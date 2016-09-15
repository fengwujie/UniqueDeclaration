using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;
using UniqueDeclarationBaseForm;
using UniqueDeclarationBaseForm.Controls;

namespace UniqueDeclaration
{
    public partial class FormPackingListInput : UniqueDeclarationBaseForm.FormBaseInput
    {
        public FormPackingListInput()
        {
            InitializeComponent();
        }

        #region 窗体事件
        public override void FormBaseInput_Load(object sender, EventArgs e)
        {
            //base.FormBaseInput_Load(sender, e);
            InitControlData();
            LoadDataSource();
            InitGrid();
        }
        #endregion
        
        #region 方法
        /// <summary>
        /// 初始化GRID
        /// </summary>
        public override void InitGrid()
        {
            this.dataGridViewDetail.AutoGenerateColumns = false;
            this.dataGridViewDetail.CausesValidation = false;
            this.dataGridViewDetail.Columns["BM"].Visible = false;
            this.dataGridViewDetail.Columns["BM"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["订单明细表id"].Visible = false;
            this.dataGridViewDetail.Columns["订单明细表id"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["箱号"].DisplayIndex = 0;
            this.dataGridViewDetail.Columns["箱号"].Width = 55;
            this.dataGridViewDetail.Columns["箱号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["客人型号"].DisplayIndex = 1;
            this.dataGridViewDetail.Columns["客人型号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["优丽型号"].DisplayIndex = 2;
            this.dataGridViewDetail.Columns["优丽型号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["订单号码"].DisplayIndex = 3;
            this.dataGridViewDetail.Columns["订单号码"].Width = 78;
            this.dataGridViewDetail.Columns["订单号码"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["手册编号"].DisplayIndex = 4;
            this.dataGridViewDetail.Columns["手册编号"].Width = 78;
            this.dataGridViewDetail.Columns["手册编号"].ReadOnly = true;
            this.dataGridViewDetail.Columns["手册编号"].ContextMenuStrip = myContextDetails;
            this.dataGridViewDetail.Columns["归并前成品序号"].DisplayIndex = 5;
            this.dataGridViewDetail.Columns["归并前成品序号"].ReadOnly = true;
            this.dataGridViewDetail.Columns["归并前成品序号"].Width = 120;
            this.dataGridViewDetail.Columns["归并前成品序号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["内部版本号"].DisplayIndex = 6;
            this.dataGridViewDetail.Columns["内部版本号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["成品项号"].DisplayIndex = 7;
            this.dataGridViewDetail.Columns["成品项号"].ReadOnly = true;
            this.dataGridViewDetail.Columns["成品项号"].Width = 78;
            this.dataGridViewDetail.Columns["成品项号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["成品名称及商编"].DisplayIndex = 8;
            this.dataGridViewDetail.Columns["成品名称及商编"].ReadOnly = true;
            this.dataGridViewDetail.Columns["成品名称及商编"].Width = 120;
            this.dataGridViewDetail.Columns["成品名称及商编"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["成品规格型号"].DisplayIndex = 9;
            this.dataGridViewDetail.Columns["成品规格型号"].Width = 110;
            this.dataGridViewDetail.Columns["成品规格型号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["数量"].DisplayIndex = 10;
            this.dataGridViewDetail.Columns["数量"].Width = 55;
            this.dataGridViewDetail.Columns["数量"].ContextMenuStrip = this.myContextDetails;
            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dataGridViewCellStyle1.Format = "N5";
            //dataGridViewCellStyle1.NullValue = null;
            //this.dataGridViewDetail.Columns["数量"].DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDetail.Columns["单位"].DisplayIndex = 11;
            this.dataGridViewDetail.Columns["单位"].Width = 55;
            this.dataGridViewDetail.Columns["单位"].ContextMenuStrip = this.myContextDetails;

            this.dataGridViewDetail.Columns["单价"].Visible = false;
            this.dataGridViewDetail.Columns["单价"].ContextMenuStrip = this.myContextDetails;
        }
        public override void InitControlData()
        {
            base.InitControlData();
            this.gstrDetailFirstField = "箱号";
            this.cbox_手册编号.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade,
                "SELECT 手册编号 FROM 手册资料表 ORDER BY 有效期限 DESC", "手册编号", "手册编号");
        }
        /// <summary>
        /// 加载表头数据
        /// </summary>
        public override void LoadDataSourceHead()
        {
            string strSQL = string.Format("SELECT * FROM 装箱单表 WHERE 订单id ={0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            dtHead = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtHead.Rows.Count > 0)
            {
                rowHead = dtHead.Rows[0];
                string OrderCode = rowHead["订单号码"].ToString();
                if(OrderCode.Contains(","))
                {
                    OrderCode = OrderCode.Substring(0,OrderCode.IndexOf(","));
                }
                IDataAccess dataManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataManufacture.Open();
                DataTable dt手册编号 = dataManufacture.GetTable(string.Format("select 手册编号 from 报关订单表 where 订单号码= '{0}'",OrderCode),null);
                dataManufacture.Close();
                if (dt手册编号.Rows.Count > 0)
                {
                    cbox_手册编号.SelectedValue = dt手册编号.Rows[0]["手册编号"];
                }
                fillControl(rowHead);
            }
            else
            {
                rowHead = dtHead.NewRow();
                dtHead.Rows.Add(rowHead);
                rowHead["出货日期"] = DateTime.Now.Date;
                rowHead["灵入日期"] = DateTime.Now.Date;
                rowHead["出口状态"] = 0;
                fillControl(rowHead);
            }
        }
        /// <summary>
        /// 加载表身数据
        /// </summary>
        public override void LoadDataSourceDetails()
        {
            string strSQL = string.Format("exec 装箱单明细表录入查询 {0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            dtDetails = dataAccess.GetTable(strSQL.ToString(), null);
            dataAccess.Close();
            bCellKeyPress = false;
            this.dataGridViewDetail.DataSource = dtDetails;
            bCellKeyPress = true;
            if (dtDetails.Rows.Count == 0)
                dtDetailsAddRow();
            //if (dtDetails.Rows.Count > 0)
            //{
            //this.dataGridViewDetail.CurrentCell = this.dataGridViewDetail["客人型号", 0];
            //}
            setTool1Enabled();
        }
        /// <summary>
        /// 检查数据是否有修改，并返回对应的操作选项
        /// Yes：保存资料，并继续;；No：不保存资料，并继续；Cancel：取消操作，返回界面
        /// </summary>
        /// <returns>Yes：保存资料，并继续;；No：不保存资料，并继续；Cancel：取消操作，返回界面</returns>
        public override DialogResult CheckModify()
        {
            bool bModify = false;
            if (rowHead.RowState == DataRowState.Modified)//(dtDetails.GetChanges()!=null && dtDetails.GetChanges().Rows.Count > 0)
            {
                bModify = true;
            }
            else if (rowHead.RowState == DataRowState.Added)
            {
                if (rowHead["订单号码"].ToString().Length > 0 || rowHead["装箱单号"].ToString().Length > 0)
                {
                    bModify = true;
                }
            }
            //如果表头没层云，再判断表身是否有异动
            if (!bModify)
            {
                for (int iRow = 0; iRow < dtDetails.Rows.Count; iRow++)
                {
                    DataRow row = dtDetails.Rows[iRow];
                    if (iRow == 0)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            bModify = true;
                            break;
                        }
                        else if (row.RowState == DataRowState.Added)  //如果是新增状态，则判断客人型号、优丽型号是否为空
                        {
                            if (row["客人型号"] != DBNull.Value || row["客人型号"].ToString().Trim().Length > 0 ||
                                row["优丽型号"] != DBNull.Value || row["优丽型号"].ToString().Trim().Length > 0)
                            {
                                bModify = true;
                                break;
                            }
                        }
                        else if (row.RowState == DataRowState.Deleted)
                        {
                            if (row["订单明细表id", DataRowVersion.Original] != DBNull.Value)
                            {
                                bModify = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (row.RowState != DataRowState.Unchanged)
                        {
                            bModify = true;
                            break;
                        }
                    }
                }
            }
            if (bModify)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine("当前资料未保存，请选择是否保存！");
                strBuilder.AppendLine("是：保存资料，并继续");
                strBuilder.AppendLine("否：不保存资料，并继续");
                strBuilder.AppendLine("取消：取消操作，返回界面");
                return SysMessage.YesNoCancelMsg(strBuilder.ToString());
            }
            return DialogResult.No;
        }
        #endregion

        #region 表头控件事件
        private void txt_订单号码_Validating(object sender, CancelEventArgs e)
        {
            if (txt_订单号码.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                return;
            }
            if (rowHead.RowState == DataRowState.Added && txt_订单号码.Text.Trim() != "")
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                DataTable dtTemp = dataAccess.GetTable(string.Format("select * from 报关订单表 WHERE 订单号码 like  '%{0}%' order by 出货日期 desc",StringTools.SqlLikeQ(txt_订单号码.Text.Trim())),null);
                dataAccess.Close();
                if (dtTemp.Rows.Count > 0)
                {
                    FormBaseSingleSelect selectForm = new FormBaseSingleSelect();
                    selectForm.strFormText = "选择订单号码";
                    selectForm.dtData = dtTemp;
                    if (selectForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rowHead["订单号码"] = selectForm.returnRow["订单号码"];
                        rowHead["客户代码"] = selectForm.returnRow["客户代码"];
                        rowHead["客户名称"] = selectForm.returnRow["客户名称"];
                        if(txt_装箱单号.Text.Trim().Length ==0)
                            rowHead["装箱单号"] = selectForm.returnRow["订单号码"];

                        txt_订单号码.Text = selectForm.returnRow["订单号码"].ToString();
                        txt_客户代码.Text = selectForm.returnRow["客户代码"].ToString();
                        txt_客户名称.Text = selectForm.returnRow["客户名称"].ToString();
                        cbox_手册编号.SelectedValue = selectForm.returnRow["手册编号"];
                        if (txt_装箱单号.Text.Trim().Length == 0)
                            txt_装箱单号.Text = selectForm.returnRow["订单号码"].ToString();
                    }
                }
            }
        }

        private void txt_订单号码_Validated(object sender, EventArgs e)
        {
            if (rowHead["订单号码"].ToString() != txt_订单号码.Text)
            {
                rowHead["订单号码"] = txt_订单号码.Text;
            }
        }

        private void txt_装箱单号_Validating(object sender, CancelEventArgs e)
        {
            if (rowHead.RowState == DataRowState.Added && txt_装箱单号.Text.Trim() != "")
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                DataTable dtTemp = dataAccess.GetTable(string.Format("select * from 装箱单表 where 装箱单号={0}", StringTools.SqlQ(txt_装箱单号.Text.Trim())), null);
                dataAccess.Close();
                if (dtTemp.Rows.Count > 0)
                {
                    SysMessage.InformationMsg("此装箱单号已经存在");
                    e.Cancel = true;
                }
            }
        }

        private void txt_装箱单号_Validated(object sender, EventArgs e)
        {
            if (rowHead["装箱单号"].ToString() != txt_装箱单号.Text)
            {
                rowHead["装箱单号"] = txt_装箱单号.Text;
            }
        }

        private void txt_客户代码_Validated(object sender, EventArgs e)
        {
            if (rowHead["客户代码"].ToString() != txt_客户代码.Text)
            {
                rowHead["客户代码"] = txt_客户代码.Text;
            }
        }

        private void txt_客户名称_Validated(object sender, EventArgs e)
        {
            if (rowHead["客户名称"].ToString() != txt_客户名称.Text)
            {
                rowHead["客户名称"] = txt_客户名称.Text;
            }
        }

        private void date_出货日期_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(rowHead["出货日期"]) != date_出货日期.Value)
            {
                rowHead["出货日期"] = date_出货日期.Value;
            }
        }

        private void txt_报关单号_Validated(object sender, EventArgs e)
        {
            if (rowHead["报关单号"].ToString() != txt_报关单号.Text)
            {
                rowHead["报关单号"] = txt_报关单号.Text;
            }
        }

        private void cbox_手册编号_TabIndexChanged(object sender, EventArgs e)
        {
            if (rowHead["手册编号"].ToString() != cbox_手册编号.SelectedValue.ToString())
                rowHead["手册编号"] = cbox_手册编号.SelectedValue;
        }

        private void txt_录入日期_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(rowHead["录入日期"]) != date_录入日期.Value)
            {
                rowHead["录入日期"] = date_录入日期.Value;
            }
        }

        private void txt_征免方式_Validated(object sender, EventArgs e)
        {
            if (rowHead["征免方式"].ToString() != txt_征免方式.Text)
            {
                rowHead["征免方式"] = txt_征免方式.Text;
            }
        }

        private void txt_产销国_Validated(object sender, EventArgs e)
        {
            if (rowHead["产销国"].ToString() != txt_产销国.Text)
            {
                rowHead["产销国"] = txt_产销国.Text;
            }
        }

        private void myCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean( rowHead["出口状态"]) != myCheckBox1.Checked)
            {
                rowHead["出口状态"] = myCheckBox1.Checked == true ? 1 : 0;
            }
        }

        private void txt_币制_Validated(object sender, EventArgs e)
        {
            if (rowHead["币制"].ToString() != txt_币制.Text)
            {
                rowHead["币制"] = txt_币制.Text;
            }
        }

        private void txt_申报地海关代码_Validated(object sender, EventArgs e)
        {
            if (rowHead["申报地海关代码"].ToString() != txt_申报地海关代码.Text)
            {
                rowHead["申报地海关代码"] = txt_申报地海关代码.Text;
            }
        }

        private void txt_进口岸代码_Validated(object sender, EventArgs e)
        {
            if (rowHead["进口岸代码"].ToString() != txt_进口岸代码.Text)
            {
                rowHead["进口岸代码"] = txt_进口岸代码.Text;
            }
        }

        private void txt_代理单位代码_Validated(object sender, EventArgs e)
        {
            if (rowHead["代理单位代码"].ToString() != txt_代理单位代码.Text)
            {
                rowHead["代理单位代码"] = txt_代理单位代码.Text;
            }
        }

        private void txt_用途_Validated(object sender, EventArgs e)
        {
            if (rowHead["用途"].ToString() != txt_用途.Text)
            {
                rowHead["用途"] = txt_用途.Text;
            }
        }

        /// <summary>
        /// 填充表头数据到控件上
        /// </summary>
        /// <param name="row">来源数据</param>
        private void fillControl(DataRow row)
        {
            if (row.Table.Columns.Contains("装箱单号"))
            {
                txt_装箱单号.Text = row["装箱单号"].ToString();
            }
            if (row.Table.Columns.Contains("订单号码"))
            {
                txt_订单号码.Text = row["订单号码"].ToString();
            }
            if (row.Table.Columns.Contains("客户代码"))
            {
                txt_客户代码.Text = row["客户代码"].ToString();
            }
            if (row.Table.Columns.Contains("客户名称"))
            {
                txt_客户名称.Text = row["客户名称"].ToString();
            }
            if (row.Table.Columns.Contains("出货日期"))
            {
                date_出货日期.Value = Convert.ToDateTime(row["出货日期"]);
            }
            if (row.Table.Columns.Contains("录入日期"))
            {
                date_录入日期.Value = Convert.ToDateTime(row["录入日期"]);
            }
            if (row.Table.Columns.Contains("报关单号"))
            {
                txt_报关单号.Text = row["报关单号"].ToString();
            }
            if (row.Table.Columns.Contains("用途"))
            {
                txt_用途.Text = row["用途"].ToString();
            }
            if (row.Table.Columns.Contains("征免方式"))
            {
                txt_征免方式.Text = row["征免方式"].ToString();
            }
            if (row.Table.Columns.Contains("产销国"))
            {
                txt_产销国.Text = row["产销国"].ToString();
            }
            if (row.Table.Columns.Contains("币制"))
            {
                txt_币制.Text = row["币制"].ToString();
            }
            if (row.Table.Columns.Contains("申报地海关代码"))
            {
                txt_申报地海关代码.Text = row["申报地海关代码"].ToString();
            }
            if (row.Table.Columns.Contains("进口岸代码"))
            {
                txt_进口岸代码.Text = row["进口岸代码"].ToString();
            }
            if (row.Table.Columns.Contains("代理单位代码"))
            {
                txt_代理单位代码.Text = row["代理单位代码"].ToString();
            }
            if (row.Table.Columns.Contains("出口状态"))
            {
                myCheckBox1.Checked = Convert.ToBoolean(row["出口状态"]);
            }
        }

        #endregion
        
        #region 表身toolStrip事件

        public override void tool2_Import_Click(object sender, EventArgs e)
        {
            base.tool2_Import_Click(sender, e);
            //int i, mypos;
            //string startpos, OrderCode;
            if (txt_订单号码.Text.Trim().Length == 0) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            foreach (string OrderCode in txt_订单号码.Text.Trim().Split(','))
            {
                dataAccess.Open();
                DataTable dt报关订单表 = dataAccess.GetTable(string.Format("select 订单id,手册编号,订单号码 from 报关订单表 where 订单号码={0}",StringTools.SqlQ(OrderCode)), null);
                dataAccess.Close();
                if (dt报关订单表.Rows.Count == 0) continue;
                dataAccess.Open();
                DataTable dt报关订单录入查询 = dataAccess.GetTable(string.Format("报关订单录入查询 {0}",dt报关订单表.Rows[0]["订单id"]), null);
                dataAccess.Close();
                foreach (DataRow row in dt报关订单录入查询.Rows)
                {
                    dataAccess.Open();
                    DataTable dt装箱单 = dataAccess.GetTable(string.Format(@"select 客人型号,优丽型号,sum(数量) as 数量  from 装箱单表 
                                                                                    inner join 装箱单明细表 on 装箱单表.订单id=装箱单明细表.订单id 
                                                                            where 装箱单明细表.订单号码= {0} and 客人型号 ={1} and 优丽型号 ={1}  group by 客人型号,优丽型号",
                                                    StringTools.SqlQ(OrderCode), StringTools.SqlQ(row["客人型号"].ToString()), StringTools.SqlQ(row["优丽型号"].ToString())), null);
                    dataAccess.Close();
                    if (dt装箱单.Rows.Count > 0)
                    {
                        DataRow row装箱单 = dt装箱单.Rows[0];
                        if (row["数量"] != DBNull.Value && row装箱单["数量"] != DBNull.Value
                            && StringTools.decimalParse(row["数量"].ToString()) - StringTools.decimalParse(row装箱单["数量"].ToString()) > 0)
                        {
                            DataRow newRow = dtDetails.NewRow();
                            newRow["箱号"] = 1;
                            newRow["客人型号"] = row["客人型号"];
                            newRow["优丽型号"] = row["优丽型号"];
                            newRow["数量"] = (row["订单数量"] == DBNull.Value ? 0 : StringTools.decimalParse(row["订单数量"].ToString()))
                                - (row装箱单["数量"] == DBNull.Value ? 0 : StringTools.decimalParse(row装箱单["数量"].ToString()));
                            newRow["成品项号"] = row["成品项号"];
                            newRow["成品名称及商编"] = row["成品名称及商编"];
                            newRow["手册编号"] = dt报关订单表.Rows[0]["手册编号"];
                            newRow["订单号码"] = dt报关订单表.Rows[0]["订单号码"];
                            newRow["单位"] = (row["申报单位"] == DBNull.Value || row["申报单位"].ToString() == "") ? "个" : row["申报单位"];
                            if (row["总重"] != DBNull.Value && StringTools.decimalParse(row["总重"].ToString()) > 0)
                            {
                                newRow["成品规格型号"] = string.Format("{0}G/{1}", row["总重"], row["单位"]);
                            }
                            newRow["归并前成品序号"] = row["版本号"];
                            newRow["内部版本号"] = row["内部版本号"];
                            dtDetails.Rows.Add(newRow);
                        }
                    }
                    else
                    {
                        DataRow newRow = dtDetails.NewRow();
                        newRow["箱号"] = 1;
                        newRow["客人型号"] = row["客人型号"];
                        newRow["优丽型号"] = row["优丽型号"];
                        newRow["数量"] = row["订单数量"];
                        newRow["成品项号"] = row["成品项号"];
                        newRow["成品名称及商编"] = row["成品名称及商编"];
                        newRow["手册编号"] = dt报关订单表.Rows[0]["手册编号"];
                        newRow["订单号码"] = dt报关订单表.Rows[0]["订单号码"];
                        newRow["单位"] = (row["申报单位"] == DBNull.Value || row["申报单位"].ToString() == "") ? "个" : row["申报单位"];
                        if (row["总重"] != DBNull.Value && StringTools.decimalParse(row["总重"].ToString()) > 0)
                        {
                            newRow["成品规格型号"] = string.Format("{0}G/{1}", row["总重"], row["单位"]);
                        }
                        newRow["归并前成品序号"] = row["版本号"];
                        newRow["内部版本号"] = row["内部版本号"];
                        dtDetails.Rows.Add(newRow);
                    }
                }
            }
            setTool1Enabled();
        }
        /// <summary>
        /// 根据产品ID获取产品颜色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetColor(long id)
        {
            string cColorName = string.Empty;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtColor = dataAccess.GetTable(string.Format("select * from 产品资料表 where 产品id={0}", id), null);
            dataAccess.Close();
            if (dtColor.Rows.Count > 0)
            {
                cColorName = dtColor.Rows[0]["产品颜色"].ToString();
            }
            return cColorName;
        }
        #endregion

        #region GRID事件
        /// <summary>
        /// GRID的回车事件
        /// </summary>
        /// <param name="dgv">Grid对象</param>
        /// <param name="cell">焦点CELL</param>
        /// <param name="bKeyEnter">是否按回车触发的事件</param>
        public override void GridKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)//
        {
            if (!bCellKeyPress) return;
            string colName = dgv.Columns[cell.ColumnIndex].Name;
            switch (colName)
            {
                case "料件编号": //跳转到料号"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["料件编号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["料号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate料件编号(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["料号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["料件编号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate料件编号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "料号": //跳转到出库数量"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["料号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["出库数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate料号(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["出库数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["料号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate料号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "料件名":   //跳转到"商品编码"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品编码", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品编码":   //跳转到"商品名称"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品名称", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品名称":   //跳转到"商品规格"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品规格", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品规格":   //跳转到"出库数量"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["出库数量", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "出库数量":   //跳转到"备注"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["出库数量"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate出库数量(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["出库数量"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate出库数量(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "库存数":   //跳转到"出库后库存数"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["出库后库存数", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "出库后库存数":   //跳转到"单位"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["单位", cell.RowIndex];
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
                case "备注":   //跳转到"料件编号"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        validate备注(dgv, cell);
                    }
                    #endregion
                    break;
            }
        }

        private bool validate料件编号(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Format(@"帮助录入查询 {0}, 3, 0, 0, 0, '', ''", StringTools.SqlQ(cell.EditedFormattedValue.ToString()));
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dttabArticle = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dttabArticle.Rows.Count == 0)
            {
                SysMessage.InformationMsg("此料件不存在！");
                dgv.CurrentCell = cell;
                return false;
            }
            else if (dttabArticle.Rows.Count == 1)
            {
                if (cbox_手册编号.SelectedValue.ToString() == "B37167420012")
                {
                    dgv.Rows[cell.RowIndex].Cells["料号"].Value = dttabArticle.Rows[0]["显示型号"];
                }
                else if (cbox_手册编号.SelectedValue.ToString() == "B37168420019")
                {
                    dgv.Rows[cell.RowIndex].Cells["料号"].Value = dttabArticle.Rows[0]["新显示型号"];
                }
                else
                {
                    dgv.Rows[cell.RowIndex].Cells["料号"].Value = dttabArticle.Rows[0]["电子帐册型号"];
                }
                dgv.Rows[cell.RowIndex].Cells["料件id"].Value = dttabArticle.Rows[0]["料件id"];
                dgv.Rows[cell.RowIndex].Cells["料件编号"].Value = dttabArticle.Rows[0]["料件型号"];
                dgv.Rows[cell.RowIndex].Cells["料件名"].Value = dttabArticle.Rows[0]["料件名"];
            }
            else if (dttabArticle.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择客户型号";
                formSelect.dtData = dttabArticle;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (cbox_手册编号.SelectedValue.ToString() == "B37167420012")
                    {
                        dgv.Rows[cell.RowIndex].Cells["料号"].Value = dttabArticle.Rows[0]["显示型号"];
                    }
                    else if (cbox_手册编号.SelectedValue.ToString() == "B37168420019")
                    {
                        dgv.Rows[cell.RowIndex].Cells["料号"].Value = dttabArticle.Rows[0]["新显示型号"];
                    }
                    else
                    {
                        dgv.Rows[cell.RowIndex].Cells["料号"].Value = dttabArticle.Rows[0]["电子帐册型号"];
                    }
                    dgv.Rows[cell.RowIndex].Cells["料件id"].Value = dttabArticle.Rows[0]["料件id"];
                    dgv.Rows[cell.RowIndex].Cells["料件编号"].Value = dttabArticle.Rows[0]["料件型号"];
                    dgv.Rows[cell.RowIndex].Cells["料件名"].Value = dttabArticle.Rows[0]["料件名"];
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            if (dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString() != "")
            {
                //strSQL = string.Format("进口料件出库库存查询 @料号={0},@电子帐册号={1},@期末时间='{2}'",
                //    StringTools.SqlQ(dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString()),
                //    StringTools.SqlQ(cbox_手册编号.SelectedValue.ToString()),
                //    date_出库时间.Value.ToString("yyyyMMdd HH:mm:ss"));
                dataAccess.Open();
                dttabArticle = dataAccess.GetTable(strSQL, null);
                if (dttabArticle.Rows.Count > 0)
                {
                    dgv.Rows[cell.RowIndex].Cells["库存数"].Value = dttabArticle.Rows[0]["库存数"];
                    dgv.Rows[cell.RowIndex].Cells["出库后库存数"].Value = StringTools.decimalParse(dgv.Rows[cell.RowIndex].Cells["库存数"].Value.ToString())
                        - StringTools.decimalParse(dgv.Rows[cell.RowIndex].Cells["出库数量"].Value.ToString());
                }
                strSQL = string.Format(@"SELECT Q.产品编号,H.序号,H.商品编码, H.商品名称, Q.商品规格, H.计量单位,H.计量单位,H.损耗率,H.单价 
                                                        FROM dbo.归并后料件清单 H LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id 
                                                        where Q.产品编号='{0}' AND H.电子帐册号='{1}'",
                                    dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString().Substring(0, 5), cbox_手册编号.SelectedValue);
                dataAccess.Open();
                dttabArticle = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dttabArticle.Rows.Count > 0)
                {
                    dgv.Rows[cell.RowIndex].Cells["商品编码"].Value = dttabArticle.Rows[0]["商品编码"];
                    dgv.Rows[cell.RowIndex].Cells["商品名称"].Value = dttabArticle.Rows[0]["商品名称"];
                    dgv.Rows[cell.RowIndex].Cells["商品规格"].Value = dttabArticle.Rows[0]["商品规格"];
                    dgv.Rows[cell.RowIndex].Cells["单位"].Value = "KGS";
                }
            }
            return true;
        }
        private bool validate料号(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Empty;
            if (cbox_手册编号.SelectedValue.ToString() == "B37167420012")
            {
                strSQL = string.Format(@"帮助录入查询 {0}, 12, 0, 0, 0, '',''", StringTools.SqlQ(cell.EditedFormattedValue.ToString()));
            }
            else if (cbox_手册编号.SelectedValue.ToString() == "B37168420019")
            {
                strSQL = string.Format(@"帮助录入查询 {0}, 14, 0, 0, 0,'', ''", StringTools.SqlQ(cell.EditedFormattedValue.ToString()));
            }
            else
            {
                strSQL = string.Format(@"帮助录入查询 {0}, 13, 0, 0, 0, '', ''", StringTools.SqlQ(cell.EditedFormattedValue.ToString()));
            }

            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dttabArticle = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dttabArticle.Rows.Count == 0)
            {
                SysMessage.InformationMsg("此料件不存在！");
                dgv.CurrentCell = cell;
                return false;
            }
            else if (dttabArticle.Rows.Count == 1)
            {
                dgv.Rows[cell.RowIndex].Cells["料件id"].Value = dttabArticle.Rows[0]["料件id"];
                dgv.Rows[cell.RowIndex].Cells["料号"].Value = dttabArticle.Rows[0]["显示型号"];
                dgv.Rows[cell.RowIndex].Cells["料件编号"].Value = dttabArticle.Rows[0]["料件型号"];
                dgv.Rows[cell.RowIndex].Cells["料件名"].Value = dttabArticle.Rows[0]["料件名"];
            }
            else if (dttabArticle.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择客户型号";
                formSelect.dtData = dttabArticle;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    dgv.Rows[cell.RowIndex].Cells["料件id"].Value = dttabArticle.Rows[0]["料件id"];
                    dgv.Rows[cell.RowIndex].Cells["料号"].Value = dttabArticle.Rows[0]["显示型号"];
                    dgv.Rows[cell.RowIndex].Cells["料件编号"].Value = dttabArticle.Rows[0]["料件型号"];
                    dgv.Rows[cell.RowIndex].Cells["料件名"].Value = dttabArticle.Rows[0]["料件名"];
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            if (dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString() != "")
            {
                //strSQL = string.Format("进口料件出库库存查询 @料号={0},@电子帐册号={1},@期末时间='{2}'",
                //    StringTools.SqlQ(dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString()),
                //    StringTools.SqlQ(cbox_手册编号.SelectedValue.ToString()),
                //    date_出库时间.Value.ToString("yyyyMMdd HH:mm:ss"));
                dataAccess.Open();
                dttabArticle = dataAccess.GetTable(strSQL, null);
                if (dttabArticle.Rows.Count > 0)
                {
                    dgv.Rows[cell.RowIndex].Cells["库存数"].Value = dttabArticle.Rows[0]["库存数"];
                    dgv.Rows[cell.RowIndex].Cells["出库后库存数"].Value = StringTools.decimalParse(dgv.Rows[cell.RowIndex].Cells["库存数"].Value.ToString())
                        - StringTools.decimalParse(dgv.Rows[cell.RowIndex].Cells["出库数量"].Value.ToString());
                }
                strSQL = string.Format(@"SELECT Q.产品编号,H.序号,H.商品编码, H.商品名称, Q.商品规格, H.计量单位,H.计量单位,H.损耗率,H.单价 
                                                        FROM dbo.归并后料件清单 H LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id 
                                                        where Q.产品编号='{0}' AND H.电子帐册号='{1}'",
                                    dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString().Substring(0, 5), cbox_手册编号.SelectedValue);
                dataAccess.Open();
                dttabArticle = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dttabArticle.Rows.Count > 0)
                {
                    dgv.Rows[cell.RowIndex].Cells["商品编码"].Value = dttabArticle.Rows[0]["商品编码"];
                    dgv.Rows[cell.RowIndex].Cells["商品名称"].Value = dttabArticle.Rows[0]["商品名称"];
                    dgv.Rows[cell.RowIndex].Cells["商品规格"].Value = dttabArticle.Rows[0]["商品规格"];
                    dgv.Rows[cell.RowIndex].Cells["单位"].Value = "KGS";
                }
            }
            return true;
        }
        private void validate出库数量(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["出库数量"].Value = 0;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["出库数量"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["出库数量"].Value = 0;
                }
            }
        }
        private void validate备注(myDataGridView dgv, DataGridViewCell cell)
        {
            //如果当前行的料件编号为空，则跳转到当前行的料件编号
            dgv["备注", cell.RowIndex].Value = cell.EditedFormattedValue;
            if (dgv.Rows[cell.RowIndex].Cells["料件编号"].Value == DBNull.Value
                || dgv.Rows[cell.RowIndex].Cells["料件编号"].Value.ToString().Trim() == "")
            {
                dgv.CurrentCell = dgv["料件编号", cell.RowIndex];
            }
            else
            {
                //否则跳转到下一行的客人型号，如果是最后一行，则新增一行
                if (cell.RowIndex == dgv.Rows.Count - 1)
                {
                    dtDetailsAddRow();
                    dgv.CurrentCell = dgv["料件编号", cell.RowIndex + 1];
                }
                else
                {
                    dgv.CurrentCell = dgv["料件编号", cell.RowIndex + 1];
                }
            }
        }
        public override void dataGridViewDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            base.dataGridViewDetail_DataError(sender, e);
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex < 0) return;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "出库数量")
                e.Cancel = false;
        }

        /// <summary>
        /// 明细GRID增加一条新行
        /// </summary>
        public override void dtDetailsAddRow()
        {
            string OrderCode = string.Empty;
            string ManualCode = string.Empty;
            int BoxNumber = 0;
            if (this.dataGridViewDetail.CurrentRow != null)
            {
                OrderCode =this.dataGridViewDetail.CurrentRow.Cells["订单号码"].Value==DBNull.Value ? "" : this.dataGridViewDetail.CurrentRow.Cells["订单号码"].Value.ToString();
                ManualCode = this.dataGridViewDetail.CurrentRow.Cells["手册编号"].Value == DBNull.Value ? "" : this.dataGridViewDetail.CurrentRow.Cells["手册编号"].Value.ToString();
                BoxNumber = this.dataGridViewDetail.CurrentRow.Cells["箱号"].Value == DBNull.Value ? 1 : StringTools.intParse(this.dataGridViewDetail.CurrentRow.Cells["箱号"].Value.ToString());
            }
            else
            {
                OrderCode = txt_订单号码.Text.Trim();
                ManualCode = cbox_手册编号.SelectedValue.ToString();
                BoxNumber = 1;
            }

            DataRow newRow = dtDetails.NewRow();
            newRow["订单号码"] = OrderCode;
            newRow["手册编号"] = ManualCode;
            newRow["箱号"] = BoxNumber;
            dtDetails.Rows.Add(newRow);
            setTool1Enabled();
        }
        #endregion

        //出口料件统计
        private void btnOuterMaterialTotal_Click(object sender, EventArgs e)
        {
            if (txt_订单号码.Text.Trim().Length > 0)
            {
                FormOuterMaterialTotal objForm = new FormOuterMaterialTotal();
                objForm.mstrFilterString = string.Format(string.Format("@订单号码={0}", txt_订单号码.Text.Trim()));
                objForm.Show();
            }
        }
        //检查订单号码
        private void btnCheckOrderNo_Click(object sender, EventArgs e)
        {
            if (txt_订单号码.Text.Trim().Length == 0)
            {
                SysMessage.InformationMsg("请输入订单号码");
                return;
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtTemp = dataAccess.GetTable(string.Format("select 订单号码,客户代码,手册编号 as 电子帐册号 from 报关订单表 WHERE 客户代码 ={0} and 手册编号 ='{1}' order by 出货日期 desc",
                                StringTools.SqlQ(txt_客户代码.Text.Trim()),cbox_手册编号.SelectedValue), null);
            dataAccess.Close();
            if (dtTemp.Rows.Count > 0)
            {
                FormBaseSingleSelect selectForm = new FormBaseSingleSelect();
                selectForm.strFormText = "选择订单号码";
                selectForm.dtData = dtTemp;
                if (selectForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (txt_订单号码.Text.Trim().Contains(selectForm.returnRow["订单号码"].ToString()))
                    {
                        SysMessage.InformationMsg("此订单号码已经存在");
                        return;
                    }
                    else
                    {
                        txt_订单号码.Text += "," + selectForm.returnRow["订单号码"].ToString();
                    }
                }
            }
        }
    }
}
