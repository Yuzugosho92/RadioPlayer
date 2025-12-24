Imports System.Text.Json.Serialization
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports RadioPlayer1.Talk

Public Class MusicList
    Inherits List(Of Music)

    '指定したタイプの音楽が存在するかを返す
    Public Function ExistsType(type As Music.WaveType) As Boolean

        For i As Integer = 0 To Me.Count - 1
            '一致したタイプがあれば、Trueを返す
            If Me.Item(i).TypeEnum = type Then
                Return True
            End If
        Next

        '見つからなかったらFalseを返す
        Return False
    End Function

End Class



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
                Case "traffic"
                    _type = WaveType.Traffic
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
        Traffic
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

        'タイトルが同じ場合
        If Me.Title = other.Title Then
            'アーティストを比較する
            'このTitleSortが無い場合
            If Me.ArtistSort Is Nothing OrElse Me.ArtistSort = "" Then
                '相手のArtistSortも無い場合
                If other.ArtistSort Is Nothing OrElse other.ArtistSort = "" Then
                    'Artist同士を比較する
                    Return Me.Artist.CompareTo(other.Artist)
                Else
                    'ArtistとArtistSortを比較する
                    Return Me.Artist.CompareTo(other.ArtistSort)
                End If
            Else
                '相手のArtistSortが無い場合
                If other.ArtistSort Is Nothing OrElse other.ArtistSort = "" Then
                    'ArtistSortとArtistを比較する
                    Return Me.ArtistSort.CompareTo(other.Artist)
                Else
                    'ArtistSort同士を比較する
                    Return Me.ArtistSort.CompareTo(other.ArtistSort)
                End If
            End If
        Else
            'タイトルを比較する
            'このTitleSortが無い場合
            If Me.TitleSort Is Nothing OrElse Me.TitleSort = "" Then
                '相手のTitleSortも無い場合
                If other.TitleSort Is Nothing OrElse other.TitleSort = "" Then
                    'Title同士を比較する
                    Return Me.Title.CompareTo(other.Title)
                Else
                    'TitleとTitleSortを比較する
                    Return Me.Title.CompareTo(other.TitleSort)
                End If
            Else
                '相手のTitleSortが無い場合
                If other.TitleSort Is Nothing OrElse other.TitleSort = "" Then
                    'TitleSortとTitleを比較する
                    Return Me.TitleSort.CompareTo(other.Title)
                Else
                    'TitleSort同士を比較する
                    Return Me.TitleSort.CompareTo(other.TitleSort)
                End If
            End If
        End If

    End Function

End Class




Public Class Talk

    Sub New()
        ReDim FeelingTime(23)

        For i As Integer = 0 To 23
            FeelingTime(i) = True
        Next
    End Sub

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
    Private _Feeling As String
    Public Property Feeling As String
        Get
            Return _Feeling
        End Get
        Set(value As String)
            _Feeling = value

            '時間帯指定があれば
            If Regex.IsMatch(_Feeling, "[0-9]*-[0-9]*") Then
                '文字列を分割
                Dim str As String() = _Feeling.Split("-")
                '開始・終了時間を設定
                Dim Start As Integer = CInt(str(0))
                Dim Final As Integer = CInt(str(1))

                If Start > Final Then
                    '非対応の各時間にFalseを登録
                    For i As Integer = Final To Start - 1
                        FeelingTime(i) = False
                    Next
                Else
                    '0時をまたぐ場合
                    For i As Integer = Final To 23
                        FeelingTime(i) = False
                    Next

                    For i As Integer = 0 To Start - 1
                        FeelingTime(i) = False
                    Next
                End If
            End If
        End Set
    End Property

    <JsonIgnore>
    Public Property FeelingTime As Boolean()

    '台本
    Public Property Text As String

End Class




Public Class VoiceCharacter

    'VOICEVOXの内部番号
    Public Property Id As Integer

    'フルネーム
    Public Property Name As String

    '自分の呼び方（MCの時）
    Public Property MySelf As String

    '自分の呼び方（交通情報の時）
    Public Property TrafficMySelf As String = ""

    '相手の呼び方
    Public Property YourName As String = ""

    'MCで使用するかどうか
    Public Property Use As Boolean = True

    '交通情報で使用するかどうか
    Public Property TrafficMcUse As Boolean = True
    Public Property TrafficCenterUse As Boolean = True

End Class
