Imports Microsoft.Office.Interop


Public Class getData

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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

                Dim No1, No2, No3 As Object
                Dim NNo1, NNo2, NNo3 As Object
                Dim n As Long
                intTotalWeight = 0

                Dim dtmRs As DataTable = tdg_to.DataSource
                If dtmRs.Rows.Count > 0 Then
                    objExcelWorkBook = objExcelApp.Workbooks.Open(Application.StartupPath & "\excel\getdata.XLS", , True)
                    objExcelWorkSheet = objExcelWorkBook.Worksheets("sheet1")
                    objExcelApp.Visible = True
                    'objExcelWorkSheet.Range("A2").Offset(0, 0) = "���ص��ţ�" & tdg_to.CurrentRow.Cells("���ص���").Value.ToString()
                    'objExcelWorkSheet.Range("C2").Offset(0, 0) = "�ͻ����룺" & mRs!�ͻ�����
                    'objExcelWorkSheet.Range("F2").Offset(0, 0) = "�ͻ����ƣ�" & mRs!�ͻ�����
                    'objExcelWorkSheet.Range("A3").Offset(0, 0) = "�������ڣ�" & mRs!��������
                    'objExcelWorkSheet.Range("C3").Offset(0, 0) = "¼�����ڣ�" & mRs!¼������
                    'objExcelWorkSheet.Range("A2").Value = "��ⵥ�ţ�" & dtmRs.Rows(0)("��ⵥ��").ToString()
                    'objExcelWorkSheet.Range("C2").Value = "���ʱ�䣺" & dtmRs.Rows(0)("���ʱ��").ToString().Split(" ")(0)
                    'objExcelWorkSheet.Range("D2").Value = "ժҪ��" & dtmRs.Rows(0)("ժҪ").ToString()

                    n = 3
                    For Each dtRow As DataRow In dtmRs.Rows
                        'objExcelWorkSheet.Range("A5").Offset(n, 0) = dtRow("�����ͺ�").ToString
                        'objExcelWorkSheet.Range("B5").Offset(n, 0) = dtRow("�����ͺ�").ToString
                        'objExcelWorkSheet.Range("G5").Offset(n, 0) = dtRow("��������").ToString
                        'objExcelWorkSheet.Range("H5").Offset(n, 0) = dtRow("��λ").ToString

                        objExcelWorkSheet.Cells(n, 1) = dtRow("����֪ͨ����").ToString.Trim
                        objExcelWorkSheet.Cells(n, 2) = dtRow("�ܵ�����").ToString.Trim
                        objExcelWorkSheet.Cells(n, 3) = dtRow("���ϳ�������").ToString.Trim
                        objExcelWorkSheet.Cells(n, 4) = dtRow("��Ʒ�������").ToString.Trim
                        objExcelWorkSheet.Cells(n, 5) = dtRow("��Ʒ��������").ToString.Trim
                        objExcelWorkSheet.Cells(n, 6) = dtRow("����֪ͨ����������").ToString.Trim
                        objExcelWorkSheet.Cells(n, 7) = dtRow("�����س�������").ToString.Trim
                        objExcelWorkSheet.Cells(n, 8) = dtRow("�����ͺ�").ToString.Trim
                        objExcelWorkSheet.Cells(n, 9) = dtRow("�����ͺ�").ToString.Trim
                        objExcelWorkSheet.Cells(n, 10) = dtRow("��ɫ").ToString.Trim
                        objExcelWorkSheet.Cells(n, 11) = dtRow("��������").ToString.Trim
                        objExcelWorkSheet.Cells(n, 12) = dtRow("��������").ToString.Trim



                        n = n + 1
                        intSortWeight = 0
                    Next

                    'n = 4
                    'objExcelWorkSheet.Cells(n, 1) = "�����ͺ�"
                    'objExcelWorkSheet.Cells(n, 2) = "�����ͺ�"
                    'objExcelWorkSheet.Cells(n, 3) = "��ɫ"
                    'objExcelWorkSheet.Cells(n, 4) = ""
                    'objExcelWorkSheet.Cells(n, 5) = ""
                    'objExcelWorkSheet.Cells(n, 6) = ""
                    'objExcelWorkSheet.Cells(n, 7) = "����"
                    'objExcelWorkSheet.Cells(n, 8) = "��λ"


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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label3.Visible = True
        Me.Update()
        Label3.Refresh()
        Me.Cursor = Cursors.AppStarting
        Dim strError As String = ""
        Dim pdtReturn As DataTable = Nothing
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)

        'Dim strSQL As String = "select a.����֪ͨ����ϸ��id,b.����֪ͨ����,b.�ܵ�����,c.����ʱ�� as ���ϳ�������,a.������� as ��Ʒ�������,a.�������� as ��Ʒ��������,b.�������� as ����֪ͨ����������,'1900/01/01' as �����س�������,a.����֪ͨ��id,a.�����ͺ�,a.�����ͺ�,a.��ɫ,a.��������,a.��������,c.�����ʲ�� from ��������֪ͨ����ϸ�� a left join ��������֪ͨ���� b on(a.����֪ͨ��id=b.����֪ͨ��id) left join �����ϼ������ c on(b.����֪ͨ����=c.����֪ͨ����) where b.����֪ͨ����='" & txtOrderNo.Text & "'"
        Dim strSQL As String = "select a.����֪ͨ����ϸ��id,b.����֪ͨ����,b.�ܵ�����,c.����ʱ�� as ���ϳ�������,a.������� as ��Ʒ�������,a.�������� as ��Ʒ��������,b.�������� as ����֪ͨ����������,'1900/01/01' as �����س�������,a.����֪ͨ��id,a.�����ͺ�,a.�����ͺ�,a.��ɫ,a.��������,a.��������,c.�����ʲ�� from ��������֪ͨ����ϸ�� a left join ��������֪ͨ���� b on(a.����֪ͨ��id=b.����֪ͨ��id) left join �����ϼ������ c on(b.����֪ͨ����=c.����֪ͨ����) where b.����֪ͨ���� not in('13-03228-1��Ǧ','14-1038-1','14-1164','14-1293','14-03204','15-0110-1��Ǧ','15-0487','15-0520','15-0526��Ǧ����','15-0542-5V','15-05117','12-1065-5')"
        Dim strCnd As String = ""

        strCnd &= " ORDER BY c.����ʱ�� DESC"

        'pdtReturn = objData.SqlProc2("�ϼ��������ѯ", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
        pdtReturn = objData.GetDataTableBySql(strSQL & strCnd, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("��ѯ���ִ���" & strError)
        End If


        Dim dtTemp As DataTable = Nothing
        Dim dtZX As DataTable = Nothing
        Dim intRow As Integer = pdtReturn.Rows.Count
        Dim intCurr As Integer = 0
        Dim intRet As Integer = 0
        Dim intError As Integer = 0

        For Each dtRow As DataRow In pdtReturn.Rows
            dtTemp = objData.GetDataTableBySql("select ��������,����֪ͨ���� from view_OrderC left join ���ض����� on(view_OrderC.����id=���ض�����.����id) where view_OrderC.����֪ͨ����='" & dtRow("����֪ͨ����").ToString & "'", "")

            Dim strBGOrder As String = ""
            If dtTemp.Rows.Count > 0 Then

                strBGOrder = dtTemp.Rows(0)("��������").ToString
                Dim objZX As New ErpDataHelper("192.168.1.3", "uniquegrade", "sa", "")
                dtZX = objZX.GetDataTableBySql("select �������� from װ�䵥�� where ��������='" & strBGOrder & "'", "")

                If dtZX.Rows.Count > 0 AndAlso dtZX.Rows(0)("��������").ToString.Trim <> "" Then
                    dtRow("�����س�������") = dtZX.Rows(0)("��������").ToString

                End If


            End If


            Dim strIn As String = "1900/01/01"
            Dim strOut As String = "1900/01/01"
            If IsDate(dtRow("�����س�������").ToString) AndAlso DateTime.Parse(dtRow("�����س�������").ToString) > DateTime.Parse("1900/01/01") Then
                strOut = DateTime.Parse(dtRow("�����س�������").ToString).AddDays(-1)
            End If

            If DateTime.Parse(strOut) > DateTime.Parse("1900/01/01") Then
                Dim rd As New Random
                Dim i As Integer = rd.Next(1, 3)
                strIn = DateTime.Parse(strOut).AddDays(-i)
            End If

            If DateTime.Parse(strIn) >= DateTime.Parse("2015/01/01") AndAlso DateTime.Parse(strIn) <= DateTime.Parse("2015/01/01") Then
                strIn = "2015/01/02"
            End If
            If DateTime.Parse(strOut) >= DateTime.Parse("2015/01/01") AndAlso DateTime.Parse(strOut) <= DateTime.Parse("2015/01/01") Then
                strOut = "2015/01/02"
            End If

            If DateTime.Parse(strIn) >= DateTime.Parse("2015/05/01") AndAlso DateTime.Parse(strIn) <= DateTime.Parse("2015/05/03") Then
                strIn = "2015/05/04"
            End If
            If DateTime.Parse(strOut) >= DateTime.Parse("2015/05/01") AndAlso DateTime.Parse(strOut) <= DateTime.Parse("2015/05/03") Then
                strOut = "2015/05/04"
            End If

            If DateTime.Parse(strIn) >= DateTime.Parse("2015/06/20") AndAlso DateTime.Parse(strIn) <= DateTime.Parse("2015/06/22") Then
                strIn = "2015/06/23"
            End If
            If DateTime.Parse(strOut) >= DateTime.Parse("2015/06/20") AndAlso DateTime.Parse(strOut) <= DateTime.Parse("2015/06/22") Then
                strOut = "2015/06/23"
            End If


            If DateTime.Parse(strIn) >= DateTime.Parse("2015/09/03") AndAlso DateTime.Parse(strIn) <= DateTime.Parse("2015/09/05") Then
                strIn = "2015/09/06"
            End If
            If DateTime.Parse(strOut) >= DateTime.Parse("2015/09/03") AndAlso DateTime.Parse(strOut) <= DateTime.Parse("2015/09/05") Then
                strOut = "2015/09/06"
            End If


            If DateTime.Parse(dtRow("���ϳ�������").ToString) > DateTime.Parse(strIn) AndAlso DateTime.Parse(strIn) > DateTime.Parse("1900/01/01") Then
                strIn = strOut
            End If


            dtRow("��Ʒ�������") = strIn


            dtRow("��Ʒ��������") = strOut


            Dim strValue As String = dtRow("����֪ͨ����ϸ��id").ToString & ",'" & dtRow("����֪ͨ����").ToString & "','" & dtRow("�ܵ�����").ToString & "','" & strBGOrder & "','" & isD(dtRow("���ϳ�������").ToString) & "','" & isD(dtRow("��Ʒ�������").ToString) & "','" & isD(dtRow("��Ʒ��������").ToString) & "','" & isD(dtRow("����֪ͨ����������").ToString) & "','" & isD(dtRow("�����س�������").ToString) & "','" & dtRow("�����ͺ�").ToString & "','" & dtRow("�����ͺ�").ToString & "','" & dtRow("��ɫ").ToString & "','" & dtRow("��������").ToString & "','" & dtRow("��������").ToString & "'"
            Dim strInsert As String = "insert into temp_BGDetail(����֪ͨ����ϸ��id,����֪ͨ����,ҵ�񶩵���,���ض�����,���ϳ�������,��Ʒ�������,��Ʒ��������,����֪ͨ����������,�����س�������,�����ͺ�,�����ͺ�,��ɫ,��������,��������)values(" & strValue & ")"
            objData.ExcelSql(strInsert, "")

            Dim strUpdate As String = "update ��������֪ͨ����ϸ�� set �������='" & strIn & "',��������='" & strOut & "' where ����֪ͨ����ϸ��id=" & dtRow("����֪ͨ����ϸ��id").ToString
            intRet = objData.ExcelSql(strUpdate, "")
            If intRet < 0 Then
                intError += 1
            Else
                intCurr += 1
            End If

            Label3.Text = "error:" & intError.ToString & "  ok:" & intCurr.ToString & "/" & intRow.ToString
            Label3.Refresh()

            Application.DoEvents()
        Next

        Me.tdg_to.DataSource = pdtReturn
        Me.Cursor = Cursors.Default
        Label3.Visible = False
    End Sub

    Private Function isD(ByVal strValue As String) As String
        If IsDate(strValue) Then
            Return strValue
        Else
            Return "1900/01/01"
        End If
    End Function


End Class