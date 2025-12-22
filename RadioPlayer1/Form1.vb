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

Public Class Form1

    Dim MusicReader As AudioFileReader
    Dim OffsetSample As OffsetSampleProvider
    Dim volumeProvider As VolumeSampleProvider
    Dim Wo As WaveOut

    Dim MusicList As New MusicList
    Dim TalkList As New List(Of Talk)

    Dim Rnd As New Random

    Public SelectMusic As Music

    Dim OnTalk As Boolean

    Dim VoiceList As New List(Of VoiceCharacter)

    'フォームスタート
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            'JSONファイルを読み込む
            JsonInput()

            'リストビューに音楽を登録
            For i As Integer = 0 To MusicList.Count - 1
                ListView1.Items.Add(MusicList(i).Title)
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(MusicList(i).Artist)
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(MusicList(i).Type)
                ListView1.Items(ListView1.Items.Count - 1).Tag = MusicList(i)
            Next

            'リストビューのカラムサイズを調整
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        Catch ex As IO.FileNotFoundException
            '音楽情報ファイルがなければ、そのまま進行
        End Try

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Wo Is Nothing OrElse SelectMusic Is Nothing Then
            Button1.Text = "一時停止"
            '次の曲を再生
            MusicChange()

        ElseIf Wo.PlaybackState = PlaybackState.Playing Then
            Button1.Text = "再開"
            Wo.Stop()
        Else

            If CheckBox1.Checked OrElse SelectMusic.EndingTime = 0 Then
                MusicLength = MusicReader.TotalTime.TotalSeconds
            Else
                MusicLength = SelectMusic.EndingTime
            End If

            Button1.Text = "一時停止"
            Wo.Play()
        End If

    End Sub


    Dim MusicLength As Integer
    Dim GenreCount As Integer



    '曲をチェンジする
    Public Overloads Sub MusicChange()

        '次の曲を選曲
        Dim i As Integer
        Do
            '次の曲を選ぶ乱数を設定
            i = Rnd.Next(0, MusicList.Count)
            Dim IsExiter As Boolean

            '前曲がNothingか、同じ曲では無い場合
            If SelectMusic Is Nothing OrElse Not MusicList(i).FileName = SelectMusic.FileName Then
                IsExiter = True
            End If

            If GenreCount >= 3 AndAlso SelectMusic.TypeEnum = Music.WaveType.Music Then
                If MusicList(i).TypeEnum = Music.WaveType.Jingle OrElse MusicList.ExistsType(Music.WaveType.Jingle) = False Then
                    IsExiter = True
                    GenreCount = 0
                Else
                    IsExiter = False
                End If
            ElseIf GenreCount >= 1 AndAlso SelectMusic.TypeEnum = Music.WaveType.Jingle Then
                If MusicList(i).TypeEnum = Music.WaveType.Music Then
                    IsExiter = True
                    GenreCount = 0
                Else
                    IsExiter = False
                End If
            End If

            If IsExiter Then
                MusicChange(MusicList(i))
                Exit Do
            End If

        Loop



    End Sub


    Public Overloads Sub MusicChange(music As Music)
        '前の曲が登録されていれば
        If Wo IsNot Nothing Then
            '演奏を終了し破棄する
            Wo.Stop()
            Wo.Dispose()
            '監視タイマーを止める
            Timer1.Stop()

            Label10.Text = ""
        End If

        '選択した曲を登録する
        SelectMusic = music

        'プレイヤーを召喚
        Wo = New WaveOut

        Try
            'パスから曲を読み込み
            MusicReader = New AudioFileReader(SelectMusic.FileNameFull)
        Catch ex As IO.FileNotFoundException
            '音楽を再生中ならば停止
            If Wo IsNot Nothing Then
                Wo.Stop()
            End If

            '曲の選択を解除
            SelectMusic = Nothing

            'ジャンル再生カウントをリセット
            GenreCount = 0

            'タイトルテロップを描画
            Label1.Refresh()

            'メッセージを表示
            MessageBox.Show("音楽ファイルが見つかりませんでした", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End Try


        MusicPlay()

    End Sub



    Private Sub MusicPlay()

        If ToolStripMenuItem3.Checked OrElse SelectMusic.Gein = 0 Then
            'ゲイン値を計算
            Dim Gain = New WeighingGain
            MusicReader.Volume = Gain.WeingingGein(SelectMusic.FileNameFull)

            SelectMusic.Gein = MusicReader.Volume
        Else
            MusicReader.Volume = SelectMusic.Gein
        End If


        Label8.Text = "Gein : " & SelectMusic.Gein


        OffsetSample = New OffsetSampleProvider(MusicReader)
        volumeProvider = New VolumeSampleProvider(MusicReader)

        '曲の開始時間を設定
        OffsetSample.SkipOver = TimeSpan.FromSeconds(SelectMusic.StartTime)

        Wo.Init(MusicReader)
        Wo.Init(volumeProvider)

        'プレーヤーを再生
        Wo.Play()




        '曲の終了位置を設定
        If SelectMusic.EndingTime = 0 OrElse CheckBox1.Checked Then
            MusicLength = MusicReader.TotalTime.TotalSeconds
        Else
            OffsetSample.Take = TimeSpan.FromSeconds(SelectMusic.EndingTime)
            MusicLength = SelectMusic.EndingTime
        End If

        NUD_StartTime.Value = SelectMusic.StartTime
        NUD_EndingTime.Value = SelectMusic.EndingTime
        NUD_IntroTime.Value = SelectMusic.IntroTime
        NUD_OutroTime.Value = SelectMusic.OutroTime
        NUD_IntroMaxLength.Value = SelectMusic.IntroMaxLength

        GenreCount += 1


        Button1.Text = "一時停止"

        'タイトルテロップを描画
        Label1.Refresh()

        '監視タイマーを動かす
        Timer1.Start()





    End Sub





    '監視タイマー
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim TimeCount As Integer = Int(MusicReader.CurrentTime.TotalSeconds)

        Dim Count As Integer

        'イントロトークの時間が来たら喋る
        If TimeCount = SelectMusic.IntroTime Then

            'トークリストが無ければ、なにもしない
            If TalkList Is Nothing OrElse TalkList.Count = 0 Then
                Label10.Text = "トークパターンが読み込まれていません"
                Exit Sub
            End If

            'ボイスリストが無ければ、なにもしない
            If VoiceList Is Nothing OrElse VoiceList.Count = 0 Then
                Label10.Text = "ボイスリストが読み込まれていません"
                Exit Sub
            End If

            '使用許可があるボイスが居ない場合、なにもしない
            For Each oVoice As VoiceCharacter In VoiceList
                Count += CInt(oVoice.Use)
            Next

            If Count = 0 Then
                Label10.Text = "ボイスが選択されていません"
                Exit Sub
            End If

            '選曲中のタイプが音楽ならば
            If SelectMusic.TypeEnum = Music.WaveType.Music Then

                Dim oTalk As Talk
                Dim Tx As String 'テロップ表示用
                Dim Scenario As String 'スピーク用

                'DJを選択
                Dim SelectedVoice As Integer

                '使用許可があるボイスが出るまで抽選
                Do
                    SelectedVoice = Rnd.Next(0, VoiceList.Count)

                    If VoiceList(SelectedVoice).Use Then
                        Exit Do
                    End If
                Loop

                Do
                    '台本を抽選
Scenario1:          oTalk = TalkList(Rnd.Next(0, TalkList.Count))

                    'イントロ用ならDoを出る
                    If oTalk.TypeEnum = Talk.TalkType.Intro Then
                        Exit Do
                    End If
                Loop

                '台本を入力
                Tx = oTalk.Text
                Scenario = oTalk.Text

                'タイトルとアーティストを置き換え
                If SelectMusic.ArtistSort Is Nothing OrElse SelectMusic.ArtistSort = "" Then
                    Scenario = Scenario.Replace("[Artist]", SelectMusic.Artist)
                Else
                    Scenario = Scenario.Replace("[Artist]", SelectMusic.ArtistSort)
                End If

                If SelectMusic.TitleSort Is Nothing OrElse SelectMusic.TitleSort = "" Then
                    Scenario = Scenario.Replace("[Title]", SelectMusic.Title)
                Else
                    Scenario = Scenario.Replace("[Title]", SelectMusic.TitleSort)
                End If

                '自己紹介文を登録
                Scenario = VoiceList(SelectedVoice).MySelf & "。" & Scenario

                'もしトーク文が長過ぎたら、再抽選
                If SelectMusic.IntroMaxLength > 0 AndAlso Scenario.Length > SelectMusic.IntroMaxLength Then
                    GoTo Scenario1
                End If

                Tx = Tx.Replace("[Artist]", SelectMusic.Artist)
                Tx = Tx.Replace("[Title]", SelectMusic.Title)

                Label10.Text = Tx & vbCrLf
                Label10.Text &= "by. " & VoiceList(SelectedVoice).Name & vbCrLf & "(" & Tx.Length & "文字" & ") (" & SelectMusic.PlayCount + 1 & "回目)"



                ZundamonTalk(Scenario, VoiceList(SelectedVoice).Id)
            End If

        End If

        'アウトロトークの時間が来たら喋る
        If TimeCount = (MusicLength - SelectMusic.OutroTime) AndAlso OnTalk = False Then

            'トークリストが無ければ、なにもしない
            If TalkList Is Nothing OrElse TalkList.Count = 0 Then
                Label10.Text = "トークパターンが読み込まれていません"
                Exit Sub
            End If

            'ボイスリストが無ければ、なにもしない
            If VoiceList Is Nothing OrElse VoiceList.Count = 0 Then
                Label10.Text = "ボイスリストが読み込まれていません"
                Exit Sub
            End If

            '使用許可があるボイスが居ない場合、なにもしない
            For Each oVoice As VoiceCharacter In VoiceList
                Count += CInt(oVoice.Use)
            Next

            If Count = 0 Then
                Label10.Text = "ボイスが選択されていません"
                Exit Sub
            End If

            If SelectMusic.TypeEnum = Music.WaveType.Music Then

                Dim oTalk As Talk
                Dim Tx As String 'テロップ表示用
                Dim Scenario As String 'スピーク用

                'DJを選択
                Dim SelectedVoice As Integer

                '使用許可があるボイスが出るまで抽選
                Do
                    SelectedVoice = Rnd.Next(0, VoiceList.Count)

                    If VoiceList(SelectedVoice).Use Then
                        Exit Do
                    End If
                Loop

                Do
                    '台本を抽選
                    oTalk = TalkList(Rnd.Next(0, TalkList.Count))

                    'アウトロ用ならDoを出る
                    If oTalk.TypeEnum = Talk.TalkType.Outro Then
                        Exit Do
                    End If
                Loop

                '台本を入力
                Tx = oTalk.Text
                Scenario = oTalk.Text

                'タイトルとアーティストを置き換え
                If SelectMusic.ArtistSort Is Nothing OrElse SelectMusic.ArtistSort = "" Then
                    Scenario = Scenario.Replace("[Artist]", SelectMusic.Artist)
                Else
                    Scenario = Scenario.Replace("[Artist]", SelectMusic.ArtistSort)
                End If

                If SelectMusic.TitleSort Is Nothing OrElse SelectMusic.TitleSort = "" Then
                    Scenario = Scenario.Replace("[Title]", SelectMusic.Title)
                Else
                    Scenario = Scenario.Replace("[Title]", SelectMusic.TitleSort)
                End If

                Tx = Tx.Replace("[Artist]", SelectMusic.Artist)
                Tx = Tx.Replace("[Title]", SelectMusic.Title)

                Label10.Text = Tx & vbCrLf
                Label10.Text &= "by. " & VoiceList(SelectedVoice).Name & vbCrLf & "(" & Tx.Length & "文字" & ") (" & SelectMusic.PlayCount + 1 & "回目)"

                ZundamonTalk(Scenario, VoiceList(SelectedVoice).Id)

                OnTalk = True

            ElseIf SelectMusic.TypeEnum = Music.WaveType.Jingle Then
                'タイプがジングルならば

                'ボイスリストが無ければ、なにもしない
                If VoiceList Is Nothing OrElse VoiceList.Count = 0 Then
                    Label10.Text = "ボイスリストが読み込まれていません"
                    Exit Sub
                End If

                '使用許可があるボイスが居ない場合、なにもしない
                For Each oVoice As VoiceCharacter In VoiceList
                    Count += CInt(oVoice.Use)
                Next

                If Count = 0 Then
                    Label10.Text = "ボイスが選択されていません"
                    Exit Sub
                End If

                Dim oTalk As Talk
                Dim Tx As String 'テロップ表示用
                Dim Scenario As String 'スピーク用

                'DJを選択
                Dim SelectedVoice As Integer

                '使用許可があるボイスが出るまで抽選
                Do
                    SelectedVoice = Rnd.Next(0, VoiceList.Count)

                    If VoiceList(SelectedVoice).Use Then
                        Exit Do
                    End If
                Loop

                Do
                    '台本を抽選
                    oTalk = TalkList(Rnd.Next(0, TalkList.Count))

                    'コール用ならDoを出る
                    If oTalk.TypeEnum = Talk.TalkType.Call Then
                        Exit Do
                    End If
                Loop

                '台本を入力
                Tx = oTalk.Text
                Scenario = oTalk.Text

                Label10.Text = Tx & vbCrLf
                Label10.Text &= "by. " & VoiceList(SelectedVoice).Name

                ZundamonTalk(Scenario, VoiceList(SelectedVoice).Id)

                OnTalk = True
            End If

        End If






        '曲が終了する3秒前ならば
        Select Case TimeCount
            Case Is >= (MusicLength - 3)
                'タイマーを止める
                Timer1.Stop()
                '再生カウントを追加
                SelectMusic.PlayCount += 1
                'トーク中を解除
                OnTalk = False
                '音量をフェードアウトする
                BackgroundWorker1.RunWorkerAsync()
        End Select


        Label1.Refresh()






    End Sub




    'フェードアウト処理
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim i As Integer
        For i = 1 To 10
            '1秒間待機する（時間のかかる処理があるものとする）
            System.Threading.Thread.Sleep(200)

            'ProgressChangedイベントハンドラを呼び出し、
            'コントロールの表示を変更する
            BackgroundWorker1.ReportProgress(i)
        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        MusicReader.Volume = Math.Max(0, MusicReader.Volume - 0.1)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MusicChange()
    End Sub


    'JSONファイル読み込み
    Private Sub JsonInput()

        '曲が再生されていたら止める
        If Wo IsNot Nothing Then
            Wo.Stop()
            Timer1.Stop()

            Label10.Text = "Now Loading..."
        End If

        '音楽リストをクリアする
        If MusicList IsNot Nothing Then
            MusicList.Clear()
        End If


        Dim Reader As IO.StreamReader
        Dim str As String

        Try
            '音楽情報ファイルを開く
            Reader = New IO.StreamReader(My.Application.Info.DirectoryPath & "\Setting\List.json")
            'JSON文字列を一括で読み取る
            str = Reader.ReadToEnd
            'ファイルを閉じる
            Reader.Close()

            'JSON文字列を音楽情報クラスに登録
            MusicList = JsonSerializer.Deserialize(Of MusicList)(str)

        Catch ex As FileNotFoundException
            '音楽情報ファイルが無い場合、スルーする
        Catch ex As System.Text.Json.JsonException
            'JSONの記述ミスがある場合
            MessageBox.Show("音楽リストに記述ミスがありそうです" & vbCrLf & vbCrLf & ex.Message, Me.Text, 0, MessageBoxIcon.Error)
        End Try


        Try
            'トークパターンファイルを開く
            Reader = New IO.StreamReader(My.Application.Info.DirectoryPath & "\Setting\TalkList.json")
            'JSON文字列を一括で読み取る
            str = Reader.ReadToEnd
            'ファイルを閉じる
            Reader.Close()

            TalkList = JsonSerializer.Deserialize(Of List(Of Talk))(str)

        Catch ex As FileNotFoundException
            'トークパターンファイルが無い場合、スルーする
        Catch ex As System.Text.Json.JsonException
            'JSONの記述ミスがある場合
            MessageBox.Show("トークパターンリストに記述ミスがありそうです" & vbCrLf & vbCrLf & ex.Message, Me.Text, 0, MessageBoxIcon.Error)
        End Try


        Try
            'ボイスパターンファイルを開く
            Reader = New IO.StreamReader(My.Application.Info.DirectoryPath & "\Setting\VoiceList.json")
            'JSON文字列を一括で読み取る
            str = Reader.ReadToEnd
            'ファイルを閉じる
            Reader.Close()

            VoiceList = JsonSerializer.Deserialize(Of List(Of VoiceCharacter))(str)

        Catch ex As FileNotFoundException
            'ボイスパターンファイルが無い場合、スルーする
        Catch ex As System.Text.Json.JsonException
            'JSONの記述ミスがある場合
            MessageBox.Show("ボイスリストに記述ミスがありそうです" & vbCrLf & vbCrLf & ex.Message, Me.Text, 0, MessageBoxIcon.Error)
        End Try

        Label10.Text = "ロード完了"
        Label8.Text = MusicList.Count & "曲"

    End Sub



    Dim player As System.Media.SoundPlayer

    '文字列をVOICEVOXに喋らせる
    'https://github.com/TORISOUP/VoicevoxClientSharp
    Private Async Sub ZundamonTalk(Str As String, Voice As Integer)
        Dim synthesizer = New VoicevoxSynthesizer()

        ' styleId = (Await synthesizer.FindStyleIdByNameAsync("四国めたん", "あまあま")).Value

        Try
            Await synthesizer.InitializeStyleAsync(Voice)

            Dim result = Await synthesizer.SynthesizeSpeechAsync(Voice, Str,,,, 1.5)

            'オーディオリソースを取り出す
            Dim strm As System.IO.Stream = New IO.MemoryStream(result.Wav)
            '同期再生する
            player = New System.Media.SoundPlayer(strm)
            player.Play()
            '後始末
            player.Dispose()

        Catch ex As Net.Http.HttpRequestException
            Label10.Text = "VOICEVOX本体が起動していません"
        End Try


    End Sub



    Public Function MusicTag(FileName As String, i As Integer) As String

        Dim shell As New ShellClass
        Dim f As Folder = shell.NameSpace(IO.Path.GetDirectoryName(FileName))
        Dim item As FolderItem = f.ParseName(IO.Path.GetFileName(FileName))

        Return f.GetDetailsOf(item, i)




    End Function


    'ソフトを終了するとき
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        '音楽情報を保存する
        Dim options As New JsonSerializerOptions
        options.WriteIndented = True
        options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping

        Dim jsonString As String = JsonSerializer.Serialize(MusicList, options)

        Dim Writer As New IO.StreamWriter(My.Application.Info.DirectoryPath & "\Setting\List.json")

        'JSONに書きこむ
        Writer.Write(jsonString)
        Writer.Close()



        'キャラクター情報を保存する
        If VoiceList IsNot Nothing AndAlso VoiceList.Count > 0 Then

            Dim di As IO.DirectoryInfo = IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Setting")

            jsonString = JsonSerializer.Serialize(VoiceList, options)

            Writer = New IO.StreamWriter(My.Application.Info.DirectoryPath & "\Setting\VoiceList.json")

            Writer.Write(jsonString)
            Writer.Close()

        End If

    End Sub


    Private Sub Label2_DragEnter(sender As Object, e As DragEventArgs) Handles Label2.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub


    '音楽ファイルがドロップされた時
    Private Sub Label2_DragDrop(sender As Object, e As DragEventArgs) Handles Label2.DragDrop
        Dim InNewMusic As Boolean

        'コントロール内にドロップされたとき実行される
        'ドロップされたすべてのファイル名を取得する
        Dim FileName As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop, False), String())

        '音楽ファイルを解析
        For i As Integer = 0 To FileName.Length - 1

            Dim Extension = Path.GetExtension(FileName(i)).ToLower

            'MP3かFLACならば、解析作業に入る
            If Extension = ".flac" OrElse Extension = ".mp3" OrElse Extension = ".mp4" OrElse Extension = ".wav" Then
                'すでに同じファイルが登録されていないか確認
                For Each oMu As Music In MusicList
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


                MusicList.Add(oMusic)


                'リストビューに追加
                ListView1.Items.Add(oMusic.Title)
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(oMusic.Artist)
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(oMusic.Type)
                ListView1.Items(ListView1.Items.Count - 1).Tag = oMusic


                SelectMusic = oMusic
                InNewMusic = True

            End If

