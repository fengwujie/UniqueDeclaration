using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DataAccess
{
  public  class DataAccessFactory
    {
      public static IDataAccess CreateDataAccess(DataAccessEnum.DataAccessName dataAccessName)
      {
          string conStr = string.Empty;
          switch (dataAccessName)
          {
              case DataAccessEnum.DataAccessName.DataAccessName_Manufacture:
                  conStr = ConfigurationManager.ConnectionStrings["Manufacture"].ToString();//读连接字符串 
                  break;
              case DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade:
                  conStr = ConfigurationManager.ConnectionStrings["Uniquegrade"].ToString();//读连接字符串 
                  break;
              case DataAccessEnum.DataAccessName.DataAccessName_GWT:
                  conStr = ConfigurationManager.ConnectionStrings["GWT"].ToString();//读连接字符串 
                  break;
          }
          return new MSSQLDAL(conStr);
      }

    }
}
