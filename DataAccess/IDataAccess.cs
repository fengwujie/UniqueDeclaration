using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess
{
  public  interface IDataAccess
    {
      void Open();//打开数据库连接
      void Close();//关闭数据库连接
      void BeginTran();//开始一个事务
      void CommitTran();//提交一个事务
      void RollbackTran();//回滚一个事务
      int ExecuteNonQuery(string sql, params QueryParameter[] para);//执行增删改
      object ExecScalar(string sql, params QueryParameter[] para);//返回单个值
      DataTable GetTable(string sql,params QueryParameter[] para);//返回查询结果表格
      IDataReader GetReader(string sql, params QueryParameter[] para);//返回一个dataReader
      DataSet GetDataSet(string sql, params QueryParameter[] para);//返回查询结果表格
    }
}
