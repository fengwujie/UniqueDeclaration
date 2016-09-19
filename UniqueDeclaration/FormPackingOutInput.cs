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
    public partial class FormPackingOutInput : UniqueDeclarationBaseForm.FormBaseInput
    {
        public FormPackingOutInput()
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
            this.dataGridViewDetail.CausesValidation = false;
            this.dataGridViewDetail.AutoGenerateColumns = false;
            this.dataGridViewDetail.Columns["BM"].Visible = false;
            this.dataGridViewDetail.Columns["BM"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["id"].Visible = false;
            this.dataGridViewDetail.Columns["id"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["出口成品id"].Visible = false;
            this.dataGridViewDetail.Columns["出口成品id"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["Unit1"].Visible = false;
            this.dataGridViewDetail.Columns["Unit1"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["Unit2"].Visible = false;
            this.dataGridViewDetail.Columns["Unit2"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["PackageNo"].DisplayIndex = 0;
            this.dataGridViewDetail.Columns["PackageNo"].HeaderText = "Packing No(箱号)";
            this.dataGridViewDetail.Columns["PackageNo"].Width = 130;
            this.dataGridViewDetail.Columns["PackageNo"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["手册编号"].DisplayIndex = 1;
            this.dataGridViewDetail.Columns["手册编号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["序号"].DisplayIndex = 2;
            this.dataGridViewDetail.Columns["序号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["品名规格型号"].DisplayIndex = 3;
            this.dataGridViewDetail.Columns["品名规格型号"].HeaderText = "Deacription of Goods";
            this.dataGridViewDetail.Columns["品名规格型号"].Width = 150;
            this.dataGridViewDetail.Columns["品名规格型号"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["剩余量"].Visible = true;
            this.dataGridViewDetail.Columns["剩余量"].ReadOnly = true;
            this.dataGridViewDetail.Columns["剩余量"].DisplayIndex = 4;
            this.dataGridViewDetail.Columns["剩余量"].Width = 70;
            this.dataGridViewDetail.Columns["剩余量"].ContextMenuStrip = this.myContextDetails;
            //this.dataGridViewDetail.Columns["BoxNum"].DisplayIndex = 4;
            //this.dataGridViewDetail.Columns["BoxNum"].HeaderText = "箱数";
            //this.dataGridViewDetail.Columns["BoxNum"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["Quantity"].DisplayIndex = 5;
            this.dataGridViewDetail.Columns["Quantity"].HeaderText = "Quantity箱";
            this.dataGridViewDetail.Columns["Quantity"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewDetail.Columns["Quantity"].DefaultCellStyle = dataGridViewCellStyle1;

            this.dataGridViewDetail.Columns["Unit"].DisplayIndex = 6;
            this.dataGridViewDetail.Columns["Unit"].HeaderText = "单位";
            this.dataGridViewDetail.Columns["Unit"].ContextMenuStrip = this.myContextDetails;

            this.dataGridViewDetail.Columns["UnitPrice"].DisplayIndex = 7;
            this.dataGridViewDetail.Columns["UnitPrice"].HeaderText = "单价";
            this.dataGridViewDetail.Columns["UnitPrice"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["UnitPrice"].DefaultCellStyle = dataGridViewCellStyle1;

            this.dataGridViewDetail.Columns["TotalPrice"].DisplayIndex = 9;
            this.dataGridViewDetail.Columns["TotalPrice"].HeaderText = "总金额";
            this.dataGridViewDetail.Columns["TotalPrice"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["TotalPrice"].DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDetail.Columns["nw"].DisplayIndex = 10;
            this.dataGridViewDetail.Columns["nw"].HeaderText = "Net Weight";
            this.dataGridViewDetail.Columns["nw"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["nw"].DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDetail.Columns["gw"].DisplayIndex = 11;
            this.dataGridViewDetail.Columns["gw"].HeaderText = "Gross Weight";
            this.dataGridViewDetail.Columns["gw"].Width = 100;
            this.dataGridViewDetail.Columns["gw"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["gw"].DefaultCellStyle = dataGridViewCellStyle1;
        }
        public override void InitControlData()
        {
            base.InitControlData();
            this.gstrDetailFirstField = "PackageNo";
            bcbox_custid_SelectedIndexChanged = false;
            this.cbox_comid.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade,
                "SELECT comid, com_Abbr FROM company", "comid", "com_Abbr", -1);
            bcbox_custid_SelectedIndexChanged = true;
        }
        /// <summary>
        /// 加载表头数据
        /// </summary>
        public override void LoadDataSourceHead()
        {
            string strSQL = string.Format("SELECT * FROM Packing1 WHERE pid = {0}", giOrderID);
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
                rowHead["exportdate"] = DateTime.Now.Date;
                rowHead["inputdate"] = DateTime.Now.Date;
                rowHead["shipdate"] = DateTime.Now.Date;
                rowHead["inputuser"] = SystemGlobal.SystemGlobal_UserInfo.UserName;
                fillControl(rowHead);
            }
        }
        /// <summary>
        /// 加载表身数据
        /// </summary>
        public override void LoadDataSourceDetails()
        {
            string strSQL = string.Format("exec 出口装箱单录入查询 {0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
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
                            if (row["出口成品id"] != DBNull.Value && Convert.ToInt32(row["出口成品id"]) > 0)
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
                        strBuilder.AppendLine(@"INSERT INTO [Packing1]([custid],[InvoiceNo] ,[ExportDate],[shipdate] ,[comid] ,[per] ,[sailingabout],[PackingFrom] ,
                                                    [PackingTo] ,[InputDate] ,[InputUser],[ContractNo] ,[YourOrderNo],[Remark],[PriceTerm],[Mark1],[Mark2],[Mark3] ,
                                                    [Mark4] ,[Mark5] ,[Mark6],[Mark7],[工缴费率] ,[报关单号] ,[remark1],[remark2] ,[remark3] ,[Remark4] ,[装箱单号])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28})",
                            rowHead["custid"] == DBNull.Value ? "NULL" : rowHead["custid"],
                            rowHead["InvoiceNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InvoiceNo"].ToString()),
                            rowHead["ExportDate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["ExportDate"].ToString()),
                            rowHead["shipdate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["shipdate"].ToString()),
                            rowHead["comid"] == DBNull.Value ? "NULL" : rowHead["comid"],
                            rowHead["per"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["per"].ToString()),
                            rowHead["sailingabout"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["sailingabout"].ToString()),
                            rowHead["PackingFrom"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["PackingFrom"].ToString()),
                            rowHead["PackingTo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["PackingTo"].ToString()),
                            rowHead["InputDate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InputDate"].ToString()),
                            rowHead["InputUser"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InputUser"].ToString()),
                            rowHead["ContractNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["ContractNo"].ToString()),
                            rowHead["YourOrderNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["YourOrderNo"].ToString()),
                            rowHead["Remark"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Remark"].ToString()),
                            rowHead["Priceterm"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Priceterm"].ToString()),
                            rowHead["Mark1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark1"].ToString()),
                            rowHead["Mark2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark2"].ToString()),
                            rowHead["Mark3"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark3"].ToString()),
                            rowHead["Mark4"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark4"].ToString()),
                            rowHead["Mark5"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark5"].ToString()),
                            rowHead["Mark6"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark6"].ToString()),
                            rowHead["Mark7"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark7"].ToString()),
                            rowHead["工缴费率"] == DBNull.Value ? "NULL" : rowHead["工缴费率"],
                            rowHead["报关单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["报关单号"].ToString()),
                            rowHead["remark1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["remark1"].ToString()),
                            rowHead["remark2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["remark2"].ToString()),
                            rowHead["remark3"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["remark3"].ToString()),
                            rowHead["Remark4"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Remark4"].ToString()),
                            rowHead["装箱单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["装箱单号"].ToString()));
                        strBuilder.AppendLine("select @@IDENTITY--自动生成的订单ID");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object Pid = dtInsert.Rows[0][0];
                        rowHead["Pid"] = Pid;
                        strBuilder.Clear();
                        #endregion

                        #region 新增明细数据
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            if (row["出口成品id"] == DBNull.Value || Convert.ToInt32(row["出口成品id"]) == 0) continue;
                            strBuilder.AppendLine(@"INSERT INTO [PackingDetail1] ([Pid] ,[出口成品id],[PackageNo],[Quantity],[Unit],[UnitPrice],[NW],[Unit1],[GW],[Unit2])");
                            strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9})",
                                Pid, row["出口成品id"] == DBNull.Value ? "NULL" : row["出口成品id"],
                            row["PackageNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["PackageNo"].ToString()),
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
                            strBuilder.AppendFormat(@"UPDATE [Packing1] SET [custid] = {0},[InvoiceNo] = {1},[ExportDate] = {2},[shipdate] = {3},[comid] = {4}
                                    ,[per] = {5},[sailingabout] ={6} ,[PackingFrom] = {7} ,[PackingTo] = {8} ,[InputDate] = {9},[InputUser] ={10},[ContractNo] = {11}
                                    ,[YourOrderNo] = {12} ,[Remark] = {13} ,[PriceTerm] = {14},[Mark1] = {15} ,[Mark2] = {16} ,[Mark3] = {17} ,[Mark4] = {18}
                                    ,[Mark5] = {19},[Mark6] = {20} ,[Mark7] = {21} ,[工缴费率] = {22} ,[报关单号] = {23} ,[remark1] ={24} ,[remark2] = {25},
                                    [remark3] = {26} ,[Remark4] = {27},[装箱单号] = {28} WHERE Pid={29}",
                            rowHead["custid"] == DBNull.Value ? "NULL" : rowHead["custid"],
                            rowHead["InvoiceNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InvoiceNo"].ToString()),
                            rowHead["ExportDate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["ExportDate"].ToString()),
                            rowHead["shipdate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["shipdate"].ToString()),
                            rowHead["comid"] == DBNull.Value ? "NULL" : rowHead["comid"],
                            rowHead["per"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["per"].ToString()),
                            rowHead["sailingabout"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["sailingabout"].ToString()),
                            rowHead["PackingFrom"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["PackingFrom"].ToString()),
                            rowHead["PackingTo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["PackingTo"].ToString()),
                            rowHead["InputDate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InputDate"].ToString()),
                            rowHead["InputUser"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["InputUser"].ToString()),
                            rowHead["ContractNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["ContractNo"].ToString()),
                            rowHead["YourOrderNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["YourOrderNo"].ToString()),
                            rowHead["Remark"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Remark"].ToString()),
                            rowHead["Priceterm"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Priceterm"].ToString()),
                            rowHead["Mark1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark1"].ToString()),
                            rowHead["Mark2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark2"].ToString()),
                            rowHead["Mark3"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark3"].ToString()),
                            rowHead["Mark4"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark4"].ToString()),
                            rowHead["Mark5"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark5"].ToString()),
                            rowHead["Mark6"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark6"].ToString()),
                            rowHead["Mark7"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Mark7"].ToString()),
                            rowHead["工缴费率"] == DBNull.Value ? "NULL" : rowHead["工缴费率"],
                            rowHead["报关单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["报关单号"].ToString()),
                            rowHead["remark1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["remark1"].ToString()),
                            rowHead["remark2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["remark2"].ToString()),
                            rowHead["remark3"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["remark3"].ToString()),
                            rowHead["Remark4"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["Remark4"].ToString()),
                            rowHead["装箱单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["装箱单号"].ToString()),
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
                                if (row["出口成品id"] == DBNull.Value || Convert.ToInt32(row["出口成品id"]) == 0) continue;
                                strBuilder.AppendLine(@"INSERT INTO [PackingDetail1] ([Pid] ,[出口成品id],[PackageNo],[Quantity],[Unit],[UnitPrice],[NW],[Unit1],[GW],[Unit2])");
                                strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9})",
                                   rowHead["Pid"], row["出口成品id"] == DBNull.Value ? "NULL" : row["出口成品id"],
                                row["PackageNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["PackageNo"].ToString()),
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
                                strBuilder.AppendFormat(@"DELETE FROM [PackingDetail1] WHERE id={0}", row["id", DataRowVersion.Original]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion

                            #region 修改表身数据
                            else //if (row.RowState == DataRowState.Modified)
                            {
                                if (row["id"] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"UPDATE [PackingDetail1]SET [Pid] ={0},[出口成品id] ={1},[PackageNo] = {2},[Quantity] ={3},[Unit] ={4}
                                                                ,[UnitPrice] ={5},[NW] = {6},[Unit1] ={7},[GW] = {8},[Unit2] ={9} WHERE id={10}",
                                        rowHead["Pid"], row["出口成品id"] == DBNull.Value ? "NULL" : row["出口成品id"],
                                row["PackageNo"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["PackageNo"].ToString()),
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
            if (date_ExportDate.Checked)
            {
                if (rowHead["ExportDate"] == DBNull.Value || Convert.ToDateTime(rowHead["ExportDate"]) != date_ExportDate.Value)
                    rowHead["ExportDate"] = date_ExportDate.Value;
            }
            else
            {
                if (rowHead["ExportDate"] != DBNull.Value)
                    rowHead["ExportDate"] = DBNull.Value;
            }
            if (date_ShipDate.Checked)
            {
                if (rowHead["InputDate"] == DBNull.Value || Convert.ToDateTime(rowHead["InputDate"]) != date_ShipDate.Value)
                    rowHead["InputDate"] = date_ShipDate.Value;
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
            if (row.Table.Columns.Contains("ExportDate"))
            {
                if (row["ExportDate"] == DBNull.Value)
                {
                    date_ExportDate.Checked = false;
                }
                else
                {
                    date_ExportDate.Checked = true;
                    date_ExportDate.Value = Convert.ToDateTime(row["ExportDate"]);
                }
            }
            if (row.Table.Columns.Contains("InputDate"))
            {
                if (row["InputDate"] == DBNull.Value)
                {
                    date_ShipDate.Checked = false;
                }
                else
                {
                    date_ShipDate.Checked = true;
                    date_ShipDate.Value = Convert.ToDateTime(row["InputDate"]);
                }
            } 
            if (row.Table.Columns.Contains("comid"))
            {
                cbox_comid.SelectedValue = row["comid"];
            }
            if (row.Table.Columns.Contains("PackingTo"))
            {
                txt_PackingTo.Text = row["PackingTo"].ToString();
            }
            if (row.Table.Columns.Contains("YourOrderNo"))
            {
                txt_YourOrderNo.Text = row["YourOrderNo"].ToString();
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
            if (row.Table.Columns.Contains("装箱单号"))
            {
                txt_装箱单号.Text = row["装箱单号"].ToString();
            }
            if (row.Table.Columns.Contains("ContractNo"))
            {
                txt_ContractNo.Text = row["ContractNo"].ToString();
            }
            if (row.Table.Columns.Contains("Remark1"))
            {
                txt_Remark1.Text = row["Remark1"].ToString();
            }
            if (row.Table.Columns.Contains("Remark2"))
            {
                txt_Remark2.Text = row["Remark2"].ToString();
            }
            if (row.Table.Columns.Contains("Remark3"))
            {
                txt_Remark3.Text = row["Remark3"].ToString();
            }
            if (row.Table.Columns.Contains("Remark4"))
            {
                txt_Remark4.Text = row["Remark4"].ToString();
            }
            if (rowHead["comid"] != DBNull.Value)
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                DataTable dtCompany = dataAccess.GetTable("select e_name from customer where custid=" + rowHead["custid"], null);
                dataAccess.Close();
                if (dtCompany.Rows.Count > 0)
                {
                    txt_Messrs.Text = dtCompany.Rows[0]["e_name"].ToString();
                }
            }
            if (row.Table.Columns.Contains("工缴费率"))
            {
                if (row["工缴费率"] == DBNull.Value)
                {
                    txt_工缴费率.Text = string.Empty;
                }
                else
                {
                    txt_工缴费率.Text = row["工缴费率"].ToString();
                }
            }
        }
        #endregion

        #region 表头控件事件
        private void cbox_comid_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (!bcbox_custid_SelectedIndexChanged) return;
            if (rowHead["comid"].ToString() != cbox_comid.SelectedValue.ToString())
            {
                rowHead["comid"] = cbox_comid.SelectedValue;
                if (rowHead.RowState == DataRowState.Added)
                {
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                    dataAccess.Open();
                    DataTable dtCustomer = dataAccess.GetTable("SELECT * FROM company WHERE comid =" + cbox_comid.SelectedValue, null);
                    dataAccess.Close();
                    if (dtCustomer.Rows.Count > 0 && txt_Mark1.Text.Trim().Length == 0)
                    {
                        txt_PackingFrom.Text = dtCustomer.Rows[0]["city"].ToString();
                        rowHead["PackingFrom"] = dtCustomer.Rows[0]["city"];
                    }
                }
            }
        }

        private void txt_InvoiceNO_Validating(object sender, CancelEventArgs e)
        {
            if (rowHead.RowState == DataRowState.Added)
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                DataTable dtPacking = dataAccess.GetTable(string.Format("SELECT pid FROM Packing1 WHERE InvoiceNo ={0}", StringTools.SqlQ(txt_InvoiceNO.Text.Trim())), null);
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
            if (date_ExportDate.Checked)
            {
                if (rowHead["ExportDate"] == DBNull.Value || Convert.ToDateTime(rowHead["ExportDate"]) != date_ExportDate.Value)
                    rowHead["ExportDate"] = date_ExportDate.Value;
            }
            else
            {
                if (rowHead["ExportDate"] != DBNull.Value)
                    rowHead["ExportDate"] = DBNull.Value;
            }
        }

        private void date_InputDate_ValueChanged(object sender, EventArgs e)
        {
            if (date_ShipDate.Checked)
            {
                if (rowHead["ShipDate"] == DBNull.Value || Convert.ToDateTime(rowHead["ShipDate"]) != date_ShipDate.Value)
                    rowHead["ShipDate"] = date_ShipDate.Value;
            }
            else
            {
                if (rowHead["ShipDate"] != DBNull.Value)
                    rowHead["ShipDate"] = DBNull.Value;
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

        private void txt_YourOrderNo_Validated(object sender, EventArgs e)
        {
            if (rowHead["YourOrderNo"].ToString() != txt_YourOrderNo.Text)
            {
                rowHead["YourOrderNo"] = txt_YourOrderNo.Text;
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
        private void txt_装箱单号_Validating(object sender, CancelEventArgs e)
        {
            if (txt_装箱单号.Text.Trim() != "")
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                DataTable dtPacking = dataAccess.GetTable(string.Format("select * from 装箱单表 where 装箱单号={0}", StringTools.SqlQ(txt_装箱单号.Text.Trim())), null);
                dataAccess.Close();
                if (dtPacking.Rows.Count == 0)
                {
                    SysMessage.InformationMsg("此装箱单号不存在！");
                    txt_装箱单号.Text = "";
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

        private void myTextBox3_Validating(object sender, CancelEventArgs e)
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dtPacking = dataAccess.GetTable(string.Format("帮助录入查询  {0},2", StringTools.SqlQ(txt_Messrs.Text.Trim())), null);
            dataAccess.Close();
            DataRow selectRow = null;
            if (dtPacking.Rows.Count == 0)
            {
                SysMessage.InformationMsg("此客户不存在！");
                e.Cancel = true;
                txt_Messrs.Focus();
                return;
            }
            else if (dtPacking.Rows.Count == 1)
            {
                selectRow = dtPacking.Rows[0];
            }
            else
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择客户";
                formSelect.dtData = dtPacking;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    selectRow = formSelect.returnRow;
                }
                else
                {
                    e.Cancel = true;
                    txt_Messrs.Focus();
                    return;
                }
            }
            rowHead["custid"] = selectRow["custid"];
            txt_Messrs.Text = selectRow["E_name"].ToString();
            if (rowHead.RowState == DataRowState.Added && txt_Mark1.Text.Trim() == "")
            {
                rowHead["mark1"] = selectRow["mark1"];
                rowHead["mark2"] = selectRow["mark2"];
                rowHead["mark3"] = selectRow["mark3"];
                rowHead["mark4"] = selectRow["mark4"];
                rowHead["mark5"] = selectRow["mark5"];
                rowHead["mark6"] = selectRow["mark6"];
                rowHead["mark7"] = selectRow["mark7"];
                rowHead["packingto"] = selectRow["country"];
                //rowHead["Messrs"] = selectRow["E_name"];

                txt_Mark1.Text = selectRow["mark1"].ToString();
                txt_Mark2.Text = selectRow["mark2"].ToString();
                txt_Mark3.Text = selectRow["mark3"].ToString();
                txt_Mark4.Text = selectRow["mark4"].ToString();
                txt_Mark5.Text = selectRow["mark5"].ToString();
                txt_Mark6.Text = selectRow["mark6"].ToString();
                txt_Mark7.Text = selectRow["mark7"].ToString();
                txt_PackingTo.Text = selectRow["country"].ToString();
                txt_Messrs.Text = selectRow["E_name"].ToString();
            }
        }
        private void txt_ContractNo_Validated(object sender, EventArgs e)
        {
            if (rowHead["ContractNo"].ToString() != txt_ContractNo.Text)
            {
                rowHead["ContractNo"] = txt_ContractNo.Text;
            }
        }

        private void txt_工缴费率_Validating(object sender, CancelEventArgs e)
        {
            if (txt_工缴费率.Text.Trim().Length == 0) return;
            try
            {
                float.Parse(txt_工缴费率.Text.Trim());
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(ex.Message);
                e.Cancel = true;
                txt_工缴费率.Focus();
            }
        }
        private void txt_工缴费率_Validated(object sender, EventArgs e)
        {
            if (rowHead["工缴费率"].ToString() != txt_工缴费率.Text)
            {
                if (txt_工缴费率.Text.Trim().Length == 0)
                {
                    rowHead["工缴费率"] = DBNull.Value;
                }
                else
                {
                    rowHead["工缴费率"] = txt_工缴费率.Text.Trim();
                }
            }
        }

        private void txt_Remark1_Validated(object sender, EventArgs e)
        {
            if (rowHead["Remark1"].ToString() != txt_Remark1.Text)
            {
                rowHead["Remark1"] = txt_Remark1.Text;
            }
        }
        private void txt_Remark2_Validated(object sender, EventArgs e)
        {
            if (rowHead["Remark2"].ToString() != txt_Remark2.Text)
            {
                rowHead["Remark2"] = txt_Remark2.Text;
            }
        }

        private void txt_Remark3_Validated(object sender, EventArgs e)
        {
            if (rowHead["Remark3"].ToString() != txt_Remark3.Text)
            {
                rowHead["Remark3"] = txt_Remark3.Text;
            }
        }

        private void txt_Remark4_Validated(object sender, EventArgs e)
        {
            if (rowHead["Remark4"].ToString() != txt_Remark4.Text)
            {
                rowHead["Remark4"] = txt_Remark4.Text;
            }
        }
        private void txt_PriceTerm_Validated(object sender, EventArgs e)
        {
            if (rowHead["PriceTerm"].ToString() != txt_PriceTerm.Text)
            {
                rowHead["PriceTerm"] = txt_PriceTerm.Text;
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
                            dgv.CurrentCell = dgv["Quantity", cell.RowIndex];
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
                        dgv.CurrentCell = dgv["Quantity", cell.RowIndex];
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
            if (txt_工缴费率.Text.Trim() == "" && selectRow["工缴费率"]!=DBNull.Value)
            {
                txt_工缴费率.Text = selectRow["工缴费率"].ToString();
            }
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
                    strSQL = string.Format("SELECT 出口成品id, 序号, 商品编号, 品名规格型号, 数量, 单位, 单价, 征免 FROM 出口成品表 where 手册id={0} and 序号='{1}'", Pid, cell.EditedFormattedValue);
                }
                else
                {
                    strSQL = string.Format("SELECT 出口成品id, 序号, 商品编号, 品名规格型号, 数量, 单位, 单价, 征免 FROM 出口成品表 where 手册id={0}", Pid);
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
                dgv.CurrentRow.Cells["出口成品id"].Value = selectRow["出口成品id"];
                dgv.CurrentRow.Cells["品名规格型号"].Value = selectRow["品名规格型号"];
                dgv.CurrentRow.Cells["序号"].Value = selectRow["序号"];
                dgv.CurrentRow.Cells["Unit"].Value = selectRow["单位"];
                dgv.CurrentRow.Cells["UnitPrice"].Value = selectRow["单价"];
                dgv.CurrentRow.Cells["剩余量"].Value = GetLeavings(Convert.ToInt32(selectRow["出口成品id"]));
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
            string strSQL = string.Format("查询统计剩余量 {0},0",id);
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
        private void validateQuantity(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["Quantity"].Value = DBNull.Value;
                dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["Quantity"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                        if (dgv.CurrentRow.Cells["UnitPrice"].Value == DBNull.Value || dgv.CurrentRow.Cells["UnitPrice"].Value == "" || Convert.ToDecimal(dgv.CurrentRow.Cells["UnitPrice"].Value) == 0)
                        {
                            dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
                        }
                        else
                        {
                            dgv.CurrentRow.Cells["Totalprice"].Value = Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["Quantity"].Value)
                                 * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["UnitPrice"].Value);
                        }
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["Quantity"].Value = 0;
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
                    if (dgv.CurrentRow.Cells["Quantity"].Value == DBNull.Value || dgv.CurrentRow.Cells["Quantity"].Value == "" || Convert.ToDecimal(dgv.CurrentRow.Cells["Quantity"].Value) == 0)
                    {
                        dgv.CurrentRow.Cells["Totalprice"].Value = DBNull.Value;
                    }
                    else
                    {
                        dgv.CurrentRow.Cells["Totalprice"].Value = Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["Quantity"].Value)
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
                dgv.Rows[cell.RowIndex].Cells["unit1"].Value = DBNull.Value;
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
                    dgv.Rows[cell.RowIndex].Cells["unit1"].Value = DBNull.Value;
                }
            }
        }
        private void validateGW(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["GW"].Value = DBNull.Value;
                dgv.Rows[cell.RowIndex].Cells["unit2"].Value = DBNull.Value;
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
                    dgv.Rows[cell.RowIndex].Cells["unit2"].Value = DBNull.Value;
                }
            }

            //如果当前行的客人型号为空，则跳转到当前行的客人型号
            if (dgv.Rows[cell.RowIndex].Cells["手册编号"].Value == DBNull.Value || dgv.Rows[cell.RowIndex].Cells["手册编号"].Value.ToString().Trim() == "" ||
                dgv.Rows[cell.RowIndex].Cells["Quantity"].Value == DBNull.Value || dgv.Rows[cell.RowIndex].Cells["Quantity"].Value.ToString().Trim() == "")
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
