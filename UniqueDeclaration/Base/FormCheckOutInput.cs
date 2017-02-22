using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using System.Configuration;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration.Base
{
    public partial class FormCheckOutInput : UniqueDeclarationBaseForm.FormBaseInput
    {
        public FormCheckOutInput()
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
        private void FormCheckOutInput_Load(object sender, EventArgs e)
        {
            InitControlData();
            LoadDataSource();
            InitGrid();
        }

        private void FormCheckOutInput_FormClosing(object sender, FormClosingEventArgs e)
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
            this.dataGridViewDetail.AutoGenerateColumns = false;
            this.dataGridViewDetail.Columns["BM"].Visible = false;
            this.dataGridViewDetail.Columns["归并前成品id"].Visible = false;
            this.dataGridViewDetail.Columns["序号"].DisplayIndex = 0;
            this.dataGridViewDetail.Columns["产品编号"].DisplayIndex = 1;
            this.dataGridViewDetail.Columns["商品编码"].DisplayIndex = 2;
            this.dataGridViewDetail.Columns["商品名称"].DisplayIndex = 3;
            this.dataGridViewDetail.Columns["商品规格"].DisplayIndex = 4;
            this.dataGridViewDetail.Columns["单价"].DisplayIndex = 5;
            this.dataGridViewDetail.Columns["币种"].DisplayIndex = 6;
            this.dataGridViewDetail.Columns["计量单位"].DisplayIndex = 7;
            this.dataGridViewDetail.Columns["计量单位"].HeaderText = "申报计量单位";
            this.dataGridViewDetail.Columns["法定单位"].DisplayIndex = 8;
            this.dataGridViewDetail.Columns["换算因子"].DisplayIndex = 9;
            this.dataGridViewDetail.Columns["日期"].DisplayIndex = 10;
            this.dataGridViewDetail.Columns["对应编号"].DisplayIndex = 11;
            this.dataGridViewDetail.Columns["商品编码"].ReadOnly = true;
            this.dataGridViewDetail.Columns["商品名称"].ReadOnly = true;
            this.dataGridViewDetail.Columns["计量单位"].ReadOnly = true;
            this.dataGridViewDetail.Columns["法定单位"].ReadOnly = true;
            this.dataGridViewDetail.Columns["换算因子"].ReadOnly = true;
            this.dataGridViewDetail.Columns["币种"].ReadOnly = true;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "F3";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewDetail.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dataGridViewDetail.Columns)
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
            IDataAccess dataAccessUniquegrade = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccessUniquegrade.Open();
            int id = Convert.ToInt32(dataAccessUniquegrade.GetTable(string.Format("SELECT 手册id FROM 手册资料表 where 手册编号='{0}'", ConfigurationManager.AppSettings["defaultManualCode"].ToString()), null).Rows[0]["手册id"]);
            dataAccessUniquegrade.Close();
            this.cbox_手册id.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade,
                "SELECT 手册id,手册编号 FROM 手册资料表 ORDER BY 有效期限 DESC", "手册id", "手册编号", id);
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
            string strSQL = string.Format("select * from 报关产品表 where 报关产品表id= {0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
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
                rowHead["手册id"] = cbox_手册id.SelectedValue;
                fillControl(rowHead);
            }
        }
        /// <summary>
        /// 加载表身出口成品数据
        /// </summary>
        public void LoadDataSourceDetails()
        {
            string strSQL = string.Format("SELECT * FROM 报关产品组成明细表 WHERE 报关产品表id ={0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            dtDetails = dataAccess.GetTable(strSQL.ToString(), null);
            dataAccess.Close();
            bCellKeyPress = false;
            this.dataGridViewDetail.DataSource = dtDetails;
            bCellKeyPress = true;
            //if (dtDetails.Rows.Count == 0)
            //    dtDetailsAddRow();
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
                if (rowHead["客人型号"].ToString().Length > 0 && rowHead["优丽型号"].ToString().Length>0)
                {
                    bModify = true;
                }
            }
            //如果表头没异动，再判断表身是否有异动
            if (!bModify)
            {
                //归并前成品id
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
                            if (row["报关产品组成明细表id", DataRowVersion.Original] != DBNull.Value)
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
            if (row.Table.Columns.Contains("手册id"))
            {
                cbox_手册id.SelectedValue =Convert.ToInt32(row["手册id"]);
            }
            if (row.Table.Columns.Contains("录入日期"))
            {
                if (row["录入日期"] == DBNull.Value)
                {
                    datetime_录入日期.Checked = false;
                }
                else
                {
                    datetime_录入日期.Checked = true;
                    datetime_录入日期.Value = Convert.ToDateTime(row["录入日期"]);
                }
            }
            if (row.Table.Columns.Contains("客人型号"))
            {
                txt_客人型号.SelectedText = row["客人型号"].ToString();
            }
            if (row.Table.Columns.Contains("优丽型号"))
            {
                txt_优丽型号.Text = row["优丽型号"].ToString();
            }
            if (row.Table.Columns.Contains("成品项号"))
            {
                txt_成品项号.Text = row["成品项号"].ToString();
            }
            if (row.Table.Columns.Contains("成品名称及商编"))
            {
                txt_成品名称及商编.Text = row["成品名称及商编"].ToString();
            }
            if (row.Table.Columns.Contains("成品规格型号"))
            {
                txt_成品规格型号.Text = row["成品规格型号"].ToString();
            }
            if (row.Table.Columns.Contains("产品表申报单位"))
            {
                txt_产品表申报单位.Text = row["产品表申报单位"].ToString();
            }
            if (row.Table.Columns.Contains("产品表法定单位"))
            {
                txt_产品表法定单位.Text = row["产品表法定单位"].ToString();
            }
            if (row.Table.Columns.Contains("变更规格型号"))
            {
                txt_变更规格型号.Text = row["变更规格型号"].ToString();
            }
            if (row.Table.Columns.Contains("归并前成品序号"))
            {
                txt_归并前成品序号.Text = row["归并前成品序号"].ToString();
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
                if (txt_客人型号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("客人型号不能为空！");
                    txt_客人型号.Focus();
                    return false;
                }
                if (txt_优丽型号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("优丽型号不能为空！");
                    txt_优丽型号.Focus();
                    return false;
                }
                #endregion
                StringBuilder strBuilder = new StringBuilder();
                if (rowHead.RowState == DataRowState.Added)
                {
                    #region 新增数据
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                    dataAccess.Open();
                    dataAccess.BeginTran();
                    try
                    {
                        #region 新增表头数据
                        strBuilder.AppendLine(@"INSERT INTO [报关产品表]([手册id],[客人型号],[优丽型号],[成品项号],[成品名称及商编],[成品规格型号]
                                                    ,[产品表申报单位],[产品表法定单位],[变更规格型号],[归并前成品序号],[录入日期])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})",
                            rowHead["手册id"] == DBNull.Value ? "NULL" : rowHead["手册id"].ToString(),
                            rowHead["客人型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客人型号"].ToString()),
                            rowHead["优丽型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["优丽型号"].ToString()),
                            rowHead["成品项号"] == DBNull.Value ? "NULL" : rowHead["成品项号"],
                            rowHead["成品名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["成品名称及商编"].ToString()),
                            rowHead["成品规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["成品规格型号"].ToString()),
                            rowHead["产品表申报单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品表申报单位"].ToString()),
                            rowHead["产品表法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品表法定单位"].ToString()),
                            rowHead["变更规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["变更规格型号"].ToString()),
                            rowHead["归并前成品序号"] == DBNull.Value ? "NULL" : rowHead["归并前成品序号"],
                            datetime_录入日期.Checked==true ? StringTools.SqlQ( datetime_录入日期.Value.ToString("yyyy-MM-dd HH:mm:ss")) : "getdate()");
                        strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object 报关产品表id = dtInsert.Rows[0][0]; // dataAccess.ExecScalar(strBuilder.ToString(), null);
                        rowHead["报关产品表id"] = 报关产品表id;
                        strBuilder.Clear();
                        #endregion

                        #region 新增明细数据
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            if (row["产品编号"] == DBNull.Value || row["产品编号"].ToString().Trim().Length == 0) continue;
                            strBuilder.AppendLine(@"INSERT INTO [报关产品组成明细表]([报关产品表id],[料件项号],[料件名称及商编],[料件规格型号],[明细表申报单位],[明细表法定单位]
                                                            ,[备案净耗单位],[备案损耗],[变更净耗单位],[变更损耗],[归并前料件序号],[归并前净耗单位],[归并前损耗])");
                            strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})",
                                报关产品表id, row["料件项号"] == DBNull.Value ? "NULL" : row["料件项号"],
                                row["料件名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["料件名称及商编"].ToString()),
                                row["料件规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["料件规格型号"].ToString()),
                                row["明细表申报单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["明细表申报单位"].ToString()),
                                row["明细表法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["明细表法定单位"].ToString()),
                                row["备案净耗单位"] == DBNull.Value ? "NULL" : row["备案净耗单位"],
                                row["备案损耗"] == DBNull.Value ? "NULL" : row["备案损耗"],
                                row["变更净耗单位"] == DBNull.Value ? "NULL" : row["变更净耗单位"],
                                row["变更损耗"] == DBNull.Value ? "NULL" : row["变更损耗"],
                                row["归并前料件序号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["归并前料件序号"].ToString()),
                                row["归并前净耗单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["归并前净耗单位"].ToString()),
                                row["归并前损耗"] == DBNull.Value ? "NULL" : row["归并前损耗"]);
                            strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                            object 报关产品组成明细表id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            row["报关产品组成明细表id"] = 报关产品组成明细表id;
                        }
                        #endregion

                        giOrderID = Convert.ToInt32(报关产品表id);
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
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                    dataAccess.Open();
                    dataAccess.BeginTran();
                    try
                    {
                        #region 修改表头数据
                        if (rowHead.RowState == DataRowState.Modified)
                        {
                            strBuilder.AppendFormat(@"UPDATE [报关产品表] SET [手册id]={0},[客人型号]={1},[优丽型号]={2},[成品项号]={3},[成品名称及商编]={4},[成品规格型号]={5}
                                                    ,[产品表申报单位]={6},[产品表法定单位]={7},[变更规格型号]={8},[归并前成品序号]={9},[录入日期]={10}) where 报关产品表id={11}",
                            rowHead["手册id"] == DBNull.Value ? "NULL" : rowHead["手册id"].ToString(),
                            rowHead["客人型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客人型号"].ToString()),
                            rowHead["优丽型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["优丽型号"].ToString()),
                            rowHead["成品项号"] == DBNull.Value ? "NULL" : rowHead["成品项号"],
                            rowHead["成品名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["成品名称及商编"].ToString()),
                            rowHead["成品规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["成品规格型号"].ToString()),
                            rowHead["产品表申报单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品表申报单位"].ToString()),
                            rowHead["产品表法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品表法定单位"].ToString()),
                            rowHead["变更规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["变更规格型号"].ToString()),
                            rowHead["归并前成品序号"] == DBNull.Value ? "NULL" : rowHead["归并前成品序号"],
                            datetime_录入日期.Checked == true ? StringTools.SqlQ(datetime_录入日期.Value.ToString("yyyy-MM-dd HH:mm:ss")) : "getdate()",
                            rowHead["报关产品表id"]);
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
                                if (row["料件名称及商编"] == DBNull.Value || row["料件名称及商编"].ToString().Trim().Length == 0) continue;
                                strBuilder.AppendLine(@"INSERT INTO [报关产品组成明细表]([报关产品表id],[料件项号],[料件名称及商编],[料件规格型号],[明细表申报单位],[明细表法定单位]
                                                            ,[备案净耗单位],[备案损耗],[变更净耗单位],[变更损耗],[归并前料件序号],[归并前净耗单位],[归并前损耗])");
                                strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})",
                                    rowHead["报关产品表id"], row["料件项号"] == DBNull.Value ? "NULL" : row["料件项号"],
                                    row["料件名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["料件名称及商编"].ToString()),
                                    row["料件规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["料件规格型号"].ToString()),
                                    row["明细表申报单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["明细表申报单位"].ToString()),
                                    row["明细表法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["明细表法定单位"].ToString()),
                                    row["备案净耗单位"] == DBNull.Value ? "NULL" : row["备案净耗单位"],
                                    row["备案损耗"] == DBNull.Value ? "NULL" : row["备案损耗"],
                                    row["变更净耗单位"] == DBNull.Value ? "NULL" : row["变更净耗单位"],
                                    row["变更损耗"] == DBNull.Value ? "NULL" : row["变更损耗"],
                                    row["归并前料件序号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["归并前料件序号"].ToString()),
                                    row["归并前净耗单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["归并前净耗单位"].ToString()),
                                    row["归并前损耗"] == DBNull.Value ? "NULL" : row["归并前损耗"]);
                                strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                                object 报关产品组成明细表id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                                strBuilder.Clear();
                                row["报关产品组成明细表id"] = 报关产品组成明细表id;
                            }
                            #endregion

                            #region 删除表身数据
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                if (row["报关产品组成明细表id", DataRowVersion.Original] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"DELETE FROM [报关产品组成明细表] WHERE 报关产品组成明细表id={0}", row["报关产品组成明细表id", DataRowVersion.Original]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion

                            #region 修改表身数据
                            else if (row.RowState == DataRowState.Modified)
                            {
                                if (row["报关产品组成明细表id"] == DBNull.Value) continue;
                                if (row["料件名称及商编"] == DBNull.Value || row["料件名称及商编"].ToString().Trim().Length == 0)
                                {
                                    strBuilder.AppendFormat(@"DELETE FROM [报关产品组成明细表] WHERE 报关产品组成明细表id={0}", row["报关产品组成明细表id"]);
                                }
                                else
                                {
                                    strBuilder.AppendFormat(@"[报关产品表id]={0},[料件项号]={1},[料件名称及商编]={2},[料件规格型号]={3},[明细表申报单位]={4},[明细表法定单位]={5}
                                                            ,[备案净耗单位]={6},[备案损耗]={7},[变更净耗单位]={8},[变更损耗]={9},[归并前料件序号]={10},[归并前净耗单位]={11},[归并前损耗]={12} 
                                                            WHERE [报关产品组成明细表id]={13}",
                                    rowHead["报关产品表id"], row["料件项号"] == DBNull.Value ? "NULL" : row["料件项号"],
                                    row["料件名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["料件名称及商编"].ToString()),
                                    row["料件规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["料件规格型号"].ToString()),
                                    row["明细表申报单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["明细表申报单位"].ToString()),
                                    row["明细表法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["明细表法定单位"].ToString()),
                                    row["备案净耗单位"] == DBNull.Value ? "NULL" : row["备案净耗单位"],
                                    row["备案损耗"] == DBNull.Value ? "NULL" : row["备案损耗"],
                                    row["变更净耗单位"] == DBNull.Value ? "NULL" : row["变更净耗单位"],
                                    row["变更损耗"] == DBNull.Value ? "NULL" : row["变更损耗"],
                                    row["归并前料件序号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["归并前料件序号"].ToString()),
                                    row["归并前净耗单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["归并前净耗单位"].ToString()),
                                    row["归并前损耗"] == DBNull.Value ? "NULL" : row["归并前损耗"],
                                    row["报关产品组成明细表id"]);
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

        #region tool2事件
        public override void tool2_Import_Click(object sender, EventArgs e)
        {
            base.tool2_Import_Click(sender, e);
        }
        #endregion
    }
}
