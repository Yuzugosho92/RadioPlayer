Imports System.IO
Imports System.Text.Json
Imports Windows.Win32.System

Public Class Load
    Public Sub Load(ByRef Cls As Object, ClsName As String, FileName As String)

        Try
            '設定ファイルを開く
            Dim Reader = New IO.StreamReader(My.Application.Info.DirectoryPath & "\Setting\" & FileName)
            'JSON文字列を一括で読み取る
            Dim str As String = Reader.ReadToEnd
            'ファイルを閉じる
            Reader.Close()

            'JSON文字列をクラスに登録
            Select Case ClsName
                Case "Settingファイル"
                    Cls = JsonSerializer.Deserialize(Of Setting)(str)
                Case "音楽リスト"
                    Cls = JsonSerializer.Deserialize(Of MusicList)(str)
                Case "トークパターンファイル"
                    Cls = JsonSerializer.Deserialize(Of List(Of Talk))(str)
                Case "ボイスリスト"
                    Cls = JsonSerializer.Deserialize(Of List(Of VoiceCharacter))(str)
                Case "交通情報ファイル"
                    Cls = JsonSerializer.Deserialize(Of TrafficInfo)(str)
            End Select

        Catch ex As FileNotFoundException
            'ファイルが無い場合、スルーする
        Catch ex As System.Text.Json.JsonException
            'JSONの記述ミスがある場合
            MessageBox.Show(ClsName & "に記述ミスがありそうです" & vbCrLf & vbCrLf & ex.Message, "Error", 0, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
