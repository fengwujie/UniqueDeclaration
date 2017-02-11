using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;
using UniqueDeclarationBaseForm.Controls;

namespace UniqueDeclaration.Base
{
    public partial class FormMergeRelationMaterialsInput : UniqueDeclarationBaseForm.FormBase
    {
        public FormMergeRelationMaterialsInput()
        {
            InitializeComponent();
        }

        #region 自定义变量
        /// <summary>
        /// 出口成品明细表的第一个字段
        /// </summary>
        private string gstrDetailFirstField = "序号";
        /// <summary>
        /// 订单ID，如果是修改打开的话，需要赋值，重复点击修改的话，需要判断被打开的FORM中是否存在该订单ID，有的话显示窗体，没有的话再创建
        /// </summary>
        public int giOrderID = 0;
        /// <summary>
        /// 表头数据集
        /// </summary>
        public DataTable dtHead = null;
        /// <summary>
        /// 表头数据集的行数据
        /// </summary>
        public DataRow rowHead = null;
        /// <summary>
        /// 表身数据集
        /// </summary>
        public DataTable dtDetails = null;
        /// <summary>
        /// 控制是否触发单元格回车事件，如果是回车事件后，指定到某个单元格，这种情况下就不再触发回车事件
        /// </summary>
        public bool bCellKeyPress = true;
        /// <summary>
        /// 是否触发单元格结束编辑事件
        /// </summary>
        public bool bCellEndEdit = true;
        /// <summary>
        /// 是否触发下拉控件的变化事件
        /// </summary>
        private bool bcbox_SelectedIndexChanged = false;
        #endregion

        #region 窗体事件
        private void FormMergeRelationMaterialsInput_Load(object sender, EventArgs e)
        {
            InitControlData();
            LoadDataSource();
            InitGrid();
        }

        private void FormMergeRelationMaterialsInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = CheckModify();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.Yes:
                    if (Save(false))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                    break;
                case System.Windows.Forms.DialogResult.No:
                    e.Cancel = false;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
        #endregion 
        
