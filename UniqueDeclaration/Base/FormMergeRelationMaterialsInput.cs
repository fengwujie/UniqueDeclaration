using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration.Base
{
    public partial class FormMergeRelationMaterialsInput : UniqueDeclarationBaseForm.FormBase
    {
        public FormMergeRelationMaterialsInput()
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
        #endregion

        #region 窗体事件
        private void FormMergeRelationMaterialsInput_Load(object sender, EventArgs e)
        {
            InitControlData();
            LoadDataSource();
            //InitGrid();
        }

        private void FormMergeRelationMaterialsInput_FormClosing(object sender, FormClosingEventArgs e)
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
        /// 初始化界面上某些控件的初始值
        /// </summary>
        public void InitControlData()
        {
            cbox_主料.Items.Add("主料");
            cbox_主料.Items.Add("非主料");
            cbox_主料.SelectedIndex = 0;

            string strSQL = "SELECT top 2 手册编号 as 电子帐册号,手册编号 as 电子帐册号2 FROM 手册资料表 order by 有效期限 desc";
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dt电子帐册号 = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            cbox_电子帐册号.InitialData(dt电子帐册号, "电子帐册号", "电子帐册号2", 0);
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
            string strSQL = string.Format("select * from 归并后料件清单 where 归并后料件id ={0}", giOrderID);
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
                rowHead["主料"] = cbox_主料.SelectedText;
                rowHead["电子帐册号"] = cbox_电子帐册号.SelectedValue;
                fillControl(rowHead);
            }
        }
        /// <summary>
        /// 加载表身出口成品数据
        /// </summary>
        public void LoadDataSourceDetails()
        {
            string strSQL = string.Format("商品归并表录入查询 {0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
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
                if (rowHead["产品编号"].ToString().Length > 0)
                {
                    bModify = true;
                }
            }
            //如果表头没异动，再判断表身是否有异动
            if (!bModify)
            {
                //归并前料件id
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
                            if (row["归并前料件id", DataRowVersion.Original] != DBNull.Value)
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
            if (row.Table.Columns.Contains("序号"))
            {
                txt_序号.Text = row["序号"].ToString();
            }
            if (row.Table.Columns.Contains("主料"))
            {
                cbox_主料.SelectedText = row["主料"].ToString();
            }
            if (row.Table.Columns.Contains("电子帐册号"))
            {
                cbox_电子帐册号.SelectedValue = row["电子帐册号"].ToString();
            }
            if (row.Table.Columns.Contains("产品编号"))
            {
                txt_产品编号.Text = row["产品编号"].ToString();
            }
            if (row.Table.Columns.Contains("商品编码"))
            {
                txt_商品编码.Text = row["商品编码"].ToString();
            }
            if (row.Table.Columns.Contains("商品名称"))
            {
                txt_商品名称.Text = row["商品名称"].ToString();
            }
            if (row.Table.Columns.Contains("商品规格"))
            {
                txt_商品规格.Text = row["商品规格"].ToString();
            }
            if (row.Table.Columns.Contains("产销国"))
            {
                txt_产销国.Text = row["产销国"].ToString();
            }
            if (row.Table.Columns.Contains("损耗率"))
            {
                txt_损耗率.Text = row["损耗率"].ToString();
            }
            if (row.Table.Columns.Contains("单价"))
            {
                txt_单价.Text = row["单价"].ToString();
            }
            if (row.Table.Columns.Contains("币种"))
            {
                txt_币种.Text = row["币种"].ToString();
            }
            if (row.Table.Columns.Contains("计量单位"))
            {
                txt_计量单位.Text = row["计量单位"].ToString();
            }
            if (row.Table.Columns.Contains("法定单位"))
            {
                txt_法定单位.Text = row["法定单位"].ToString();
            }
            if (row.Table.Columns.Contains("换算因子"))
            {
                txt_换算因子.Text = row["换算因子"].ToString();
            }
            if (row.Table.Columns.Contains("四位大类序号"))
            {
                txt_四位大类序号.Text = row["四位大类序号"].ToString();
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
                if (txt_产品编号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg("产品编号不能为空！");
                    txt_产品编号.Focus();
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
                            StringTools.SqlQ(Convert.ToDateTime(rowHead["有效期限"]).ToShortDateString()),
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
                            StringTools.SqlQ(Convert.ToDateTime(rowHead["审批日期"]).ToShortDateString()),
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

                        #region 新增明细数据
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
                            StringTools.SqlQ(Convert.ToDateTime(rowHead["有效期限"]).ToShortDateString()),
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
                            StringTools.SqlQ(Convert.ToDateTime(rowHead["审批日期"]).ToShortDateString()),
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

        #region tool
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
            if (rowHead["手册id"] == DBNull.Value)
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

    }
}
