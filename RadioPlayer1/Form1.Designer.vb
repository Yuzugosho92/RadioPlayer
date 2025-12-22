<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Button1 = New Button()
        Timer1 = New Timer(components)
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        Label1 = New Label()
        Label2 = New Label()
        NUD_StartTime = New NumericUpDown()
        NUD_EndingTime = New NumericUpDown()
        NUD_IntroTime = New NumericUpDown()
        NUD_OutroTime = New NumericUpDown()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Button5 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        Button8 = New Button()
        Button9 = New Button()
        Label7 = New Label()
        NUD_IntroMaxLength = New NumericUpDown()
        Label8 = New Label()
        HScrollBar1 = New HScrollBar()
        GroupBox1 = New GroupBox()
        Label10 = New Label()
        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        PlayToolStripMenuItem = New ToolStripMenuItem()
        EditToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripSeparator()
        DelToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1 = New MenuStrip()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripMenuItem()
        CheckBox1 = New CheckBox()
        CType(NUD_StartTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(NUD_EndingTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(NUD_IntroTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(NUD_OutroTime, ComponentModel.ISupportInitialize).BeginInit()
        CType(NUD_IntroMaxLength, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        ContextMenuStrip1.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(10, 128)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 0
        Button1.Text = "スタート"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 1000
        ' 
        ' BackgroundWorker1
        ' 
        BackgroundWorker1.WorkerReportsProgress = True
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Label1.BorderStyle = BorderStyle.Fixed3D
        Label1.Dock = DockStyle.Top
        Label1.Font = New Font("Rounded M+ 1c regular", 13.999999F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label1.ForeColor = SystemColors.Window
        Label1.Location = New Point(0, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(921, 92)
        Label1.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AllowDrop = True
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label2.BorderStyle = BorderStyle.FixedSingle
        Label2.Location = New Point(561, 165)
        Label2.Name = "Label2"
        Label2.Size = New Size(350, 232)
        Label2.TabIndex = 6
        Label2.Text = "ここに音楽ファイルを投入" & vbCrLf & "(Wave, MP3, MP4, FLAC)"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' NUD_StartTime
        ' 
        NUD_StartTime.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        NUD_StartTime.BorderStyle = BorderStyle.FixedSingle
        NUD_StartTime.Location = New Point(145, 25)
        NUD_StartTime.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        NUD_StartTime.Name = "NUD_StartTime"
        NUD_StartTime.Size = New Size(86, 31)
        NUD_StartTime.TabIndex = 4
        ' 
        ' NUD_EndingTime
        ' 
        NUD_EndingTime.Location = New Point(145, 62)
        NUD_EndingTime.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        NUD_EndingTime.Name = "NUD_EndingTime"
        NUD_EndingTime.Size = New Size(86, 31)
        NUD_EndingTime.TabIndex = 5
        ' 
        ' NUD_IntroTime
        ' 
        NUD_IntroTime.Location = New Point(145, 99)
        NUD_IntroTime.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        NUD_IntroTime.Name = "NUD_IntroTime"
        NUD_IntroTime.Size = New Size(86, 31)
        NUD_IntroTime.TabIndex = 6
        ' 
        ' NUD_OutroTime
        ' 
        NUD_OutroTime.Location = New Point(145, 136)
        NUD_OutroTime.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        NUD_OutroTime.Name = "NUD_OutroTime"
        NUD_OutroTime.Size = New Size(86, 31)
        NUD_OutroTime.TabIndex = 7
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
        ' Button5
        ' 
        Button5.Location = New Point(6, 215)
        Button5.Name = "Button5"
        Button5.Size = New Size(112, 34)
        Button5.TabIndex = 9
        Button5.Text = "変更"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(270, 128)
        Button6.Name = "Button6"
        Button6.Size = New Size(71, 34)
        Button6.TabIndex = 2
        Button6.Text = "+10"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(193, 128)
        Button7.Name = "Button7"
        Button7.Size = New Size(71, 34)
        Button7.TabIndex = 1
        Button7.Text = "-10"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Button8
        ' 
        Button8.Location = New Point(237, 136)
        Button8.Name = "Button8"
        Button8.Size = New Size(112, 34)
        Button8.TabIndex = 10
        Button8.Text = "この時間！"
        Button8.UseVisualStyleBackColor = True
        ' 
        ' Button9
        ' 
        Button9.Location = New Point(347, 129)
        Button9.Name = "Button9"
        Button9.Size = New Size(70, 34)
        Button9.TabIndex = 3
        Button9.Text = "ラスト"
        Button9.UseVisualStyleBackColor = True
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
        NUD_IntroMaxLength.TabIndex = 8
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Dock = DockStyle.Bottom
        Label8.Location = New Point(0, 731)
        Label8.Name = "Label8"
        Label8.Size = New Size(0, 25)
        Label8.TabIndex = 23
        ' 
        ' HScrollBar1
        ' 
        HScrollBar1.Dock = DockStyle.Bottom
        HScrollBar1.Location = New Point(0, 692)
        HScrollBar1.Name = "HScrollBar1"
        HScrollBar1.Size = New Size(921, 39)
        HScrollBar1.TabIndex = 12
        HScrollBar1.Value = 100
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
        GroupBox1.Controls.Add(Button5)
        GroupBox1.Controls.Add(NUD_IntroMaxLength)
        GroupBox1.Controls.Add(Button8)
        GroupBox1.Location = New Point(10, 400)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(363, 260)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "タイミング調整"
        ' 
        ' Label10
        ' 
        Label10.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(64))
        Label10.BorderStyle = BorderStyle.Fixed3D
        Label10.Font = New Font("Rounded M+ 1c regular", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, CByte(128))
        Label10.ForeColor = Color.White
        Label10.Location = New Point(10, 165)
        Label10.Name = "Label10"
        Label10.Size = New Size(545, 232)
        Label10.TabIndex = 31
        ' 
        ' ListView1
        ' 
        ListView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ListView1.AutoArrange = False
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3})
        ListView1.ContextMenuStrip = ContextMenuStrip1
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.HideSelection = True
        ListView1.Location = New Point(389, 411)
        ListView1.MultiSelect = False
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(520, 247)
        ListView1.TabIndex = 11
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "タイトル"
        ColumnHeader1.Width = 150
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "アーティスト"
        ColumnHeader2.Width = 150
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "タイプ"
        ColumnHeader3.Width = 53
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(24, 24)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {PlayToolStripMenuItem, EditToolStripMenuItem, ToolStripMenuItem2, DelToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(253, 106)
        ' 
        ' PlayToolStripMenuItem
        ' 
        PlayToolStripMenuItem.Name = "PlayToolStripMenuItem"
        PlayToolStripMenuItem.Size = New Size(252, 32)
        PlayToolStripMenuItem.Text = "再生(&P)"
        ' 
        ' EditToolStripMenuItem
        ' 
        EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        EditToolStripMenuItem.Size = New Size(252, 32)
        EditToolStripMenuItem.Text = "編集(&E)"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(249, 6)
        ' 
        ' DelToolStripMenuItem
        ' 
        DelToolStripMenuItem.Name = "DelToolStripMenuItem"
        DelToolStripMenuItem.Size = New Size(252, 32)
        DelToolStripMenuItem.Text = "データベースから削除(&D)"
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(921, 33)
        MenuStrip1.TabIndex = 34
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem3})
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(78, 29)
        ToolStripMenuItem1.Text = "メニュー"
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(239, 34)
        ToolStripMenuItem3.Text = "ゲイン再読み込み"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.Appearance = Appearance.Button
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(128, 128)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(59, 35)
        CheckBox1.TabIndex = 35
        CheckBox1.Text = "FULL"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(921, 756)
        Controls.Add(CheckBox1)
        Controls.Add(ListView1)
        Controls.Add(Label10)
        Controls.Add(GroupBox1)
        Controls.Add(HScrollBar1)
        Controls.Add(Label8)
        Controls.Add(Button9)
        Controls.Add(Button7)
        Controls.Add(Button6)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(MenuStrip1)
        Name = "Form1"
        Text = "ラジオ風プレイヤー"
        CType(NUD_StartTime, ComponentModel.ISupportInitialize).EndInit()
        CType(NUD_EndingTime, ComponentModel.ISupportInitialize).EndInit()
        CType(NUD_IntroTime, ComponentModel.ISupportInitialize).EndInit()
        CType(NUD_OutroTime, ComponentModel.ISupportInitialize).EndInit()
        CType(NUD_IntroMaxLength, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ContextMenuStrip1.ResumeLayout(False)
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents NUD_StartTime As NumericUpDown
    Friend WithEvents NUD_EndingTime As NumericUpDown
    Friend WithEvents NUD_IntroTime As NumericUpDown
    Friend WithEvents NUD_OutroTime As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents NUD_IntroMaxLength As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents PlayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents DelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBox1 As CheckBox

End Class
