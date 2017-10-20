Imports Microsoft.Office.Interop

Public Class frmInStock

    Public gintCls As Integer = 1   '1=�鿴������ϸ  2=�鿴���ϱ���ϵͳ��ϸ
    Public gstrOrderNo As String = ""  '������

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'DateTimePicker1.Value = Date.Parse(Now.Date.Year & "/" & Now.Date.Month & "/01")
        Me.tdg_to.AllowUserToAddRows = False  '  //Ĭ�ϲ������Լ�������
        Me.tdg_to.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tdg_to.RowHeadersVisible = False
        tdg_to.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Me.tdgDetail.AllowUserToAddRows = False  '  //Ĭ�ϲ������Լ�������
        Me.tdgDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tdgDetail.RowHeadersVisible = False
        tdgDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy/MM"

        AddHandler tdg_to.CurrentCellChanged, AddressOf gridView_SelectionChanged
    End Sub

    ''' <summary>
    ''' ȡ����Դ����
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadUniqueData()
        'lblMsg.Text = "���ڶ�ȡͬ���ѵ������ݣ����Եȣ�"

        My.WebServices.Service.Url = My.Settings.wpfurl
        Dim strCnd As String = " �ϼ�������id ='" & gstrOrderNo & "'"
        Dim pdtReturn As DataTable = Nothing
        Try

            Dim strSql As String = "select �ϼ�id,�ϼ��ͺ�,�ϼ���,��ɫ,��������,������λ2,��ע from �ϼ�������ϸ�� Where " & strCnd
            Dim dtSet As DataSet = My.WebServices.Service.GetDataTableBySql(strSql)

            Dim dtTem As DataTable = dtSet.Tables(0)
            Me.tdgDetail.DataSource = dtTem

            'lblMsg.Text = "��ȡ�ɹ�����"
        Catch ex As Exception
            'lblMsg.Text = "��ȡʧ�ܣ���"
        End Try

    End Sub


    Private Function ReplaceA(ByVal strValue As String) As String
        Return strValue.Replace("'", "''")
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadAndyData()
    End Sub

    ''' <summary>
    ''' ��ȡ�ѵ�������
    ''' </summary>
    ''' <param name="strOrder"></param>
    ''' <remarks></remarks>
    Private Sub LoadAndyData(Optional ByVal strOrder As String = "")

        Me.Update()
        Me.Cursor = Cursors.AppStarting
        Dim strError As String = ""
        Dim pdtReturn As DataTable = Nothing
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)

        Dim strSQL As String = "select ����֪ͨ����,�ͻ����� from ��������֪ͨ���� Where 1=1"
        Dim strCnd As String = ""

        If Me.txtSearch.Text.Trim <> "" Then
            strCnd &= " And (����֪ͨ���� like '%" & txtSearch.Text & "%' Or �ͻ����� like '%" & txtSearch.Text & "%')"
        End If

        Dim tianshu As Integer = DateTime.DaysInMonth(DateTimePicker2.Value.Year, DateTimePicker2.Value.Month)
        If DateTimePicker2.Checked Then
            strCnd &= " And �������� >= '" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/01'"
            strCnd &= " And �������� <= '" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/" & tianshu.ToString & "'"
        End If

        If chk_noinstock.Checked Then
            strCnd &= " And (select sum(��������-isnull(���������,0)) from ��������֪ͨ����ϸ�� where ��������֪ͨ����ϸ��.����֪ͨ��id=��������֪ͨ����.����֪ͨ��id)>0"
        End If

        If strCnd = "" Then
            MessageBox.Show("������Ҫ��ѯ��������")
            Me.Cursor = Cursors.Default
            Return
        End If
        strCnd &= " ORDER BY �������� DESC"

        'pdtReturn = objData.SqlProc2("�ϼ��������ѯ", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
        pdtReturn = objData.GetDataTableBySql(strSQL & strCnd, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("��ѯ���ִ���" & strError)
        End If
        Me.tdg_to.DataSource = pdtReturn
        If pdtReturn IsNot Nothing Then
            'Me.tdg_to.Columns(0).Visible = False

            If pdtReturn.Rows.Count <= 0 AndAlso Me.tdgDetail.DataSource IsNot Nothing Then
                Me.tdgDetail.DataSource.Rows.Clear()
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private mstrFromId As String = ""
    Private Sub gridView_SelectionChanged(ByVal sender As System.Object, ByVal e As EventArgs)

        If tdg_to.CurrentRow IsNot Nothing Then
            Dim strFromNo As String = tdg_to.CurrentRow.Cells("����֪ͨ����").Value.ToString()
            Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
            Dim strSQL As String = "select * from ��������֪ͨ���� Where ����֪ͨ����='" & strFromNo & "'"
            Dim strError As String = ""

            'pdtReturn = objData.SqlProc2("�ϼ��������ѯ", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
            Dim pdtReturn As DataTable = objData.GetDataTableBySql(strSQL, strError)
            If pdtReturn Is Nothing Then
                MessageBox.Show("��ѯ���ִ���" & strError)
                Return
            End If

            Dim strFromId As String = pdtReturn.Rows(0)("����֪ͨ��id").ToString
            lblNo.Text = pdtReturn.Rows(0)("����֪ͨ����").ToString
            lblCstNo.Text = pdtReturn.Rows(0)("�ͻ�����").ToString
            lblCstName.Text = pdtReturn.Rows(0)("�ͻ�����").ToString
            lblDate.Text = pdtReturn.Rows(0)("��������").ToString.Split(" ")(0)
            lblStockNo.Text = pdtReturn.Rows(0)("��ⵥ��").ToString

            mstrFromId = strFromId
            LoadDetail(strFromId)
        End If

    End Sub

    Private Sub LoadDetail(ByVal strFromId As String)

        Me.Update()
        Me.Cursor = Cursors.AppStarting
        Dim strError As String = ""
        Dim pdtReturn As DataTable = Nothing
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)

        Dim strSQL As String = "select ����֪ͨ����ϸ��id,����֪ͨ��id,�����ͺ�,�����ͺ�,��ɫ,��������,��λ,���������,0 As �������,��ⵥ��,Convert(varchar(10),�������,120) as �������,�ѳ������� from ��������֪ͨ����ϸ�� Where isnull(��������,0)>0 and ����֪ͨ��id=" & strFromId


        'pdtReturn = objData.SqlProc2("�ϼ��������ѯ", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
        pdtReturn = objData.GetDataTableBySql(strSQL, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("��ѯ���ִ���" & strError)
        End If
        For Each dtRow As DataRow In pdtReturn.Rows
            If dtRow("�������").ToString <> "" Then
                If DateTime.Parse(dtRow("�������").ToString) <= Date.Parse("1900/01/01") Then
                    dtRow("�������") = ""
                End If
            End If
        Next
        Me.tdgDetail.DataSource = pdtReturn
        If pdtReturn IsNot Nothing Then
            Me.tdgDetail.Columns(0).Visible = False
            Me.tdgDetail.Columns(1).Visible = False
            Me.tdgDetail.Columns(10).Visible = False

            tdgDetail.Columns(2).ReadOnly = True
            tdgDetail.Columns(2).DefaultCellStyle.BackColor = Color.Silver
            tdgDetail.Columns(3).ReadOnly = True
            tdgDetail.Columns(3).DefaultCellStyle.BackColor = Color.Silver
            tdgDetail.Columns(4).ReadOnly = True
            tdgDetail.Columns(4).DefaultCellStyle.BackColor = Color.Silver
            tdgDetail.Columns(5).ReadOnly = True
            tdgDetail.Columns(5).DefaultCellStyle.BackColor = Color.Silver
            tdgDetail.Columns(6).ReadOnly = True
            tdgDetail.Columns(6).DefaultCellStyle.BackColor = Color.Silver
            tdgDetail.Columns(7).ReadOnly = True
            tdgDetail.Columns(7).DefaultCellStyle.BackColor = Color.Silver
            tdgDetail.Columns(11).ReadOnly = True
            tdgDetail.Columns(11).DefaultCellStyle.BackColor = Color.Silver
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If MessageBox.Show("ȷ��Ҫȫ�������", "��ʾ", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        Dim intUpCount As Integer = 0
        Dim strSql As String = ""
        Dim strError As String = ""
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
        Dim dtData As DataTable = Me.tdgDetail.DataSource
        For Each dtRow As DataRow In dtData.Rows

            If Val(dtRow("���������").ToString) < Val(dtRow("��������").ToString) Then
                strSql = "Update ��������֪ͨ����ϸ�� set ��������� =��������,�������='" & DateTimePicker1.Value & "' where ����֪ͨ����ϸ��id=" & dtRow("����֪ͨ����ϸ��id").ToString
                Dim intRet As Integer = objData.ExcelSql(strSql, strError)
                If intRet < 0 Then
                    MessageBox.Show("���´���" & strError)
                Else
                    intUpCount += 1
                End If
            End If


        Next

        If intUpCount > 0 Then
            MessageBox.Show("�ɹ����£�" & intUpCount.ToString & " �����ݣ�")

            If Me.lblStockNo.Text = "" Then
                strSql = "select max(��ⵥ��) from ��������֪ͨ���� where ��ⵥ�� like '" & DateTime.Now.ToString("yyyyMMdd") & "%'"
                Dim strNo = objData.GetDataTableByField(strSql, strError)
                If strNo = "" Then
                    strNo = DateTime.Now.ToString("yyyyMMdd") & "001"
                Else
                    strNo = Val(strNo) + 1
                End If

                Me.lblStockNo.Text = strNo
                strSql = "update ��������֪ͨ���� set ��ⵥ��='" & strNo & "' Where ����֪ͨ��id=" & mstrFromId
                Dim intR As Integer = objData.ExcelSql(strSql, strError)
                If intR < 0 Then
                    MessageBox.Show("������ⵥʧ�ܣ�" & strError)
                End If
            End If

            LoadDetail(mstrFromId)
        Else
            MessageBox.Show("û���ҵ������Ĳ�Ʒ��")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim blnRef As Boolean = False
        Dim intUpCount As Integer = 0
        Dim strSql As String = ""
        Dim strError As String = ""
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
        Dim dtData As DataTable = Me.tdgDetail.DataSource
        For Each dtRow As DataRow In dtData.Rows

            Dim strUniqueNo As String = dtRow("�����ͺ�").ToString
            If Val(dtRow("���������").ToString) + Val(dtRow("�������").ToString) > Val(dtRow("��������").ToString) Then
                MessageBox.Show("�����ͺţ�" & dtRow("�����ͺ�").ToString & "  ��������� + ��������ѳ����������������޸ģ�")
                strSql = "Update ��������֪ͨ����ϸ�� set ��ⵥ��=" & Val(dtRow("��ⵥ��").ToString) & ",�������='" & DateTimePicker1.Value & "' where ����֪ͨ����ϸ��id=" & dtRow("����֪ͨ����ϸ��id").ToString
                Dim intRet As Integer = objData.ExcelSql(strSql, strError)
                blnRef = True
            ElseIf Val(dtRow("�������").ToString) > 0 Then
                strSql = "Update ��������֪ͨ����ϸ�� set ��������� =isnull(���������,0)+" & dtRow("�������").ToString & ",��ⵥ��=" & Val(dtRow("��ⵥ��").ToString) & ",�������='" & DateTimePicker1.Value & "' where ����֪ͨ����ϸ��id=" & dtRow("����֪ͨ����ϸ��id").ToString
                Dim intRet As Integer = objData.ExcelSql(strSql, strError)
                If intRet < 0 Then
                    MessageBox.Show("���´���" & strError)
                Else
                    intUpCount += 1
                End If
            End If


            objData.SetStockPrice(strUniqueNo)

        Next

        If intUpCount > 0 Then
            MessageBox.Show("�ɹ����£�" & intUpCount.ToString & " �����ݣ�")
            blnRef = True
            If Me.lblStockNo.Text = "" Then
                strSql = "select max(��ⵥ��) from ��������֪ͨ���� where ��ⵥ�� like '" & DateTime.Now.ToString("yyyyMMdd") & "%'"
                Dim strNo = objData.GetDataTableByField(strSql, strError)
                If strNo = "" Then
                    strNo = DateTime.Now.ToString("yyyyMMdd") & "001"
                Else
                    strNo = Val(strNo) + 1
                End If

                Me.lblStockNo.Text = strNo
                strSql = "update ��������֪ͨ���� set ��ⵥ��='" & strNo & "' Where ����֪ͨ��id=" & mstrFromId
                Dim intR As Integer = objData.ExcelSql(strSql, strError)
                If intR < 0 Then
                    MessageBox.Show("������ⵥʧ�ܣ�" & strError)
                End If
            End If

        End If

        If blnRef Then
            LoadDetail(mstrFromId)
        End If

    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        CmdExcel_Click()
    End Sub

    Private Sub CmdExcel_Click()
        If MsgBox("�����Ƿ���EXCEL�ļ���", vbYesNo + vbQuestion, "��ʾ") = vbYes Then  ' �û�����"��"��
            Me.Cursor = Cursors.AppStarting
            Dim intSortWeight As Single
            Dim intTotalWeight As Single
            Dim strError As String = ""
            'Dim isExportDetail As Boolean

            'If MsgBox("�Ƿ񵼳�������ϸ", vbYesNo + 32, "��ʾ") = vbYes Then
            '    isExportDetail = True
            'Else
            '    isExportDetail = False
            'End If
            Dim objExcelApp As Excel.Application        'Excel����
            Dim objExcelWorkBook As Excel.Workbook      'Excel������
            Dim objExcelWorkSheet As Excel.Worksheet    'Excel������
            '            On Error Resume Next

            Try

                objExcelApp = New Excel.Application
                If Err.Number > 0 Then
                    MsgBox("Excel ��ʼ��ʱ�������������Ӧ����ϵ��", vbExclamation)
                    Exit Sub
                End If

                Dim n As Long
                intTotalWeight = 0

                Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
                Dim dtmRs As DataTable = objData.GetDataTableBySql("select * from ��������֪ͨ���� where ����֪ͨ����='" & lblNo.Text & "'", "")
                If dtmRs.Rows.Count > 0 Then
                    objExcelWorkBook = objExcelApp.Workbooks.Open(Application.StartupPath & "\excel\���ز�����ϸ��.XLS", , True)
                    objExcelWorkSheet = objExcelWorkBook.Worksheets("sheet1")
                    objExcelApp.Visible = True
                    'objExcelWorkSheet.Range("A2").Offset(0, 0) = "����֪ͨ���ţ�" & tdg_to.CurrentRow.Cells("����֪ͨ����").Value.ToString()
                    'objExcelWorkSheet.Range("C2").Offset(0, 0) = "�ͻ����룺" & mRs!�ͻ�����
                    'objExcelWorkSheet.Range("F2").Offset(0, 0) = "�ͻ����ƣ�" & mRs!�ͻ�����
                    'objExcelWorkSheet.Range("A3").Offset(0, 0) = "�������ڣ�" & mRs!��������
                    'objExcelWorkSheet.Range("C3").Offset(0, 0) = "¼�����ڣ�" & mRs!¼������
                    objExcelWorkSheet.Range("A1").Value = "��Ʒ��ⵥ"

                    objExcelWorkSheet.Range("A2").Value = "����֪ͨ���ţ�" & dtmRs.Rows(0)("����֪ͨ����").ToString()
                    objExcelWorkSheet.Range("C2").Value = "�ͻ����룺" & dtmRs.Rows(0)("�ͻ�����").ToString()
                    objExcelWorkSheet.Range("F2").Value = "�ͻ����ƣ�" & dtmRs.Rows(0)("�ͻ�����").ToString()
                    objExcelWorkSheet.Range("A3").Value = "�������ڣ�" & dtmRs.Rows(0)("��������").ToString().Split(" ")(0)
                    objExcelWorkSheet.Range("C3").Value = "¼�����ڣ�" & dtmRs.Rows(0)("¼������").ToString().Split(" ")(0)

                    n = 4
                    objExcelWorkSheet.Cells(n, 1) = "�����ͺ�"
                    objExcelWorkSheet.Cells(n, 2) = "�����ͺ�"
                    objExcelWorkSheet.Cells(n, 3) = "��ɫ"
                    objExcelWorkSheet.Cells(n, 4) = ""
                    objExcelWorkSheet.Cells(n, 5) = "��������"
                    objExcelWorkSheet.Cells(n, 6) = "��λ"
                    objExcelWorkSheet.Cells(n, 7) = "�������"
                    objExcelWorkSheet.Cells(n, 8) = "�������"

                    n = 5
                    Dim dtDetail As DataTable = Me.tdgDetail.DataSource
                    For Each dtRow As DataRow In dtDetail.Rows
                        'objExcelWorkSheet.Range("A5").Offset(n, 0) = dtRow("�����ͺ�").ToString
                        'objExcelWorkSheet.Range("B5").Offset(n, 0) = dtRow("�����ͺ�").ToString
                        'objExcelWorkSheet.Range("G5").Offset(n, 0) = dtRow("��������").ToString
                        'objExcelWorkSheet.Range("H5").Offset(n, 0) = dtRow("��λ").ToString

                        objExcelWorkSheet.Cells(n, 1) = dtRow("�����ͺ�").ToString
                        objExcelWorkSheet.Cells(n, 2) = dtRow("�����ͺ�").ToString
                        objExcelWorkSheet.Cells(n, 3) = dtRow("��ɫ").ToString
                        objExcelWorkSheet.Cells(n, 5) = dtRow("��������").ToString
                        objExcelWorkSheet.Cells(n, 6) = dtRow("��λ").ToString
                        objExcelWorkSheet.Cells(n, 7) = dtRow("���������").ToString
                        objExcelWorkSheet.Cells(n, 8) = dtRow("�������").ToString.Split(" ")(0)


                        n = n + 1
                        intSortWeight = 0

                    Next

                    If dtDetail.Rows.Count > 0 Then
                        objExcelWorkSheet.Range("A" & n & ":H" & n).Select()
                        With objExcelWorkSheet.Range("A" & n & ":H" & n).Borders(Excel.XlBordersIndex.xlEdgeTop)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.Constants.xlAutomatic
                        End With
                    End If


                    objExcelWorkSheet = Nothing
                    objExcelWorkBook = Nothing
                    objExcelApp = Nothing
                End If
        Me.Cursor = Cursors.Default

            Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(Err.Description)
            objExcelWorkSheet = Nothing
            objExcelWorkBook = Nothing
            objExcelApp = Nothing
        End Try
        End If

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        If MessageBox.Show("ȷ��Ҫȫ���ָ���", "��ʾ", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        Dim intOutStock As Integer = 0
        Dim intUpCount As Integer = 0
        Dim strSql As String = ""
        Dim strError As String = ""
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
        Dim dtData As DataTable = Me.tdgDetail.DataSource
        For Each dtRow As DataRow In dtData.Rows

            If Val(dtRow("���������").ToString) > 0 AndAlso Val(dtRow("�ѳ�������").ToString) = 0 Then
                strSql = "Update ��������֪ͨ����ϸ�� set ��������� =0,�������='1900/01/01' where ����֪ͨ����ϸ��id=" & dtRow("����֪ͨ����ϸ��id").ToString
                Dim intRet As Integer = objData.ExcelSql(strSql, strError)
                If intRet < 0 Then
                    MessageBox.Show("���´���" & strError)
                Else
                    intUpCount += 1
                End If
            End If

            If Val(dtRow("�ѳ�������").ToString) > 0 Then
                intOutStock += 1
            End If


        Next

        If intUpCount > 0 Then

            If intOutStock > 0 Then
                MessageBox.Show("�ɹ����£�" & intUpCount.ToString & " �����ݣ������� " & intOutStock.ToString & " ���ѳ��⣡")
            Else
                MessageBox.Show("�ɹ����£�" & intUpCount.ToString & " �����ݣ�")
            End If

            If Me.lblStockNo.Text <> "" Then

                Me.lblStockNo.Text = ""
                strSql = "update ��������֪ͨ���� set ��ⵥ��='' Where ����֪ͨ��id=" & mstrFromId
                Dim intR As Integer = objData.ExcelSql(strSql, strError)
                If intR < 0 Then
                    MessageBox.Show("���»ָ���ʧ�ܣ�" & strError)
                End If
            End If

            LoadDetail(mstrFromId)
        Else

            If intOutStock > 0 Then
                MessageBox.Show("û���ҵ��ɻָ��Ĳ�Ʒ�������� " & intOutStock.ToString & " ���ѳ��⣡")
            Else
                MessageBox.Show("û���ҵ��ɻָ��Ĳ�Ʒ��")
            End If
        End If
    End Sub
End Class
