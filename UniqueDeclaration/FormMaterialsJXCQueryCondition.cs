using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration
{
    public partial class FormMaterialsJXCQueryCondition : UniqueDeclarationBaseForm.FormBaseQueryCondition
    {
        public FormMaterialsJXCQueryCondition()
        {
            InitializeComponent();
        }
        public string mdFromDate = string.Empty;
        public string mdToDate = string.Empty;
        public string mdFromDateString = string.Empty;
        public string mdToDateString = string.Empty;
        public string ManualCode = string.Empty;
        public int passvalue;
        public override void btnOK_Click(object sender, EventArgs e)
        {
            //base.btnOK_Click(sender, e);
            if (txt_料号.Text.Trim() != "")
            {
                base.strReturnWhere =string.Format( "@料号='%{0}%'",StringTools.SqlLikeQ(txt_料号.Text.Trim()));
            }
            if (datetime_入库时间1.Checked)
            {
                strReturnWhere += (strReturnWhere.Length > 0 ? "," : "") + string.Format("@期初时间='{0}'",datetime_入库时间1.Value.ToString("yyyymmdd hh:mm:ss"));
                mdFromDate = datetime_入库时间1.Value.ToString("yyyymmdd hh:mm:ss");
                mdFromDateString = datetime_入库时间1.Value.ToString("yyyymmdd hh:mm:ss");
            }
            if (datetime_入库时间2.Checked)
            {
                strReturnWhere += (strReturnWhere.Length > 0 ? "," : "") + string.Format("@期末时间='{0}'", datetime_入库时间2.Value.ToString("yyyymmdd hh:mm:ss"));
                mdToDate = datetime_入库时间2.Value.ToString("yyyymmdd hh:mm:ss");
                mdToDateString = datetime_入库时间2.Value.ToString("yyyymmdd hh:mm:ss");
            }
            if (cbox_电子帐册号.SelectedValue != DBNull.Value && cbox_电子帐册号.SelectedValue != DBNull.Value)
            {
                strReturnWhere += (strReturnWhere.Length > 0 ? "," : "") + string.Format("@电子帐册号='{0}'", cbox_电子帐册号.SelectedValue);
                ManualCode = cbox_电子帐册号.SelectedValue.ToString();
            }
            if (this.radioButton1.Checked)
            {
                passvalue = 1;
            }
            else if (this.radioButton2.Checked)
            {
                passvalue = 2;
            }
            else if (this.radioButton3.Checked)
            {
                passvalue = 3;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FormMaterialsJXCQueryCondition_Load(object sender, EventArgs e)
        {
            this.cbox_电子帐册号.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade, "SELECT 手册编号 FROM 手册资料表 ORDER BY 有效期限 DESC", "手册编号", "手册编号");
            datetime_入库时间1.Value =Convert.ToDateTime( "2008-11-1 00:00:00");
            datetime_入库时间2.Value = Convert.ToDateTime( DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
        }
    }
}
