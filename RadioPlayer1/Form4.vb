Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form4

    Dim Setting As Setting

    Public Overloads Function ShowDialog(Owner As IWin32Window, ByRef Setting As Setting)

        Me.Setting = Setting

        '全般
        'ラジオ局名
        txb_RadioName.Text = Setting.RadioName

        '音楽
        'MCが名を名乗るかどうか
        ckb_MySelf.Checked = Setting.MySelf

        'ジングルを挟む頻度（n曲に1回）
        NumericUpDown2.Value = Setting.JingleFrequency

        'ゲインの再読み込みの有無
        ckb_Gein.Checked = Setting.Gein

        '交通情報
        '挟むかどうか
        ckb_Traffic.Checked = Setting.Traffic

        '放送間隔
        NumericUpDown1.Value = Setting.TrafficInterval






        Return Me.ShowDialog(Owner)

    End Function

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click

        '全般
        'ラジオ局名
        Setting.RadioName = txb_RadioName.Text

        '音楽
        'MCが名を名乗るかどうか
        Setting.MySelf = ckb_MySelf.Checked

        'ジングルを挟む頻度（n曲に1回）
        Setting.JingleFrequency = NumericUpDown2.Value

        'ゲインの再読み込みの有無
        Setting.Gein = ckb_Gein.Checked

        '交通情報
        '挟むかどうか
        Setting.Traffic = ckb_Traffic.Checked

        '放送間隔
        Setting.TrafficInterval = NumericUpDown1.Value

        'フォームを閉じる
        Me.Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        'フォームを閉じる
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'サブフォームを起動
        Dim F As New Form3
        F.ShowDialog(Owner, DirectCast(Owner, Form1).VoiceList, VoiceCharacter.TalkType.Mc)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'サブフォームを起動
        Dim F As New Form3
        F.ShowDialog(Owner, DirectCast(Owner, Form1).VoiceList, VoiceCharacter.TalkType.TrafficMc)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'サブフォームを起動
        Dim F As New Form3
        F.ShowDialog(Owner, DirectCast(Owner, Form1).VoiceList, VoiceCharacter.TalkType.TrafficCenter)
    End Sub
End Class