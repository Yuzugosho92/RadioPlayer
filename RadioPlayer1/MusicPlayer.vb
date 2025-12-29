Imports System.IO
Imports NAudio.Wave
Imports NAudio.Wave.SampleProviders
Imports Shell32

Public Class MusicPlayer

    '基本設定ファイル
    Public ReadOnly Property Setting As Setting

    '音楽プレイヤー
    Public ReadOnly Property Wo As WaveOut
    Public ReadOnly Property MusicReader As AudioFileReader
    Public ReadOnly Property OffsetSample As OffsetSampleProvider
    Public ReadOnly Property volumeProvider As VolumeSampleProvider
    Public ReadOnly Property fadeSong As FadeInOutSampleProvider

    '音楽リスト
    Public Property MusicList As New MusicList

    '現在選択中の音楽
    Public ReadOnly Property SelectMusic As Music

    '現在選択中の曲を再生する長さ
    Public Property MusicLength As Integer

    '現在のジャンルを再生した回数
    Public ReadOnly Property GenreCount As Integer


    'インスタンス時
    Sub New(Setting As Setting)
        Me.Setting = Setting
    End Sub


    '次の音楽を設定する
    Public Overloads Sub Change(music As Music)
        '前の曲が登録されていれば
        If Wo IsNot Nothing Then
            '演奏を終了し破棄する
            Wo.Stop()
            Wo.Dispose()
        End If

        '選択した曲を登録する
        _SelectMusic = music

        'プレイヤーを召喚
        _Wo = New WaveOut

        Try
            'パスから曲を読み込み
            _MusicReader = New AudioFileReader(SelectMusic.FileNameFull)

        Catch ex As IO.FileNotFoundException
            'パスの音楽ファイルが無い場合
            '音楽を再生中ならば停止
            If Wo IsNot Nothing Then
                Wo.Stop()
                Wo.Dispose()
            End If

            '曲の選択を解除
            _SelectMusic = Nothing

            'ジャンル再生カウントをリセット
            _GenreCount = 0

            'メッセージを表示
            MessageBox.Show("音楽ファイルが見つかりませんでした", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End Try







        Play()

    End Sub


    '音楽を再生する
    Private Sub Play()

        If Setting.Gein OrElse SelectMusic.Gein = 0 Then
            'ゲイン値を計算
            Dim Gain = New WeighingGain
            MusicReader.Volume = Gain.WeingingGein(SelectMusic.FileNameFull)

            SelectMusic.Gein = MusicReader.Volume
        Else
            MusicReader.Volume = SelectMusic.Gein
        End If

        '曲の開始時間を設定
        _OffsetSample = New OffsetSampleProvider(MusicReader)
        OffsetSample.SkipOver = TimeSpan.FromSeconds(SelectMusic.StartTime)

        '曲の終了位置を設定
        If SelectMusic.EndingTime = 0 OrElse Setting.FullChorus OrElse SelectMusic.TypeEnum = Music.WaveType.Traffic Then
            MusicLength = Int(MusicReader.TotalTime.TotalSeconds)
        Else
            OffsetSample.Take = TimeSpan.FromSeconds(SelectMusic.EndingTime)
            MusicLength = SelectMusic.EndingTime
        End If

        _volumeProvider = New VolumeSampleProvider(OffsetSample)

        _fadeSong = New FadeInOutSampleProvider(volumeProvider, False)

        Wo.Init(MusicReader)
        Wo.Init(fadeSong)

        'プレーヤーを再生
        Wo.Play()

        'ジャンルの再生カウントを追加
        _GenreCount += 1

    End Sub


    '音楽を一時停止or再開する
    Public Function PalyOrStop() As String

        If Wo.PlaybackState = PlaybackState.Playing Then
            '再生中の場合
            '一時停止
            Wo.Stop()

            'If Wo2 IsNot Nothing Then
            '    Wo2.Stop()
            'End If

            Return "再開"

        Else
            '一時停止中の場合

            'If CheckBox1.Checked OrElse SelectMusic.EndingTime = 0 Then
            '    MusicLength = MusicReader.TotalTime.TotalSeconds
            'Else
            '    MusicLength = SelectMusic.EndingTime
            'End If

            '再生を再開
            Wo.Play()

            'If Wo2 IsNot Nothing Then
            '    Wo2.Play()
            'End If

            Return "一時停止"
        End If
    End Function


    '曲の再生位置を変更
    Public Sub Skip(Time As Integer)
        '再生位置を指定
        MusicReader.CurrentTime = TimeSpan.FromSeconds(Time)
    End Sub


    '曲の終了位置を変更
    Public Sub EndingTimeChange()
        '設定を反転する
        Setting.FullChorus = Not Setting.FullChorus

        '曲を選択している場合
        If Wo IsNot Nothing Then

            If Setting.FullChorus OrElse SelectMusic.EndingTime = 0 Then
                MusicLength = Int(MusicReader.TotalTime.TotalSeconds)
            Else
                MusicLength = SelectMusic.EndingTime
            End If

        End If
    End Sub


    '曲の選択を削除
    Public Sub MusicClose()
        If Wo IsNot Nothing Then
            Wo.Stop()
            Wo.Dispose()

            _SelectMusic = Nothing
        End If
    End Sub


    '音量を変更
    Public Sub Volume(value As Integer)
        If Wo IsNot Nothing Then
            Wo.Volume = (value / 100)
        End If
    End Sub


    'ジャンルカウンターをリセットする
    Public Sub GenreCountReset()
        _GenreCount = 0
    End Sub


    'プレイヤーが再生中かどうか
    Public ReadOnly Property PlaybackState As PlaybackState
        Get
            If Wo Is Nothing Then
                Return PlaybackState.Stopped
            Else
                Return Wo.PlaybackState
            End If
        End Get
    End Property


    '再生を止める
    Public Sub [Stop]()
        If PlaybackState = PlaybackState.Playing Then
            Wo.Stop()
        End If
    End Sub


    Public Function Add(FileName As String) As Music

        Dim Extension = Path.GetExtension(FileName).ToLower

        '音楽ファイルならば、解析作業に入る
        Select Case Extension
            Case ".flac", ".mp3", ".mp4", ".wav", ".m4a"

                'すでに同じファイルが登録されていないか確認
                For Each oMu As Music In MusicList
                    '登録されていたら、このファイルを解析しない
                    If oMu.FileName = FileName Then
                        Return Nothing
                    End If
                Next

                '新しい音楽データ箱を作成
                Dim oMusic As New Music

                '各種データを登録
                oMusic.Type = "Music"
                oMusic.FileName = FileName
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

                Return oMusic

            Case Else
                Return Nothing
        End Select

    End Function



End Class
