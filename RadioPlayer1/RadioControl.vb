Imports NAudio.Wave

Public Class RadioControl

    Private ReadOnly Rnd As New Random

    Public ReadOnly Property Owner As Form1

    '基本設定ファイル
    Public Property Setting As Setting

    '音楽プレイヤー
    Public Property MusicPlayer As MusicPlayer

    'トークプレイヤー
    Public Property TalkPlayer As TalkPlayer

    Public Property InfoText As String

    '交通情報プレイヤー
    Public Property TrafficInfo As TrafficInfo


    Private OnTalk As Boolean

    '曲を変更した時に発生するイベント
    Public Event OnMusicChange(ByVal sender As Object, ByVal e As EventArgs)

    '情報文を変更した時に発生するイベント
    Public Event InfoTextChange(ByVal sender As Object, ByVal e As EventArgs)


    'インスタンス時
    Sub New(Owner As Form1)
        Me.Owner = Owner

        Setting = New Setting
        MusicPlayer = New MusicPlayer(Me)
        TalkPlayer = New TalkPlayer(Setting)

        TrafficInfo = New TrafficInfo(Setting, Me)
    End Sub


    Dim OnFadeOut As Boolean


    '定時確認ポイント
    Public Sub Tick()

        '曲が再生されていなければ、何もしない
        If MusicPlayer.Wo Is Nothing Then
            Return
        End If

        '現在の音楽再生位置を取得
        Dim TimeCount As Integer = Int(MusicPlayer.MusicReader.CurrentTime.TotalSeconds)

        '再生位置で分岐
        Select Case TimeCount
            Case Is >= MusicPlayer.MusicLength
                '曲が終了する時間ならば

                OnFadeOut = False

                OnTalk = False

                _InfoText = ""

                '次の曲へ
                MusicChange()

            Case Is >= (MusicPlayer.MusicLength - 3)
                '曲が終了する3秒前ならば


                If OnFadeOut = False Then


                    'ジャンルが交通情報でなければ
                    If MusicPlayer.SelectMusic.TypeEnum <> Music.WaveType.Traffic Then
                        '再生カウントを追加
                        MusicPlayer.SelectMusic.PlayCount += 1
                        'フェードアウト中をオンにする
                        OnFadeOut = True
                        '音量をフェードアウトする
                        MusicPlayer.fadeSong.BeginFadeOut(2000)
                    End If
                End If






            Case MusicPlayer.SelectMusic.IntroTime
                'イントロトークの時間が来たら

                If OnTalk = False Then

                    '選曲中のタイプが音楽ならば
                    If MusicPlayer.SelectMusic.TypeEnum = Music.WaveType.Music Then


                        OnTalk = True

                        TalkChange(Talk.TalkType.Intro)





                    End If

                End If








            Case MusicPlayer.MusicLength - MusicPlayer.SelectMusic.OutroTime
                'アウトロトークの時間が来たら


                If OnTalk = False Then

                    '選曲中のタイプが音楽ならば
                    If MusicPlayer.SelectMusic.TypeEnum = Music.WaveType.Music Then
                        OnTalk = True

                        TalkChange(Talk.TalkType.Outro)



                    ElseIf MusicPlayer.SelectMusic.TypeEnum = Music.WaveType.Jingle Then
                        OnTalk = True
                        TalkChange(Talk.TalkType.Call)


                    End If


                End If


            Case Else

                OnTalk = TalkPlayer.PlaybackState





        End Select










    End Sub



    Public Async Sub TalkChange(TalkType As Talk.TalkType)

        'トークリストが無ければ、なにもしない
        If TalkPlayer.TalkList Is Nothing OrElse TalkPlayer.TalkList.Count = 0 Then
            _InfoText = "トークパターンが読み込まれていません"
            Exit Sub
        End If

        'ボイスリストが無ければ、なにもしない
        If TalkPlayer.VoiceList Is Nothing OrElse TalkPlayer.VoiceList.Count = 0 Then
            _InfoText = "ボイスリストが読み込まれていません"
            Exit Sub
        End If

        '使用許可があるボイスが居ない場合、なにもしない
        Dim Count As Integer
        For Each oVoice As VoiceCharacter In TalkPlayer.VoiceList
            Count += CInt(oVoice.Use)
        Next
        If Count = 0 Then
            _InfoText = "ボイスが選択されていません"
            Exit Sub
        End If

        'トーク音声を一旦削除
        TalkPlayer.WoClose()

        Dim oTalk As Talk
        Dim Tx As String 'テロップ表示用
        Dim Scenario As String 'スピーク用

        'DJを選択
