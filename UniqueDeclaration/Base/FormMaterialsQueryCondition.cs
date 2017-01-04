using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration.Base
{
    public partial class FormMaterialsQueryCondition : UniqueDeclarationBaseForm.FormBaseQueryCondition
    {
        public FormMaterialsQueryCondition()
        {
            InitializeComponent();
        }

        private void FormMaterialsQueryList_Load(object sender, EventArgs e)
        {
            this.cbox_料件类别.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Manufacture, "SELECT [料件类别],[料件类别说明] FROM [料件类别表]", "料件类别", "料件类别说明",-1);
            this.cbox_报关类别.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Manufacture, "select 料件报关分类 as 报关类别 from 料件报关分类 order by 料件报关分类", "报关类别", "报关类别", -1);
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("采购区域", typeof(string));
            dtTemp.Columns.Add("采购区域名称", typeof(string));
            DataRow newRow1 = dtTemp.NewRow();
            newRow1["采购区域"] = "国内";
            newRow1["采购区域名称"] = "国内";
            dtTemp.Rows.Add(newRow1);
            DataRow newRow2 = dtTemp.NewRow();
            newRow2["采购区域"] = "国外";
            newRow2["采购区域名称"] = "国外";
            dtTemp.Rows.Add(newRow2);
            this.cbox_采购区域.InitialData(dtTemp, "采购区域", "采购区域名称", -1);

            datetime_料件建档日期1.Value =Convert.ToDateTime( string.Format("{0} 00:00:01", DateTime.Now.ToShortDateString()));
            datetime_料件建档日期2.Value = Convert.ToDateTime(string.Format("{0} 23:59:59", DateTime.Now.ToShortDateString()));
            datetime_料件建档日期1.Checked = false;
            datetime_料件建档日期2.Checked = false;
        }
    }
}
