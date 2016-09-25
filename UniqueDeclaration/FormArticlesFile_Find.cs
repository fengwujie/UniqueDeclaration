using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration
{
    public partial class FormArticlesFile_Find : UniqueDeclarationBaseForm.FormBase
    {
        public FormArticlesFile_Find()
        {
            InitializeComponent();
        }

        public string gstrCust = string.Empty;
        public string gstrSecondField = string.Empty;
        public string gstrKeyField = string.Empty;
        public string gstrColors = string.Empty;

        private void btnOK_Click(object sender, EventArgs e)
        {
            gstrCust = this.txt_Cust.Text.Trim();
            gstrSecondField = txt_SecondField.Text.Trim();
            gstrKeyField = txt_KeyField.Text.Trim();
            gstrColors = txt_Colors.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void FormArticlesFile_Find_Load(object sender, EventArgs e)
        {
            this.txt_Cust.Text = gstrCust;
            this.txt_SecondField.Text = gstrSecondField;
            this.txt_KeyField.Text = gstrKeyField;
            this.txt_Colors.Text = gstrColors;
        }
    }
}
