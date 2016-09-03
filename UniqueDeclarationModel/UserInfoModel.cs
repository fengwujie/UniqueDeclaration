using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniqueDeclarationModel
{
    public class UserInfoModel
    {
        private string _userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _userPwd;
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd
        {
            get { return _userPwd; }
            set { _userPwd = value; }
        }
    }
}