L1:     Next


        If InNewMusic Then


            MusicChange(SelectMusic)
        End If

    End Sub

    'タイミング調整の値を変更する
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        SelectMusic.StartTime = CInt(NUD_StartTime.Value)
        SelectMusic.EndingTime = CInt(NUD_EndingTime.Value)
        SelectMusic.IntroTime = CInt(NUD_IntroTime.Value)
        SelectMusic.OutroTime = CInt(NUD_OutroTime.Value)
        SelectMusic.IntroMaxLength = CInt(NUD_IntroMaxLength.Value)

        If CheckBox1.Checked OrElse SelectMusic.EndingTime = 0 Then
            MusicLength = MusicReader.TotalTime.TotalSeconds
        Else
            MusicLength = CInt(NUD_EndingTime.Value)
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        MusicReader.CurrentTime += TimeSpan.FromSeconds(10)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MusicReader.CurrentTime -= TimeSpan.FromSeconds(10)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        SelectMusic.EndingTime = MusicReader.CurrentTime.TotalSeconds + 10

        NUD_EndingTime.Value = SelectMusic.EndingTime


    End Sub

    '再生位置をラスト15秒前まで飛ばす
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        '曲が再生していない場合、なにもしない
        If Wo Is Nothing OrElse Wo.PlaybackState <> PlaybackState.Playing Then
            Exit Sub
        End If

        'トークを止める
        player.Stop()
        player.Dispose()

        '再生位置をラスト15秒前まで飛ばす
        MusicSkip(MusicLength - 15)
    End Sub


    '再生位置を動かすメソッド
    Public Sub MusicSkip(Time As Integer)
        '再生位置を指定
        MusicReader.CurrentTime = TimeSpan.FromSeconds(Time)
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If Wo Is Nothing OrElse Not Wo.PlaybackState = PlaybackState.Playing Then
            Exit Sub
        End If

        If CheckBox1.Checked OrElse SelectMusic.EndingTime = 0 Then
            MusicLength = MusicReader.TotalTime.TotalSeconds
        Else
            MusicLength = SelectMusic.EndingTime
        End If
    End Sub


    '音量バー
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll

        If Wo IsNot Nothing Then
            Wo.Volume = (e.NewValue / 100)
        End If

    End Sub

    Private Sub Label1_Paint(sender As Object, e As PaintEventArgs) Handles Label1.Paint

        If SelectMusic Is Nothing Then Exit Sub

        e.Graphics.DrawString(SelectMusic.Title, Label1.Font, Brushes.LightPink, 0, 2)

        e.Graphics.DrawString(SelectMusic.Artist, Label1.Font, Brushes.White, 0, 42)




        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Far

        Dim TimeRectangle As New RectangleF(Label1.Width - 150, 2, 148, 42)

        e.Graphics.DrawString(Format(Now, "HH:mm:ss"), Label1.Font, Brushes.White, TimeRectangle, sf)

        Dim TimeCount As Integer = Int(MusicReader.CurrentTime.TotalSeconds)
        TimeRectangle = New RectangleF(Label1.Width - 150, 42, 148, 42)
        e.Graphics.DrawString(TimeCount, Label1.Font, Brushes.White, TimeRectangle, sf)




    End Sub




    Private Sub PlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayToolStripMenuItem.Click

        If player IsNot Nothing Then
            player.Stop()
            player.Dispose()
        End If



        MusicChange(ListView1.SelectedItems(0).Tag)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

        ToolStripMenuItem3.Checked = Not ToolStripMenuItem3.Checked


    End Sub

    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        If e.Column > 0 Then Exit Sub

        ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column)

        ListView1.Sort()


        MusicList.Sort()

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

        If player IsNot Nothing Then
            player.Stop()
            player.Dispose()
        End If

        If Wo IsNot Nothing Then
            Wo.Stop()
            Wo.Dispose()
        End If


        Dim str As String = "「" & ListView1.SelectedItems(0).Text & "」を選択中" & vbCrLf
        str &= "選択中の曲を、データベースから削除しますか？" & vbCrLf & "音楽ファイル自体は残ります"


        If MessageBox.Show(str, Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then

            Dim Num As Integer = MusicList.IndexOf(ListView1.SelectedItems(0).Tag)
            '音楽リストから削除
            MusicList.RemoveAt(Num)
            'リストビューからも削除
            ListView1.SelectedItems(0).Remove()
        End If

    End Sub

    Private Sub VoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VoiceToolStripMenuItem.Click

        Dim F As New Form3

        'サブフォームを起動
        F.ShowDialog(Me, VoiceList)

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
