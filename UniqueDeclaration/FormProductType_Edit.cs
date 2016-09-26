using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;
using DataAccess;

namespace UniqueDeclaration
{
    public partial class FormProductType_Edit : UniqueDeclarationBaseForm.FormBase
    {
        public FormProductType_Edit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// LABLE文本说明
        /// </summary>
        public string strLable = string.Empty;
        /// <summary>
        /// 当前产品类别ID
        /// </summary>
        public int itypeID=0;
        /// <summary>
        /// 父级产品ID
        /// </summary>
        public int iParentTypeID = 0;
        /// <summary>
        /// 当前产品类别描述
        /// </summary>
        public string strTypeText = string.Empty;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (myTextBox1.Text.Trim().Length == 0)
            {
                SysMessage.InformationMsg("产品类别不允许为空！");
                return;
            }
            string strSQL = string.Empty;
            if (itypeID == 0) //新增
            {
                strSQL = string.Format("INSERT INTO [产品类别表]([产品类别],[产品类别描述])VALUES({0},{1})", iParentTypeID == 0 ? "NULL" : iParentTypeID.ToString(), StringTools.SqlQ(myTextBox1.Text.Trim()));
            }
            else
            {
                if (this.strTypeText == this.myTextBox1.Text.Trim())
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    return;
                }
                if (SysMessage.YesNoMsg("确定要修改？") == System.Windows.Forms.DialogResult.No)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    return;
                }
                strSQL = string.Format("UPDATE [产品类别表] SET [产品类别描述] ={0} WHERE 产品类别ID={1}",StringTools.SqlQ(myTextBox1.Text.Trim()),itypeID);
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dataAccess.ExecuteNonQuery(strSQL, null);
            dataAccess.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void FormProductType_Edit_Load(object sender, EventArgs e)
        {
            this.myLable1.Text = strLable;
            this.myTextBox1.Text = strTypeText;
            this.myTextBox1.SelectAll();
        }
    }
}
