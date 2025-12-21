Imports System.Text.Json.Serialization

Public Class Music
    Implements System.IComparable(Of Music)

    'タイプ
    Private _type As WaveType
    Public Property Type As String
        Get
            Return _type.ToString
        End Get
        Set(value As String)
            Select Case value.ToLower
                Case "music"
                    _type = WaveType.Music
                Case "commercial"
                    _type = WaveType.Commercial
                Case "jingle"
                    _type = WaveType.Jingle
            End Select
        End Set
    End Property

    <JsonIgnore>
    Public ReadOnly Property TypeEnum As WaveType
        Get
            Return _type
        End Get
    End Property

    Public Enum WaveType
        Music
        Commercial
        Jingle
    End Enum


    'フルパス 
    Private _FileName As String
    Public Property FileName As String
        Get
            Return _FileName
        End Get
        Set(value As String)
            _FileName = value
        End Set
    End Property

    <JsonIgnore>
    Public ReadOnly Property FileNameFull As String
        Get
            Return ToFull(_FileName)
        End Get
    End Property

    Private Function ToFull(str As String)
        '先頭が"\"の場合、先頭にアプリケーションのパスを追記する
        If str.Substring(0, 1) = "\" Then
            Return My.Application.Info.DirectoryPath & str
        Else
            Return str
        End If
    End Function

    '開始時間（秒）
    Public Property StartTime As Integer

    '終了時間（秒）
    Public Property EndingTime As Integer

    'イントロトークwavのフルパス
    Private _IntroFileName As String
    Public Property IntroFileName As String
        Get
            Return _IntroFileName
        End Get
        Set(value As String)
            _IntroFileName = value
        End Set
    End Property

    <JsonIgnore>
    Public ReadOnly Property IntroFileNameFull As String
        Get
            Return ToFull(_IntroFileName)
        End Get
    End Property



    Public Property Title As String

    Public Property TitleSort As String


    Public Property Artist As String


    Public Property ArtistSort As String


    'イントロトークの内容
    <JsonIgnore>
    Public Property IntroTalk As String

    Public Property IntroMaxLength As Integer

    'イントロトークの開始時間（秒）
    Public Property IntroTime As Integer = 1


    'アウトロトークwavのフルパス
    Private _OutroFileName As String
    Public Property OutroFileName As String
        Get
            Return _OutroFileName
        End Get
        Set(value As String)
            _OutroFileName = value
        End Set
    End Property

    <JsonIgnore>
    Public ReadOnly Property OutroFileNameFull As String
        Get
            Return ToFull(_OutroFileName)
        End Get
    End Property


    'アウトロトークの内容
    <JsonIgnore>
    Public Property OutroTalk As String

    'アウトロトークの開始時間（秒）
    Public Property OutroTime As Integer = 12


    Public Property Gein As Double


    Public Property PlayCount As Integer




    '自分自身がotherより小さいときはマイナスの数、大きいときはプラスの数、
    '同じときは0を返す
    Public Function CompareTo(ByVal other As Music) As Integer Implements System.IComparable(Of Music).CompareTo

        'Nothingより大きい
        If other Is Nothing Then
            Return 1
        End If

        If Me.Title = other.Title Then

            If Me.ArtistSort IsNot Nothing AndAlso other.ArtistSort IsNot Nothing Then
                Return Me.ArtistSort.CompareTo(other.ArtistSort)
            Else
                Return Me.Artist.CompareTo(other.Artist)
            End If

        ElseIf Me.TitleSort IsNot Nothing AndAlso other.TitleSort IsNot Nothing Then
            Return Me.TitleSort.CompareTo(other.TitleSort)
        Else
            Return Me.Title.CompareTo(other.Title)
        End If

    End Function







End Class




Public Class Talk

    'タイプ
    Private _type As TalkType
    Public Property Type As String
        Get
            Return _type.ToString
        End Get
        Set(value As String)
            Select Case value.ToLower
                Case "intro"
                    _type = TalkType.Intro
                Case "outro"
                    _type = TalkType.Outro
                Case "call"
                    _type = TalkType.Call
            End Select
        End Set
    End Property

    <JsonIgnore>
    Public ReadOnly Property TypeEnum As TalkType
        Get
            Return _type
        End Get
    End Property

    Public Enum TalkType
        Intro
        Outro
        [Call]
    End Enum

    '雰囲気・時間帯
    Public Property Feeling As String

    '台本
    Public Property Text As String

End Class




Public Class VoiceCharacter

    Sub New(id As Integer, name As String, mySelf As String)
        Me.Id = id
        Me.Name = name
        Me.MySelf = mySelf
    End Sub

    Public Id As Integer
    Public Property Name As String

    Public Property MySelf As String

End Class
