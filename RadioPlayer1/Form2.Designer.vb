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
        GroupBox1 = New GroupBox()
        Label3 = New Label()
        NUD_StartTime = New NumericUpDown()
        NUD_EndingTime = New NumericUpDown()
        NUD_IntroTime = New NumericUpDown()
        NUD_OutroTime = New NumericUpDown()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        NUD_IntroMaxLength = New NumericUpDown()
        Button8 = New Button()
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
        GroupBox1.SuspendLayout()
        CType(NUD_StartTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(NUD_EndingTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(NUD_IntroTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(NUD_OutroTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(NUD_IntroMaxLength, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(NUD_StartTime)
        GroupBox1.Controls.Add(NUD_EndingTime)
        GroupBox1.Controls.Add(NUD_IntroTime)
        GroupBox1.Controls.Add(NUD_OutroTime)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(NUD_IntroMaxLength)
        GroupBox1.Controls.Add(Button8)
        GroupBox1.Location = New Point(12, 315)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(361, 216)
        GroupBox1.TabIndex = 31
        GroupBox1.TabStop = False
        GroupBox1.Text = "タイミング調声"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(6, 27)
        Label3.Name = "Label3"
        Label3.Size = New Size(87, 25)
        Label3.TabIndex = 12
        Label3.Text = "StartTime"
        ' 
        ' NUD_StartTime
        ' 
        NUD_StartTime.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        NUD_StartTime.BorderStyle = BorderStyle.FixedSingle
        NUD_StartTime.Location = New Point(145, 25)
        NUD_StartTime.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        NUD_StartTime.Name = "NUD_StartTime"
        NUD_StartTime.Size = New Size(86, 31)
        NUD_StartTime.TabIndex = 8
        ' 
        ' NUD_EndingTime
        ' 
        NUD_EndingTime.Location = New Point(145, 62)
        NUD_EndingTime.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        NUD_EndingTime.Name = "NUD_EndingTime"
        NUD_EndingTime.Size = New Size(86, 31)
        NUD_EndingTime.TabIndex = 9
        ' 
        ' NUD_IntroTime
        ' 
        NUD_IntroTime.Location = New Point(145, 99)
        NUD_IntroTime.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        NUD_IntroTime.Name = "NUD_IntroTime"
        NUD_IntroTime.Size = New Size(86, 31)
        NUD_IntroTime.TabIndex = 10
        ' 
        ' NUD_OutroTime
        ' 
        NUD_OutroTime.Location = New Point(145, 136)
        NUD_OutroTime.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        NUD_OutroTime.Name = "NUD_OutroTime"
        NUD_OutroTime.Size = New Size(86, 31)
        NUD_OutroTime.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(6, 64)
        Label4.Name = "Label4"
        Label4.Size = New Size(105, 25)
        Label4.TabIndex = 13
        Label4.Text = "EndingTime"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(6, 101)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 25)
        Label5.TabIndex = 14
        Label5.Text = "IntroTime"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(6, 138)
        Label6.Name = "Label6"
        Label6.Size = New Size(97, 25)
        Label6.TabIndex = 15
        Label6.Text = "OutroTime"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(6, 174)
        Label7.Name = "Label7"
        Label7.Size = New Size(137, 25)
        Label7.TabIndex = 22
        Label7.Text = "IntroMaxLength"
        ' 
        ' NUD_IntroMaxLength
        ' 
        NUD_IntroMaxLength.Location = New Point(145, 172)
        NUD_IntroMaxLength.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        NUD_IntroMaxLength.Name = "NUD_IntroMaxLength"
        NUD_IntroMaxLength.Size = New Size(86, 31)
        NUD_IntroMaxLength.TabIndex = 21
        ' 
        ' Button8
        ' 
        Button8.Location = New Point(237, 96)
        Button8.Name = "Button8"
        Button8.Size = New Size(112, 34)
        Button8.TabIndex = 19
        Button8.Text = "ここに挿入"
        Button8.UseVisualStyleBackColor = True
        ' 
        ' btn_OK
        ' 
        btn_OK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_OK.DialogResult = DialogResult.OK
        btn_OK.Location = New Point(436, 536)
        btn_OK.Name = "btn_OK"
        btn_OK.Size = New Size(112, 34)
        btn_OK.TabIndex = 16
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
        GroupBox2.TabIndex = 33
        GroupBox2.TabStop = False
        GroupBox2.Text = "基本情報"
        ' 
        ' txb_ArtistSort
        ' 
        txb_ArtistSort.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txb_ArtistSort.Location = New Point(145, 212)
        txb_ArtistSort.Name = "txb_ArtistSort"
        txb_ArtistSort.Size = New Size(496, 31)
        txb_ArtistSort.TabIndex = 30
        ' 
        ' txb_Artist
        ' 
        txb_Artist.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txb_Artist.Location = New Point(145, 175)
        txb_Artist.Name = "txb_Artist"
        txb_Artist.Size = New Size(496, 31)
        txb_Artist.TabIndex = 29
        ' 
        ' txb_TitleSort
        ' 
        txb_TitleSort.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txb_TitleSort.Location = New Point(145, 138)
        txb_TitleSort.Name = "txb_TitleSort"
        txb_TitleSort.Size = New Size(496, 31)
        txb_TitleSort.TabIndex = 28
        ' 
        ' txb_Title
        ' 
        txb_Title.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txb_Title.Location = New Point(145, 101)
        txb_Title.Name = "txb_Title"
        txb_Title.Size = New Size(496, 31)
        txb_Title.TabIndex = 27
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
        cmb_Type.TabIndex = 24
        ' 
        ' txb_FileName
        ' 
        txb_FileName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txb_FileName.Location = New Point(145, 62)
        txb_FileName.Name = "txb_FileName"
        txb_FileName.Size = New Size(496, 31)
        txb_FileName.TabIndex = 23
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
        btn_Cancel.Location = New Point(554, 536)
        btn_Cancel.Name = "btn_Cancel"
        btn_Cancel.Size = New Size(112, 34)
        btn_Cancel.TabIndex = 16
        btn_Cancel.Text = "キャンセル"
        btn_Cancel.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(675, 582)
        Controls.Add(btn_Cancel)
        Controls.Add(btn_OK)
        Controls.Add(GroupBox2)
        Controls.Add(lbl_Title)
        Controls.Add(GroupBox1)
        Name = "Form2"
        Text = "ラジオ風プレイヤー"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(NUD_StartTime, ComponentModel.ISupportInitialize).EndInit()
        CType(NUD_EndingTime, ComponentModel.ISupportInitialize).EndInit()
        CType(NUD_IntroTime, ComponentModel.ISupportInitialize).EndInit()
        CType(NUD_OutroTime, ComponentModel.ISupportInitialize).EndInit()
        CType(NUD_IntroMaxLength, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents NUD_StartTime As NumericUpDown
    Friend WithEvents NUD_EndingTime As NumericUpDown
    Friend WithEvents NUD_IntroTime As NumericUpDown
    Friend WithEvents NUD_OutroTime As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btn_OK As Button
    Friend WithEvents NUD_IntroMaxLength As NumericUpDown
    Friend WithEvents Button8 As Button
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
