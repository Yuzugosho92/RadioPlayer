Public Class Form3

    Dim VoiceList As List(Of VoiceCharacter)
    Dim Type As VoiceCharacter.TalkType

    Public Overloads Function ShowDialog(Owner As IWin32Window, RadioControl As RadioControl, Type As VoiceCharacter.TalkType)

        Me.VoiceList = RadioControl.TalkPlayer.VoiceList
        Me.Type = Type

        'リストビューにボイスを登録
        For i As Integer = 0 To VoiceList.Count - 1

            Dim oListViewItem As ListViewItem = ListView1.Items.Add(VoiceList(i).Name)
            oListViewItem.Tag = VoiceList(i)

            Select Case Type
                Case VoiceCharacter.TalkType.Mc
                    oListViewItem.Checked = VoiceList(i).Use
                Case VoiceCharacter.TalkType.TrafficMc
                    oListViewItem.Checked = VoiceList(i).TrafficMcUse
                Case VoiceCharacter.TalkType.TrafficCenter
                    oListViewItem.Checked = VoiceList(i).TrafficCenterUse
            End Select
        Next

        'リストビューのカラムサイズを調整
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        Return Me.ShowDialog(Owner)

    End Function

    'すべてにチェックを入れる
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i As Integer = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).Checked = True
        Next
    End Sub

    'すべてのチェックを外す
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i As Integer = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).Checked = False
        Next
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click

        For i As Integer = 0 To ListView1.Items.Count - 1

            Select Case Type
                Case VoiceCharacter.TalkType.Mc
                    VoiceList(i).Use = ListView1.Items(i).Checked
                Case VoiceCharacter.TalkType.TrafficMc
                    VoiceList(i).TrafficMcUse = ListView1.Items(i).Checked
                Case VoiceCharacter.TalkType.TrafficCenter
                    VoiceList(i).TrafficCenterUse = ListView1.Items(i).Checked
            End Select

        Next

        'フォームを閉じる
        Me.Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        'フォームを閉じる
        Me.Close()
    End Sub

End Class