Scenario1: Dim SelectedVoice As Integer

        '使用許可があるボイスが出るまで抽選
        Do
            SelectedVoice = Rnd.Next(0, TalkPlayer.VoiceList.Count)

            If TalkPlayer.VoiceList(SelectedVoice).Use Then
                Exit Do
            End If
        Loop

        Do
            '台本を抽選
            oTalk = TalkPlayer.TalkList(Rnd.Next(0, TalkPlayer.TalkList.Count))





            'イントロ・アウトロ用ならば
            If oTalk.TypeEnum = TalkType Then

                '時間が対応していたら、Doを出る
                If oTalk.FeelingTime(Now.Hour) Then
                    Exit Do
                End If
            End If





        Loop

        '台本を入力
        Tx = oTalk.Text
        Scenario = oTalk.Text


        If TalkType = Talk.TalkType.Call Then
            Tx = Tx.Replace("[RadioName]", Setting.RadioName)
            Scenario = Scenario.Replace("[RadioName]", Setting.RadioName)

            _InfoText = Tx & vbCrLf & "by. " & TalkPlayer.VoiceList(SelectedVoice).Name
        Else
            'タイトルとアーティストを置き換え
            If MusicPlayer.SelectMusic.ArtistSort Is Nothing OrElse MusicPlayer.SelectMusic.ArtistSort = "" Then
                Scenario = Scenario.Replace("[Artist]", MusicPlayer.SelectMusic.Artist)
            Else
                Scenario = Scenario.Replace("[Artist]", MusicPlayer.SelectMusic.ArtistSort)
            End If

            If MusicPlayer.SelectMusic.TitleSort Is Nothing OrElse MusicPlayer.SelectMusic.TitleSort = "" Then
                Scenario = Scenario.Replace("[Title]", MusicPlayer.SelectMusic.Title)
            Else
                Scenario = Scenario.Replace("[Title]", MusicPlayer.SelectMusic.TitleSort)
            End If

            '自己紹介文を登録
            If Setting.MySelf Then
                Scenario = TalkPlayer.VoiceList(SelectedVoice).MySelf & "。" & Scenario
            End If

            'もしトーク文が長過ぎたら、再抽選
            If MusicPlayer.SelectMusic.IntroMaxLength > 0 AndAlso Scenario.Length > MusicPlayer.SelectMusic.IntroMaxLength Then
                GoTo Scenario1
            End If

            Tx = Tx.Replace("[Artist]", MusicPlayer.SelectMusic.Artist)
            Tx = Tx.Replace("[Title]", MusicPlayer.SelectMusic.Title)

            _InfoText = Tx & vbCrLf
            _InfoText &= "by. " & TalkPlayer.VoiceList(SelectedVoice).Name & vbCrLf & "(" & Tx.Length & "文字" & ") (" & MusicPlayer.SelectMusic.PlayCount + 1 & "回目)"
        End If


        Try
            Await TalkPlayer.Talk(Scenario, TalkPlayer.VoiceList(SelectedVoice).Id, False)
        Catch ex As Net.Http.HttpRequestException
            'VOICEVOX本体が起動していない時
            _InfoText = "VOICEVOXが起動していません"
        End Try





    End Sub


    '次の曲を選曲
    Public Overloads Sub MusicChange()
        Dim NextMusic As Music

        Do
            '次の曲を選ぶ乱数を設定
            NextMusic = MusicPlayer.MusicList(Rnd.Next(0, MusicPlayer.MusicList.Count))

            '前曲が無い場合
            If MusicPlayer.SelectMusic Is Nothing Then
                Exit Do
            End If

            '曲がリストの中に1曲しかない場合
            If MusicPlayer.MusicList.Count = 1 Then
                Exit Do
            End If

            '前曲と同じ曲では無い場合
            If NextMusic IsNot MusicPlayer.SelectMusic Then
                '前曲のタイプで分岐
                Select Case MusicPlayer.SelectMusic.TypeEnum
                    Case Music.WaveType.Music
                        '音楽の場合
                        '選択した曲のタイプで分岐
                        Select Case NextMusic.TypeEnum
                            Case Music.WaveType.Music
                                '音楽の場合
                                '音楽タイプの再生回数が設定を越えてなければ
                                If MusicPlayer.GenreCount < Setting.JingleFrequency Then
                                    Exit Do
                                Else
                                    'リストにジングルが無い場合
                                    If MusicPlayer.MusicList.ExistsType(Music.WaveType.Jingle) = False Then
                                        MusicPlayer.GenreCountReset()
                                        Exit Do
                                    End If
                                End If

                            Case Music.WaveType.Jingle
                                'ジングルの場合
                                '音楽タイプの再生回数が設定を越えていれば
                                If MusicPlayer.GenreCount >= Setting.JingleFrequency Then
                                    MusicPlayer.GenreCountReset()
                                    Exit Do
                                End If

                            Case Else
                                '交通情報の場合、再抽選
                        End Select

                    Case Music.WaveType.Jingle
                        'ジングルの場合
                        '交通情報を挟む設定かつ交通情報がある場合かつ交通情報の時間が過ぎていた場合
                        If Setting.Traffic AndAlso MusicPlayer.MusicList.ExistsType(Music.WaveType.Traffic) AndAlso TrafficInfo.TimeWhenTraffic.AddMinutes(Setting.TrafficInterval) < Now Then
                            '選択した曲が交通情報の場合
                            If NextMusic.TypeEnum = Music.WaveType.Traffic Then
                                MusicPlayer.GenreCountReset()
                                Exit Do
                            End If
                        Else
                            '選択した曲が音楽の場合
                            If NextMusic.TypeEnum = Music.WaveType.Music Then
                                MusicPlayer.GenreCountReset()
                                Exit Do
                            End If
                        End If

                    Case Music.WaveType.Traffic
                        '交通情報の場合
                        '選択した曲が音楽の場合
                        If NextMusic.TypeEnum = Music.WaveType.Music Then
                            MusicPlayer.GenreCountReset()
                            Exit Do
                        End If
                End Select
            End If
        Loop

        MusicChange(NextMusic)

        '選ばれた曲が交通情報ならば
        If NextMusic.TypeEnum = Music.WaveType.Traffic Then
            '交通情報を流す
            TrafficInfo.Play()
        End If

    End Sub

    Public Overloads Sub MusicChange(music As Music)

        'トークプレイヤーを終了
        TalkPlayer.WoClose()
        'トーク情報ラベルをクリア
        InfoText = ""

        MusicPlayer.Change(music)

        'イベントを発生させる
        RaiseEvent OnMusicChange(Me, New EventArgs)
    End Sub


    '曲の再生位置を変更
    Public Sub Skip(Time As Integer)
        '曲を再生している場合
        If MusicPlayer.PlaybackState = PlaybackState.Playing Then
            'トークプレイヤーを終了
            TalkPlayer.WoClose()
            'トーク情報ラベルをクリア
            InfoText = ""

            '再生位置を指定
            MusicPlayer.Skip(Time)
        End If
    End Sub


    Friend Sub InfoTextChanged()
        'イベントを発生させる
        RaiseEvent InfoTextChange(Me, New EventArgs)
    End Sub


End Class
