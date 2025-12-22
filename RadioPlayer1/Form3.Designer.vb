<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        btn_Cancel = New Button()
        btn_OK = New Button()
        Button1 = New Button()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' ListView1
        ' 
        ListView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ListView1.AutoArrange = False
        ListView1.CheckBoxes = True
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader1})
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.HideSelection = True
        ListView1.Location = New Point(12, 12)
        ListView1.MultiSelect = False
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(466, 562)
        ListView1.TabIndex = 1
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "ボイスキャラクター"
        ColumnHeader1.Width = 200
        ' 
        ' btn_Cancel
        ' 
        btn_Cancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_Cancel.DialogResult = DialogResult.Cancel
        btn_Cancel.Location = New Point(368, 580)
        btn_Cancel.Name = "btn_Cancel"
        btn_Cancel.Size = New Size(112, 34)
        btn_Cancel.TabIndex = 5
        btn_Cancel.Text = "キャンセル"
        btn_Cancel.UseVisualStyleBackColor = True
        ' 
        ' btn_OK
        ' 
        btn_OK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_OK.DialogResult = DialogResult.OK
        btn_OK.Location = New Point(250, 580)
        btn_OK.Name = "btn_OK"
        btn_OK.Size = New Size(112, 34)
        btn_OK.TabIndex = 4
        btn_OK.Text = "OK"
        btn_OK.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Button1.Location = New Point(12, 580)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 2
        Button1.Text = "すべて選択"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Button2.Location = New Point(130, 580)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 34)
        Button2.TabIndex = 3
        Button2.Text = "すべて外す"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(490, 626)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(btn_Cancel)
        Controls.Add(btn_OK)
        Controls.Add(ListView1)
        MinimumSize = New Size(512, 0)
        Name = "Form3"
        Text = "ラジオ風プレイヤー"
        ResumeLayout(False)
    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents btn_OK As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
