Imports System.Text.Encodings.Web
Imports System.Text.Json

Public Class Save

    Sub New(Owner As Form1)


        '設定ファイルを保存する
        Dim options As New JsonSerializerOptions
        options.WriteIndented = True
        options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping

        Dim jsonString As String = JsonSerializer.Serialize(Owner.Setting, options)

        Dim Writer As New IO.StreamWriter(My.Application.Info.DirectoryPath & "\Setting\Setting.json")

        'JSONに書きこむ
        Writer.Write(jsonString)
        Writer.Close()


        jsonString = JsonSerializer.Serialize(Owner.TrafficInfoList, options)

        Writer = New IO.StreamWriter(My.Application.Info.DirectoryPath & "\Setting\TrafficInfo.json")

        'JSONに書きこむ
        Writer.Write(jsonString)
        Writer.Close()


















    End Sub




















End Class
