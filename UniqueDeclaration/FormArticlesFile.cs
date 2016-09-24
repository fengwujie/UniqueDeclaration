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
    public partial class FormArticlesFile : UniqueDeclarationBaseForm.FormBase
    {
        public FormArticlesFile()
        {
            InitializeComponent();
        }
        public string CustValue = string.Empty;
        private bool bcbox_Type_SelectedIndexChanged = true;
        private void FormArticlesFile_Load(object sender, EventArgs e)
        {
            bcbox_Type_SelectedIndexChanged = false;
            this.cbox_Type.InitialData(DataAccessEnum.DataAccessName.DataAccessName_Manufacture, "select * from sort order by 产品类别描述", "产品类别", "产品类别描述");
            bcbox_Type_SelectedIndexChanged = true;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtArticle = dataAccess.GetTable(string.Format("SELECT tabArticle.* FROM tabArticle where Cust like '%{0}%' ORDER BY Cust,SecondField",StringTools.SqlLikeQ(CustValue)),null);
            dataAccess.Close();
            this.myTabControl1.SelectedIndex = 1;
            this.myDataGridView1.DataSource = dtArticle;
            //if (myDataGridView1.RowCount > 0)
            //{
            //    this.myDataGridView1.Rows[0].Selected = true;
            //}
            this.myTabControl1.SelectedIndex = 0;
            setTool1Enabled();
            this.myDataGridView1_SelectionChanged(null, null);  //初期赋值时，不是GRID页签，CurrentRow为NULL，所以不能用这句
            //if (dtArticle.Rows.Count > 0)
            //    fillControl((myDataGridView1.Rows[0].DataBoundItem as DataRowView).Row);
            //else
            //    fillControl(null);

        }

        #region 菜单按钮事件
        private void tool1_First_Click(object sender, EventArgs e)
        {
            this.myDataGridView1.ClearSelection();
            this.myDataGridView1.Rows[0].Selected = true;
            this.myDataGridView1.CurrentCell = this.myDataGridView1.Rows[0].Cells["Cust"];
            setTool1Enabled();
        }

        private void tool1_up_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.myDataGridView1.CurrentRow.Index;
            this.myDataGridView1.ClearSelection();
            this.myDataGridView1.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridView1.CurrentCell = this.myDataGridView1.Rows[iSelectRow - 1].Cells["Cust"];
            setTool1Enabled();
        }

        private void tool1_Down_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.myDataGridView1.CurrentRow.Index;
            this.myDataGridView1.ClearSelection();
            this.myDataGridView1.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridView1.CurrentCell = this.myDataGridView1.Rows[iSelectRow + 1].Cells["Cust"];
            setTool1Enabled();
        }

        private void tool1_End_Click(object sender, EventArgs e)
        {
            this.myDataGridView1.ClearSelection();
            this.myDataGridView1.Rows[this.myDataGridView1.RowCount - 1].Selected = true;
            this.myDataGridView1.CurrentCell = this.myDataGridView1.Rows[this.myDataGridView1.RowCount - 1].Cells["Cust"];
            setTool1Enabled();
        }

        private void tool1_Add_Click(object sender, EventArgs e)
        {
            DataTable dtArticle = (DataTable)this.myDataGridView1.DataSource;
            DataRow newRow = dtArticle.NewRow();
            newRow["InputDate"] = DateTime.Now.Date;
            newRow["CostCurrencys"] = "USD";
            txt_Cust.Focus();
            dtArticle.Rows.Add(newRow);
            //this.myDataGridView1.Rows[this.myDataGridView1.RowCount - 1].Selected = true;
            this.myTabControl1.SelectedIndex=0;
            this.tool1_End_Click(null, null);
        }

        private void tool1_Save_Click(object sender, EventArgs e)
        {

        }

        private void tool1_Undo_Click(object sender, EventArgs e)
        {

        }

        private void tool1_Modify_Click(object sender, EventArgs e)
        {

        }

        private void tool1_Delete_Click(object sender, EventArgs e)
        {

        }

        private void tool1_Query_Click(object sender, EventArgs e)
        {

        }

        private void tool1_Print_Click(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 设置tools的按钮是否可用
        /// </summary>
        private void setTool1Enabled()
        {
            this.tool1_Query.Enabled = true;
            this.tool1_Add.Enabled = true;
            //DataTable dtTable = (DataTable)myDataGridView1.DataSource;
            if (this.myDataGridView1.RowCount > 0)
            {
                this.tool1_Save.Enabled = true;
                this.tool1_Undo.Enabled = true;
                this.tool1_Delete.Enabled = true;
                this.tool1_Modify.Enabled = true;
                this.tool1_Print.Enabled = true;
                this.btnCopy.Enabled = true;
                //如果总行数为1时，则笔数移动按钮都为不可编辑
                if (this.myDataGridView1.RowCount == 1)
                {
                    this.tool1_First.Enabled = false;
                    this.tool1_up.Enabled = false;
                    this.tool1_Down.Enabled = false;
                    this.tool1_End.Enabled = false;
                }
                else
                {
                    //如果当前行索引为0
                    if (this.myDataGridView1.CurrentRow == null) return;
                    if (this.myDataGridView1.CurrentRow.Index == 0)
                    {
                        this.tool1_First.Enabled = false;
                        this.tool1_up.Enabled = false;
                        this.tool1_Down.Enabled = true;
                        this.tool1_End.Enabled = true;
                    }
                    else if (this.myDataGridView1.CurrentRow.Index == this.myDataGridView1.RowCount - 1)  //如果行索引为最后一行
                    {
                        this.tool1_First.Enabled = true;
                        this.tool1_up.Enabled = true;
                        this.tool1_Down.Enabled = true;
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
            }
            else
            {
                this.tool1_First.Enabled = false;
                this.tool1_up.Enabled = false;
                this.tool1_Down.Enabled = false;
                this.tool1_End.Enabled = false;

                this.tool1_Save.Enabled = false;
                this.tool1_Undo.Enabled = false;
                this.tool1_Delete.Enabled = false;
                this.tool1_Modify.Enabled = false;
                this.tool1_Print.Enabled = false;
                this.btnCopy.Enabled = false;
            }
        }
        #endregion

        private void myDataGridView1_SelectionChanged(object sender, EventArgs e)
        {            
            //if (this.myDataGridView1.CurrentRowNew == null)
            //    fillControl(null);
            //else
            //    fillControl((myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row);
            fillControl(this.myDataGridView1.CurrentRowNew);
            setTool1Enabled();
        }

        private void fillControl(DataGridViewRow dgvRow)
        {
            if (dgvRow == null)
            {
                txt_Cust.Text = string.Empty;
                txt_Cust_Lab.Text = string.Empty;
                txt_SecondField.Text = string.Empty;
                date_InputDate.Value = DateTime.Now.Date;
                txt_KeyField.Text = string.Empty;
                txt_Cost.Text = string.Empty;
                txt_CostCurrencys.Text = "USD";
                txt_Colors.Text = string.Empty;
                txt_Price.Text = string.Empty;
                txt_Currencys.Text = string.Empty;
                txt_Descript.Text = string.Empty;
                txt_typesort.Text = string.Empty;
                txt_Unit.Text = string.Empty;
                cbox_Type.SelectedIndex = -1;
                txt_Weight.Text = string.Empty;
                txt_UnitN.Text = string.Empty;
                txt_Packing.Text = string.Empty;
                txt_Remark.Text = string.Empty;
                txt_Remark1.Text = string.Empty;
                txt_Remark2.Text = string.Empty;
                txt_Remark3.Text = string.Empty;
                txt_Notice.Text = string.Empty;
            }
            else
            {
                DataRow row = (dgvRow.DataBoundItem as DataRowView).Row;
                txt_Cust.Text = row["Cust"].ToString();
                txt_Cust_Lab.Text = row["Cust_Lab"].ToString();
                txt_SecondField.Text = row["SecondField"].ToString();
                if (row["InputDate"] == DBNull.Value)
                {
                    date_InputDate.Checked =false;
                }
                else
                {
                    date_InputDate.Value = Convert.ToDateTime(row["InputDate"]);
                }
                txt_KeyField.Text = row["KeyField"].ToString();
                txt_Cost.Text = row["Cost"] == DBNull.Value ? string.Empty : row["Cost"].ToString();
                txt_CostCurrencys.Text = row["CostCurrencys"].ToString();
                txt_Colors.Text = row["Colors"].ToString();
                txt_Price.Text = row["Price"] == DBNull.Value ? string.Empty : row["Price"].ToString();
                txt_Currencys.Text = row["Currencys"].ToString();
                txt_Descript.Text = row["Descript"].ToString();
                txt_typesort.Text = row["typesort"].ToString();
                txt_Unit.Text = row["Unit"].ToString();
                if (row["Type"] == DBNull.Value)
                {
                    cbox_Type.SelectedIndex = -1;
                }
                else
                {
                    cbox_Type.SelectedValue = row["Type"].ToString();
                }
                txt_Weight.Text = row["Weight"] == DBNull.Value ? string.Empty : row["Weight"].ToString();
                txt_UnitN.Text = row["UnitN"].ToString();
                txt_Packing.Text = row["Packing"].ToString();
                txt_Remark.Text = row["Remark"].ToString();
                txt_Remark1.Text = row["Remark1"].ToString();
                txt_Remark2.Text = row["Remark2"].ToString();
                txt_Remark3.Text = row["Remark3"].ToString();
                txt_Notice.Text = row["Notice"].ToString();
            }
        }

        #region 表头控件事件
        private void txt_Cust_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Cust"].ToString() != txt_Cust.Text.Trim())
            {
                row["Cust"] = txt_Cust.Text.Trim();
            }
        }

        private void txt_Cust_Lab_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Cust_Lab"].ToString() != txt_Cust_Lab.Text.Trim())
            {
                row["Cust_Lab"] = txt_Cust_Lab.Text.Trim();
            }
        }

        private void txt_SecondField_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["SecondField"].ToString() != txt_SecondField.Text.Trim())
            {
                row["SecondField"] = txt_SecondField.Text.Trim();
            }
        }

        private void date_InputDate_ValueChanged(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (date_InputDate.Checked)
            {
                if (row["InputDate"] == DBNull.Value || Convert.ToDateTime(row["InputDate"]) != date_InputDate.Value)
                    row["InputDate"] = date_InputDate.Value;
            }
            else
            {
                if (row["InputDate"] != DBNull.Value)
                    row["InputDate"] = DBNull.Value;
            }
        }

        private void txt_KeyField_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["KeyField"].ToString() != txt_KeyField.Text.Trim())
            {
                row["KeyField"] = txt_KeyField.Text.Trim();
            }
        }

        private void txt_Cost_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txt_Cost.Text.Trim().Length > 0)
                {
                    float.Parse(txt_Cost.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                SysMessage.ErrorMsg(ex.Message);
            }
        }

        private void txt_Cost_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Cost"].ToString() != txt_Cost.Text.Trim())
            {
                row["Cost"] = txt_Cost.Text.Trim();
            }
        }

        private void txt_CostCurrencys_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["CostCurrencys"].ToString() != txt_CostCurrencys.Text.Trim())
            {
                row["CostCurrencys"] = txt_CostCurrencys.Text.Trim();
            }
        }

        private void txt_Colors_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Colors"].ToString() != txt_Colors.Text.Trim())
            {
                row["Colors"] = txt_Colors.Text.Trim();
            }
        }

        private void txt_Price_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txt_Price.Text.Trim().Length > 0)
                {
                    float.Parse(txt_Price.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                SysMessage.ErrorMsg(ex.Message);
            }
        }

        private void txt_Price_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Price"].ToString() != txt_Price.Text.Trim())
            {
                row["Price"] = txt_Price.Text.Trim();
            }
        }

        private void txt_Currencys_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Currencys"].ToString() != txt_Currencys.Text.Trim())
            {
                row["Currencys"] = txt_Currencys.Text.Trim();
            }
        }

        private void txt_Descript_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Descript"].ToString() != txt_Descript.Text.Trim())
            {
                row["Descript"] = txt_Descript.Text.Trim();
            }
        }

        private void txt_typesort_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["typesort"].ToString() != txt_typesort.Text.Trim())
            {
                row["typesort"] = txt_typesort.Text.Trim();
            }
        }

        private void txt_Unit_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Unit"].ToString() != txt_Unit.Text.Trim())
            {
                row["Unit"] = txt_Unit.Text.Trim();
            }
        }

        private void cbox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bcbox_Type_SelectedIndexChanged) return;
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (cbox_Type.SelectedValue == null && row["Type"] == DBNull.Value) return;
            if (cbox_Type.SelectedValue == null)
            {
                row["Type"] = DBNull.Value;
            }
            else if (row["Type"].ToString() != cbox_Type.SelectedValue.ToString())
            {
                if (cbox_Type.SelectedIndex == -1 || cbox_Type.SelectedValue == null)
                {
                    row["Type"] = DBNull.Value;
                }
                else
                {
                    row["Type"] = cbox_Type.SelectedValue;
                }
            }
        }

        private void txt_Weight_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txt_Weight.Text.Trim().Length > 0)
                {
                    float.Parse(txt_Weight.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                SysMessage.ErrorMsg(ex.Message);
            }
        }

        private void txt_Weight_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Weight"].ToString() != txt_Weight.Text.Trim())
            {
                row["Weight"] = txt_Weight.Text.Trim();
            }
        }

        private void txt_UnitN_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["UnitN"].ToString() != txt_UnitN.Text.Trim())
            {
                row["UnitN"] = txt_UnitN.Text.Trim();
            }
        }

        private void txt_Packing_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Packing"].ToString() != txt_Packing.Text.Trim())
            {
                row["Packing"] = txt_Packing.Text.Trim();
            }
        }

        private void txt_Remark_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Remark"].ToString() != txt_Remark.Text.Trim())
            {
                row["Remark"] = txt_Remark.Text.Trim();
            }
        }

        private void txt_Remark1_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Remark1"].ToString() != txt_Remark1.Text.Trim())
            {
                row["Remark1"] = txt_Remark1.Text.Trim();
            }
        }

        private void txt_Remark2_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Remark2"].ToString() != txt_Remark2.Text.Trim())
            {
                row["Remark2"] = txt_Remark2.Text.Trim();
            }
        }

        private void txt_Remark3_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Remark3"].ToString() != txt_Remark3.Text.Trim())
            {
                row["Remark3"] = txt_Remark3.Text.Trim();
            }
        }

        private void txt_Notice_Validated(object sender, EventArgs e)
        {
            DataRow row = (this.myDataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            if (row["Notice"].ToString() != txt_Notice.Text.Trim())
            {
                row["Notice"] = txt_Notice.Text.Trim();
            }
        }
        #endregion

        private void myDataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

    }
}
