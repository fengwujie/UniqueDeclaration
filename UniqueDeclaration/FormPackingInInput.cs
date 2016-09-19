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
    public partial class FormPackingInInput : UniqueDeclarationBaseForm.FormBaseInput
    {
        public FormPackingInInput()
        {
            InitializeComponent();
        }

        private long Pid;

        /// 是否触发值变化事件
        /// </summary>
        private bool bcbox_custid_SelectedIndexChanged = true;
        public override void FormBaseInput_Load(object sender, System.EventArgs e)
        {
            //base.FormBaseInput_Load(sender, e);
            InitControlData();
            LoadDataSource();
            InitGrid();
        }

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
            this.dataGridViewDetail.Columns["id"].Visible = false;
            this.dataGridViewDetail.Columns["id"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["进口料件id"].Visible = false;
            this.dataGridViewDetail.Columns["进口料件id"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["unit1"].Visible = false;
            this.dataGridViewDetail.Columns["unit1"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["unit2"].Visible = false;
            this.dataGridViewDetail.Columns["unit2"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["Packageno"].DisplayIndex = 0;
            this.dataGridViewDetail.Columns["Packageno"].HeaderText = "Packing No(箱号)";
            this.dataGridViewDetail.Columns["Packageno"].Width = 130;
            this.dataGridViewDetail.Columns["Packageno"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["手册编号"].DisplayIndex = 1;
            this.dataGridViewDetail.Columns["手册编号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["序号"].DisplayIndex = 2;
            this.dataGridViewDetail.Columns["序号"].Width = 55;
            this.dataGridViewDetail.Columns["序号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["品名规格型号"].DisplayIndex = 3;
            this.dataGridViewDetail.Columns["品名规格型号"].Width = 150;
            this.dataGridViewDetail.Columns["品名规格型号"].ReadOnly = true;
            this.dataGridViewDetail.Columns["品名规格型号"].HeaderText = "Deacription of Goods";
            this.dataGridViewDetail.Columns["品名规格型号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["剩余量"].DisplayIndex = 4;
            this.dataGridViewDetail.Columns["剩余量"].Width = 70;
            this.dataGridViewDetail.Columns["剩余量"].ReadOnly = true;
            this.dataGridViewDetail.Columns["剩余量"].ContextMenuStrip = myContextDetails;
            this.dataGridViewDetail.Columns["BoxNum"].DisplayIndex = 5;
            this.dataGridViewDetail.Columns["BoxNum"].Width = 55;
            this.dataGridViewDetail.Columns["BoxNum"].HeaderText = "箱数";
            this.dataGridViewDetail.Columns["BoxNum"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["Quantity"].DisplayIndex = 6;
            this.dataGridViewDetail.Columns["Quantity"].HeaderText = "Quantity/箱";
            this.dataGridViewDetail.Columns["Quantity"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewDetail.Columns["Quantity"].DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDetail.Columns["Unit"].DisplayIndex = 7;
            this.dataGridViewDetail.Columns["Unit"].Width = 60;
            this.dataGridViewDetail.Columns["Unit"].HeaderText = "单位";
            this.dataGridViewDetail.Columns["Unit"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["UnitPrice"].DisplayIndex = 8;
            this.dataGridViewDetail.Columns["UnitPrice"].Width = 60;
            this.dataGridViewDetail.Columns["UnitPrice"].HeaderText = "单价";
            this.dataGridViewDetail.Columns["UnitPrice"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["TotalNum"].DisplayIndex = 9;
            this.dataGridViewDetail.Columns["TotalNum"].Width = 70;
            this.dataGridViewDetail.Columns["TotalNum"].ReadOnly = true;
            this.dataGridViewDetail.Columns["TotalNum"].HeaderText = "总数量";
            this.dataGridViewDetail.Columns["TotalNum"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["TotalPrice"].DisplayIndex = 10;
            this.dataGridViewDetail.Columns["TotalPrice"].Width = 80;
            this.dataGridViewDetail.Columns["TotalPrice"].ReadOnly = true;
            this.dataGridViewDetail.Columns["TotalPrice"].HeaderText = "总金额";
            this.dataGridViewDetail.Columns["TotalPrice"].ContextMenuStrip = this.myContextDetails;
            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dataGridViewCellStyle1.Format = "N5";
            //dataGridViewCellStyle1.NullValue = null;
            //this.dataGridViewDetail.Columns["数量"].DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDetail.Columns["nw"].DisplayIndex = 11;
            this.dataGridViewDetail.Columns["nw"].Width = 100;
            this.dataGridViewDetail.Columns["nw"].HeaderText = "Net Weight";
            this.dataGridViewDetail.Columns["nw"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["nw"].DefaultCellStyle = dataGridViewCellStyle1;

            this.dataGridViewDetail.Columns["gw"].DisplayIndex = 12;
            this.dataGridViewDetail.Columns["gw"].Width = 110;
            this.dataGridViewDetail.Columns["gw"].HeaderText = "Gross Weight";
            this.dataGridViewDetail.Columns["gw"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["gw"].DefaultCellStyle = dataGridViewCellStyle1;
        }
        public override void InitControlData()
        {
            base.InitControlData();
            this.gstrDetailFirstField = "PackageNo";
            bcbox_custid_SelectedIndexChanged = false;
            this.cbox_custid.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade,
                "SELECT custid, com_Abbr FROM dbo.Customer", "custid", "com_Abbr",-1);
            bcbox_custid_SelectedIndexChanged = true;
        }
        /// <summary>
        /// 加载表头数据
        /// </summary>
        public override void LoadDataSourceHead()
        {
            string strSQL = string.Format("SELECT * FROM Packing WHERE pid ={0}", giOrderID);
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
                rowHead["importdate"] = DateTime.Now.Date;
                rowHead["inputdate"] = DateTime.Now.Date;
                rowHead["inputuser"] = SystemGlobal.SystemGlobal_UserInfo.UserName;
                rowHead["PriceTerm"] = "FOB XIAMEN CHINA";
                fillControl(rowHead);
            }
        }
        /// <summary>
        /// 加载表身数据
        /// </summary>
        public override void LoadDataSourceDetails()
        {
            string strSQL = string.Format("exec 进口装箱单录入查询 {0}", giOrderID);
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
            setDate();
            if (rowHead.RowState == DataRowState.Modified)
            {
                bModify = true;
            }
            else if (rowHead.RowState == DataRowState.Added)
            {
                if (rowHead["InvoiceNo"].ToString().Length > 0)
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
                            if (row["进口料件id"] != DBNull.Value && Convert.ToInt32(row["进口料件id"]) > 0)
                            {
                                bModify = true;
                                break;
                            }
                        }
                        else if (row.RowState == DataRowState.Deleted)
                        {
                            if (row["id", DataRowVersion.Original] != DBNull.Value)
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
                if (txt_InvoiceNO.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("InvoiceNO不能为空！");
                    txt_InvoiceNO.Focus();
                    return false;
                }
                #endregion

                setDate();
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
                        strBuilder.AppendLine(@"INSERT INTO [Packing]([custid] ,[InvoiceNo] ,[ImportDate] ,[comid] ,[per] ,[sailingabout] ,[PackingFrom],[PackingTo]
                                     ,[TranshipmentAt] ,[InputDate] ,[InputUser] ,[Remark] ,[Priceterm] ,[Mark1] ,[Mark2],[Mark3] ,[Mark4] ,[Mark5] ,[Mark6],[Mark7] ,[报关单号])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20})",
                            rowHead["custid"] == DBNull.Value ? "NULL" : rowHead["custid"],
                            rowHead["InvoiceNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InvoiceNo"].ToString()),
                            rowHead["ImportDate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["ImportDate"].ToString()),
                            rowHead["comid"] == DBNull.Value ? "NULL" : rowHead["comid"],
                            rowHead["per"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["per"].ToString()),
                            rowHead["sailingabout"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["sailingabout"].ToString()),
                            rowHead["PackingFrom"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["PackingFrom"].ToString()),
                            rowHead["PackingTo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["PackingTo"].ToString()),
                            rowHead["TranshipmentAt"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["TranshipmentAt"].ToString()),
                            rowHead["InputDate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InputDate"].ToString()),
                            rowHead["InputUser"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InputUser"].ToString()),
                            rowHead["Remark"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Remark"].ToString()),
                            rowHead["Priceterm"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Priceterm"].ToString()),
                            rowHead["Mark1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark1"].ToString()),
                            rowHead["Mark2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark2"].ToString()),
                            rowHead["Mark3"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark3"].ToString()),
                            rowHead["Mark4"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark4"].ToString()),
                            rowHead["Mark5"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark5"].ToString()),
                            rowHead["Mark6"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark6"].ToString()),
                            rowHead["Mark7"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark7"].ToString()),
                            rowHead["报关单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["报关单号"].ToString()));
                        strBuilder.AppendLine("select @@IDENTITY--自动生成的订单ID");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object Pid = dtInsert.Rows[0][0];
                        rowHead["Pid"] = Pid;
                        strBuilder.Clear();
                        #endregion

                        #region 新增明细数据
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            if (row["进口料件id"] == DBNull.Value || Convert.ToInt32(row["进口料件id"]) == 0) continue;
                            strBuilder.AppendLine(@"INSERT INTO [PackingDetail] ([Pid] ,[进口料件id],[PackageNo],[BoxNum],[Quantity],[Unit],[UnitPrice],[NW],[Unit1],[GW],[Unit2])");
                            strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})",
                                Pid, row["进口料件id"] == DBNull.Value ? "NULL" : row["进口料件id"],
                            row["PackageNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["PackageNo"].ToString()),
                            row["BoxNum"] == DBNull.Value ? "NULL" : row["BoxNum"],
                            row["Quantity"] == DBNull.Value ? "NULL" : row["Quantity"],
                            row["Unit"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit"].ToString()),
                            row["UnitPrice"] == DBNull.Value ? "NULL" : row["UnitPrice"],
                            row["NW"] == DBNull.Value ? "NULL" : row["NW"],
                            row["Unit1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit1"].ToString()),
                            row["GW"] == DBNull.Value ? "NULL" : row["GW"],
                            row["Unit2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit2"].ToString()));
                            strBuilder.AppendLine("select @@IDENTITY");
                            object id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            row["id"] = id;
                        }
                        #endregion
                        giOrderID = Convert.ToInt32(Pid);
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
                            strBuilder.AppendFormat(@"UPDATE [Packing] SET [custid] = {0},[InvoiceNo] = {1},[ImportDate] ={2},[comid] = {3},[per] = {4},[sailingabout] ={5},[PackingFrom] = {6}
                                                        ,[PackingTo] = {7},[TranshipmentAt] ={8},[InputDate] = {9},[InputUser] = {10},[Remark] ={11},[Priceterm] = {12},[Mark1] = {13},[Mark2] = {14},
                                                        [Mark3] = {15},[Mark4] ={16},[Mark5] = {17},[Mark6] = {18},[Mark7] = {19},[报关单号] = {20} where Pid={21}",
                            rowHead["custid"] == DBNull.Value ? "NULL" : rowHead["custid"],
                            rowHead["InvoiceNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InvoiceNo"].ToString()),
                            rowHead["ImportDate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["ImportDate"].ToString()),
                            rowHead["comid"] == DBNull.Value ? "NULL" : rowHead["comid"],
                            rowHead["per"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["per"].ToString()),
                            rowHead["sailingabout"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["sailingabout"].ToString()),
                            rowHead["PackingFrom"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["PackingFrom"].ToString()),
                            rowHead["PackingTo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["PackingTo"].ToString()),
                            rowHead["TranshipmentAt"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["TranshipmentAt"].ToString()),
                            rowHead["InputDate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InputDate"].ToString()),
                            rowHead["InputUser"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InputUser"].ToString()),
                            rowHead["Remark"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Remark"].ToString()),
                            rowHead["Priceterm"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Priceterm"].ToString()),
                            rowHead["Mark1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark1"].ToString()),
                            rowHead["Mark2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark2"].ToString()),
                            rowHead["Mark3"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark3"].ToString()),
                            rowHead["Mark4"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark4"].ToString()),
                            rowHead["Mark5"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark5"].ToString()),
                            rowHead["Mark6"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark6"].ToString()),
                            rowHead["Mark7"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark7"].ToString()),
                            rowHead["报关单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["报关单号"].ToString()),
                            rowHead["Pid"] == DBNull.Value ? "NULL" : rowHead["Pid"]);
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
                                if (row["进口料件id"] == DBNull.Value || Convert.ToInt32(row["进口料件id"]) == 0) continue;
                                strBuilder.AppendLine(@"INSERT INTO [PackingDetail] ([Pid] ,[进口料件id],[PackageNo],[BoxNum],[Quantity],[Unit],[UnitPrice],[NW],[Unit1],[GW],[Unit2])");
                                strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})",
                                   rowHead["Pid"], row["进口料件id"] == DBNull.Value ? "NULL" : row["进口料件id"],
                                row["PackageNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["PackageNo"].ToString()),
                                row["BoxNum"] == DBNull.Value ? "NULL" : row["BoxNum"],
                                row["Quantity"] == DBNull.Value ? "NULL" : row["Quantity"],
                                row["Unit"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit"].ToString()),
                                row["UnitPrice"] == DBNull.Value ? "NULL" : row["UnitPrice"],
                                row["NW"] == DBNull.Value ? "NULL" : row["NW"],
                                row["Unit1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit1"].ToString()),
                                row["GW"] == DBNull.Value ? "NULL" : row["GW"],
                                row["Unit2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit2"].ToString()));
                                strBuilder.AppendLine("select @@IDENTITY");
                                object id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                                strBuilder.Clear();
                                row["id"] = id;
                            }
                            #endregion

                            #region 删除表身数据
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                if (row["id", DataRowVersion.Original] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"DELETE FROM [PackingDetail] WHERE id={0}", row["id", DataRowVersion.Original]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion

                            #region 修改表身数据
                            else //if (row.RowState == DataRowState.Modified)
                            {
                                if (row["id"] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"UPDATE [PackingDetail]SET [Pid] ={0},[进口料件id] ={1},[PackageNo] = {2},[BoxNum] = {3},[Quantity] ={4},[Unit] ={5}
                                                                ,[UnitPrice] ={6},[NW] = {7},[Unit1] ={8},[GW] = {9},[Unit2] ={10} WHERE id={11}",
                                        rowHead["Pid"], row["进口料件id"] == DBNull.Value ? "NULL" : row["进口料件id"],
                                row["PackageNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["PackageNo"].ToString()),
                                row["BoxNum"] == DBNull.Value ? "NULL" : row["BoxNum"],
                                row["Quantity"] == DBNull.Value ? "NULL" : row["Quantity"],
                                row["Unit"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit"].ToString()),
                                row["UnitPrice"] == DBNull.Value ? "NULL" : row["UnitPrice"],
                                row["NW"] == DBNull.Value ? "NULL" : row["NW"],
                                row["Unit1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit1"].ToString()),
                                row["GW"] == DBNull.Value ? "NULL" : row["GW"],
                                row["Unit2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit2"].ToString()),row["id"]);
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
        /// <summary>
        /// 设置时间值
        /// </summary>
        private void setDate()
        {
            if (date_ImportDate.Checked)
            {
                if (rowHead["ImportDate"] == DBNull.Value || Convert.ToDateTime(rowHead["ImportDate"]) != date_ImportDate.Value)
                    rowHead["ImportDate"] = date_ImportDate.Value;
            }
            else
            {
                if (rowHead["ImportDate"] != DBNull.Value)
                    rowHead["ImportDate"] = DBNull.Value;
            }
            if (date_InputDate.Checked)
            {
                if (rowHead["InputDate"] == DBNull.Value || Convert.ToDateTime(rowHead["InputDate"]) != date_InputDate.Value)
                    rowHead["InputDate"] = date_InputDate.Value;
            }
            else
            {
                if (rowHead["InputDate"] != DBNull.Value)
                    rowHead["InputDate"] = DBNull.Value;
            }
        }

        /// <summary>
        /// 填充表头数据到控件上
        /// </summary>
        /// <param name="row">来源数据</param>
        private void fillControl(DataRow row)
        {
            if (row.Table.Columns.Contains("InvoiceNo"))
            {
                txt_InvoiceNO.Text = row["InvoiceNo"].ToString();
            }
            if (row.Table.Columns.Contains("per"))
            {
                txt_per.Text = row["per"].ToString();
            }
            if (row.Table.Columns.Contains("sailingabout"))
            {
                txt_sailingabout.Text = row["sailingabout"].ToString();
            }
            if (row.Table.Columns.Contains("PackingFrom"))
            {
                txt_PackingFrom.Text = row["PackingFrom"].ToString();
            }
            if (row.Table.Columns.Contains("ImportDate"))
            {
                if (row["ImportDate"] == DBNull.Value)
                {
                    date_ImportDate.Checked = false;
                }
                else
                {
                    date_ImportDate.Checked = true;
                    date_ImportDate.Value = Convert.ToDateTime(row["ImportDate"]);
                }
            }
            if (row.Table.Columns.Contains("InputDate"))
            {
                if (row["InputDate"] == DBNull.Value)
                {
                    date_InputDate.Checked = false;
                }
                else
                {
                    date_InputDate.Checked = true;
                    date_InputDate.Value = Convert.ToDateTime(row["InputDate"]);
                }
            } 
            if (row.Table.Columns.Contains("custid"))
            {
                cbox_custid.SelectedValue = row["custid"];
            }
            if (row.Table.Columns.Contains("PackingTo"))
            {
                txt_PackingTo.Text = row["PackingTo"].ToString();
            }
            if (row.Table.Columns.Contains("TranshipmentAt"))
            {
                txt_TranshipmentAt.Text = row["TranshipmentAt"].ToString();
            }
            if (row.Table.Columns.Contains("InputUser"))
            {
                txt_inputuser.Text = row["InputUser"].ToString();
            }
            if (row.Table.Columns.Contains("Remark"))
            {
                txt_Remark.Text = row["Remark"].ToString();
            }
            if (row.Table.Columns.Contains("Priceterm"))
            {
                txt_PriceTerm.Text = row["Priceterm"].ToString();
            }
            if (row.Table.Columns.Contains("Mark1"))
            {
                txt_Mark1.Text = row["Mark1"].ToString();
            }
            if (row.Table.Columns.Contains("Mark2"))
            {
                txt_Mark2.Text = row["Mark2"].ToString();
            }
            if (row.Table.Columns.Contains("Mark3"))
            {
                txt_Mark3.Text = row["Mark3"].ToString();
            }
            if (row.Table.Columns.Contains("Mark4"))
            {
                txt_Mark4.Text = row["Mark4"].ToString();
            }
            if (row.Table.Columns.Contains("Mark5"))
            {
                txt_Mark5.Text = row["Mark5"].ToString();
            }
            if (row.Table.Columns.Contains("Mark6"))
            {
                txt_Mark6.Text = row["Mark6"].ToString();
            }
            if (row.Table.Columns.Contains("Mark7"))
            {
                txt_Mark7.Text = row["Mark7"].ToString();
            }
            if (row.Table.Columns.Contains("报关单号"))
            {
                txt_报关单号.Text = row["报关单号"].ToString();
            }
            if (rowHead["comid"] != DBNull.Value)
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                DataTable dtCompany = dataAccess.GetTable("select e_name from company where comid=" + rowHead["comid"], null);
                dataAccess.Close();
                if (dtCompany.Rows.Count > 0)
                {
                    myTextBox3.Text = dtCompany.Rows[0]["e_name"].ToString();
                }
            }
        }
        #endregion

        #region 表头控件事件
        private void cbox_custid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bcbox_custid_SelectedIndexChanged) return;
            if (rowHead["custid"].ToString() != cbox_custid.SelectedValue.ToString())
            {
                rowHead["custid"] = cbox_custid.SelectedValue;
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                DataTable dtCustomer = dataAccess.GetTable("SELECT * FROM Customer WHERE custid = " + cbox_custid.SelectedValue, null);
                dataAccess.Close();
                if (dtCustomer.Rows.Count > 0 && txt_Mark1.Text.Trim().Length == 0)
                {
                    txt_Mark1.Text = dtCustomer.Rows[0]["mark1"].ToString();
                    txt_Mark2.Text = dtCustomer.Rows[0]["mark2"].ToString();
                    txt_Mark3.Text = dtCustomer.Rows[0]["mark3"].ToString();
                    txt_Mark4.Text = dtCustomer.Rows[0]["mark4"].ToString();
                    txt_Mark5.Text = dtCustomer.Rows[0]["mark5"].ToString();
                    txt_Mark6.Text = dtCustomer.Rows[0]["mark6"].ToString();
                    txt_Mark7.Text = dtCustomer.Rows[0]["mark7"].ToString();
                    txt_PackingFrom.Text = dtCustomer.Rows[0]["country"].ToString();
                    rowHead["mark1"] = dtCustomer.Rows[0]["mark1"];
                    rowHead["mark2"] = dtCustomer.Rows[0]["mark2"];
                    rowHead["mark3"] = dtCustomer.Rows[0]["mark3"];
                    rowHead["mark4"] = dtCustomer.Rows[0]["mark4"];
                    rowHead["mark5"] = dtCustomer.Rows[0]["mark5"];
                    rowHead["mark6"] = dtCustomer.Rows[0]["mark6"];
                    rowHead["mark7"] = dtCustomer.Rows[0]["mark7"];
                    rowHead["PackingFrom"] = dtCustomer.Rows[0]["country"];
                }
            }
        }

        private void txt_InvoiceNO_Validating(object sender, CancelEventArgs e)
        {
            if (rowHead.RowState == DataRowState.Added)
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                DataTable dtPacking = dataAccess.GetTable(string.Format("SELECT pid FROM Packing WHERE InvoiceNo ={0}",StringTools.SqlQ(txt_InvoiceNO.Text.Trim())), null);
                dataAccess.Close();
                if (dtPacking.Rows.Count == 0)
                {
                    rowHead["InvoiceNo"] = txt_InvoiceNO.Text.Trim();
                }
                else
                {
                    SysMessage.InformationMsg("此InvoiceNo已存在！");
                    e.Cancel = true;
                    txt_InvoiceNO.Focus();
                }
            }
        }

        private void txt_InvoiceNO_Validated(object sender, EventArgs e)
        {
            if (rowHead["InvoiceNO"].ToString() != txt_InvoiceNO.Text)
            {
                rowHead["InvoiceNO"] = txt_InvoiceNO.Text;
            }
        }

        private void txt_报关单号_Validated(object sender, EventArgs e)
        {
            if (rowHead["报关单号"].ToString() != txt_报关单号.Text)
            {
                rowHead["报关单号"] = txt_报关单号.Text;
            }
        }

        private void date_ImportDate_ValueChanged(object sender, EventArgs e)
        {
            if (date_ImportDate.Checked)
            {
                if (rowHead["ImportDate"] == DBNull.Value || Convert.ToDateTime(rowHead["ImportDate"]) != date_ImportDate.Value)
                    rowHead["ImportDate"] = date_ImportDate.Value;
            }
            else
            {
                if (rowHead["ImportDate"] != DBNull.Value)
                    rowHead["ImportDate"] = DBNull.Value;
            }
        }

        private void date_InputDate_ValueChanged(object sender, EventArgs e)
        {
            if (date_InputDate.Checked)
            {
                if (rowHead["InputDate"] == DBNull.Value || Convert.ToDateTime(rowHead["InputDate"]) != date_InputDate.Value)
                    rowHead["InputDate"] = date_InputDate.Value;
            }
            else
            {
                if (rowHead["InputDate"] != DBNull.Value)
                    rowHead["InputDate"] = DBNull.Value;
            }
        }

        private void myTextBox3_Validated(object sender, EventArgs e)
        {

        }

        private void txt_per_Validated(object sender, EventArgs e)
        {
            if (rowHead["per"].ToString() != txt_per.Text)
            {
                rowHead["per"] = txt_per.Text;
            }
        }

        private void txt_sailingabout_Validated(object sender, EventArgs e)
        {
            if (rowHead["sailingabout"].ToString() != txt_sailingabout.Text)
            {
                rowHead["sailingabout"] = txt_sailingabout.Text;
            }
        }

        private void txt_PackingFrom_Validated(object sender, EventArgs e)
        {
            if (rowHead["PackingFrom"].ToString() != txt_PackingFrom.Text)
            {
                rowHead["PackingFrom"] = txt_PackingFrom.Text;
            }
        }

        private void txt_PackingTo_Validated(object sender, EventArgs e)
        {
            if (rowHead["PackingTo"].ToString() != txt_PackingTo.Text)
            {
                rowHead["PackingTo"] = txt_PackingTo.Text;
            }
        }

        private void txt_TranshipmentAt_Validated(object sender, EventArgs e)
        {
            if (rowHead["TranshipmentAt"].ToString() != txt_TranshipmentAt.Text)
            {
                rowHead["TranshipmentAt"] = txt_TranshipmentAt.Text;
            }
        }

        private void txt_Mark1_Validated(object sender, EventArgs e)
        {
            if (rowHead["Mark1"].ToString() != txt_Mark1.Text)
            {
                rowHead["Mark1"] = txt_Mark1.Text;
            }
        }

        private void txt_Mark2_Validated(object sender, EventArgs e)
        {
            if (rowHead["Mark2"].ToString() != txt_Mark2.Text)
            {
                rowHead["Mark2"] = txt_Mark2.Text;
            }
        }

        private void txt_Mark3_Validated(object sender, EventArgs e)
        {
            if (rowHead["Mark3"].ToString() != txt_Mark3.Text)
            {
                rowHead["Mark3"] = txt_Mark3.Text;
            }
        }

        private void txt_Mark4_Validated(object sender, EventArgs e)
        {
            if (rowHead["Mark4"].ToString() != txt_Mark4.Text)
            {
                rowHead["Mark4"] = txt_Mark4.Text;
            }
        }

        private void txt_Mark5_Validated(object sender, EventArgs e)
        {
            if (rowHead["Mark5"].ToString() != txt_Mark5.Text)
            {
                rowHead["Mark5"] = txt_Mark5.Text;
            }
        }

        private void txt_Mark6_Validated(object sender, EventArgs e)
        {
            if (rowHead["Mark6"].ToString() != txt_Mark6.Text)
            {
                rowHead["Mark6"] = txt_Mark6.Text;
            }
        }

        private void txt_Mark7_Validated(object sender, EventArgs e)
        {
            if (rowHead["Mark7"].ToString() != txt_Mark7.Text)
            {
                rowHead["Mark7"] = txt_Mark7.Text;
            }
        }

        private void txt_inputuser_Validated(object sender, EventArgs e)
        {
            if (rowHead["inputuser"].ToString() != txt_inputuser.Text)
            {
                rowHead["inputuser"] = txt_inputuser.Text;
            }
        }

        private void txt_Remark_Validated(object sender, EventArgs e)
        {
            if (rowHead["Remark"].ToString() != txt_Remark.Text)
            {
                rowHead["Remark"] = txt_Remark.Text;
            }
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
                case "PackageNo":   //跳转到"手册编号"
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
                        if (dgv.CurrentRow.Cells["手册编号"].Value!=DBNull.Value && dgv.CurrentRow.Cells["手册编号"].Value.ToString()!="" && dgv.CurrentRow.Cells["手册编号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["序号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate手册编号(dgv, cell))
                        {
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["序号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        //if (dgv.CurrentRow.Cells["手册编号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        //{
                            validate手册编号(dgv, cell);
                        //}
                    }
                    #endregion
                    break;
                case "序号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        //if (dgv.CurrentRow.Cells["序号"].Value != DBNull.Value && dgv.CurrentRow.Cells["序号"].Value.ToString() != "" && dgv.CurrentRow.Cells["序号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        //{
                        //    bCellEndEdit = false;
                        //    dgv.CurrentCell = dgv["BoxNum", cell.RowIndex];
                        //    bCellEndEdit = true;
                        //}
                        //else 
                        if (validate序号(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["BoxNum", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        //if (dgv.CurrentRow.Cells["序号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        //{
                            validate序号(dgv, cell);
                        //}
                    }
                    #endregion
                    break;
                case "BoxNum":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["BoxNum"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["Quantity", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validateBoxNum(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["Quantity", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        //if (dgv.CurrentRow.Cells["BoxNum"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        //{
                            validateBoxNum(dgv, cell);
                        //}
                    }
                    #endregion
                    break;
                case "Quantity":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["Quantity"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["Unit", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validateQuantity(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["Unit", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        //if (dgv.CurrentRow.Cells["Quantity"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        //{
                            validateQuantity(dgv, cell);
                        //}
                    }
                    #endregion
                    break;
                case "Unit":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["UnitPrice", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "UnitPrice":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["UnitPrice"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["NW", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validateUnitPrice(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["NW", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        //if (dgv.CurrentRow.Cells["UnitPrice"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        //{
                            validateUnitPrice(dgv, cell);
                        //}
                    }
                    #endregion
                    break;
                case "成品规格型号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["剩余量", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "剩余量":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["BoxNum", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "TotalNum":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["Totalprice", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "Totalprice":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["NG", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "NW":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["NW"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["GW", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validateNW(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["GW", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        //if (dgv.CurrentRow.Cells["NW"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        //{
                            validateQuantity(dgv, cell);
                        //}
                    }
                    #endregion
                    break;
                case "GW":     
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        validateGW(dgv, cell);
                        (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                    }
                    #endregion
                    break;
            }
        }
        private bool validate手册编号(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Empty;
            if (cell.EditedFormattedValue == null || cell.EditedFormattedValue == DBNull.Value || cell.EditedFormattedValue.ToString() == "")
            {
                strSQL = "帮助录入查询 '%', 1";
            }
            else
            {
                strSQL = string.Format("帮助录入查询 {0}, 1",StringTools.SqlQ(cell.EditedFormattedValue.ToString()));
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dtTemp = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            DataRow selectRow = null;
            if (dtTemp.Rows.Count == 0)
            {
                SysMessage.InformationMsg("此手册编号不存在！");
                dgv.CurrentCell = cell;
                return false;
            }
            else if (dtTemp.Rows.Count == 1)
            {
                selectRow = dtTemp.Rows[0];
            }
            else if (dtTemp.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择手册编号";
                formSelect.dtData = dtTemp;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    selectRow = formSelect.returnRow;
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            Pid =Convert.ToInt32( selectRow["手册id"]);
            dgv.CurrentRow.Cells["手册编号"].Value = selectRow["手册编号"];
            return true;
               
        }
        private bool validate序号(myDataGridView dgv, DataGridViewCell cell)
        {
            if (dgv.CurrentRow.Cells["手册编号"].Value == DBNull.Value || dgv.CurrentRow.Cells["手册编号"].Value.ToString() == "")
            {
                SysMessage.InformationMsg("请先输入手册编号");
                dgv.CurrentCell = cell;
                return false;
            }
            else
            {
                string strSQL = string.Empty;
                if (cell.EditedFormattedValue != null && cell.EditedFormattedValue != DBNull.Value && cell.EditedFormattedValue.ToString() != "")
                {
                    strSQL = string.Format("SELECT 进口料件id, 序号, 商品编号, 品名规格型号, 数量, 单位, 单价, 征免 FROM 进口料件表 where 手册id={0} and 序号='{1}'", Pid, cell.EditedFormattedValue);
                }
                else
                {
                    strSQL = string.Format("SELECT 进口料件id, 序号, 商品编号, 品名规格型号, 数量, 单位, 单价, 征免 FROM 进口料件表 where 手册id={0}",Pid);
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                DataTable dtTemp = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataRow selectRow = null;
                if (dtTemp.Rows.Count == 0)
                {
                    SysMessage.InformationMsg("此序号不存在！");
                    dgv.CurrentCell = cell;
                    return false;
                }
                else if (dtTemp.Rows.Count == 1)
                {
                    selectRow = dtTemp.Rows[0];
                }
                else if (dtTemp.Rows.Count > 1)
                {
                    FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                    formSelect.strFormText = "选择序号";
                    formSelect.dtData = dtTemp;
                    if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        selectRow = formSelect.returnRow;
                    }
                    else
                    {
                        dgv.CurrentCell = cell;
                        return false;
                    }
                }
                dgv.CurrentRow.Cells["进口料件id"].Value = selectRow["进口料件id"];
                dgv.CurrentRow.Cells["品名规格型号"].Value = selectRow["品名规格型号"];
                dgv.CurrentRow.Cells["序号"].Value = selectRow["序号"];
                dgv.CurrentRow.Cells["Unit"].Value = selectRow["单位"];
                dgv.CurrentRow.Cells["UnitPrice"].Value = selectRow["单价"];
                dgv.CurrentRow.Cells["剩余量"].Value = GetLeavings(Convert.ToInt32(selectRow["进口料件id"]));
            }
            return true;
        }
        /// <summary>
        /// 根据料件id获取剩余量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private decimal GetLeavings(int id)
        {
            string strSQL = string.Format("查询统计剩余量 {0},1",id);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dtTemp = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtTemp.Rows.Count > 0)
            {
                return Convert.ToDecimal(dtTemp.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }
        private void validateBoxNum(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["BoxNum"].Value = DBNull.Value;
                dgv.CurrentRow.Cells["TotalNum"].Value = DBNull.Value;
                dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["BoxNum"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                    if (dgv.CurrentRow.Cells["Quantity"].Value == DBNull.Value || dgv.CurrentRow.Cells["Quantity"].Value == "" || Convert.ToDecimal(dgv.CurrentRow.Cells["Quantity"].Value) == 0)
                    {
                        dgv.CurrentRow.Cells["TotalNum"].Value = DBNull.Value;
                        dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
                    }
                    else
                    {
                        dgv.CurrentRow.Cells["TotalNum"].Value = Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["BoxNum"].Value) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["Quantity"].Value);
                        if (dgv.CurrentRow.Cells["UnitPrice"].Value == DBNull.Value || dgv.CurrentRow.Cells["UnitPrice"].Value == "" || Convert.ToDecimal(dgv.CurrentRow.Cells["UnitPrice"].Value) == 0)
                        {
                            dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
                        }
                        else
                        {
                            dgv.CurrentRow.Cells["Totalprice"].Value = Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["BoxNum"].Value) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["Quantity"].Value)
                                 * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["UnitPrice"].Value);
                        }
                    }
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["BoxNum"].Value = 0;
                    dgv.CurrentRow.Cells["TotalNum"].Value = DBNull.Value;
                    dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
                }
            }
        }
        private void validateQuantity(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["Quantity"].Value = DBNull.Value;
                dgv.CurrentRow.Cells["TotalNum"].Value = DBNull.Value;
                dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["Quantity"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                    if (dgv.CurrentRow.Cells["BoxNum"].Value == DBNull.Value || dgv.CurrentRow.Cells["BoxNum"].Value == "" || Convert.ToDecimal(dgv.CurrentRow.Cells["BoxNum"].Value) == 0)
                    {
                        dgv.CurrentRow.Cells["TotalNum"].Value = DBNull.Value;
                        dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
                    }
                    else
                    {
                        dgv.CurrentRow.Cells["TotalNum"].Value = Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["BoxNum"].Value) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["Quantity"].Value);
                        if (dgv.CurrentRow.Cells["UnitPrice"].Value == DBNull.Value || dgv.CurrentRow.Cells["UnitPrice"].Value == "" || Convert.ToDecimal(dgv.CurrentRow.Cells["UnitPrice"].Value) == 0)
                        {
                            dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
                        }
                        else
                        {
                            dgv.CurrentRow.Cells["Totalprice"].Value = Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["BoxNum"].Value) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["Quantity"].Value)
                                 * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["UnitPrice"].Value);
                        }
                    }
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["Quantity"].Value = 0;
                    dgv.CurrentRow.Cells["TotalNum"].Value = DBNull.Value;
                    dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
                }
            }
        }
        private void validateUnitPrice(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["UnitPrice"].Value = DBNull.Value;
                dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["UnitPrice"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                    if (dgv.CurrentRow.Cells["BoxNum"].Value == DBNull.Value || dgv.CurrentRow.Cells["BoxNum"].Value == "" || Convert.ToDecimal(dgv.CurrentRow.Cells["BoxNum"].Value) == 0 ||
                        dgv.CurrentRow.Cells["Quantity"].Value == DBNull.Value || dgv.CurrentRow.Cells["Quantity"].Value == "" || Convert.ToDecimal(dgv.CurrentRow.Cells["Quantity"].Value) == 0)
                    {
                        dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
                    }
                    else
                    {
                        dgv.CurrentRow.Cells["Totalprice"].Value = Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["BoxNum"].Value) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["Quantity"].Value)
                             * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["UnitPrice"].Value);
                    }
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["UnitPrice"].Value = 0;
                    dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
                }
            }
        }
        private void validateNW(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["NW"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["NW"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["NW"].Value = 0;
                }
            }
        }
        private void validateGW(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["GW"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["GW"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["GW"].Value = 0;
                }
            }

            //如果当前行的客人型号为空，则跳转到当前行的客人型号
            if (dgv.Rows[cell.RowIndex].Cells["手册编号"].Value == DBNull.Value || dgv.Rows[cell.RowIndex].Cells["手册编号"].Value.ToString().Trim() == "" ||
                dgv.Rows[cell.RowIndex].Cells["BoxNum"].Value == DBNull.Value || dgv.Rows[cell.RowIndex].Cells["BoxNum"].Value.ToString().Trim() == "")
            {
                dgv.CurrentCell = cell;
            }
            else
            {
                //否则跳转到下一行的箱号
                if (cell.RowIndex == dgv.Rows.Count - 1)
                {
                    dtDetailsAddRow();
                    dgv.CurrentCell = dgv["PackageNo", cell.RowIndex + 1];
                }
                else
                {
                    dgv.CurrentCell = dgv["PackageNo", cell.RowIndex + 1];
                }
            }
        }
        public override void dataGridViewDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            base.dataGridViewDetail_DataError(sender, e);
            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "BoxNum" || colName == "Quantity" || colName == "UnitPrice" || colName == "NW" || colName == "GW")
                e.Cancel = false;
        }

        /// <summary>
        /// 明细GRID增加一条新行
        /// </summary>
        public override void dtDetailsAddRow()
        {
            string OldNo = string.Empty;
            if (Pid > 0)
            {
                if (this.dataGridViewDetail.CurrentRow != null)
                    OldNo = this.dataGridViewDetail.CurrentRow.Cells["手册编号"].Value.ToString();
            }
            DataRow newRow = dtDetails.NewRow();
            if (giOrderID > 0)
                newRow["手册编号"] = OldNo;
            dtDetails.Rows.Add(newRow);
            setTool1Enabled();
        }
        #endregion

    }
}
