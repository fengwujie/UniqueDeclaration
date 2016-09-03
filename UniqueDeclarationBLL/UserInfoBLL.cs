using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniqueDeclarationModel;
using UniqueDeclarationDAL;
using System.Data;

namespace UniqueDeclarationBLL
{
    public class UserInfoBLL
    {
        UserInfoDAL dal = new UserInfoDAL();
        public DataTable getUserInfo()
        {
            return dal.getUserInfo();
        }

        /// <summary>
        /// 检查用户信息是否合法
        /// </summary>
        /// <param name="model">用户信息模型</param>
        /// <param name="strMessage">不合法时的提示信息</param>
        /// <returns>返回检查结果，TRUE或FALSE</returns>
        public bool checkUserInfo(UserInfoModel model, ref string strMessage)
        {
            if (string.IsNullOrEmpty(model.UserName))
            {
                strMessage = "用户账号不允许为空！";
                return false;
            }
            //if (string.IsNullOrEmpty(model.UserPwd))
            //{
            //    strMessage = "用户密码不允许为空！";
            //    return false;
            //}
            return dal.checkUserInfo(model, ref strMessage);
        }
    }
}
