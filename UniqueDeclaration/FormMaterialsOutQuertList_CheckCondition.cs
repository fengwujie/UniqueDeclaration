using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration
{
    public partial class FormMaterialsOutQuertList_CheckCondition : UniqueDeclarationBaseForm.FormBase
    {
        public FormMaterialsOutQuertList_CheckCondition()
        {
            InitializeComponent();
        }

        
        public string mstrFilterString=string.Empty;
        public string ManualCode= string.Empty;
        public int passvalue = 0;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                passvalue = 1;
            }
            else if(this.radioButton1.Checked)
            {
                passvalue = 2;
            }
            mstrFilterString = "@电子帐册号='" + this.myComboBox1.SelectedValue +  "'";
            ManualCode = this.myComboBox1.SelectedValue.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void FormMaterialsOutQuertList_CheckCondition_Load(object sender, EventArgs e)
        {
            this.myComboBox1.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Manufacture, "SELECT distinct 手册编号 FROM 报关订单表 where isnull(手册编号,'')<>''", "手册编号", "手册编号");

        }
    }
}
