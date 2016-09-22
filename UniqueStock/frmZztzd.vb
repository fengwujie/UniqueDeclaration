Imports Microsoft.Office.Interop

Public Class frmZztzd

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

        Label3.Visible = True
        Me.Update()
        Label3.Refresh()
        Me.Cursor = Cursors.AppStarting
        Dim strError As String = ""
        Dim pdtReturn As DataTable = Nothing
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)

        Dim strSQL As String = "select * from 报关制造通知单表 Where 1=1"
        Dim strCnd As String = ""

        If txtNo.Text.Trim <> "" Then
            strCnd &= " And 制造通知单号 like '%" & txtNo.Text & "%'"
        End If
        If txtCstNo.Text.Trim <> "" Then
            strCnd &= " And 客户代码 like '%" & txtCstNo.Text & "%'"
        End If
        If DateTimePicker1.Checked Then
            strCnd &= " And 出货日期 >= '" & DateTimePicker1.Value.ToShortDateString & "'"
        End If
        If DateTimePicker2.Checked Then
            strCnd &= " And 出货日期 <= '" & DateTimePicker2.Value.ToShortDateString & "'"
        End If

        If strCnd = "" Then
            MessageBox.Show("请输入要查询的条件！")
            Me.Cursor = Cursors.Default
            Label3.Visible = False
            Return
        End If

        'pdtReturn = objData.SqlProc2("料件进销存查询", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
        pdtReturn = objData.GetDataTableBySql(strSQL & strCnd, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("查询出现错误：" & strError)
        End If
        Me.tdg_to.DataSource = pdtReturn
        If pdtReturn IsNot Nothing Then
            Me.tdg_to.Columns(0).Visible = False
            Me.tdg_to.Columns(8).Visible = False
            Me.tdg_to.Columns(9).Visible = False
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
            Dim strFromId As String = tdg_to.CurrentRow.Cells("制造通知单id").Value.ToString()
            lblShowNo.Text = tdg_to.CurrentRow.Cells("制造通知单号").Value.ToString()

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

        Dim strSQL As String = "select * from 报关制造通知单明细表 Where isnull(订单数量,0)>0 and 制造通知单id=" & strFromId


        'pdtReturn = objData.SqlProc2("料件进销存查询", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
        pdtReturn = objData.GetDataTableBySql(strSQL, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("查询出现错误：" & strError)
        End If
        Me.tdgDetail.DataSource = pdtReturn
        If pdtReturn IsNot Nothing Then
            Me.tdgDetail.Columns(0).Visible = False
            Me.tdgDetail.Columns(1).Visible = False
            Me.tdgDetail.Columns(6).Visible = False
            Me.tdgDetail.Columns(7).Visible = False
            Me.tdgDetail.Columns(8).Visible = False
            Me.tdgDetail.Columns(11).Visible = False
            Me.tdgDetail.Columns(12).Visible = False
            Me.tdgDetail.Columns(13).Visible = False
            Me.tdgDetail.Columns(14).Visible = False
            Me.tdgDetail.Columns(15).Visible = False
            Me.tdgDetail.Columns(16).Visible = False
            Me.tdgDetail.Columns(17).Visible = False
            Me.tdgDetail.Columns(18).Visible = False
            Me.tdgDetail.Columns(19).Visible = False
            Me.tdgDetail.Columns(20).Visible = False
            Me.tdgDetail.Columns(21).Visible = False
            Me.tdgDetail.Columns(22).Visible = False
        End If
        Me.Cursor = Cursors.Default
        Label3.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'daochu(tdg_to)
        CmdExcel_Click(False)
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

    Private Sub CmdExcel_Click(ByVal isExportDetail As Boolean)
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

                Dim No1, No2, No3 As Object
                Dim NNo1, NNo2, NNo3 As Object
                Dim n As Long
                intTotalWeight = 0

                Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
                Dim dtmRs As DataTable = objData.GetDataTableBySql("select * from 报关制造通知单表 where 制造通知单号='" & lblShowNo.Text & "'", "")
                If dtmRs.Rows.Count > 0 Then
                    objExcelWorkBook = objExcelApp.Workbooks.Open(Application.StartupPath & "\excel\报关材料明细表.XLS", , True)
                    objExcelWorkSheet = objExcelWorkBook.Worksheets("sheet1")
                    objExcelApp.Visible = True
                    'objExcelWorkSheet.Range("A2").Offset(0, 0) = "制造通知单号：" & tdg_to.CurrentRow.Cells("制造通知单号").Value.ToString()
                    'objExcelWorkSheet.Range("C2").Offset(0, 0) = "客户代码：" & mRs!客户代码
                    'objExcelWorkSheet.Range("F2").Offset(0, 0) = "客户名称：" & mRs!客户名称
                    'objExcelWorkSheet.Range("A3").Offset(0, 0) = "出货日期：" & mRs!出货日期
                    'objExcelWorkSheet.Range("C3").Offset(0, 0) = "录入日期：" & mRs!录入日期
                    If isExportDetail Then
                        objExcelWorkSheet.Range("A1").Value = "材料明细表"
                    Else
                        objExcelWorkSheet.Range("A1").Value = "制造通知单"
                    End If

                    objExcelWorkSheet.Range("A2").Value = "制造通知单号：" & dtmRs.Rows(0)("制造通知单号").ToString()
                    objExcelWorkSheet.Range("C2").Value = "客户代码：" & dtmRs.Rows(0)("客户代码").ToString()
                    objExcelWorkSheet.Range("F2").Value = "客户名称：" & dtmRs.Rows(0)("客户名称").ToString()
                    objExcelWorkSheet.Range("A3").Value = "出货日期：" & dtmRs.Rows(0)("出货日期").ToString().Split(" ")(0)
                    objExcelWorkSheet.Range("C3").Value = "录入日期：" & dtmRs.Rows(0)("录入日期").ToString().Split(" ")(0)

                    n = 4
                    objExcelWorkSheet.Cells(n, 1) = "客人型号"
                    objExcelWorkSheet.Cells(n, 2) = "优丽型号"
                    objExcelWorkSheet.Cells(n, 3) = "颜色"
                    'If isExportDetail = False Then
                    objExcelWorkSheet.Cells(n, 4) = ""
                    objExcelWorkSheet.Cells(n, 5) = ""
                    objExcelWorkSheet.Cells(n, 6) = ""
                    'End If
                    objExcelWorkSheet.Cells(n, 7) = "数量"
                    objExcelWorkSheet.Cells(n, 8) = "单位"

                    n = 5
                    Dim dtDetail As DataTable = Me.tdgDetail.DataSource
                    For Each dtRow As DataRow In dtDetail.Rows
                        'objExcelWorkSheet.Range("A5").Offset(n, 0) = dtRow("客人型号").ToString
                        'objExcelWorkSheet.Range("B5").Offset(n, 0) = dtRow("优丽型号").ToString
                        'objExcelWorkSheet.Range("G5").Offset(n, 0) = dtRow("订单数量").ToString
                        'objExcelWorkSheet.Range("H5").Offset(n, 0) = dtRow("单位").ToString

                        objExcelWorkSheet.Cells(n, 1) = dtRow("客人型号").ToString
                        objExcelWorkSheet.Cells(n, 2) = dtRow("优丽型号").ToString
                        objExcelWorkSheet.Cells(n, 3) = dtRow("颜色").ToString
                        objExcelWorkSheet.Cells(n, 7) = dtRow("订单数量").ToString
                        objExcelWorkSheet.Cells(n, 8) = dtRow("单位").ToString


                        n = n + 1
                        intSortWeight = 0
                        '                        If IsNull(rs!产品id) = False Then
                        '                            rs1.Filter = "产品id=" & rs!产品id
                        '                        ElseIf IsNull(rs!配件id) = False Then
                        '                            rs1.Filter = "产品配件id=" & rs!配件id
                        '                        Else
                        '                            rs1.Filter = "产品配件id=0"
                        ''                        End If
                        '                        If rs1.RecordCount > 0 Then
                        '                            rs1.MoveFirst
                        '                        End If
                        If isExportDetail = True Then
                            Dim pdtReturn As DataTable = objData.SqlProc2("报关制造通知单单耗", dtRow("制造通知单id").ToString, dtRow("制造通知单明细表id").ToString, strError)
                            'rs1 = deManufacture.cnnPublic.Execute("报关制造通知单单耗 @制造通知单id=" & mRs!制造通知单id & ",@制造通知单明细表id=" & rs!制造通知单明细表id)

                            objExcelWorkSheet.Cells(n, 1) = "材料明细："
                            n = n + 1
                            For Each dtDRow As DataRow In pdtReturn.Rows
                                If Val(dtRow("订单数量").ToString) > 0 Then
                                    'objExcelWorkSheet.Range("A5").Offset(n, 0) = dtDRow("料号").ToString
                                    'objExcelWorkSheet.Range("B5").Offset(n, 0) = rs1!料件名 & ""
                                    'objExcelWorkSheet.Range("C5").Offset(n, 0) = rs1!商品名称 & ""
                                    'objExcelWorkSheet.Range("D5").Offset(n, 0) = Format(rs1!用量, "0.00000") & Trim(rs1!用量单位 & "")
                                    'objExcelWorkSheet.Range("E5").Offset(n, 0) = Format(rs1!用量 * rs!订单数量, "0.00000") & Trim(rs1!用量单位 & "")
                                    'objExcelWorkSheet.Range("F5").Offset(n, 0) = rs1!单耗
                                    'objExcelWorkSheet.Range("G5").Offset(n, 0) = rs1!单耗 * rs!订单数量
                                    'objExcelWorkSheet.Range("H5").Offset(n, 0) = rs1!单位
                                    objExcelWorkSheet.Cells(n, 1) = dtDRow("料号").ToString
                                    objExcelWorkSheet.Cells(n, 2) = dtDRow("料件名").ToString
                                    objExcelWorkSheet.Cells(n, 3) = dtDRow("商品名称").ToString
                                    objExcelWorkSheet.Cells(n, 4) = Format(Val(dtDRow("用量").ToString), "0.00000")   '& Trim(dtDRow("用量单位").ToString)
                                    objExcelWorkSheet.Cells(n, 5) = Math.Round(Val(dtDRow("用量").ToString) * Val(dtRow("订单数量").ToString), 5)   '& Trim(dtDRow("用量单位").ToString)
                                    objExcelWorkSheet.Cells(n, 6) = Math.Round(Val(dtDRow("单耗").ToString), 5)
                                    objExcelWorkSheet.Cells(n, 7) = Math.Round(Val(objExcelWorkSheet.Cells(n, 6).value) * Val(dtRow("订单数量").ToString), 5)
                                    objExcelWorkSheet.Cells(n, 8) = dtDRow("单位").ToString
                                    n = n + 1
                                End If
                            Next

                            objExcelWorkSheet.Range("A" & n & ":H" & n).Select()
                            With objExcelWorkSheet.Range("A" & n & ":H" & n).Borders(Excel.XlBordersIndex.xlEdgeTop)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlMedium
                                .ColorIndex = Excel.Constants.xlAutomatic
                            End With
                            n = n + 1

                        End If


                        'If isExportDetail = True Then n = n + 1
                    Next

                    If dtDetail.Rows.Count > 0 AndAlso isExportDetail = False Then
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


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CmdExcel_Click(True)
    End Sub

    Private Sub btnOrderQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrderQuery.Click

        Dim strSystem As String = System.IO.File.ReadAllText(Application.StartupPath & "\system.txt")
        If strSystem = "1" Then
            Dim objForm As New inputdata
            objForm.Show()
        Else
            CmdOrderExcel_Click()
        End If

    End Sub

    Private Sub CmdOrderExcel_Click()
        'If MsgBox("数据是否导入EXCEL文件？", vbYesNo + vbQuestion, "提示") = vbYes Then  ' 用户按下"是"。
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

            Dim No1, No2, No3 As Object
            Dim NNo1, NNo2, NNo3 As Object
            Dim n As Long
            intTotalWeight = 0

            Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
            Dim dtmRs As DataTable = objData.GetDataTableBySql("select * from 报关制造通知单表 where 制造通知单号='" & lblShowNo.Text & "'", "")
            If dtmRs.Rows.Count > 0 Then
                objExcelWorkBook = objExcelApp.Workbooks.Open(Application.StartupPath & "\excel\报关材料明细表.XLS", , True)
                objExcelWorkSheet = objExcelWorkBook.Worksheets("sheet1")
                objExcelApp.Visible = True
                'objExcelWorkSheet.Range("A2").Offset(0, 0) = "制造通知单号：" & tdg_to.CurrentRow.Cells("制造通知单号").Value.ToString()
                'objExcelWorkSheet.Range("C2").Offset(0, 0) = "客户代码：" & mRs!客户代码
                'objExcelWorkSheet.Range("F2").Offset(0, 0) = "客户名称：" & mRs!客户名称
                'objExcelWorkSheet.Range("A3").Offset(0, 0) = "出货日期：" & mRs!出货日期
                'objExcelWorkSheet.Range("C3").Offset(0, 0) = "录入日期：" & mRs!录入日期
                objExcelWorkSheet.Range("A1").Value = "ORDER"

                objExcelWorkSheet.Range("A2").Value = "订单号：" & dtmRs.Rows(0)("制造通知单号").ToString()
                objExcelWorkSheet.Range("C2").Value = "客户代码：" & dtmRs.Rows(0)("客户代码").ToString()
                objExcelWorkSheet.Range("F2").Value = "客户名称：" & dtmRs.Rows(0)("客户名称").ToString()
                objExcelWorkSheet.Range("A3").Value = "出货日期：" & dtmRs.Rows(0)("出货日期").ToString().Split(" ")(0)
                objExcelWorkSheet.Range("C3").Value = ""

                n = 4
                objExcelWorkSheet.Cells(n, 1) = "客人型号"
                objExcelWorkSheet.Cells(n, 2) = "优丽型号"
                objExcelWorkSheet.Cells(n, 3) = "颜色"
                objExcelWorkSheet.Cells(n, 4) = ""
                objExcelWorkSheet.Cells(n, 5) = ""
                objExcelWorkSheet.Cells(n, 6) = ""
                objExcelWorkSheet.Cells(n, 7) = "数量"
                objExcelWorkSheet.Cells(n, 8) = "单位"

                n = 5
                Dim dtDetail As DataTable = Me.tdgDetail.DataSource
                For Each dtRow As DataRow In dtDetail.Rows
                    'objExcelWorkSheet.Range("A5").Offset(n, 0) = dtRow("客人型号").ToString
                    'objExcelWorkSheet.Range("B5").Offset(n, 0) = dtRow("优丽型号").ToString
                    'objExcelWorkSheet.Range("G5").Offset(n, 0) = dtRow("订单数量").ToString
                    'objExcelWorkSheet.Range("H5").Offset(n, 0) = dtRow("单位").ToString

                    objExcelWorkSheet.Cells(n, 1) = dtRow("客人型号").ToString
                    objExcelWorkSheet.Cells(n, 2) = dtRow("优丽型号").ToString
                    objExcelWorkSheet.Cells(n, 3) = dtRow("颜色").ToString
                    objExcelWorkSheet.Cells(n, 7) = dtRow("订单数量").ToString
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

                Dim strPath As String = "D:\Temp\"
                Dim dtOut As DateTime = DateTime.Parse(dtmRs.Rows(0)("出货日期").ToString())
                strPath = strPath & dtOut.Year.ToString & "\"

                If System.IO.Directory.Exists(strPath) = False Then
                    System.IO.Directory.CreateDirectory(strPath)
                End If

                strPath = strPath & dtmRs.Rows(0)("制造通知单号").ToString().Split("无")(0)
                objExcelWorkBook.SaveAs(strPath & ".XLS")
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
        'End If

    End Sub

End Class
