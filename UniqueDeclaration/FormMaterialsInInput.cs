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
using UniqueDeclarationBaseForm;

namespace UniqueDeclaration
{
    public partial class FormMaterialsInInput : UniqueDeclarationBaseForm.FormBaseInput
    {
        public FormMaterialsInInput()
        {
            InitializeComponent();
        }
        
        #region 自定义变量
        /// <summary>
        /// 电子帐册号
        /// </summary>
        public string strBooksNo = string.Empty;
        /// <summary>
        /// 是否触发值变化事件
        /// </summary>
        private bool bcbox_电子帐册号_SelectedIndexChanged = true;
        /// <summary>
        /// 是否已经导入过数据
        /// </summary>
        private bool Importid = false;
        #endregion

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
            this.dataGridViewDetail.Columns["料件入库明细表id"].Visible = false;
            this.dataGridViewDetail.Columns["料件入库明细表id"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["料件id"].Visible = false;
            this.dataGridViewDetail.Columns["料件id"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["料件编号"].DisplayIndex = 0;
            this.dataGridViewDetail.Columns["料件编号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["料号"].DisplayIndex = 1;
            this.dataGridViewDetail.Columns["料号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["料件名"].DisplayIndex = 2;
            this.dataGridViewDetail.Columns["料件名"].ReadOnly = true;
            this.dataGridViewDetail.Columns["料件名"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["商品编码"].DisplayIndex = 3;
            this.dataGridViewDetail.Columns["商品编码"].ReadOnly = true;
            this.dataGridViewDetail.Columns["商品编码"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["商品名称"].DisplayIndex = 4;
            this.dataGridViewDetail.Columns["商品名称"].ReadOnly = true;
            this.dataGridViewDetail.Columns["商品名称"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["商品规格"].DisplayIndex = 5;
            this.dataGridViewDetail.Columns["商品规格"].ReadOnly = true;
            this.dataGridViewDetail.Columns["商品规格"].ContextMenuStrip = this.myContextDetails;

            this.dataGridViewDetail.Columns["单价"].DisplayIndex = 6;
            this.dataGridViewDetail.Columns["单价"].ReadOnly = false;
            this.dataGridViewDetail.Columns["单价"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewDetail.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle2;

            this.dataGridViewDetail.Columns["入库数量"].DisplayIndex = 7;
            this.dataGridViewDetail.Columns["入库数量"].ReadOnly = false;
            this.dataGridViewDetail.Columns["入库数量"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewDetail.Columns["入库数量"].DefaultCellStyle = dataGridViewCellStyle1;


            this.dataGridViewDetail.Columns["总金额"].DisplayIndex = 8;
            //this.myDataGridViewDetails.Columns["总金额"].Width = 60;
            this.dataGridViewDetail.Columns["总金额"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["总金额"].DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDetail.Columns["总金额"].ReadOnly = true;

            this.dataGridViewDetail.Columns["成本价"].DisplayIndex = 9;
            //this.myDataGridViewDetails.Columns["成本价"].Width = 60;
            this.dataGridViewDetail.Columns["成本价"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["成本价"].DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDetail.Columns["成本价"].ReadOnly = true;

            this.dataGridViewDetail.Columns["单位"].DisplayIndex = 10;
            this.dataGridViewDetail.Columns["单位"].ReadOnly = true;
            this.dataGridViewDetail.Columns["单位"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["备注"].DisplayIndex = 11;
            this.dataGridViewDetail.Columns["备注"].ContextMenuStrip = this.myContextDetails;
        }
        public override void InitControlData()
        {
            base.InitControlData();
            this.gstrDetailFirstField = "料件编号";
            bcbox_电子帐册号_SelectedIndexChanged = false;
            this.cbox_电子帐册号.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade,
                "SELECT 手册编号 FROM 手册资料表 ORDER BY 有效期限 DESC", "手册编号", "手册编号");
            bcbox_电子帐册号_SelectedIndexChanged = true;
        }
        /// <summary>
        /// 加载表头数据
        /// </summary>
        public override void LoadDataSourceHead()
        {
            string strSQL = string.Format("select * from 进口料件入库表 WHERE 料件入库表id = {0}", giOrderID);
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
                dataAccess.Open();
                //获取自动生成的单号
                strSQL = string.Format(@"declare @CODE varchar(20)
                                                exec 进口单号生成 'R','R','{0}', @CODE output
                                                select @CODE",DateTime.Now.ToString("yyMMdd"));
                object CODE = dataAccess.ExecScalar(strSQL, null);
                dataAccess.Close();
                rowHead["入库单号"] = CODE;
                rowHead["入库时间"] = DateTime.Now;
                rowHead["电子帐册号"] = "E37168000009";
                rowHead["摘要"] = string.Empty;
                rowHead["录入员"] = SystemGlobal.SystemGlobal_UserInfo.UserName;
                rowHead["过帐标志"] = 0;
                fillControl(rowHead);
                //dtHead.AcceptChanges();
            }
            setForeColor();
        }
        /// <summary>
        /// 加载表身数据
        /// </summary>
        public override void LoadDataSourceDetails()
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            string strSQL = string.Format("exec 进口料件入库录入查询 {0},'{1}'", giOrderID, strBooksNo);
            dataAccess.Open();
            dtDetails = dataAccess.GetTable(strSQL.ToString(), null);
            dataAccess.Close();
            bCellKeyPress = false;
            this.dataGridViewDetail.DataSource = dtDetails;
            bCellKeyPress = true;
            if (dtDetails.Rows.Count == 0)
                dtDetailsAddRow();
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
                if (rowHead["入库单号"].ToString().Length > 0)
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
                            if (row["料件编号"] != DBNull.Value || row["料件编号"].ToString().Trim().Length > 0 ||
                                row["料号"] != DBNull.Value || row["料号"].ToString().Trim().Length > 0)
                            {
                                bModify = true;
                                break;
                            }
                        }
                        else if (row.RowState == DataRowState.Deleted)
                        {
                            if (row["料件入库明细表id", DataRowVersion.Original] != DBNull.Value)
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
                if (txt_入库单号1.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("入库单号不能为空！");
                    txt_入库单号1.Focus();
                    return false;
                }
                if (txt_入库单号2.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("入库单号不能为空！");
                    txt_入库单号2.Focus();
                    return false;
                }
                if (txt_录入员.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("录入员不能为空！");
                    txt_录入员.Focus();
                    return false;
                }
                #endregion

                if (!Convert.ToBoolean(rowHead["过帐标志"]) && SysMessage.YesNoMsg("要过帐吗？") == System.Windows.Forms.DialogResult.Yes)
                    rowHead["过帐标志"] = 1;

                //bool bUpdateCost = true;
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
                        strBuilder.AppendLine(@"INSERT INTO [进口料件入库表]([入库单号] ,[入库时间],[摘要],[报关单号],[发票号],[电子帐册号] ,[录入员]
                                                        ,[过帐标志],[清单编号],[用途],[征免方式],[产销国] ,[币制] ,[申报地海关代码] ,[进口岸代码] ,[代理单位代码])");
                        strBuilder.AppendFormat("VALUES({0},'{1}',{2},{3},{4},'{5}',{6},{7},{8},{9},{10},{11},{12},{13},{14},{15})",
                            rowHead["入库单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["入库单号"].ToString()), rowHead["入库时间"],
                             rowHead["摘要"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["摘要"].ToString()),
                            rowHead["报关单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["报关单号"].ToString()),
                            rowHead["发票号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["发票号"].ToString()),
                            rowHead["电子帐册号"] == DBNull.Value ? "NULL" : rowHead["电子帐册号"],
                            rowHead["录入员"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["录入员"].ToString()),
                            (rowHead["过帐标志"] == DBNull.Value || Convert.ToBoolean(rowHead["过帐标志"]) == false) ? 0 : 1,
                            rowHead["清单编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["清单编号"].ToString()),
                            rowHead["用途"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["用途"].ToString()),
                            rowHead["征免方式"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["征免方式"].ToString()),
                            rowHead["产销国"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产销国"].ToString()),
                            rowHead["币制"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["币制"].ToString()),
                            rowHead["申报地海关代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["申报地海关代码"].ToString()),
                            rowHead["进口岸代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进口岸代码"].ToString()),
                            rowHead["代理单位代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["代理单位代码"].ToString()));
                        strBuilder.AppendLine("select @@IDENTITY");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object 料件入库表id = dtInsert.Rows[0][0]; // dataAccess.ExecScalar(strBuilder.ToString(), null);
                        rowHead["料件入库表id"] = 料件入库表id;
                        strBuilder.Clear();
                        #endregion

                        #region 新增明细数据
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            if (row["料件id"] == DBNull.Value) continue;
                            strBuilder.AppendLine("INSERT INTO [进口料件入库明细表]([料件入库表id] ,[料件id] ,[单价],[入库数量] ,[备注])");
                            strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4})",
                                料件入库表id, row["料件id"], row["单价"] == DBNull.Value ? "NULL" : row["单价"].ToString(),
                                row["入库数量"] == DBNull.Value ? "NULL" : row["入库数量"].ToString(),
                                row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()));
                            strBuilder.AppendLine("select @@IDENTITY");
                            object 料件入库明细表id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            row["料件入库明细表id"] = 料件入库明细表id;
                            //updateCost(row);
                            //if (bUpdateCost)
                            //{
                            //    SysMethod.updateCost(row, true);
                            //}
                        }
                        #endregion
                        giOrderID = Convert.ToInt32(料件入库表id);
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
                        #region //修改表头数据
                        if (rowHead.RowState == DataRowState.Modified)
                        {
                            strBuilder.AppendFormat(@"UPDATE [进口料件入库表]SET [入库单号] ={0} ,[入库时间] = '{1}',[摘要] = {2},[报关单号] = {3},[发票号] ={4}
                                                     ,[电子帐册号] = '{5}' ,[录入员] = {6},[过帐标志] = {7} ,[清单编号] ={8} ,[用途] = {9} ,[征免方式] = {10} 
                                                    ,[产销国] = {11} ,[币制] = {12},[申报地海关代码] ={13} ,[进口岸代码] = {14},[代理单位代码] ={15} where 料件入库表id={16}",
                            rowHead["入库单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["入库单号"].ToString()), rowHead["入库时间"],
                             rowHead["摘要"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["摘要"].ToString()),
                            rowHead["报关单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["报关单号"].ToString()),
                            rowHead["发票号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["发票号"].ToString()),
                            rowHead["电子帐册号"] == DBNull.Value ? "NULL" : rowHead["电子帐册号"],
                            rowHead["录入员"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["录入员"].ToString()),
                            (rowHead["过帐标志"] == DBNull.Value || Convert.ToBoolean(rowHead["过帐标志"]) == false) ? 0 : 1,
                            rowHead["清单编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["清单编号"].ToString()),
                            rowHead["用途"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["用途"].ToString()),
                            rowHead["征免方式"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["征免方式"].ToString()),
                            rowHead["产销国"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产销国"].ToString()),
                            rowHead["币制"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["币制"].ToString()),
                            rowHead["申报地海关代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["申报地海关代码"].ToString()),
                            rowHead["进口岸代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进口岸代码"].ToString()),
                            rowHead["代理单位代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["代理单位代码"].ToString()), rowHead["料件入库表id"]);
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
                                if (row["料件id"] == DBNull.Value) continue;
                                strBuilder.AppendLine("INSERT INTO [进口料件入库明细表]([料件入库表id] ,[料件id] ,[单价],[入库数量] ,[备注])");
                                strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4})",
                                    rowHead["料件入库表id"], row["料件id"], row["单价"] == DBNull.Value ? "NULL" : row["单价"].ToString(),
                                    row["入库数量"] == DBNull.Value ? "NULL" : row["入库数量"].ToString(),
                                    row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()));
                                strBuilder.AppendLine("select @@IDENTITY");
                                object 料件入库明细表id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                                strBuilder.Clear();
                                row["料件入库明细表id"] = 料件入库明细表id;
                                //updateCost(row);
                                //if (bUpdateCost) SysMethod.updateCost(row, true);
                            }
                            #endregion

                            #region 删除表身数据
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                if (row["料件入库明细表id", DataRowVersion.Original] == DBNull.Value) continue;
                                //updateCost(row);
                                //if (bUpdateCost)
                                //{
                                //    SysMethod.updateCost(row, false);
                                //}
                                strBuilder.AppendFormat(@"DELETE FROM [进口料件入库明细表] WHERE 料件入库明细表id={0}", row["料件入库明细表id", DataRowVersion.Original]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion

                            #region 修改表身数据
                            else //if (row.RowState == DataRowState.Modified)
                            {
                                if (row["料件入库明细表id"] == DBNull.Value) continue;
                                if (row["料件id"] == DBNull.Value)
                                {
                                    strBuilder.AppendFormat(@"DELETE FROM [进口料件入库明细表] WHERE 料件入库明细表id={0}", row["料件入库明细表id"]);
                                }
                                else
                                {
                                    //updateCost(row);
                                    strBuilder.AppendFormat(@"UPDATE [进口料件入库明细表] SET [料件入库表id] = {0},[料件id] = {1},[单价] = {2} ,[入库数量] = {3}
                                                    ,[备注] = {4} where 料件入库明细表id={5}",
                                            rowHead["料件入库表id"], row["料件id"], row["单价"] == DBNull.Value ? "NULL" : row["单价"].ToString(),
                                    row["入库数量"] == DBNull.Value ? "NULL" : row["入库数量"].ToString(),
                                    row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()), row["料件入库明细表id"]);
                                    //if (bUpdateCost) SysMethod.updateCost(row, true);
                                }
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
                if (Convert.ToBoolean(rowHead["过帐标志"]))
                {
                    foreach (DataRow row in dtDetails.Rows)
                        SysMethod.updateCost(row, true);
                }
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
        private void txt_入库单号1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !check入库单号();
        }
        private void txt_入库单号1_Validated(object sender, EventArgs e)
        {
            string str入库单号 = txt_入库单号1.Text.Trim() + txt_入库单号2.Text.Trim();
            if (rowHead["入库单号"].ToString() != str入库单号)
            {
                rowHead["入库单号"] = str入库单号;
            }
        }
        private void txt_入库单号2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !check入库单号();
        }
        private void txt_入库单号2_Validated(object sender, EventArgs e)
        {
            string str入库单号 = txt_入库单号1.Text.Trim() + txt_入库单号2.Text.Trim();
            if (rowHead["入库单号"].ToString() != str入库单号)
            {
                rowHead["入库单号"] = str入库单号;
            }
        }
        /// <summary>
        /// 检查入库单号的合法性
        /// </summary>
        /// <returns>返回检查结果</returns>
        private bool check入库单号()
        {
            bool bReturn = true;
            string str入库单号 = string.Format("{0}{1}", txt_入库单号1.Text.Trim(), txt_入库单号2.Text.Trim());
            bool isCheck = false;
            if (rowHead.RowState == DataRowState.Added)
            {
                isCheck = true;
            }
            else if (rowHead.RowState == DataRowState.Modified)
            {
                if (rowHead["入库单号", DataRowVersion.Original].ToString() != str入库单号)
                {
                    isCheck = true;
                }
            }
            if (isCheck)
            {
                string strSQL = string.Format("SELECT 料件入库表id FROM 进口料件入库表 WHERE 入库单号 ={0}", StringTools.SqlQ(str入库单号));
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                DataTable dtData = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtData.Rows.Count == 0)
                {
                    bReturn = true;
                }
                else
                {
                    SysMessage.InformationMsg("此出库单已存在！");
                    bReturn = false;
                }
            }
            return bReturn;
        }

        private void date_入库时间_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(rowHead["入库时间"]) != date_入库时间.Value)
            {
                rowHead["入库时间"] = date_入库时间.Value;
            }
        }

        private void txt_录入员_Validated(object sender, EventArgs e)
        {
            if (rowHead["录入员"].ToString() != txt_录入员.Text)
            {
                rowHead["录入员"] = txt_录入员.Text;
            }
        }

        private void cbox_电子帐册号_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_电子帐册号.SelectedValue!=null && bcbox_电子帐册号_SelectedIndexChanged && rowHead["电子帐册号"].ToString() != cbox_电子帐册号.SelectedValue.ToString())
                rowHead["电子帐册号"] = cbox_电子帐册号.SelectedValue;
        }

        private void txt_报关单号_Validating(object sender, CancelEventArgs e)
        {
            if (txt_报关单号.Text.Trim() == "") return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable rs = dataAccess.GetTable(string.Format("SELECT * FROM 料件入库表 WHERE 报关单号 ={0}", StringTools.SqlQ(txt_报关单号.Text.Trim())), null);
            dataAccess.Close();
            if (rs.Rows.Count > 0)
            {

            }
            else
            {
                SysMessage.InformationMsg("此报关单号不存在");
                txt_报关单号.Text = string.Empty;
                rowHead["报关单号"] = string.Empty;
            }
        }
        private void txt_报关单号_Validated(object sender, EventArgs e)
        {
            if (rowHead["报关单号"].ToString() != txt_报关单号.Text)
            {
                rowHead["报关单号"] = txt_报关单号.Text;
            }
        }

        private void txt_清单编号_Validating(object sender, CancelEventArgs e)
        {
            if (txt_清单编号.Text.Trim() == "") return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable rs = dataAccess.GetTable(string.Format("SELECT * FROM 料件入库表 WHERE 清单编号 ={0}", StringTools.SqlQ(txt_清单编号.Text.Trim())), null);
            dataAccess.Close();
            if (rs.Rows.Count > 0)
            {

            }
            else
            {
                SysMessage.InformationMsg("此清单编号不存在");
                txt_清单编号.Text = string.Empty;
                rowHead["清单编号"] = string.Empty;
            }
        }
        private void txt_清单编号_Validated(object sender, EventArgs e)
        {
            if (rowHead["清单编号"].ToString() != txt_清单编号.Text)
            {
                rowHead["清单编号"] = txt_清单编号.Text;
            }
        }

        private void txt_发票号_Validating(object sender, CancelEventArgs e)
        {
            if (txt_发票号.Text.Trim() == "") return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable rs = dataAccess.GetTable(string.Format("SELECT * FROM 料件入库表 WHERE 发票号 ={0}", StringTools.SqlQ(txt_发票号.Text.Trim())), null);
            dataAccess.Close();
            if (rs.Rows.Count > 0)
            {

            }
            else
            {
                SysMessage.InformationMsg("此发票号不存在");
                txt_发票号.Text = string.Empty;
                rowHead["发票号"] = string.Empty;
            }
        }
        private void txt_发票号_Validated(object sender, EventArgs e)
        {
            if (rowHead["发票号"].ToString() != txt_发票号.Text)
            {
                rowHead["发票号"] = txt_发票号.Text;
            }
        }

        private void txt_摘要_Validated(object sender, EventArgs e)
        {
            if (rowHead["摘要"].ToString() != txt_摘要.Text)
            {
                rowHead["摘要"] = txt_摘要.Text;
            }
        }

        private void txt_用途_Validated(object sender, EventArgs e)
        {
            if (rowHead["用途"].ToString() != txt_用途.Text)
            {
                rowHead["用途"] = txt_用途.Text;
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
        /// <summary>
        /// 填充表头数据到控件上
        /// </summary>
        /// <param name="row">来源数据</param>
        private void fillControl(DataRow row)
        {
            if (row.Table.Columns.Contains("入库单号"))
            {
                txt_入库单号1.Text = row["入库单号"].ToString().Substring(0, 1);
                txt_入库单号2.Text = row["入库单号"].ToString().Substring(1);
            }
            if (row.Table.Columns.Contains("报关单号"))
            {
                txt_报关单号.Text = row["报关单号"].ToString();
            }
            if (row.Table.Columns.Contains("入库时间"))
            {
                date_入库时间.Value = Convert.ToDateTime(row["入库时间"]);
            }
            if (row.Table.Columns.Contains("摘要"))
            {
                txt_摘要.Text = row["摘要"].ToString();
            }
            if (row.Table.Columns.Contains("电子帐册号"))
            {
                cbox_电子帐册号.SelectedValue = row["电子帐册号"];
            }
            if (row.Table.Columns.Contains("录入员"))
            {
                txt_录入员.Text = row["录入员"].ToString();
            }
            if (row.Table.Columns.Contains("发票号"))
            {
                txt_发票号.Text = row["发票号"].ToString();
            }
            if (row.Table.Columns.Contains("清单编号"))
            {
                txt_清单编号.Text = row["清单编号"].ToString();
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
        }
        /// <summary>
        /// 设置出库单号的字体颜色
        /// </summary>
        private void setForeColor()
        {
            if (rowHead["过帐标志"] == DBNull.Value || !Convert.ToBoolean(rowHead["过帐标志"]))
            {
                txt_入库单号1.ForeColor = Color.Black;
                txt_入库单号2.ForeColor = Color.Black;
            }
            else
            {
                txt_入库单号1.ForeColor = Color.Red;
                txt_入库单号2.ForeColor = Color.Red;
            }
        }
        #endregion

        #region 表身toolStrip事件

        public override void tool2_Import_Click(object sender, EventArgs e)
        {
            base.tool2_Import_Click(sender, e);
            if (cbox_电子帐册号.SelectedValue == null || cbox_电子帐册号.SelectedValue == DBNull.Value || cbox_电子帐册号.SelectedValue.ToString() == "")
            {
                SysMessage.InformationMsg("请输入电子帐册号");
                cbox_电子帐册号.Focus();
                return;
            }
            IDataAccess dataManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            DataTable rs = null;
            if (txt_清单编号.Text.Trim() == "")
            {
                if (txt_报关单号.Text.Trim() == "")
                {
                    rs = dataManufacture.GetTable(string.Format(@"SELECT R.报关单号,R.清单编号, R.发票号, SUM(RM.入库数量) AS 入库数量, L.料件型号, L.显示型号, 
                                                                        L.显示型号L as 新显示型号,L.电子帐册型号, RM.料件id, L.料件名, L.仓库数量2, L.换算数量, L.换算单位 
                                                                    FROM 料件资料表 L RIGHT OUTER JOIN 料件入库明细表 RM ON L.料件id = RM.料件id 
                                                                    RIGHT OUTER JOIN 料件入库表 R ON RM.料件入库表id = R.料件入库表id 
                                                            WHERE R.发票号 ={0} GROUP BY L.显示型号L,R.报关单号,R.清单编号,R.发票号, L.料件型号, L.显示型号, 
                                                                L.电子帐册型号, RM.料件id,L.料件名, L.仓库数量2, L.换算数量, L.换算单位 ",StringTools.SqlQ(txt_发票号.Text.Trim())), null);
                }
                else
                {
                    rs = dataManufacture.GetTable(string.Format(@"SELECT R.报关单号,R.清单编号, R.发票号, SUM(RM.入库数量) AS 入库数量, L.料件型号, L.显示型号, 
                                                                        L.显示型号L as 新显示型号,L.电子帐册型号, RM.料件id, L.料件名, L.仓库数量2, L.换算数量, L.换算单位 
                                                                    FROM 料件资料表 L RIGHT OUTER JOIN 料件入库明细表 RM ON L.料件id = RM.料件id 
                                                                    RIGHT OUTER JOIN 料件入库表 R ON RM.料件入库表id = R.料件入库表id 
                                                                    WHERE R.报关单号 ={0} GROUP BY L.显示型号L,R.报关单号,R.清单编号,R.发票号, L.料件型号, L.显示型号, 
                                                                    L.电子帐册型号, RM.料件id,L.料件名, L.仓库数量2, L.换算数量, L.换算单位 ",StringTools.SqlQ(txt_报关单号.Text.Trim())), null);
                }
            }
            else
            {
                rs = dataManufacture.GetTable(string.Format(@"SELECT R.报关单号,R.清单编号, R.发票号, SUM(RM.入库数量) AS 入库数量, L.料件型号, L.显示型号, 
                                                                    L.显示型号L as 新显示型号,L.电子帐册型号, RM.料件id, L.料件名, L.仓库数量2, L.换算数量, L.换算单位 
                                                                FROM 料件资料表 L RIGHT OUTER JOIN 料件入库明细表 RM ON L.料件id = RM.料件id 
                                                                RIGHT OUTER JOIN 料件入库表 R ON RM.料件入库表id = R.料件入库表id 
                                                                WHERE R.清单编号 ={0} GROUP BY L.显示型号L,R.报关单号,R.清单编号, R.发票号, L.料件型号, L.显示型号,
                                                                L.电子帐册型号, RM.料件id,L.料件名, L.仓库数量2, L.换算数量, L.换算单位 ",StringTools.SqlQ(txt_清单编号.Text.Trim())), null);
            }
            if (rs.Rows.Count > 0)
            {
                foreach (DataRow rsRow in rs.Rows)
                {
                    DataRow newRow = dtDetails.NewRow();
                    newRow["料件id"] = rsRow["料件id"];
                    if (cbox_电子帐册号.SelectedValue.ToString() == "B37167420012")
                    {
                        newRow["料号"] = rsRow["显示型号"];
                    }
                    else if (cbox_电子帐册号.SelectedValue.ToString() == "B37168420019")
                    {
                        newRow["料号"] = rsRow["新显示型号"];
                    }
                    else
                    {
                        newRow["料号"] = rsRow["电子帐册型号"];
                    }
                    newRow["料件编号"] = rsRow["料件型号"];
                    newRow["料件名"] = rsRow["料件名"];
                    if (rsRow["仓库数量2"] != DBNull.Value && Convert.ToDecimal(rsRow["仓库数量2"]) != 0)
                    {
                        newRow["入库数量"] = (Convert.ToDecimal(rsRow["入库数量"]) / Convert.ToDecimal(rsRow["仓库数量2"]) * Convert.ToDecimal(rsRow["换算数量"])).ToString("N2");
                    }
                    if (newRow["料号"] != DBNull.Value && newRow["料号"].ToString() != "")
                    {
                        dataManufacture.Open();
                        DataTable crs = dataManufacture.GetTable(string.Format(@"SELECT Q.产品编号,H.序号,H.商品编码, H.商品名称, Q.商品规格, H.计量单位,H.计量单位,
                                                            H.损耗率,H.单价 FROM 归并后料件清单 H LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id 
                                                            where Q.产品编号={0} AND H.电子帐册号='{1}'",
                                          StringTools.SqlQ(newRow["料号"].ToString().Substring(0,5)),cbox_电子帐册号.SelectedValue),null);
                        dataManufacture.Close();
                        if (crs.Rows.Count > 0)
                        {
                            newRow["商品编码"] = crs.Rows[0]["商品编码"];
                            newRow["商品名称"] = crs.Rows[0]["商品名称"];
                            newRow["商品规格"] = crs.Rows[0]["商品规格"];
                            newRow["单位"] = "KGS";
                            newRow["单价"] = crs.Rows[0]["单价"];
                        }
                    }
                    dtDetails.Rows.Add(newRow);
                }
            }
            setTool1Enabled();
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
                            dgv.CurrentCell = dgv["单价", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate料号(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["单价", cell.RowIndex];
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
                case "单价":   //跳转到"备注"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["单价"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["入库数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate单价(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["入库数量", cell.RowIndex];
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
                case "入库数量":   //跳转到"备注"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["入库数量"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate入库数量(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["入库数量"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate入库数量(dgv, cell);
                        }
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
            if (Importid) return false;
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
                if (cbox_电子帐册号.SelectedValue.ToString() == "B37167420012")
                {
                    dgv.Rows[cell.RowIndex].Cells["料号"].Value = dttabArticle.Rows[0]["显示型号"];
                }
                else if (cbox_电子帐册号.SelectedValue.ToString() == "B37168420019")
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
                dgv.Rows[cell.RowIndex].Cells["成本价"].Value = dttabArticle.Rows[0]["成本价"] == DBNull.Value ? 0 : Convert.ToDecimal(dttabArticle.Rows[0]["成本价"]);
            }
            else if (dttabArticle.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择客户型号";
                formSelect.dtData = dttabArticle;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (cbox_电子帐册号.SelectedValue.ToString() == "B37167420012")
                    {
                        dgv.Rows[cell.RowIndex].Cells["料号"].Value = dttabArticle.Rows[0]["显示型号"];
                    }
                    else if (cbox_电子帐册号.SelectedValue.ToString() == "B37168420019")
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
                    dgv.Rows[cell.RowIndex].Cells["成本价"].Value = dttabArticle.Rows[0]["成本价"] == DBNull.Value ? 0 : Convert.ToDecimal(dttabArticle.Rows[0]["成本价"]);
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            if (dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString() != "")
            {
                strSQL = string.Format(@"SELECT Q.产品编号,H.序号,H.商品编码, H.商品名称, Q.商品规格, H.计量单位,H.计量单位,H.损耗率,H.单价 
                                        FROM 归并后料件清单 H LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id 
                                        where Q.产品编号='{0}' AND H.电子帐册号='{1}'",
                                    dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString().Substring(0, 5), cbox_电子帐册号.SelectedValue);
                dataAccess.Open();
                dttabArticle = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dttabArticle.Rows.Count > 0)
                {
                    dgv.Rows[cell.RowIndex].Cells["商品编码"].Value = dttabArticle.Rows[0]["商品编码"];
                    dgv.Rows[cell.RowIndex].Cells["商品名称"].Value = dttabArticle.Rows[0]["商品名称"];
                    dgv.Rows[cell.RowIndex].Cells["商品规格"].Value = dttabArticle.Rows[0]["商品规格"];
                    dgv.Rows[cell.RowIndex].Cells["单位"].Value = "KGS";
                    dgv.Rows[cell.RowIndex].Cells["单价"].Value = dttabArticle.Rows[0]["单价"];
                }
            }
            return true;
        }
        private bool validate料号(myDataGridView dgv, DataGridViewCell cell)
        {
            if (Importid) return false;
            string strSQL = string.Empty;
            if (cbox_电子帐册号.SelectedValue.ToString() == "B37167420012")
            {
                strSQL = string.Format(@"帮助录入查询 {0}, 12, 0, 0, 0, '',''", StringTools.SqlQ(cell.EditedFormattedValue.ToString()));
            }
            else if (cbox_电子帐册号.SelectedValue.ToString() == "B37168420019")
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
                dgv.Rows[cell.RowIndex].Cells["成本价"].Value = dttabArticle.Rows[0]["成本价"] == DBNull.Value ? 0 : Convert.ToDecimal(dttabArticle.Rows[0]["成本价"]);
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
                    dgv.Rows[cell.RowIndex].Cells["成本价"].Value = dttabArticle.Rows[0]["成本价"] == DBNull.Value ? 0 : Convert.ToDecimal(dttabArticle.Rows[0]["成本价"]);
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            if (dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString() != "")
            {
                strSQL = string.Format(@"SELECT Q.产品编号,H.序号,H.商品编码, H.商品名称, Q.商品规格, H.计量单位,H.计量单位,H.损耗率,H.单价 
                                        FROM 归并后料件清单 H LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id 
                                        where Q.产品编号='{0}' AND H.电子帐册号='{1}'",
                                    dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString().Substring(0, 5), cbox_电子帐册号.SelectedValue);
                dataAccess.Open();
                dttabArticle = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dttabArticle.Rows.Count > 0)
                {
                    dgv.Rows[cell.RowIndex].Cells["商品编码"].Value = dttabArticle.Rows[0]["商品编码"];
                    dgv.Rows[cell.RowIndex].Cells["商品名称"].Value = dttabArticle.Rows[0]["商品名称"];
                    dgv.Rows[cell.RowIndex].Cells["商品规格"].Value = dttabArticle.Rows[0]["商品规格"];
                    dgv.Rows[cell.RowIndex].Cells["单位"].Value = "KGS";
                    dgv.Rows[cell.RowIndex].Cells["单价"].Value = dttabArticle.Rows[0]["单价"];
                }
            }
            return true;
        }
        private void validate单价(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["单价"].Value = 0;
                dgv.Rows[cell.RowIndex].Cells["总金额"].Value = 0;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["单价"].Value = cell.EditedFormattedValue;

                    if (dgv.Rows[cell.RowIndex].Cells["入库数量"].Value == DBNull.Value || Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["入库数量"].Value) == 0)
                    {
                        dgv.Rows[cell.RowIndex].Cells["总金额"].Value = 0;
                    }
                    else
                    {
                        dgv.Rows[cell.RowIndex].Cells["总金额"].Value = Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["单价"].Value) *
                            Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["入库数量"].Value);
                    }
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["单价"].Value = 0;
                    dgv.Rows[cell.RowIndex].Cells["总金额"].Value = 0;
                }
            }
        }
        private void validate入库数量(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["入库数量"].Value = 0;
                dgv.Rows[cell.RowIndex].Cells["总金额"].Value = 0;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["入库数量"].Value = cell.EditedFormattedValue;

                    if (dgv.Rows[cell.RowIndex].Cells["单价"].Value == DBNull.Value || Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["单价"].Value) == 0)
                    {
                        dgv.Rows[cell.RowIndex].Cells["总金额"].Value = 0;
                    }
                    else
                    {
                        dgv.Rows[cell.RowIndex].Cells["总金额"].Value = Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["单价"].Value) *
                            Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["入库数量"].Value);
                    }
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["入库数量"].Value = 0;
                    dgv.Rows[cell.RowIndex].Cells["总金额"].Value = 0;
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
            if (colName == "入库数量" || colName == "单价")
                e.Cancel = false;
        }

        /// <summary>
        /// 明细GRID增加一条新行
        /// </summary>
        public override void dtDetailsAddRow()
        {
            DataRow newRow = dtDetails.NewRow();
            newRow["入库数量"] = 1;
            newRow["单位"] = "KGS";
            dtDetails.Rows.Add(newRow);
            setTool1Enabled();
        }

        #endregion

        /// <summary>
        /// 更新料件成本
        /// </summary>
        /// <param name="row">料件行数据</param>
        private void updateCostT(DataRow row)
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            try
            {
                if (row.RowState == DataRowState.Added)  //新增入库
                {
                    int 料件id = Convert.ToInt32(row["料件id"]);
                    dataAccess.ExecuteNonQuery(string.Format("exec 进口料件初始化库存成本 {0}", 料件id));
                    object 成本价 = dataAccess.ExecScalar(string.Format("select 成本价 from 料件资料表 where 料件id={0}", 料件id));
                    if(成本价 == null || 成本价== DBNull.Value || Convert.ToDouble(成本价)==0)
                    {
                        dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价={0} where 料件id={1}",row["单价"], 料件id));
                    }
                    else
                    {
                        DataTable dt = dataAccess.GetTable(string.Format("select * from 单耗库存查询表 where 料件id={0}", 料件id));
                        if(dt.Rows.Count == 0 || Convert.ToDouble(dt.Rows[0]["入库数量"]) == 0)
                        {
                            dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价={0} where 料件id={1}", row["单价"], 料件id));
                        }
                        else
                        {
                            decimal 数量 = Convert.ToDecimal(dt.Rows[0]["入库数量"]);
                            成本价 = (Convert.ToDecimal(成本价) * 数量 + Convert.ToDecimal(row["总金额"])) / (数量 + Convert.ToDecimal( row["入库数量"]));
                            dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价={0} where 料件id={1}", row["单价"], 料件id));
                        }
                    }
                }
                else if (row.RowState == DataRowState.Deleted)  //删除入库
                {
                    //1、撤消修改前的库存金额和数量，算出成本
                    int 旧料件id = Convert.ToInt32(row["料件id", DataRowVersion.Original]);
                    DataTable dt旧料件库存 = dataAccess.GetTable(string.Format("select * from 单耗库存查询表 where 料件id={0}", 旧料件id));
                    decimal 旧料件库存数量 = Convert.ToDecimal(dt旧料件库存.Rows[0]["数量"]);
                    if (旧料件库存数量 == Convert.ToDecimal(row["入库数量", DataRowVersion.Original]))
                    {
                        dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价=0 where 料件id={0}", 旧料件id));
                    }
                    else
                    {
                        decimal 旧料件成本 = Convert.ToDecimal(dataAccess.ExecScalar(string.Format("select 成本价 from 料件资料表 where 料件id={0}", 旧料件id)));
                        decimal 旧料件总金额 = 旧料件库存数量 * 旧料件成本;
                        decimal 旧料件成本更新 = (旧料件总金额 - Convert.ToDecimal(row["总金额", DataRowVersion.Original])) / (旧料件库存数量 - Convert.ToDecimal(row["入库数量", DataRowVersion.Original]));
                        dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价={0} where 料件id={1}", 旧料件成本更新, 旧料件id));
                    }
                }
                else //if (row.RowState == DataRowState.Modified)  //修改入库
                {
                    //1、撤消修改前的库存金额和数量，算出成本
                    int 旧料件id = Convert.ToInt32(row["料件id",DataRowVersion.Original]);
                    DataTable dt旧料件库存 = dataAccess.GetTable(string.Format("select * from 单耗库存查询表 where 料件id={0}", 旧料件id));
                    decimal 旧料件库存数量 = Convert.ToDecimal(dt旧料件库存.Rows[0]["数量"]);
                    if (旧料件库存数量 == Convert.ToDecimal(row["入库数量", DataRowVersion.Original]))
                    {
                        dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价=0 where 料件id={0}", 旧料件id));
                    }
                    else
                    {
                        decimal 旧料件成本 = Convert.ToDecimal(dataAccess.ExecScalar(string.Format("select 成本价 from 料件资料表 where 料件id={0}", 旧料件id)));
                        decimal 旧料件总金额 = 旧料件库存数量 * 旧料件成本;
                        decimal 旧料件成本更新 = (旧料件总金额 - Convert.ToDecimal(row["总金额", DataRowVersion.Original])) / (旧料件库存数量 - Convert.ToDecimal(row["入库数量", DataRowVersion.Original]));
                        dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价={0} where 料件id={1}",旧料件成本更新, 旧料件id));
                    }
                    //2、不管料件ID是否有变，根据现有的料件ID，数量，总金额重算一次成本价
                    int 新料件id = Convert.ToInt32(row["料件id"]);
                    dataAccess.ExecuteNonQuery(string.Format("exec 进口料件初始化库存成本 {0}", 新料件id));
                    object 成本价 = dataAccess.ExecScalar(string.Format("select 成本价 from 料件资料表 where 料件id={0}", 新料件id));
                    if (成本价 == null || 成本价 == DBNull.Value || Convert.ToDouble(成本价) == 0)
                    {
                        dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价={0} where 料件id={1}", row["单价"], 新料件id));
                    }
                    else
                    {
                        DataTable dt = dataAccess.GetTable(string.Format("select * from 单耗库存查询表 where 料件id={0}", 新料件id));
                        if (dt.Rows.Count == 0 || Convert.ToDouble(dt.Rows[0]["数量"]) == 0)
                        {
                            dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价={0} where 料件id={1}", row["单价"], 新料件id));
                        }
                        else
                        {
                            decimal 数量 = Convert.ToDecimal(dt.Rows[0]["数量"]);
                            成本价 = (Convert.ToDecimal(成本价) * 数量 + Convert.ToDecimal(row["总金额"])) / (数量 + Convert.ToDecimal(row["入库数量"]));
                            dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价={0} where 料件id={1}", row["单价"], 新料件id));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("更新料件【{0}】库存成本出错：{1}",row["料件id"],ex.Message),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
