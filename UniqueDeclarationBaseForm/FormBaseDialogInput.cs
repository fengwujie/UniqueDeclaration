using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;

namespace UniqueDeclarationBaseForm
{
    public partial class FormBaseDialogInput : Form
    {
        public FormBaseDialogInput()
        {
            InitializeComponent();
        }

        public string strFormText = string.Empty;

        public string strReturn = string.Empty;

        public string strDefault = string.Empty;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txt_input.Text.Trim().Length == 0)
            {
                SysMessage.InformationMsg("不允许输入空值！");
                txt_input.Focus();
                return;
            }
            strReturn = txt_input.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void FormBaseDialogInput_Load(object sender, EventArgs e)
        {
            this.Text = strFormText;
            this.txt_input.Text = strDefault;
        }
    }
}
