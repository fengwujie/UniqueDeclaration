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


    Private Sub ������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ������ToolStripMenuItem.Click
        Dim info As New System.Diagnostics.ProcessStartInfo()
        Dim proc As New System.Diagnostics.Process()

        '//�����ⲿ������(���±��� notepad.exe �������� calc.exe) 
        info.FileName = "calc.exe"

        '//�����ⲿ�������������

        info.Arguments = ""

        '//�����ⲿ������Ŀ¼Ϊc:\windows

        info.WorkingDirectory = "c:/windows/"

        Try


            '// 
            '//�����ⲿ���� 
            '// 
            proc = System.Diagnostics.Process.Start(info)
        Catch ex As Exception
            MessageBox.Show("ϵͳ�Ҳ���ָ���ĳ����ļ�", "������ʾ��")
        End Try
    End Sub

    Private Sub �������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �������ToolStripMenuItem.Click
        Dim objForm As New AboutBox1
        objForm.ShowDialog()
    End Sub

    Private Sub �˳�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �˳�ToolStripMenuItem.Click
        If MessageBox.Show("ȷ��Ҫ�˳���", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub ����֪ͨ��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����֪ͨ��ToolStripMenuItem.Click
        Dim objForm As New frmZztzd
        objForm.MdiParent = Me
        objForm.Show()
    End Sub

    Private Sub ���ϳ��ⵥToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���ϳ��ⵥToolStripMenuItem.Click
        Dim objform As New frmOutStockQuery
        objform.MdiParent = Me
        objform.Show()
    End Sub

    Private Sub ������ⵥToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ������ⵥToolStripMenuItem.Click
        Dim objform As New frmInStockQuery
        objform.MdiParent = Me
        objform.Show()
    End Sub

    Private Sub ��Ʒ��ⵥToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��Ʒ��ⵥToolStripMenuItem.Click
        Dim objForm As New frmInStock
        objForm.MdiParent = Me
        objForm.Show()
    End Sub

    Private Sub ��Ʒ���ⵥToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��Ʒ���ⵥToolStripMenuItem.Click
        Dim objForm As New frmOutStock
        objForm.MdiParent = Me
        objForm.Show()
    End Sub

    Private Sub ��Ʒ���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��Ʒ���ToolStripMenuItem.Click
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

    Private Sub ���Ͽ��ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ���Ͽ��ToolStripMenuItem.Click
        Dim objForm As New frmLjStock
        objForm.ShowDialog()
    End Sub

End Class