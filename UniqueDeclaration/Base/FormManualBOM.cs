using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;
using UniqueDeclarationBaseForm.Controls;
using UniqueDeclarationBaseForm;

namespace UniqueDeclaration.Base
{
    public partial class FormManualBOM : Form
    {
        public FormManualBOM()
        {
            InitializeComponent();
        }

        #region 外部传进来的变量
        /// <summary>
        /// 手册id
        /// </summary>
        public int mIntID = 0;
        /// <summary>
        /// 手册编号       
        /// </summary>
        public string mstrNo = string.Empty;
        /// <summary>
        /// 出口成品id
        /// </summary>
        public int mnPId = 0;
        /// <summary>
        /// 品名规格型号
        /// </summary>
        public string mstrName = string.Empty;
        #endregion

        #region 自定义变量
        /// <summary>
        /// 控制是否触发单元格回车事件，如果是回车事件后，指定到某个单元格，这种情况下就不再触发回车事件
        /// </summary>
        private bool bCellKeyPress = true;
        /// <summary>
        /// 是否触发单元格结束编辑事件
        /// </summary>
        private bool bCellEndEdit = true;
        /// <summary>
        /// 数据集
        /// </summary>
        private DataTable dtBOM = null;
        #endregion

        #region 窗体事件
        private void FormManualBOM_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} 结构组成",mstrName);

