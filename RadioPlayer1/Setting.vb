Public Class Setting

    'ラジオ局の名前
    Public Property RadioName As String = "ボイボ寮ラジオ"

    'MCの前に名前を名乗るかどうか
    Public Property MySelf As Boolean

    'ジングルを挟む頻度（n曲に1回）
    Public Property JingleFrequency As Integer = 3

    'ゲインの再読み込み
    Public Property Gein As Boolean

    'フルコーラス流すかどうか
    Public Property FullChorus As Boolean

    '交通情報を挟むかどうか
    Public Property Traffic As Boolean = True

    '交通情報の時間間隔
    Public Property TrafficInterval As Integer = 30






End Class
