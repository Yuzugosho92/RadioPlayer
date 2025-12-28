Imports System.ComponentModel
Imports System.Diagnostics.Eventing
Imports NAudio.Wave
Imports NAudio.Wave.SampleProviders
Imports System.Text.Json
Imports System.Runtime.InteropServices.Marshalling
Imports VoicevoxClientSharp
Imports Shell32
Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Text.Encodings.Web
Imports System.Text.Json.Serialization
Imports System.Runtime.InteropServices
Imports VoicevoxClientSharp.ApiClient
Imports NAudio.Gui
Imports NAudio.Utils
Imports System.Net.Mime.MediaTypeNames
Imports NAudio.CoreAudioApi
Imports System.Reflection.Emit
Imports System.Drawing.Text
Imports System.Diagnostics.CodeAnalysis
Imports System.Windows
Imports System.Threading
Imports System.Windows.Forms.VisualStyles
Imports System.Configuration
Imports NAudio
Imports System.Transactions
Imports System.Runtime.InteropServices.JavaScript.JSType

Public Class Form1

    'Dim MusicReader As AudioFileReader
    'Dim OffsetSample As OffsetSampleProvider
    'Dim volumeProvider As VolumeSampleProvider
    Dim Wo2 As WaveOut

    'Public MusicList As New MusicList
    Public TalkList As New List(Of Talk)
    Public VoiceList As New List(Of VoiceCharacter)

    Public Setting As New Setting

    Dim Rnd As New Random

    'Public SelectMusic As Music

    Dim OnTalk As Boolean

    Public TrafficInfoList As New TrafficInfo

    Dim TimeWhenTraffic As Date

    Dim MusicPlayer As MusicPlayer
    Dim TalkPlayer As TalkPlayer

    Dim RadioControl As RadioControl

    'フォームスタート
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '音楽プレイヤーをインスタンス
        MusicPlayer = New MusicPlayer(Setting)

        'トークプレイヤーをインスタンス
        TalkPlayer = New TalkPlayer(Setting)

        'ロードクラスで各JSONを読み込む
        Dim Load As New Load

        '基本設定を読み込む
        Load.Load(Setting, "Settingファイル", "Setting.json")
        '音楽情報を読み込む
        Load.Load(MusicPlayer.MusicList, "音楽リスト", "List.json")
        'トークパターンを読み込む
        Load.Load(TalkPlayer.TalkList, "トークパターンファイル", "TalkList.json")
        'キャラクター情報を読み込む
        Load.Load(TalkPlayer.VoiceList, "ボイスリスト", "VoiceList.json")
        '交通情報ファイルを読み込む
        Load.Load(TrafficInfoList, "交通情報ファイル", "TrafficInfo.json")

        'ラジオコントロールをインスタンス
        RadioControl = New RadioControl(Setting, MusicPlayer, TalkPlayer)

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



    '再生or一時停止ボタン
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MusicPlayer.SelectMusic Is Nothing Then

            RadioControl.MusicChange()

            Button1.Text = "一時停止"

        Else
            Button1.Text = MusicPlayer.PalyOrStop()

        End If





        NUD_StartTime.Value = MusicPlayer.SelectMusic.StartTime
        NUD_EndingTime.Value = MusicPlayer.SelectMusic.EndingTime
        NUD_IntroTime.Value = MusicPlayer.SelectMusic.IntroTime
        NUD_OutroTime.Value = MusicPlayer.SelectMusic.OutroTime
        NUD_IntroMaxLength.Value = MusicPlayer.SelectMusic.IntroMaxLength

        Label8.Text = "Gein : " & MusicPlayer.SelectMusic.Gein

        'Timer1.Start()

        Label1.Refresh()




    End Sub


    Dim MusicLength As Integer
    Dim GenreCount As Integer



    '曲をチェンジする
    Public Overloads Sub MusicChange()
        RadioControl.MusicChange()

        NUD_StartTime.Value = MusicPlayer.SelectMusic.StartTime
        NUD_EndingTime.Value = MusicPlayer.SelectMusic.EndingTime
        NUD_IntroTime.Value = MusicPlayer.SelectMusic.IntroTime
        NUD_OutroTime.Value = MusicPlayer.SelectMusic.OutroTime
        NUD_IntroMaxLength.Value = MusicPlayer.SelectMusic.IntroMaxLength

        Label8.Text = "Gein : " & MusicPlayer.SelectMusic.Gein
        Button1.Text = "一時停止"

        'タイトルテロップを描画
        Label1.Refresh()

        '監視タイマーを動かす
        Timer1.Start()
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




    'VOICEVOXで文字列からwavバイト配列を生成
    Private Async Function VoicevoxCreate(Str As String, Voice As Integer) As Task(Of Byte())

        Dim Bt As Byte()

        Try
            Bt = Await TalkPlayer.TextByteCreate(Str, Voice)

            'バイト配列を取り出す
            Return Bt

        Catch ex As Net.Http.HttpRequestException
            Label10.Text = "VOICEVOX本体が起動していません"

            Return Nothing

        End Try

    End Function





    'Wavバイト配列を再生する
    Private Async Function ByteArrayPlay(bt As Byte(), OnFull As Boolean) As Task


        Await TalkPlayer.ByteArrayPlay(bt, OnFull)



    End Function








    Public Function MusicTag(FileName As String, i As Integer) As String

        Dim shell As New ShellClass
        Dim f As Folder = shell.NameSpace(IO.Path.GetDirectoryName(FileName))
        Dim item As FolderItem = f.ParseName(IO.Path.GetFileName(FileName))

        Return f.GetDetailsOf(item, i)




    End Function


    'ソフトを終了するとき
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        '保存作業をするクラスをインスタンス
        Dim Save As New Save

        '基本設定を保存する
        Save.Save(Setting, "Setting.json")
        '音楽情報を保存する
        Save.Save(MusicPlayer.MusicList, "List.json")
        'キャラクター情報を保存する
        Save.Save(TalkPlayer.VoiceList, "VoiceList.json")
    End Sub


    Private Sub Label2_DragEnter(sender As Object, e As DragEventArgs) Handles Label2.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub


    '音楽ファイルがドロップされた時
    Private Sub Label2_DragDrop(sender As Object, e As DragEventArgs) Handles Label2.DragDrop
        Dim InNewMusic As Boolean

        Dim SelectMusic As Music

        'コントロール内にドロップされたとき実行される
        'ドロップされたすべてのファイル名を取得する
        Dim FileName As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop, False), String())

        '音楽ファイルを解析
        For i As Integer = 0 To FileName.Length - 1

            Dim Extension = Path.GetExtension(FileName(i)).ToLower

            '音楽ファイルならば、解析作業に入る
            Select Case Extension
                Case ".flac", ".mp3", ".mp4", ".wav", ".m4a"

                    'すでに同じファイルが登録されていないか確認
                    For Each oMu As Music In MusicPlayer.MusicList
                        '登録されていたら、このファイルを解析しない
                        If oMu.FileName = FileName(i) Then
                            GoTo L1
                        End If
                    Next

                    '新しい音楽データ箱を作成
                    Dim oMusic As New Music

                    '各種データを登録
                    oMusic.Type = "Music"
                    oMusic.FileName = FileName(i)
                    oMusic.StartTime = 0

                    '音楽ファイルのタグを開く
                    Dim shell As New ShellClass
                    Dim f = shell.NameSpace(Path.GetDirectoryName(oMusic.FileNameFull))
                    Dim item = f.ParseName(Path.GetFileName(oMusic.FileNameFull))


                    Dim MusicLength As Date = DateTime.Parse(f.GetDetailsOf(item, 27))
                    oMusic.EndingTime = Math.Min(120, MusicLength.Minute * 60 + MusicLength.Second)

                    oMusic.Title = f.GetDetailsOf(item, 21)
                    oMusic.TitleSort = f.GetDetailsOf(item, 310)

                    If oMusic.Title = "" Then
                        oMusic.Title = IO.Path.GetFileNameWithoutExtension(oMusic.FileNameFull)
                    End If

                    If f.GetDetailsOf(item, 237) = "" Then
                        oMusic.Artist = f.GetDetailsOf(item, 20)
                    Else
                        oMusic.Artist = f.GetDetailsOf(item, 237)
                    End If

                    oMusic.ArtistSort = f.GetDetailsOf(item, 241)


                    MusicPlayer.MusicList.Add(oMusic)


                    'リストビューに追加
                    Dim oListViewItem As ListViewItem = ListView1.Items.Add(oMusic.Title)

                    oListViewItem.SubItems.Add(oMusic.Artist)
                    oListViewItem.SubItems.Add(oMusic.Type)
                    oListViewItem.Tag = oMusic

                    SelectMusic = oMusic
                    InNewMusic = True

            End Select

