Imports System.Reflection.Emit
Imports System.Threading
Imports NAudio.Wave

Public Class RadioControl

    Private Rnd As New Random

    '基本設定ファイル
    Public ReadOnly Property Setting As Setting

    '音楽プレイヤー
    Public ReadOnly Property MusicPlayer As MusicPlayer

    'トークプレイヤー
    Public ReadOnly Property TalkPlayer As TalkPlayer

    '前回の交通情報を流した時間を記録
    Public Property TimeWhenTraffic As Date


    Public Property InfoText As String





    'インスタンス時
    Sub New(Setting As Setting, MusicPlayer As MusicPlayer, TalkPlayer As TalkPlayer)
        Me.Setting = Setting
        Me.MusicPlayer = MusicPlayer
        Me.TalkPlayer = TalkPlayer
    End Sub


    Dim OnFadeOut As Boolean


    '定時確認ポイント
    Public Sub Tick()

        '曲が再生されていなければ、何もしない
        If MusicPlayer.Wo Is Nothing OrElse MusicPlayer.Wo.PlaybackState = PlaybackState.Paused Then
            Return
        End If

        '現在の音楽再生位置を取得
        Dim TimeCount As Integer = Int(MusicPlayer.MusicReader.CurrentTime.TotalSeconds)

        '再生位置で分岐
        Select Case TimeCount
            Case Is >= (MusicPlayer.MusicLength)
                '曲が終了する時間ならば

                If OnFadeOut Then


                    OnFadeOut = False

                    _InfoText = ""





                    If MusicPlayer.SelectMusic IsNot Nothing AndAlso MusicPlayer.MusicList.ExistsType(Music.WaveType.Traffic) AndAlso Setting.Traffic Then
                        Select Case MusicPlayer.SelectMusic.TypeEnum
                            Case Music.WaveType.Jingle
                                '前曲がジングルならば

                                '交通情報の開始時間を過ぎていたら
                                If TimeWhenTraffic.AddMinutes(Setting.TrafficInterval) < Now Then






                                    'ボイスリストが無ければ
                                    If TalkPlayer.VoiceList Is Nothing OrElse TalkPlayer.VoiceList.Count = 0 Then
                                        '次の曲へ
                                        MusicChange()
                                        Exit Sub
                                    End If






                                    Dim Count As Integer

                                    'MCの使用許可があるボイスが居ない場合
                                    For Each oVoice As VoiceCharacter In TalkPlayer.VoiceList
                                        Count += CInt(oVoice.TrafficMcUse)
                                    Next

                                    If Count = 0 Then
                                        '次の曲へ
                                        MusicChange()
                                        Exit Sub
                                    End If

                                    Count = 0

                                    '道路交通情報センターの使用許可があるボイスが居ない場合
                                    For Each oVoice As VoiceCharacter In TalkPlayer.VoiceList
                                        Count += CInt(oVoice.TrafficCenterUse)
                                    Next

                                    If Count = 0 Then
                                        '次の曲へ
                                        MusicChange()
                                        Exit Sub
                                    End If

                                    'VOICEVOXが起動していない時
                                    If Diagnostics.Process.GetProcessesByName("VOICEVOX").Length = 0 Then
                                        '次の曲へ
                                        MusicChange()
                                    Else
                                        ''交通情報を流す
                                        'TrafficInfo()
                                    End If
                                Else
                                    '次の曲へ
                                    MusicChange()
                                End If

                            Case Else
                                '次の曲へ
                                MusicChange()
                        End Select

                    Else
                        '次の曲へ
                        MusicChange()

                    End If







                End If



            Case Is >= (MusicPlayer.MusicLength - 3)
                '曲が終了する3秒前ならば


                If OnFadeOut = False Then


                    'ジャンルが交通情報でなければ
                    If MusicPlayer.SelectMusic.TypeEnum <> Music.WaveType.Traffic Then
                        ''タイマーを止める
                        'Timer1.Stop()
                        '再生カウントを追加
                        MusicPlayer.SelectMusic.PlayCount += 1
                        ''トーク中を解除
                        'OnTalk = False
                        'フェードアウト中をオンにする
                        OnFadeOut = True
                        '音量をフェードアウトする
                        MusicPlayer.fadeSong.BeginFadeOut(2000)
                    End If
                End If






            Case MusicPlayer.SelectMusic.IntroTime
                'イントロトークの時間が来たら

                '選曲中のタイプが音楽ならば
                If MusicPlayer.SelectMusic.TypeEnum = Music.WaveType.Music Then
                    TalkChange(Talk.TalkType.Intro)
                End If




            Case MusicPlayer.MusicLength - MusicPlayer.SelectMusic.OutroTime
                'アウトロトークの時間が来たら


                '選曲中のタイプが音楽ならば
                If MusicPlayer.SelectMusic.TypeEnum = Music.WaveType.Music Then
                    TalkChange(Talk.TalkType.Outro)
                End If




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



        Await TalkPlayer.Talk(Scenario, TalkPlayer.VoiceList(SelectedVoice).Id, False)



    End Sub


    '次の曲を選曲
    Public Sub MusicChange()
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
                                    If MusicPlayer.SelectMusic.TypeEnum = Music.WaveType.Music Then
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
                        '交通情報を挟む設定かつ交通情報がある場合
                        If Setting.Traffic AndAlso MusicPlayer.SelectMusic.TypeEnum = Music.WaveType.Traffic Then
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

        MusicPlayer.Change(NextMusic)

    End Sub

























End Class
