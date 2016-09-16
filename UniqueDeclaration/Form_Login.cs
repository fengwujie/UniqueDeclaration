using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using UniqueDeclarationBLL;
using UniqueDeclarationModel;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }
        UserInfoBLL bll = new UserInfoBLL();
        private void btnOK_Click(object sender, EventArgs e)
        {
            UserInfoModel model = new UserInfoModel();
            model.UserName = this.cboxUserName.Text;
            model.UserPwd = this.txtUserPwd.Text.Trim();
            string strMessage = string.Empty ;
            if (bll.checkUserInfo(model, ref strMessage))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                SysMessage.ErrorMsg(strMessage);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Application.Exit();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            DataTable dtUser = bll.getUserInfo();
            this.cboxUserName.DataSource = dtUser;
            this.cboxUserName.DisplayMember = "登录名";
            //this.cboxUserName.ValueMember = "密码";
        }
    }
}
