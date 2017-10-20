Imports Microsoft.Office.Interop

Public Class frmStock

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'DateTimePicker1.Value = Date.Parse(Now.Date.Year & "/" & Now.Date.Month & "/01")
        Me.tdg_to.AllowUserToAddRows = False  '  //默认不允许自己新增行
        Me.tdg_to.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tdg_to.RowHeadersVisible = False
        tdg_to.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Me.tdgDetail.AllowUserToAddRows = False  '  //默认不允许自己新增行
        Me.tdgDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tdgDetail.RowHeadersVisible = False
        tdgDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        AddHandler tdg_to.CurrentCellChanged, AddressOf gridView_SelectionChanged

        'LoadAndyData()
    End Sub


    ''' <summary>
    ''' 读取已导的数据
    ''' </summary>
    ''' <param name="strOrder"></param>
    ''' <remarks></remarks>
    Private Sub LoadAndyData(Optional ByVal strOrder As String = "")

        Me.Update()
        Me.Cursor = Cursors.AppStarting
        Dim strError As String = ""
        Dim pdtReturn As DataTable = Nothing
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)

        Dim strSQL As String = "select * from 报关制造通知单表 Where 1=1"
        Dim strCnd As String = ""

        If Me.txtNo.Text.Trim <> "" Then
            strCnd &= " And (制造通知单号 like '%" & txtNo.Text & "%')"
        End If

        If DateTimePicker2.Checked Then
            strCnd &= " And 出货日期 >= '" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/01'"
            strCnd &= " And 出货日期 <= '" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/31'"
        End If

        Dim strTmpCnd As String = ""
        If txtDetailNo.Text.Trim <> "" Then
            strTmpCnd = "(报关制造通知单明细表.客人型号 like '%" & txtDetailNo.Text & "%' Or 报关制造通知单明细表.优丽型号 like '%" & txtDetailNo.Text & "%') And "
        End If
        strCnd &= " And (select sum(isnull(已入库数量,0)-isnull(已出库数量,0)) from 报关制造通知单明细表 where " & strTmpCnd & " 报关制造通知单明细表.制造通知单id=报关制造通知单表.制造通知单id)>0"

        If strCnd = "" Then
            MessageBox.Show("请输入要查询的条件！")
            Me.Cursor = Cursors.Default
            Return
        End If
        strCnd &= " ORDER BY 出货日期 DESC"

        'pdtReturn = objData.SqlProc2("料件进销存查询", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
        pdtReturn = objData.GetDataTableBySql(strSQL & strCnd, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("查询出现错误：" & strError)
        End If
        Me.tdg_to.DataSource = pdtReturn
        If pdtReturn IsNot Nothing Then
            Me.tdg_to.Columns(0).Visible = False

            If pdtReturn.Rows.Count <= 0 AndAlso Me.tdgDetail.DataSource IsNot Nothing Then
                Me.tdgDetail.DataSource.Rows.Clear()
            End If
        End If
        Me.Cursor = Cursors.Default
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
            Dim strFromId As String = tdg_to.CurrentRow.Cells("制造通知单id").Value.ToString()
            lblNo.Text = tdg_to.CurrentRow.Cells("制造通知单号").Value.ToString()
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

        'Dim strPrice As String = ",(select top 1 stockprice from uniquestockprice where 优丽型号=uniqueno order by setdate desc) as 库存成本"
        Dim strSQL As String = "select 制造通知单明细表id,制造通知单id,客人型号,优丽型号,颜色,订单数量,已入库数量-isnull(已出库数量,0) As 库存数量,库存成本,单位 from 报关制造通知单明细表 Where 制造通知单id=" & strFromId
        pdtReturn = objData.GetDataTableBySql(strSQL, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("查询出现错误：" & strError)
        End If
        Me.tdgDetail.DataSource = pdtReturn
        If pdtReturn IsNot Nothing Then
            Me.tdgDetail.Columns(0).Visible = False
            Me.tdgDetail.Columns(1).Visible = False
            Me.tdgDetail.Columns(2).Visible = False
        End If
        Me.Cursor = Cursors.Default
        Label3.Visible = False
    End Sub


    Public Function daochu(ByVal x As DataGridView) As Boolean '导出到Excel函数
        Try
            If x.Rows.Count <= 0 Then '判断记录数,如果没有记录就退出
                MessageBox.Show("没有记录可以导出", "没有可以导出的项目", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else '如果有记录就导出到Excel
                Dim xx As Object : Dim yy As Object
                xx = CreateObject("Excel.Application") '创建Excel对象
                yy = xx.workbooks.add()
                Dim i As Integer, u As Integer = 0, v As Integer = 0 '定义循环变量,行列变量
                For i = 1 To x.Columns.Count '把表头写入Excel
                    yy.worksheets(1).cells(1, i) = x.Columns(i - 1).HeaderCell.Value
                Next
                Dim str(x.Rows.Count - 1, x.Columns.Count - 1) '定义一个二维数组
                For u = 1 To x.Rows.Count '行循环
                    For v = 1 To x.Columns.Count '列循环
                        If x.Item(v - 1, u - 1).Value.GetType.ToString <> "System.Guid" Then
                            str(u - 1, v - 1) = x.Item(v - 1, u - 1).Value
                        Else
                            str(u - 1, v - 1) = x.Item(v - 1, u - 1).Value.ToString
                        End If
                    Next
                Next
                yy.worksheets(1).range("A2").Resize(x.Rows.Count, x.Columns.Count).Value = str '把数组一起写入Excel
                yy.worksheets(1).Cells.EntireColumn.AutoFit() '自动调整Excel列
                ' yy.worksheets(1).name = x.TopLeftHeaderCell.Value.ToString '表标题写入作为Excel工作表名称
                xx.visible = True '设置Excel可见
                yy = Nothing '销毁组建释放资源
                xx = Nothing '销毁组建释放资源
            End If
            Return True
        Catch ex As Exception '错误处理
            MessageBox.Show(Err.Description.ToString, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error) '出错提示
            Return False
        End Try
    End Function


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        CmdExcel_Click()
    End Sub

    Private Sub CmdExcel_Click()
        If MsgBox("数据是否导入EXCEL文件？", vbYesNo + vbQuestion, "提示") = vbYes Then  ' 用户按下"是"。
            Me.Cursor = Cursors.AppStarting
            Dim intSortWeight As Single
            Dim intTotalWeight As Single
            Dim strError As String = ""
            'Dim isExportDetail As Boolean

            'If MsgBox("是否导出单耗明细", vbYesNo + 32, "提示") = vbYes Then
            '    isExportDetail = True
            'Else
            '    isExportDetail = False
            'End If
            Dim objExcelApp As Excel.Application        'Excel进程
            Dim objExcelWorkBook As Excel.Workbook      'Excel工作簿
            Dim objExcelWorkSheet As Excel.Worksheet    'Excel工作表
            '            On Error Resume Next

            Try

                objExcelApp = New Excel.Application
                If Err.Number > 0 Then
                    MsgBox("Excel 初始化时出错，请与软件供应商联系！", vbExclamation)
                    Exit Sub
                End If

                Dim n As Long
                intTotalWeight = 0

                Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
                Dim dtmRs As DataTable = objData.GetDataTableBySql("select * from 报关制造通知单表 where 制造通知单号='" & lblNo.Text & "'", "")
                If dtmRs.Rows.Count > 0 Then
                    objExcelWorkBook = objExcelApp.Workbooks.Open(Application.StartupPath & "\excel\报关材料明细表.XLS", , True)
                    objExcelWorkSheet = objExcelWorkBook.Worksheets("sheet1")
                    objExcelApp.Visible = True
                    'objExcelWorkSheet.Range("A2").Offset(0, 0) = "制造通知单号：" & tdg_to.CurrentRow.Cells("制造通知单号").Value.ToString()
                    'objExcelWorkSheet.Range("C2").Offset(0, 0) = "客户代码：" & mRs!客户代码
                    'objExcelWorkSheet.Range("F2").Offset(0, 0) = "客户名称：" & mRs!客户名称
                    'objExcelWorkSheet.Range("A3").Offset(0, 0) = "出货日期：" & mRs!出货日期
                    'objExcelWorkSheet.Range("C3").Offset(0, 0) = "录入日期：" & mRs!录入日期
                    objExcelWorkSheet.Range("A1").Value = "成品库存单"

                    objExcelWorkSheet.Range("A2").Value = "制造通知单号：" & dtmRs.Rows(0)("制造通知单号").ToString()
                    objExcelWorkSheet.Range("C2").Value = "客户代码：" & dtmRs.Rows(0)("客户代码").ToString()
                    objExcelWorkSheet.Range("F2").Value = "客户名称：" & dtmRs.Rows(0)("客户名称").ToString()
                    objExcelWorkSheet.Range("A3").Value = "出货日期：" & dtmRs.Rows(0)("出货日期").ToString().Split(" ")(0)
                    objExcelWorkSheet.Range("C3").Value = "录入日期：" & dtmRs.Rows(0)("录入日期").ToString().Split(" ")(0)

                    n = 4
                    objExcelWorkSheet.Cells(n, 1) = "客人型号"
                    objExcelWorkSheet.Cells(n, 2) = "优丽型号"
                    objExcelWorkSheet.Cells(n, 3) = "颜色"
                    objExcelWorkSheet.Cells(n, 4) = ""
                    objExcelWorkSheet.Cells(n, 5) = ""
                    objExcelWorkSheet.Cells(n, 6) = "订单数量"
                    objExcelWorkSheet.Cells(n, 7) = "库存数量"
                    objExcelWorkSheet.Cells(n, 8) = "单位"

                    n = 5
                    Dim dtDetail As DataTable = Me.tdgDetail.DataSource
                    For Each dtRow As DataRow In dtDetail.Rows
                        'objExcelWorkSheet.Range("A5").Offset(n, 0) = dtRow("客人型号").ToString
                        'objExcelWorkSheet.Range("B5").Offset(n, 0) = dtRow("优丽型号").ToString
                        'objExcelWorkSheet.Range("G5").Offset(n, 0) = dtRow("订单数量").ToString
                        'objExcelWorkSheet.Range("H5").Offset(n, 0) = dtRow("单位").ToString

                        '客人型号,优丽型号,颜色,订单数量,已入库数量-isnull(已出库数量) As 库存数量,单位

                        objExcelWorkSheet.Cells(n, 1) = dtRow("客人型号").ToString
                        objExcelWorkSheet.Cells(n, 2) = dtRow("优丽型号").ToString
                        objExcelWorkSheet.Cells(n, 3) = dtRow("颜色").ToString
                        objExcelWorkSheet.Cells(n, 4) = ""
                        objExcelWorkSheet.Cells(n, 5) = ""
                        objExcelWorkSheet.Cells(n, 6) = dtRow("订单数量").ToString
                        objExcelWorkSheet.Cells(n, 7) = dtRow("库存数量").ToString
                        objExcelWorkSheet.Cells(n, 8) = dtRow("单位").ToString


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