        #region 方法
        /// <summary>
        /// 出口成品GRID初始化
        /// </summary>
        private void InitGrid()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["BM"].Visible = false;
            this.myDataGridViewDetails.Columns["归并前料件id"].Visible = false;
            this.myDataGridViewDetails.Columns["序号"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["产品编号"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["商品编码"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["商品名称"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["商品规格"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["单价"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["币种"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["计量单位"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["计量单位"].HeaderText = "申报计量单位";
            this.myDataGridViewDetails.Columns["法定单位"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["换算因子"].DisplayIndex = 9;
            this.myDataGridViewDetails.Columns["对应编号"].DisplayIndex = 10;
            this.myDataGridViewDetails.Columns["商品编码"].ReadOnly = true;
            this.myDataGridViewDetails.Columns["商品名称"].ReadOnly = true;
            this.myDataGridViewDetails.Columns["计量单位"].ReadOnly = true;
            this.myDataGridViewDetails.Columns["法定单位"].ReadOnly = true;
            this.myDataGridViewDetails.Columns["换算因子"].ReadOnly = true;
            this.myDataGridViewDetails.Columns["币种"].ReadOnly = true;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "F3";
            dataGridViewCellStyle1.NullValue = null;
            this.myDataGridViewDetails.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewDetails.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextDetails;
            }
        }
        /// <summary>
        /// 初始化界面上某些控件的初始值
        /// </summary>
        public void InitControlData()
        {
            bcbox_SelectedIndexChanged = false;
            cbox_主料.Items.Add("主料");
            cbox_主料.Items.Add("非主料");
            cbox_主料.SelectedIndex = 0;

            string strSQL = "SELECT top 2 手册编号 as 电子帐册号 FROM 手册资料表 order by 有效期限 desc";
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dt电子帐册号 = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            cbox_电子帐册号.InitialData(dt电子帐册号, "电子帐册号", "电子帐册号2", 0);
            bcbox_SelectedIndexChanged = true;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadDataSource()
        {
            LoadDataSourceHead();
            LoadDataSourceDetails();
        }
        /// <summary>
        /// 加载表头数据
        /// </summary>
        public void LoadDataSourceHead()
        {
            string strSQL = string.Format("select * from 归并后料件清单 where 归并后料件id ={0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtHead = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtHead.Rows.Count > 0)
            {
                rowHead = dtHead.Rows[0];
                fillControl(rowHead);
            }
            else
            {
                rowHead = dtHead.NewRow();
                dtHead.Rows.Add(rowHead);
                rowHead["主料"] = cbox_主料.SelectedText;
                rowHead["电子帐册号"] = cbox_电子帐册号.SelectedValue;
                fillControl(rowHead);
            }
        }
        /// <summary>
        /// 加载表身出口成品数据
        /// </summary>
        public void LoadDataSourceDetails()
        {
            string strSQL = string.Format("商品归并表录入查询 {0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtDetails = dataAccess.GetTable(strSQL.ToString(), null);
            dataAccess.Close();
            bCellKeyPress = false;
            this.myDataGridViewDetails.DataSource = dtDetails;
            bCellKeyPress = true;
            if (dtDetails.Rows.Count == 0)
                dtDetailsAddRow();
            setTool2Enabled();
        }
        /// <summary>
        /// 检查数据是否有修改，并返回对应的操作选项
        /// Yes：保存资料，并继续;；No：不保存资料，并继续；Cancel：取消操作，返回界面
        /// </summary>
        /// <returns>Yes：保存资料，并继续;；No：不保存资料，并继续；Cancel：取消操作，返回界面</returns>
        public DialogResult CheckModify()
        {
            bool bModify = false;
            if (rowHead.RowState == DataRowState.Modified)
            {
                bModify = true;
            }
            else if (rowHead.RowState == DataRowState.Added)
            {
                if (rowHead["产品编号"].ToString().Length > 0)
                {
                    bModify = true;
                }
            }
            //如果表头没异动，再判断表身是否有异动
            if (!bModify)
            {
                //归并前料件id
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
                        else if (row.RowState == DataRowState.Added)  //如果是新增状态，则判断商品编号是否为空
                        {
                            if (row["产品编号"] != DBNull.Value || row["产品编号"].ToString().Trim().Length > 0)
                            {
                                bModify = true;
                                break;
                            }
                        }
                        else if (row.RowState == DataRowState.Deleted)
                        {
                            if (row["归并前料件id", DataRowVersion.Original] != DBNull.Value)
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
        /// <summary>
        /// 填充表头数据到控件上
        /// </summary>
        /// <param name="row">来源数据</param>
        private void fillControl(DataRow row)
        {
            if (row.Table.Columns.Contains("序号"))
            {
                txt_序号.Text = row["序号"].ToString();
            }
            if (row.Table.Columns.Contains("主料"))
            {
                cbox_主料.SelectedText = row["主料"].ToString();
            }
            if (row.Table.Columns.Contains("电子帐册号"))
            {
                cbox_电子帐册号.SelectedValue = row["电子帐册号"].ToString();
            }
            if (row.Table.Columns.Contains("产品编号"))
            {
                txt_产品编号.Text = row["产品编号"].ToString();
            }
            if (row.Table.Columns.Contains("商品编码"))
            {
                txt_商品编码.Text = row["商品编码"].ToString();
            }
            if (row.Table.Columns.Contains("商品名称"))
            {
                txt_商品名称.Text = row["商品名称"].ToString();
            }
            if (row.Table.Columns.Contains("商品规格"))
            {
                txt_商品规格.Text = row["商品规格"].ToString();
            }
            if (row.Table.Columns.Contains("产销国"))
            {
                txt_产销国.Text = row["产销国"].ToString();
            }
            if (row.Table.Columns.Contains("损耗率"))
            {
                txt_损耗率.Text = row["损耗率"].ToString();
            }
            if (row.Table.Columns.Contains("单价"))
            {
                txt_单价.Text = row["单价"].ToString();
            }
            if (row.Table.Columns.Contains("币种"))
            {
                txt_币种.Text = row["币种"].ToString();
            }
            if (row.Table.Columns.Contains("计量单位"))
            {
                txt_计量单位.Text = row["计量单位"].ToString();
            }
            if (row.Table.Columns.Contains("法定单位"))
            {
                txt_法定单位.Text = row["法定单位"].ToString();
            }
            if (row.Table.Columns.Contains("换算因子"))
            {
                txt_换算因子.Text = row["换算因子"].ToString();
            }
            if (row.Table.Columns.Contains("四位大类序号"))
            {
                txt_四位大类序号.Text = row["四位大类序号"].ToString();
            }
        }

        /// <summary>
        /// 保存数据，并返回是否保存成功
        /// <param name="bShowSuccessMsg">保存成功时是否弹出提示信息</param>
        /// </summary>
        public bool Save(bool bShowSuccessMsg)
        {
            bool bSuccess = true;
            try
            {
                #region 前期验证
                if (txt_产品编号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("产品编号不能为空！");
                    txt_产品编号.Focus();
                    return false;
                }
                if (txt_商品编码.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("商品编码不能为空！");
                    txt_商品编码.Focus();
                    return false;
                }
                #endregion
                StringBuilder strBuilder = new StringBuilder();
                if (rowHead.RowState == DataRowState.Added)
                {
                    #region 新增数据
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    dataAccess.BeginTran();
                    try
                    {
                        #region 新增表头数据
                        strBuilder.AppendLine(@"INSERT INTO [归并后料件清单]([电子帐册号],[序号],[产品编号],[商品编码],[商品名称],[商品规格],[产销国]
           ,[计量单位],[法定单位],[换算因子],[单价],[损耗率],[币种],[主料],[四位大类序号])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})",
                            rowHead["电子帐册号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["电子帐册号"].ToString()),
                            rowHead["序号"] == DBNull.Value ? "NULL" : rowHead["序号"].ToString(),
                            rowHead["产品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品编号"].ToString()),
                            rowHead["商品编码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["商品编码"].ToString()),
                            rowHead["商品名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["商品名称"].ToString()),
                            rowHead["商品规格"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["商品规格"].ToString()),
                            rowHead["产销国"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产销国"].ToString()),
                            rowHead["计量单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["计量单位"].ToString()),
                            rowHead["法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["法定单位"].ToString()),
                            rowHead["换算因子"] == DBNull.Value ? "NULL" : rowHead["换算因子"],
                            rowHead["单价"] == DBNull.Value ? "NULL" : rowHead["单价"],
                            rowHead["损耗率"] == DBNull.Value ? "NULL" : rowHead["损耗率"],
                            rowHead["币种"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["币种"].ToString()),
                            rowHead["主料"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["主料"].ToString()),
                            rowHead["四位大类序号"] == DBNull.Value ? "NULL" : rowHead["四位大类序号"]);
                        strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object 归并后料件id = dtInsert.Rows[0][0]; // dataAccess.ExecScalar(strBuilder.ToString(), null);
                        rowHead["归并后料件id"] = 归并后料件id;
                        strBuilder.Clear();
                        #endregion

                        #region 新增明细数据
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            if (row["产品编号"] == DBNull.Value || row["产品编号"].ToString().Trim().Length == 0) continue;
                            strBuilder.AppendLine("INSERT INTO [归并前料件清单]([归并后料件id],[产品编号],[序号],[商品规格],[对应编号],[单价])");
                            strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5})",
                                归并后料件id, row["产品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["产品编号"].ToString()),
                                row["序号"] == DBNull.Value ? "NULL" : row["序号"],
                                row["商品规格"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品规格"].ToString()),
                                row["对应编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["对应编号"].ToString()),
                                row["单价"] == DBNull.Value ? "NULL" : row["单价"]);
                            strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                            object 归并前料件id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            row["归并前料件id"] = 归并前料件id;
                        }
                        #endregion

                        giOrderID = Convert.ToInt32(归并后料件id);
                        dataAccess.CommitTran();
                        dataAccess.Close();
                    }
                    catch (Exception ex)
                    {
                        dataAccess.RollbackTran();
                        dataAccess.Close();
                        throw new Exception(ex.Message);
                    }
                    #endregion
                }
                else //if (rowHead.RowState == DataRowState.Modified || (dtDetails.GetChanges() !=null && dtDetails.GetChanges().Rows.Count>0))
                {
                    #region 修改数据
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    dataAccess.BeginTran();
                    try
                    {
                        #region 修改表头数据
                        if (rowHead.RowState == DataRowState.Modified)
                        {
                            strBuilder.AppendFormat(@"UPDATE [归并后料件清单]
   SET [电子帐册号] = {0},[序号] = {1},[产品编号] = {2},[商品编码] = {3},[商品名称] = {4},[商品规格] = {5},[产销国] = {6},[计量单位] = {7},
   [法定单位] ={8},[换算因子] = {9},[单价] = {10},[损耗率] ={11},[币种] ={12},[主料] = {13},[四位大类序号] ={14} where 归并后料件id={15}",
                            rowHead["电子帐册号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["电子帐册号"].ToString()),
                            rowHead["序号"] == DBNull.Value ? "NULL" : rowHead["序号"].ToString(),
                            rowHead["产品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品编号"].ToString()),
                            rowHead["商品编码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["商品编码"].ToString()),
                            rowHead["商品名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["商品名称"].ToString()),
                            rowHead["商品规格"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["商品规格"].ToString()),
                            rowHead["产销国"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产销国"].ToString()),
                            rowHead["计量单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["计量单位"].ToString()),
                            rowHead["法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["法定单位"].ToString()),
                            rowHead["换算因子"] == DBNull.Value ? "NULL" : rowHead["换算因子"],
                            rowHead["单价"] == DBNull.Value ? "NULL" : rowHead["单价"],
                            rowHead["损耗率"] == DBNull.Value ? "NULL" : rowHead["损耗率"],
                            rowHead["币种"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["币种"].ToString()),
                            rowHead["主料"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["主料"].ToString()),
                            rowHead["四位大类序号"] == DBNull.Value ? "NULL" : rowHead["四位大类序号"],
                            rowHead["归并后料件id"]);
                            dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                            strBuilder.Clear();
                        }
                        #endregion

                        #region 处理明细数据
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            #region 新增表身数据
                            if (row.RowState == DataRowState.Added)
                            {
                                if (row["产品编号"] == DBNull.Value || row["产品编号"].ToString().Trim().Length == 0) continue;
                                strBuilder.AppendLine("INSERT INTO [归并前料件清单]([归并后料件id],[产品编号],[序号],[商品规格],[对应编号],[单价])");
                                strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5})",
                                    rowHead["归并后料件id"], row["产品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["产品编号"].ToString()),
                                    row["序号"] == DBNull.Value ? "NULL" : row["序号"],
                                    row["商品规格"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品规格"].ToString()),
                                    row["对应编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["对应编号"].ToString()),
                                    row["单价"] == DBNull.Value ? "NULL" : row["单价"]);
                                strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                                object 归并前料件id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                                strBuilder.Clear();
                                row["归并前料件id"] = 归并前料件id;
                            }
                            #endregion

                            #region 删除表身数据
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                if (row["归并前料件id", DataRowVersion.Original] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"DELETE FROM [归并前料件清单] WHERE 归并前料件id={0}", row["归并前料件id", DataRowVersion.Original]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion

                            #region 修改表身数据
                            else if (row.RowState == DataRowState.Modified)
                            {
                                if (row["归并前料件id"] == DBNull.Value) continue;
                                if (row["产品编号"] == DBNull.Value || row["产品编号"].ToString().Trim().Length == 0)
                                {
                                    strBuilder.AppendFormat(@"DELETE FROM [归并前料件清单] WHERE 归并前料件id={0}", row["归并前料件id"]);
                                }
                                else
                                {
                                    strBuilder.AppendFormat(@"UPDATE [归并前料件清单] SET [归并后料件id] = {0},[产品编号] = {1},
                                                        [序号] = {2},[商品规格] = {3},[对应编号] = {4},[单价] = {5} WHERE [归并前料件id]={6}",
                                    rowHead["归并后料件id"], row["产品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["产品编号"].ToString()),
                                    row["序号"] == DBNull.Value ? "NULL" : row["序号"],
                                    row["商品规格"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品规格"].ToString()),
                                    row["对应编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["对应编号"].ToString()),
                                    row["单价"] == DBNull.Value ? "NULL" : row["单价"],
                                    row["归并前料件id"]);
                                }
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion
                        }
                        #endregion

                        dataAccess.CommitTran();
                        dataAccess.Close();
                    }
                    catch (Exception ex)
                    {
                        dataAccess.RollbackTran();
                        dataAccess.Close();
                        throw new Exception(ex.Message);
                    }
                    #endregion
                }
                dtHead.AcceptChanges();
                bCellKeyPress = false;
                dtDetails.AcceptChanges();
                bCellKeyPress = true;
                if (bSuccess && bShowSuccessMsg)
                {
                    SysMessage.InformationMsg("保存成功！");
                }
                //LoadDataSourceDetails();
            }
            catch (Exception ex)
            {
                bSuccess = false;
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine("保存数据出错：");
                strBuilder.AppendLine(ex.Message);
                SysMessage.ErrorMsg(strBuilder.ToString());
            }
            return bSuccess;
        }
        #endregion
        
        #region 表头tool
        private void tool1_Add_Click(object sender, EventArgs e)
        {
            DialogResult result = CheckModify();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.Yes:
                    if (Save(false))
                        LoadDataSource();
                    break;
                case System.Windows.Forms.DialogResult.No:
                    {
                        giOrderID = 0;
                        LoadDataSource();
                    }
                    break;
                case System.Windows.Forms.DialogResult.Cancel:

                    break;
            }
        }

        private void tool1_Save_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        private void tool1_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 表身tool
        private void tool2_First_Click(object sender, EventArgs e)
        {
            this.myDataGridViewDetails.ClearSelection();
            this.myDataGridViewDetails.Rows[0].Selected = true;
            this.myDataGridViewDetails.CurrentCell = this.myDataGridViewDetails.Rows[0].Cells[gstrDetailFirstField];
            setTool2Enabled();
        }

        private void tool2_up_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.myDataGridViewDetails.CurrentRow.Index;
            this.myDataGridViewDetails.ClearSelection();
            this.myDataGridViewDetails.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewDetails.CurrentCell = this.myDataGridViewDetails.Rows[iSelectRow - 1].Cells[gstrDetailFirstField];
            setTool2Enabled();
        }

        private void tool2_Down_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.myDataGridViewDetails.CurrentRow.Index;
            this.myDataGridViewDetails.ClearSelection();
            this.myDataGridViewDetails.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewDetails.CurrentCell = this.myDataGridViewDetails.Rows[iSelectRow + 1].Cells[gstrDetailFirstField];
            setTool2Enabled();
        }

        private void tool2_End_Click(object sender, EventArgs e)
        {
            this.myDataGridViewDetails.ClearSelection();
            this.myDataGridViewDetails.Rows[this.myDataGridViewDetails.RowCount - 1].Selected = true;
            this.myDataGridViewDetails.CurrentCell = this.myDataGridViewDetails.Rows[this.myDataGridViewDetails.RowCount - 1].Cells[gstrDetailFirstField];
            setTool2Enabled();
        }

        //导入
        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void tool2_Add_Click(object sender, EventArgs e)
        {
            dtDetailsAddRow();
        }

        private void tool2_Delete_Click(object sender, EventArgs e)
        {
            this.myDataGridViewDetails.Rows.RemoveAt(this.myDataGridViewDetails.CurrentRow.Index);
            setTool2Enabled();
        }

        /// <summary>
        /// 设置出口成品tools的按钮是否可用
        /// </summary>
        public void setTool2Enabled()
        {
            if (dtDetails != null && dtDetails.Rows.Count > 0)
            {
                //如果总行数为1时，则笔数移动按钮都为不可编辑
                if (dtDetails.Rows.Count == 1)
                {
                    this.tool2_First.Enabled = false;
                    this.tool2_up.Enabled = false;
                    this.tool2_Down.Enabled = false;
                    this.tool2_End.Enabled = false;
                }
                else
                {
                    //如果当前行索引为0
                    if (this.myDataGridViewDetails.CurrentRow == null) return;
                    if (this.myDataGridViewDetails.CurrentRow.Index == 0)
                    {
                        this.tool2_First.Enabled = false;
                        this.tool2_up.Enabled = true;
                        this.tool2_Down.Enabled = true;
                        this.tool2_End.Enabled = true;
                    }
                    else if (this.myDataGridViewDetails.CurrentRow.Index == this.myDataGridViewDetails.RowCount - 1)  //如果行索引为最后一行
                    {
                        this.tool2_First.Enabled = true;
                        this.tool2_up.Enabled = true;
                        this.tool2_Down.Enabled = false;
                        this.tool2_End.Enabled = false;
                    }
                    else
                    {
                        this.tool2_First.Enabled = true;
                        this.tool2_up.Enabled = true;
                        this.tool2_Down.Enabled = true;
                        this.tool2_End.Enabled = true;
                    }
                }

                this.tool2_Delete.Enabled = true;
            }
            else
            {
                this.tool2_First.Enabled = false;
                this.tool2_up.Enabled = false;
                this.tool2_Down.Enabled = false;
                this.tool2_End.Enabled = false;

                this.tool2_Delete.Enabled = false;
            }
        }
        /// <summary>
        /// 明细增加一条记录
        /// </summary>
        public void dtDetailsAddRow()
        {
            DataRow newRow = dtDetails.NewRow();
            int i序号=dtDetails.Rows.Count + 1;
            newRow["序号"] = i序号;
            if(txt_商品编码.Text.Trim().Length>0)
            {
                newRow["产品编号"] = i序号>9 ? string.Format("{0}{1}", txt_产品编号.Text.Trim(), i序号) : string.Format("{0}0{1}", txt_产品编号.Text.Trim(), i序号);
                newRow["商品编码"] = txt_商品编码.Text.Trim();
                newRow["商品名称"] = txt_商品名称.Text.Trim();
                newRow["计量单位"] = txt_计量单位.Text.Trim();
                newRow["法定单位"] = txt_法定单位.Text.Trim();
                newRow["币种"] = "USD";
                newRow["单价"] =txt_单价.Text.Length == 0 ? 0 : Convert.ToDecimal( txt_单价.Text);
                newRow["换算因子"] = txt_换算因子.Text.Length == 0 ? 0 : Convert.ToDecimal( txt_换算因子.Text);
            }
            dtDetails.Rows.Add(newRow);
            setTool2Enabled();
        }
        #endregion

        #region 表头控件事件
        private void txt_Validated(object sender, EventArgs e)
        {
            myTextBox txtBox = (myTextBox)sender;
            string fieldName = txtBox.Name.Replace("txt_", "");
            if (rowHead[fieldName].ToString() != txtBox.Text)
            {
                if (fieldName=="序号" || fieldName == "损耗率" || fieldName == "单价" || fieldName == "换算因子")
                {
                    if (txtBox.Text.Trim().Length == 0)
                    {
                        rowHead[fieldName] = DBNull.Value;
                    }
                    else
                    {
                        rowHead[fieldName] = txtBox.Text;
                        if (fieldName == "序号")
                        {
                            if (txt_产品编号.Text.Trim().Length > 0) return;
                            if (txtBox.Text.Length == 1)
                            {
                                txt_产品编号.Text = string.Format("A0{0}", txtBox.Text.Trim());
                            }
                            else
                            {
                                txt_产品编号.Text = string.Format("A{0}", txtBox.Text.Trim());
                            }
                            rowHead["产品编号"] = txt_产品编号.Text;
                        }
                    }
                }
                else
                {
                    rowHead[fieldName] = txtBox.Text;
                }
            }
        }
        private void txtInt_Validating(object sender, CancelEventArgs e)
        {
            myTextBox txtBox = (myTextBox)sender;
            if (txtBox.Text.Trim().Length > 0)
            {
                try
                {
                    int.Parse(txtBox.Text.Trim());
                }
                catch (Exception ex)
                {
                    SysMessage.ErrorMsg(ex.Message);
                    e.Cancel = true;
                }
            }
        }
        private void txtFloat_Validating(object sender, CancelEventArgs e)
        {
            myTextBox txtBox = (myTextBox)sender;
            if (txtBox.Text.Trim().Length > 0)
            {
                try
                {
                    decimal.Parse(txtBox.Text.Trim());
                }
                catch (Exception ex)
                {
                    SysMessage.ErrorMsg(ex.Message);
                    e.Cancel = true;
                }
            }
        }
        private void cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bcbox_SelectedIndexChanged)
            {
                myComboBox cbox = (myComboBox)sender;
                string fieldName = cbox.Name.Replace("cbox_", "");
                rowHead[fieldName] = cbox.Text;
            }
        }
        #endregion

        #region GRID事件
        private void myDataGridViewDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridKeyEnter(dgv, cell, false);
        }

        private void myDataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            myDataGridView dgv = (myDataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "序号" || colName == "单价")
                e.Cancel = false;
        }

        private void myDataGridViewDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == SystemConst.GridKeysEnter)
            {
                myDataGridView dgv = sender as myDataGridView;
                DataGridViewCell cell = dgv.CurrentCell;
                GridKeyEnter(dgv, cell, true);
            }
        }

        private void myDataGridViewDetails_SelectionChanged(object sender, EventArgs e)
        {
            setTool2Enabled();
        }
        private void GridKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
        {
            if (!bCellKeyPress) return;
            string colName = dgv.Columns[cell.ColumnIndex].Name;
            switch (colName)
            {
                case "序号":   //跳转到"产品编号"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["序号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["产品编号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate序号(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["产品编号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["序号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate序号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "产品编号"://跳转到"商品编码"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品编码", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品编码"://跳转到"商品名称"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品名称", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品名称":  //跳转到"商品规格"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品规格", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品规格":  //跳转到"单价"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["单价", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "单价":   //跳转到"币种"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["单价"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["币种", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate单价(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["币种", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["单价"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate单价(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "币种":   //跳转到"计量单位"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["计量单位", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "计量单位":   //跳转到"法定单位"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["法定单位", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "法定单位":   //跳转到"换算因子" 
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["换算因子", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "换算因子":   //跳转到"对应编号"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["对应编号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "对应编号":   //跳转到"序号"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        validate对应编号(dgv, cell);
                        (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                    }
                    #endregion
                    break;
            }
        }
        private void validate序号(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["序号"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["序号"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["序号"].Value = 0;
                }
            }
        }
        private void validate单价(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["单价"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["单价"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["单价"].Value = DBNull.Value;
                }
            }
        }
        private void validate对应编号(myDataGridView dgv, DataGridViewCell cell)
        {
            dgv["对应编号", cell.RowIndex].Value = cell.EditedFormattedValue;
            //如果当前行的商品编号为空，则跳转到当前行的商品编号
            if (dgv.Rows[cell.RowIndex].Cells["产品编号"].Value == DBNull.Value
                || dgv.Rows[cell.RowIndex].Cells["产品编号"].Value.ToString().Trim() == "")
            {
                dgv.CurrentCell = dgv["产品编号", cell.RowIndex];
            }
            else
            {
                //否则跳转到下一行的产品编号，如果是最后一行，则新增一行
                if (cell.RowIndex == dgv.Rows.Count - 1)
                {
                    dtDetailsAddRow();
                    dgv.CurrentCell = dgv["产品编号", cell.RowIndex + 1];
                }
                else
                {
                    dgv.CurrentCell = dgv["产品编号", cell.RowIndex + 1];
                }
            }
        }
        #endregion

    }
}
