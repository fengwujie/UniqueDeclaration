Imports System.Configuration

Public Class Login

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If Now.ToString("yyyy/MM/dd") >= Date.Parse("2011/12/01") Then
        '  MessageBox.Show("初始化错误：2011/12/01，请与开发人员联系。。")
        '  Exit Sub
        'End If

        Dim strError As String = ""
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
        If objData.InitialConnection(strError) < 0 Then
            MessageBox.Show("连接失败：" & strError)
            Exit Sub
        End If

        Dim strSql As String = "select * from 权限表 where 登录名='" & txtUser.Text & "' And 密码='" & txtPw.Text & "'"
        Dim dtData As DataTable = objData.GetDataTableBySql(strSql, "")
        If dtData.Rows.Count <= 0 Then
            MessageBox.Show("用户名不存在或密码错误，请与管理人员联系！")
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
            MessageBox.Show("连接失败：" & strError)
            Exit Sub
        End If

        Dim strSql As String = "select 登录名 from 权限表 where 登录名<>'Admin'"
        Dim dtData As DataTable = objData.GetDataTableBySql(strSql, "")
        For Each dtRow As DataRow In dtData.Rows
            txtUser.Items.Add(dtRow("登录名").ToString())
        Next

        If My.Settings.wpfurl <> "" Then
            txtUser.Text = My.Settings.wpfurl
        Else
            txtUser.Text = "Admin"
        End If

    End Sub


End Class
