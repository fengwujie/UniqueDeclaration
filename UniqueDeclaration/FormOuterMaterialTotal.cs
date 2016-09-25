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
    public partial class FormOuterMaterialTotal : UniqueDeclarationBaseForm.FormBase
    {
        public FormOuterMaterialTotal()
        {
            InitializeComponent();
        }

        public string mstrFilterString = string.Empty;

        private DataTable dtData = null;
        private void FormOuterMaterialTotal_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void LoadDataSource()
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            dtData = dataAccess.GetTable(string.Format("出口料件统计 {0}", mstrFilterString), null);
            dataAccess.Close();
            if (!mstrFilterString.Contains("类别"))
                this.myDataGridViewHead.Columns["成品名称及商编"].Visible = false;
            DataTableTools.AddEmptyRow(dtData);
            this.myDataGridViewHead.DataSource = dtData;
            setTool1Enabled();
        }

        private void tool1_First_Click(object sender, EventArgs e)
        {
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells["手册编号"];
            setTool1Enabled();
        }

        private void tool1_up_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells["手册编号"];
            setTool1Enabled();

        }

        private void tool1_Down_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells["手册编号"];
            setTool1Enabled();
        }

        private void tool1_End_Click(object sender, EventArgs e)
        {
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells["手册编号"];
            setTool1Enabled();
        }

        private void tool1_Query_Click(object sender, EventArgs e)
        {
            FormOuterMaterialTotalQueryCondition objForm = new FormOuterMaterialTotalQueryCondition();
            if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadDataSource();
            }
        }

        private void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            ExcelCommonMethod.ExportIntoExcel(dtData, "出库料件统计");
        }

        /// <summary>
        /// 设置tools的按钮是否可用
        /// </summary>
        private void setTool1Enabled()
        {
            this.tool1_Query.Enabled = true;
            DataTable dtTable = (DataTable)myDataGridViewHead.DataSource;
            if (dtTable.Rows.Count > 0)
            {
                //如果总行数为1时，则笔数移动按钮都为不可编辑
                if (dtTable.Rows.Count == 1)
                {
                    this.tool1_First.Enabled = false;
                    this.tool1_up.Enabled = false;
                    this.tool1_Down.Enabled = false;
                    this.tool1_End.Enabled = false;
                }
                else
                {
                    //如果当前行索引为0
                    if (this.myDataGridViewHead.CurrentRow == null) return;
                    if (this.myDataGridViewHead.CurrentRow.Index == 0)
                    {
                        this.tool1_First.Enabled = false;
                        this.tool1_up.Enabled = false;
                        this.tool1_Down.Enabled = true;
                        this.tool1_End.Enabled = true;
                    }
                    else if (this.myDataGridViewHead.CurrentRow.Index == this.myDataGridViewHead.RowCount - 1)  //如果行索引为最后一行
                    {
                        this.tool1_First.Enabled = true;
                        this.tool1_up.Enabled = true;
                        this.tool1_Down.Enabled = false;
                        this.tool1_End.Enabled = false;
                    }
                    else
                    {
                        this.tool1_First.Enabled = true;
                        this.tool1_up.Enabled = true;
                        this.tool1_Down.Enabled = true;
                        this.tool1_End.Enabled = true;
                    }
                }
                this.tool1_ExportExcel.Enabled = true;
            }
            else
            {
                this.tool1_First.Enabled = false;
                this.tool1_up.Enabled = false;
                this.tool1_Down.Enabled = false;
                this.tool1_End.Enabled = false;
                this.tool1_ExportExcel.Enabled = false;
            }
        }
    }
}
