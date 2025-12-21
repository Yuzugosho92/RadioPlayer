Public Class Form2

    Dim EditMusic As Music

    Public Overloads Function ShowDialog(Owner As IWin32Window, editMusic As Music)

        'Typeコンボボックスの内容を設定
        cmb_Type.Items.AddRange({Music.WaveType.Music, Music.WaveType.Jingle})

        '編集する曲を登録
        Me.EditMusic = editMusic

        '選択中の曲の情報を設定
        lbl_Title.Text = editMusic.Title
        cmb_Type.SelectedItem = editMusic.TypeEnum
        txb_FileName.Text = editMusic.FileName
        txb_Title.Text = editMusic.Title
        txb_TitleSort.Text = editMusic.TitleSort
        txb_Artist.Text = editMusic.Artist
        txb_ArtistSort.Text = editMusic.ArtistSort

        Return Me.ShowDialog(Owner)

    End Function



    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click

        '各種情報を更新
        EditMusic.Type = cmb_Type.SelectedItem.ToString
        EditMusic.FileName = txb_FileName.Text
        EditMusic.Title = txb_Title.Text
        EditMusic.TitleSort = txb_TitleSort.Text
        EditMusic.Artist = txb_Artist.Text
        EditMusic.ArtistSort = txb_ArtistSort.Text

        lbl_Title.Text = EditMusic.Title

        'フォームを閉じる
        Me.Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        'フォームを閉じる
        Me.Close()
    End Sub




End Class