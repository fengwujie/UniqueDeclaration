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
                rowHead["录入日期"] = DateTime.Now.Date;
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
            //如果表头没异动，再判断表身是否有异动
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
        /// <summary>
        /// 保存数据，并返回是否保存成功
        /// <param name="bShowSuccessMsg">保存成功时是否弹出提示信息</param>
        /// </summary>
        public override bool Save(bool bShowSuccessMsg)
        {
            bool bSuccess = true;
            try
            {
                #region 前期验证
                if (txt_订单号码.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("订单号码不能为空！");
                    txt_订单号码.Focus();
                    return false;
                }
                if (txt_装箱单号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("装箱单号不能为空！");
                    txt_装箱单号.Focus();
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
                        strBuilder.AppendLine(@"INSERT INTO [装箱单表]([装箱单号],[订单号码],[客户代码],[客户名称],[出货日期],[录入日期],[报关单号],[备案号]
                                                                    ,[用途] ,[征免方式],[产销国] ,[币制],[申报地海关代码],[进口岸代码],[代理单位代码],[出口状态])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},{3},'{4}','{5}',{6},{7},{8},{9},{10},{11},{12},{13},{14},{15})",
                            rowHead["装箱单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["装箱单号"].ToString()),
                            rowHead["订单号码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["订单号码"].ToString()),
                            rowHead["客户代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户代码"].ToString()),
                            rowHead["客户名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户名称"].ToString()),
                            rowHead["出货日期"], rowHead["录入日期"], rowHead["报关单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["报关单号"].ToString()),
                            rowHead["备案号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["备案号"].ToString()),
                            rowHead["用途"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["用途"].ToString()),
                            rowHead["征免方式"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["征免方式"].ToString()),
                            rowHead["产销国"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产销国"].ToString()),
                            rowHead["币制"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["币制"].ToString()),
                            rowHead["申报地海关代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["申报地海关代码"].ToString()),
                            rowHead["进口岸代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进口岸代码"].ToString()),
                            rowHead["代理单位代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["代理单位代码"].ToString()),
                            (rowHead["出口状态"] == DBNull.Value || Convert.ToBoolean(rowHead["出口状态"]) == false) ? 0 : 1);
                        strBuilder.AppendLine("select @@IDENTITY--自动生成的订单ID");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object 订单id = dtInsert.Rows[0][0]; // dataAccess.ExecScalar(strBuilder.ToString(), null);
                        rowHead["订单id"] = 订单id;
                        strBuilder.Clear();
                        #endregion

                        #region 新增明细数据
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            if (row["客人型号"] == DBNull.Value || row["客人型号"].ToString().Trim().Length == 0) continue;
                            if (row["优丽型号"] == DBNull.Value || row["优丽型号"].ToString().Trim().Length == 0) continue;
                            strBuilder.AppendLine(@"INSERT INTO [装箱单明细表]([订单id],[箱号] ,[客人型号],[优丽型号],[成品项号],[成品名称及商编],[成品规格型号]
                                                         ,[手册编号] ,[数量] ,[单位] ,[归并前成品序号] ,[订单号码] ,[内部版本号],[单价])");
                            strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})",
                                订单id, row["箱号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["箱号"].ToString()),
                            row["客人型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["客人型号"].ToString()),
                            row["优丽型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["优丽型号"].ToString()),
                            row["成品项号"] == DBNull.Value ? "NULL" : row["成品项号"],
                            row["成品名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品名称及商编"].ToString()),
                            row["成品规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品规格型号"].ToString()),
                            row["手册编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["手册编号"].ToString()),
                            row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                            row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                            row["归并前成品序号"] == DBNull.Value ? "NULL" : row["归并前成品序号"],
                            row["订单号码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["订单号码"].ToString()),
                            row["内部版本号"] == DBNull.Value ? "NULL" : row["内部版本号"],
                            row["单价"] == DBNull.Value ? "NULL" : row["单价"]);
                            strBuilder.AppendLine("select @@IDENTITY");
                            object 订单明细表id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            row["订单明细表id"] = 订单明细表id;
                        }
                        #endregion
                        giOrderID = Convert.ToInt32(订单id);
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
                            strBuilder.AppendFormat(@"UPDATE [装箱单表] SET [装箱单号] = {0},[订单号码] ={1},[客户代码] = {2},[客户名称] = {3},[出货日期] = '{4}'
                                          ,[录入日期] = '{5}' ,[报关单号] ={6} ,[备案号] = {7} ,[用途] = {8} ,[征免方式] = {9} ,[产销国] = {10} ,[币制] = {11} 
                                            ,[申报地海关代码] = {12} ,[进口岸代码] = {13} ,[代理单位代码] = {14} ,[出口状态] ={15} where 订单id={16}",
                            rowHead["装箱单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["装箱单号"].ToString()),
                            rowHead["订单号码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["订单号码"].ToString()),
                            rowHead["客户代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户代码"].ToString()),
                            rowHead["客户名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户名称"].ToString()),
                            rowHead["出货日期"], rowHead["录入日期"], rowHead["报关单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["报关单号"].ToString()),
                            rowHead["备案号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["备案号"].ToString()),
                            rowHead["用途"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["用途"].ToString()),
                            rowHead["征免方式"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["征免方式"].ToString()),
                            rowHead["产销国"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产销国"].ToString()),
                            rowHead["币制"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["币制"].ToString()),
                            rowHead["申报地海关代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["申报地海关代码"].ToString()),
                            rowHead["进口岸代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进口岸代码"].ToString()),
                            rowHead["代理单位代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["代理单位代码"].ToString()),
                            (rowHead["出口状态"] == DBNull.Value || Convert.ToBoolean(rowHead["出口状态"]) == false) ? 0 : 1, rowHead["订单id"]);
                            dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                            strBuilder.Clear();
                        }
                        #endregion
                        //处理明细数据
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            #region 新增表身数据
                            if (row.RowState == DataRowState.Added)
                            {
                                if (row["客人型号"] == DBNull.Value || row["客人型号"].ToString().Trim().Length == 0) continue;
                                if (row["优丽型号"] == DBNull.Value || row["优丽型号"].ToString().Trim().Length == 0) continue;
                                strBuilder.AppendLine(@"INSERT INTO [装箱单明细表]([订单id],[箱号] ,[客人型号],[优丽型号],[成品项号],[成品名称及商编],[成品规格型号]
                                                         ,[手册编号] ,[数量] ,[单位] ,[归并前成品序号] ,[订单号码] ,[内部版本号],[单价])");
                                strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})",
                                   rowHead["订单id"], row["箱号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["箱号"].ToString()),
                                row["客人型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["客人型号"].ToString()),
                                row["优丽型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["优丽型号"].ToString()),
                                row["成品项号"] == DBNull.Value ? "NULL" : row["成品项号"],
                                row["成品名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品名称及商编"].ToString()),
                                row["成品规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品规格型号"].ToString()),
                                row["手册编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["手册编号"].ToString()),
                                row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                row["归并前成品序号"] == DBNull.Value ? "NULL" : row["归并前成品序号"],
                                row["订单号码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["订单号码"].ToString()),
                                row["内部版本号"] == DBNull.Value ? "NULL" : row["内部版本号"],
                                row["单价"] == DBNull.Value ? "NULL" : row["单价"]);
                                strBuilder.AppendLine("select @@IDENTITY");
                                object 订单明细表id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                                strBuilder.Clear();
                                row["订单明细表id"] = 订单明细表id;
                            }
                            #endregion

                            #region 删除表身数据
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                if (row["订单明细表id", DataRowVersion.Original] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"DELETE FROM [装箱单明细表] WHERE 订单明细表id={0}", row["订单明细表id", DataRowVersion.Original]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion

                            #region 修改表身数据
                            else //if (row.RowState == DataRowState.Modified)
                            {
                                if (row["订单明细表id"] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"UPDATE [装箱单明细表] SET [订单id] = {0},[箱号] = {1},[客人型号] ={2} ,[优丽型号] = {3},[成品项号] = {4}
                                                ,[成品名称及商编] = {5} ,[成品规格型号] = {6} ,[手册编号] = {7} ,[数量] = {8} ,[单位] = {9} ,[归并前成品序号] = {10}
                                                ,[订单号码] = {11},[内部版本号] = {12} ,[单价] = {13} WHERE 订单明细表id={14}",
                                         rowHead["订单id"], row["箱号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["箱号"].ToString()),
                                row["客人型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["客人型号"].ToString()),
                                row["优丽型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["优丽型号"].ToString()),
                                row["成品项号"] == DBNull.Value ? "NULL" : row["成品项号"],
                                row["成品名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品名称及商编"].ToString()),
                                row["成品规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品规格型号"].ToString()),
                                row["手册编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["手册编号"].ToString()),
                                row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                row["归并前成品序号"] == DBNull.Value ? "NULL" : row["归并前成品序号"],
                                row["订单号码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["订单号码"].ToString()),
                                row["内部版本号"] == DBNull.Value ? "NULL" : row["内部版本号"],
                                row["单价"] == DBNull.Value ? "NULL" : row["单价"], row["订单明细表id"]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion
                        }
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
                    DataRow selectRow = null;
                    if (dtTemp.Rows.Count == 1)
                    {
                        selectRow = dtTemp.Rows[0];
                    }
                    else
                    {
                        FormBaseSingleSelect selectForm = new FormBaseSingleSelect();
                        selectForm.strFormText = "选择订单号码";
                        selectForm.dtData = dtTemp;
                        if (selectForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            selectRow = selectForm.returnRow;
                        }
                    }
                    if (selectRow != null)
                    {
                        rowHead["订单号码"] = selectRow["订单号码"];
                        rowHead["客户代码"] = selectRow["客户代码"];
                        rowHead["客户名称"] = selectRow["客户名称"];
                        if (txt_装箱单号.Text.Trim().Length == 0)
                            rowHead["装箱单号"] = selectRow["订单号码"];

                        txt_订单号码.Text = selectRow["订单号码"].ToString();
                        txt_客户代码.Text = selectRow["客户代码"].ToString();
                        txt_客户名称.Text = selectRow["客户名称"].ToString();
                        cbox_手册编号.SelectedValue = selectRow["手册编号"];
                        if (txt_装箱单号.Text.Trim().Length == 0)
                            txt_装箱单号.Text = selectRow["订单号码"].ToString();

                        set订单号码();
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
        private void set订单号码()
        {
            foreach (DataRow row in dtDetails.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                if (txt_订单号码.Text.Trim().Length>0 && (row["订单号码"] == DBNull.Value || row["订单号码"].ToString() == ""))
                    row["订单号码"] = txt_订单号码.Text.Trim();
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
            IDataAccess dataManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            IDataAccess dataUniquegrade = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);

                //如果最后一行的客人型号和优丽型号都为空，则删除掉
                    //int iCount = dtDetails.Rows.Count - 1;
                    //DataRow rowLast = dtDetails.Rows[iCount];
                    int iCount = this.dataGridViewDetail.Rows.Count - 1;
                    DataRow rowLast = (this.dataGridViewDetail.Rows[this.dataGridViewDetail.Rows.Count - 1].DataBoundItem as DataRowView).Row;
                    if (rowLast.RowState == DataRowState.Added)
                    {
                        if ((rowLast["客人型号"] == DBNull.Value || rowLast["客人型号"].ToString().Trim().Length == 0) &&
                         (rowLast["优丽型号"] == DBNull.Value || rowLast["优丽型号"].ToString().Trim().Length > 0))
                        {
                            //dtDetails.Rows.RemoveAt(iCount);
                            this.dataGridViewDetail.Rows.RemoveAt(iCount);
                        }
                    }

            foreach (string OrderCode in txt_订单号码.Text.Trim().Split(','))
            {
                dataManufacture.Open();
                DataTable dt报关订单表 = dataManufacture.GetTable(string.Format("select 订单id,手册编号,订单号码 from 报关订单表 where 订单号码={0}",StringTools.SqlQ(OrderCode)), null);
                dataManufacture.Close();
                if (dt报关订单表.Rows.Count == 0) continue;
                dataManufacture.Open();
                DataTable dt报关订单录入查询 = dataManufacture.GetTable(string.Format("报关订单录入查询 {0}",dt报关订单表.Rows[0]["订单id"]), null);
                dataManufacture.Close();
                DataTable dtData = dt报关订单录入查询.Clone();
                DataRow[] rows = dt报关订单录入查询.Select("","成品项号");
                foreach (DataRow r in rows)
                    dtData.ImportRow(r);
                foreach (DataRow row in dtData.Rows)
                {
                    dataUniquegrade.Open();
                    DataTable dt装箱单 = dataUniquegrade.GetTable(string.Format(@"select 客人型号,优丽型号,sum(数量) as 数量  from 装箱单表 
                                                                                    inner join 装箱单明细表 on 装箱单表.订单id=装箱单明细表.订单id 
                                                                            where 装箱单明细表.订单号码= {0} and 客人型号 ={1} and 优丽型号 ={1}  group by 客人型号,优丽型号",
                                                    StringTools.SqlQ(OrderCode), StringTools.SqlQ(row["客人型号"].ToString()), StringTools.SqlQ(row["优丽型号"].ToString())), null);
                    dataUniquegrade.Close();
                    if (dt装箱单.Rows.Count > 0)
                    {
                        DataRow row装箱单 = dt装箱单.Rows[0];
                        if (row["订单数量"] != DBNull.Value && row装箱单["数量"] != DBNull.Value
                            && StringTools.decimalParse(row["订单数量"].ToString()) - StringTools.decimalParse(row装箱单["数量"].ToString()) > 0)
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
                                newRow["成品规格型号"] = string.Format("{0}G/{1}", row["总重"], row["申报单位"]);
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
                            newRow["成品规格型号"] = string.Format("{0}G/{1}", row["总重"], row["申报单位"]);
                        }
                        newRow["归并前成品序号"] = row["版本号"];
                        newRow["内部版本号"] = row["内部版本号"];
                        dtDetails.Rows.Add(newRow);
                    }
                }
            }
            if (this.dataGridViewDetail.Rows.Count == 0)
            {
                dtDetailsAddRow();
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
                case "箱号":   //跳转到"型号"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["客人型号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "客人型号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["客人型号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate客人型号(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["客人型号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate客人型号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "优丽型号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["优丽型号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate优丽型号(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["优丽型号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate优丽型号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "数量":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["数量"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["单位", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate数量(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["单位", cell.RowIndex];
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
                case "订单号码":   
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["手册编号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "手册编号":   
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["成品项号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "成品项号":    
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["成品名称及商编", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "成品名称及商编":   
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["成品规格型号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "成品规格型号":   
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["数量", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "归并前成品序号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["内部版本号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "内部版本号":  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["成品项号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "单位":   //跳转到"客人型号"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        validate单位(dgv, cell);
                        (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                    }
                    #endregion
                    break;
            }
        }
        private bool validate客人型号(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue != DBNull.Value && cell.EditedFormattedValue.ToString() != "")
            {
                if (!string.IsNullOrEmpty(cell.EditedFormattedValue.ToString()))
                {
                    if (txt_客户代码.Text.Trim().Length == 0)
                    {
                        SysMessage.InformationMsg("请先输入客户代码");
                        txt_客户代码.Focus();
                        dgv.CurrentCell = cell;
                        return false;
                    }
                    string strSQL = string.Format(@"select 客人型号,优丽型号,内部版本号,版本号 as 归并前成品序号,成品项号,成品名称及商编,成品规格型号,手册编号,
                                                    申报单位 as 单位,订单数量 from 报关订单表 inner join 报关订单明细表 on 报关订单表.订单id=报关订单明细表.订单id 
                                                    where 订单号码= {0} and 客人型号 like '%{1}%'",
                                    StringTools.SqlQ(dgv.CurrentRow.Cells["订单号码"].Value.ToString()), StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));
                    IDataAccess dataManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataManufacture.Open();
                    DataTable dttabArticle = dataManufacture.GetTable(strSQL, null);
                    dataManufacture.Close();
                    DataRow selectRow = null;
                    if (dttabArticle.Rows.Count == 0)
                    {
                        return true;
                    }
                    else if (dttabArticle.Rows.Count == 1)
                    {
                        selectRow = dttabArticle.Rows[0];
                    }
                    else if (dttabArticle.Rows.Count > 1)
                    {
                        FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                        formSelect.strFormText = "选择客户型号";
                        formSelect.dtData = dttabArticle;
                        if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            selectRow = formSelect.returnRow;
                        }
                        else
                        {
                            //dgv.CurrentCell = cell;
                            return true;
                        }
                    }

                    IDataAccess dataUniquegrade = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                    dataUniquegrade.Open();
                    DataTable dt装箱单表 = dataUniquegrade.GetTable(string.Format(@"select 客人型号,优丽型号,sum(数量) as 数量  from 装箱单表 
                                                                                    inner join 装箱单明细表 on 装箱单表.订单id=装箱单明细表.订单id 
                                                                    where 装箱单明细表.订单号码={0} and 客人型号 ={1} and 优丽型号 = {2} group by 客人型号,优丽型号",
                                                StringTools.SqlQ(dgv.CurrentRow.Cells["订单号码"].Value.ToString()),StringTools.SqlQ( selectRow["客人型号"].ToString()),
                                                StringTools.SqlQ(selectRow["优丽型号"].ToString())), null);
                    dataUniquegrade.Close();
                    if(dt装箱单表.Rows.Count>0)
                    {
                        if (StringTools.decimalParse(selectRow["订单数量"].ToString()) - StringTools.decimalParse(dt装箱单表.Rows[0]["数量"].ToString()) 
                            + StringTools.decimalParse(dgv.CurrentRow.Cells["数量"].Value.ToString()) <= 0)
                        {
                            if (SysMessage.YesNoMsg("此型号已全部出口，无须再出,是否继续") == System.Windows.Forms.DialogResult.No)
                            {
                                dgv.CurrentRow.Cells["客人型号"].Value = DBNull.Value;
                                return true;
                            }
                        }
                    }
                    dgv.CurrentRow.Cells["客人型号"].Value = selectRow["客人型号"];
                    dgv.CurrentRow.Cells["优丽型号"].Value = selectRow["优丽型号"];
                    dgv.CurrentRow.Cells["成品项号"].Value = selectRow["成品项号"];
                    dgv.CurrentRow.Cells["归并前成品序号"].Value = selectRow["归并前成品序号"];
                    dgv.CurrentRow.Cells["内部版本号"].Value = selectRow["内部版本号"];
                    dgv.CurrentRow.Cells["成品名称及商编"].Value = selectRow["成品名称及商编"];
                    dgv.CurrentRow.Cells["成品规格型号"].Value = selectRow["成品规格型号"];
                    dgv.CurrentRow.Cells["手册编号"].Value = selectRow["手册编号"];
                    dgv.CurrentRow.Cells["单位"].Value = selectRow["单位"];
                    dgv.CurrentRow.Cells["数量"].Value =StringTools.decimalParse( selectRow["订单数量"].ToString()) - (dt装箱单表.Rows.Count>0 ? StringTools.decimalParse( dt装箱单表.Rows[0]["数量"].ToString()):0);
                }
            }
            return true;
        }
        private bool validate优丽型号(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue != DBNull.Value && cell.EditedFormattedValue.ToString() != "")
            {
                if (!string.IsNullOrEmpty(cell.EditedFormattedValue.ToString()))
                {
                    if (txt_客户代码.Text.Trim().Length == 0)
                    {
                        SysMessage.InformationMsg("请先输入客户代码");
                        txt_客户代码.Focus();
                        dgv.CurrentCell = cell;
                        return false;
                    }
                    string strSQL = string.Format(@"select 客人型号,优丽型号,内部版本号,版本号 as 归并前成品序号,成品项号,成品名称及商编,成品规格型号,手册编号,
                                                            申报单位 as 单位,订单数量 from 报关订单表 inner join 报关订单明细表 on 报关订单表.订单id=报关订单明细表.订单id 
                                                    where 订单号码={0} and 优丽型号 like '%{1}%'",
                                    StringTools.SqlQ(dgv.CurrentRow.Cells["订单号码"].Value.ToString()), StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));
                    IDataAccess dataManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataManufacture.Open();
                    DataTable dttabArticle = dataManufacture.GetTable(strSQL, null);
                    dataManufacture.Close();
                    DataRow selectRow = null;
                    if (dttabArticle.Rows.Count == 0)
                    {
                        return true;
                    }
                    else if (dttabArticle.Rows.Count == 1)
                    {
                        selectRow = dttabArticle.Rows[0];
                    }
                    else if (dttabArticle.Rows.Count > 1)
                    {
                        FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                        formSelect.strFormText = "选择客户型号";
                        formSelect.dtData = dttabArticle;
                        if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            selectRow = formSelect.returnRow;
                        }
                        else
                        {
                            //dgv.CurrentCell = cell;
                            return true;
                        }
                    }
                    IDataAccess dataUniquegrade = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                    dataUniquegrade.Open();
                    DataTable dt装箱单表 = dataUniquegrade.GetTable(string.Format(@"select 客人型号,优丽型号,sum(数量) as 数量  from 装箱单表 
                                                                                    inner join 装箱单明细表 on 装箱单表.订单id=装箱单明细表.订单id 
                                                                    where 装箱单明细表.订单号码={0} and 客人型号 ={1} and 优丽型号 ={2} group by 客人型号,优丽型号",
                                                StringTools.SqlQ(dgv.CurrentRow.Cells["订单号码"].Value.ToString()), StringTools.SqlQ(selectRow["客人型号"].ToString()),
                                                StringTools.SqlQ(selectRow["优丽型号"].ToString())), null);
                    dataUniquegrade.Close();
                    if (dt装箱单表.Rows.Count > 0)
                    {
                        if (StringTools.decimalParse(selectRow["订单数量"].ToString()) - StringTools.decimalParse(dt装箱单表.Rows[0]["数量"].ToString())
                            + StringTools.decimalParse(dgv.CurrentRow.Cells["数量"].Value.ToString()) <= 0)
                        {
                            if (SysMessage.YesNoMsg("此型号已全部出口，无须再出,是否继续") == System.Windows.Forms.DialogResult.No)
                            {
                                dgv.CurrentRow.Cells["客人型号"].Value = DBNull.Value;
                                return true;
                            }
                        }
                    }
                    dgv.CurrentRow.Cells["客人型号"].Value = selectRow["客人型号"];
                    dgv.CurrentRow.Cells["优丽型号"].Value = selectRow["优丽型号"];
                    dgv.CurrentRow.Cells["成品项号"].Value = selectRow["成品项号"];
                    dgv.CurrentRow.Cells["归并前成品序号"].Value = selectRow["归并前成品序号"];
                    dgv.CurrentRow.Cells["内部版本号"].Value = selectRow["内部版本号"];
                    dgv.CurrentRow.Cells["成品名称及商编"].Value = selectRow["成品名称及商编"];
                    dgv.CurrentRow.Cells["成品规格型号"].Value = selectRow["成品规格型号"];
                    dgv.CurrentRow.Cells["手册编号"].Value = selectRow["手册编号"];
                    dgv.CurrentRow.Cells["单位"].Value = selectRow["单位"];
                    dgv.CurrentRow.Cells["数量"].Value = StringTools.decimalParse(selectRow["订单数量"].ToString()) - (dt装箱单表.Rows.Count > 0 ? StringTools.decimalParse(dt装箱单表.Rows[0]["数量"].ToString()) : 0);
                }
            }
            return true;
        }
        private void validate数量(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["订单数量"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["订单数量"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["订单数量"].Value = 0;
                }
            }
        }
        private void validate单位(myDataGridView dgv, DataGridViewCell cell)
        {
            dgv["单位", cell.RowIndex].Value = cell.EditedFormattedValue;
            //如果当前行的客人型号为空，则跳转到当前行的客人型号
            if (dgv.Rows[cell.RowIndex].Cells["客人型号"].Value == DBNull.Value
                || dgv.Rows[cell.RowIndex].Cells["客人型号"].Value.ToString().Trim() == "")
            {
                dgv.CurrentCell = dgv["客人型号", cell.RowIndex];
            }
            else
            {
                //否则跳转到下一行的客人型号，如果是最后一行，则新增一行
                if (cell.RowIndex == dgv.Rows.Count - 1)
                {
                    dtDetailsAddRow();
                    dgv.CurrentCell = dgv["箱号", cell.RowIndex + 1];
                }
                else
                {
                    dgv.CurrentCell = dgv["箱号", cell.RowIndex + 1];
                }
            }
        }
        public override void dataGridViewDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            base.dataGridViewDetail_DataError(sender, e);
            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "数量" || colName == "箱数")
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
