Imports NAudio.Wave

Public Class Form1
    Dim WithEvents RadioControl As RadioControl

    Dim MusicPlayer As MusicPlayer
    Dim TalkPlayer As TalkPlayer

    'フォームスタート
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ラジオコントロールをインスタンス
        RadioControl = New RadioControl(Me)

        MusicPlayer = RadioControl.MusicPlayer
        TalkPlayer = RadioControl.TalkPlayer

        'ロードクラスで各JSONを読み込む
        Dim Load As New Load
        Load.Load(RadioControl)

        RadioControl.InfoText = "ロード完了"
        Label8.Text = MusicPlayer.MusicList.Count & "曲"

        'リストビューに音楽を登録
        For Each oMusic As Music In MusicPlayer.MusicList
            Dim oListViewItem As ListViewItem = ListView1.Items.Add(oMusic.Title)
            oListViewItem.SubItems.Add(oMusic.Artist)
            oListViewItem.SubItems.Add(oMusic.Type)
            oListViewItem.Tag = oMusic
        Next

        'リストビューのカラムサイズを調整
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub


    'ソフトを終了するとき
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        '各設定を保存する
        Dim Save As New Save
        Save.Save(RadioControl)
    End Sub


    '再生or一時停止ボタン
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MusicPlayer.SelectMusic Is Nothing Then

            RadioControl.MusicChange()

            Button1.Text = "一時停止"

        Else
            Button1.Text = MusicPlayer.PalyOrStop()

        End If

    End Sub


    '曲をチェンジした時
    Private Sub Music_Changed(sender As Object, e As System.EventArgs) Handles RadioControl.OnMusicChange
        'タイミング調整の値を変更
        NUD_StartTime.Value = MusicPlayer.SelectMusic.StartTime
        NUD_EndingTime.Value = MusicPlayer.SelectMusic.EndingTime
        NUD_IntroTime.Value = MusicPlayer.SelectMusic.IntroTime
        NUD_OutroTime.Value = MusicPlayer.SelectMusic.OutroTime
        NUD_IntroMaxLength.Value = MusicPlayer.SelectMusic.IntroMaxLength

        Label8.Text = "Gein : " & MusicPlayer.SelectMusic.Gein
        Button1.Text = "一時停止"

        'タイトルテロップを描画
        Label1.Refresh()
    End Sub


    '監視タイマー
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '定時確認メソッドを起動
        RadioControl.Tick()

        'トークテキストを更新
        Label10.Text = RadioControl.InfoText

        '情報フォームを再描画
        Label1.Refresh()

    End Sub


    '音楽ファイルがドラッグされた時
    Private Sub Label2_DragEnter(sender As Object, e As DragEventArgs) Handles Label2.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub


    '音楽ファイルがドロップされた時
    Private Sub Label2_DragDrop(sender As Object, e As DragEventArgs) Handles Label2.DragDrop
        Dim InNewMusic As Music = Nothing

        'コントロール内にドロップされたとき実行される
        'ドロップされたすべてのファイル名を取得する
        Dim FileName As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop, False), String())

        '音楽ファイルを解析
        For i As Integer = 0 To FileName.Length - 1

            Dim oMusic = MusicPlayer.Add(FileName(i))

            If oMusic IsNot Nothing Then

                'リストビューに追加
                Dim oListViewItem As ListViewItem = ListView1.Items.Add(oMusic.Title)

                oListViewItem.SubItems.Add(oMusic.Artist)
                oListViewItem.SubItems.Add(oMusic.Type)
                oListViewItem.Tag = oMusic

                If InNewMusic Is Nothing Then
                    InNewMusic = oMusic
                End If
            End If
        Next

        'ドロップした音楽があれば、再生する
        If InNewMusic IsNot Nothing Then
            RadioControl.MusicChange(InNewMusic)
        End If

    End Sub


    'タイミング調整の値を変更する
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button50.Click

        MusicPlayer.SelectMusic.StartTime = CInt(NUD_StartTime.Value)
        MusicPlayer.SelectMusic.EndingTime = CInt(NUD_EndingTime.Value)
        MusicPlayer.SelectMusic.IntroTime = CInt(NUD_IntroTime.Value)
        MusicPlayer.SelectMusic.OutroTime = CInt(NUD_OutroTime.Value)
        MusicPlayer.SelectMusic.IntroMaxLength = CInt(NUD_IntroMaxLength.Value)

        If RadioControl.Setting.FullChorus OrElse MusicPlayer.SelectMusic.EndingTime = 0 Then
            MusicPlayer.MusicLength = MusicPlayer.MusicReader.TotalTime.TotalSeconds
        Else
            MusicPlayer.MusicLength = CInt(NUD_EndingTime.Value)
        End If

    End Sub


    '10秒進める
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If MusicPlayer.PlaybackState Then
            '時間を進める
            RadioControl.Skip(MusicPlayer.MusicReader.CurrentTime.TotalSeconds + 10)
        End If

        'トーク情報ラベルを更新
        Label10.Text = RadioControl.InfoText
    End Sub


    '10秒戻す
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If MusicPlayer.PlaybackState Then
            '時間を戻す
            RadioControl.Skip(MusicPlayer.MusicReader.CurrentTime.TotalSeconds - 10)
        End If

        'トーク情報ラベルを更新
        Label10.Text = RadioControl.InfoText
    End Sub


    '再生位置をラスト15秒前まで飛ばす
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If MusicPlayer.PlaybackState Then
            '再生位置をラスト15秒前まで飛ばす
            RadioControl.Skip(MusicPlayer.MusicLength - 15)
        End If

        'トーク情報ラベルを更新
        Label10.Text = RadioControl.InfoText
    End Sub


    '「この時間！」ボタン
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        MusicPlayer.SelectMusic.EndingTime = MusicPlayer.MusicReader.CurrentTime.TotalSeconds + 10

        NUD_EndingTime.Value = MusicPlayer.SelectMusic.EndingTime

        'フルコーラス再生でない場合、曲の長さを設定
        If RadioControl.Setting.FullChorus = False AndAlso MusicPlayer.SelectMusic.EndingTime > 0 Then
            MusicPlayer.MusicLength = MusicPlayer.SelectMusic.EndingTime
        End If

    End Sub


    'フルコーラス設定を反転する
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        MusicPlayer.EndingTimeChange()
    End Sub


    '音量バー
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        MusicPlayer.Volume(e.NewValue)
    End Sub


    '情報ラベルを再描画
    Private Sub Label1_Paint(sender As Object, e As PaintEventArgs) Handles Label1.Paint
        '文字描画位置を右寄せにする
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Far

        '時刻表示枠を指定
        Dim TimeRectangle As New RectangleF(Label1.Width - 150, 2, 148, 42)

        '現在の時刻を描画
        e.Graphics.DrawString(Format(Now, "HH:mm:ss"), Label1.Font, Brushes.White, TimeRectangle, sf)

        If MusicPlayer.SelectMusic IsNot Nothing Then
            Dim TimeCount As Integer = Int(MusicPlayer.MusicReader.CurrentTime.TotalSeconds)
            TimeRectangle = New RectangleF(Label1.Width - 150, 42, 148, 42)
            e.Graphics.DrawString(TimeCount, Label1.Font, Brushes.White, TimeRectangle, sf)


            e.Graphics.DrawString(MusicPlayer.SelectMusic.Title, Label1.Font, Brushes.LightPink, 0, 2)

            e.Graphics.DrawString(MusicPlayer.SelectMusic.Artist, Label1.Font, Brushes.White, 0, 42)


        End If
    End Sub



    'リストから再生
    Private Sub PlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayToolStripMenuItem.Click

        RadioControl.MusicChange(ListView1.SelectedItems(0).Tag)

    End Sub


    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        If e.Column > 0 Then Exit Sub

        ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column)

        ListView1.Sort()


        MusicPlayer.MusicList.Sort()

    End Sub

    '音楽情報を編集するフォームを開く
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        Dim EditMusic As Music = ListView1.SelectedItems(0).Tag

        Dim F As New Form2

        'サブフォームを起動
        If F.ShowDialog(Me, EditMusic) = DialogResult.OK Then
            '情報が更新されたらリストビューも更新
            ListView1.SelectedItems(0).SubItems(0).Text = EditMusic.Title
            ListView1.SelectedItems(0).SubItems(1).Text = EditMusic.Artist
            ListView1.SelectedItems(0).SubItems(2).Text = EditMusic.Type
        End If

    End Sub


    'リストから曲を削除
    Private Sub DelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DelToolStripMenuItem.Click

        MusicPlayer.Stop()

        TalkPlayer.Stop()

        Dim str As String = "「" & ListView1.SelectedItems(0).Text & "」を選択中" & vbCrLf
        str &= "選択中の曲を、データベースから削除しますか？" & vbCrLf & "音楽ファイル自体は残ります"


        If MessageBox.Show(str, Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then

            Dim music As Integer = MusicPlayer.MusicList.IndexOf(ListView1.SelectedItems(0).Tag)
            '音楽リストから削除
            MusicPlayer.MusicList.RemoveAt(music)
            'リストビューからも削除
            ListView1.SelectedItems(0).Remove()

        End If

    End Sub



    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click

        Dim F As New Form4

        'サブフォームを起動
        F.ShowDialog(Me, RadioControl)

    End Sub

    '次の曲へボタン
    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click

        TalkPlayer.WoClose()

        If MusicPlayer.SelectMusic.TypeEnum <> Music.WaveType.Traffic Then
            RadioControl.MusicChange()
        End If

    End Sub

    'ラジオコントロールの情報文が変更された時
    Private Sub InfoTextChange(sender As Object, e As EventArgs) Handles RadioControl.InfoTextChange
        Label10.Text = RadioControl.InfoText
    End Sub



End Class





''' <summary>
''' ListViewの項目の並び替えに使用するクラス
''' </summary>
Public Class ListViewItemComparer
    Implements IComparer
    Private _column As Integer

    ''' <summary>
    ''' ListViewItemComparerクラスのコンストラクタ
    ''' </summary>
    ''' <param name="col">並び替える列番号</param>
    Public Sub New(ByVal col As Integer)
        _column = col
    End Sub

    'xがyより小さいときはマイナスの数、大きいときはプラスの数、
    '同じときは0を返す
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        'ListViewItemの取得
        Dim itemx As ListViewItem = CType(x, ListViewItem)
        Dim itemy As ListViewItem = CType(y, ListViewItem)

        'xとyを比較する
        Return DirectCast(itemx.Tag, Music).CompareTo(DirectCast(itemy.Tag, Music))
    End Function
End Class



Public Class WeighingGain

    Public Function WeingingGein(FileName As String) As Single

        Dim targetRmsDb As Double = -20.0F

        Dim rms As Double = GetRmsLevel(FileName)
        Dim rmsDb As Double = 20 * Math.Log10(rms)

        Dim gainDb As Double = targetRmsDb - rmsDb
        Dim gain As Single = CSng(Math.Pow(10, gainDb / 20))

        Return gain

    End Function


    Function GetRmsLevel(mp3Path As String) As Double
        Using reader As New AudioFileReader(mp3Path)
            Dim buffer(1023) As Single
            Dim read As Integer
            Dim sumSquares As Double = 0
            Dim count As Long = 0

            Do
                read = reader.Read(buffer, 0, buffer.Length)
                For i = 0 To read - 1
                    sumSquares += buffer(i) * buffer(i)
                    count += 1
                Next
            Loop While read > 0

            Return Math.Sqrt(sumSquares / count)
        End Using
    End Function

End Class
