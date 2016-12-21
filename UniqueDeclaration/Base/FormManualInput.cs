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

namespace UniqueDeclaration.Base
{
    public partial class FormManualInput : UniqueDeclarationBaseForm.FormBase
    {
        public FormManualInput()
        {
            InitializeComponent();
        }

        #region 自定义变量
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
        /// 表身数据集
        /// </summary>
        public DataTable dtDetails2 = null;
        /// <summary>
        /// 出口成品明细表的第一个字段
        /// </summary>
        private string gstrDetailFirstField = "序号";
        /// <summary>
        /// 进口料件明细表的第一个字段
        /// </summary>
        private string gstrDetailFirstField2 = "序号";
        /// <summary>
        /// 控制是否触发单元格回车事件，如果是回车事件后，指定到某个单元格，这种情况下就不再触发回车事件
        /// </summary>
        public bool bCellKeyPress = true;
        /// <summary>
        /// 是否触发单元格结束编辑事件
        /// </summary>
        public bool bCellEndEdit = true;
        #endregion

        #region 窗体事件
        private void FormManualInput_Load(object sender, EventArgs e)
        {
            InitControlData();
            LoadDataSource();
            InitGrid();
        }

        private void FormManualInput_FormClosing(object sender, FormClosingEventArgs e)
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
        /// 初始化GRID
        /// </summary>
        public void InitGrid()
        {
            InitGridDetails();
            InitGridDetails2();
        }
        /// <summary>
        /// 出口成品GRID初始化
        /// </summary>
        private void InitGridDetails()
        {
            this.myDataGridViewDetails.Columns["BM"].Visible = false;
            this.myDataGridViewDetails.Columns["出口成品id"].Visible = false;
            this.myDataGridViewDetails.Columns["总价"].ReadOnly = true;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "F3";
            dataGridViewCellStyle1.NullValue = null;
            this.myDataGridViewDetails.Columns["数量"].DefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridViewDetails.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridViewDetails.Columns["总价"].DefaultCellStyle = dataGridViewCellStyle1;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewDetails.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextDetails;
            }
        }
        /// <summary>
        /// 进口料件GRID初始化
        /// </summary>
        private void InitGridDetails2()
        {
            this.myDataGridViewDetails2.Columns["BM"].Visible = false;
            this.myDataGridViewDetails2.Columns["进口料件id"].Visible = false;
            this.myDataGridViewDetails2.Columns["总价"].ReadOnly = true;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "F3";
            dataGridViewCellStyle1.NullValue = null;
            this.myDataGridViewDetails2.Columns["数量"].DefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridViewDetails2.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridViewDetails2.Columns["总价"].DefaultCellStyle = dataGridViewCellStyle1;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewDetails2.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextDetails2;
            }
        }
        /// <summary>
        /// 初始化界面上某些控件的初始值
        /// </summary>
        public void InitControlData()
        {
            
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadDataSource()
        {
            LoadDataSourceHead();
            LoadDataSourceDetails();
            LoadDataSourceDetails2();
        }
        /// <summary>
        /// 加载表头数据
        /// </summary>
        public void LoadDataSourceHead()
        {
            string strSQL = string.Format("select * from 手册资料表 where 手册id={0}", giOrderID);
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
                rowHead["有效期限"] = date_有效期限.Value;
                rowHead["审批日期"] = date_审批日期.Value;
                rowHead["录入员"] = SystemGlobal.SystemGlobal_UserInfo.UserName;
                fillControl(rowHead);
            }
        }
        /// <summary>
        /// 加载表身出口成品数据
        /// </summary>
        public void LoadDataSourceDetails()
        {
            string strSQL = string.Format("出口成品表录入查询 {0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
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
        /// 加载表身进口料件数据
        /// </summary>
        public void LoadDataSourceDetails2()
        {
            string strSQL = string.Format("进口料件表录入查询 {0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            dtDetails2 = dataAccess.GetTable(strSQL.ToString(), null);
            dataAccess.Close();
            bCellKeyPress = false;
            this.myDataGridViewDetails2.DataSource = dtDetails2;
            bCellKeyPress = true;
            if (dtDetails2.Rows.Count == 0)
                dtDetailsAddRow2();
            setTool3Enabled();
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
                if (rowHead["手册编号"].ToString().Length > 0)
                {
                    bModify = true;
                }
            }
            //如果表头没异动，再判断表身是否有异动
            if (!bModify)
            {
                //出口成品id
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
                            if (row["商品编号"] != DBNull.Value || row["商品编号"].ToString().Trim().Length > 0)
                            {
                                bModify = true;
                                break;
                            }
                        }
                        else if (row.RowState == DataRowState.Deleted)
                        {
                            if (row["出口成品id", DataRowVersion.Original] != DBNull.Value)
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

                //进口料件id
                for (int iRow = 0; iRow < dtDetails2.Rows.Count; iRow++)
                {
                    DataRow row = dtDetails2.Rows[iRow];
                    if (iRow == 0)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            bModify = true;
                            break;
                        }
                        else if (row.RowState == DataRowState.Added)  //如果是新增状态，则判断商品编号是否为空
                        {
                            if (row["商品编号"] != DBNull.Value || row["商品编号"].ToString().Trim().Length > 0)
                            {
                                bModify = true;
                                break;
                            }
                        }
                        else if (row.RowState == DataRowState.Deleted)
                        {
                            if (row["进口料件id", DataRowVersion.Original] != DBNull.Value)
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
            if (row.Table.Columns.Contains("手册编号"))
            {
                txt_手册编号.Text = row["手册编号"].ToString();
            }
            if (row.Table.Columns.Contains("进出口岸一"))
            {
                txt_进出口岸一.Text = row["进出口岸一"].ToString();
            }
            if (row.Table.Columns.Contains("经营单位"))
            {
                txt_经营单位.Text = row["经营单位"].ToString();
            }
            if (row.Table.Columns.Contains("贸易方式"))
            {
                txt_贸易方式.Text = row["贸易方式"].ToString();
            }
            if (row.Table.Columns.Contains("有效期限"))
            {
                date_有效期限.Value = Convert.ToDateTime(row["有效期限"]);
            }
            if (row.Table.Columns.Contains("收货单位"))
            {
                txt_收货单位.Text = row["收货单位"].ToString();
            }
            if (row.Table.Columns.Contains("起抵地"))
            {
                txt_起抵地.Text = row["起抵地"].ToString();
            }
            if (row.Table.Columns.Contains("重点标志"))
            {
                txt_重点标志.Text = row["重点标志"].ToString();
            }
            if (row.Table.Columns.Contains("收货单位编码"))
            {
                txt_收货单位编码.Text = row["收货单位编码"].ToString();
            }
            if (row.Table.Columns.Contains("企业地址"))
            {
                txt_企业地址.Text = row["企业地址"].ToString();
            }
            if (row.Table.Columns.Contains("联系人"))
            {
                txt_联系人.Text = row["联系人"].ToString();
            }
            if (row.Table.Columns.Contains("联系电话"))
            {
                txt_联系电话.Text = row["联系电话"].ToString();
            }
            if (row.Table.Columns.Contains("外商公司"))
            {
                txt_外商公司.Text = row["外商公司"].ToString();
            }
            if (row.Table.Columns.Contains("征免性质"))
            {
                txt_征免性质.Text = row["征免性质"].ToString();
            }
            if (row.Table.Columns.Contains("批文号"))
            {
                txt_批文号.Text = row["批文号"].ToString();
            }
            if (row.Table.Columns.Contains("协议书号"))
            {
                txt_协议书号.Text = row["协议书号"].ToString();
            }
            if (row.Table.Columns.Contains("进口合同"))
            {
                txt_进口合同.Text = row["进口合同"].ToString();
            }
            if (row.Table.Columns.Contains("出口合同"))
            {
                txt_出口合同.Text = row["出口合同"].ToString();
            }
            if (row.Table.Columns.Contains("进口总值"))
            {
                txt_进口总值.Text = row["进口总值"].ToString();
            }
            if (row.Table.Columns.Contains("出口总值"))
            {
                txt_出口总值.Text = row["出口总值"].ToString();
            }
            if (row.Table.Columns.Contains("监管费"))
            {
                txt_监管费.Text = row["监管费"].ToString();
            }
            if (row.Table.Columns.Contains("进出口岸二"))
            {
                txt_进出口岸二.Text = row["进出口岸二"].ToString();
            }
            if (row.Table.Columns.Contains("进出口岸三"))
            {
                txt_进出口岸三.Text = row["进出口岸三"].ToString();
            }
            if (row.Table.Columns.Contains("进出口岸四"))
            {
                txt_进出口岸四.Text = row["进出口岸四"].ToString();
            }
            if (row.Table.Columns.Contains("进出口岸五"))
            {
                txt_进出口岸五.Text = row["进出口岸五"].ToString();
            }
            if (row.Table.Columns.Contains("审批员"))
            {
                txt_审批员.Text = row["审批员"].ToString();
            }
            if (row.Table.Columns.Contains("审批日期"))
            {
                date_审批日期.Value = Convert.ToDateTime(row["审批日期"]);
            }
            if (row.Table.Columns.Contains("保税方式"))
            {
                txt_保税方式.Text = row["保税方式"].ToString();
            }
            if (row.Table.Columns.Contains("录入员"))
            {
                txt_录入员.Text = row["录入员"].ToString();
            }
            if (row.Table.Columns.Contains("备注"))
            {
                txt_备注.Text = row["备注"].ToString();
            }
            if (row.Table.Columns.Contains("工缴费率"))
            {
                txt_工缴费率.Text = row["工缴费率"].ToString();
            }
            if (row.Table.Columns.Contains("手册编号"))
            {
                txt_手册编号2.Text = row["手册编号"].ToString();
            }
            if (row.Table.Columns.Contains("手册编号"))
            {
                txt_手册编号3.Text = row["手册编号"].ToString();
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
                if (txt_手册编号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("手册编号不能为空！");
                    txt_手册编号.Focus();
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
                        strBuilder.AppendLine(@"INSERT INTO [手册资料表]
           ([手册编号],[进出口岸一],[经营单位],[贸易方式],[有效期限],[收货单位],[起抵地],[重点标志],[收货单位编码],[企业地址],[联系人],[联系电话]
           ,[外商公司],[征免性质],[批文号],[协议书号],[进口合同],[出口合同],[进口总值],[出口总值],[监管费],[进出口岸二],[进出口岸三],[进出口岸四]
		   ,[进出口岸五],[审批员],[审批日期],[保税方式],[备注],[录入员],[工缴费率])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30})",
                            rowHead["手册编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["手册编号"].ToString()),
                            rowHead["进出口岸一"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进出口岸一"].ToString()),
                            rowHead["经营单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["经营单位"].ToString()),
                            rowHead["贸易方式"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["贸易方式"].ToString()),
                            StringTools.SqlQ(Convert.ToDateTime( rowHead["有效期限"]).ToShortDateString()),
                            rowHead["收货单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["收货单位"].ToString()),
                            rowHead["起抵地"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["起抵地"].ToString()),
                            rowHead["重点标志"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["重点标志"].ToString()),
                            rowHead["收货单位编码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["收货单位编码"].ToString()),
                            rowHead["企业地址"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["企业地址"].ToString()),
                            rowHead["联系人"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["联系人"].ToString()),
                            rowHead["联系电话"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["联系电话"].ToString()),
                            rowHead["外商公司"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["外商公司"].ToString()),
                            rowHead["征免性质"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["征免性质"].ToString()),
                            rowHead["批文号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["批文号"].ToString()),
                            rowHead["协议书号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["协议书号"].ToString()),
                            rowHead["进口合同"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进口合同"].ToString()),
                            rowHead["出口合同"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["出口合同"].ToString()),
                            rowHead["进口总值"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进口总值"].ToString()),
                            rowHead["出口总值"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["出口总值"].ToString()),
                            rowHead["监管费"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["监管费"].ToString()),
                            rowHead["进出口岸二"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进出口岸二"].ToString()),
                            rowHead["进出口岸三"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进出口岸三"].ToString()),
                            rowHead["进出口岸四"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进出口岸四"].ToString()),
                            rowHead["进出口岸五"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进出口岸五"].ToString()),
                            rowHead["审批员"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["审批员"].ToString()),
                            StringTools.SqlQ(Convert.ToDateTime( rowHead["审批日期"]).ToShortDateString()),
                            rowHead["保税方式"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["保税方式"].ToString()),
                            rowHead["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["备注"].ToString()),
                            rowHead["录入员"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["录入员"].ToString()),
                            rowHead["工缴费率"] == DBNull.Value ? "NULL" : rowHead["工缴费率"]);
                        strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object 手册id = dtInsert.Rows[0][0]; // dataAccess.ExecScalar(strBuilder.ToString(), null);
                        rowHead["手册id"] = 手册id;
                        strBuilder.Clear();
                        #endregion

                        #region 新增明细数据（出口成品）
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            if (row["商品编号"] == DBNull.Value || row["商品编号"].ToString().Trim().Length == 0) continue;
                            //row["订单id"] = iID;
                            strBuilder.AppendLine("INSERT INTO [出口成品表]([手册Id],[序号],[产品编号],[商品编号],[品名规格型号],[数量],[单位],[单价],[币种],[征免],[备注])");
                            strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})",
                                手册id, row["序号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["序号"].ToString()),
                                row["产品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["产品编号"].ToString()),
                                row["商品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品编号"].ToString()),
                                row["品名规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["品名规格型号"].ToString()),
                                row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                row["单价"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单价"].ToString()),
                                row["币种"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["币种"].ToString()),
                                row["征免"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["征免"].ToString()),
                                row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()));
                            strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                            object 出口成品id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            row["出口成品id"] = 出口成品id;
                        }
                        #endregion

                        #region 新增明细数据（进口料件）
                        foreach (DataRow row in dtDetails2.Rows)
                        {
                            if (row["商品编号"] == DBNull.Value || row["商品编号"].ToString().Trim().Length == 0) continue;
                            strBuilder.AppendLine("INSERT INTO [进口料件表]([手册id],[序号],[商品编号],[品名规格型号],[数量],[单位],[单价],[币种],[征免])");
                            strBuilder.AppendFormat("VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                                手册id, row["序号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["序号"].ToString()),
                                row["商品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品编号"].ToString()),
                                row["品名规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["品名规格型号"].ToString()),
                                row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                row["单价"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单价"].ToString()),
                                row["币种"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["币种"].ToString()),
                                row["征免"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["征免"].ToString()));
                            strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                            object 进口料件id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            row["进口料件id"] = 进口料件id;
                        }
                        #endregion
                        giOrderID = Convert.ToInt32(手册id);
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
                            strBuilder.AppendFormat(@"UPDATE [手册资料表] set [手册编号]={0},[进出口岸一]={1},[经营单位]={2},[贸易方式]={3},[有效期限]={4},[收货单位]={5},[起抵地]={6},
            [重点标志]={7},[收货单位编码]={8},[企业地址]={9},[联系人]={10},[联系电话]={11},[外商公司]={12},[征免性质]={13},[批文号]={14},[协议书号]={15},[进口合同]={16},[出口合同]={17},
            [进口总值]={18},[出口总值]={19},[监管费]={20},[进出口岸二]={21},[进出口岸三]={22},[进出口岸四]={23},[进出口岸五]={24},[审批员]={25},[审批日期]={26},[保税方式]={27},[备注]={28},
            [录入员]={29},[工缴费率]={30} where 手册id={31}",
                            rowHead["手册编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["手册编号"].ToString()),
                            rowHead["进出口岸一"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进出口岸一"].ToString()),
                            rowHead["经营单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["经营单位"].ToString()),
                            rowHead["贸易方式"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["贸易方式"].ToString()),
                            StringTools.SqlQ(Convert.ToDateTime( rowHead["有效期限"]).ToShortDateString()),
                            rowHead["收货单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["收货单位"].ToString()),
                            rowHead["起抵地"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["起抵地"].ToString()),
                            rowHead["重点标志"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["重点标志"].ToString()),
                            rowHead["收货单位编码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["收货单位编码"].ToString()),
                            rowHead["企业地址"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["企业地址"].ToString()),
                            rowHead["联系人"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["联系人"].ToString()),
                            rowHead["联系电话"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["联系电话"].ToString()),
                            rowHead["外商公司"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["外商公司"].ToString()),
                            rowHead["征免性质"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["征免性质"].ToString()),
                            rowHead["批文号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["批文号"].ToString()),
                            rowHead["协议书号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["协议书号"].ToString()),
                            rowHead["进口合同"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进口合同"].ToString()),
                            rowHead["出口合同"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["出口合同"].ToString()),
                            rowHead["进口总值"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进口总值"].ToString()),
                            rowHead["出口总值"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["出口总值"].ToString()),
                            rowHead["监管费"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["监管费"].ToString()),
                            rowHead["进出口岸二"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进出口岸二"].ToString()),
                            rowHead["进出口岸三"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进出口岸三"].ToString()),
                            rowHead["进出口岸四"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进出口岸四"].ToString()),
                            rowHead["进出口岸五"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["进出口岸五"].ToString()),
                            rowHead["审批员"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["审批员"].ToString()),
                            StringTools.SqlQ( Convert.ToDateTime(rowHead["审批日期"]).ToShortDateString()),
                            rowHead["保税方式"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["保税方式"].ToString()),
                            rowHead["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["备注"].ToString()),
                            rowHead["录入员"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["录入员"].ToString()),
                            rowHead["工缴费率"] == DBNull.Value ? "NULL" : rowHead["工缴费率"],
                            rowHead["手册id"]);
                            dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                            strBuilder.Clear();
                        }
                        #endregion

                        #region 处理明细数据(出口成品)
                        foreach (DataRow row in dtDetails.Rows)
                        {
                            #region 新增表身数据
                            if (row.RowState == DataRowState.Added)
                            {
                                if (row["商品编号"] == DBNull.Value || row["商品编号"].ToString().Trim().Length == 0) continue;
                                //row["订单id"] = iID;
                                strBuilder.AppendLine("INSERT INTO [出口成品表]([手册Id],[序号],[产品编号],[商品编号],[品名规格型号],[数量],[单位],[单价],[币种],[征免],[备注])");
                                strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})",
                                    rowHead["手册id"], row["序号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["序号"].ToString()),
                                    row["产品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["产品编号"].ToString()),
                                    row["商品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品编号"].ToString()),
                                    row["品名规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["品名规格型号"].ToString()),
                                    row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                    row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                    row["单价"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单价"].ToString()),
                                    row["币种"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["币种"].ToString()),
                                    row["征免"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["征免"].ToString()),
                                    row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()));
                                strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                                object 出口成品id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                                strBuilder.Clear();
                                row["出口成品id"] = 出口成品id;
                            }
                            #endregion

                            #region 删除表身数据
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                if (row["出口成品id", DataRowVersion.Original] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"DELETE FROM [出口成品表] WHERE 出口成品id={0}", row["出口成品id", DataRowVersion.Original]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion

                            #region 修改表身数据
                            else //if (row.RowState == DataRowState.Modified)
                            {
                                if (row["出口成品id"] == DBNull.Value) continue;
                                if (row["商品编号"] == DBNull.Value || row["商品编号"].ToString().Trim().Length == 0)
                                {
                                    strBuilder.AppendFormat(@"DELETE FROM [出口成品表] WHERE 出口成品id={0}", row["出口成品id"]);
                                }
                                else
                                {
                                    strBuilder.AppendFormat(@"UPDATE [出口成品表] SET [手册Id]={0},[序号]={1},[产品编号]={2},[商品编号]={3},[品名规格型号]={4},[数量]={5},[单位]={6},[单价]={7},
                                                            [币种]={8},[征免]={9},[备注]={10} where 出口成品id={11}",
                                    rowHead["手册id"], row["序号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["序号"].ToString()),
                                    row["产品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["产品编号"].ToString()),
                                    row["商品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品编号"].ToString()),
                                    row["品名规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["品名规格型号"].ToString()),
                                    row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                    row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                    row["单价"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单价"].ToString()),
                                    row["币种"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["币种"].ToString()),
                                    row["征免"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["征免"].ToString()),
                                    row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()),
                                    row["出口成品id"]);
                                }
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion
                        }
                        #endregion

                        #region 处理明细数据(进口料件id)
                        foreach (DataRow row in dtDetails2.Rows)
                        {
                            #region 新增表身数据
                            if (row.RowState == DataRowState.Added)
                            {
                                if (row["商品编号"] == DBNull.Value || row["商品编号"].ToString().Trim().Length == 0) continue;
                                strBuilder.AppendLine("INSERT INTO [进口料件表]([手册id],[序号],[商品编号],[品名规格型号],[数量],[单位],[单价],[币种],[征免])");
                                strBuilder.AppendFormat("VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                                    rowHead["手册id"], row["序号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["序号"].ToString()),
                                    row["商品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品编号"].ToString()),
                                    row["品名规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["品名规格型号"].ToString()),
                                    row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                    row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                    row["单价"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单价"].ToString()),
                                    row["币种"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["币种"].ToString()),
                                    row["征免"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["征免"].ToString()));
                                strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                                object 进口料件id = dataAccess.ExecScalar(strBuilder.ToString(), null);
                                strBuilder.Clear();
                                row["进口料件id"] = 进口料件id;
                            }
                            #endregion

                            #region 删除表身数据
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                if (row["进口料件id", DataRowVersion.Original] == DBNull.Value) continue;
                                strBuilder.AppendFormat(@"DELETE FROM [进口料件表] WHERE 进口料件id={0}", row["进口料件id", DataRowVersion.Original]);
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                                strBuilder.Clear();
                            }
                            #endregion

                            #region 修改表身数据
                            else //if (row.RowState == DataRowState.Modified)
                            {
                                if (row["进口料件id"] == DBNull.Value) continue;
                                if (row["商品编号"] == DBNull.Value || row["商品编号"].ToString().Trim().Length == 0)
                                {
                                    strBuilder.AppendFormat(@"DELETE FROM [进口料件表] WHERE 进口料件id={0}", row["进口料件id"]);
                                }
                                else
                                {
                                    strBuilder.AppendFormat(@"UPDATE [进口料件表] SET [手册id] = {0},[序号] = {1},[商品编号] = {2},[品名规格型号] = {3},[数量] = {4},[单位] = {5},[单价] = {6},
                                            [币种] = {7},[征免] = {8} where 进口料件id={9}",
                                     rowHead["手册id"], row["序号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["序号"].ToString()),
                                    row["商品编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品编号"].ToString()),
                                    row["品名规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["品名规格型号"].ToString()),
                                    row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                    row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                    row["单价"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单价"].ToString()),
                                    row["币种"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["币种"].ToString()),
                                    row["征免"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["征免"].ToString()),
                                    row["进口料件id"]);
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
                dtDetails2.AcceptChanges();
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

        #region 出口成品tool
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

        private void tool2_Add_Click(object sender, EventArgs e)
        {
            dtDetailsAddRow();
        }

        private void tool2_Delete_Click(object sender, EventArgs e)
        {
            this.myDataGridViewDetails.Rows.RemoveAt(this.myDataGridViewDetails.CurrentRow.Index);
            setTool2Enabled();
        }

        private void tool2_BOM_Click(object sender, EventArgs e)
        {
            #region 判断手册编号是否存在
            if (this.myDataGridViewDetails.RowCount == 0) return;
            if (rowHead["手册id"]==DBNull.Value)
            {
                SysMessage.InformationMsg("手册资料还未保存，请先保存手册资料再执行该操作！");
                return;
            }
            if (rowHead["手册编号"].ToString() == "")
            {
                SysMessage.InformationMsg("手册编号为空，不允许执行该操作！");
                return;
            }
            #endregion

            #region 判断是否已经有打开的BOM窗体
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormManualBOM")
                {
                    FormManualBOM orderBomForm = (FormManualBOM)childFrm;
                    if (orderBomForm.mIntID == Convert.ToInt32(rowHead["手册id"])
                        && orderBomForm.mnPId == Convert.ToInt32(this.myDataGridViewDetails.CurrentRow.Cells["出口成品id"].Value))
                    {
                        childFrm.Activate();
                        return;
                    }
                }
            }
            #endregion

            #region 打开BOM窗体
            FormManualBOM formBOM = new FormManualBOM();
            formBOM.mIntID = Convert.ToInt32(rowHead["手册id"]);
            formBOM.mstrNo = rowHead["手册编号"].ToString();
            formBOM.mnPId = Convert.ToInt32(this.myDataGridViewDetails.CurrentRow.Cells["出口成品id"].Value);
            formBOM.mstrName = this.myDataGridViewDetails.CurrentRow.Cells["品名规格型号"].Value.ToString();
            formBOM.MdiParent = this.MdiParent;
            formBOM.Show();
            #endregion
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
            newRow["序号"] = dtDetails.Rows.Count + 1;
            newRow["币种"] = "USD";
            newRow["征免"] = "征免";
            dtDetails.Rows.Add(newRow);
            setTool2Enabled();
        }
        #endregion
        
        #region 进口料件tool
        private void tool3_First_Click(object sender, EventArgs e)
        {
            this.myDataGridViewDetails2.ClearSelection();
            this.myDataGridViewDetails2.Rows[0].Selected = true;
            this.myDataGridViewDetails2.CurrentCell = this.myDataGridViewDetails2.Rows[0].Cells[gstrDetailFirstField2];
            setTool3Enabled();
        }

        private void tool3_Up_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.myDataGridViewDetails2.CurrentRow.Index;
            this.myDataGridViewDetails2.ClearSelection();
            this.myDataGridViewDetails2.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewDetails2.CurrentCell = this.myDataGridViewDetails2.Rows[iSelectRow - 1].Cells[gstrDetailFirstField2];
            setTool3Enabled();
        }

        private void tool3_Down_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.myDataGridViewDetails2.CurrentRow.Index;
            this.myDataGridViewDetails2.ClearSelection();
            this.myDataGridViewDetails2.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewDetails2.CurrentCell = this.myDataGridViewDetails2.Rows[iSelectRow + 1].Cells[gstrDetailFirstField2];
            setTool3Enabled();
        }

        private void tool3_End_Click(object sender, EventArgs e)
        {
            this.myDataGridViewDetails2.ClearSelection();
            this.myDataGridViewDetails2.Rows[this.myDataGridViewDetails2.RowCount - 1].Selected = true;
            this.myDataGridViewDetails2.CurrentCell = this.myDataGridViewDetails2.Rows[this.myDataGridViewDetails2.RowCount - 1].Cells[gstrDetailFirstField2];
            setTool3Enabled();
        }

        private void tool3_Add_Click(object sender, EventArgs e)
        {
            dtDetailsAddRow2();
        }

        private void tool3_Delete_Click(object sender, EventArgs e)
        {
            this.myDataGridViewDetails2.Rows.RemoveAt(this.myDataGridViewDetails2.CurrentRow.Index);
            setTool3Enabled();
        }
        /// <summary>
        /// 设置进口料件tools的按钮是否可用
        /// </summary>
        public void setTool3Enabled()
        {
            if (dtDetails2 != null && dtDetails2.Rows.Count > 0)
            {
                //如果总行数为1时，则笔数移动按钮都为不可编辑
                if (dtDetails2.Rows.Count == 1)
                {
                    this.tool3_First.Enabled = false;
                    this.tool3_Up.Enabled = false;
                    this.tool3_Down.Enabled = false;
                    this.tool3_End.Enabled = false;
                }
                else
                {
                    //如果当前行索引为0
                    if (this.myDataGridViewDetails2.CurrentRow == null) return;
                    if (this.myDataGridViewDetails2.CurrentRow.Index == 0)
                    {
                        this.tool3_First.Enabled = false;
                        this.tool3_Up.Enabled = true;
                        this.tool3_Down.Enabled = true;
                        this.tool3_End.Enabled = true;
                    }
                    else if (this.myDataGridViewDetails2.CurrentRow.Index == this.myDataGridViewDetails2.RowCount - 1)  //如果行索引为最后一行
                    {
                        this.tool3_First.Enabled = true;
                        this.tool3_Up.Enabled = true;
                        this.tool3_Down.Enabled = false;
                        this.tool3_End.Enabled = false;
                    }
                    else
                    {
                        this.tool3_First.Enabled = true;
                        this.tool3_Up.Enabled = true;
                        this.tool3_Down.Enabled = true;
                        this.tool3_End.Enabled = true;
                    }
                }

                this.tool3_Delete.Enabled = true;
            }
            else
            {
                this.tool3_First.Enabled = false;
                this.tool3_Up.Enabled = false;
                this.tool3_Down.Enabled = false;
                this.tool3_End.Enabled = false;

                this.tool3_Delete.Enabled = false;
            }
        }
        /// <summary>
        /// 明细增加一条记录
        /// </summary>
        public void dtDetailsAddRow2()
        {
            DataRow newRow = dtDetails2.NewRow();
            newRow["序号"] = dtDetails2.Rows.Count + 1;
            newRow["币种"] = "USD";
            dtDetails2.Rows.Add(newRow);
            setTool3Enabled();
        }
        #endregion

        #region 表头控件事件 
        private void txt_手册编号_TextChanged(object sender, EventArgs e)
        {
            txt_手册编号2.Text = txt_手册编号.Text;
            txt_手册编号3.Text = txt_手册编号.Text;
        }
        //文本控件值变化后同步到rowHead中
        private void txt_Validated(object sender, EventArgs e)
        {
            myTextBox txtBox = (myTextBox)sender;
            string fieldName = txtBox.Name.Replace("txt_","");
            if (rowHead[fieldName].ToString() != txtBox.Text)
            {
                rowHead[fieldName] = txtBox.Text;
            }
        }
        //日期控件值变化后同步到rowHead中
        private void date_有效期限_ValueChanged(object sender, EventArgs e)
        {
            myDateTimePicker dtPicker = (myDateTimePicker)sender;
            string fieldName = dtPicker.Name.Replace("date_","");
            if (Convert.ToDateTime(rowHead[fieldName]) != dtPicker.Value)
            {
                rowHead[fieldName] = dtPicker.Value;
            }
        }
        //文本控件值变化时验证
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            myTextBox txtBox = (myTextBox)sender;
            string fieldName = txtBox.Name.Replace("txt_", "");
            string strSQL = string.Empty;
            IDataAccess dataAccess = null;
            switch (fieldName)
            {
                case "手册编号":
                    #region 手册编号
                    if (rowHead.RowState == DataRowState.Added)
                    {
                        strSQL = string.Format("SELECT 手册id FROM 手册资料表 WHERE 手册编号 ={0}", StringTools.SqlQ(txtBox.Text));
                        dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                        dataAccess.Open();
                        DataTable dtManual = dataAccess.GetTable(strSQL.ToString(), null);
                        dataAccess.Close();
                        if (dtManual.Rows.Count > 0)
                        {
                            SysMessage.InformationMsg("手册编号已经存在，请重新输入！");
                            e.Cancel = true;
                            txtBox.Focus();
                        }
                    }
                    break;
                    #endregion
                case "经营单位":
                    #region 经营单位
                    strSQL = string.Format("帮助录入查询 {0},0", StringTools.SqlQ(txtBox.Text));
                    dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                    dataAccess.Open();
                    DataTable dt经营单位 = dataAccess.GetTable(strSQL.ToString(), null);
                    dataAccess.Close();
                    DataRow selectRow经营单位 = null;
                    if (dt经营单位.Rows.Count == 0)
                    {
                        SysMessage.InformationMsg("此经营单位不存在！");
                        e.Cancel = true;
                        txtBox.Focus();
                    }
                    else if (dt经营单位.Rows.Count == 1)
                    {
                        selectRow经营单位 = dt经营单位.Rows[0];
                    }
                    else if (dt经营单位.Rows.Count > 1)
                    {
                        FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                        formSelect.strFormText = "选择经营单位";
                        formSelect.dtData = dt经营单位;
                        if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            selectRow经营单位 = formSelect.returnRow;
                        }
                        else
                        {
                            e.Cancel = true;
                            txtBox.Focus();
                        }
                    }
                    if (selectRow经营单位 != null)
                    {
                        txtBox.Text = selectRow经营单位["c_name"].ToString();
                        txt_收货单位.Text = selectRow经营单位["c_name"].ToString();
                        txt_收货单位编码.Text = selectRow经营单位["com_Code"].ToString();
                        txt_企业地址.Text = selectRow经营单位["C_Address"].ToString();
                        txt_联系人.Text = selectRow经营单位["linkman"].ToString();
                        txt_联系电话.Text = selectRow经营单位["Tel1"].ToString();
                        rowHead["经营单位"] = selectRow经营单位["c_name"];
                        rowHead["收货单位"] = selectRow经营单位["c_name"];
                        rowHead["收货单位编码"] = selectRow经营单位["com_Code"];
                        rowHead["企业地址"] = selectRow经营单位["C_Address"];
                        rowHead["联系人"] = selectRow经营单位["linkman"];
                        rowHead["联系电话"] = selectRow经营单位["Tel1"];
                    }
                    break;
                    #endregion
                case "收货单位":
                    #region 收货单位
                    strSQL = string.Format("帮助录入查询 {0},0", StringTools.SqlQ(txtBox.Text));
                    dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                    dataAccess.Open();
                    DataTable dt收货单位 = dataAccess.GetTable(strSQL.ToString(), null);
                    dataAccess.Close();
                    DataRow selectRow收货单位 = null;
                    if (dt收货单位.Rows.Count == 0)
                    {
                        SysMessage.InformationMsg("此收货单位不存在！");
                        e.Cancel = true;
                        txtBox.Focus();
                    }
                    else if (dt收货单位.Rows.Count == 1)
                    {
                        selectRow收货单位 = dt收货单位.Rows[0];
                    }
                    else if (dt收货单位.Rows.Count > 1)
                    {
                        FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                        formSelect.strFormText = "选择收货单位";
                        formSelect.dtData = dt收货单位;
                        if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            selectRow收货单位 = formSelect.returnRow;
                        }
                        else
                        {
                            e.Cancel = true;
                            txtBox.Focus();
                        }
                    }
                    if (selectRow收货单位 != null)
                    {
                        txtBox.Text = selectRow收货单位["c_name"].ToString();
                        txt_收货单位.Text = selectRow收货单位["c_name"].ToString();
                        txt_收货单位编码.Text = selectRow收货单位["com_Code"].ToString();
                        txt_企业地址.Text = selectRow收货单位["C_Address"].ToString();
                        txt_联系人.Text = selectRow收货单位["linkman"].ToString();
                        txt_联系电话.Text = selectRow收货单位["Tel1"].ToString();
                        rowHead["经营单位"] = selectRow收货单位["c_name"];
                        rowHead["收货单位"] = selectRow收货单位["c_name"];
                        rowHead["收货单位编码"] = selectRow收货单位["com_Code"];
                        rowHead["企业地址"] = selectRow收货单位["C_Address"];
                        rowHead["联系人"] = selectRow收货单位["linkman"];
                        rowHead["联系电话"] = selectRow收货单位["Tel1"];
                    }
                    break;
                    #endregion
                case "外商公司":
                    #region 外商公司
                    strSQL = string.Format("帮助录入查询 {0},2", StringTools.SqlQ(txtBox.Text));
                    dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                    dataAccess.Open();
                    DataTable dt外商公司 = dataAccess.GetTable(strSQL.ToString(), null);
                    dataAccess.Close();
                    DataRow selectRow外商公司 = null;
                    if (dt外商公司.Rows.Count == 0)
                    {
                        SysMessage.InformationMsg("此外商公司不存在！");
                        e.Cancel = true;
                        txtBox.Focus();
                    }
                    else if (dt外商公司.Rows.Count == 1)
                    {
                        selectRow外商公司 = dt外商公司.Rows[0];
                    }
                    else if (dt外商公司.Rows.Count > 1)
                    {
                        FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                        formSelect.strFormText = "选择外商公司";
                        formSelect.dtData = dt外商公司;
                        if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            selectRow外商公司 = formSelect.returnRow;
                        }
                        else
                        {
                            e.Cancel = true;
                            txtBox.Focus();
                        }
                    }
                    if (selectRow外商公司 != null)
                    {
                        txtBox.Text = selectRow外商公司["c_name"].ToString();
                        rowHead["外商公司"] = selectRow外商公司["c_name"];
                    }
                    break;
                    #endregion
            }
        }
        //工缴费率
        private void txt_工缴费率_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal.Parse(txt_工缴费率.Text.Trim());
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(ex.Message);
                e.Cancel = true;
            }
        }
        #endregion

        #region 出口成品GRID事件
        private void myDataGridViewDetails_SelectionChanged(object sender, EventArgs e)
        {
            setTool2Enabled();
        }

        private void myDataGridViewDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridKeyEnter(dgv, cell, false);
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

        private void myDataGridViewDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            myDataGridView dgv = (myDataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "序号" || colName == "数量" || colName == "单价")
                e.Cancel = false;
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
                case "产品编号"://跳转到"商品编号"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品编号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品编号"://跳转到"品名规格型号"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["品名规格型号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "品名规格型号":  //跳转到"数量"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["数量", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "数量":   //跳转到"单位"
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
                case "单位":   //跳转到"单价"
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
                case "币种":   //跳转到"总价"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["总价", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "总价":   //跳转到"征免" 
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["征免", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "征免":   //跳转到"备注"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["备注", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "备注":   //跳转到"序号"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        validate备注(dgv, cell);
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
        private void validate数量(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["数量"].Value = DBNull.Value;
                dgv.Rows[cell.RowIndex].Cells["总价"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                    if (dgv.Rows[cell.RowIndex].Cells["单价"].Value != DBNull.Value)
                    {
                        dgv.Rows[cell.RowIndex].Cells["总价"].Value = Convert.ToDecimal(cell.EditedFormattedValue) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["单价"].Value);
                    }
                    (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = DBNull.Value;
                    dgv.Rows[cell.RowIndex].Cells["总价"].Value = DBNull.Value;
                }
            }
        }
        private void validate单价(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["单价"].Value = DBNull.Value;
                dgv.Rows[cell.RowIndex].Cells["总价"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["单价"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                    if (dgv.Rows[cell.RowIndex].Cells["数量"].Value != DBNull.Value)
                    {
                        dgv.Rows[cell.RowIndex].Cells["总价"].Value = Convert.ToDecimal(cell.EditedFormattedValue) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["数量"].Value);
                    }
                    (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["单价"].Value = DBNull.Value;
                    dgv.Rows[cell.RowIndex].Cells["总价"].Value = DBNull.Value;
                }
            }
        }
        private void validate备注(myDataGridView dgv, DataGridViewCell cell)
        {
            dgv["备注", cell.RowIndex].Value = cell.EditedFormattedValue;
            //如果当前行的商品编号为空，则跳转到当前行的商品编号
            if (dgv.Rows[cell.RowIndex].Cells["商品编号"].Value == DBNull.Value
                || dgv.Rows[cell.RowIndex].Cells["商品编号"].Value.ToString().Trim() == "")
            {
                dgv.CurrentCell = dgv["商品编号", cell.RowIndex];
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

        #region 进口料件GRID事件
        private void myDataGridViewDetails2_SelectionChanged(object sender, EventArgs e)
        {
            setTool3Enabled();
        }      

        private void myDataGridViewDetails2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            myDataGridView dgv = (myDataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "序号" || colName == "数量" || colName == "单价")
                e.Cancel = false;
        }

        private void myDataGridViewDetails2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridKeyEnter2(dgv, cell, false);
        }

        private void myDataGridViewDetails2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == SystemConst.GridKeysEnter)
            {
                myDataGridView dgv = sender as myDataGridView;
                DataGridViewCell cell = dgv.CurrentCell;
                GridKeyEnter2(dgv, cell, true);
            }
        }
        private void GridKeyEnter2(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
        {
            if (!bCellKeyPress) return;
            string colName = dgv.Columns[cell.ColumnIndex].Name;
            switch (colName)
            {
                case "序号":   //跳转到"商品编号"  
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
                            validate序号2(dgv, cell);
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
                            validate序号2(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "商品编号"://跳转到"品名规格型号"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["品名规格型号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "品名规格型号":  //跳转到"数量"
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["数量", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "数量":   //跳转到"单位"
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
                            validate数量2(dgv, cell);
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
                            validate数量2(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "单位":   //跳转到"单价"
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
                            validate单价2(dgv, cell);
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
                            validate单价2(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "币种":   //跳转到"总价"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["总价", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "总价":   //跳转到"征免" 
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["征免", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "征免":   //跳转到"序号"  
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        validate征免2(dgv, cell);
                        (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                    }
                    #endregion
                    break;
            }
        }
        private void validate序号2(myDataGridView dgv, DataGridViewCell cell)
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
        private void validate数量2(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["数量"].Value = DBNull.Value;
                dgv.Rows[cell.RowIndex].Cells["总价"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                    if (dgv.Rows[cell.RowIndex].Cells["单价"].Value != DBNull.Value)
                    {
                        dgv.Rows[cell.RowIndex].Cells["总价"].Value = Convert.ToDecimal(cell.EditedFormattedValue) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["单价"].Value);
                    }
                    (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = DBNull.Value;
                    dgv.Rows[cell.RowIndex].Cells["总价"].Value = DBNull.Value;
                }
            }
        }
        private void validate单价2(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["单价"].Value = DBNull.Value;
                dgv.Rows[cell.RowIndex].Cells["总价"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["单价"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                    if (dgv.Rows[cell.RowIndex].Cells["数量"].Value != DBNull.Value)
                    {
                        dgv.Rows[cell.RowIndex].Cells["总价"].Value = Convert.ToDecimal(cell.EditedFormattedValue) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["数量"].Value);
                    }
                    (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["单价"].Value = DBNull.Value;
                    dgv.Rows[cell.RowIndex].Cells["总价"].Value = DBNull.Value;
                }
            }
        }
        private void validate征免2(myDataGridView dgv, DataGridViewCell cell)
        {
            dgv["征免", cell.RowIndex].Value = cell.EditedFormattedValue;
            //如果当前行的商品编号为空，则跳转到当前行的商品编号
            if (dgv.Rows[cell.RowIndex].Cells["商品编号"].Value == DBNull.Value
                || dgv.Rows[cell.RowIndex].Cells["商品编号"].Value.ToString().Trim() == "")
            {
                dgv.CurrentCell = dgv["商品编号", cell.RowIndex];
            }
            else
            {
                //否则跳转到下一行的产品编号，如果是最后一行，则新增一行
                if (cell.RowIndex == dgv.Rows.Count - 1)
                {
                    dtDetailsAddRow2();
                    dgv.CurrentCell = dgv["商品编号", cell.RowIndex + 1];
                }
                else
                {
                    dgv.CurrentCell = dgv["商品编号", cell.RowIndex + 1];
                }
            }
        }
        #endregion


    }
}
