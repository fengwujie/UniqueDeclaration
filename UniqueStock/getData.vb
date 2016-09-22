Imports Microsoft.Office.Interop


Public Class getData

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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

                Dim No1, No2, No3 As Object
                Dim NNo1, NNo2, NNo3 As Object
                Dim n As Long
                intTotalWeight = 0

                Dim dtmRs As DataTable = tdg_to.DataSource
                If dtmRs.Rows.Count > 0 Then
                    objExcelWorkBook = objExcelApp.Workbooks.Open(Application.StartupPath & "\excel\getdata.XLS", , True)
                    objExcelWorkSheet = objExcelWorkBook.Worksheets("sheet1")
                    objExcelApp.Visible = True
                    'objExcelWorkSheet.Range("A2").Offset(0, 0) = "报关单号：" & tdg_to.CurrentRow.Cells("报关单号").Value.ToString()
                    'objExcelWorkSheet.Range("C2").Offset(0, 0) = "客户代码：" & mRs!客户代码
                    'objExcelWorkSheet.Range("F2").Offset(0, 0) = "客户名称：" & mRs!客户名称
                    'objExcelWorkSheet.Range("A3").Offset(0, 0) = "出货日期：" & mRs!出货日期
                    'objExcelWorkSheet.Range("C3").Offset(0, 0) = "录入日期：" & mRs!录入日期
                    'objExcelWorkSheet.Range("A2").Value = "入库单号：" & dtmRs.Rows(0)("入库单号").ToString()
                    'objExcelWorkSheet.Range("C2").Value = "入库时间：" & dtmRs.Rows(0)("入库时间").ToString().Split(" ")(0)
                    'objExcelWorkSheet.Range("D2").Value = "摘要：" & dtmRs.Rows(0)("摘要").ToString()

                    n = 3
                    For Each dtRow As DataRow In dtmRs.Rows
                        'objExcelWorkSheet.Range("A5").Offset(n, 0) = dtRow("客人型号").ToString
                        'objExcelWorkSheet.Range("B5").Offset(n, 0) = dtRow("优丽型号").ToString
                        'objExcelWorkSheet.Range("G5").Offset(n, 0) = dtRow("订单数量").ToString
                        'objExcelWorkSheet.Range("H5").Offset(n, 0) = dtRow("单位").ToString

                        objExcelWorkSheet.Cells(n, 1) = dtRow("制造通知单号").ToString.Trim
                        objExcelWorkSheet.Cells(n, 2) = dtRow("总单号码").ToString.Trim
                        objExcelWorkSheet.Cells(n, 3) = dtRow("材料出库日期").ToString.Trim
                        objExcelWorkSheet.Cells(n, 4) = dtRow("成品入库日期").ToString.Trim
                        objExcelWorkSheet.Cells(n, 5) = dtRow("成品出库日期").ToString.Trim
                        objExcelWorkSheet.Cells(n, 6) = dtRow("制造通知单出货日期").ToString.Trim
                        objExcelWorkSheet.Cells(n, 7) = dtRow("报单关出货日期").ToString.Trim
                        objExcelWorkSheet.Cells(n, 8) = dtRow("客人型号").ToString.Trim
                        objExcelWorkSheet.Cells(n, 9) = dtRow("优丽型号").ToString.Trim
                        objExcelWorkSheet.Cells(n, 10) = dtRow("颜色").ToString.Trim
                        objExcelWorkSheet.Cells(n, 11) = dtRow("订单数量").ToString.Trim
                        objExcelWorkSheet.Cells(n, 12) = dtRow("生产数量").ToString.Trim



                        n = n + 1
                        intSortWeight = 0
                    Next

                    'n = 4
                    'objExcelWorkSheet.Cells(n, 1) = "客人型号"
                    'objExcelWorkSheet.Cells(n, 2) = "优丽型号"
                    'objExcelWorkSheet.Cells(n, 3) = "颜色"
                    'objExcelWorkSheet.Cells(n, 4) = ""
                    'objExcelWorkSheet.Cells(n, 5) = ""
                    'objExcelWorkSheet.Cells(n, 6) = ""
                    'objExcelWorkSheet.Cells(n, 7) = "数量"
                    'objExcelWorkSheet.Cells(n, 8) = "单位"


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

        'Dim strSQL As String = "select a.制造通知单明细表id,b.制造通知单号,b.总单号码,c.出库时间 as 材料出库日期,a.入库日期 as 成品入库日期,a.出库日期 as 成品出库日期,b.出货日期 as 制造通知单出货日期,'1900/01/01' as 报单关出货日期,a.制造通知单id,a.客人型号,a.优丽型号,a.颜色,a.订单数量,a.生产数量,c.电子帐册号 from 报关制造通知单明细表 a left join 报关制造通知单表 b on(a.制造通知单id=b.制造通知单id) left join 进口料件出库表 c on(b.制造通知单号=c.制造通知单号) where b.制造通知单号='" & txtOrderNo.Text & "'"
        Dim strSQL As String = "select a.制造通知单明细表id,b.制造通知单号,b.总单号码,c.出库时间 as 材料出库日期,a.入库日期 as 成品入库日期,a.出库日期 as 成品出库日期,b.出货日期 as 制造通知单出货日期,'1900/01/01' as 报单关出货日期,a.制造通知单id,a.客人型号,a.优丽型号,a.颜色,a.订单数量,a.生产数量,c.电子帐册号 from 报关制造通知单明细表 a left join 报关制造通知单表 b on(a.制造通知单id=b.制造通知单id) left join 进口料件出库表 c on(b.制造通知单号=c.制造通知单号) where b.制造通知单号 not in('13-03228-1无铅','14-1038-1','14-1164','14-1293','14-03204','15-0110-1无铅','15-0487','15-0520','15-0526无铅无镍','15-0542-5V','15-05117','12-1065-5')"
        Dim strCnd As String = ""

        strCnd &= " ORDER BY c.出库时间 DESC"

        'pdtReturn = objData.SqlProc2("料件进销存查询", ComboBox1.Text, DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, strError)
        pdtReturn = objData.GetDataTableBySql(strSQL & strCnd, strError)
        If pdtReturn Is Nothing Then
            MessageBox.Show("查询出现错误：" & strError)
        End If


        Dim dtTemp As DataTable = Nothing
        Dim dtZX As DataTable = Nothing
        Dim intRow As Integer = pdtReturn.Rows.Count
        Dim intCurr As Integer = 0
        Dim intRet As Integer = 0
        Dim intError As Integer = 0

        For Each dtRow As DataRow In pdtReturn.Rows
            dtTemp = objData.GetDataTableBySql("select 订单号码,制造通知单号 from view_OrderC left join 报关订单表 on(view_OrderC.订单id=报关订单表.订单id) where view_OrderC.制造通知单号='" & dtRow("制造通知单号").ToString & "'", "")

            Dim strBGOrder As String = ""
            If dtTemp.Rows.Count > 0 Then

                strBGOrder = dtTemp.Rows(0)("订单号码").ToString
                Dim objZX As New ErpDataHelper("192.168.1.3", "uniquegrade", "sa", "")
                dtZX = objZX.GetDataTableBySql("select 出货日期 from 装箱单表 where 订单号码='" & strBGOrder & "'", "")

                If dtZX.Rows.Count > 0 AndAlso dtZX.Rows(0)("出货日期").ToString.Trim <> "" Then
                    dtRow("报单关出货日期") = dtZX.Rows(0)("出货日期").ToString

                End If


            End If


            Dim strIn As String = "1900/01/01"
            Dim strOut As String = "1900/01/01"
            If IsDate(dtRow("报单关出货日期").ToString) AndAlso DateTime.Parse(dtRow("报单关出货日期").ToString) > DateTime.Parse("1900/01/01") Then
                strOut = DateTime.Parse(dtRow("报单关出货日期").ToString).AddDays(-1)
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


            If DateTime.Parse(dtRow("材料出库日期").ToString) > DateTime.Parse(strIn) AndAlso DateTime.Parse(strIn) > DateTime.Parse("1900/01/01") Then
                strIn = strOut
            End If


            dtRow("成品入库日期") = strIn


            dtRow("成品出库日期") = strOut


            Dim strValue As String = dtRow("制造通知单明细表id").ToString & ",'" & dtRow("制造通知单号").ToString & "','" & dtRow("总单号码").ToString & "','" & strBGOrder & "','" & isD(dtRow("材料出库日期").ToString) & "','" & isD(dtRow("成品入库日期").ToString) & "','" & isD(dtRow("成品出库日期").ToString) & "','" & isD(dtRow("制造通知单出货日期").ToString) & "','" & isD(dtRow("报单关出货日期").ToString) & "','" & dtRow("客人型号").ToString & "','" & dtRow("优丽型号").ToString & "','" & dtRow("颜色").ToString & "','" & dtRow("订单数量").ToString & "','" & dtRow("生产数量").ToString & "'"
            Dim strInsert As String = "insert into temp_BGDetail(制造通知单明细表id,制造通知单号,业务订单号,报关订单号,材料出库日期,成品入库日期,成品出库日期,制造通知单出货日期,报单关出货日期,客人型号,优丽型号,颜色,订单数量,生产数量)values(" & strValue & ")"
            objData.ExcelSql(strInsert, "")

            Dim strUpdate As String = "update 报关制造通知单明细表 set 入库日期='" & strIn & "',出库日期='" & strOut & "' where 制造通知单明细表id=" & dtRow("制造通知单明细表id").ToString
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