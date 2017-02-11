using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration.Base
{
    public partial class FormCodeSelect : UniqueDeclarationBaseForm.FormBase
    {
        public FormCodeSelect()
        {
            InitializeComponent();
        }
        public long lStartNo = 0;
        public long iCount = 0;
        private void FormCodeSelect_Load(object sender, EventArgs e)
        {
            this.myTextBox1.Text = lStartNo.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.myTextBox2.Text.Trim() == "")
            {
                SysMessage.InformationMsg(string.Format("【{0}】不允许为空！",this.myLable2.Text));
                return;
            }
            if (this.myTextBox2.Text.Trim() == "0")
            {
                SysMessage.InformationMsg(string.Format("【{0}】必须大于0！", this.myLable2.Text));
                return;
            }
            iCount = Convert.ToInt64(this.myTextBox2.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void myTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int iCount = int.Parse(this.myTextBox2.Text);
                this.myTextBox3.Text =( Convert.ToInt64(myTextBox1.Text) + iCount-1).ToString();
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(ex.Message);
            }
        }
    }
}
