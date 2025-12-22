<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btn_OK = New Button()
        lbl_Title = New Label()
        GroupBox2 = New GroupBox()
        txb_ArtistSort = New TextBox()
        txb_Artist = New TextBox()
        txb_TitleSort = New TextBox()
        txb_Title = New TextBox()
        Label12 = New Label()
        cmb_Type = New ComboBox()
        txb_FileName = New TextBox()
        Label2 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        btn_Cancel = New Button()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' btn_OK
        ' 
        btn_OK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_OK.DialogResult = DialogResult.OK
        btn_OK.Location = New Point(436, 316)
        btn_OK.Name = "btn_OK"
        btn_OK.Size = New Size(112, 34)
        btn_OK.TabIndex = 11
        btn_OK.Text = "OK"
        btn_OK.UseVisualStyleBackColor = True
        ' 
        ' lbl_Title
        ' 
        lbl_Title.BorderStyle = BorderStyle.Fixed3D
        lbl_Title.Dock = DockStyle.Top
        lbl_Title.Font = New Font("Rounded M+ 1c regular", 13.999999F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        lbl_Title.ImageAlign = ContentAlignment.MiddleLeft
        lbl_Title.Location = New Point(0, 0)
        lbl_Title.Name = "lbl_Title"
        lbl_Title.Size = New Size(675, 53)
        lbl_Title.TabIndex = 32
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(txb_ArtistSort)
        GroupBox2.Controls.Add(txb_Artist)
        GroupBox2.Controls.Add(txb_TitleSort)
        GroupBox2.Controls.Add(txb_Title)
        GroupBox2.Controls.Add(Label12)
        GroupBox2.Controls.Add(cmb_Type)
        GroupBox2.Controls.Add(txb_FileName)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Controls.Add(Label10)
        GroupBox2.Controls.Add(Label11)
        GroupBox2.Location = New Point(12, 56)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(654, 253)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "基本情報"
        ' 
        ' txb_ArtistSort
        ' 
        txb_ArtistSort.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txb_ArtistSort.Location = New Point(145, 212)
        txb_ArtistSort.Name = "txb_ArtistSort"
        txb_ArtistSort.Size = New Size(496, 31)
        txb_ArtistSort.TabIndex = 7
        ' 
        ' txb_Artist
        ' 
        txb_Artist.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txb_Artist.Location = New Point(145, 175)
        txb_Artist.Name = "txb_Artist"
        txb_Artist.Size = New Size(496, 31)
        txb_Artist.TabIndex = 6
        ' 
        ' txb_TitleSort
        ' 
        txb_TitleSort.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txb_TitleSort.Location = New Point(145, 138)
        txb_TitleSort.Name = "txb_TitleSort"
        txb_TitleSort.Size = New Size(496, 31)
        txb_TitleSort.TabIndex = 5
        ' 
        ' txb_Title
        ' 
        txb_Title.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txb_Title.Location = New Point(145, 101)
        txb_Title.Name = "txb_Title"
        txb_Title.Size = New Size(496, 31)
        txb_Title.TabIndex = 4
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(6, 209)
        Label12.Name = "Label12"
        Label12.Size = New Size(87, 25)
        Label12.TabIndex = 26
        Label12.Text = "ArtistSort"
        ' 
        ' cmb_Type
        ' 
        cmb_Type.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cmb_Type.FormattingEnabled = True
        cmb_Type.Location = New Point(145, 23)
        cmb_Type.Name = "cmb_Type"
        cmb_Type.Size = New Size(496, 33)
        cmb_Type.TabIndex = 2
        ' 
        ' txb_FileName
        ' 
        txb_FileName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txb_FileName.Location = New Point(145, 62)
        txb_FileName.Name = "txb_FileName"
        txb_FileName.Size = New Size(496, 31)
        txb_FileName.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 27)
        Label2.Name = "Label2"
        Label2.Size = New Size(48, 25)
        Label2.TabIndex = 12
        Label2.Text = "Type"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(6, 64)
        Label8.Name = "Label8"
        Label8.Size = New Size(85, 25)
        Label8.TabIndex = 13
        Label8.Text = "FileName"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(6, 101)
        Label9.Name = "Label9"
        Label9.Size = New Size(44, 25)
        Label9.TabIndex = 14
        Label9.Text = "Title"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(6, 138)
        Label10.Name = "Label10"
        Label10.Size = New Size(77, 25)
        Label10.TabIndex = 15
        Label10.Text = "TitleSort"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(6, 174)
        Label11.Name = "Label11"
        Label11.Size = New Size(54, 25)
        Label11.TabIndex = 22
        Label11.Text = "Artist"
        ' 
        ' btn_Cancel
        ' 
        btn_Cancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_Cancel.DialogResult = DialogResult.Cancel
        btn_Cancel.Location = New Point(554, 316)
        btn_Cancel.Name = "btn_Cancel"
        btn_Cancel.Size = New Size(112, 34)
        btn_Cancel.TabIndex = 12
        btn_Cancel.Text = "キャンセル"
        btn_Cancel.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(675, 362)
        Controls.Add(btn_Cancel)
        Controls.Add(btn_OK)
        Controls.Add(GroupBox2)
        Controls.Add(lbl_Title)
        Name = "Form2"
        Text = "ラジオ風プレイヤー"
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents btn_OK As Button
    Friend WithEvents lbl_Title As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmb_Type As ComboBox
    Friend WithEvents txb_FileName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents txb_ArtistSort As TextBox
    Friend WithEvents txb_Artist As TextBox
    Friend WithEvents txb_TitleSort As TextBox
    Friend WithEvents txb_Title As TextBox
    Friend WithEvents Label12 As Label
End Class
