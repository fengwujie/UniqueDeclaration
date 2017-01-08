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
    public partial class FormMaterialsInput : UniqueDeclarationBaseForm.FormBase
    {
        public FormMaterialsInput()
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
        #endregion

        #region 窗体事件
        private void FormMaterialsInput_Load(object sender, EventArgs e)
        {
            InitControlData();
            LoadDataSource();
        }

        private void FormMaterialsInput_FormClosing(object sender, FormClosingEventArgs e)
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
            this.cbox_料件类别.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Manufacture, "SELECT [料件类别],[料件类别说明] FROM [料件类别表]", "料件类别", "料件类别说明", -1);
            this.cbox_报关类别.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Manufacture, "select 料件报关分类 as 报关类别 from 料件报关分类 order by 料件报关分类", "报关类别", "报关类别", -1);
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("采购区域", typeof(string));
            dtTemp.Columns.Add("采购区域名称", typeof(string));
            DataRow newRow1 = dtTemp.NewRow();
            newRow1["采购区域"] = "国内";
            newRow1["采购区域名称"] = "国内";
            dtTemp.Rows.Add(newRow1);
            DataRow newRow2 = dtTemp.NewRow();
            newRow2["采购区域"] = "国外";
            newRow2["采购区域名称"] = "国外";
            dtTemp.Rows.Add(newRow2);
            this.cbox_采购区域.InitialData(dtTemp, "采购区域", "采购区域名称", -1);

            datetime_料件建档日期.Value =DateTime.Now;
            datetime_料件建档日期.Checked = false;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadDataSource()
        {
            string strSQL = string.Format("SELECT * FROM 料件资料表 WHERE 料件id = {0}", giOrderID);
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
                datetime_料件建档日期.Value = DateTime.Now;
                datetime_料件建档日期.Checked = false;
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
                if (rowHead["手册编号"].ToString().Length > 0)
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
            //,[料件型号],[显示型号],[电子帐册型号],[显示型号L],[料件名],[料件建档日期],[仓库数量1]
            //,[仓库单位1],[仓库数量2],[仓库单位2],[单位数量],[料件单位],[领料数量1],[领料单位1]
            //,[领料数量2],[领料单位2],[安全存量],[料件类别],[料件存放位置],[料件备注],[计算库存]
            //,[料件规格],[报关类别],[换算数量],[换算单位],[采购区域],[保税],[所属仓库],[料件项号]
            //,[归并序号],[仓位],[料件基本编号]
            if (row.Table.Columns.Contains("料件型号"))
            {
                txt_料件型号.Text = row["料件型号"].ToString();
            }
            if (row.Table.Columns.Contains("显示型号"))
            {
                txt_显示型号.Text = row["显示型号"].ToString();
            }
            if (row.Table.Columns.Contains("电子帐册型号"))
            {
                txt_电子帐册型号.Text = row["电子帐册型号"].ToString();
            }
            if (row.Table.Columns.Contains("显示型号"))
            {
                txt_显示型号.Text = row["显示型号"].ToString();
            }
            if (row.Table.Columns.Contains("料件建档日期"))
            {
                datetime_料件建档日期.Value = Convert.ToDateTime(row["料件建档日期"]);
            }
            if (row.Table.Columns.Contains("料件名"))
            {
                txt_料件名.Text = row["料件名"].ToString();
            }
            if (row.Table.Columns.Contains("仓库数量1"))
            {
                txt_仓库数量1.Text = row["仓库数量1"].ToString();
            }
            if (row.Table.Columns.Contains("仓库单位1"))
            {
                txt_仓库单位1.Text = row["仓库单位1"].ToString();
            }
            if (row.Table.Columns.Contains("仓库数量2"))
            {
                txt_仓库数量2.Text = row["仓库数量2"].ToString();
            }
            if (row.Table.Columns.Contains("仓库单位2"))
            {
                txt_仓库单位2.Text = row["仓库单位2"].ToString();
            }
            if (row.Table.Columns.Contains("单位数量"))
            {
                txt_单位数量.Text = row["单位数量"].ToString();
            }
            if (row.Table.Columns.Contains("料件单位"))
            {
                txt_料件单位.Text = row["料件单位"].ToString();
            }
            if (row.Table.Columns.Contains("领料数量1"))
            {
                txt_领料数量1.Text = row["领料数量1"].ToString();
            }
            if (row.Table.Columns.Contains("领料单位1"))
            {
                txt_领料单位1.Text = row["领料单位1"].ToString();
            }
            if (row.Table.Columns.Contains("领料数量2"))
            {
                txt_领料数量2.Text = row["领料数量2"].ToString();
            }
            if (row.Table.Columns.Contains("领料单位2"))
            {
                txt_领料单位2.Text = row["领料单位2"].ToString();
            }
            if (row.Table.Columns.Contains("安全存量"))
            {
                txt_安全存量.Text = row["安全存量"].ToString();
            }
            if (row.Table.Columns.Contains("料件类别"))
            {
                cbox_料件类别.SelectedValue = row["料件类别"].ToString();
            }
            if (row.Table.Columns.Contains("报关类别"))
            {
                cbox_报关类别.SelectedValue = row["报关类别"].ToString();
            }
            if (row.Table.Columns.Contains("采购区域"))
            {
                cbox_采购区域.SelectedValue = row["采购区域"].ToString();
            }
            if (row.Table.Columns.Contains("料件存放位置"))
            {
                txt_料件存放位置.Text = row["料件存放位置"].ToString();
            }
            if (row.Table.Columns.Contains("料件备注"))
            {
                txt_料件备注.Text = row["料件备注"].ToString();
            }
            if (row.Table.Columns.Contains("计算库存"))
            {
                chk_计算库存.Checked =Convert.ToBoolean( row["计算库存"]);
            }
            //if (row.Table.Columns.Contains("料件规格"))
            //{
            //    txt_料件规格.Text = row["料件规格"].ToString();
            //}
            if (row.Table.Columns.Contains("换算数量"))
            {
                txt_换算数量.Text = row["换算数量"].ToString();
            }
            if (row.Table.Columns.Contains("换算单位"))
            {
                txt_换算单位.Text = row["换算单位"].ToString();
            }
            //if (row.Table.Columns.Contains("保税"))
            //{
            //    txt_保税.Text = row["保税"].ToString();
            //}
            if (row.Table.Columns.Contains("所属仓库"))
            {
                txt_所属仓库.Text = row["所属仓库"].ToString();
            }
            //if (row.Table.Columns.Contains("料件项号"))
            //{
            //    txt_料件项号.Text = row["料件项号"].ToString();
            //}
            //if (row.Table.Columns.Contains("归并序号"))
            //{
            //    txt_归并序号.Text = row["归并序号"].ToString();
            //}
            //if (row.Table.Columns.Contains("仓位"))
            //{
            //    txt_仓位.Text = row["仓位"].ToString();
            //}
            //if (row.Table.Columns.Contains("料件基本编号"))
            //{
            //    txt_料件基本编号.Text = row["料件基本编号"].ToString();
            //}
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
                if (txt_料件型号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！",lab_料件型号.Text));
                    txt_料件型号.Focus();
                    return false;
                }
                if (txt_显示型号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_显示型号.Text));
                    txt_显示型号.Focus();
                    return false;
                }
                if (txt_料件名.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_料件名.Text));
                    txt_料件名.Focus();
                    return false;
                }
                if (txt_仓库数量1.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_仓库数量1.Text));
                    txt_仓库数量1.Focus();
                    return false;
                }
                if (txt_仓库单位1.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_仓库单位1.Text));
                    txt_仓库单位1.Focus();
                    return false;
                }
                if (txt_仓库数量2.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_仓库数量2.Text));
                    txt_仓库数量2.Focus();
                    return false;
                }
                if (txt_仓库单位2.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_仓库单位2.Text));
                    txt_仓库单位2.Focus();
                    return false;
                }
                if (txt_单位数量.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_单位数量.Text));
                    txt_单位数量.Focus();
                    return false;
                }
                if (txt_领料数量1.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_领料数量1.Text));
                    txt_领料数量1.Focus();
                    return false;
                }
                if (txt_领料单位1.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_领料单位1.Text));
                    txt_领料单位1.Focus();
                    return false;
                }
                if (txt_领料数量2.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_领料数量2.Text));
                    txt_领料数量2.Focus();
                    return false;
                }
                if (txt_领料单位2.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_领料单位2.Text));
                    txt_领料单位2.Focus();
                    return false;
                }
                if (txt_安全存量.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_安全存量.Text));
                    txt_安全存量.Focus();
                    return false;
                }
                if (cbox_料件类别.SelectedValue == null || cbox_料件类别.SelectedValue.ToString() == "")
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_料件类别.Text));
                    cbox_料件类别.Focus();
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
                        strBuilder.AppendLine(@"INSERT INTO [手册资料表]([料件型号],[显示型号],[电子帐册型号],[显示型号L],[料件名],[料件建档日期],[仓库数量1],[仓库单位1],
                                                [仓库数量2],[仓库单位2],[单位数量],[领料数量1],[领料单位1] ,[领料数量2],[领料单位2],[安全存量],[料件类别],
                                                [料件存放位置],[料件备注],[计算库存],[报关类别],[换算数量],[换算单位],[采购区域],[所属仓库])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24})",
                            rowHead["料件型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["料件型号"].ToString()),
                            rowHead["显示型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["显示型号"].ToString()),
                            rowHead["电子帐册型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["电子帐册型号"].ToString()),
                            rowHead["显示型号L"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["显示型号L"].ToString()),
                            rowHead["料件名"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["料件名"].ToString()),
                            rowHead["料件建档日期"] == DBNull.Value ? "NULL" : StringTools.SqlQ(Convert.ToDateTime(rowHead["料件建档日期"]).ToShortDateString()),
                            rowHead["仓库数量1"] == DBNull.Value ? "NULL" : rowHead["仓库数量1"],
                            rowHead["仓库单位1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["仓库单位1"].ToString()),
                            rowHead["仓库数量2"] == DBNull.Value ? "NULL" : rowHead["仓库数量2"],
                            rowHead["仓库单位2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["仓库单位2"].ToString()),
                            rowHead["单位数量"] == DBNull.Value ? "NULL" : rowHead["单位数量"],
                            rowHead["领料数量1"] == DBNull.Value ? "NULL" : rowHead["领料数量1"],
                            rowHead["领料单位1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["领料单位1"].ToString()),
                            rowHead["领料数量2"] == DBNull.Value ? "NULL" : rowHead["领料数量2"],
                            rowHead["领料单位2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["领料单位2"].ToString()),
                            rowHead["安全存量"] == DBNull.Value ? "NULL" : rowHead["安全存量"],
                            rowHead["料件类别"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["料件类别"].ToString()),
                            rowHead["料件存放位置"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["料件存放位置"].ToString()),
                            rowHead["料件备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["料件备注"].ToString()),
                            rowHead["计算库存"] == DBNull.Value ? "NULL" : Convert.ToBoolean(rowHead["计算库存"])==true ? "1" :"0" ,
                            rowHead["报关类别"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["报关类别"].ToString()),
                            rowHead["换算数量"] == DBNull.Value ? "NULL" : rowHead["换算数量"],
                            rowHead["采购区域"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["采购区域"].ToString()),
                            rowHead["所属仓库"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["所属仓库"].ToString()));
                        strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object 料件id = dtInsert.Rows[0][0]; // dataAccess.ExecScalar(strBuilder.ToString(), null);
                        rowHead["料件id"] = 料件id;
                        strBuilder.Clear();
                        #endregion
                        giOrderID = Convert.ToInt32(料件id);
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
                            strBuilder.AppendFormat(@"UPDATE [手册资料表] set [料件型号]={0},[显示型号]={1},[电子帐册型号]={2},[显示型号L]={3},[料件名]={4},[料件建档日期]={5},[仓库数量1]={6},[仓库单位1]={7},
                                                [仓库数量2]={8},[仓库单位2]={9},[单位数量]={10},[领料数量1]={11},[领料单位1]={12} ,[领料数量2]={13},[领料单位2]={14},[安全存量]={15},[料件类别]={16},
                                                [料件存放位置]={17},[料件备注]={18},[计算库存]={19},[报关类别]={20},[换算数量]={21},[换算单位]={22},[采购区域]={23},[所属仓库]={24} where 料件id={25}",
                             rowHead["料件型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["料件型号"].ToString()),
                            rowHead["显示型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["显示型号"].ToString()),
                            rowHead["电子帐册型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["电子帐册型号"].ToString()),
                            rowHead["显示型号L"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["显示型号L"].ToString()),
                            rowHead["料件名"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["料件名"].ToString()),
                            rowHead["料件建档日期"] == DBNull.Value ? "NULL" : StringTools.SqlQ(Convert.ToDateTime(rowHead["料件建档日期"]).ToShortDateString()),
                            rowHead["仓库数量1"] == DBNull.Value ? "NULL" : rowHead["仓库数量1"],
                            rowHead["仓库单位1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["仓库单位1"].ToString()),
                            rowHead["仓库数量2"] == DBNull.Value ? "NULL" : rowHead["仓库数量2"],
                            rowHead["仓库单位2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["仓库单位2"].ToString()),
                            rowHead["单位数量"] == DBNull.Value ? "NULL" : rowHead["单位数量"],
                            rowHead["领料数量1"] == DBNull.Value ? "NULL" : rowHead["领料数量1"],
                            rowHead["领料单位1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["领料单位1"].ToString()),
                            rowHead["领料数量2"] == DBNull.Value ? "NULL" : rowHead["领料数量2"],
                            rowHead["领料单位2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["领料单位2"].ToString()),
                            rowHead["安全存量"] == DBNull.Value ? "NULL" : rowHead["安全存量"],
                            rowHead["料件类别"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["料件类别"].ToString()),
                            rowHead["料件存放位置"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["料件存放位置"].ToString()),
                            rowHead["料件备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["料件备注"].ToString()),
                            rowHead["计算库存"] == DBNull.Value ? "NULL" : Convert.ToBoolean(rowHead["计算库存"]) == true ? "1" : "0",
                            rowHead["报关类别"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["报关类别"].ToString()),
                            rowHead["换算数量"] == DBNull.Value ? "NULL" : rowHead["换算数量"],
                            rowHead["采购区域"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["采购区域"].ToString()),
                            rowHead["所属仓库"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["所属仓库"].ToString()),
                            rowHead["料件id"]);
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

        #region tool1事件
        private void tool1_Add_Click(object sender, EventArgs e)
        {

        }

        private void tool1_Save_Click(object sender, EventArgs e)
        {

        }

        private void tool1_Close_Click(object sender, EventArgs e)
        {

        }
        #endregion

        //编号生成
        private void btnCreateNo_Click(object sender, EventArgs e)
        {

        }

    }
}
