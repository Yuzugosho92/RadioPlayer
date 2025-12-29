Imports System.IO
Imports System.Text.Json

Public Class Load

    Public Sub Load(RadioControl As RadioControl)

        '基本設定を読み込む
        LoadSolo(RadioControl.Setting, "Settingファイル", "Setting.json")
        '音楽情報を読み込む
        LoadSolo(RadioControl.MusicPlayer.MusicList, "音楽リスト", "List.json")
        'トークパターンを読み込む
        LoadSolo(RadioControl.TalkPlayer.TalkList, "トークパターンファイル", "TalkList.json")
        'キャラクター情報を読み込む
        LoadSolo(RadioControl.TalkPlayer.VoiceList, "ボイスリスト", "VoiceList.json")
        '交通情報ファイルを読み込む
        LoadSolo(RadioControl.TrafficInfo.TIList, "交通情報ファイル", "TrafficInfo.json")

    End Sub


    Public Sub LoadSolo(ByRef Cls As Object, ClsName As String, FileName As String)

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
                    Cls = JsonSerializer.Deserialize(Of TrafficInfoList)(str)
            End Select

        Catch ex As FileNotFoundException
            'ファイルが無い場合、スルーする
        Catch ex As System.Text.Json.JsonException
            'JSONの記述ミスがある場合
            MessageBox.Show(ClsName & "に記述ミスがありそうです" & vbCrLf & vbCrLf & ex.Message, "Error", 0, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
