<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class getData
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tdg_to = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.setprice = New System.Windows.Forms.Button()
        CType(Me.tdg_to, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdg_to
        '
        Me.tdg_to.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tdg_to.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tdg_to.Location = New System.Drawing.Point(16, 112)
        Me.tdg_to.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tdg_to.Name = "tdg_to"
        Me.tdg_to.ReadOnly = True
        Me.tdg_to.RowHeadersWidth = 12
        Me.tdg_to.RowTemplate.Height = 23
        Me.tdg_to.Size = New System.Drawing.Size(1167, 411)
        Me.tdg_to.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(964, 59)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 29)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "getData"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1073, 59)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 29)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "excel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(16, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "正在查询，请稍等....."
        Me.Label3.Visible = False
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(635, 59)
        Me.txtOrderNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.Size = New System.Drawing.Size(132, 25)
        Me.txtOrderNo.TabIndex = 15
        '
        'setprice
        '
        Me.setprice.Location = New System.Drawing.Point(964, 13)
        Me.setprice.Margin = New System.Windows.Forms.Padding(4)
        Me.setprice.Name = "setprice"
        Me.setprice.Size = New System.Drawing.Size(100, 29)
        Me.setprice.TabIndex = 16
        Me.setprice.Text = "生成库存成本"
        Me.setprice.UseVisualStyleBackColor = True
        '
        'getData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 558)
        Me.Controls.Add(Me.setprice)
        Me.Controls.Add(Me.txtOrderNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tdg_to)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "getData"
        Me.Text = "getData"
        CType(Me.tdg_to, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tdg_to As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents setprice As Button
End Class
