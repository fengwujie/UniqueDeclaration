using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccess
{
    public class MSSQLDAL : IDataAccess
    {
        private SqlConnection _con;
        private int CommandTimeout = Convert.ToInt16(ConfigurationManager.AppSettings["CommandTimeout"].ToString());
        public MSSQLDAL(string conStr)
        {
            _con = new SqlConnection(conStr);
        }
        #region IDataAccess 成员
        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open()
        {
            if (this._con == null || this._con.State == System.Data.ConnectionState.Closed)
            {
                this._con.Open();
            }
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (this._con != null || _tran != null)
            {
                this._con.Close();
            }
        }
        private SqlTransaction _tran;
        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTran()
        {
            _tran = this._con.BeginTransaction();
        }
        /// <summary>
        /// 提交事务 
        /// </summary>
        public void CommitTran()
        {
            this._tran.Commit();
        }
        /// <summary>
        /// 回滚事务 
        /// </summary>
        public void RollbackTran()
        {
            this._tran.Rollback();
        }
        /// <summary>
        /// 执行增删改操作 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, QueryParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, CommandType.Text, sql, para);
            int i = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return i;

        }
        public object ExecScalar(string sql, QueryParameter[] para)//返回单个值
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, CommandType.Text, sql, para);
            object obj = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return obj;
        }
        public DataTable GetTable(string sql, QueryParameter[] para)//返回查询结果表格
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = CommandTimeout;
            PrepareCommand(cmd, CommandType.Text, sql, para);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cmd.Parameters.Clear();
            return dt;
        }
        public DataSet GetDataSet(string sql, QueryParameter[] para)//返回查询结果表格
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = CommandTimeout;
            PrepareCommand(cmd, CommandType.Text, sql, para);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }
        public IDataReader GetReader(string sql, QueryParameter[] para)//返回一个dataReader
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, CommandType.Text, sql, para);
            SqlDataReader dr = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return dr;
        }
        private void PrepareCommand(SqlCommand cmd, CommandType commandType, string commandtext, QueryParameter[] commandQueryParameter)
        {
            cmd.CommandType = commandType;
            cmd.CommandText = commandtext;
            cmd.Connection = this._con;
            cmd.Transaction = this._tran;
            cmd.CommandTimeout = CommandTimeout;
            if (commandQueryParameter != null && commandQueryParameter.Length > 0)
            {
                for (int i = 0; i < commandQueryParameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue(commandQueryParameter[i].Name, commandQueryParameter[i].Value);//这里将Add改为AddWithValue原因是VS提示该方法已过时
                }
            }
        }
        #endregion
    }
}
