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
using UniqueDeclarationBaseForm.Controls;
using UniqueDeclarationBaseForm;

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
        /// 是否触发下拉控件的变化事件
        /// </summary>
        private bool bcbox_SelectedIndexChanged = false;
        /// <summary>
        /// 是否触发录入日期事件
        /// </summary>
        private bool bdatetime_录入日期_ValueChanged = false;
        #endregion

        #region 窗体事件
        public override void FormBaseInput_Load(object sender, EventArgs e)
        {
            base.gstrDetailFirstField = "料件项号";
            base.FormBaseInput_Load(sender, e);
        }
        #endregion
        
        #region 方法
        /// <summary>
        /// 出口成品GRID初始化
        /// </summary>
        public override void InitGrid()
        {
            // 
            // 报关产品组成明细表id
            // 
            DataGridViewTextBoxColumn 报关产品组成明细表id = new DataGridViewTextBoxColumn();
            报关产品组成明细表id.DataPropertyName = "报关产品组成明细表id";
            报关产品组成明细表id.HeaderText = "报关产品组成明细表id";
            报关产品组成明细表id.Name = "报关产品组成明细表id";
            报关产品组成明细表id.ReadOnly = true;
            报关产品组成明细表id.Visible = false;
            // 
            // 料件id
            // 
            DataGridViewTextBoxColumn 料件id = new DataGridViewTextBoxColumn();
            料件id.DataPropertyName = "料件id";
            料件id.HeaderText = "料件id";
            料件id.Name = "料件id";
            料件id.ReadOnly = true;
            料件id.Visible = false;
            // 
            // 料件id
            // 
            DataGridViewTextBoxColumn 报关产品表id = new DataGridViewTextBoxColumn();
            报关产品表id.DataPropertyName = "报关产品表id";
            报关产品表id.HeaderText = "报关产品表id";
            报关产品表id.Name = "报关产品表id";
            报关产品表id.ReadOnly = true;
            报关产品表id.Visible = false;
            // 
            // 料件项号
            // 
            DataGridViewTextBoxColumn 料件项号 = new DataGridViewTextBoxColumn();
            料件项号.DataPropertyName = "料件项号";
            料件项号.HeaderText = "料件项号";
            料件项号.Name = "料件项号";
            料件项号.Width = 80;
            料件项号.DisplayIndex = 0;
            料件项号.Visible = true;
            料件项号.ReadOnly = false;
            // 
            // 料件名称及商编
            // 
            DataGridViewTextBoxColumn 料件名称及商编 = new DataGridViewTextBoxColumn();
            料件名称及商编.DataPropertyName = "料件名称及商编";
            料件名称及商编.HeaderText = "料件名称及商编";
            料件名称及商编.Name = "料件名称及商编";
            料件名称及商编.Width = 150;
            料件名称及商编.DisplayIndex = 1;
            料件名称及商编.Visible = true;
            料件名称及商编.ReadOnly = false;
            // 
            // 料件规格型号
            // 
            DataGridViewTextBoxColumn 料件规格型号 = new DataGridViewTextBoxColumn();
            料件规格型号.DataPropertyName = "料件规格型号";
            料件规格型号.HeaderText = "料件规格型号";
            料件规格型号.Name = "料件规格型号";
            料件规格型号.Width = 200;
            料件规格型号.DisplayIndex = 2;
            料件规格型号.Visible = true;
            料件规格型号.ReadOnly = false;
            // 
            // 料件规格型号
            // 
            DataGridViewTextBoxColumn 明细表申报单位 = new DataGridViewTextBoxColumn();
            明细表申报单位.DataPropertyName = "明细表申报单位";
            明细表申报单位.HeaderText = "申报单位";
            明细表申报单位.Name = "明细表申报单位";
            明细表申报单位.Width = 80;
            明细表申报单位.DisplayIndex = 3;
            明细表申报单位.Visible = true;
            明细表申报单位.ReadOnly = false;
            // 
            // 明细表法定单位
            // 
            DataGridViewTextBoxColumn 明细表法定单位 = new DataGridViewTextBoxColumn();
            明细表法定单位.DataPropertyName = "明细表法定单位";
            明细表法定单位.HeaderText = "法定单位";
            明细表法定单位.Name = "明细表法定单位";
            明细表法定单位.Width = 80;
            明细表法定单位.DisplayIndex = 4;
            明细表法定单位.Visible = true;
            明细表法定单位.ReadOnly = false;
            // 
            // 备案净耗单位
            // 
            DataGridViewTextBoxColumn 备案净耗单位 = new DataGridViewTextBoxColumn();
            备案净耗单位.DataPropertyName = "备案净耗单位";
            备案净耗单位.HeaderText = "备案净耗单位";
            备案净耗单位.Name = "备案净耗单位";
            备案净耗单位.Width = 120;
            备案净耗单位.DisplayIndex = 5;
            备案净耗单位.Visible = true;
            备案净耗单位.ReadOnly = false;
            // 
            // 备案损耗
            // 
            DataGridViewTextBoxColumn 备案损耗 = new DataGridViewTextBoxColumn();
            备案损耗.DataPropertyName = "备案损耗";
            备案损耗.HeaderText = "备案损耗";
            备案损耗.Name = "备案损耗";
            备案损耗.Width = 80;
            备案损耗.DisplayIndex = 6;
            备案损耗.Visible = true;
            备案损耗.ReadOnly = false;
            // 
            // 变更净耗单位
            // 
            DataGridViewTextBoxColumn 变更净耗单位 = new DataGridViewTextBoxColumn();
            变更净耗单位.DataPropertyName = "变更净耗单位";
            变更净耗单位.HeaderText = "变更净耗单位";
            变更净耗单位.Name = "变更净耗单位";
            变更净耗单位.Width = 120;
            变更净耗单位.DisplayIndex = 7;
            变更净耗单位.Visible = true;
            变更净耗单位.ReadOnly = false;
            // 
            // 变更损耗
            // 
            DataGridViewTextBoxColumn 变更损耗 = new DataGridViewTextBoxColumn();
            变更损耗.DataPropertyName = "变更损耗";
            变更损耗.HeaderText = "变更损耗";
            变更损耗.Name = "变更损耗";
            变更损耗.Width = 80;
            变更损耗.DisplayIndex = 8;
            变更损耗.Visible = true;
            变更损耗.ReadOnly = false;
            // 
            // 归并前料件序号
            // 
            DataGridViewTextBoxColumn 归并前料件序号 = new DataGridViewTextBoxColumn();
            归并前料件序号.DataPropertyName = "归并前料件序号";
            归并前料件序号.HeaderText = "归并前料件序号";
            归并前料件序号.Name = "归并前料件序号";
            归并前料件序号.Width = 120;
            归并前料件序号.DisplayIndex = 9;
            归并前料件序号.Visible = true;
            归并前料件序号.ReadOnly = false;
            // 
            // 归并前净耗单位
            // 
            DataGridViewTextBoxColumn 归并前净耗单位 = new DataGridViewTextBoxColumn();
            归并前净耗单位.DataPropertyName = "归并前净耗单位";
            归并前净耗单位.HeaderText = "归并前净耗单位";
            归并前净耗单位.Name = "归并前净耗单位";
            归并前净耗单位.Width = 120;
            归并前净耗单位.DisplayIndex = 10;
            归并前净耗单位.Visible = true;
            归并前净耗单位.ReadOnly = false;
            // 
            // 归并前净耗单位
            // 
            DataGridViewTextBoxColumn 归并前损耗 = new DataGridViewTextBoxColumn();
            归并前损耗.DataPropertyName = "归并前损耗";
            归并前损耗.HeaderText = "归并前损耗";
            归并前损耗.Name = "归并前损耗";
            归并前损耗.Width = 100;
            归并前损耗.DisplayIndex = 11;
            归并前损耗.Visible = true;
            归并前损耗.ReadOnly = false;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{报关产品组成明细表id,料件id,报关产品表id,料件项号,料件名称及商编,
                        料件规格型号,明细表申报单位,明细表法定单位,备案净耗单位,备案损耗,变更净耗单位, 变更损耗,归并前料件序号,归并前净耗单位,归并前损耗});
        }
        /// <summary>
        /// 初始化界面上某些控件的初始值
        /// </summary>
        public override void InitControlData()
        {
            bcbox_SelectedIndexChanged = false;
            IDataAccess dataAccessUniquegrade = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccessUniquegrade.Open();
            //int id = Convert.ToInt32(dataAccessUniquegrade.GetTable(string.Format("SELECT 手册id FROM 手册资料表 where 手册编号='{0}'", ConfigurationManager.AppSettings["defaultManualCode"].ToString()), null).Rows[0]["手册id"]);
            object id = dataAccessUniquegrade.GetTable(string.Format("SELECT 手册id FROM 手册资料表 where 手册编号='{0}'", ConfigurationManager.AppSettings["defaultManualCode"].ToString()), null).Rows[0]["手册id"];
            dataAccessUniquegrade.Close();
            this.cbox_手册id.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade,
                "SELECT 手册id,手册编号 FROM 手册资料表 ORDER BY 有效期限 DESC", "手册id", "手册编号", id);
            bcbox_SelectedIndexChanged = true;
        }
        /// <summary>
        /// 加载表头数据
        /// </summary>
        public override void LoadDataSourceHead()
        {
            string strSQL = string.Format("select * from 报关产品表 where 报关产品表id={0}", giOrderID);
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
        public override void LoadDataSourceDetails()
        {
            string strSQL = string.Format("SELECT * FROM 报关产品组成明细表 WHERE 报关产品表id ={0}", giOrderID);
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
                            if (row["料件名称及商编"] != DBNull.Value || row["料件名称及商编"].ToString().Trim().Length > 0)
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
        /// 保存数据，并返回是否保存成功
        /// <param name="bShowSuccessMsg">保存成功时是否弹出提示信息</param>
        /// </summary>
        public override bool Save(bool bShowSuccessMsg)
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
                            if (row["料件名称及商编"] == DBNull.Value || row["料件名称及商编"].ToString().Trim().Length == 0) continue;
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

        #region 表头控件事件
        //文本控件值变化时验证
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            myTextBox txtBox = (myTextBox)sender;
            if (txtBox.Text.Trim().Length == 0) return;
            string fieldName = txtBox.Name.Replace("txt_", "");
            string strSQL = string.Empty;
            IDataAccess dataAccess = null;
            switch (fieldName)
            {
                case "配件型号":
                    #region 配件型号
                    if (rowHead.RowState == DataRowState.Added ||
                        (rowHead.RowState == DataRowState.Modified && rowHead["配件型号", DataRowVersion.Original].ToString() != txtBox.Text))
                    {
                        strSQL = string.Format("SELECT 配件id FROM 配件资料表 WHERE 配件型号 = {0}", StringTools.SqlQ(txtBox.Text));
                        dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                        dataAccess.Open();
                        DataTable dtManual = dataAccess.GetTable(strSQL.ToString(), null);
                        dataAccess.Close();
                        if (dtManual.Rows.Count > 0)
                        {
                            SysMessage.InformationMsg("此配件型号已存在，请重新输入！");
                            e.Cancel = true;
                            txtBox.Focus();
                        }
                    }
                    break;
                    #endregion
            }
        }
        private void txt_Validated(object sender, EventArgs e)
        {
            myTextBox txtBox = (myTextBox)sender;
            string fieldName = txtBox.Name.Replace("txt_", "");
            if (rowHead[fieldName].ToString() != txtBox.Text)
            {
                rowHead[fieldName] = txtBox.Text;
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
                rowHead[fieldName] = cbox.SelectedValue;
            }
        }
        private void datetime_录入日期_ValueChanged(object sender, EventArgs e)
        {
            if (!bdatetime_录入日期_ValueChanged) return;
            if (datetime_录入日期.Checked)
            {
                if (rowHead["录入日期"] == DBNull.Value || Convert.ToDateTime(rowHead["录入日期"]) != datetime_录入日期.Value)
                {
                    rowHead["录入日期"] = datetime_录入日期.Value;
                }
            }
            else
            {
                if (rowHead["录入日期"] != DBNull.Value)
                {
                    rowHead["录入日期"] = DBNull.Value;
                }
            }
        }
        /// <summary>
        /// 填充表头数据到控件上
        /// </summary>
        /// <param name="row">来源数据</param>
        private void fillControl(DataRow row)
        {
            if (row.Table.Columns.Contains("手册id"))
            {
                cbox_手册id.SelectedValue = Convert.ToInt32(row["手册id"]);
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
                case "料件项号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["料件项号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["料件名称及商编", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate料件项号(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["料件名称及商编", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["料件项号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate料件项号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "料件名称及商编":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["料件名称及商编"].Value.ToString() == cell.EditedFormattedValue.ToString() && cell.EditedFormattedValue.ToString().ToString().Trim()!="")
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["料件规格型号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate料件名称及商编(dgv, cell))
                        {
                            //dtDetails.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["料件规格型号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["料件名称及商编"].Value.ToString() != cell.EditedFormattedValue.ToString() || cell.EditedFormattedValue.ToString().ToString().Trim()=="")
                        {
                            validate料件名称及商编(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "料件规格型号": 
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["明细表申报单位", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "明细表申报单位":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["明细表法定单位", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "明细表法定单位":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["备案净耗单位", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "备案净耗单位":   
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["备案净耗单位"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备案损耗", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate备案净耗单位(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备案损耗", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["备案净耗单位"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate备案净耗单位(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "备案损耗":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["备案损耗"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["变更净耗单位", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate备案损耗(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["变更净耗单位", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["备案损耗"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate备案损耗(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "变更净耗单位":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["变更净耗单位"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["变更损耗", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate变更净耗单位(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["变更损耗", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["变更净耗单位"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate变更净耗单位(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "变更损耗": 
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["变更损耗"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["归并前料件序号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate变更损耗(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["归并前料件序号", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["变更损耗"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate变更损耗(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "归并前料件序号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["归并前净耗单位", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "归并前净耗单位":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["归并前损耗", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "归并前损耗":   
                    #region CELL回车跳转
                    validate归并前损耗(dgv, cell);
                    #endregion
                    break;
                
            }
        }

        private bool validate料件名称及商编(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(cell.EditedFormattedValue.ToString()))
            {
                strSQL = string.Format("select 进口料件表.序号,进口料件表.商品编号,进口料件表.品名规格型号 from 进口料件表,手册资料表 where 进口料件表.手册id=手册资料表.手册id and 手册资料表.手册编号='{0}'  and 进口料件表.品名规格型号 like '%{1}%' order by 进口料件id desc", cbox_手册id.Text, StringTools.SqlLikeQ(cell.EditedFormattedValue.ToString()));
            }
            else
            {
                strSQL = string.Format("select 进口料件表.序号,进口料件表.商品编号,进口料件表.品名规格型号 from 进口料件表,手册资料表 where 进口料件表.手册id=手册资料表.手册id and 手册资料表.手册编号='{0}' order by 进口料件id desc", cbox_手册id.Text);
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dt进口料件表 = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dt进口料件表.Rows.Count == 1)
            {
                string 料件名称及商编 = string.Empty;
                string 料件规格型号 = string.Empty;
                if (dt进口料件表.Rows[0]["品名规格型号"].ToString().Trim().Length > 0)
                {
                    string[] texts = dt进口料件表.Rows[0]["品名规格型号"].ToString().Trim().Split('/');
                    料件名称及商编 = texts[0];
                    if (texts.Length > 1)
                    {
                        料件规格型号 = texts[texts.Length-1];
                    }
                }
                cell.Value = 料件名称及商编;
                dgv.Rows[cell.RowIndex].Cells["料件项号"].Value = dt进口料件表.Rows[0]["序号"];
                dgv.Rows[cell.RowIndex].Cells["料件规格型号"].Value = 料件规格型号;
                dgv.Rows[cell.RowIndex].Cells["明细表申报单位"].Value = "千克";
                dgv.Rows[cell.RowIndex].Cells["明细表法定单位"].Value = "千克";
                dgv.Rows[cell.RowIndex].Cells["备案损耗"].Value = 0;
            }
            else if (dt进口料件表.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择客户型号";
                formSelect.dtData = dt进口料件表;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string 料件名称及商编 = string.Empty;
                    string 料件规格型号 = string.Empty;
                    if (formSelect.returnRow["品名规格型号"].ToString().Trim().Length > 0)
                    {
                        string[] texts = formSelect.returnRow["品名规格型号"].ToString().Trim().Split('/');
                        料件名称及商编 = texts[0];
                        if (texts.Length > 1)
                        {
                            料件规格型号 = texts[texts.Length - 1];
                        }
                    }
                    cell.Value = 料件名称及商编;
                    dgv.Rows[cell.RowIndex].Cells["料件项号"].Value = formSelect.returnRow["序号"];
                    dgv.Rows[cell.RowIndex].Cells["料件规格型号"].Value = 料件规格型号;
                    dgv.Rows[cell.RowIndex].Cells["明细表申报单位"].Value = "千克";
                    dgv.Rows[cell.RowIndex].Cells["明细表法定单位"].Value = "千克";
                    dgv.Rows[cell.RowIndex].Cells["备案损耗"].Value = 0;
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            return true;
        }
        private void validate料件项号(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["料件项号"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    int.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["料件项号"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["料件项号"].Value = 0;
                }
            }
        }
        private void validate备案净耗单位(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["备案净耗单位"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["备案净耗单位"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["备案净耗单位"].Value = 0;
                }
            }
        }
        private void validate备案损耗(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["备案损耗"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["备案损耗"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["备案损耗"].Value = 0;
                }
            }
        }
        private void validate变更净耗单位(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["变更净耗单位"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["变更净耗单位"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["变更净耗单位"].Value = 0;
                }
            }
        }
        private void validate变更损耗(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["变更损耗"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["变更损耗"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["变更损耗"].Value = 0;
                }
            }
        }
        private void validate归并前损耗(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["归并前损耗"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["归并前损耗"].Value = cell.EditedFormattedValue;
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["归并前损耗"].Value = 0;
                }
            }
            //如果当前行的料件名称及商编为空，则跳转到当前行的料件名称及商编
            if (dgv.Rows[cell.RowIndex].Cells["料件名称及商编"].Value == DBNull.Value
                || dgv.Rows[cell.RowIndex].Cells["料件名称及商编"].Value.ToString().Trim() == "")
            {
                dgv.CurrentCell = dgv["料件名称及商编", cell.RowIndex];
            }
            else
            {
                //否则跳转到下一行的料件项号，如果是最后一行，则新增一行
                if (cell.RowIndex == dgv.Rows.Count - 1)
                {
                    //int iRow = dgv.Rows.Add();
                    //dgv.CurrentCell = dgv["料件项号", iRow];
                    dtDetailsAddRow();
                    dgv.CurrentCell = dgv["料件项号", cell.RowIndex + 1];
                }
                else
                {
                    dgv.CurrentCell = dgv["料件项号", cell.RowIndex + 1];
                }
            }
        }
        public override void dataGridViewDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            base.dataGridViewDetail_DataError(sender, e);
            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "料件项号" || colName == "备案净耗单位" || colName == "备案损耗" || colName == "变更净耗单位" || colName == "变更损耗" || colName == "归并前损耗")
                e.Cancel = false;
        }

        /// <summary>
        /// 明细GRID增加一条新行
        /// </summary>
        public override void dtDetailsAddRow()
        {
            //DataRow newRow = dtDetails.NewRow();
            //newRow["订单数量"] = 0;
            //newRow["产品表申报单位"] = "个";
            //newRow["法定单位"] = "千克";
            //dtDetails.Rows.Add(newRow);
            DataTableTools.AddEmptyRow(dtDetails,false);
            //this.dataGridViewDetail.CurrentCell = this.dataGridViewDetail["客人型号", dtDetails.Rows.Count - 1];
            setTool1Enabled();
        }

        #endregion
    }
}
