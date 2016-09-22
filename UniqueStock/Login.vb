Imports System.Configuration

Public Class Login

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If Now.ToString("yyyy/MM/dd") >= Date.Parse("2011/12/01") Then
        '  MessageBox.Show("��ʼ������2011/12/01�����뿪����Ա��ϵ����")
        '  Exit Sub
        'End If

        Dim strError As String = ""
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
        If objData.InitialConnection(strError) < 0 Then
            MessageBox.Show("����ʧ�ܣ�" & strError)
            Exit Sub
        End If

        Dim strSql As String = "select * from Ȩ�ޱ� where ��¼��='" & txtUser.Text & "' And ����='" & txtPw.Text & "'"
        Dim dtData As DataTable = objData.GetDataTableBySql(strSql, "")
        If dtData.Rows.Count <= 0 Then
            MessageBox.Show("�û��������ڻ�����������������Ա��ϵ��")
            Exit Sub
        End If

        My.Settings.wpfurl = txtUser.Text
        My.Settings.Save()

        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        My.Settings.server = ConfigurationManager.AppSettings("server").ToString()
        My.Settings.datasource = ConfigurationManager.AppSettings("datasource").ToString()
        My.Settings.sa = ConfigurationManager.AppSettings("sa").ToString()
        My.Settings.pw = ConfigurationManager.AppSettings("pw").ToString()
        My.Settings.Save()

        txtUser.Items.Add("Admin")

        Dim strError As String = ""
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
        If objData.InitialConnection(strError) < 0 Then
            MessageBox.Show("����ʧ�ܣ�" & strError)
            Exit Sub
        End If

        Dim strSql As String = "select ��¼�� from Ȩ�ޱ� where ��¼��<>'Admin'"
        Dim dtData As DataTable = objData.GetDataTableBySql(strSql, "")
        For Each dtRow As DataRow In dtData.Rows
            txtUser.Items.Add(dtRow("��¼��").ToString())
        Next

        If My.Settings.wpfurl <> "" Then
            txtUser.Text = My.Settings.wpfurl
        Else
            txtUser.Text = "Admin"
        End If

    End Sub


End Class
