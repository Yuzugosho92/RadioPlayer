Imports System.IO
Imports System.Reflection.Emit
Imports NAudio.Wave
Imports VoicevoxClientSharp

Public Class TalkPlayer

    Private Rnd As New Random

    '基本設定ファイル
    Public ReadOnly Property Setting As Setting

    '音楽プレイヤー
    Public ReadOnly Property Wo As WaveOut

    '台本リスト
    Public Property TalkList As New List(Of Talk)

    'ボイスキャラクターリスト
    Public Property VoiceList As New List(Of VoiceCharacter)


    'インスタンス時
    Sub New(Setting As Setting)
        Me.Setting = Setting
    End Sub



    '文字列をVOICEVOXに喋らせる
    'https://github.com/TORISOUP/VoicevoxClientSharp
    Public Async Function Talk(Str As String, Voice As Integer, OnFull As Boolean) As Task

        Dim bt As Byte() = Await TextByteCreate(Str, Voice)

        Await ByteArrayPlay（bt, OnFull)
    End Function


    'VOICEVOXで文字列からwavバイト配列を生成
    Public Async Function TextByteCreate(Str As String, Voice As Integer) As Task(Of Byte())
        Dim synthesizer = New VoicevoxSynthesizer()

        Try
            Await synthesizer.InitializeStyleAsync(Voice)

            Dim result = Await synthesizer.SynthesizeSpeechAsync(Voice, Str,,,, 1.5)

            'バイト配列を取り出す
            Return result.Wav

        Catch ex As Net.Http.HttpRequestException
            'VOICEVOX本体が起動していない時
            Throw
        End Try
    End Function


    'Wavバイト配列を再生する
    Public Async Function ByteArrayPlay(bt As Byte(), OnFull As Boolean) As Task

        If bt Is Nothing Then Exit Function

        'バイト配列を読み込む
        Dim Reader As New WaveFileReader(New MemoryStream(bt))

        'プレイヤーを召喚
        _Wo = New WaveOut
        '音声を読み込む
        Wo.Init(Reader)
        'プレイヤーを再生
        Wo.Play()

        If OnFull Then
            While Wo.PlaybackState = PlaybackState.Playing
                Await Task.Delay(100)
            End While
        End If
    End Function

End Class
