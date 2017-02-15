Imports Microsoft.Office.Interop

Public Class inputdata

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim intOk As Integer = 0
        Dim intError As Integer = 0
        Dim strError As String = ""
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
        Dim strSQL As String = "select ����֪ͨ��id,����֪ͨ����,��������,�ͻ����� from ��������֪ͨ���� Where ��������<='2015/07/31'"
        Dim pdtReturn As DataTable = objData.GetDataTableBySql(strSQL, strError)

        For Each dtRow As DataRow In pdtReturn.Rows

            Dim strFromId As String = dtRow("����֪ͨ��id").ToString

            Dim dtT As DateTime = DateTime.Parse(dtRow("��������").ToString).AddDays(-3)

            Dim strSQL2 As String = "Update ��������֪ͨ����ϸ�� set ���������=��������,�������='" & dtT.ToString & "'  where ����֪ͨ��id=" & strFromId
            Dim intRet As Integer = objData.ExcelSql(strSQL2, strError)
            If intRet < 0 Then
                intError += 1
            Else
                intOk += 1
            End If


            Dim dtO As DateTime = DateTime.Parse(dtRow("��������").ToString).AddDays(-1)
            strSQL2 = "Update ��������֪ͨ����ϸ�� set �ѳ�������=isnull(���������,0),��������='" & dtO.ToString & "'  where ����֪ͨ��id=" & strFromId
            intRet = objData.ExcelSql(strSQL2, strError)
            If intRet < 0 Then
                intError += 1
            Else
                intOk += 1
            End If



            lblOk.Text = intOk.ToString
            lblOk.Refresh()

            lblError.Text = intError.ToString
            lblError.Refresh()
            Application.DoEvents()

        Next


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Cursor = Cursors.AppStarting
        Dim strError As String = ""
        Dim pdtReturn As DataTable = Nothing
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)

        Dim strSQL As String = "select * from ��������֪ͨ���� Where 1=1"
        Dim strCnd As String = ""

        If DateTimePicker1.Checked Then
            strCnd &= " And �������� >= '" & DateTimePicker1.Value.ToShortDateString & "'"
        End If
        If DateTimePicker2.Checked Then
            strCnd &= " And �������� <= '" & DateTimePicker2.Value.ToShortDateString & "'"
        End If

        If strCnd = "" Then
            MessageBox.Show("������Ҫ��ѯ��������")
            Me.Cursor = Cursors.Default
            Label3.Visible = False
            Return
        End If

        'pdtReturn = objData.SqlProc2("�ϼ��������ѯ", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
        pdtReturn = objData.GetDataTableBySql(strSQL & strCnd, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("��ѯ���ִ���" & strError)
        End If

        If pdtReturn IsNot Nothing Then

            Dim intOk As Integer = 0
            Dim intError As Integer = 0

            Dim intCount As Integer = pdtReturn.Rows.Count



            For Each dtRow As DataRow In pdtReturn.Rows

                Dim intRet As Integer = CmdOrderExcel_Click(dtRow("����֪ͨ����").ToString)
                If intRet = 1 Then
                    intOk += 1
                Else
                    intError += 1
                End If


                lblOk.Text = intOk.ToString & "/" & intCount.ToString
                lblOk.Refresh()

                lblError.Text = intError.ToString
                lblError.Refresh()
                Application.DoEvents()

            Next

        End If

        MessageBox.Show("������ɣ�")
        Me.Cursor = Cursors.Default

    End Sub


    Private Function CmdOrderExcel_Click(ByVal strNo As String) As Integer
        Dim intRet As Integer = 0

        'If MsgBox("�����Ƿ���EXCEL�ļ���", vbYesNo + vbQuestion, "��ʾ") = vbYes Then  ' �û�����"��"��
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
                Exit Function
            End If

            Dim n As Long
            intTotalWeight = 0

            Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
            Dim dtmRs As DataTable = objData.GetDataTableBySql("select * from ��������֪ͨ���� where ����֪ͨ����='" & strNo & "'", "")
            If dtmRs.Rows.Count > 0 Then
                objExcelWorkBook = objExcelApp.Workbooks.Open(Application.StartupPath & "\excel\���ز�����ϸ��.XLS", , True)
                objExcelWorkSheet = objExcelWorkBook.Worksheets("sheet1")
                objExcelApp.Visible = True
                'objExcelWorkSheet.Range("A2").Offset(0, 0) = "����֪ͨ���ţ�" & tdg_to.CurrentRow.Cells("����֪ͨ����").Value.ToString()
                'objExcelWorkSheet.Range("C2").Offset(0, 0) = "�ͻ����룺" & mRs!�ͻ�����
                'objExcelWorkSheet.Range("F2").Offset(0, 0) = "�ͻ����ƣ�" & mRs!�ͻ�����
                'objExcelWorkSheet.Range("A3").Offset(0, 0) = "�������ڣ�" & mRs!��������
                'objExcelWorkSheet.Range("C3").Offset(0, 0) = "¼�����ڣ�" & mRs!¼������
                objExcelWorkSheet.Range("A1").Value = "ORDER"

                objExcelWorkSheet.Range("A2").Value = "�����ţ�" & dtmRs.Rows(0)("����֪ͨ����").ToString()
                objExcelWorkSheet.Range("C2").Value = "�ͻ����룺" & dtmRs.Rows(0)("�ͻ�����").ToString()
                objExcelWorkSheet.Range("F2").Value = "�ͻ����ƣ�" & dtmRs.Rows(0)("�ͻ�����").ToString()
                objExcelWorkSheet.Range("A3").Value = "�������ڣ�" & dtmRs.Rows(0)("��������").ToString().Split(" ")(0)
                objExcelWorkSheet.Range("C3").Value = ""

                n = 4
                objExcelWorkSheet.Cells(n, 1) = "�����ͺ�"
                objExcelWorkSheet.Cells(n, 2) = "�����ͺ�"
                objExcelWorkSheet.Cells(n, 3) = "��ɫ"
                objExcelWorkSheet.Cells(n, 4) = ""
                objExcelWorkSheet.Cells(n, 5) = ""
                objExcelWorkSheet.Cells(n, 6) = ""
                objExcelWorkSheet.Cells(n, 7) = "����"
                objExcelWorkSheet.Cells(n, 8) = "��λ"

                n = 5

                Dim strSQL As String = "select * from ��������֪ͨ����ϸ�� Where isnull(��������,0)>0 and ����֪ͨ��id=" & dtmRs.Rows(0)("����֪ͨ��id").ToString()

                Dim dtDetail As DataTable = objData.GetDataTableBySql(strSQL, strError)
                If dtDetail Is Nothing Then
                    Return intRet
                End If

                For Each dtRow As DataRow In dtDetail.Rows
                    'objExcelWorkSheet.Range("A5").Offset(n, 0) = dtRow("�����ͺ�").ToString
                    'objExcelWorkSheet.Range("B5").Offset(n, 0) = dtRow("�����ͺ�").ToString
                    'objExcelWorkSheet.Range("G5").Offset(n, 0) = dtRow("��������").ToString
                    'objExcelWorkSheet.Range("H5").Offset(n, 0) = dtRow("��λ").ToString

                    objExcelWorkSheet.Cells(n, 1) = dtRow("�����ͺ�").ToString
                    objExcelWorkSheet.Cells(n, 2) = dtRow("�����ͺ�").ToString
                    objExcelWorkSheet.Cells(n, 3) = dtRow("��ɫ").ToString
                    objExcelWorkSheet.Cells(n, 7) = dtRow("��������").ToString
                    objExcelWorkSheet.Cells(n, 8) = dtRow("��λ").ToString

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

                Dim strPath As String = "D:\Temp\"
                Dim dtOut As DateTime = DateTime.Parse(dtmRs.Rows(0)("��������").ToString())
                strPath = strPath & dtOut.Year.ToString & "_" & dtOut.Month.ToString & "\"

                If System.IO.Directory.Exists(strPath) = False Then
                    System.IO.Directory.CreateDirectory(strPath)
                End If

                strPath = strPath & dtmRs.Rows(0)("����֪ͨ����").ToString().Split("��")(0)
                objExcelWorkBook.SaveAs(strPath & ".XLS")
                intRet = 1

                objExcelWorkSheet = Nothing
                objExcelWorkBook = Nothing
                objExcelApp.Quit()
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

        Return intRet
        'End If

    End Function

End Class