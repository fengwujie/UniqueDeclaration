Imports Microsoft.Office.Interop

Public Class frmOutStockQuery

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

        AddHandler tdg_to.CurrentCellChanged, AddressOf gridView_SelectionChanged

        'LoadAndyData()
    End Sub


    ''' <summary>
    ''' ��ȡ�ѵ�������
    ''' </summary>
    ''' <param name="strOrder"></param>
    ''' <remarks></remarks>
    Private Sub LoadAndyData(Optional ByVal strOrder As String = "")

        Label3.Visible = True
        Me.Update()
        Label3.Refresh()
        Me.Cursor = Cursors.AppStarting
        Dim strError As String = ""
        Dim pdtReturn As DataTable = Nothing
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)

        Dim strSQL As String = "select �ϼ������id,���ⵥ��,����֪ͨ����,Convert(varchar(10),����ʱ��,120) as ��������,ժҪ,�����ʲ��,¼��Ա,���ʱ�־ from �����ϼ������ Where 1=1"
        Dim strCnd As String = ""

        If txtNo.Text.Trim <> "" Then
            strCnd &= " And ���ⵥ�� like '%" & txtNo.Text & "%'"
        End If
        If txtCstNo.Text.Trim <> "" Then
            strCnd &= " And ����֪ͨ���� like '%" & txtCstNo.Text & "%'"
        End If
        If DateTimePicker1.Checked Then
            strCnd &= " And ����ʱ�� >= '" & DateTimePicker1.Value.ToShortDateString & "'"
        End If
        If DateTimePicker2.Checked Then
            strCnd &= " And ����ʱ�� <= '" & DateTimePicker2.Value.ToShortDateString & "'"
        End If

        If strCnd = "" Then
            MessageBox.Show("������Ҫ��ѯ��������")
            Me.Cursor = Cursors.Default
            Label3.Visible = False
            Return
        End If
        strCnd &= " ORDER BY ����ʱ�� DESC"

        'pdtReturn = objData.SqlProc2("�ϼ��������ѯ", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
        pdtReturn = objData.GetDataTableBySql(strSQL & strCnd, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("��ѯ���ִ���" & strError)
        End If
        Me.tdg_to.DataSource = pdtReturn
        If pdtReturn IsNot Nothing Then
            Me.tdg_to.Columns(0).Visible = False
            If pdtReturn.Rows.Count <= 0 AndAlso Me.tdgDetail.DataSource IsNot Nothing Then
                Me.tdgDetail.DataSource.Rows.Clear()
            End If
        End If
        Me.Cursor = Cursors.Default
        Label3.Visible = False
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
            LoadAndyData()
        End If
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        LoadAndyData()
    End Sub

    Private Sub gridView_SelectionChanged(ByVal sender As System.Object, ByVal e As EventArgs)

        If tdg_to.CurrentRow IsNot Nothing Then
            Dim strFromId As String = tdg_to.CurrentRow.Cells("�ϼ������id").Value.ToString()
            lblShowNo.Text = tdg_to.CurrentRow.Cells("���ⵥ��").Value.ToString()
            lblShowNo2.Text = tdg_to.CurrentRow.Cells("�����ʲ��").Value.ToString()

            LoadDetail(strFromId)
        End If

    End Sub

    Private Sub LoadDetail(ByVal strFromId As String)

        Label3.Visible = True
        Me.Update()
        Label3.Refresh()
        Me.Cursor = Cursors.AppStarting
        Dim strError As String = ""
        Dim pdtReturn As DataTable = Nothing
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)

        pdtReturn = objData.SqlProc3("�����ϼ������޸Ĳ�ѯ", strFromId, lblShowNo2.Text, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("��ѯ���ִ���" & strError)
        End If

        Dim dtSave As DataTable = pdtReturn.Clone
        For Each dtRow As DataRow In pdtReturn.Rows
            If Val(dtRow("��������").ToString.Trim) > 0 AndAlso dtRow("�Ϻ�").ToString.Trim <> "" AndAlso dtRow("�Ϻ�").ToString.Substring(0, 1) = "A" Then
                dtSave.ImportRow(dtRow)
            End If
        Next

        Me.tdgDetail.DataSource = dtSave
        If pdtReturn IsNot Nothing Then
            Me.tdgDetail.Columns(0).Visible = False
            Me.tdgDetail.Columns(1).Visible = False
            Me.tdgDetail.Columns(2).Visible = False
            Me.tdgDetail.Columns(11).Visible = False
            Me.tdgDetail.Columns(12).Visible = False
        End If
        Me.Cursor = Cursors.Default
        Label3.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'daochu(tdg_to)
        CmdExcel_Click()
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

                Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
                Dim dtmRs As DataTable = objData.GetDataTableBySql("select * from �����ϼ������ where ���ⵥ��='" & lblShowNo.Text & "'", "")
                If dtmRs.Rows.Count > 0 Then
                    objExcelWorkBook = objExcelApp.Workbooks.Open(Application.StartupPath & "\excel\���ϳ��ⵥ.XLS", , True)
                    objExcelWorkSheet = objExcelWorkBook.Worksheets("sheet1")
                    objExcelApp.Visible = True
                    'objExcelWorkSheet.Range("A2").Offset(0, 0) = "����֪ͨ���ţ�" & tdg_to.CurrentRow.Cells("����֪ͨ����").Value.ToString()
                    'objExcelWorkSheet.Range("C2").Offset(0, 0) = "�ͻ����룺" & mRs!�ͻ�����
                    'objExcelWorkSheet.Range("F2").Offset(0, 0) = "�ͻ����ƣ�" & mRs!�ͻ�����
                    'objExcelWorkSheet.Range("A3").Offset(0, 0) = "�������ڣ�" & mRs!��������
                    'objExcelWorkSheet.Range("C3").Offset(0, 0) = "¼�����ڣ�" & mRs!¼������
                    objExcelWorkSheet.Range("A2").Value = "���ⵥ�ţ�" & dtmRs.Rows(0)("���ⵥ��").ToString()
                    objExcelWorkSheet.Range("C2").Value = "�����ţ�" & dtmRs.Rows(0)("����֪ͨ����").ToString()
                    objExcelWorkSheet.Range("D2").Value = "����ʱ�䣺" & dtmRs.Rows(0)("����ʱ��").ToString().Split(" ")(0)
                    objExcelWorkSheet.Range("A3").Value = "ժ    Ҫ��" & dtmRs.Rows(0)("ժҪ").ToString()

                    'n = 4
                    'objExcelWorkSheet.Cells(n, 1) = "�����ͺ�"
                    'objExcelWorkSheet.Cells(n, 2) = "�����ͺ�"
                    'objExcelWorkSheet.Cells(n, 3) = "��ɫ"
                    'objExcelWorkSheet.Cells(n, 4) = ""
                    'objExcelWorkSheet.Cells(n, 5) = ""
                    'objExcelWorkSheet.Cells(n, 6) = ""
                    'objExcelWorkSheet.Cells(n, 7) = "����"
                    'objExcelWorkSheet.Cells(n, 8) = "��λ"

                    n = 5
                    Dim dtDetail As DataTable = Me.tdgDetail.DataSource
                    For Each dtRow As DataRow In dtDetail.Rows
                        'objExcelWorkSheet.Range("A5").Offset(n, 0) = dtRow("�����ͺ�").ToString
                        'objExcelWorkSheet.Range("B5").Offset(n, 0) = dtRow("�����ͺ�").ToString
                        'objExcelWorkSheet.Range("G5").Offset(n, 0) = dtRow("��������").ToString
                        'objExcelWorkSheet.Range("H5").Offset(n, 0) = dtRow("��λ").ToString

                        objExcelWorkSheet.Cells(n, 1) = dtRow("�ϼ����").ToString.Trim
                        objExcelWorkSheet.Cells(n, 2) = dtRow("�Ϻ�").ToString.Trim
                        objExcelWorkSheet.Cells(n, 3) = dtRow("�ϼ���").ToString.Trim
                        objExcelWorkSheet.Cells(n, 4) = dtRow("��������").ToString.Trim
                        objExcelWorkSheet.Cells(n, 5) = dtRow("��λ").ToString.Trim
                        objExcelWorkSheet.Cells(n, 6) = dtRow("��ע").ToString.Trim


                        n = n + 1
                        intSortWeight = 0
                    Next

                    If dtDetail.Rows.Count > 0 Then
                        objExcelWorkSheet.Range("A" & n & ":F" & n).Select()
                        With objExcelWorkSheet.Range("A" & n & ":F" & n).Borders(Excel.XlBordersIndex.xlEdgeTop)
                            .LineStyle = Excel.XlLineStyle.xlDot
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.Constants.xlAutomatic
                        End With

                        n = n + 1
                        objExcelWorkSheet.Cells(n, 1) = "�γ���            �鳤��               �����ˣ�               ¼��Ա��"
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
