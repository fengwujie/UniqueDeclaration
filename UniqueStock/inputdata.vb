Imports Microsoft.Office.Interop

Public Class inputdata

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim intOk As Integer = 0
        Dim intError As Integer = 0
        Dim strError As String = ""
        Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
        Dim strSQL As String = "select 制造通知单id,制造通知单号,出货日期,客户代码 from 报关制造通知单表 Where 出货日期<='2015/07/31'"
        Dim pdtReturn As DataTable = objData.GetDataTableBySql(strSQL, strError)

        For Each dtRow As DataRow In pdtReturn.Rows

            Dim strFromId As String = dtRow("制造通知单id").ToString

            Dim dtT As DateTime = DateTime.Parse(dtRow("出货日期").ToString).AddDays(-3)

            Dim strSQL2 As String = "Update 报关制造通知单明细表 set 已入库数量=订单数量,入库日期='" & dtT.ToString & "'  where 制造通知单id=" & strFromId
            Dim intRet As Integer = objData.ExcelSql(strSQL2, strError)
            If intRet < 0 Then
                intError += 1
            Else
                intOk += 1
            End If


            Dim dtO As DateTime = DateTime.Parse(dtRow("出货日期").ToString).AddDays(-1)
            strSQL2 = "Update 报关制造通知单明细表 set 已出库数量=isnull(已入库数量,0),出库日期='" & dtO.ToString & "'  where 制造通知单id=" & strFromId
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

        Dim strSQL As String = "select * from 报关制造通知单表 Where 1=1"
        Dim strCnd As String = ""

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

        If pdtReturn IsNot Nothing Then

            Dim intOk As Integer = 0
            Dim intError As Integer = 0

            Dim intCount As Integer = pdtReturn.Rows.Count



            For Each dtRow As DataRow In pdtReturn.Rows

                Dim intRet As Integer = CmdOrderExcel_Click(dtRow("制造通知单号").ToString)
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

        MessageBox.Show("导出完成！")
        Me.Cursor = Cursors.Default

    End Sub


    Private Function CmdOrderExcel_Click(ByVal strNo As String) As Integer
        Dim intRet As Integer = 0

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
                Exit Function
            End If

            Dim n As Long
            intTotalWeight = 0

            Dim objData As New ErpDataHelper(My.Settings.server, My.Settings.datasource, My.Settings.sa, My.Settings.pw)
            Dim dtmRs As DataTable = objData.GetDataTableBySql("select * from 报关制造通知单表 where 制造通知单号='" & strNo & "'", "")
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

                Dim strSQL As String = "select * from 报关制造通知单明细表 Where isnull(订单数量,0)>0 and 制造通知单id=" & dtmRs.Rows(0)("制造通知单id").ToString()

                Dim dtDetail As DataTable = objData.GetDataTableBySql(strSQL, strError)
                If dtDetail Is Nothing Then
                    Return intRet
                End If

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
                strPath = strPath & dtOut.Year.ToString & "_" & dtOut.Month.ToString & "\"

                If System.IO.Directory.Exists(strPath) = False Then
                    System.IO.Directory.CreateDirectory(strPath)
                End If

                strPath = strPath & dtmRs.Rows(0)("制造通知单号").ToString().Split("无")(0)
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