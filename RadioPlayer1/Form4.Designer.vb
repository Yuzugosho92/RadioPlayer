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
        Button1 = New Button()
        CheckBox1 = New CheckBox()
        GroupBox2 = New GroupBox()
        Label1 = New Label()
        NumericUpDown1 = New NumericUpDown()
        Button3 = New Button()
        Button2 = New Button()
        CheckBox2 = New CheckBox()
        btn_Cancel = New Button()
        btn_OK = New Button()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(CheckBox1)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(180, 115)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "音楽"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(6, 65)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 1
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(6, 30)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(124, 29)
        CheckBox1.TabIndex = 0
        CheckBox1.Text = "CheckBox1"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(NumericUpDown1)
        GroupBox2.Controls.Add(Button3)
        GroupBox2.Controls.Add(Button2)
        GroupBox2.Controls.Add(CheckBox2)
        GroupBox2.Location = New Point(198, 12)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(420, 192)
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
        ' CheckBox2
        ' 
        CheckBox2.AutoSize = True
        CheckBox2.Location = New Point(6, 30)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New Size(84, 29)
        CheckBox2.TabIndex = 0
        CheckBox2.Text = "OnAir"
        CheckBox2.UseVisualStyleBackColor = True
        ' 
        ' btn_Cancel
        ' 
        btn_Cancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_Cancel.DialogResult = DialogResult.Cancel
        btn_Cancel.Location = New Point(677, 310)
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
        btn_OK.Location = New Point(559, 310)
        btn_OK.Name = "btn_OK"
        btn_OK.Size = New Size(112, 34)
        btn_OK.TabIndex = 6
        btn_OK.Text = "OK"
        btn_OK.UseVisualStyleBackColor = True
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 356)
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
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents btn_OK As Button
End Class
