using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.LocalDatabase
{
    class ORCALEDAL : IDataAccess
    {
        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void BeginTran()
        {
            throw new NotImplementedException();
        }

        public void CommitTran()
        {
            throw new NotImplementedException();
        }

        public void RollbackTran()
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string sql, params QueryParameter[] para)
        {
            throw new NotImplementedException();
        }

        public object ExecScalar(string sql, params QueryParameter[] para)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetTable(string sql, params QueryParameter[] para)
        {
            throw new NotImplementedException();
        }

        public System.Data.IDataReader GetReader(string sql, params QueryParameter[] para)
        {
            throw new NotImplementedException();
        }




        public System.Data.DataSet GetDataSet(string sql, params QueryParameter[] para)
        {
            throw new NotImplementedException();
        }
    }
}
