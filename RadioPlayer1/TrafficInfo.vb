Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class TrafficInfo

    Dim Rnd As New Random

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





    Public Property Highway As New List(Of String)

    Public Property CityHighway As New List(Of String)

    Public Property GeneralRoad As New List(Of String)

    Public Property EndingTalk As New List(Of String)


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

            Dim Num As Integer = Rnd.Next(Highway.Count)

            If Selecting.Contains(Num) = False Then

                Tx.Append(PatternReplace(Highway(Num)))
                ScenarioList.Add(New Scenario(Tx.ToString, Voice))
                Selecting.Add(Num)

                i += 1
            End If
        Loop Until i = 3


        ScenarioList.Add(New Scenario("次に首都高速道路の状況です。", Voice))

        Selecting.Clear()
        i = 0

        Do
            Tx.Clear()

            Dim Num As Integer = Rnd.Next(CityHighway.Count)

            If Selecting.Contains(Num) = False Then

                Tx.Append(PatternReplace(CityHighway(Num)))
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

            Dim Num As Integer = Rnd.Next(GeneralRoad.Count)

            If Selecting.Contains(Num) = False Then

                Tx.Append(PatternReplace(GeneralRoad(Num)))
                ScenarioList.Add(New Scenario(Tx.ToString, Voice))
                Selecting.Add(Num)

                i += 1
            End If
        Loop Until i = 3


        '最後に啓発の一言
        Dim Num2 As Integer = Rnd.Next(EndingTalk.Count + 1)

        If Num2 < EndingTalk.Count Then
            ScenarioList.Add(New Scenario(EndingTalk(Num2), Voice))
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
