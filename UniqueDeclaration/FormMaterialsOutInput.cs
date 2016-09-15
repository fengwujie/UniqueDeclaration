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
    public partial class FormMaterialsOutInput : UniqueDeclarationBaseForm.FormBaseInput
    {
        public FormMaterialsOutInput()
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
            this.dataGridViewDetail.Columns["料件出库明细表id"].Visible = false;
            this.dataGridViewDetail.Columns["料件出库明细表id"].ContextMenuStrip = this.myContextDetails;
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

            this.dataGridViewDetail.Columns["出库数量"].DisplayIndex = 6;
            this.dataGridViewDetail.Columns["出库数量"].ReadOnly = false;
            this.dataGridViewDetail.Columns["出库数量"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewDetail.Columns["出库数量"].DefaultCellStyle = dataGridViewCellStyle1;

            this.dataGridViewDetail.Columns["库存数"].DisplayIndex = 7;
            this.dataGridViewDetail.Columns["库存数"].ReadOnly = true;
            this.dataGridViewDetail.Columns["库存数"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewDetail.Columns["库存数"].DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDetail.Columns["出库后库存数"].DisplayIndex = 8;
            this.dataGridViewDetail.Columns["出库后库存数"].ReadOnly = true;
            this.dataGridViewDetail.Columns["出库后库存数"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["单位"].DisplayIndex = 9;
            this.dataGridViewDetail.Columns["单位"].ReadOnly = true;
            this.dataGridViewDetail.Columns["单位"].ContextMenuStrip = this.myContextDetails;
            this.dataGridViewDetail.Columns["备注"].DisplayIndex = 10;
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
            string strSQL = string.Format("select * from 进口料件出库表 WHERE 料件出库表id = {0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtHead = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtHead.Rows.Count > 0)
            {
                rowHead = dtHead.Rows[0];
                fillControl(rowHead,false);
            }
            else
            {
                rowHead = dtHead.NewRow();
                dtHead.Rows.Add(rowHead);
                dataAccess.Open();
                //获取自动生成的单号
                strSQL = string.Format(@"declare @CODE varchar(20)
                                                exec 进口单号生成 'C','C','160830', @CODE output
                                                select @CODE");
                object CODE = dataAccess.ExecScalar(strSQL,null);
                dataAccess.Close();
                rowHead["出库单号"] = CODE;
                rowHead["出库时间"] = DateTime.Now;
                rowHead["制造通知单号"] =string.Empty;
                rowHead["电子帐册号"] = cbox_电子帐册号.SelectedValue;
                rowHead["摘要"] =string.Empty;
                rowHead["录入员"] =SystemGlobal.SystemGlobal_UserInfo.UserName;
                rowHead["过帐标志"] = 0;
                fillControl(rowHead,false);
                //dtHead.AcceptChanges();
            }
            setForeColor();
        }
        /// <summary>
        /// 加载表身数据
        /// </summary>
        public override void LoadDataSourceDetails()
        {
            string strSQL = string.Format("exec 进口料件出库修改查询 {0},'{1}'", giOrderID,strBooksNo);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
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
                if (rowHead["出库单号"].ToString().Length > 0 || rowHead["制造通知单号"].ToString().Length > 0)
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
                            if (row["料件编号"] != DBNull.Value || row["料件编号"].ToString().Trim().Length > 0 ||
                                row["料号"] != DBNull.Value || row["料号"].ToString().Trim().Length > 0)
                            {
                                bModify = true;
                                break;
                            }
                        }
                        else if (row.RowState == DataRowState.Deleted)
                        {
                            if (row["料件出库明细表id", DataRowVersion.Original] != DBNull.Value)
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
                if (txt_出库单号1.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("出库单号不能为空！");
                    txt_出库单号1.Focus();
                    return false;
                }
                if (txt_出库单号2.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("出库单号不能为空！");
                    txt_出库单号2.Focus();
                    return false;
                }
                if (txt_制造通知单号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("制造通知单号不能为空！");
                    txt_制造通知单号.Focus();
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
                        strBuilder.AppendLine("INSERT INTO .[进口料件出库表]([出库单号],[制造通知单号],[出库时间],[摘要],[电子帐册号],[录入员],[过帐标志])");
                        strBuilder.AppendFormat("VALUES({0},{1},'{2}',{3},'{4}',{5},{6})",
                            rowHead["出库单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["出库单号"].ToString()),
                            rowHead["制造通知单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["制造通知单号"].ToString()),
                            rowHead["出库时间"],  rowHead["摘要"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["摘要"].ToString()),
                            rowHead["电子帐册号"] == DBNull.Value ? "NULL" : rowHead["电子帐册号"],
                            rowHead["录入员"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["录入员"].ToString()),
                            (rowHead["过帐标志"] == DBNull.Value || Convert.ToBoolean(rowHead["过帐标志"])==false) ? 0 :1);
                        strBuilder.AppendLine("select @@IDENTITY--新增进口料件出库表时，自动生成的订单ID");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object 料件出库表id = dtInsert.Rows[0][0]; // dataAccess.ExecScalar(strBuilder.ToString(), null);
                        rowHead["料件出库表id"] = 料件出库表id;
                        strBuilder.Clear();
                        #endregion

                        #region 新增明细数据
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            if (row["料件id"] == DBNull.Value) continue;
                            strBuilder.AppendLine("INSERT INTO [进口料件出库明细表]([料件出库表id],[料件id],[出库数量],[备注])");
                            strBuilder.AppendFormat("VALUES({0},{1},{2},{3})",
                                料件出库表id, row["料件id"],
                                row["出库数量"] == DBNull.Value ? "NULL" : row["出库数量"].ToString(),
                                row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()));
                            strBuilder.AppendLine("select @@IDENTITY");
                            object 料件出库明细表id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            row["料件出库明细表id"] = 料件出库明细表id;
                        }
                        #endregion
                        giOrderID = Convert.ToInt32(料件出库表id);
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
                            strBuilder.AppendFormat("UPDATE [进口料件出库表] SET [出库单号] = {0},[制造通知单号] = {1},[出库时间] = '{2}',[摘要] = {3},[电子帐册号] = '{4}',[录入员] ={5},[过帐标志] = {6} where 料件出库表id={7}",
                            rowHead["出库单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["出库单号"].ToString()),
                            rowHead["制造通知单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["制造通知单号"].ToString()),
                            rowHead["出库时间"],  rowHead["摘要"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["摘要"].ToString()),
                            rowHead["电子帐册号"] == DBNull.Value ? "NULL" : rowHead["电子帐册号"],
                            rowHead["录入员"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["录入员"].ToString()),
                            (rowHead["过帐标志"] == DBNull.Value || Convert.ToBoolean(rowHead["过帐标志"]) == false) ? 0 : 1, rowHead["料件出库表id"]);
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
                                strBuilder.AppendLine("INSERT INTO [进口料件出库明细表]([料件出库表id],[料件id],[出库数量],[备注])");
                                strBuilder.AppendFormat("VALUES({0},{1},{2},{3})",
                                    row["料件出库表id"], row["料件id"],
                                    row["出库数量"] == DBNull.Value ? "NULL" : row["出库数量"],
                                    row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()));
                                strBuilder.AppendLine("select @@IDENTITY");
                                object 料件出库明细表id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                                strBuilder.Clear();
                                row["料件出库明细表id"] = 料件出库明细表id;
                            }
                            #endregion

                            #region 删除表身数据
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                if (row["料件出库明细表id",DataRowVersion.Original] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"DELETE FROM [进口料件出库明细表] WHERE 料件出库明细表id={0}", row["料件出库明细表id", DataRowVersion.Original]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion

                            #region 修改表身数据
                            else //if (row.RowState == DataRowState.Modified)
                            {
                                if (row["料件出库明细表id"] == DBNull.Value) continue;
                                if (row["料件id"] == DBNull.Value)
                                {
                                    strBuilder.AppendFormat(@"DELETE FROM [进口料件出库明细表] WHERE 料件出库明细表id={0}", row["订单明细表id"]);
                                }
                                else
                                {
                                    strBuilder.AppendFormat(@"UPDATE [进口料件出库明细表] SET [料件出库表id] ={0},[料件id] = {1},[出库数量] ={2},[备注] = {3} where 料件出库明细表id={4}",
                                            rowHead["料件出库表id"], row["料件id"],row["出库数量"] == DBNull.Value ? "NULL" : row["出库数量"],
                                            row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()), row["料件出库明细表id"]);
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
        
        #region 表身toolStrip事件

        public override void tool2_Import_Click(object sender, EventArgs e)
        {
            base.tool2_Import_Click(sender, e);

            if (txt_制造通知单号.Text.Trim().Length == 0)
            {
                SysMessage.InformationMsg("请输入单号");
                return;
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            string strSQL = string.Empty;
            DataTable dtTemp = null;
            if (StringTools.intParse(rowHead["料件出库表id"].ToString()) != 0)
            {
                dataAccess.Open();
                strSQL = string.Format("select * from 进口料件出库明细表 WHERE 料件出库表id = {0}", rowHead["料件出库表id"]);
                dtTemp = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtTemp.Rows.Count > 0)
                {
                    if (SysMessage.YesNoMsg("此单已导，是否继续") == System.Windows.Forms.DialogResult.Yes)
                    {
                        strSQL = string.Format("delete from 进口料件出库明细表 WHERE 料件出库表id = {0}", rowHead["料件出库表id"]);
                        dataAccess.Open();
                        dataAccess.ExecuteNonQuery(strSQL, null);
                        dataAccess.Close();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Importid = true;
            strSQL = string.Format("SELECT 制造通知单id FROM 报关制造通知单表 where 制造通知单号={0}", StringTools.SqlQ(rowHead["制造通知单号"].ToString()));
            dataAccess.Open();
            dtTemp = dataAccess.GetTable(strSQL, null);
            strSQL = string.Format("报关制造通知单料件出库导出 @制造通知单id={0}", dtTemp.Rows[0]["制造通知单id"]);
            dtTemp = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtTemp.Rows.Count > 0)
            {
                //如果最后一行的料件编号和料号都为空，则删除掉
                if (dtDetails.Rows.Count > 0)
                {
                    int iCount = dtDetails.Rows.Count - 1;
                    DataRow rowLast = dtDetails.Rows[iCount];
                    if (rowLast.RowState == DataRowState.Added)
                    {
                        if ((rowLast["料件编号"] == DBNull.Value || rowLast["料件编号"].ToString().Trim().Length == 0) &&
                            (rowLast["料号"] == DBNull.Value || rowLast["料号"].ToString().Trim().Length > 0))
                        {
                            dtDetails.Rows.RemoveAt(iCount);
                        }
                    }
                }
                dataAccess.Open();
                foreach (DataRow row in dtTemp.Rows)
                {
                    DataRow newRow = dtDetails.NewRow();
                    newRow["料件id"] = row["料件id"];
                    newRow["料件编号"] = row["料件编号"];
                    newRow["料号"] = row["料号"];
                    newRow["料件名"] = row["料件名"];
                    newRow["商品编码"] = row["商品编码"];
                    newRow["商品名称"] = row["商品名称"];
                    newRow["商品规格"] = row["商品规格"];
                    newRow["单位"] = row["单位"];
                    newRow["出库数量"] = row["数量"];
                    if (row["料号"] != DBNull.Value && row["料号"].ToString() != "")
                    {
                        strSQL = string.Format("进口料件出库库存查询 @料号={0},@电子帐册号={1}", StringTools.SqlQ(row["料号"].ToString()), StringTools.SqlQ(cbox_电子帐册号.SelectedValue.ToString()));
                        DataTable dt库存 = dataAccess.GetTable(strSQL, null);
                        if (dt库存.Rows.Count > 0)
                        {
                            newRow["库存数"] = dt库存.Rows[0]["库存数"];
                            newRow["出库后库存数"] = StringTools.decimalParse(dt库存.Rows[0]["库存数"].ToString()) - StringTools.decimalParse(newRow["出库数量"].ToString());
                        }
                    }
                    dtDetails.Rows.Add(newRow);
                }
                dataAccess.Close();
            }
            Importid = false;
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

        #region 表头控件值变化事件
        private void txt_出库单号1_Validated(object sender, EventArgs e)
        {
            string str出库单号 = txt_出库单号1.Text.Trim() + txt_出库单号2.Text.Trim();
            if (rowHead["出库单号"].ToString() != str出库单号)
            {
                rowHead["出库单号"] = str出库单号;
            }
        }
        private void txt_出库单号2_Validated(object sender, EventArgs e)
        {
            string str出库单号 = txt_出库单号1.Text.Trim() + txt_出库单号2.Text.Trim();
            if (rowHead["出库单号"].ToString() != str出库单号)
            {
                rowHead["出库单号"] = str出库单号;
            }
        }
        private void txt_出库单号1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !check出库单号();
        }
        private void txt_出库单号2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !check出库单号();
        }

        private void txt_摘要_Validated(object sender, EventArgs e)
        {
            if (rowHead["摘要"].ToString() != txt_摘要.Text)
            {
                rowHead["摘要"] = txt_摘要.Text;
            }
        }

        private void txt_录入员_Validated(object sender, EventArgs e)
        {
            if (rowHead["录入员"].ToString() != txt_录入员.Text)
            {
                rowHead["录入员"] = txt_录入员.Text;
            }
        }

        private void txt_制造通知单号_Validated(object sender, EventArgs e)
        {
            if (rowHead["制造通知单号"].ToString() != txt_制造通知单号.Text)
            {
                rowHead["制造通知单号"] = txt_制造通知单号.Text;
            }
        }

        private void txt_制造通知单号_Validating(object sender, CancelEventArgs e)
        {
            if (rowHead.RowState == DataRowState.Added && this.txt_制造通知单号.Text.Trim().Length > 0 && rowHead["制造通知单号"].ToString()!=this.txt_制造通知单号.Text.Trim())
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("SELECT 制造通知单号 FROM 进口料件出库表 where 制造通知单号={0}", StringTools.SqlQ(this.txt_制造通知单号.Text.Trim()));
                DataTable dtTemp = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtTemp.Rows.Count > 0)
                {
                    if (SysMessage.YesNoMsg("此单材料明细已经存在，是否继续") == System.Windows.Forms.DialogResult.Yes)
                    {
                    }
                    else
                    {
                        txt_制造通知单号.Text = "";
                        txt_制造通知单号.Focus();
                        return;
                    }
                }

                //strSQL = string.Format("SELECT distinct 报关制造通知单表.制造通知单号,报关制造通知单表.手册编号,报关制造通知单表.录入日期,报关制造通知单表.出货日期 FROM 报关制造通知单表 LEFT OUTER JOIN 报关制造通知单明细表 ON 报关制造通知单表.制造通知单id =报关制造通知单明细表.制造通知单id where 报关制造通知单表.制造通知单号 like  '%{0}%' order by 报关制造通知单表.制造通知单号", StringTools.SqlLikeQ(this.txt_制造通知单号.Text.Trim()));
                strSQL = string.Format("SELECT distinct 报关制造通知单表.制造通知单号,报关制造通知单表.手册编号 as 电子帐册号,报关制造通知单表.录入日期,报关制造通知单表.出货日期 as 出库时间 FROM 报关制造通知单表 LEFT OUTER JOIN 报关制造通知单明细表 ON 报关制造通知单表.制造通知单id =报关制造通知单明细表.制造通知单id where 报关制造通知单表.制造通知单号 like  '%{0}%' order by 报关制造通知单表.制造通知单号", StringTools.SqlLikeQ(this.txt_制造通知单号.Text.Trim()));
                dtTemp = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtTemp.Rows.Count == 0)
                {
                    SysMessage.InformationMsg("此单号不存在！");
                    //e.Cancel = true;
                    return;
                }
                //如果大于1记录的话，则弹出选择框选择
                if (dtTemp.Rows.Count > 1)
                {
                    FormBaseSingleSelect selectForm = new FormBaseSingleSelect();
                    selectForm.strFormText = "选择制造通知单";
                    selectForm.dtData = dtTemp;
                    if (selectForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        fillRowHead(selectForm.returnRow, true);
                        fillControl(selectForm.returnRow, true);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    fillRowHead(dtTemp.Rows[0],true);
                    fillControl(dtTemp.Rows[0], true);
                }
            }
        }
        /// <summary>
        /// 填充表头数据到控件上
        /// </summary>
        /// <param name="row">来源数据</param>
        /// <param name="bDiffDay">出库时间差异天数</param>
        private void fillControl(DataRow row,bool bDiffDay)
        {
            if (row.Table.Columns.Contains("出库单号"))
            {
                txt_出库单号1.Text = row["出库单号"].ToString().Substring(0,1);
                txt_出库单号2.Text = row["出库单号"].ToString().Substring(1);
            }
            if (row.Table.Columns.Contains("制造通知单号"))
            {
                txt_制造通知单号.Text = row["制造通知单号"].ToString();
            }
            if (row.Table.Columns.Contains("出库时间"))
            {
                if (bDiffDay)
                {
                    date_出库时间.Value = Convert.ToDateTime(row["出库时间"]).AddDays(-7);
                }
                else
                {
                    date_出库时间.Value = Convert.ToDateTime(row["出库时间"]);
                }
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
        }
        /// <summary>
        /// 填充表头数据到rowHead中
        /// </summary>
        /// <param name="row">来源数据</param>
        /// <param name="bDiffDay">出库时间差异天数</param>
        private void fillRowHead(DataRow row, bool bDiffDay)
        {
            if (row.Table.Columns.Contains("出库单号") && rowHead["出库单号"].ToString() != row["出库单号"].ToString())
            {
                rowHead["出库单号"] = row["出库单号"];
            }
            if (row.Table.Columns.Contains("制造通知单号") && rowHead["制造通知单号"].ToString() != row["制造通知单号"].ToString())
            {
                rowHead["制造通知单号"] = row["制造通知单号"];
            }
            if (row.Table.Columns.Contains("摘要") && rowHead["摘要"].ToString() != row["摘要"].ToString())
            {
                rowHead["摘要"] = row["摘要"];
            }
            if (row.Table.Columns.Contains("录入员") && rowHead["录入员"].ToString() != row["录入员"].ToString())
            {
                rowHead["录入员"] = row["录入员"];
            }
            if (row.Table.Columns.Contains("电子帐册号") && rowHead["电子帐册号"].ToString() != row["电子帐册号"].ToString())
            {
                rowHead["电子帐册号"] = row["电子帐册号"];
            }
            if (row.Table.Columns.Contains("出库时间") && Convert.ToDateTime(rowHead["出库时间"]) != Convert.ToDateTime(row["出库时间"]))
            {
                if (bDiffDay)
                {
                    rowHead["出库时间"] = Convert.ToDateTime(row["出库时间"]).AddDays(-7);
                }
                else
                {
                    rowHead["出库时间"] = row["出库时间"];
                }
            }
        }

        private void cbox_电子帐册号_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bcbox_电子帐册号_SelectedIndexChanged && rowHead["手册编号"].ToString() != cbox_电子帐册号.SelectedValue.ToString())
                rowHead["手册编号"] = cbox_电子帐册号.SelectedValue;
        }

        private void date_出库时间_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(rowHead["出库时间"]) != date_出库时间.Value)
            {
                rowHead["出货日期"] = date_出库时间.Value;
            }
        }
        /// <summary>
        /// 设置出库单号的字体颜色
        /// </summary>
        private void setForeColor()
        {
            if (rowHead["过帐标志"] == DBNull.Value || !Convert.ToBoolean(rowHead["过帐标志"]))
            {
                txt_出库单号1.ForeColor = Color.Black;
                txt_出库单号2.ForeColor = Color.Black;
            }
            else
            {
                txt_出库单号1.ForeColor = Color.Red;
                txt_出库单号2.ForeColor = Color.Red;
            }
        }
        /// <summary>
        /// 检查出库单号的合法性
        /// </summary>
        /// <returns>返回检查结果</returns>
        private bool check出库单号()
        {
            bool bReturn = true;
            string str出库单号 = string.Format("{0}{1}", txt_出库单号1.Text.Trim(), txt_出库单号2.Text.Trim());
            bool isCheck = false;
            if (rowHead.RowState == DataRowState.Added)
            {
                isCheck = true;
            }
            else if (rowHead.RowState == DataRowState.Modified)
            {
                if (rowHead["出库单号", DataRowVersion.Original].ToString() != str出库单号)
                {
                    isCheck = true;
                }
            }
            if (isCheck)
            {
                string strSQL = string.Format("SELECT 料件出库表id FROM 进口料件出库表 WHERE 出库单号 ={0}", StringTools.SqlQ(str出库单号));
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
                        validate备注(dgv,cell);
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
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            if (dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString() != "")
            {
                strSQL = string.Format("进口料件出库库存查询 @料号={0},@电子帐册号={1},@期末时间='{2}'",
                    StringTools.SqlQ(dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString()),
                    StringTools.SqlQ(cbox_电子帐册号.SelectedValue.ToString()),
                    date_出库时间.Value.ToString("yyyyMMdd HH:mm:ss"));
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
                strSQL = string.Format("进口料件出库库存查询 @料号={0},@电子帐册号={1},@期末时间='{2}'",
                    StringTools.SqlQ(dgv.Rows[cell.RowIndex].Cells["料号"].Value.ToString()),
                    StringTools.SqlQ(cbox_电子帐册号.SelectedValue.ToString()),
                    date_出库时间.Value.ToString("yyyyMMdd HH:mm:ss"));
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
            DataRow newRow = dtDetails.NewRow();
            newRow["出库数量"] = 1;
            newRow["单位"] = "KGS";
            dtDetails.Rows.Add(newRow);
            setTool1Enabled();
        }
        
        #endregion

    }
}
