Imports System.Reflection.Emit

Public Class InfoPaint

    Private Const FirstHeight = 2
    Private Const SecondHeight = 42

    Public Sub Paint(g As Graphics, Music As Music, LabelWidth As Integer, Font As Font)

        '曲が選択されていれば
        If Music IsNot Nothing Then
            'リリース年が設定されていれば
            If Music.ReleaseYear <> "" Then
                'リリース年を描画
                g.DrawString(Music.ReleaseYearIsWestern, Font, Brushes.White, 2, FirstHeight)
                'リリース年を和暦で描画
                g.DrawString(Music.ReleaseYearIsJapanese, Font, Brushes.White, 2, SecondHeight)
            End If

            Dim sf As New StringFormat
            sf.Trimming = StringTrimming.EllipsisCharacter

            'タイトルを描画
            g.DrawString(Music.Title, Font, Brushes.LightGreen, New RectangleF(130, FirstHeight, LabelWidth \ 2 - 124, 42), sf)
            'アーティストを描画
            g.DrawString(Music.Artist, Font, Brushes.White, New RectangleF(130, SecondHeight, LabelWidth \ 2 - 124, 42), sf)

            '作詞者を描画
            If Music.Lyricist <> "" Then
                g.DrawString("作詞 " & Music.Lyricist, Font, Brushes.White, LabelWidth \ 2, FirstHeight)
            End If

            '作曲者を描画
            If Music.Composer <> "" Then
                g.DrawString("作曲 " & Music.Composer, Font, Brushes.White, LabelWidth \ 2, SecondHeight)
            End If

        End If

    End Sub


    Public Sub TimePaint(g As Graphics, MusicPlayer As MusicPlayer, LabelWidth As Integer, Font As Font)

        '文字描画位置を右寄せにする
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Far

        '時刻表示枠を指定
        Dim TimeRectangle As New RectangleF(LabelWidth - 150, FirstHeight, 148, 42)

        '現在の時刻を描画
        g.DrawString(Format(Now, "HH:mm:ss"), Font, Brushes.White, TimeRectangle, sf)

        '曲が選択されていれば
        If MusicPlayer.MusicReader IsNot Nothing Then
            '再生位置を描画
            Dim TimeCount As Integer = Int(MusicPlayer.MusicReader.CurrentTime.TotalSeconds)
            TimeRectangle = New RectangleF(LabelWidth - 150, SecondHeight, 148, 42)
            g.DrawString(TimeCount, Font, Brushes.White, TimeRectangle, sf)
        End If

    End Sub

End Class