L1:     Next


        If InNewMusic Then


            MusicPlayer.Change(SelectMusic)
        End If

    End Sub

    'タイミング調整の値を変更する
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button50.Click

        MusicPlayer.SelectMusic.StartTime = CInt(NUD_StartTime.Value)
        MusicPlayer.SelectMusic.EndingTime = CInt(NUD_EndingTime.Value)
        MusicPlayer.SelectMusic.IntroTime = CInt(NUD_IntroTime.Value)
        MusicPlayer.SelectMusic.OutroTime = CInt(NUD_OutroTime.Value)
        MusicPlayer.SelectMusic.IntroMaxLength = CInt(NUD_IntroMaxLength.Value)

        If Setting.FullChorus OrElse MusicPlayer.SelectMusic.EndingTime = 0 Then
            MusicLength = MusicPlayer.MusicReader.TotalTime.TotalSeconds
        Else
            MusicLength = CInt(NUD_EndingTime.Value)
        End If

    End Sub

    '10秒進める
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MusicPlayer.Skip(MusicPlayer.MusicReader.CurrentTime.TotalSeconds + 10)
    End Sub

    '10秒戻す
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MusicPlayer.Skip(MusicPlayer.MusicReader.CurrentTime.TotalSeconds - 10)
    End Sub


    '「この時間！」ボタン
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        MusicPlayer.SelectMusic.EndingTime = MusicPlayer.MusicReader.CurrentTime.TotalSeconds + 10

        NUD_EndingTime.Value = MusicPlayer.SelectMusic.EndingTime

        'フルコーラス再生でない場合、曲の長さを設定
        If Setting.FullChorus = False AndAlso MusicPlayer.SelectMusic.EndingTime > 0 Then
            MusicPlayer.MusicLength = MusicPlayer.SelectMusic.EndingTime
        End If

    End Sub

    '再生位置をラスト15秒前まで飛ばす
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button4.Click

        '再生位置をラスト15秒前まで飛ばす
        MusicPlayer.Skip(MusicPlayer.MusicLength - 15)

        ''曲が再生していない場合、なにもしない
        'If Wo Is Nothing OrElse Wo.PlaybackState <> PlaybackState.Playing Then
        '    Exit Sub
        'End If





        'トークプレイヤーがある場合
        If Wo2 IsNot Nothing Then
            Wo2.Stop()
        End If


    End Sub


    ''再生位置を動かすメソッド
    'Public Sub MusicSkip(Time As Integer)
    '    '再生位置を指定
    '    MusicReader.CurrentTime = TimeSpan.FromSeconds(Time)
    'End Sub


    'フルコーラス設定を反転する
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        MusicPlayer.EndingTimeChange()

        'If Wo Is Nothing OrElse Not Wo.PlaybackState = PlaybackState.Playing Then
        '    Exit Sub
        'End If

        'If CheckBox1.Checked OrElse SelectMusic.EndingTime = 0 Then
        '    MusicLength = MusicReader.TotalTime.TotalSeconds
        'Else
        '    MusicLength = SelectMusic.EndingTime
        'End If
    End Sub


    '音量バー
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        MusicPlayer.Volume(e.NewValue)
    End Sub


    '情報ラベルを再描画
    Private Sub Label1_Paint(sender As Object, e As PaintEventArgs) Handles Label1.Paint





        If MusicPlayer.SelectMusic IsNot Nothing Then
            e.Graphics.DrawString(MusicPlayer.SelectMusic.Title, Label1.Font, Brushes.LightPink, 0, 2)

            e.Graphics.DrawString(MusicPlayer.SelectMusic.Artist, Label1.Font, Brushes.White, 0, 42)



        End If





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
        End If






    End Sub



    'リストから再生
    Private Sub PlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayToolStripMenuItem.Click

        'トークプレイヤーがある場合
        If Wo2 IsNot Nothing Then
            Bt.Clear()

            Wo2.Stop()


        End If



        MusicPlayer.Change(ListView1.SelectedItems(0).Tag)



        NUD_StartTime.Value = MusicPlayer.SelectMusic.StartTime
        NUD_EndingTime.Value = MusicPlayer.SelectMusic.EndingTime
        NUD_IntroTime.Value = MusicPlayer.SelectMusic.IntroTime
        NUD_OutroTime.Value = MusicPlayer.SelectMusic.OutroTime
        NUD_IntroMaxLength.Value = MusicPlayer.SelectMusic.IntroMaxLength

        Label8.Text = "Gein : " & MusicPlayer.SelectMusic.Gein
        Button1.Text = "一時停止"

        'タイトルテロップを描画
        Label1.Refresh()

        '監視タイマーを動かす
        Timer1.Start()
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

    Private Sub DelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DelToolStripMenuItem.Click

        'トークプレイヤーがある場合
        If Wo2 IsNot Nothing Then
            Wo2.Stop()
        End If

        'If Wo IsNot Nothing Then
        '    Wo.Stop()
        '    Wo.Dispose()
        'End If


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


    '交通情報を流す
    Dim Bt As Dictionary(Of Integer, Byte())

    Private Async Sub TrafficInfo()

        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        CheckBox1.Enabled = False
        GroupBox1.Enabled = False

        '次の曲を選曲
        MusicChange()

        'Do
        '    Dim i As Integer

        '    '次の曲を選ぶ乱数を設定
        '    i = Rnd.Next(0, MusicList.Count)

        '    If MusicList(i).TypeEnum = Music.WaveType.Traffic Then
        '        MusicChange(MusicList(i))
        '        Exit Do
        '    End If

        'Loop

        'MCを選択
        Dim SelectedVoiceMC As VoiceCharacter

        '使用許可があるボイスが出るまで抽選
        Do
            Dim Num As Integer = Rnd.Next(0, VoiceList.Count)

            If VoiceList(Num).TrafficMcUse Then
                SelectedVoiceMC = VoiceList(Num)
                Exit Do
            End If
        Loop

        '情報センター担当者を選択
        Dim SelectedVoiceCenter As VoiceCharacter

        '使用許可があるボイスが出るまで抽選
        Do
            Dim Num As Integer = Rnd.Next(0, VoiceList.Count)

            If VoiceList(Num).TrafficCenterUse Then
                SelectedVoiceCenter = VoiceList(Num)
                Exit Do
            End If
        Loop




        Dim Scenario As New List(Of TrafficInfo.Scenario)

        Scenario.AddRange(TrafficInfoList.McScenario(Setting, SelectedVoiceMC, SelectedVoiceCenter))

        Scenario.InsertRange(1, TrafficInfoList.CenterScenario(Setting, SelectedVoiceCenter))

        Bt = New Dictionary(Of Integer, Byte())

        '冒頭の音声を作成
        Bt.Add(0, Await VoicevoxCreate(Scenario(0).Text, Scenario(0).Voice.Id))

        '続く音声を順次作成
        Parallel.For(1, Scenario.Count, Async Sub(i)

                                            Bt.Add(i, Await VoicevoxCreate(Scenario(i).Text, Scenario(i).Voice.Id)）

                                        End Sub)


        'テキストを表示
        Label10.Text = "By." & Scenario(0).Voice.Name & vbCrLf & Scenario(0).Text
        Await ByteArrayPlay(Bt(0), True)

        For i As Integer = 1 To Scenario.Count - 1
            'テキストを表示
            Label10.Text = "By." & Scenario(i).Voice.Name & vbCrLf & Scenario(i).Text
            '音声を再生
            If Bt IsNot Nothing AndAlso Bt.ContainsKey(i) Then
                Await ByteArrayPlay(Bt(i), True)
            End If
        Next

        '今の時刻を記録する
        TimeWhenTraffic = Now

        GenreCount = 0
        OnTalk = False

        Try
            If Bt IsNot Nothing AndAlso Bt.Count > 0 Then
                Bt.Clear()
                Bt = Nothing
                '音量をフェードアウトする
                BackgroundWorker1.RunWorkerAsync()
            End If
        Catch ex As Exception
            'スルー
        End Try

        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        CheckBox1.Enabled = True
        GroupBox1.Enabled = True
    End Sub


    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click

        Dim F As New Form4

        'サブフォームを起動
        F.ShowDialog(Me, Setting)

    End Sub

    '次の曲へボタン
    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click

        'タイマーを止める
        Timer1.Stop()
        'トーク中を解除
        OnTalk = False

        If Wo2 IsNot Nothing Then
            Wo2.Stop()
        End If

        If Bt IsNot Nothing Then
            Bt.Clear()
            Bt = Nothing
        End If

        MusicChange()

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
