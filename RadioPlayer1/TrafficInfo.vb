Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports NAudio.Wave.Asio

Public Class TrafficInfo

    Dim Rnd As New Random

    '基本設定ファイル
    Public ReadOnly Property Setting As Setting

    Public ReadOnly Property RadioControl As RadioControl

    '使用するトークプレイヤー
    Public ReadOnly Property TalkPlayer As TalkPlayer

    '各種リスト集クラス
    Public Property TIList As New TrafficInfoList

    '前回の交通情報を流した時間を記録
    Public Property TimeWhenTraffic As Date


    Sub New(Setting As Setting, RadioControl As RadioControl)
        Me.Setting = Setting
        Me.RadioControl = RadioControl
        Me.TalkPlayer = RadioControl.TalkPlayer
    End Sub


    Dim Bt As Dictionary(Of Integer, Byte())

    Public Async Sub Play()

        RadioControl.Owner.Button1.Enabled = False
        RadioControl.Owner.Button2.Enabled = False
        RadioControl.Owner.Button3.Enabled = False
        RadioControl.Owner.Button4.Enabled = False
        RadioControl.Owner.CheckBox1.Enabled = False
        RadioControl.Owner.GroupBox1.Enabled = False

        'MCを選択
        Dim SelectedVoiceMC As VoiceCharacter

        '使用許可があるボイスが出るまで抽選
        Do
            Dim Id As Integer = Rnd.Next(0, TalkPlayer.VoiceList.Count)

            If TalkPlayer.VoiceList(Id).TrafficMcUse Then
                SelectedVoiceMC = TalkPlayer.VoiceList(Id)
                Exit Do
            End If
        Loop

        '情報センター担当者を選択
        Dim SelectedVoiceCenter As VoiceCharacter

        '使用許可があるボイスが出るまで抽選
        Do
            Dim Id As Integer = Rnd.Next(0, TalkPlayer.VoiceList.Count)

            If TalkPlayer.VoiceList(Id).TrafficCenterUse Then
                SelectedVoiceCenter = TalkPlayer.VoiceList(Id)
                Exit Do
            End If
        Loop




        Dim Scenario As New List(Of TrafficInfo.Scenario)

        Scenario.AddRange(McScenario(Setting, SelectedVoiceMC, SelectedVoiceCenter))

        Scenario.InsertRange(1, CenterScenario(Setting, SelectedVoiceCenter))

        Bt = New Dictionary(Of Integer, Byte())

        '冒頭の音声を作成
        Bt.Add(0, Await TalkPlayer.TextByteCreate(Scenario(0).Text, Scenario(0).Voice.Id))

        '続く音声を順次作成
        Parallel.For(1, Scenario.Count, Async Sub(i)

                                            Bt.Add(i, Await TalkPlayer.TextByteCreate(Scenario(i).Text, Scenario(i).Voice.Id)）
                                        End Sub)


        'テキストを表示
        RadioControl.InfoText = "By." & Scenario(0).Voice.Name & vbCrLf & Scenario(0).Text

        'ラジオコントロールクラスに、情報文を変更したことを伝える
        RadioControl.InfoTextChanged()

        Await TalkPlayer.ByteArrayPlay(Bt(0), True)

        For i As Integer = 1 To Scenario.Count - 1
            'テキストを表示
            RadioControl.InfoText = "By." & Scenario(i).Voice.Name & vbCrLf & Scenario(i).Text

            'ラジオコントロールクラスに、情報文を変更したことを伝える
            RadioControl.InfoTextChanged()

            '音声を再生
            If Bt IsNot Nothing AndAlso Bt.ContainsKey(i) Then
                Await TalkPlayer.ByteArrayPlay(Bt(i), True)
            End If
        Next

        '今の時刻を記録する
        TimeWhenTraffic = Now



        RadioControl.MusicPlayer.GenreCountReset()

        Bt.Clear()
        Bt = Nothing



        '音量をフェードアウトする
        RadioControl.MusicPlayer.fadeSong.BeginFadeOut(3000)

        Await Task.Delay(3000)


        '次の曲へ
        RadioControl.MusicChange()

        RadioControl.Owner.Button1.Enabled = True
        RadioControl.Owner.Button2.Enabled = True
        RadioControl.Owner.Button3.Enabled = True
        RadioControl.Owner.Button4.Enabled = True
        RadioControl.Owner.CheckBox1.Enabled = True
        RadioControl.Owner.GroupBox1.Enabled = True

    End Sub








    '複数選択の文字列を置き換える
    Private Function PatternReplace(str As String) As String

        Dim p As String = "\{(?<Text>[,、\w]*?)\}"
        Dim r As New Text.RegularExpressions.Regex(p, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        Dim m As Text.RegularExpressions.Match

        Do
            m = r.Match(str)

            If m.Groups("Text").Value = "" Then
                Return str
            Else

                Dim Pattern As String() = m.Groups("Text").Value.Split(",")
                str = r.Replace(str, Pattern(Rnd.Next(Pattern.Length)), 1)

            End If
        Loop

    End Function


    Private Selecting As New List(Of Integer)

    Public Function McScenario(Setting As Setting, Mc As VoiceCharacter, Center As VoiceCharacter) As Scenario()

        Dim Scenario(1) As Scenario

        Dim Tx As New Text.StringBuilder()

        If Setting.MySelf Then
            Tx.Append(Mc.MySelf & "。")
        End If

        Tx.Append("時刻は" & Now.ToString("h時m分") & "になりました。")
        Tx.Append("ここで" & Setting.RadioName & "交通情報です。")
        Tx.Append("道路交通情報センターの" & Center.YourName & "さんどうぞ。")

        Scenario(0) = New Scenario(Tx.ToString, Mc)

        Tx.Clear()

        Tx.Append("ありがとうございました。")
        Tx.Append("次の交通情報は、" & Now.AddMinutes(Setting.TrafficInterval).ToString("h時m分") & "頃お伝えいたします。")

        Scenario(1) = New Scenario(Tx.ToString, Mc)

        Return Scenario

    End Function


    Public Function CenterScenario(Setting As Setting, Voice As VoiceCharacter) As Scenario()

        Dim ScenarioList As New List(Of Scenario)

        Dim Tx As New Text.StringBuilder()
        Dim Rnd As New Random

        Tx.Append("はい。")
        Tx.Append("まず高速道路の状況です。")

        ScenarioList.Add(New Scenario(Tx.ToString, Voice))

        Selecting.Clear()

        Dim i As Integer
        Do
            Tx.Clear()

            Dim Num As Integer = Rnd.Next(TIList.Highway.Count)

            If Selecting.Contains(Num) = False Then

                Tx.Append(PatternReplace(TIList.Highway(Num)))
                ScenarioList.Add(New Scenario(Tx.ToString, Voice))
                Selecting.Add(Num)

                i += 1
            End If
        Loop Until i = 3


        ScenarioList.Add(New Scenario("次に" & TIList.CityHighwayName & "の状況です。", Voice))

        Selecting.Clear()
        i = 0

        Do
            Tx.Clear()

            Dim Num As Integer = Rnd.Next(TIList.CityHighway.Count)

            If Selecting.Contains(Num) = False Then

                Tx.Append(PatternReplace(TIList.CityHighway(Num)))
                ScenarioList.Add(New Scenario(Tx.ToString, Voice))
                Selecting.Add(Num)

                i += 1
            End If
        Loop Until i = 3



        ScenarioList.Add(New Scenario("一般道の状況です。", Voice))

        Selecting.Clear()
        i = 0

        Do
            Tx.Clear()

            Dim Num As Integer = Rnd.Next(TIList.GeneralRoad.Count)

            If Selecting.Contains(Num) = False Then

                Tx.Append(PatternReplace(TIList.GeneralRoad(Num)))
                ScenarioList.Add(New Scenario(Tx.ToString, Voice))
                Selecting.Add(Num)

                i += 1
            End If
        Loop Until i = 3


        '最後に啓発の一言
        Dim Num2 As Integer = Rnd.Next(TIList.EndingTalk.Count + 1)

        If Num2 < TIList.EndingTalk.Count Then
            ScenarioList.Add(New Scenario(TIList.EndingTalk(Num2), Voice))
        End If

        Tx.Clear()


        Tx.Append("道路交通情報センターの " & Voice.TrafficMySelf & "でした。")

        ScenarioList.Add(New Scenario(Tx.ToString, Voice))



        Return ScenarioList.ToArray




    End Function



















    Public Class Scenario

        Sub New(Text As String, Voice As VoiceCharacter)
            Me.Text = Text
            Me.Voice = Voice
        End Sub


        Public Property Text As String

        Public Property Voice As VoiceCharacter

    End Class









End Class






Public Class TrafficInfoList

    '都市高速の名前（首都高・阪神高速など）
    Public Property CityHighwayName As String = "首都高速道路"

    '高速道路の台本リスト
    Public Property Highway As New List(Of String)
    '都市高速の台本リスト
    Public Property CityHighway As New List(Of String)
    '一般道の台本リスト
    Public Property GeneralRoad As New List(Of String)
    '最後の一言リスト
    Public Property EndingTalk As New List(Of String)

End Class