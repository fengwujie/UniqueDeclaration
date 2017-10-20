Imports Microsoft.Office.Interop

Public Class frmLjStock

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'DateTimePicker1.Value = Date.Parse(Now.Date.Year & "/" & Now.Date.Month & "/01")
        'Me.tdg_to.AllowUserToAddRows = False  '  //Ĭ�ϲ������Լ�������
        'Me.tdg_to.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        'Me.tdg_to.RowHeadersVisible = False
        'tdg_to.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Me.tdgDetail.AllowUserToAddRows = False  '  //Ĭ�ϲ������Լ�������
        Me.tdgDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tdgDetail.RowHeadersVisible = False
        tdgDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        'AddHandler tdg_to.CurrentCellChanged, AddressOf gridView_SelectionChanged

        'LoadAndyData()
    End Sub



    Private Function ReplaceA(ByVal strValue As String) As String
        Return strValue.Replace("'", "''")
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Function GetSql(ByVal dtData As DataTable, ByVal tabname As String, ByVal strField As String) As String
        Dim str2 As String = ""
        Dim left As String = ""
        Dim strArray As String() = strField.Split(New Char() {","c})
        Dim num3 As Integer = (dtData.Rows.Count - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            left = ""
            Dim num4 As Integer = (strArray.Length - 1)
            Dim j As Integer = 0
            Do While (j <= num4)
                left &= IIf(left = "", "", ",") & Me.GetOleDataType(dtData.Columns.Item(strArray(j)).DataType.FullName, dtData.Rows.Item(i).Item(strArray(j)).ToString)
                j += 1
            Loop
            str2 = String.Concat(New String() {str2, " Insert into ", tabname, "(", strField, ")values(", left, ")"})
            i += 1
        Loop
        Return str2
    End Function

    Private Function GetOleDataType(ByVal strNetDataType As String, ByVal strValue As String) As String
        Dim str As String = strValue
        Select Case strNetDataType
            Case "System.String"
                Return ("'" & strValue.Replace(",", "''") & "'")
            Case "System.DateTime"
                If (strValue = "") Then
                    strValue = "1900/01/01"
                End If
                Return ("'" & strValue & "'")
            Case "System.Boolean"
                If ((strValue = "") OrElse Not Convert.ToBoolean(strValue)) Then
                    Return 0
                End If
                Return 1
            Case "System.DBNull"
                Return strValue
            Case "System.SByte"
                Return strValue
            Case "System.Int16", "System.Int32", "System.Int64", "System.Double", "System.Single", "System.Decimal"
                If (strValue = "") Then
                    strValue = "NULL"
                End If
                Return strValue
            Case "System.Array"
                Return strValue
            Case "System.Byte[]"
                Return strValue
            Case "System.Object"
                str = strValue
                Exit Select
        End Select
        Return str
    End Function

    Private Sub txtToNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            LoadDetail()
        End If
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        LoadDetail()
    End Sub


    Private Sub LoadDetail()

        Label3.Visible = True
        Me.Update()
        Label3.Refresh()
        Me.Cursor = Cursors.AppStarting
        Dim strError As String = ""
        Dim pdtReturn As DataTable = Nothing
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)

        'Dim strPrice As String = ",(select top 1 stockprice from uniquestockprice where �����ͺ�=uniqueno order by setdate desc) as ���ɱ�"

        Dim strWhere As String = "�ϼ����<>''"
        If txtNo.Text.Trim <> "" Then
            strWhere &= " And �ϼ���� like '%" & txtNo.Text & "%'"
        End If
        If txtDetailNo.Text.Trim <> "" Then
            strWhere &= " And ��Ʒ���� like '%" & txtDetailNo.Text & "%'"
        End If
        If txtName.Text.Trim <> "" Then
            strWhere &= " And ��Ʒ���� like '%" & txtName.Text & "%'"
        End If

        'Select Case Top 10 * from view_LjInstock where  �ϼ����='STF-030'
        'Select Case Top 10 * from view_LjOutstock where  �ϼ����='STF-030'
        'Select Case �ϼ����,�ϼ���,�Ϻ�,��Ʒ����,��Ʒ����,��Ʒ���,���� As ��ⵥ��,round(sum(����),2) As ���,(Select sum(��������) from view_LjOutstock b where b.�ϼ����=a.�ϼ���� And b.�Ϻ�=a.�Ϻ� And b.��Ʒ����=a.��Ʒ���� And b.��Ʒ���=b.��Ʒ���) As �������� From view_LjInstock a  Where �ϼ���� ='STF-030'  group by �ϼ����,�ϼ���,�Ϻ�,��Ʒ����,��Ʒ����,��Ʒ���,����

        Dim strSQL As String = "select �ϼ����,�ϼ���,�Ϻ�,��Ʒ����,��Ʒ����,��Ʒ���,���� as ��ⵥ��,round(sum(����),2) as ����� from view_LjInstock  where  " & strWhere & "  group by �ϼ����,�ϼ���,�Ϻ�,��Ʒ����,��Ʒ����,��Ʒ���,���� "
        pdtReturn = objData.GetDataTableBySql(strSQL, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("��ѯ���ִ���" & strError)
        End If
        Me.tdgDetail.DataSource = pdtReturn
        If pdtReturn IsNot Nothing Then
            'Me.tdgDetail.Columns(0).Visible = False
            'Me.tdgDetail.Columns(1).Visible = False
            'Me.tdgDetail.Columns(2).Visible = False
        End If
        Me.Cursor = Cursors.Default
        Label3.Visible = False
    End Sub


    Public Function daochu(ByVal x As DataGridView) As Boolean '������Excel����
        Try
            If x.Rows.Count <= 0 Then '�жϼ�¼��,���û�м�¼���˳�
                MessageBox.Show("û�м�¼���Ե���", "û�п��Ե�������Ŀ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else '����м�¼�͵�����Excel
                Dim xx As Object : Dim yy As Object
                xx = CreateObject("Excel.Application") '����Excel����
                yy = xx.workbooks.add()
                Dim i As Integer, u As Integer = 0, v As Integer = 0 '����ѭ������,���б���
                For i = 1 To x.Columns.Count '�ѱ�ͷд��Excel
                    yy.worksheets(1).cells(1, i) = x.Columns(i - 1).HeaderCell.Value
                Next
                Dim str(x.Rows.Count - 1, x.Columns.Count - 1) '����һ����ά����
                For u = 1 To x.Rows.Count '��ѭ��
                    For v = 1 To x.Columns.Count '��ѭ��
                        If x.Item(v - 1, u - 1).Value.GetType.ToString <> "System.Guid" Then
                            str(u - 1, v - 1) = x.Item(v - 1, u - 1).Value
                        Else
                            str(u - 1, v - 1) = x.Item(v - 1, u - 1).Value.ToString
                        End If
                    Next
                Next
                yy.worksheets(1).range("A2").Resize(x.Rows.Count, x.Columns.Count).Value = str '������һ��д��Excel
                yy.worksheets(1).Cells.EntireColumn.AutoFit() '�Զ�����Excel��
                ' yy.worksheets(1).name = x.TopLeftHeaderCell.Value.ToString '�����д����ΪExcel����������
                xx.visible = True '����Excel�ɼ�
                yy = Nothing '�����齨�ͷ���Դ
                xx = Nothing '�����齨�ͷ���Դ
            End If
            Return True
        Catch ex As Exception '������
            MessageBox.Show(Err.Description.ToString, "����", MessageBoxButtons.OK, MessageBoxIcon.Error) '������ʾ
            Return False
        End Try
    End Function


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
                    objExcelWorkSheet.Range("A1").Value = "��Ʒ��浥"

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
                    objExcelWorkSheet.Cells(n, 5) = ""
                    objExcelWorkSheet.Cells(n, 6) = "��������"
                    objExcelWorkSheet.Cells(n, 7) = "�������"
                    objExcelWorkSheet.Cells(n, 8) = "��λ"

                    n = 5
                    Dim dtDetail As DataTable = Me.tdgDetail.DataSource
                    For Each dtRow As DataRow In dtDetail.Rows
                        'objExcelWorkSheet.Range("A5").Offset(n, 0) = dtRow("�����ͺ�").ToString
                        'objExcelWorkSheet.Range("B5").Offset(n, 0) = dtRow("�����ͺ�").ToString
                        'objExcelWorkSheet.Range("G5").Offset(n, 0) = dtRow("��������").ToString
                        'objExcelWorkSheet.Range("H5").Offset(n, 0) = dtRow("��λ").ToString

                        '�����ͺ�,�����ͺ�,��ɫ,��������,���������-isnull(�ѳ�������) As �������,��λ

                        objExcelWorkSheet.Cells(n, 1) = dtRow("�����ͺ�").ToString
                        objExcelWorkSheet.Cells(n, 2) = dtRow("�����ͺ�").ToString
                        objExcelWorkSheet.Cells(n, 3) = dtRow("��ɫ").ToString
                        objExcelWorkSheet.Cells(n, 4) = ""
                        objExcelWorkSheet.Cells(n, 5) = ""
                        objExcelWorkSheet.Cells(n, 6) = dtRow("��������").ToString
                        objExcelWorkSheet.Cells(n, 7) = dtRow("�������").ToString
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

End Class
