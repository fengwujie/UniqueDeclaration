﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using System.Configuration;
using UniqueDeclarationPubilc;
using UniqueDeclarationBaseForm;
using UniqueDeclarationBaseForm.Controls;

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
            this.tool2_Number.Visible = true;
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
            this.dataGridViewDetail.AutoGenerateColumns = false;
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
            // 制造通知单号
            // 
            DataGridViewTextBoxColumn 制造通知单号 = new DataGridViewTextBoxColumn();
            制造通知单号.DataPropertyName = "制造通知单号";
            制造通知单号.HeaderText = "制造通知单号";
            制造通知单号.Name = "制造通知单号";
            制造通知单号.ReadOnly = false;
            制造通知单号.Visible = true;
            制造通知单号.Width = 100;

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
            // 版本号
            // 
            DataGridViewTextBoxColumn 版本号 = new DataGridViewTextBoxColumn();
            版本号.DataPropertyName = "版本号";
            版本号.HeaderText = "企业版本号";
            版本号.Name = "版本号";
            版本号.ReadOnly = true;
            版本号.Visible = true;
            // 
            // 内部版本号
            // 
            DataGridViewTextBoxColumn 内部版本号 = new DataGridViewTextBoxColumn();
            内部版本号.DataPropertyName = "内部版本号";
            内部版本号.HeaderText = "内部版本号";
            内部版本号.Name = "内部版本号";
            内部版本号.ReadOnly = true;
            内部版本号.Visible = true;
            // 
            // 制造通知单ID
            // 
            DataGridViewTextBoxColumn 制造通知单id = new DataGridViewTextBoxColumn();
            制造通知单id.DataPropertyName = "制造通知单id";
            制造通知单id.HeaderText = "制造通知单id";
            制造通知单id.Name = "制造通知单id";
            制造通知单id.ReadOnly = true;
            制造通知单id.Visible = false;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{BM,订单明细表id,制造通知单号,客人型号,优丽型号,颜色,订单数量,单位,
                        箱数,产品id,配件id,型号,生产数量,实际总重, 成品项号,成品名称及商编,成品规格型号,申报单位,法定单位,版本号,内部版本号,变更规格型号,总重,
                        订单备注,制造通知单id});

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
            if (rowHead.RowState == DataRowState.Modified)
            {
                bModify = true;
            }
            else if (rowHead.RowState == DataRowState.Added)
            {
                if (rowHead["订单号码"].ToString().Length > 0
                    || rowHead["客户代码"].ToString().Length > 0 || rowHead["客户名称"].ToString().Length > 0)
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
                        strBuilder.AppendLine("INSERT INTO [报关订单表]([订单号码],[客户代码],[客户名称],[出货日期],[录入日期],[手册编号])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},'{3}','{4}','{5}')",
                            rowHead["订单号码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["订单号码"].ToString()),
                            rowHead["客户代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户代码"].ToString()),
                            rowHead["客户名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户名称"].ToString()),
                            rowHead["出货日期"], rowHead["录入日期"], rowHead["手册编号"] == DBNull.Value ? "NULL" : rowHead["手册编号"]);
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
                            strBuilder.AppendLine("INSERT INTO [报关订单明细表]([订单id],[客人型号],[优丽型号],[颜色],[单位],[箱数],[产品id],[配件id],[订单数量],");
                            strBuilder.AppendLine("[生产数量],[成品项号],[成品名称及商编],[成品规格型号],[申报单位],[法定单位],[变更规格型号],[订单备注],版本号,内部版本号,制造通知单id)");
                            strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19})",
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
                                row["订单备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["订单备注"].ToString()),
                                row["版本号"] == DBNull.Value ? 0 : row["版本号"],row["内部版本号"] == DBNull.Value ? 0 : row["内部版本号"],
                                row["制造通知单id"] == DBNull.Value ? 0 : row["制造通知单id"]);
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
                        #region 修改表头数据
                        if (rowHead.RowState == DataRowState.Modified)
                        {
                            strBuilder.AppendFormat("UPDATE [报关订单表] SET [订单号码]={0},[客户代码]={1},[客户名称]={2},[出货日期]={3},[录入日期]={4},[手册编号]={5} where 订单id={6}",
                                                    rowHead["订单号码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["订单号码"].ToString()),
                                rowHead["客户代码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户代码"].ToString()),
                                rowHead["客户名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["客户名称"].ToString()),
                                rowHead["出货日期"], rowHead["录入日期"], rowHead["手册编号"] == DBNull.Value ? "NULL" : rowHead["手册编号"],
                                rowHead["订单id"]);
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
                                strBuilder.AppendLine("INSERT INTO [报关订单明细表]([订单id],[客人型号],[优丽型号],[颜色],[单位],[箱数],[产品id],[配件id],[订单数量],");
                                strBuilder.AppendLine("[生产数量],[成品项号],[成品名称及商编],[成品规格型号],[申报单位],[法定单位],[变更规格型号],[订单备注],版本号,内部版本号,制造通知单id)");
                                strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19})",
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
                                    row["订单备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["订单备注"].ToString()),
                                    row["版本号"] == DBNull.Value ? 0 : row["版本号"], row["内部版本号"] == DBNull.Value ? 0 : row["内部版本号"],
                                    row["制造通知单id"] == DBNull.Value ? 0 : row["制造通知单id"]);
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
                                strBuilder.AppendFormat(@"DELETE FROM [报关订单明细表] WHERE 订单明细表id={0}", row["订单明细表id", DataRowVersion.Original]);
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
                                    strBuilder.AppendFormat(@"UPDATE [报关订单明细表] SET [订单id]={0},[客人型号]={1},[优丽型号]={2},[颜色]={3},[单位]={4},[箱数]={5},
                                                        [产品id]={6},[配件id]={7},[订单数量]={8},[生产数量]={9},[成品项号]={10},[成品名称及商编]={11},[成品规格型号]={12},
                                                        [申报单位]={13},[法定单位]={14},[变更规格型号]={15},[订单备注]={16},版本号={17},内部版本号={18},制造通知单id={19} 
                                                        where 订单明细表id={20}",
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
                                        row["订单备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["订单备注"].ToString()),
                                        row["版本号"] == DBNull.Value ? 0 : row["版本号"], row["内部版本号"] == DBNull.Value ? 0 : row["内部版本号"],
                                        row["制造通知单id"] == DBNull.Value ? 0 : row["制造通知单id"],row["订单明细表id"]);
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
                string strSQL = string.Format("select KeyField as 客户代码,SecondField as 客户名称 from tabCustomer WHERE KeyField = {0} order by KeyField", StringTools.SqlQ(this.txt_客户代码.Text.Trim()));
                DataTable dttabCustomer = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dttabCustomer.Rows.Count == 0)
                {
                    SysMessage.InformationMsg("此客户编号不存在！");
                    //e.Cancel = true;
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

        #region tool2事件
        public override void tool2_Import_Click(object sender, EventArgs e)
        {
            base.tool2_Import_Click(sender, e);
            FormBaseDialogInput objForm = new FormBaseDialogInput();
            objForm.strFormText = "请输入制造通知单号";
            if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            string strSQL = string.Format("SELECT * FROM 报关制造通知单表 WHERE 手册编号='{0}' AND 制造通知单号 LIKE '%{1}%'", cbox_电子帐册号.Text, StringTools.SqlLikeQ(objForm.strReturn));
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtList = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtList.Rows.Count == 0) return;
            string 制造通知单号 = string.Empty;
            long 制造通知单id = 0;
            if (dtList.Rows.Count == 1)
            {
                制造通知单号 = dtList.Rows[0]["制造通知单号"].ToString();
                制造通知单id = Convert.ToInt64(dtList.Rows[0]["制造通知单id"]);
            }
            else
            {
                FormBaseSingleSelect selectForm = new FormBaseSingleSelect();
                selectForm.strFormText = "选择流水号";
                selectForm.dtData = dtList;
                if (selectForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    制造通知单号 = selectForm.returnRow["制造通知单号"].ToString();
                    制造通知单id = Convert.ToInt64(selectForm.returnRow["制造通知单id"]);
                }
                else
                {
                    return;
                }
            }

            strSQL = string.Format(@"select DN.制造通知单明细表id, DN.客人型号,DN.优丽型号,DN.颜色,DN.订单数量,DN.单位,DN.箱数,DN.产品id, DN.配件id, 
                                        isnull(C.产品型号, P.配件型号) as 型号, DN.生产数量,DN.订单备注,case when c.产品id>0 then C.实际总重 else P.实际总重 end as 实际总重,
                                        DN.成品项号,DN.成品名称及商编,DN.成品规格型号,DN.申报单位,DN.法定单位,DN.变更规格型号,isnull(A.单耗,0)+isnull(B.单耗,0) as 单耗,DN.订单备注 
                                     from 报关制造通知单明细表 DN left outer join 产品资料表 C on C.产品id = DN.产品id left outer join 配件资料表 P on P.配件id = DN.配件id 
                                     left outer join (SELECT 制造通知单id, 制造通知单明细表id,SUM(单耗*1000) AS 单耗 From 产品配件改样报关前材料明细表 GROUP BY  制造通知单id, 制造通知单明细表id)  A 
                                            on DN.制造通知单id = A.制造通知单id AND DN.制造通知单明细表id = A.制造通知单明细表id 
                                     left outer join (SELECT 制造通知单id, 制造通知单明细表id,SUM(数量*1000)  AS 单耗 From 产品配件改样报关前材料表 GROUP BY  制造通知单id, 制造通知单明细表id)  B 
                                            on DN.制造通知单id =B.制造通知单id AND DN.制造通知单明细表id =B.制造通知单明细表id where DN.制造通知单id ={0}", 制造通知单id);
            dataAccess.Open();
            dtList = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            DataRow lastRow = (this.dataGridViewDetail.Rows[this.dataGridViewDetail.Rows.Count-1].DataBoundItem as DataRowView).Row;
            //if (lastRow["客人型号"] == DBNull.Value || lastRow["客人型号"].ToString()=="")
            //    this.dataGridViewDetail.Rows.RemoveAt(this.dataGridViewDetail.Rows.Count - 1);

            if (dtList.Rows.Count > 0)
            {
                //如果最后一行的客人型号和优丽型号都为空，则删除掉
                if (this.dataGridViewDetail.Rows.Count > 0)
                {
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
                }
                foreach (DataRow row in dtList.Rows)
                {
                    DataRow newRow = dtDetails.NewRow();
                    newRow["制造通知单号"] = 制造通知单号;
                    newRow["制造通知单id"] = 制造通知单id;
                    newRow["客人型号"] = row["客人型号"];
                    newRow["优丽型号"] = row["优丽型号"];
                    newRow["颜色"] = row["颜色"];
                    newRow["单位"] = row["单位"];
                    newRow["型号"] = row["型号"];
                    newRow["产品id"] = row["产品id"];
                    newRow["配件id"] = row["配件id"];
                    newRow["订单备注"] = row["订单备注"];
                    newRow["订单数量"] = row["订单数量"] == DBNull.Value ? 0 : row["订单数量"];
                    newRow["生产数量"] = row["生产数量"];
                    newRow["实际总重"] = row["实际总重"];
                    newRow["成品规格型号"] = row["成品规格型号"];
                    newRow["成品名称及商编"] = row["成品名称及商编"];
                    newRow["申报单位"] = row["申报单位"] == DBNull.Value ? "个" : row["申报单位"];
                    newRow["法定单位"] = row["法定单位"] == DBNull.Value ? "千克" : row["法定单位"];
                    newRow["成品项号"] = row["成品项号"];
                    newRow["成品规格型号"] = row["成品规格型号"];
                    newRow["变更规格型号"] = row["变更规格型号"];
                    newRow["箱数"] = row["箱数"] == DBNull.Value ? 0 : row["箱数"];
                    dtDetails.Rows.Add(newRow);
                }
                setTool1Enabled();
            }
        }

        public override void tool2_Number_Click(object sender, EventArgs e)
        {
            base.tool2_Number_Click(sender, e);
            if (dataGridViewDetail.Rows.Count > 0)
            {
                string strSQL = string.Format("SELECT 出口成品表.手册Id FROM 手册资料表 LEFT OUTER JOIN 出口成品表 ON 手册资料表.手册id = 出口成品表.手册Id where 手册资料表.手册编号='{0}'",cbox_电子帐册号.SelectedValue);
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                DataTable dtTemp = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtTemp.Rows.Count == 0) return;
                int m = dtTemp.Rows.Count;
                long[] Numbers = new long[m];
                long[] InNumbers = new long[m];
                long IDValue = 0;
                dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                foreach (DataRow row in dtDetails.Rows)
                {
                    if (row.RowState == DataRowState.Deleted) continue;

                    #region 处理版本号
                    if (row["版本号"] == DBNull.Value || row["版本号"].ToString() == "")
                    {
                        //如果成品项号为空时，不做版本号处理
                        if (row["成品项号"] == DBNull.Value || row["成品项号"].ToString() == "")
                        {
                        }
                        else
                        {
                            strSQL = string.Format(@"SELECT max(报关订单明细表.版本号) as 版本号 FROM 报关订单表 LEFT OUTER JOIN 报关订单明细表 ON 报关订单表.订单id =报关订单明细表.订单id 
                                                        where 报关订单明细表.版本号 is not null and 报关订单表.手册编号='{0}' and 报关订单明细表.成品项号={1}",
                                                            cbox_电子帐册号.SelectedValue, row["成品项号"]);
                            dtTemp = dataAccess.GetTable(strSQL, null);
                            if (dtTemp.Rows.Count > 0)
                            {
                                DataRow rowT = dtTemp.Rows[0];
                                if (IDValue != ((row["产品id"] == DBNull.Value ? 0 : Convert.ToInt64(row["产品id"])) + 
                                    (row["配件id"] == DBNull.Value ? 0 : Convert.ToInt64(row["配件id"]))))
                                {
                                    if (Numbers[Convert.ToInt64(row["成品项号"])] == 0)
                                    {
                                        row["版本号"] = (rowT["版本号"] == DBNull.Value ? 0 : Convert.ToInt64(rowT["版本号"])) + 1;
                                        Numbers[Convert.ToInt64(row["成品项号"])] = Convert.ToInt64(rowT["版本号"]) + 1;
                                    }
                                    else
                                    {
                                        row["版本号"] = Numbers[Convert.ToInt64(row["成品项号"])] + 1;
                                        Numbers[Convert.ToInt64(row["成品项号"])] = Numbers[Convert.ToInt64(row["成品项号"])] + 1;
                                    }
                                }
                                else
                                {
                                    if (Numbers[Convert.ToInt64(row["成品项号"])] == 0)
                                    {
                                        row["版本号"] = (rowT["版本号"] == DBNull.Value ? 0 : Convert.ToInt64(rowT["版本号"]));
                                        Numbers[Convert.ToInt64(row["成品项号"])] = Convert.ToInt64(rowT["版本号"]);
                                    }
                                    else
                                    {
                                        row["版本号"] = Numbers[Convert.ToInt64(row["成品项号"])];
                                        Numbers[Convert.ToInt64(row["成品项号"])] = Numbers[Convert.ToInt64(row["成品项号"])];
                                    }
                                }
                                /*
                                 */
                            }
                            else
                            {
                                row["版本号"] = 1;
                            }
                        }
                    }
                    #endregion

                    #region 处理内部版本号
                    if (row["内部版本号"] == DBNull.Value || row["内部版本号"].ToString() == "")
                    {
                        //如果成品项号为空时，不做版本号处理
                        if (row["成品项号"] == DBNull.Value || row["成品项号"].ToString() == "")
                        {
                        }
                        else
                        {
                            strSQL = string.Format(@"SELECT max(报关订单明细表.内部版本号) as 内部版本号 FROM 报关订单表 LEFT OUTER JOIN 报关订单明细表 ON 报关订单表.订单id =报关订单明细表.订单id 
                                                        where 报关订单明细表.版本号 is not null and 报关订单表.手册编号='{0}' and 报关订单明细表.成品项号={1}",
                                                            cbox_电子帐册号.SelectedValue, row["成品项号"]);
                            dtTemp = dataAccess.GetTable(strSQL, null);
                            if (dtTemp.Rows.Count > 0)
                            {
                                DataRow rowT = dtTemp.Rows[0];
                                if (InNumbers[Convert.ToInt64(row["成品项号"])] == 0)
                                {
                                    row["内部版本号"] = (rowT["内部版本号"] == DBNull.Value ? 0 : Convert.ToInt64(rowT["内部版本号"])) + 1;
                                    InNumbers[Convert.ToInt64(row["成品项号"])] = Convert.ToInt64(rowT["内部版本号"]) + 1;
                                }
                                else
                                {
                                    row["内部版本号"] = InNumbers[Convert.ToInt64(row["成品项号"])];
                                }
                            }
                            else
                            {
                                row["内部版本号"] = 1;
                            }
                        }
                    }
                    #endregion

                    IDValue = ((row["产品id"] == DBNull.Value ? 0 : Convert.ToInt64(row["产品id"])) +
                                    (row["配件id"] == DBNull.Value ? 0 : Convert.ToInt64(row["配件id"])));
                }
                dataAccess.Close();
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
                case "制造通知单号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["制造通知单号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["客人型号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate制造通知单号(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["客人型号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["制造通知单号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate制造通知单号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "客人型号"://跳转到"订单数量"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["客人型号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["订单数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate客人型号(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["订单数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["客人型号"].Value ==null || dgv.CurrentRow.Cells["客人型号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate客人型号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "优丽型号"://跳转到"订单数量"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["优丽型号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["订单数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate优丽型号(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();      
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["订单数量", cell.RowIndex];
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
                case "颜色":  //跳转到"订单数量"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["订单数量", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "订单数量":   //跳转到"箱数"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["订单数量"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["箱数", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate订单数量(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["箱数", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["订单数量"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate订单数量(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "箱数":   //跳转到"型号"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["箱数"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["型号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate箱数(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["型号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["箱数"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate箱数(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "型号":   //跳转到"生产数量"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["型号"].Value.ToString() == cell.EditedFormattedValue.ToString() && dgv.CurrentRow.Cells["型号"].Value.ToString().Length > 0)
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["生产数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate型号(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["生产数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["型号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate型号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "生产数量":   //跳转到"实际总重"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["生产数量"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["实际总重", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate生产数量(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["实际总重", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["生产数量"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate生产数量(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "实际总重":   //跳转到"成品项号" 
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["实际总重"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["成品项号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate实际总重(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["成品项号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["实际总重"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate实际总重(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "成品项号":   //跳转到"成品名称及商编"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["成品项号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["申报单位", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate成品项号(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["申报单位", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["成品项号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate成品项号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "成品名称及商编":   //跳转到"成品规格型号"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["成品规格型号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "成品规格型号":   //跳转到"申报单位"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["成品规格型号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["申报单位", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate成品规格型号(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["申报单位", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["成品规格型号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate成品规格型号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "申报单位":   //跳转到"法定单位"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["申报单位"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["法定单位", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate申报单位(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["法定单位", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["申报单位"].Value != null && dgv.CurrentRow.Cells["申报单位"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate申报单位(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "法定单位":   //跳转到"变更规格型号"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["变更规格型号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "变更规格型号":   //跳转到"订单备注"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["订单备注", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "订单备注":   //跳转到"订单号码"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        validate订单备注(dgv, cell);
                        (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                    }
                    #endregion
                    break;
            }
        }
        private bool validate制造通知单号(myDataGridView dgv, DataGridViewCell cell)
        {
            if (!string.IsNullOrEmpty(cell.EditedFormattedValue.ToString()))
            {
                string strSQL = string.Format(@"select 制造通知单号,客户代码,客户名称,出货日期,录入日期,制造通知单id from 报关制造通知单表 where 制造通知单号 like '%{0}%'",
                               StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                DataTable dttabArticle = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dttabArticle.Rows.Count == 0)
                {
                    SysMessage.InformationMsg("此制造通知单不存在！");
                    dgv.CurrentCell = cell;
                    return false;
                }
                else if (dttabArticle.Rows.Count == 1)
                {
                    dgv.Rows[cell.RowIndex].Cells["制造通知单号"].Value = dttabArticle.Rows[0]["制造通知单号"];
                    dgv.Rows[cell.RowIndex].Cells["制造通知单id"].Value = dttabArticle.Rows[0]["制造通知单id"];
                    cell.Value = dttabArticle.Rows[0]["制造通知单号"];
                    return true;
                }
                else if (dttabArticle.Rows.Count > 1)
                {
                    FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                    formSelect.strFormText = "选择客户型号";
                    formSelect.dtData = dttabArticle;
                    if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        dgv.Rows[cell.RowIndex].Cells["制造通知单号"].Value = formSelect.returnRow["制造通知单号"];
                        dgv.Rows[cell.RowIndex].Cells["制造通知单id"].Value = formSelect.returnRow["制造通知单id"];
                        cell.Value = formSelect.returnRow["制造通知单号"];
                        return true;
                    }
                    else
                    {
                        dgv.CurrentCell = cell;
                        return false;
                    }
                }
            }
            else
            {
                dgv.Rows[cell.RowIndex].Cells["制造通知单号"].Value = DBNull.Value;
                dgv.Rows[cell.RowIndex].Cells["制造通知单id"].Value = DBNull.Value;
                return true;
            }
            return true;
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
                    #region 如果制造通知单id为空时
                    if (dgv.Rows[cell.RowIndex].Cells["制造通知单id"].Value == DBNull.Value || Convert.ToInt64(dgv.Rows[cell.RowIndex].Cells["制造通知单id"].Value) == 0)
                    {
                        string strSQL = string.Format(@"select SecondField as 客人型号,KeyField as 优丽型号,colors as 颜色,unit as 单位,cust as 客户代码 
                                                                from tabArticle where cust={0} and SecondField like '%{1}%'",
                                        StringTools.SqlQ(txt_客户代码.Text.Trim()), StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));
                        IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                        dataAccess.Open();
                        DataTable dttabArticle = dataAccess.GetTable(strSQL, null);
                        dataAccess.Close();
                        if (dttabArticle.Rows.Count == 0)
                        {
                            SysMessage.InformationMsg("此客户型号不存在！");
                            return false;
                        }
                        else if (dttabArticle.Rows.Count == 1)
                        {
                            cell.Value = dttabArticle.Rows[0]["客人型号"];
                            dgv.Rows[cell.RowIndex].Cells["客人型号"].Value = dttabArticle.Rows[0]["客人型号"];
                            dgv.Rows[cell.RowIndex].Cells["优丽型号"].Value = dttabArticle.Rows[0]["优丽型号"];
                            dgv.Rows[cell.RowIndex].Cells["颜色"].Value = dttabArticle.Rows[0]["颜色"];
                            dgv.Rows[cell.RowIndex].Cells["单位"].Value = dttabArticle.Rows[0]["单位"];
                        }
                        else if (dttabArticle.Rows.Count > 1)
                        {
                            FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                            formSelect.strFormText = "选择客户型号";
                            formSelect.dtData = dttabArticle;
                            if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                cell.Value = formSelect.returnRow["客人型号"];
                                dgv.Rows[cell.RowIndex].Cells["客人型号"].Value = formSelect.returnRow["客人型号"];
                                dgv.Rows[cell.RowIndex].Cells["优丽型号"].Value = formSelect.returnRow["优丽型号"];
                                dgv.Rows[cell.RowIndex].Cells["颜色"].Value = formSelect.returnRow["颜色"];
                                dgv.Rows[cell.RowIndex].Cells["单位"].Value = formSelect.returnRow["单位"];
                            }
                            else
                            {
                                dgv.CurrentCell = cell;
                                return false;
                            }
                        }
                    }
                    #endregion
                    #region 如果制造通知单id不为空时
                    else
                    {
                        string strSQL = string.Format(@"select DN.制造通知单明细表id, DN.客人型号,DN.优丽型号,DN.颜色,DN.订单数量,DN.单位,DN.箱数,DN.产品id, DN.配件id, 
                                                                isnull(C.产品型号, P.配件型号) as 型号, DN.生产数量,DN.订单备注,
                                                                case when c.产品id>0 then C.实际总重 else P.实际总重 end as 实际总重,DN.成品项号,DN.成品名称及商编,
                                                                DN.成品规格型号,DN.申报单位,DN.法定单位,DN.变更规格型号,isnull(A.单耗,0)+isnull(B.单耗,0) as 单耗,DN.订单备注
                                                        from 报关制造通知单明细表 DN left outer join 产品资料表 C on C.产品id = DN.产品id left outer join 配件资料表 P on P.配件id = DN.配件id 
                                                                left outer join (SELECT 制造通知单id, 制造通知单明细表id,SUM(单耗*1000) AS 单耗 
                                                                                        From 产品配件改样报关前材料明细表 GROUP BY  制造通知单id, 制造通知单明细表id)  A 
                                                                                        on DN.制造通知单id = A.制造通知单id AND DN.制造通知单明细表id = A.制造通知单明细表id 
                                                                left outer join (SELECT 制造通知单id, 制造通知单明细表id,SUM(数量*1000)  AS 单耗 
                                                                                        From 产品配件改样报关前材料表 GROUP BY  制造通知单id, 制造通知单明细表id)  B 
                                                                                        on DN.制造通知单id =B.制造通知单id AND DN.制造通知单明细表id =B.制造通知单明细表id 
                                                                where DN.制造通知单id ={0} and DN.客人型号 like '%{1}%'",
                                                        dgv.Rows[cell.RowIndex].Cells["制造通知单id"].Value, StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));
                        IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                        dataAccess.Open();
                        DataTable dttabArticle = dataAccess.GetTable(strSQL, null);
                        dataAccess.Close();
                        if (dttabArticle.Rows.Count == 0)
                        {
                            SysMessage.InformationMsg("制造通知单中此客人型号不存在！");
                            dgv.CurrentCell = cell;
                            return false;
                        }
                        else if (dttabArticle.Rows.Count == 1)
                        {
                            dgv.Rows[cell.RowIndex].Cells["客人型号"].Value = dttabArticle.Rows[0]["客人型号"];
                            dgv.Rows[cell.RowIndex].Cells["优丽型号"].Value = dttabArticle.Rows[0]["优丽型号"];
                            dgv.Rows[cell.RowIndex].Cells["颜色"].Value = dttabArticle.Rows[0]["颜色"];
                            dgv.Rows[cell.RowIndex].Cells["单位"].Value = dttabArticle.Rows[0]["单位"];
                            dgv.Rows[cell.RowIndex].Cells["型号"].Value = dttabArticle.Rows[0]["型号"];
                            dgv.Rows[cell.RowIndex].Cells["产品id"].Value = dttabArticle.Rows[0]["产品id"];
                            dgv.Rows[cell.RowIndex].Cells["配件id"].Value = dttabArticle.Rows[0]["配件id"];
                            dgv.Rows[cell.RowIndex].Cells["订单备注"].Value = dttabArticle.Rows[0]["订单备注"];
                            dgv.Rows[cell.RowIndex].Cells["订单数量"].Value = dttabArticle.Rows[0]["订单数量"];
                            dgv.Rows[cell.RowIndex].Cells["生产数量"].Value = dttabArticle.Rows[0]["生产数量"];
                            dgv.Rows[cell.RowIndex].Cells["实际总重"].Value = dttabArticle.Rows[0]["实际总重"];
                            dgv.Rows[cell.RowIndex].Cells["成品规格型号"].Value = dttabArticle.Rows[0]["成品规格型号"];
                            dgv.Rows[cell.RowIndex].Cells["成品名称及商编"].Value = dttabArticle.Rows[0]["成品名称及商编"];
                            dgv.Rows[cell.RowIndex].Cells["申报单位"].Value = dttabArticle.Rows[0]["申报单位"];
                            dgv.Rows[cell.RowIndex].Cells["法定单位"].Value = dttabArticle.Rows[0]["法定单位"];
                            dgv.Rows[cell.RowIndex].Cells["成品项号"].Value = dttabArticle.Rows[0]["成品项号"];
                            dgv.Rows[cell.RowIndex].Cells["成品规格型号"].Value = dttabArticle.Rows[0]["成品规格型号"];
                            dgv.Rows[cell.RowIndex].Cells["变更规格型号"].Value = dttabArticle.Rows[0]["变更规格型号"];
                        }
                        else if (dttabArticle.Rows.Count > 1)
                        {
                            FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                            formSelect.strFormText = "选择客户型号";
                            formSelect.dtData = dttabArticle;
                            if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                dgv.Rows[cell.RowIndex].Cells["客人型号"].Value = dttabArticle.Rows[0]["客人型号"];
                                dgv.Rows[cell.RowIndex].Cells["优丽型号"].Value = dttabArticle.Rows[0]["优丽型号"];
                                dgv.Rows[cell.RowIndex].Cells["颜色"].Value = dttabArticle.Rows[0]["颜色"];
                                dgv.Rows[cell.RowIndex].Cells["单位"].Value = dttabArticle.Rows[0]["单位"];
                                dgv.Rows[cell.RowIndex].Cells["型号"].Value = dttabArticle.Rows[0]["型号"];
                                dgv.Rows[cell.RowIndex].Cells["产品id"].Value = dttabArticle.Rows[0]["产品id"];
                                dgv.Rows[cell.RowIndex].Cells["配件id"].Value = dttabArticle.Rows[0]["配件id"];
                                dgv.Rows[cell.RowIndex].Cells["订单备注"].Value = dttabArticle.Rows[0]["订单备注"];
                                dgv.Rows[cell.RowIndex].Cells["订单数量"].Value = dttabArticle.Rows[0]["订单数量"];
                                dgv.Rows[cell.RowIndex].Cells["生产数量"].Value = dttabArticle.Rows[0]["生产数量"];
                                dgv.Rows[cell.RowIndex].Cells["实际总重"].Value = dttabArticle.Rows[0]["实际总重"];
                                dgv.Rows[cell.RowIndex].Cells["成品规格型号"].Value = dttabArticle.Rows[0]["成品规格型号"];
                                dgv.Rows[cell.RowIndex].Cells["成品名称及商编"].Value = dttabArticle.Rows[0]["成品名称及商编"];
                                dgv.Rows[cell.RowIndex].Cells["申报单位"].Value = dttabArticle.Rows[0]["申报单位"];
                                dgv.Rows[cell.RowIndex].Cells["法定单位"].Value = dttabArticle.Rows[0]["法定单位"];
                                dgv.Rows[cell.RowIndex].Cells["成品项号"].Value = dttabArticle.Rows[0]["成品项号"];
                                dgv.Rows[cell.RowIndex].Cells["成品规格型号"].Value = dttabArticle.Rows[0]["成品规格型号"];
                                dgv.Rows[cell.RowIndex].Cells["变更规格型号"].Value = dttabArticle.Rows[0]["变更规格型号"];
                            }
                            else
                            {
                                dgv.CurrentCell = cell;
                                return false;
                            }
                        }
                    }
                    #endregion
                }
            }
            return true;
        }
        private bool validate优丽型号(myDataGridView dgv, DataGridViewCell cell)
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
                #region 如果制造通知单id为空时
                if (dgv.Rows[cell.RowIndex].Cells["制造通知单id"].Value == DBNull.Value || Convert.ToInt64(dgv.Rows[cell.RowIndex].Cells["制造通知单id"].Value) == 0)
                {
                    string strSQL = string.Format(@"select SecondField as 客人型号,KeyField as 优丽型号,colors as 颜色,unit as 单位,cust as 客户代码 
                                                    from tabArticle where cust={0} and KeyField like '%{1}%'",
                                    StringTools.SqlQ(txt_客户代码.Text.Trim()), StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    DataTable dttabArticle = dataAccess.GetTable(strSQL, null);
                    dataAccess.Close();
                    if (dttabArticle.Rows.Count == 0)
                    {
                        SysMessage.InformationMsg("此客户型号不存在！");
                        dgv.CurrentCell = cell;
                        return false;
                    }
                    else if (dttabArticle.Rows.Count == 1)
                    {
                        dgv.Rows[cell.RowIndex].Cells["客人型号"].Value = dttabArticle.Rows[0]["客人型号"];
                        dgv.Rows[cell.RowIndex].Cells["优丽型号"].Value = dttabArticle.Rows[0]["优丽型号"];
                        dgv.Rows[cell.RowIndex].Cells["颜色"].Value = dttabArticle.Rows[0]["颜色"];
                        dgv.Rows[cell.RowIndex].Cells["单位"].Value = dttabArticle.Rows[0]["单位"];
                    }
                    else if (dttabArticle.Rows.Count > 1)
                    {
                        FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                        formSelect.strFormText = "选择客户型号";
                        formSelect.dtData = dttabArticle;
                        if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            dgv.Rows[cell.RowIndex].Cells["客人型号"].Value = formSelect.returnRow["客人型号"];
                            dgv.Rows[cell.RowIndex].Cells["优丽型号"].Value = formSelect.returnRow["优丽型号"];
                            dgv.Rows[cell.RowIndex].Cells["颜色"].Value = formSelect.returnRow["颜色"];
                            dgv.Rows[cell.RowIndex].Cells["单位"].Value = formSelect.returnRow["单位"];
                        }
                        else
                        {
                            dgv.CurrentCell = cell;
                            return false;
                        }
                    }
                }
                #endregion

                #region 如果制造通知单id不为空时
                else
                {
                    string strSQL = string.Format(@"select DN.制造通知单明细表id, DN.客人型号,DN.优丽型号,DN.颜色,DN.订单数量,DN.单位,DN.箱数,DN.产品id, DN.配件id, 
                                                            isnull(C.产品型号, P.配件型号) as 型号, DN.生产数量,DN.订单备注,
                                                            case when c.产品id>0 then C.实际总重 else P.实际总重 end as 实际总重,DN.成品项号,DN.成品名称及商编,
                                                            DN.成品规格型号,DN.申报单位,DN.法定单位,DN.变更规格型号,isnull(A.单耗,0)+isnull(B.单耗,0) as 单耗,DN.订单备注
                                                    from 报关制造通知单明细表 DN left outer join 产品资料表 C on C.产品id = DN.产品id left outer join 配件资料表 P on P.配件id = DN.配件id 
                                                    left outer join (SELECT 制造通知单id, 制造通知单明细表id,SUM(单耗*1000) AS 单耗 
                                                                    From 产品配件改样报关前材料明细表 GROUP BY  制造通知单id, 制造通知单明细表id)  A 
                                                                    on DN.制造通知单id = A.制造通知单id AND DN.制造通知单明细表id = A.制造通知单明细表id
                                                    left outer join (SELECT 制造通知单id, 制造通知单明细表id,SUM(数量*1000)  AS 单耗 
                                                                    From 产品配件改样报关前材料表 GROUP BY  制造通知单id, 制造通知单明细表id)  B 
                                                                    on DN.制造通知单id =B.制造通知单id AND DN.制造通知单明细表id =B.制造通知单明细表id 
                                                    where DN.制造通知单id ={0} and DN.优丽型号 like '%{1}%'",
                                                    dgv.Rows[cell.RowIndex].Cells["制造通知单id"].Value, StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    DataTable dttabArticle = dataAccess.GetTable(strSQL, null);
                    dataAccess.Close();
                    if (dttabArticle.Rows.Count == 0)
                    {
                        SysMessage.InformationMsg("制造通知单中此优丽型号不存在！");
                        dgv.CurrentCell = cell;
                        return false;
                    }
                    else if (dttabArticle.Rows.Count == 1)
                    {
                        dgv.Rows[cell.RowIndex].Cells["客人型号"].Value = dttabArticle.Rows[0]["客人型号"];
                        dgv.Rows[cell.RowIndex].Cells["优丽型号"].Value = dttabArticle.Rows[0]["优丽型号"];
                        dgv.Rows[cell.RowIndex].Cells["颜色"].Value = dttabArticle.Rows[0]["颜色"];
                        dgv.Rows[cell.RowIndex].Cells["单位"].Value = dttabArticle.Rows[0]["单位"];
                        dgv.Rows[cell.RowIndex].Cells["型号"].Value = dttabArticle.Rows[0]["型号"];
                        dgv.Rows[cell.RowIndex].Cells["产品id"].Value = dttabArticle.Rows[0]["产品id"];
                        dgv.Rows[cell.RowIndex].Cells["配件id"].Value = dttabArticle.Rows[0]["配件id"];
                        dgv.Rows[cell.RowIndex].Cells["订单备注"].Value = dttabArticle.Rows[0]["订单备注"];
                        dgv.Rows[cell.RowIndex].Cells["订单数量"].Value = dttabArticle.Rows[0]["订单数量"];
                        dgv.Rows[cell.RowIndex].Cells["生产数量"].Value = dttabArticle.Rows[0]["生产数量"];
                        dgv.Rows[cell.RowIndex].Cells["实际总重"].Value = dttabArticle.Rows[0]["实际总重"];
                        dgv.Rows[cell.RowIndex].Cells["成品规格型号"].Value = dttabArticle.Rows[0]["成品规格型号"];
                        dgv.Rows[cell.RowIndex].Cells["成品名称及商编"].Value = dttabArticle.Rows[0]["成品名称及商编"];
                        dgv.Rows[cell.RowIndex].Cells["申报单位"].Value = dttabArticle.Rows[0]["申报单位"];
                        dgv.Rows[cell.RowIndex].Cells["法定单位"].Value = dttabArticle.Rows[0]["法定单位"];
                        dgv.Rows[cell.RowIndex].Cells["成品项号"].Value = dttabArticle.Rows[0]["成品项号"];
                        dgv.Rows[cell.RowIndex].Cells["成品规格型号"].Value = dttabArticle.Rows[0]["成品规格型号"];
                        dgv.Rows[cell.RowIndex].Cells["变更规格型号"].Value = dttabArticle.Rows[0]["变更规格型号"];
                    }
                    else if (dttabArticle.Rows.Count > 1)
                    {
                        FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                        formSelect.strFormText = "选择客户型号";
                        formSelect.dtData = dttabArticle;
                        if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            dgv.Rows[cell.RowIndex].Cells["客人型号"].Value = dttabArticle.Rows[0]["客人型号"];
                            dgv.Rows[cell.RowIndex].Cells["优丽型号"].Value = dttabArticle.Rows[0]["优丽型号"];
                            dgv.Rows[cell.RowIndex].Cells["颜色"].Value = dttabArticle.Rows[0]["颜色"];
                            dgv.Rows[cell.RowIndex].Cells["单位"].Value = dttabArticle.Rows[0]["单位"];
                            dgv.Rows[cell.RowIndex].Cells["型号"].Value = dttabArticle.Rows[0]["型号"];
                            dgv.Rows[cell.RowIndex].Cells["产品id"].Value = dttabArticle.Rows[0]["产品id"];
                            dgv.Rows[cell.RowIndex].Cells["配件id"].Value = dttabArticle.Rows[0]["配件id"];
                            dgv.Rows[cell.RowIndex].Cells["订单备注"].Value = dttabArticle.Rows[0]["订单备注"];
                            dgv.Rows[cell.RowIndex].Cells["订单数量"].Value = dttabArticle.Rows[0]["订单数量"];
                            dgv.Rows[cell.RowIndex].Cells["生产数量"].Value = dttabArticle.Rows[0]["生产数量"];
                            dgv.Rows[cell.RowIndex].Cells["实际总重"].Value = dttabArticle.Rows[0]["实际总重"];
                            dgv.Rows[cell.RowIndex].Cells["成品规格型号"].Value = dttabArticle.Rows[0]["成品规格型号"];
                            dgv.Rows[cell.RowIndex].Cells["成品名称及商编"].Value = dttabArticle.Rows[0]["成品名称及商编"];
                            dgv.Rows[cell.RowIndex].Cells["申报单位"].Value = dttabArticle.Rows[0]["申报单位"];
                            dgv.Rows[cell.RowIndex].Cells["法定单位"].Value = dttabArticle.Rows[0]["法定单位"];
                            dgv.Rows[cell.RowIndex].Cells["成品项号"].Value = dttabArticle.Rows[0]["成品项号"];
                            dgv.Rows[cell.RowIndex].Cells["成品规格型号"].Value = dttabArticle.Rows[0]["成品规格型号"];
                            dgv.Rows[cell.RowIndex].Cells["变更规格型号"].Value = dttabArticle.Rows[0]["变更规格型号"];
                        }
                        else
                        {
                            dgv.CurrentCell = cell;
                            return false;
                        }
                    }
                }
                #endregion
            }
            return true;
        }
        private void validate订单数量(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["订单数量"].Value = DBNull.Value;
                dgv.Rows[cell.RowIndex].Cells["生产数量"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["订单数量"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                    dgv.Rows[cell.RowIndex].Cells["生产数量"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["订单数量"].Value = 0;
                    dgv.Rows[cell.RowIndex].Cells["生产数量"].Value = 0;
                }
            }
        }
        private void validate箱数(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["箱数"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["箱数"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["箱数"].Value = 0;
                }
            }
        }
        private bool validate型号(myDataGridView dgv, DataGridViewCell cell)
        {
            int 订单id = rowHead["订单id"] == DBNull.Value ? 0 : Convert.ToInt32(rowHead["订单id"]);
            int 订单明细表id = dgv.Rows[cell.RowIndex].Cells["订单明细表id"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgv.Rows[cell.RowIndex].Cells["订单明细表id"].Value);
            int 配件id = dgv.Rows[cell.RowIndex].Cells["配件id"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgv.Rows[cell.RowIndex].Cells["配件id"].Value);
            int 产品id = dgv.Rows[cell.RowIndex].Cells["产品id"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgv.Rows[cell.RowIndex].Cells["产品id"].Value);
            #region 判断生产型号是否存在
            string strSQL = string.Empty;
            strSQL = string.Format(@"select '产品' as 类别, 产品id as id, 产品型号 as 型号, 产品单位 as 单位, 产品类别 as 类, null as 组, 产品备注 as 备注, 除数,实际总重 From 产品资料表 where 产品型号 like '{0}%' 
                            Union All select '配件', 配件id, 配件型号, 'PCS', 'C', 配件组别, 配件备注, 1,实际总重  From 配件资料表 where 配件型号 like '%{0}%'",
                                            StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString().Trim().Length == 0 ? dgv.Rows[cell.RowIndex].Cells["优丽型号"].Value.ToString() : cell.EditedFormattedValue.ToString().Trim())); 
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            DataTable dt产品配件 = dataAccess.GetTable(strSQL, null);
            DataRow row产品配件 = null;
            if (dt产品配件.Rows.Count == 0)
            {
                SysMessage.InformationMsg("此产品或配件不存在！");
                dgv.CurrentCell = cell;
                return false;
            }
            else if (dt产品配件.Rows.Count == 1)
            {
                row产品配件 = dt产品配件.Rows[0];
            }
            else
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择生产型号";
                formSelect.dtData = dt产品配件;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    row产品配件 = formSelect.returnRow;
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            #endregion

            DataRow rowCurrent = (dgv.CurrentRow.DataBoundItem as DataRowView).Row;
            if (rowCurrent.RowState != DataRowState.Added && rowCurrent["型号",DataRowVersion.Original].ToString() != row产品配件["型号"].ToString())
            {
                if (配件id == 0)
                {
                    strSQL = string.Format("SELECT 订单id From 产品配件改样报关材料明细表 where 订单id ={0} and 订单明细表id ={1} and 产品id ={2}", 订单id, 订单明细表id, rowCurrent["产品id", DataRowVersion.Original]);
                    strSQL += Environment.NewLine + string.Format("SELECT 订单id From 产品配件改样报关材料表 where 订单id ={0} and 订单明细表id ={1} and 产品id ={2}", 订单id, 订单明细表id, rowCurrent["产品id", DataRowVersion.Original]);
                }
                else
                {
                    strSQL = string.Format("SELECT 订单id From 产品配件改样报关材料明细表 where 订单id ={0} and 订单明细表id ={1} and 配件id ={2}", 订单id, 订单明细表id, rowCurrent["配件id", DataRowVersion.Original]);
                    strSQL += Environment.NewLine + string.Format("SELECT 订单id From 产品配件改样报关材料表 where 订单id ={0} and 订单明细表id ={1} and 配件id ={2}", 订单id, 订单明细表id, rowCurrent["配件id", DataRowVersion.Original]);
                }
                DataSet ds = dataAccess.GetDataSet(strSQL, null);
                if ((ds.Tables[0].Rows.Count + ds.Tables[1].Rows.Count) > 0)
                {
                    SysMessage.InformationMsg("此产品已经生成材料明细，不能更改产品型号");
                    rowCurrent["型号"] = rowCurrent["型号", DataRowVersion.Original];
                    dgv.CurrentRow.Cells["型号"].Value = rowCurrent["型号", DataRowVersion.Original];
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            dgv.Rows[cell.RowIndex].Cells["型号"].Value = row产品配件["型号"];
            if (row产品配件["类别"].ToString() == "产品")
            {
                dgv.Rows[cell.RowIndex].Cells["产品id"].Value = row产品配件["id"];
                dgv.Rows[cell.RowIndex].Cells["配件id"].Value = DBNull.Value;
            }
            else
            {
                dgv.Rows[cell.RowIndex].Cells["产品id"].Value = DBNull.Value;
                dgv.Rows[cell.RowIndex].Cells["配件id"].Value = row产品配件["id"];
            }
            dgv.Rows[cell.RowIndex].Cells["订单备注"].Value = row产品配件["备注"];
            dgv.Rows[cell.RowIndex].Cells["实际总重"].Value = row产品配件["实际总重"];
            if (row产品配件["实际总重"] != DBNull.Value && Convert.ToDecimal(row产品配件["实际总重"]) > 0)
            {
                dgv.Rows[cell.RowIndex].Cells["成品规格型号"].Value = String.Format("{0:N1}", row产品配件["实际总重"]) + "G/个";
            }
            return true;
        }
        private void validate生产数量(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["生产数量"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["生产数量"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["生产数量"].Value = 0;
                }
            }
        }
        private void validate实际总重(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["实际总重"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());

                    if (dgv.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value != DBNull.Value
                         && Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value) < 0)
                    {
                        dgv["实际总重", cell.RowIndex].Value = DBNull.Value;
                        dgv["成品规格型号", cell.RowIndex].Value = DBNull.Value;
                        return;
                    }
                    else
                    {
                        dgv["实际总重", cell.RowIndex].Value = cell.EditedFormattedValue;
                    }
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["实际总重"].Value = 0;
                }

            }
            #region 单元格数据验证
            if (dgv["配件id", cell.RowIndex].Value != DBNull.Value)
            {
                if (dgv["配件id", cell.RowIndex].Value != DBNull.Value && Convert.ToInt32(dgv["配件id", cell.RowIndex].Value) > 0 && dgv.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value != DBNull.Value)
                {
                    string strSQL = string.Format("update 配件资料表 set 实际总重={0} where 配件id={1}",
                        cell.EditedFormattedValue, dgv["配件id", cell.RowIndex].Value);
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    int i = dataAccess.ExecuteNonQuery(strSQL, null);
                    dataAccess.Close();
                }
            }
            else
            {
                if (dgv["产品id", cell.RowIndex].Value != DBNull.Value && Convert.ToInt32(dgv["产品id", cell.RowIndex].Value) > 0 && dgv.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value != DBNull.Value)
                {
                    string strSQL = string.Format("update 产品资料表 set 实际总重={0} where 产品id={1}",
                        cell.EditedFormattedValue, dgv["产品id", cell.RowIndex].Value);
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    int i = dataAccess.ExecuteNonQuery(strSQL, null);
                    dataAccess.Close();
                }
            }
            string 申报单位 = dgv["申报单位", cell.RowIndex].Value.ToString();
            if (dgv["实际总重", cell.RowIndex].Value != DBNull.Value)
            {
                //dgv["成品规格型号", cell.RowIndex].Value = dgv["实际总重", cell.RowIndex].Value + "G/个";
                dgv["成品规格型号", cell.RowIndex].Value = string.Format("{0}G/{1}", dgv["实际总重", cell.RowIndex].Value, 申报单位 == string.Empty ? "个" : 申报单位);
            }
            else
            {
                //dgv["成品规格型号", cell.RowIndex].Value = "G/个";
                dgv["成品规格型号", cell.RowIndex].Value = string.Format("G/{0}", 申报单位 == string.Empty ? "个" : 申报单位);
            }
            #endregion
        }
        private void validate成品项号(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cbox_电子帐册号.Text != "" && cell.EditedFormattedValue != DBNull.Value && cell.EditedFormattedValue.ToString().Trim().Length > 0)   // && dgv["成品项号", cell.RowIndex].Value != DBNull.Value
            {
                string strSQL = string.Format(@"select 商品编号,品名规格型号,单位 from 出口成品表,手册资料表 
                                                            where  出口成品表.手册id=手册资料表.手册id and 手册资料表.手册编号='{0}' and 序号={1}",
                                                cbox_电子帐册号.Text, cell.EditedFormattedValue);
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                DataTable dtQueryList = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtQueryList.Rows.Count == 0)
                {
                    SysMessage.InformationMsg("此成品项号不存在！");
                    dgv["成品名称及商编", cell.RowIndex].Value = DBNull.Value;
                    dgv["申报单位", cell.RowIndex].Value = DBNull.Value;
                    dgv["法定单位", cell.RowIndex].Value = DBNull.Value;
                    dgv["成品项号", cell.RowIndex].Value = DBNull.Value;
                }
                else
                {
                    DataRow rowTemp = dtQueryList.Rows[0];
                    dgv["成品项号", cell.RowIndex].Value = cell.EditedFormattedValue;
                    if (rowTemp["单位"] != DBNull.Value && rowTemp["单位"].ToString() != "")
                    {
                        dgv["申报单位", cell.RowIndex].Value = rowTemp["单位"];
                    }
                    else
                    {
                        dgv["申报单位", cell.RowIndex].Value = "个";
                    }
                    dgv["成品名称及商编", cell.RowIndex].Value = string.Format("{0}/{1}", rowTemp["品名规格型号"], rowTemp["商品编号"]);
                }
                string 申报单位 = dgv["申报单位", cell.RowIndex].Value.ToString();
                if (dgv["实际总重", cell.RowIndex].Value != DBNull.Value)
                {
                    dgv["成品规格型号", cell.RowIndex].Value = string.Format("{0}G/{1}", dgv["实际总重", cell.RowIndex].Value, 申报单位 == string.Empty ? "个" : 申报单位);
                }
                else
                {
                    dgv["成品规格型号", cell.RowIndex].Value = string.Format("G/{0}", 申报单位 == string.Empty ? "个" : 申报单位);
                }
                if (dgv["法定单位", cell.RowIndex].Value == DBNull.Value || dgv["法定单位", cell.RowIndex].Value.ToString() == "")
                {
                    dgv["法定单位", cell.RowIndex].Value = "千克";
                }
            }
        }
        private void validate成品规格型号(myDataGridView dgv, DataGridViewCell cell)
        {
            string 申报单位 = dgv["申报单位", cell.RowIndex].Value.ToString();
            if (dgv["实际总重", cell.RowIndex].Value != DBNull.Value)
            {
                //dgv["成品规格型号", cell.RowIndex].Value = dgv["实际总重", cell.RowIndex].Value + "G/个";
                dgv["成品规格型号", cell.RowIndex].Value = string.Format("{0}G/{1}", dgv["实际总重", cell.RowIndex].Value, 申报单位 == string.Empty ? "个" : 申报单位);
            }
            else
            {
                //dgv["成品规格型号", cell.RowIndex].Value = "G/个";
                dgv["成品规格型号", cell.RowIndex].Value = string.Format("G/{0}", 申报单位 == string.Empty ? "个" : 申报单位);
            }
        }
        private void validate申报单位(myDataGridView dgv, DataGridViewCell cell)
        {
            string 申报单位 = cell.EditedFormattedValue.ToString();
            dgv["申报单位", cell.RowIndex].Value = 申报单位;
            if (dgv["实际总重", cell.RowIndex].Value != DBNull.Value)
            {
                //dgv["成品规格型号", cell.RowIndex].Value = dgv["实际总重", cell.RowIndex].Value + "G/个";
                dgv["成品规格型号", cell.RowIndex].Value = string.Format("{0}G/{1}", dgv["实际总重", cell.RowIndex].Value, 申报单位 == string.Empty ? "个" : 申报单位);
            }
            else
            {
                //dgv["成品规格型号", cell.RowIndex].Value = "G/个";
                dgv["成品规格型号", cell.RowIndex].Value = string.Format("G/{0}", 申报单位 == string.Empty ? "个" : 申报单位);
            }
        }
        private void validate订单备注(myDataGridView dgv, DataGridViewCell cell)
        {
            dgv["订单备注", cell.RowIndex].Value = cell.EditedFormattedValue;
            //如果当前行的客人型号为空，则跳转到当前行的客人型号
            if (dgv.Rows[cell.RowIndex].Cells["制造通知单号"].Value == DBNull.Value
                || dgv.Rows[cell.RowIndex].Cells["制造通知单号"].Value.ToString().Trim() == "")
            {
                dgv.CurrentCell = dgv["制造通知单号", cell.RowIndex];
            }
            else
            {
                //否则跳转到下一行的客人型号，如果是最后一行，则新增一行
                if (cell.RowIndex == dgv.Rows.Count - 1)
                {
                    dtDetailsAddRow();
                    dgv.CurrentCell = dgv["制造通知单号", cell.RowIndex + 1];
                }
                else
                {
                    dgv.CurrentCell = dgv["制造通知单号", cell.RowIndex + 1];
                }
            }
        }
        public override void dataGridViewDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            base.dataGridViewDetail_DataError(sender, e);
            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "订单数量" || colName == "箱数" || colName == "生产数量" || colName == "实际总重")
                e.Cancel = false;
        }

        /// <summary>
        /// 明细GRID增加一条新行
        /// </summary>
        public override void dtDetailsAddRow()
        {
            DataRow newRow = dtDetails.NewRow();
            newRow["订单数量"] = 0;
            newRow["申报单位"] = "个";
            newRow["法定单位"] = "千克";
            dtDetails.Rows.Add(newRow);
            setTool1Enabled();
        }

        #endregion
    }
}
