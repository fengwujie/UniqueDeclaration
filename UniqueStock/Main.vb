Public Class Main

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()

        Dim objForm As New Login
        If objForm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Application.Exit()
            Exit Sub
        End If

        Me.Show()

    End Sub


    Private Sub 计算器ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 计算器ToolStripMenuItem.Click
        Dim info As New System.Diagnostics.ProcessStartInfo()
        Dim proc As New System.Diagnostics.Process()

        '//设置外部程序名(记事本用 notepad.exe 计算器用 calc.exe) 
        info.FileName = "calc.exe"

        '//设置外部程序的启动参数

        info.Arguments = ""

        '//设置外部程序工作目录为c:\windows

        info.WorkingDirectory = "c:/windows/"

        Try


            '// 
            '//启动外部程序 
            '// 
            proc = System.Diagnostics.Process.Start(info)
        Catch ex As Exception
            MessageBox.Show("系统找不到指定的程序文件", "错误提示！")
        End Try
    End Sub

    Private Sub 关于软件ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 关于软件ToolStripMenuItem.Click
        Dim objForm As New AboutBox1
        objForm.ShowDialog()
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出ToolStripMenuItem.Click
        If MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub 制造通知单ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 制造通知单ToolStripMenuItem.Click
        Dim objForm As New frmZztzd
        objForm.MdiParent = Me
        objForm.Show()
    End Sub

    Private Sub 材料出库单ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 材料出库单ToolStripMenuItem.Click
        Dim objform As New frmOutStockQuery
        objform.MdiParent = Me
        objform.Show()
    End Sub

    Private Sub 材料入库单ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 材料入库单ToolStripMenuItem.Click
        Dim objform As New frmInStockQuery
        objform.MdiParent = Me
        objform.Show()
    End Sub

    Private Sub 成品入库单ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 成品入库单ToolStripMenuItem.Click
        Dim objForm As New frmInStock
        objForm.MdiParent = Me
        objForm.Show()
    End Sub

    Private Sub 成品出库单ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 成品出库单ToolStripMenuItem.Click
        Dim objForm As New frmOutStock
        objForm.MdiParent = Me
        objForm.Show()
    End Sub

    Private Sub 成品库存ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 成品库存ToolStripMenuItem.Click
        Dim objForm As New frmStock
        objForm.MdiParent = Me
        objForm.Show()
    End Sub

    Private Sub InpudataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InpudataToolStripMenuItem.Click
        Dim objForm As New inputdata
        objForm.MdiParent = Me
        objForm.Show()
    End Sub

    Private Sub GetDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetDataToolStripMenuItem.Click
        Dim objForm As New getData
        objForm.ShowDialog()

    End Sub

    Private Sub 材料库存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 材料库存ToolStripMenuItem.Click
        Dim objForm As New frmLjStock
        objForm.ShowDialog()
    End Sub

End Class