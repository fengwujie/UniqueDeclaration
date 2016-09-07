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

namespace UniqueDeclaration
{
    public partial class FormFinishedProductOutInput : UniqueDeclarationBaseForm.FormBaseInput
    {
        public FormFinishedProductOutInput()
        {
            InitializeComponent();
        }
        
        /// 是否触发值变化事件
        /// </summary>
        private bool bcbox_电子帐册号_SelectedIndexChanged = true;

        #region Form事件
        public override void FormBaseInput_Load(object sender, EventArgs e)
        {
            base.gstrDetailFirstField = "制造通知单号";
            base.FormBaseInput_Load(sender, e);
        }
        #endregion
        
        #region 方法
        /// <summary>
        /// 初始化GRID
        /// </summary>
        public override void InitGrid()
        {
            this.dataGridViewDetail.CausesValidation = false;
            // 
            // BM
            // 
            DataGridViewTextBoxColumn BM = new DataGridViewTextBoxColumn();
            BM.DataPropertyName = "BM";
            BM.HeaderText = "BM";
            BM.Name = "BM";
            BM.ReadOnly = true;
            BM.Visible = false;
            // 
            // 订单明细表id
            // 
            DataGridViewTextBoxColumn 订单明细表id = new DataGridViewTextBoxColumn();
            订单明细表id.DataPropertyName = "订单明细表id";
            订单明细表id.HeaderText = "订单明细表id";
            订单明细表id.Name = "订单明细表id";
            订单明细表id.ReadOnly = true;
            订单明细表id.Visible = false;
            // 
            // 客人型号
            // 
            DataGridViewTextBoxColumn 客人型号 = new DataGridViewTextBoxColumn();
            客人型号.DataPropertyName = "客人型号";
            客人型号.HeaderText = "客人型号";
            客人型号.Name = "客人型号";
            客人型号.ReadOnly = false;
            客人型号.Visible = true;
            客人型号.Width = 78;
            // 
            // 优丽型号
            // 
            DataGridViewTextBoxColumn 优丽型号 = new DataGridViewTextBoxColumn();
            优丽型号.DataPropertyName = "优丽型号";
            优丽型号.HeaderText = "优丽型号";
            优丽型号.Name = "优丽型号";
            优丽型号.ReadOnly = false;
            优丽型号.Visible = true;
            优丽型号.Width = 80;
            // 
            // 颜色
            // 
            DataGridViewTextBoxColumn 颜色 = new DataGridViewTextBoxColumn();
            颜色.DataPropertyName = "颜色";
            颜色.HeaderText = "颜色";
            颜色.Name = "颜色";
            颜色.ReadOnly = false;
            颜色.Visible = true;
            颜色.Width = 70;
            // 
            // 订单数量
            // 
            DataGridViewTextBoxColumn 订单数量 = new DataGridViewTextBoxColumn();
            订单数量.DataPropertyName = "订单数量";
            订单数量.HeaderText = "订单数量";
            订单数量.Name = "订单数量";
            订单数量.ReadOnly = false;
            订单数量.Visible = true;
            订单数量.Width = 78;
            // 
            // 单位
            // 
            DataGridViewTextBoxColumn 单位 = new DataGridViewTextBoxColumn();
            单位.DataPropertyName = "单位";
            单位.HeaderText = "单位";
            单位.Name = "单位";
            单位.ReadOnly = false;
            单位.Visible = true;
            单位.Width = 40;
            // 
            // 箱数
            // 
            DataGridViewTextBoxColumn 箱数 = new DataGridViewTextBoxColumn();
            箱数.DataPropertyName = "箱数";
            箱数.HeaderText = "箱数";
            箱数.Name = "箱数";
            箱数.ReadOnly = false;
            箱数.Visible = true;
            箱数.Width = 40;
            // 
            // 产品id
            // 
            DataGridViewTextBoxColumn 产品id = new DataGridViewTextBoxColumn();
            产品id.DataPropertyName = "产品id";
            产品id.HeaderText = "产品id";
            产品id.Name = "产品id";
            产品id.ReadOnly = true;
            产品id.Visible = false;
            // 
            // 配件id
            // 
            DataGridViewTextBoxColumn 配件id = new DataGridViewTextBoxColumn();
            配件id.DataPropertyName = "配件id";
            配件id.HeaderText = "配件id";
            配件id.Name = "配件id";
            配件id.ReadOnly = true;
            配件id.Visible = false;
            // 
            // 型号
            // 
            DataGridViewTextBoxColumn 型号 = new DataGridViewTextBoxColumn();
            型号.DataPropertyName = "型号";
            型号.HeaderText = "生产型号";
            型号.Name = "型号";
            型号.ReadOnly = false;
            型号.Visible = true;
            // 
            // 生产数量
            // 
            DataGridViewTextBoxColumn 生产数量 = new DataGridViewTextBoxColumn();
            生产数量.DataPropertyName = "生产数量";
            生产数量.HeaderText = "生产数量";
            生产数量.Name = "生产数量";
            生产数量.ReadOnly = false;
            生产数量.Visible = true;
            生产数量.Width = 78;
            // 
            // 实际总重
            // 
            DataGridViewTextBoxColumn 实际总重 = new DataGridViewTextBoxColumn();
            实际总重.DataPropertyName = "实际总重";
            实际总重.HeaderText = "实际总重";
            实际总重.Name = "实际总重";
            实际总重.ReadOnly = false;
            实际总重.Visible = true;
            实际总重.Width = 78;
            // 
            // 成品项号
            // 
            DataGridViewTextBoxColumn 成品项号 = new DataGridViewTextBoxColumn();
            成品项号.DataPropertyName = "成品项号";
            成品项号.HeaderText = "成品项号";
            成品项号.Name = "成品项号";
            成品项号.ReadOnly = false;
            成品项号.Visible = true;
            成品项号.Width = 78;
            // 
            // 成品名称及商编
            // 
            DataGridViewTextBoxColumn 成品名称及商编 = new DataGridViewTextBoxColumn();
            成品名称及商编.DataPropertyName = "成品名称及商编";
            成品名称及商编.HeaderText = "成品名称及商编";
            成品名称及商编.Name = "成品名称及商编";
            成品名称及商编.ReadOnly = false;
            成品名称及商编.Visible = true;
            成品名称及商编.Width = 120;
            // 
            // 成品规格型号
            // 
            DataGridViewTextBoxColumn 成品规格型号 = new DataGridViewTextBoxColumn();
            成品规格型号.DataPropertyName = "成品规格型号";
            成品规格型号.HeaderText = "成品规格型号";
            成品规格型号.Name = "成品规格型号";
            成品规格型号.ReadOnly = false;
            成品规格型号.Visible = true;
            成品规格型号.Width = 110;
            // 
            // 申报单位
            // 
            DataGridViewTextBoxColumn 申报单位 = new DataGridViewTextBoxColumn();
            申报单位.DataPropertyName = "申报单位";
            申报单位.HeaderText = "申报单位";
            申报单位.Name = "申报单位";
            申报单位.ReadOnly = false;
            申报单位.Visible = true;
            申报单位.Width = 78;
            // 
            // 法定单位
            // 
            DataGridViewTextBoxColumn 法定单位 = new DataGridViewTextBoxColumn();
            法定单位.DataPropertyName = "法定单位";
            法定单位.HeaderText = "法定单位";
            法定单位.Name = "法定单位";
            法定单位.ReadOnly = false;
            法定单位.Visible = true;
            法定单位.Width = 78;
            // 
            // 变更规格型号
            // 
            DataGridViewTextBoxColumn 变更规格型号 = new DataGridViewTextBoxColumn();
            变更规格型号.DataPropertyName = "变更规格型号";
            变更规格型号.HeaderText = "变更规格型号";
            变更规格型号.Name = "变更规格型号";
            变更规格型号.ReadOnly = false;
            变更规格型号.Visible = true;
            变更规格型号.Width = 110;
            // 
            // 总重
            // 
            DataGridViewTextBoxColumn 总重 = new DataGridViewTextBoxColumn();
            总重.DataPropertyName = "总重";
            总重.HeaderText = "总重";
            总重.Name = "总重";
            总重.ReadOnly = true;
            总重.Visible = false;
            // 
            // 订单备注
            // 
            DataGridViewTextBoxColumn 订单备注 = new DataGridViewTextBoxColumn();
            订单备注.DataPropertyName = "订单备注";
            订单备注.HeaderText = "订单备注";
            订单备注.Name = "订单备注";
            订单备注.ReadOnly = false;
            订单备注.Visible = true;
            订单备注.Width = 120;
            // 
            // 已生产量
            // 
            DataGridViewTextBoxColumn 已生产量 = new DataGridViewTextBoxColumn();
            已生产量.DataPropertyName = "已生产量";
            已生产量.HeaderText = "已生产量";
            已生产量.Name = "已生产量";
            已生产量.ReadOnly = true;
            已生产量.Visible = false;
            // 
            // 未生产量量
            // 
            DataGridViewTextBoxColumn 未生产量 = new DataGridViewTextBoxColumn();
            未生产量.DataPropertyName = "未生产量";
            未生产量.HeaderText = "未生产量";
            未生产量.Name = "未生产量";
            未生产量.ReadOnly = true;
            未生产量.Visible = false;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{BM,订单明细表id,客人型号,优丽型号,颜色,订单数量,单位,
                        箱数,产品id,配件id,型号,生产数量,实际总重, 成品项号,成品名称及商编,成品规格型号,申报单位,法定单位,变更规格型号,总重,
                        订单备注,已生产量,未生产量});

        }
        public override void InitControlData()
        {
            base.InitControlData();
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
            string strSQL = string.Format("SELECT * FROM 报关订单表 WHERE 订单id ={0}", giOrderID);
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
                rowHead["出货日期"] = date_出货日期.Value;
                rowHead["录入日期"] = date_录入日期.Value;
                cbox_电子帐册号.SelectedValue = ConfigurationManager.AppSettings["defaultManualCode"].ToString();
                rowHead["手册编号"] = cbox_电子帐册号.SelectedValue;
                fillControl(rowHead);
                //dtHead.AcceptChanges();
            }
        }
        /// <summary>
        /// 加载表身数据
        /// </summary>
        public override void LoadDataSourceDetails()
        {
            string strSQL = string.Format("exec 报关订单录入查询 {0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
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
                if (rowHead["订单号码"].ToString().Length > 0 || rowHead["流水号"].ToString().Length > 0
                    || rowHead["客户代码"].ToString().Length > 0 || rowHead["客户名称"].ToString().Length > 0)
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
                if (txt_客户代码.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("客户代码不能为空！");
                    txt_客户代码.Focus();
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
                        strBuilder.AppendLine("INSERT INTO [报关预先订单表]([订单号码],[客户代码],[客户名称],[出货日期],[录入日期],[手册编号],[流水号])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},'{3}','{4}','{5}',{6})",
                            rowHead["订单号码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["订单号码"].ToString()),
                            rowHead["客户代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户代码"].ToString()),
                            rowHead["客户名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户名称"].ToString()),
                            rowHead["出货日期"], rowHead["录入日期"], rowHead["手册编号"] == DBNull.Value ? "NULL" : rowHead["手册编号"],
                            rowHead["流水号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["流水号"].ToString()));
                        strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
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
                            //row["订单id"] = iID;
                            strBuilder.AppendLine("INSERT INTO [报关预先订单明细表]([订单id],[客人型号],[优丽型号],[颜色],[单位],[箱数],[产品id],[配件id],[订单数量],");
                            strBuilder.AppendLine("[生产数量],[成品项号],[成品名称及商编],[成品规格型号],[申报单位],[法定单位],[变更规格型号],[订单备注])");
                            strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})",
                                订单id, row["客人型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["客人型号"].ToString()),
                                row["优丽型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["优丽型号"].ToString()),
                                row["颜色"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["颜色"].ToString()),
                                row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                row["箱数"] == DBNull.Value ? "NULL" : row["箱数"], row["产品id"] == DBNull.Value ? "NULL" : row["产品id"],
                                row["配件id"] == DBNull.Value ? "NULL" : row["配件id"], row["订单数量"] == DBNull.Value ? "NULL" : row["订单数量"],
                                row["生产数量"] == DBNull.Value ? 0 : row["生产数量"], row["成品项号"] == DBNull.Value ? "NULL" : row["成品项号"],
                                row["成品名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品名称及商编"].ToString()),
                                row["成品规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品规格型号"].ToString()),
                                row["申报单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["申报单位"].ToString()),
                                row["法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["法定单位"].ToString()),
                                row["变更规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["变更规格型号"].ToString()),
                                row["订单备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["订单备注"].ToString()));
                            strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
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
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    dataAccess.BeginTran();
                    try
                    {
                        #region //修改表头数据
                        if (rowHead.RowState == DataRowState.Modified)
                        {
                            strBuilder.AppendFormat("UPDATE [报关预先订单表] SET [订单号码]={0},[客户代码]={1},[客户名称]={2},[出货日期]={3},[录入日期]={4},[手册编号]={5},[流水号]={6} where 订单id={7}",
                                                    rowHead["订单号码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["订单号码"].ToString()),
                                rowHead["客户代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户代码"].ToString()),
                                rowHead["客户名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户名称"].ToString()),
                                rowHead["出货日期"], rowHead["录入日期"], rowHead["手册编号"] == DBNull.Value ? "NULL" : rowHead["手册编号"],
                                rowHead["流水号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["流水号"].ToString()), rowHead["订单id"]);
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
                                //row["订单id"] = rowHead["订单id"];
                                if (row["客人型号"] == DBNull.Value || row["客人型号"].ToString().Trim().Length == 0) continue;
                                if (row["优丽型号"] == DBNull.Value || row["优丽型号"].ToString().Trim().Length == 0) continue;
                                strBuilder.AppendLine("INSERT INTO [报关预先订单明细表]([订单id],[客人型号],[优丽型号],[颜色],[单位],[箱数],[产品id],[配件id],[订单数量],");
                                strBuilder.AppendLine("[生产数量],[成品项号],[成品名称及商编],[成品规格型号],[申报单位],[法定单位],[变更规格型号],[订单备注])");
                                strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})",
                                    rowHead["订单id"] == DBNull.Value ? "NULL" : rowHead["订单id"],
                                    row["客人型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["客人型号"].ToString()),
                                    row["优丽型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["优丽型号"].ToString()),
                                    row["颜色"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["颜色"].ToString()),
                                    row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                    row["箱数"] == DBNull.Value ? "NULL" : row["箱数"], row["产品id"] == DBNull.Value ? "NULL" : row["产品id"],
                                    row["配件id"] == DBNull.Value ? "NULL" : row["配件id"], row["订单数量"] == DBNull.Value ? "NULL" : row["订单数量"],
                                    row["生产数量"] == DBNull.Value ? 0 : row["生产数量"], row["成品项号"] == DBNull.Value ? "NULL" : row["成品项号"],
                                    row["成品名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品名称及商编"].ToString()),
                                    row["成品规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品规格型号"].ToString()),
                                    row["申报单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["申报单位"].ToString()),
                                    row["法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["法定单位"].ToString()),
                                    row["变更规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["变更规格型号"].ToString()),
                                    row["订单备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["订单备注"].ToString()));
                                strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                                object 订单明细表id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                                strBuilder.Clear();
                                row["订单明细表id"] = 订单明细表id;
                            }
                            #endregion

                            #region 删除表身数据
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                if (row["订单明细表id", DataRowVersion.Original] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"DELETE FROM [报关预先订单明细表] WHERE 订单明细表id={0}", row["订单明细表id", DataRowVersion.Original]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion

                            #region 修改表身数据
                            else //if (row.RowState == DataRowState.Modified)
                            {
                                if (row["订单明细表id"] == DBNull.Value) continue;
                                if (row["客人型号"] == DBNull.Value || row["客人型号"].ToString().Trim().Length == 0
                                    || row["优丽型号"] == DBNull.Value || row["优丽型号"].ToString().Trim().Length == 0)
                                {
                                    strBuilder.AppendFormat(@"DELETE FROM [报关预先订单明细表] WHERE 订单明细表id={0}", row["订单明细表id"]);
                                }
                                else
                                {
                                    strBuilder.AppendFormat(@"UPDATE [报关预先订单明细表] SET [订单id]={0},[客人型号]={1},[优丽型号]={2},[颜色]={3},[单位]={4},[箱数]={5},
                                                        [产品id]={6},[配件id]={7},[订单数量]={8},[生产数量]={9},[成品项号]={10},[成品名称及商编]={11},[成品规格型号]={12},
                                                        [申报单位]={13},[法定单位]={14},[变更规格型号]={15},[订单备注]={16} where 订单明细表id={17}",
                                            rowHead["订单id"], row["客人型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["客人型号"].ToString()),
                                        row["优丽型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["优丽型号"].ToString()),
                                        row["颜色"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["颜色"].ToString()),
                                        row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                        row["箱数"] == DBNull.Value ? "NULL" : row["箱数"], row["产品id"] == DBNull.Value ? "NULL" : row["产品id"],
                                        row["配件id"] == DBNull.Value ? "NULL" : row["配件id"], row["订单数量"] == DBNull.Value ? "NULL" : row["订单数量"],
                                        row["生产数量"] == DBNull.Value ? 0 : row["生产数量"], row["成品项号"] == DBNull.Value ? "NULL" : row["成品项号"],
                                        row["成品名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品名称及商编"].ToString()),
                                        row["成品规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["成品规格型号"].ToString()),
                                        row["申报单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["申报单位"].ToString()),
                                        row["法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["法定单位"].ToString()),
                                        row["变更规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["变更规格型号"].ToString()),
                                        row["订单备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["订单备注"].ToString()), row["订单明细表id"]);
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

        #region 表头控件值变化事件
        private void txt_订单号码_Validating(object sender, CancelEventArgs e)
        {
            if (txt_订单号码.Text.Trim().Length == 0)
            {
                SysMessage.InformationMsg("请输入订单号码");
                return;
            }
            if (rowHead.RowState != DataRowState.Added && txt_订单号码.Text.Trim() != rowHead["订单号码", DataRowVersion.Original].ToString())
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                DataTable dtTemp = dataAccess.GetTable(string.Format("SELECT 订单号码 FROM 装箱单明细表 WHERE 订单号码={0}", rowHead["订单号码", DataRowVersion.Original]), null);
                dataAccess.Close();
                if (dtTemp.Rows.Count > 0)
                {
                    SysMessage.InformationMsg("在装箱单此订单号码已经存在不能修改");
                    txt_订单号码.Text = rowHead["订单号码", DataRowVersion.Original].ToString();
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

        private void txt_客户代码_Validating(object sender, CancelEventArgs e)
        {
            if (txt_客户代码.Text.Trim().Length > 0)
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("select KeyField as 客户代码,SecondField as 客户名称 from dbo.tabCustomer WHERE KeyField = {0} order by KeyField", StringTools.SqlQ(this.txt_客户代码.Text.Trim()));
                DataTable dttabCustomer = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dttabCustomer.Rows.Count == 0)
                {
                    SysMessage.InformationMsg("此客户编号不存在！");
                    e.Cancel = true;
                    return;
                }
                else
                {
                    fillControl(dttabCustomer.Rows[0]);
                    fillRowHead(dttabCustomer.Rows[0]);
                }
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

        /// <summary>
        /// 填充表头数据到控件上
        /// </summary>
        /// <param name="row">来源数据</param>
        private void fillControl(DataRow row)
        {
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
            if (row.Table.Columns.Contains("手册编号"))
            {
                cbox_电子帐册号.SelectedValue = row["手册编号"];
            }
            if (row.Table.Columns.Contains("出货日期"))
            {
                date_出货日期.Value = Convert.ToDateTime(row["出货日期"]);
            }
            if (row.Table.Columns.Contains("录入日期"))
            {
                date_录入日期.Value = Convert.ToDateTime(row["录入日期"]);
            }
        }
        /// <summary>
        /// 填充表头数据到rowHead中
        /// </summary>
        /// <param name="row">来源数据</param>
        private void fillRowHead(DataRow row)
        {
            if (row.Table.Columns.Contains("订单号码") && rowHead["订单号码"].ToString() != row["订单号码"].ToString())
            {
                rowHead["订单号码"] = row["订单号码"];
            }
            if (row.Table.Columns.Contains("客户代码") && rowHead["客户代码"].ToString() != row["客户代码"].ToString())
            {
                rowHead["客户代码"] = row["客户代码"];
            }
            if (row.Table.Columns.Contains("客户名称") && rowHead["客户名称"].ToString() != row["客户名称"].ToString())
            {
                rowHead["客户名称"] = row["客户名称"];
            }
            if (row.Table.Columns.Contains("手册编号") && rowHead["手册编号"].ToString() != row["手册编号"].ToString())
            {
                rowHead["手册编号"] = row["手册编号"];
            }
            if (row.Table.Columns.Contains("出货日期") && Convert.ToDateTime(rowHead["出货日期"]) != Convert.ToDateTime(row["出货日期"]))
            {
                rowHead["出货日期"] = row["出货日期"];
            }
            if (row.Table.Columns.Contains("录入日期") && Convert.ToDateTime(rowHead["录入日期"]) != Convert.ToDateTime(row["录入日期"]))
            {
                rowHead["录入日期"] = row["录入日期"];
            }
        }

        private void cbox_电子帐册号_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bcbox_电子帐册号_SelectedIndexChanged && rowHead["手册编号"].ToString() != cbox_电子帐册号.SelectedValue.ToString())
                rowHead["手册编号"] = cbox_电子帐册号.SelectedValue;
        }

        private void date_出货日期_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(rowHead["出货日期"]) != date_出货日期.Value)
            {
                rowHead["出货日期"] = date_出货日期.Value;
            }
        }

        private void date_录入日期_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(rowHead["录入日期"]) != date_录入日期.Value)
            {
                rowHead["录入日期"] = date_录入日期.Value;
            }
        }
        #endregion


    }
}
