Imports Microsoft.Office.Interop

Public Class frmInStock

    Public gintCls As Integer = 1   '1=查看汇腾明细  2=查看安迪本地系统明细
    Public gstrOrderNo As String = ""  '订单号

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

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy/MM"

        AddHandler tdg_to.CurrentCellChanged, AddressOf gridView_SelectionChanged
    End Sub

    ''' <summary>
    ''' 取到来源数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadUniqueData()
        'lblMsg.Text = "正在读取同安已导入数据，请稍等！"

        My.WebServices.Service.Url = My.Settings.wpfurl
        Dim strCnd As String = " 料件订购表id ='" & gstrOrderNo & "'"
        Dim pdtReturn As DataTable = Nothing
        Try

            Dim strSql As String = "select 料件id,料件型号,料件名,颜色,订购数量,订购单位2,备注 from 料件订购明细表 Where " & strCnd
            Dim dtSet As DataSet = My.WebServices.Service.GetDataTableBySql(strSql)

            Dim dtTem As DataTable = dtSet.Tables(0)
            Me.tdgDetail.DataSource = dtTem

            'lblMsg.Text = "读取成功！！"
        Catch ex As Exception
            'lblMsg.Text = "读取失败！！"
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

        Dim strSQL As String = "select 制造通知单号,客户代码 from 报关制造通知单表 Where 1=1"
        Dim strCnd As String = ""

        If Me.txtSearch.Text.Trim <> "" Then
            strCnd &= " And (制造通知单号 like '%" & txtSearch.Text & "%' Or 客户代码 like '%" & txtSearch.Text & "%')"
        End If

        Dim tianshu As Integer = DateTime.DaysInMonth(DateTimePicker2.Value.Year, DateTimePicker2.Value.Month)
        If DateTimePicker2.Checked Then
            strCnd &= " And 出货日期 >= '" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/01'"
            strCnd &= " And 出货日期 <= '" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/" & tianshu.ToString & "'"
        End If

        If chk_noinstock.Checked Then
            strCnd &= " And (select sum(订单数量-isnull(已入库数量,0)) from 报关制造通知单明细表 where 报关制造通知单明细表.制造通知单id=报关制造通知单表.制造通知单id)>0"
        End If

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
            Dim strFromNo As String = tdg_to.CurrentRow.Cells("制造通知单号").Value.ToString()
            Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
            Dim strSQL As String = "select * from 报关制造通知单表 Where 制造通知单号='" & strFromNo & "'"
            Dim strError As String = ""

            'pdtReturn = objData.SqlProc2("料件进销存查询", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
            Dim pdtReturn As DataTable = objData.GetDataTableBySql(strSQL, strError)
            If pdtReturn Is Nothing Then
                MessageBox.Show("查询出现错误：" & strError)
                Return
            End If

            Dim strFromId As String = pdtReturn.Rows(0)("制造通知单id").ToString
            lblNo.Text = pdtReturn.Rows(0)("制造通知单号").ToString
            lblCstNo.Text = pdtReturn.Rows(0)("客户代码").ToString
            lblCstName.Text = pdtReturn.Rows(0)("客户名称").ToString
            lblDate.Text = pdtReturn.Rows(0)("出货日期").ToString.Split(" ")(0)
            lblStockNo.Text = pdtReturn.Rows(0)("入库单号").ToString

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

        Dim strSQL As String = "select 制造通知单明细表id,制造通知单id,客人型号,优丽型号,颜色,订单数量,单位,已入库数量,0 As 入库数量,入库单价,Convert(varchar(10),入库日期,120) as 入库日期,已出库数量 from 报关制造通知单明细表 Where isnull(订单数量,0)>0 and 制造通知单id=" & strFromId


        'pdtReturn = objData.SqlProc2("料件进销存查询", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
        pdtReturn = objData.GetDataTableBySql(strSQL, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("查询出现错误：" & strError)
        End If
        For Each dtRow As DataRow In pdtReturn.Rows
            If dtRow("入库日期").ToString <> "" Then
                If DateTime.Parse(dtRow("入库日期").ToString) <= Date.Parse("1900/01/01") Then
                    dtRow("入库日期") = ""
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
        If MessageBox.Show("确定要全部入库吗？", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        Dim intUpCount As Integer = 0
        Dim strSql As String = ""
        Dim strError As String = ""
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
        Dim dtData As DataTable = Me.tdgDetail.DataSource
        For Each dtRow As DataRow In dtData.Rows

            If Val(dtRow("已入库数量").ToString) < Val(dtRow("订单数量").ToString) Then
                strSql = "Update 报关制造通知单明细表 set 已入库数量 =订单数量,入库日期='" & DateTimePicker1.Value & "' where 制造通知单明细表id=" & dtRow("制造通知单明细表id").ToString
                Dim intRet As Integer = objData.ExcelSql(strSql, strError)
                If intRet < 0 Then
                    MessageBox.Show("更新错误：" & strError)
                Else
                    intUpCount += 1
                End If
            End If


        Next

        If intUpCount > 0 Then
            MessageBox.Show("成功更新：" & intUpCount.ToString & " 条数据！")

            If Me.lblStockNo.Text = "" Then
                strSql = "select max(入库单号) from 报关制造通知单表 where 入库单号 like '" & DateTime.Now.ToString("yyyyMMdd") & "%'"
                Dim strNo = objData.GetDataTableByField(strSql, strError)
                If strNo = "" Then
                    strNo = DateTime.Now.ToString("yyyyMMdd") & "001"
                Else
                    strNo = Val(strNo) + 1
                End If

                Me.lblStockNo.Text = strNo
                strSql = "update 报关制造通知单表 set 入库单号='" & strNo & "' Where 制造通知单id=" & mstrFromId
                Dim intR As Integer = objData.ExcelSql(strSql, strError)
                If intR < 0 Then
                    MessageBox.Show("更新入库单失败：" & strError)
                End If
            End If

            LoadDetail(mstrFromId)
        Else
            MessageBox.Show("没有找到可入库的产品！")
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

            Dim strUniqueNo As String = dtRow("优丽型号").ToString
            If Val(dtRow("已入库数量").ToString) + Val(dtRow("入库数量").ToString) > Val(dtRow("订单数量").ToString) Then
                MessageBox.Show("优丽型号：" & dtRow("优丽型号").ToString & "  已入库数量 + 入库数量已超出订单数量，请修改！")
                strSql = "Update 报关制造通知单明细表 set 入库单价=" & Val(dtRow("入库单价").ToString) & ",入库日期='" & DateTimePicker1.Value & "' where 制造通知单明细表id=" & dtRow("制造通知单明细表id").ToString
                Dim intRet As Integer = objData.ExcelSql(strSql, strError)
                blnRef = True
            ElseIf Val(dtRow("入库数量").ToString) > 0 Then
                strSql = "Update 报关制造通知单明细表 set 已入库数量 =isnull(已入库数量,0)+" & dtRow("入库数量").ToString & ",入库单价=" & Val(dtRow("入库单价").ToString) & ",入库日期='" & DateTimePicker1.Value & "' where 制造通知单明细表id=" & dtRow("制造通知单明细表id").ToString
                Dim intRet As Integer = objData.ExcelSql(strSql, strError)
                If intRet < 0 Then
                    MessageBox.Show("更新错误：" & strError)
                Else
                    intUpCount += 1
                End If
            End If


            objData.SetStockPrice(strUniqueNo)

        Next

        If intUpCount > 0 Then
            MessageBox.Show("成功更新：" & intUpCount.ToString & " 条数据！")
            blnRef = True
            If Me.lblStockNo.Text = "" Then
                strSql = "select max(入库单号) from 报关制造通知单表 where 入库单号 like '" & DateTime.Now.ToString("yyyyMMdd") & "%'"
                Dim strNo = objData.GetDataTableByField(strSql, strError)
                If strNo = "" Then
                    strNo = DateTime.Now.ToString("yyyyMMdd") & "001"
                Else
                    strNo = Val(strNo) + 1
                End If

                Me.lblStockNo.Text = strNo
                strSql = "update 报关制造通知单表 set 入库单号='" & strNo & "' Where 制造通知单id=" & mstrFromId
                Dim intR As Integer = objData.ExcelSql(strSql, strError)
                If intR < 0 Then
                    MessageBox.Show("更新入库单失败：" & strError)
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
                    objExcelWorkSheet.Range("A1").Value = "成品入库单"

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
                    objExcelWorkSheet.Cells(n, 5) = "订单数量"
                    objExcelWorkSheet.Cells(n, 6) = "单位"
                    objExcelWorkSheet.Cells(n, 7) = "入库数量"
                    objExcelWorkSheet.Cells(n, 8) = "入库日期"

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
                        objExcelWorkSheet.Cells(n, 5) = dtRow("订单数量").ToString
                        objExcelWorkSheet.Cells(n, 6) = dtRow("单位").ToString
                        objExcelWorkSheet.Cells(n, 7) = dtRow("已入库数量").ToString
                        objExcelWorkSheet.Cells(n, 8) = dtRow("入库日期").ToString.Split(" ")(0)


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
        If MessageBox.Show("确定要全部恢复吗？", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        Dim intOutStock As Integer = 0
        Dim intUpCount As Integer = 0
        Dim strSql As String = ""
        Dim strError As String = ""
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
        Dim dtData As DataTable = Me.tdgDetail.DataSource
        For Each dtRow As DataRow In dtData.Rows

            If Val(dtRow("已入库数量").ToString) > 0 AndAlso Val(dtRow("已出库数量").ToString) = 0 Then
                strSql = "Update 报关制造通知单明细表 set 已入库数量 =0,入库日期='1900/01/01' where 制造通知单明细表id=" & dtRow("制造通知单明细表id").ToString
                Dim intRet As Integer = objData.ExcelSql(strSql, strError)
                If intRet < 0 Then
                    MessageBox.Show("更新错误：" & strError)
                Else
                    intUpCount += 1
                End If
            End If

            If Val(dtRow("已出库数量").ToString) > 0 Then
                intOutStock += 1
            End If


        Next

        If intUpCount > 0 Then

            If intOutStock > 0 Then
                MessageBox.Show("成功更新：" & intUpCount.ToString & " 条数据，其中有 " & intOutStock.ToString & " 条已出库！")
            Else
                MessageBox.Show("成功更新：" & intUpCount.ToString & " 条数据！")
            End If

            If Me.lblStockNo.Text <> "" Then

                Me.lblStockNo.Text = ""
                strSql = "update 报关制造通知单表 set 入库单号='' Where 制造通知单id=" & mstrFromId
                Dim intR As Integer = objData.ExcelSql(strSql, strError)
                If intR < 0 Then
                    MessageBox.Show("更新恢复单失败：" & strError)
                End If
            End If

            LoadDetail(mstrFromId)
        Else

            If intOutStock > 0 Then
                MessageBox.Show("没有找到可恢复的产品，其中有 " & intOutStock.ToString & " 条已出库！")
            Else
                MessageBox.Show("没有找到可恢复的产品！")
            End If
        End If
    End Sub
End Class
