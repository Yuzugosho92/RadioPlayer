<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        ckb_Gein = New CheckBox()
        Button1 = New Button()
        ckb_MySelf = New CheckBox()
        GroupBox2 = New GroupBox()
        Label1 = New Label()
        NumericUpDown1 = New NumericUpDown()
        Button3 = New Button()
        Button2 = New Button()
        ckb_Traffic = New CheckBox()
        btn_Cancel = New Button()
        btn_OK = New Button()
        GroupBox3 = New GroupBox()
        Label3 = New Label()
        NumericUpDown2 = New NumericUpDown()
        GroupBox4 = New GroupBox()
        Label2 = New Label()
        txb_RadioName = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox4.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(ckb_Gein)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(ckb_MySelf)
        GroupBox1.Location = New Point(12, 104)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(208, 149)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "音楽"
        ' 
        ' ckb_Gein
        ' 
        ckb_Gein.AutoSize = True
        ckb_Gein.Location = New Point(6, 105)
        ckb_Gein.Name = "ckb_Gein"
        ckb_Gein.Size = New Size(178, 29)
        ckb_Gein.TabIndex = 2
        ckb_Gein.Text = "ゲインの再読み込み"
        ckb_Gein.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(6, 65)
        Button1.Name = "Button1"
        Button1.Size = New Size(124, 34)
        Button1.TabIndex = 1
        Button1.Text = "ボイス選択"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ckb_MySelf
        ' 
        ckb_MySelf.AutoSize = True
        ckb_MySelf.Location = New Point(6, 30)
        ckb_MySelf.Name = "ckb_MySelf"
        ckb_MySelf.Size = New Size(138, 29)
        ckb_MySelf.TabIndex = 0
        ckb_MySelf.Text = "名前を名乗る"
        ckb_MySelf.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(NumericUpDown1)
        GroupBox2.Controls.Add(Button3)
        GroupBox2.Controls.Add(Button2)
        GroupBox2.Controls.Add(ckb_Traffic)
        GroupBox2.Location = New Point(12, 259)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(208, 192)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "交通情報"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 147)
        Label1.Name = "Label1"
        Label1.Size = New Size(84, 25)
        Label1.TabIndex = 4
        Label1.Text = "放送間隔"
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Location = New Point(96, 145)
        NumericUpDown1.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(60, 31)
        NumericUpDown1.TabIndex = 3
        NumericUpDown1.Value = New Decimal(New Integer() {30, 0, 0, 0})
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(6, 105)
        Button3.Name = "Button3"
        Button3.Size = New Size(112, 34)
        Button3.TabIndex = 2
        Button3.Text = "Button3"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(6, 65)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 34)
        Button2.TabIndex = 1
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' ckb_Traffic
        ' 
        ckb_Traffic.AutoSize = True
        ckb_Traffic.Location = New Point(6, 30)
        ckb_Traffic.Name = "ckb_Traffic"
        ckb_Traffic.Size = New Size(84, 29)
        ckb_Traffic.TabIndex = 0
        ckb_Traffic.Text = "OnAir"
        ckb_Traffic.UseVisualStyleBackColor = True
        ' 
        ' btn_Cancel
        ' 
        btn_Cancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_Cancel.DialogResult = DialogResult.Cancel
        btn_Cancel.Location = New Point(408, 427)
        btn_Cancel.Name = "btn_Cancel"
        btn_Cancel.Size = New Size(112, 34)
        btn_Cancel.TabIndex = 7
        btn_Cancel.Text = "キャンセル"
        btn_Cancel.UseVisualStyleBackColor = True
        ' 
        ' btn_OK
        ' 
        btn_OK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_OK.DialogResult = DialogResult.OK
        btn_OK.Location = New Point(290, 427)
        btn_OK.Name = "btn_OK"
        btn_OK.Size = New Size(112, 34)
        btn_OK.TabIndex = 6
        btn_OK.Text = "OK"
        btn_OK.UseVisualStyleBackColor = True
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(Label5)
        GroupBox3.Controls.Add(Label3)
        GroupBox3.Controls.Add(NumericUpDown2)
        GroupBox3.Location = New Point(226, 104)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(234, 68)
        GroupBox3.TabIndex = 8
        GroupBox3.TabStop = False
        GroupBox3.Text = "ジングル"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(6, 27)
        Label3.Name = "Label3"
        Label3.Size = New Size(84, 25)
        Label3.TabIndex = 6
        Label3.Text = "放送間隔"
        ' 
        ' NumericUpDown2
        ' 
        NumericUpDown2.Location = New Point(96, 25)
        NumericUpDown2.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        NumericUpDown2.Name = "NumericUpDown2"
        NumericUpDown2.Size = New Size(54, 31)
        NumericUpDown2.TabIndex = 5
        NumericUpDown2.Value = New Decimal(New Integer() {3, 0, 0, 0})
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(Label2)
        GroupBox4.Controls.Add(txb_RadioName)
        GroupBox4.Location = New Point(12, 12)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(263, 79)
        GroupBox4.TabIndex = 9
        GroupBox4.TabStop = False
        GroupBox4.Text = "全般"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 33)
        Label2.Name = "Label2"
        Label2.Size = New Size(89, 25)
        Label2.TabIndex = 6
        Label2.Text = "ラジオ局名"
        ' 
        ' txb_RadioName
        ' 
        txb_RadioName.Location = New Point(96, 30)
        txb_RadioName.Name = "txb_RadioName"
        txb_RadioName.Size = New Size(155, 31)
        txb_RadioName.TabIndex = 5
        txb_RadioName.Text = "ボイボ寮ラジオ"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(162, 147)
        Label4.Name = "Label4"
        Label4.Size = New Size(30, 25)
        Label4.TabIndex = 5
        Label4.Text = "分"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(156, 27)
        Label5.Name = "Label5"
        Label5.Size = New Size(72, 25)
        Label5.TabIndex = 7
        Label5.Text = "曲に1回"
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(531, 473)
        Controls.Add(GroupBox4)
        Controls.Add(GroupBox3)
        Controls.Add(btn_Cancel)
        Controls.Add(btn_OK)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Name = "Form4"
        Text = "Form4"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).EndInit()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ckb_MySelf As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ckb_Traffic As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents btn_OK As Button
    Friend WithEvents ckb_Gein As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txb_RadioName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
