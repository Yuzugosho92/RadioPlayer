Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form4

    Dim Setting As Setting

    Public Overloads Function ShowDialog(Owner As IWin32Window, ByRef Setting As Setting)

        Me.Setting = Setting



        NumericUpDown1.Value = Setting.TrafficInterval






        Return Me.ShowDialog(Owner)

    End Function

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click

        Setting.TrafficInterval = NumericUpDown1.Value

        'フォームを閉じる
        Me.Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        'フォームを閉じる
        Me.Close()
    End Sub



End Class