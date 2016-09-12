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
    public partial class FormOuterMaterialTotalQueryCondition : UniqueDeclarationBaseForm.FormBaseQueryCondition
    {
        public FormOuterMaterialTotalQueryCondition()
        {
            InitializeComponent();
        }
        public string mstrFilterString = string.Empty;
        public override void btnOK_Click(object sender, EventArgs e)
        {
            //base.btnOK_Click(sender, e);
            mstrFilterString=string.Empty;
            if(txt_订单号码.Text.Trim().Length>0)
                mstrFilterString = string.Format("@订单号码='%{0}%'", StringTools.SqlLikeQ(txt_订单号码.Text.Trim()));
            if(date_出货日期1.Checked)
                mstrFilterString = (mstrFilterString.Length > 0 ? "," : "") + string.Format("@开始日期=''", date_出货日期1.Value.ToString("YYYYMMDD"));
            if(date_出货日期2.Checked)
                mstrFilterString = (mstrFilterString.Length > 0 ? "," : "") + string.Format("@结束日期=''", date_出货日期2.Value.ToString("YYYYMMDD"));
            if(myCheckBox2.Checked)
                mstrFilterString = (mstrFilterString.Length > 0 ? ",@类别=1" : "");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public override void btnCancel_Click(object sender, EventArgs e)
        {
            mstrFilterString = string.Empty;
            base.btnCancel_Click(sender, e);
        }
    }
}
