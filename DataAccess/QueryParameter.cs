using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess
{
   public class QueryParameter
    {
       public QueryParameter(string name, object value, DbType dbType)
       {
           this._dbType = dbType;
           this._name = name;
           this._value = value;
       }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private object _value;

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private DbType _dbType;

        public DbType DbType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }
        private ParameterDirection _direction = ParameterDirection.Input;

        public ParameterDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
    }
}
