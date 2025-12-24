Imports System.IO
Imports System.Text.Json

Public Class Load

    Sub New(Owner As Form1)

        Dim Reader As IO.StreamReader
        Dim str As String

        Try
            '設定ファイルを開く
            Reader = New IO.StreamReader(My.Application.Info.DirectoryPath & "\Setting\Setting.json")
            'JSON文字列を一括で読み取る
            str = Reader.ReadToEnd
            'ファイルを閉じる
            Reader.Close()

            'JSON文字列を音楽情報クラスに登録
            Owner.setting = JsonSerializer.Deserialize(Of Setting)(str)

        Catch ex As FileNotFoundException
            '設定ファイルが無い場合、スルーする
        Catch ex As System.Text.Json.JsonException
            'JSONの記述ミスがある場合
            MessageBox.Show("Settingファイルに記述ミスがありそうです" & vbCrLf & vbCrLf & ex.Message, Owner.Text, 0, MessageBoxIcon.Error)
        End Try


        Try
            '音楽情報ファイルを開く
            Reader = New IO.StreamReader(My.Application.Info.DirectoryPath & "\Setting\List.json")
            'JSON文字列を一括で読み取る
            str = Reader.ReadToEnd
            'ファイルを閉じる
            Reader.Close()

            'JSON文字列を音楽情報クラスに登録
            Owner.MusicList = JsonSerializer.Deserialize(Of MusicList)(str)

        Catch ex As FileNotFoundException
            '音楽情報ファイルが無い場合、スルーする
        Catch ex As System.Text.Json.JsonException
            'JSONの記述ミスがある場合
            MessageBox.Show("音楽リストに記述ミスがありそうです" & vbCrLf & vbCrLf & ex.Message, Owner.Text, 0, MessageBoxIcon.Error)
        End Try


        Try
            'トークパターンファイルを開く
            Reader = New IO.StreamReader(My.Application.Info.DirectoryPath & "\Setting\TalkList.json")
            'JSON文字列を一括で読み取る
            str = Reader.ReadToEnd
            'ファイルを閉じる
            Reader.Close()

            Owner.TalkList = JsonSerializer.Deserialize(Of List(Of Talk))(str)

        Catch ex As FileNotFoundException
            'トークパターンファイルが無い場合、スルーする
        Catch ex As System.Text.Json.JsonException
            'JSONの記述ミスがある場合
            MessageBox.Show("トークパターンリストに記述ミスがありそうです" & vbCrLf & vbCrLf & ex.Message, Owner.Text, 0, MessageBoxIcon.Error)
        End Try


        Try
            'ボイスパターンファイルを開く
            Reader = New IO.StreamReader(My.Application.Info.DirectoryPath & "\Setting\VoiceList.json")
            'JSON文字列を一括で読み取る
            str = Reader.ReadToEnd
            'ファイルを閉じる
            Reader.Close()

            Owner.VoiceList = JsonSerializer.Deserialize(Of List(Of VoiceCharacter))(str)

        Catch ex As FileNotFoundException
            'ボイスパターンファイルが無い場合、スルーする
        Catch ex As System.Text.Json.JsonException
            'JSONの記述ミスがある場合
            MessageBox.Show("ボイスリストに記述ミスがありそうです" & vbCrLf & vbCrLf & ex.Message, Owner.Text, 0, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