            LoadDataSourceBOM();
            initGrid();
        }

        private void FormManualBOM_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveBOM();
        }
        #endregion

        #region 初始化GRID
        private void initGrid()
        {
            this.myDataGridViewBOM.Columns["产品组成表id"].Visible = false;
            this.myDataGridViewBOM.Columns["出口成品id"].Visible = false;
            this.myDataGridViewBOM.Columns["进口料件id"].Visible = false;
            this.myDataGridViewBOM.Columns["手册id"].Visible = false;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "F3";
            dataGridViewCellStyle1.NullValue = null;
            this.myDataGridViewBOM.Columns["数量"].DefaultCellStyle = dataGridViewCellStyle1;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewBOM.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextBOM;
            }
        }
        #endregion

        #region 按钮事件
        private void tool_Save_Click(object sender, EventArgs e)
        {
            SaveBOM();

        }

        private void tool_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.myDataGridViewBOM.CurrentRow != null)
            {
                this.myDataGridViewBOM.Rows.RemoveAt(this.myDataGridViewBOM.CurrentRow.Index);
            }
            if (this.myDataGridViewBOM.CurrentRow == null)
            {
                dtBOMAddRow();
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadDataSourceBOM()
        {
            string strSQL = string.Format(@"SELECT 产品组成表.产品组成表id, 产品组成表.出口成品id,产品组成表.进口料件id, 进口料件表.手册id, 手册资料表.手册编号,
         进口料件表.序号 as 项号,进口料件表.商品编号 , 进口料件表.品名规格型号, 产品组成表.数量, 进口料件表.单位, 产品组成表.备注 
         FROM 产品组成表 INNER JOIN 进口料件表 ON 产品组成表.进口料件id = 进口料件表.进口料件id INNER JOIN 手册资料表 ON 进口料件表.手册id = 手册资料表.手册id where 产品组成表.出口成品id={0} ", mnPId);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            dtBOM = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtBOM.Rows.Count == 0)
            {
                dtBOM.Rows.Add(dtBOM.NewRow());
                dtBOM.Rows[0]["手册编号"] = mstrNo;
                dtBOM.Rows[0]["手册id"] = mIntID;
                dtBOM.Rows[0]["出口成品id"] = mnPId;
            }
            this.myDataGridViewBOM.DataSource = dtBOM;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveBOM()
        {
            try
            {
                string strSQL = string.Empty;
                foreach (DataRow row in dtBOM.Rows)
                {
                    #region 新增行
                    if (row.RowState == DataRowState.Added)
                    {
                        if (row["进口料件id"] == DBNull.Value) continue;
                        strSQL += string.Format(@"INSERT INTO [产品组成表]([出口成品id],[进口料件id],[数量],[备注])
                                         VALUES({0},{1},{2},{3})" + Environment.NewLine,
                                             row["出口成品id"] == DBNull.Value ? "NULL" : row["出口成品id"],
                                             row["进口料件id"] == DBNull.Value ? "NULL" : row["进口料件id"],
                                             row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                             row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()));
                    }
                    #endregion

                    #region 删除行
                    else if (row.RowState == DataRowState.Deleted)
                    {
                        if (row["产品组成表id", DataRowVersion.Original] == DBNull.Value) continue;
                        strSQL += string.Format("DELETE FROM [产品组成表] WHERE 产品组成表id={0}" + Environment.NewLine, row["产品组成表id", DataRowVersion.Original]);
                    }
                    #endregion

                    #region 修改行
                    else if (row.RowState == DataRowState.Modified)
                    {
                        if (row["产品组成表id"] == DBNull.Value) continue;
                        strSQL += string.Format(@"UPDATE [产品组成表] SET [出口成品id] ={0},[进口料件id] = {1},[数量] = {2},[备注] = {3}
                                                 WHERE 产品组成表id={4}",
                                             row["出口成品id"] == DBNull.Value ? "NULL" : row["出口成品id"],
                                             row["进口料件id"] == DBNull.Value ? "NULL" : row["进口料件id"],
                                             row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                             row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()),
                                             row["产品组成表id"] == DBNull.Value ? "NULL" : row["产品组成表id"]);
                    }
                    #endregion
                }
                if (strSQL.Length > 0)
                {
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                    dataAccess.Open();
                    dataAccess.ExecuteNonQuery(strSQL, null);
                    dataAccess.Close();
                    dtBOM.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(ex.Message);
            }
        }
        /// <summary>
        /// BOM-GRID增加一条新行
        /// </summary>
        private void dtBOMAddRow()
        {
            DataRow newRow = dtBOM.NewRow();
            newRow["手册id"] = mIntID;
            newRow["手册编号"] = mstrNo;
            newRow["出口成品id"] = mnPId;
            dtBOM.Rows.Add(newRow);
        }
        #endregion

        #region GRID事件
        private void myDataGridViewBOM_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridKeyEnter(dgv, cell, false);
        }

        private void myDataGridViewBOM_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            myDataGridView dgv = (myDataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "数量")
                e.Cancel = false;
        }

        private void myDataGridViewBOM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == SystemConst.GridKeysEnter)
            {
                myDataGridView dgv = sender as myDataGridView;
                DataGridViewCell cell = dgv.CurrentCell;
                GridKeyEnter(dgv, cell, true);
            }
        }
        /// <summary>
        /// GRID的回车事件
        /// </summary>
        /// <param name="dgv">Grid对象</param>
        /// <param name="cell">焦点CELL</param>
        /// <param name="bKeyEnter">是否按回车触发的事件</param>
        private void GridKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
        {
            if (!bCellKeyPress) return;
            string colName = dgv.Columns[cell.ColumnIndex].Name;
            switch (colName)
            {
                case "手册编号":  //跳转到商品编号
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["手册编号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["商品编号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate手册编号(dgv, cell))
                        {
                            //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["商品编号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["手册编号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate手册编号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "商品编号":  //跳转数量
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["商品编号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate商品编号(dgv, cell))
                        {
                            //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["商品编号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate商品编号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "品名规格型号": //跳转数量
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["品名规格型号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate品名规格型号(dgv, cell))
                        {
                            //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["品名规格型号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate品名规格型号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "数量":  //跳转到备注
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["数量"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate数量(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["数量"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate数量(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "备注":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        validate备注(dgv, cell);
                        (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                    }
                    #endregion
                    break;
                case "项号":   //跳转到"商品编号"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品编号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "单位":   //跳转到"备注"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["备注", cell.RowIndex];
                    }
                    #endregion
                    break;
            }
        }

        /// <summary>
        /// 验证手册编号合法性
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool validate手册编号(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Empty;
            strSQL = string.Format("SELECT 手册id, 手册编号, 有效期限, 进出口岸一 FROM 手册资料表 where 手册编号 like '%{0}%'", StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count == 1)
            {
                DataRow row = dtData.Rows[0];
                dgv.Rows[cell.RowIndex].Cells["手册id"].Value = row["手册id"];
                dgv.Rows[cell.RowIndex].Cells["手册编号"].Value = row["手册编号"];
            }
            else if (dtData.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择资料";
                formSelect.dtData = dtData;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dgv.Rows[cell.RowIndex].Cells["手册id"].Value = formSelect.returnRow["手册id"];
                    dgv.Rows[cell.RowIndex].Cells["手册编号"].Value = formSelect.returnRow["手册编号"];
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            else
            {
                SysMessage.InformationMsg("此手册编号不存在！");
                dgv.CurrentCell = cell;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 验证商品编号合法性
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool validate商品编号(myDataGridView dgv, DataGridViewCell cell)
        {
            if (dgv.Rows[cell.RowIndex].Cells["手册id"].Value == DBNull.Value || Convert.ToInt32(dgv.Rows[cell.RowIndex].Cells["手册id"].Value) <= 0)
            {
                SysMessage.InformationMsg("请先选择手册编号！");
                return false;
            }
            string strSQL = string.Empty;
                strSQL = string.Format("SELECT 进口料件id, 商品编号, 品名规格型号, 单位 FROM 进口料件表 where 手册id={0} and 商品编号 like '%{1}%'",
                    dgv.Rows[cell.RowIndex].Cells["手册id"].Value,StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));
            
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count == 1)
            {
                DataRow row = dtData.Rows[0];
                dgv.Rows[cell.RowIndex].Cells["进口料件id"].Value = row["进口料件id"];
                dgv.Rows[cell.RowIndex].Cells["商品编号"].Value = row["商品编号"];
                dgv.Rows[cell.RowIndex].Cells["单位"].Value = row["单位"];
                dgv.Rows[cell.RowIndex].Cells["品名规格型号"].Value = row["品名规格型号"];
            }
            else if (dtData.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择资料";
                formSelect.dtData = dtData;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dgv.Rows[cell.RowIndex].Cells["进口料件id"].Value = formSelect.returnRow["进口料件id"];
                    dgv.Rows[cell.RowIndex].Cells["商品编号"].Value = formSelect.returnRow["商品编号"];
                    dgv.Rows[cell.RowIndex].Cells["单位"].Value = formSelect.returnRow["单位"];
                    dgv.Rows[cell.RowIndex].Cells["品名规格型号"].Value = formSelect.returnRow["品名规格型号"];
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            else
            {
                SysMessage.InformationMsg("此商品编号不存在！");
                dgv.CurrentCell = cell;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 验证品名规格型号合法性
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool validate品名规格型号(myDataGridView dgv, DataGridViewCell cell)
        {
            if (dgv.Rows[cell.RowIndex].Cells["手册id"].Value == DBNull.Value || Convert.ToInt32(dgv.Rows[cell.RowIndex].Cells["手册id"].Value) <= 0)
            {
                SysMessage.InformationMsg("请先选择手册编号！");
                return false;
            }
            string strSQL = string.Empty;
            strSQL = string.Format("SELECT 进口料件id, 商品编号, 品名规格型号, 单位 FROM 进口料件表 where 手册id={0} and 品名规格型号 like '%{1}%'",
                dgv.Rows[cell.RowIndex].Cells["手册id"].Value, StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));

            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count == 1)
            {
                DataRow row = dtData.Rows[0];
                dgv.Rows[cell.RowIndex].Cells["进口料件id"].Value = row["进口料件id"];
                dgv.Rows[cell.RowIndex].Cells["商品编号"].Value = row["商品编号"];
                dgv.Rows[cell.RowIndex].Cells["单位"].Value = row["单位"];
                dgv.Rows[cell.RowIndex].Cells["品名规格型号"].Value = row["品名规格型号"];
            }
            else if (dtData.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择资料";
                formSelect.dtData = dtData;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dgv.Rows[cell.RowIndex].Cells["进口料件id"].Value = formSelect.returnRow["进口料件id"];
                    dgv.Rows[cell.RowIndex].Cells["商品编号"].Value = formSelect.returnRow["商品编号"];
                    dgv.Rows[cell.RowIndex].Cells["单位"].Value = formSelect.returnRow["单位"];
                    dgv.Rows[cell.RowIndex].Cells["品名规格型号"].Value = formSelect.returnRow["品名规格型号"];
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            else
            {
                SysMessage.InformationMsg("此商品编号不存在！");
                dgv.CurrentCell = cell;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 验证数量合法性
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private void validate数量(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["数量"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = 0;
                }
            }
        }
        private void validate备注(myDataGridView dgv, DataGridViewCell cell)
        {
            dgv["备注", cell.RowIndex].Value = cell.EditedFormattedValue;
            //如果当前行的商品编号为空，则跳转到当前行的商品编号
            if (dgv.Rows[cell.RowIndex].Cells["商品编号"].Value == DBNull.Value
                || dgv.Rows[cell.RowIndex].Cells["商品编号"].Value.ToString().Trim() == "")
            {
                dgv.CurrentCell = dgv["商品编号", cell.RowIndex];
            }
            else
            {
                //否则跳转到下一行的产品编号，如果是最后一行，则新增一行
                if (cell.RowIndex == dgv.Rows.Count - 1)
                {
                    dtBOMAddRow();
                    dgv.CurrentCell = dgv["商品编号", cell.RowIndex + 1];
                }
                else
                {
                    dgv.CurrentCell = dgv["商品编号", cell.RowIndex + 1];
                }
            }
        }
        #endregion
    }
}
