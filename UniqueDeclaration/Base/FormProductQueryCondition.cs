using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration.Base
{
    public partial class FormProductQueryCondition : UniqueDeclarationBaseForm.FormBaseQueryCondition
    {
        public FormProductQueryCondition()
        {
            InitializeComponent();
        }

        public bool abOK = false;

        private void FormFitQueryCondition_Load(object sender, EventArgs e)
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("产品类别", typeof(string));
            dtTemp.Columns.Add("产品类别名称", typeof(string));
            DataRow newRow1 = dtTemp.NewRow();
            newRow1["产品类别"] = "A";
            newRow1["产品类别名称"] = "A";
            dtTemp.Rows.Add(newRow1);
            DataRow newRow2 = dtTemp.NewRow();
            newRow2["产品类别"] = "B";
            newRow2["产品类别名称"] = "B";
            dtTemp.Rows.Add(newRow2);
            DataRow newRow3 = dtTemp.NewRow();
            newRow3["产品类别"] = "AB";
            newRow3["产品类别名称"] = "AB";
            dtTemp.Rows.Add(newRow3);
            this.cbox_产品类别.InitialData(dtTemp, "产品类别", "产品类别名称", -1);

            datetime_产品建档日期1.Value = Convert.ToDateTime(string.Format("{0} 00:00:01", DateTime.Now.ToShortDateString()));
            datetime_产品建档日期2.Value = Convert.ToDateTime(string.Format("{0} 23:59:59", DateTime.Now.ToShortDateString()));
            datetime_产品建档日期1.Checked = false;
            datetime_产品建档日期2.Checked = false;
        }

        public override void btnOK_Click(object sender, EventArgs e)
        {
            if (cbox_产品类别.SelectedValue != null && cbox_产品类别.SelectedValue.ToString() == "AB")
            {
                abOK = true;
            }
            else
            {
                abOK = false;
            }
            base.btnOK_Click(sender, e);
        }

        public override void BeforeBaseWhere()
        {
            base.BeforeBaseWhere();
            if (cbox_产品类别.SelectedValue != null && cbox_产品类别.SelectedValue.ToString() == "AB")
            {
                strReturnWhere = " 产品id > 0 and not (A.产品A is null) ";
            }
            else
            {
                strReturnWhere = " 产品id> 0 ";
            }
        }
    }
}
