using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniqueDeclarationModel;
using System.Data;
using DataAccess;
using UniqueDeclarationPubilc;

namespace UniqueDeclarationDAL
{
    public class UserInfoDAL
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>返回结果集</returns>
        public DataTable getUserInfo()
        {
            DataTable dtUserInfo = null;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            dtUserInfo = dataAccess.GetTable("SELECT [登录名],[密码] FROM [权限表]", null);//,[权限1],[权限2],[权限3],[权限4],[值]
            dataAccess.Close();
            return dtUserInfo;
        }

        /// <summary>
        /// 检查用户名的合法性
        /// </summary>
        /// <param name="model">用户信息模型</param>
        /// <param name="strMessage">数据不合法时的提示信息</param>
        /// <returns>返回检查结果，TRUE或FALSE</returns>
        public bool checkUserInfo(UserInfoModel model, ref string strMessage)
        {
            bool bSuccess = false;
            try
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();//,[权限1],[权限2],[权限3],[权限4],[值]
                string strSQL = string.Format("SELECT [登录名],[密码] FROM [权限表] where [登录名]='{0}' and [密码]='{1}'", model.UserName, model.UserPwd);
                DataTable dtUserInfo = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtUserInfo.Rows.Count > 0)
                {                   
                    SystemGlobal.SystemGlobal_UserInfo = model;
                    bSuccess = true;
                }
                else
                {
                    strMessage = "用户账号或用户密码错误！";
                    bSuccess = false;
                }
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
                bSuccess = false;
            }
            return bSuccess;
        }
    }
}
