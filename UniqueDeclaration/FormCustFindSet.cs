using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration
{
    public partial class FormCustFindSet : UniqueDeclarationBaseForm.FormBase
    {
        public FormCustFindSet()
        {
            InitializeComponent();
        }
        public string CustValue = string.Empty;
        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (txt_CustNo.Text.Trim().Length == 0)
            //{
            //    CustValue = "%";
            //}
            //else
            //{
            //    CustValue = txt_CustNo.Text.Trim();
            //}
            CustValue = txt_CustNo.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void FormCustFindSet_Load(object sender, EventArgs e)
        {
            this.txt_CustNo.Focus();
        }
    }
}
