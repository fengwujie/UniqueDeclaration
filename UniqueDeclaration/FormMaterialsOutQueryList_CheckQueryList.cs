using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration
{
    public partial class FormMaterialsOutQueryList_CheckQueryList : UniqueDeclarationBaseForm.FormBase
    {
        public FormMaterialsOutQueryList_CheckQueryList()
        {
            InitializeComponent();
        }

        public string ManualCode = string.Empty;
        public int InId = 0;
        public int passvalue = 0;
        public int InOutvalue = 0;
        private void FormMaterialsOutQueryList_CheckQueryList_Load(object sender, EventArgs e)
        {
            string strSQL = string.Empty;
            if (InOutvalue == 1)
            {
                strSQL = string.Format("报关进口料件数量转换统计 @id={0},@电子帐册号='{1}',@类别={2}", InId, ManualCode, passvalue);
            }
            else
            {
                strSQL = string.Format("报关出口料件数量转换统计 @id={0},@电子帐册号='{1}',@类别={2}", InId, ManualCode, passvalue);
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            this.myDataGridView1.DataSource = dtData;

            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridView1.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMenuStripCell1;
            }

        }

        private void tool_ExportExcel_Click(object sender, EventArgs e)
        {
            DataTable dtData = (DataTable)this.myDataGridView1.DataSource;
            if (dtData.Rows.Count > 0)
            {
                ExcelCommonMethod.ExportIntoExcel(dtData, "");
            }
        }
    }
}
