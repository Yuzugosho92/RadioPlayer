Imports System.Text.Encodings.Web
Imports System.Text.Json

'各設定をJSONに保存するクラス
Public Class Save

    Public Sub Save(RadioControl As RadioControl)

        '基本設定を保存する
        SaveSolo(RadioControl.Setting, "Setting.json")
        '音楽情報を保存する
        SaveSolo(RadioControl.MusicPlayer.MusicList, "List.json")
        'キャラクター情報を保存する
        SaveSolo(RadioControl.TalkPlayer.VoiceList, "VoiceList.json")

    End Sub


    Public Sub SaveSolo(Cls As Object, FileName As String)
        'もしクラスがNothingなら、なにもしない
        If Cls Is Nothing Then
            Return
        End If

        'インスタンス
        Dim options As New JsonSerializerOptions
        options.WriteIndented = True
        options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping

        'Settingフォルダが無ければ作成
        Dim di As IO.DirectoryInfo = IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Setting")

        'JSONファイルに保存する準備
        Dim jsonString As String = JsonSerializer.Serialize(Cls, options)
        Dim Writer As New IO.StreamWriter(My.Application.Info.DirectoryPath & "\Setting\" & FileName)

        'JSONに書きこむ
        Writer.Write(jsonString)
        Writer.Close()
    End Sub
End Class
