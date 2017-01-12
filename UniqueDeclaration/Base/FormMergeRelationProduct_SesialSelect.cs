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
    public partial class FormMergeRelationProduct_SesialSelect : UniqueDeclarationBaseForm.FormBase
    {
        public FormMergeRelationProduct_SesialSelect()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 序号起始
        /// </summary>
        public int iSerialBegin = 0;
        /// <summary>
        /// 序号终止
        /// </summary>
        public int iSerialEnd = 0;
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                iSerialBegin = int.Parse(txt_SerialBegin.Text.Trim());
                iSerialEnd = int.Parse(txt_SerialEnd.Text.Trim());
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch
            {
                SysMessage.InformationMsg("序号必须是整数型！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
