Imports System.Collections.Generic
Imports System.Web
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

''' <summary>
'''DataHelper 的摘要说明
''' </summary>
Public Class ErpDataHelper
  '
  'TODO: 在此处添加构造函数逻辑
  '
  Public Sub New(ByVal strServer As String, ByVal strData As String, ByVal strSa As String, ByVal strSaPw As String)
    mstrServer = strServer
    mstrData = strData
    strCn = "Data Source=" & mstrServer & ";Initial Catalog=" & mstrData & ";Integrated Security=False;User=" & strSa & ";Pwd=" & strSaPw & ";"
  End Sub

  Dim mstrServer As String = ""
  Dim mstrData As String = ""
  Dim strCn As String = ""
  Public Function InitialConnection(ByRef strError As String) As Integer
    Dim intRet As Integer = 0
    Dim mecn As SqlConnection = New SqlConnection(strCn)

    Try
      mecn.Open()
    Catch ee As Exception
      strError = ee.Message
      MessageBox.Show(ee.Message)
      intRet = -1
    End Try
    Return intRet
  End Function

  Public Function GetDataTableBySql(ByVal strSql As String, ByRef strMsg As String) As DataTable
    Dim dtData As New DataTable()

    'If InitialConnection(strMsg) < 0 Then
    '  Return Nothing
    'End If
    Dim mecn As SqlConnection = New SqlConnection(strCn)

    Try
      mecn.Open()
      Dim meCmd As New SqlCommand()
      meCmd.Connection = mecn
      meCmd.CommandType = CommandType.Text
      meCmd.CommandText = strSql
      Dim dap As New SqlDataAdapter(meCmd)
      dap.Fill(dtData)
    Catch e As Exception
      strMsg = e.Message
      dtData = Nothing
    Finally
      If mecn IsNot Nothing Then
        mecn.Close()
      End If
    End Try
    Return dtData
  End Function

    'VB.NET代码---执行存储过程
    Public Function SqlProc2(ByVal ProcName As String, ByVal Param1 As String, ByVal Param2 As String, ByRef strMsg As String) As DataTable
        Dim mecn As SqlConnection = New SqlConnection(strCn)
        Dim myDataSet As New DataSet
        Dim dtData As DataTable = Nothing

        Try
            mecn.Open()
            '定义命令对象，并使用储存过程  
            Dim myCommand As New SqlClient.SqlCommand(ProcName, mecn)
            myCommand.CommandType = CommandType.StoredProcedure
            myCommand.CommandTimeout = 3600

            '定义一个数据适配器，并设置参数  
            Dim myDapter As New SqlClient.SqlDataAdapter(myCommand)
            myDapter.SelectCommand.Parameters.Add("@制造通知单id", SqlDbType.VarChar, 20).Value = Param1
            myDapter.SelectCommand.Parameters.Add("@制造通知单明细表id", SqlDbType.VarChar, 20).Value = Param2

            '定义一个数据集对象，并填充数据集  
            myDapter.Fill(myDataSet)

            dtData = myDataSet.Tables(0)
        Catch e As Exception
            strMsg = e.Message
            dtData = Nothing
        Finally
            If mecn IsNot Nothing Then
                mecn.Close()
            End If
        End Try
        Return dtData
    End Function

    Public Function SqlProc3(ByVal ProcName As String, ByVal Param1 As String, ByVal Param2 As String, ByRef strMsg As String) As DataTable
        Dim mecn As SqlConnection = New SqlConnection(strCn)
        Dim myDataSet As New DataSet
        Dim dtData As DataTable = Nothing

        Try
            mecn.Open()
            '定义命令对象，并使用储存过程  
            Dim myCommand As New SqlClient.SqlCommand(ProcName, mecn)
            myCommand.CommandType = CommandType.StoredProcedure
            myCommand.CommandTimeout = 3600

            '定义一个数据适配器，并设置参数  
            Dim myDapter As New SqlClient.SqlDataAdapter(myCommand)
            myDapter.SelectCommand.Parameters.Add("@料件出库表id", SqlDbType.VarChar, 20).Value = Param1
            myDapter.SelectCommand.Parameters.Add("@电子帐册号", SqlDbType.VarChar, 20).Value = Param2

            '定义一个数据集对象，并填充数据集  
            myDapter.Fill(myDataSet)

            dtData = myDataSet.Tables(0)
        Catch e As Exception
            strMsg = e.Message
            dtData = Nothing
        Finally
            If mecn IsNot Nothing Then
                mecn.Close()
            End If
        End Try
        Return dtData
    End Function

    Public Function SqlProc4(ByVal ProcName As String, ByVal Param1 As String, ByVal Param2 As String, ByRef strMsg As String) As DataTable
        Dim mecn As SqlConnection = New SqlConnection(strCn)
        Dim myDataSet As New DataSet
        Dim dtData As DataTable = Nothing

        Try
            mecn.Open()
            '定义命令对象，并使用储存过程  
            Dim myCommand As New SqlClient.SqlCommand(ProcName, mecn)
            myCommand.CommandType = CommandType.StoredProcedure
            myCommand.CommandTimeout = 3600

            '定义一个数据适配器，并设置参数  
            Dim myDapter As New SqlClient.SqlDataAdapter(myCommand)
            myDapter.SelectCommand.Parameters.Add("@料件入库表id", SqlDbType.VarChar, 20).Value = Param1
            myDapter.SelectCommand.Parameters.Add("@电子帐册号", SqlDbType.VarChar, 20).Value = Param2

            '定义一个数据集对象，并填充数据集  
            myDapter.Fill(myDataSet)

            dtData = myDataSet.Tables(0)
        Catch e As Exception
            strMsg = e.Message
            dtData = Nothing
        Finally
            If mecn IsNot Nothing Then
                mecn.Close()
            End If
        End Try
        Return dtData
    End Function

  Public Function GetDataTableByField(ByVal strSql As String, ByRef strMsg As String) As String
    Dim dtData As New DataTable()
    Dim strRet As String = ""
    'If InitialConnection(strMsg) < 0 Then
    '  Return Nothing
    'End If

    Dim mecn As SqlConnection = New SqlConnection(strCn)

    Try
      mecn.Open()
      Dim meCmd As New SqlCommand()
      meCmd.Connection = mecn
      meCmd.CommandType = CommandType.Text
      meCmd.CommandText = strSql
      Dim dap As New SqlDataAdapter(meCmd)
      dap.Fill(dtData)

      If dtData.Rows.Count > 0 Then
        strRet = dtData.Rows(0)(0).ToString
      End If
    Catch e As Exception
      strMsg = e.Message
      dtData = Nothing
    Finally
      If mecn IsNot Nothing Then
        mecn.Close()
      End If
    End Try
    Return strRet
  End Function

  Public Function ExcelSql(ByVal strSql As String, ByRef strMsg As String) As Integer
    Dim intRet As Integer = 0

    'If InitialConnection(strMsg) < 0 Then
    '  Return -1
    'End If
    Dim mecn As New SqlConnection(strCn)
    Dim tsn As SqlTransaction = Nothing
    Try
      mecn.Open()
      Dim meCmd As New SqlCommand()
      meCmd.Connection = mecn
      meCmd.CommandType = CommandType.Text
      meCmd.CommandTimeout = 120
      tsn = mecn.BeginTransaction()

      Dim strS As String() = strSql.Split(Chr(8))
      meCmd.Transaction = tsn

      For Each strIn As String In strS
        If strIn <> "" Then
          meCmd.CommandText = strIn
          meCmd.ExecuteNonQuery()
        End If
      Next
      tsn.Commit()
    Catch e As Exception
      strMsg = e.Message
      tsn.Rollback()
      intRet = -1
    Finally
      If mecn IsNot Nothing Then
        mecn.Close()
      End If
    End Try
    Return intRet
  End Function

End Class

