using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration
{
    public partial class FormArticlesFile_ExportExcel : UniqueDeclarationBaseForm.FormBase
    {
        public FormArticlesFile_ExportExcel()
        {
            InitializeComponent();
        }
        public string strSecondFieldBeingExcel = string.Empty;
        public string strSecondFieldEndExcel = string.Empty;
        public string strKeyFieldBeingExcel = string.Empty;
        public string strKeyFieldEndExcel = string.Empty;
        public string strCustExcel = string.Empty;
        private void FormArticlesFile_ExportExcel_Load(object sender, EventArgs e)
        {
            txt_Cust.Text = strCustExcel;
            txt_KeyFieldBegin.Text = strKeyFieldBeingExcel;
            txt_KeyFieldEnd.Text = strKeyFieldEndExcel;
            txt_SecondFieldBegin.Text = strSecondFieldBeingExcel;
            txt_SecondFieldEnd.Text = strSecondFieldEndExcel;
            this.txt_SecondFieldBegin.GotFocus += new System.EventHandler(this.txt_SecondFieldBegin_GotFocus);
            this.txt_SecondFieldEnd.GotFocus += new System.EventHandler(this.txt_SecondFieldEnd_GotFocus);
            this.txt_KeyFieldBegin.GotFocus += new System.EventHandler(this.txt_KeyFieldBegin_GotFocus);
            this.txt_KeyFieldEnd.GotFocus += new System.EventHandler(this.txt_KeyFieldEnd_GotFocus);
            this.txt_Cust.GotFocus += new System.EventHandler(this.txt_Cust_GotFocus);
        }

        private void txt_SecondFieldBegin_GotFocus(object sender, EventArgs e)
        {
            txt_SecondFieldBegin.SelectAll();
        }
        private void txt_SecondFieldEnd_GotFocus(object sender, EventArgs e)
        {
            if (txt_SecondFieldEnd.Text.Trim().Length == 0)
                txt_SecondFieldEnd.Text = txt_SecondFieldBegin.Text;
            txt_SecondFieldEnd.SelectAll();
        }
        private void txt_KeyFieldBegin_GotFocus(object sender, EventArgs e)
        {
            txt_KeyFieldBegin.SelectAll();
        }
        private void txt_KeyFieldEnd_GotFocus(object sender, EventArgs e)
        {
            if (txt_KeyFieldEnd.Text.Trim().Length == 0)
                txt_KeyFieldEnd.Text = txt_KeyFieldBegin.Text;
            txt_KeyFieldEnd.SelectAll();
        }
        private void txt_Cust_GotFocus(object sender, EventArgs e)
        {
            txt_Cust.SelectAll();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            strCustExcel = txt_Cust.Text.Trim();
            strKeyFieldBeingExcel = txt_KeyFieldBegin.Text.Trim();
            strKeyFieldEndExcel = txt_KeyFieldEnd.Text.Trim();
            strSecondFieldBeingExcel = txt_SecondFieldBegin.Text.Trim();
            strSecondFieldEndExcel = txt_SecondFieldEnd.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
