Public Class Form3

    Dim VoiceList As List(Of VoiceCharacter)

    Public Overloads Function ShowDialog(Owner As IWin32Window, ByRef VoiceList As List(Of VoiceCharacter))

        Me.VoiceList = VoiceList

        'リストビューにボイスを登録
        For i As Integer = 0 To VoiceList.Count - 1
            ListView1.Items.Add(VoiceList(i).Name)
            ListView1.Items(ListView1.Items.Count - 1).Checked = VoiceList(i).Use
            ListView1.Items(ListView1.Items.Count - 1).Tag = VoiceList(i)
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
            VoiceList(i).Use = ListView1.Items(i).Checked
        Next

        'フォームを閉じる
        Me.Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        'フォームを閉じる
        Me.Close()
    End Sub

End Class