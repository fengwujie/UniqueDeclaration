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
    public partial class FormFitInput : UniqueDeclarationBaseForm.FormBase
    {
        public FormFitInput()
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
        /// 文本控件失去焦点事件
        /// </summary>
        private bool btxt_LostFocus = false;
        #endregion

        #region 窗体事件
        private void FormFitInput_Load(object sender, EventArgs e)
        {
            InitControlData();
            LoadDataSource(); 
        }

        private void FormFitInput_FormClosing(object sender, FormClosingEventArgs e)
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
        /// 初始化界面上某些控件的初始值
        /// </summary>
        public void InitControlData()
        {
            datetime_配件建档日期.Value =DateTime.Now;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadDataSource()
        {
            string strSQL = string.Format("SELECT * FROM 配件资料表 WHERE 配件id = {0}", giOrderID);
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
                datetime_配件建档日期.Value = DateTime.Now;
                rowHead["配件建档日期"] = DateTime.Now;
                fillControl(rowHead);
            }
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
                if (rowHead["配件型号"].ToString().Length > 0)
                {
                    bModify = true;
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
            if (row.Table.Columns.Contains("编号"))
            {
                txt_编号.Text = row["编号"].ToString();
            }
            if (row.Table.Columns.Contains("电子帐册编号"))
            {
                txt_电子帐册编号.Text = row["电子帐册编号"].ToString();
            }
            if (row.Table.Columns.Contains("配件型号"))
            {
                txt_配件型号.Text = row["配件型号"].ToString();
            }
            if (row.Table.Columns.Contains("配件名"))
            {
                txt_配件名.Text = row["配件名"].ToString();
            }
            if (row.Table.Columns.Contains("配件建档日期"))
            {
                datetime_配件建档日期.Value = Convert.ToDateTime(row["配件建档日期"]);
            }
            if (row.Table.Columns.Contains("配件组别"))
            {
                txt_配件组别.Text = row["配件组别"].ToString();
            }
            if (row.Table.Columns.Contains("实际总重"))
            {
                txt_实际总重.Text = row["实际总重"].ToString();
            }
            if (row.Table.Columns.Contains("配件存放位置"))
            {
                txt_配件存放位置.Text = row["配件存放位置"].ToString();
            }
            if (row.Table.Columns.Contains("配件备注"))
            {
                txt_配件备注.Text = row["配件备注"].ToString();
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
                if (txt_配件型号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_配件型号.Text));
                    txt_配件型号.Focus();
                    return false;
                }
                if (txt_配件组别.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_配件组别.Text));
                    txt_配件组别.Focus();
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
                        strBuilder.AppendLine(@"INSERT INTO [配件资料表]([编号],[电子帐册编号],[配件型号],[配件名],[配件建档日期],[配件组别],[配件存放位置],[配件备注],[实际总重])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                            rowHead["编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["编号"].ToString()),
                            rowHead["电子帐册编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["电子帐册编号"].ToString()),
                            rowHead["配件型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件型号"].ToString()),
                            rowHead["配件型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件型号"].ToString()),
                            rowHead["配件建档日期"] == DBNull.Value ? "NULL" : StringTools.SqlQ(Convert.ToDateTime(rowHead["配件建档日期"]).ToString("yyyy-MM-dd HH:mm:ss")),
                            rowHead["配件组别"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件组别"].ToString()),
                            rowHead["配件存放位置"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件存放位置"].ToString()),
                            rowHead["配件存放位置"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件存放位置"].ToString()),
                            rowHead["配件备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件备注"].ToString()),
                            rowHead["实际总重"] == DBNull.Value ? "NULL" : rowHead["实际总重"]);
                        strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object 配件id = dtInsert.Rows[0][0]; // dataAccess.ExecScalar(strBuilder.ToString(), null);
                        rowHead["配件id"] = 配件id;
                        strBuilder.Clear();
                        #endregion
                        giOrderID = Convert.ToInt32(配件id);
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
                            strBuilder.AppendFormat(@"UPDATE [配件资料表] set [编号]={0},[电子帐册编号]={1},[配件型号]={2},[配件名]={3},[配件建档日期]={4},[配件组别]={5},
                                                            [配件存放位置]={6},[配件备注]={7},[实际总重]={8} where 配件id={9}",
                            rowHead["编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["编号"].ToString()),
                            rowHead["电子帐册编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["电子帐册编号"].ToString()),
                            rowHead["配件型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件型号"].ToString()),
                            rowHead["配件型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件型号"].ToString()),
                            rowHead["配件建档日期"] == DBNull.Value ? "NULL" : StringTools.SqlQ(Convert.ToDateTime(rowHead["配件建档日期"]).ToString("yyyy-MM-dd HH:mm:ss")),
                            rowHead["配件组别"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件组别"].ToString()),
                            rowHead["配件存放位置"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件存放位置"].ToString()),
                            rowHead["配件存放位置"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件存放位置"].ToString()),
                            rowHead["配件备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["配件备注"].ToString()),
                            rowHead["实际总重"] == DBNull.Value ? "NULL" : rowHead["实际总重"],
                            rowHead["配件id"]);
                            dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                            strBuilder.Clear();
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
                if (bSuccess && bShowSuccessMsg)
                {
                    SysMessage.InformationMsg("保存成功！");
                }
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

        #region tool事件
        //新增
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
        //保存
        private void tool1_Save_Click(object sender, EventArgs e)
        {
            Save(true);
        }
        //复制
        private void btnClone_Click(object sender, EventArgs e)
        {

        }
        //BOM结构
        private void tool1_BOM_Click(object sender, EventArgs e)
        {

        }
        //关闭
        private void tool1_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
