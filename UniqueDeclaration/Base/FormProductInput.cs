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
    public partial class FormProductInput : UniqueDeclarationBaseForm.FormBase
    {
        public FormProductInput()
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
        /// 是否触发产品类别下拉框事件
        /// </summary>
        private bool bcbox_SelectedIndexChanged = false;
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
            bcbox_SelectedIndexChanged = false;
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("产品类别", typeof(string));
            dtTemp.Columns.Add("产品类别名称", typeof(string));
            DataRow newRow1 = dtTemp.NewRow();
            newRow1["产品类别"] = "A";
            newRow1["产品类别名称"] = "A";
            dtTemp.Rows.Add(newRow1);
            DataRow newRow2 = dtTemp.NewRow();
            newRow2["产品类别"] = "B";
            newRow2["产品类别名称"] = "B";
            dtTemp.Rows.Add(newRow2);
            DataRow newRow3 = dtTemp.NewRow();
            newRow3["产品类别"] = "C";
            newRow3["产品类别名称"] = "C";
            dtTemp.Rows.Add(newRow3);
            DataRow newRow4 = dtTemp.NewRow();
            newRow4["产品类别"] = "D";
            newRow4["产品类别名称"] = "D";
            dtTemp.Rows.Add(newRow4);
            this.cbox_产品类别.InitialData(dtTemp, "产品类别", "产品类别名称", -1);
            bcbox_SelectedIndexChanged = true;
            datetime_产品建档日期.Value =DateTime.Now;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadDataSource()
        {
            string strSQL = string.Format("SELECT * FROM 产品资料表 WHERE 产品id = {0}", giOrderID);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtHead = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            bcbox_SelectedIndexChanged = false;
            if (dtHead.Rows.Count > 0)
            {
                rowHead = dtHead.Rows[0];
                fillControl(rowHead);
            }
            else
            {
                rowHead = dtHead.NewRow();
                dtHead.Rows.Add(rowHead);
                datetime_产品建档日期.Value = DateTime.Now;
                rowHead["产品建档日期"] = DateTime.Now;
                fillControl(rowHead);
            }
            bcbox_SelectedIndexChanged = true;
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
                if (rowHead["产品型号"].ToString().Length > 0)
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
                txt_编号.Text = row["编号"].ToString().Trim();
            }
            if (row.Table.Columns.Contains("电子帐册编号"))
            {
                txt_电子帐册编号.Text = row["电子帐册编号"].ToString().Trim();
            }
            if (row.Table.Columns.Contains("产品型号"))
            {
                txt_产品型号.Text = row["产品型号"].ToString();
            }
            if (row.Table.Columns.Contains("产品名"))
            {
                txt_产品名.Text = row["产品名"].ToString();
            }
            if (row.Table.Columns.Contains("产品建档日期"))
            {
                datetime_产品建档日期.Value = Convert.ToDateTime(row["产品建档日期"]);
            }
            if (row.Table.Columns.Contains("产品单位"))
            {
                txt_产品单位.Text = row["产品单位"].ToString();
            }
            if (row.Table.Columns.Contains("产品颜色"))
            {
                txt_产品颜色.Text = row["产品颜色"].ToString();
            }
            if (row.Table.Columns.Contains("产品类别"))
            {
                cbox_产品类别.SelectedValue = row["产品类别"].ToString();
            }
            if (row.Table.Columns.Contains("实际总重"))
            {
                txt_实际总重.Text = row["实际总重"].ToString();
            }
            if (row.Table.Columns.Contains("内部版本号"))
            {
                txt_内部版本号.Text = row["内部版本号"].ToString();
            }
            if (row.Table.Columns.Contains("企业版本号"))
            {
                txt_企业版本号.Text = row["企业版本号"].ToString();
            }
            if (row.Table.Columns.Contains("除数"))
            {
                txt_除数.Text = row["除数"].ToString();
            }
            if (row.Table.Columns.Contains("产品备注"))
            {
                txt_产品备注.Text = row["产品备注"].ToString();
            }
        }
        /// <summary>
        /// 保存数据，并返回是否保存成功
        /// <param name="bShowSuccessMsg">保存成功时是否弹出提示信息</param>
        /// </summary>
        public bool Save(bool bShowSuccessMsg)
        {
            Control control = this.ActiveControl;
            Control nextControl = this.GetNextControl(control, false);
            nextControl.Focus();
            bool bSuccess = true;
            try
            {
                #region 前期验证
                if (txt_产品型号.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_产品型号.Text));
                    txt_产品型号.Focus();
                    return false;
                }
                if (txt_产品单位.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_单位.Text));
                    txt_产品单位.Focus();
                    return false;
                }
                if (txt_产品颜色.Text.Trim().Length == 0)
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_颜色.Text));
                    txt_产品颜色.Focus();
                    return false;
                }
                if (cbox_产品类别.SelectedValue == null || cbox_产品类别.SelectedValue.ToString() == "")
                {
                    SysMessage.InformationMsg(string.Format("[{0}]不能为空！", lab_产品类别.Text));
                    cbox_产品类别.Focus();
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
                        strBuilder.AppendLine(@"INSERT INTO [产品资料表]([编号],[电子帐册编号],[产品型号],[产品名],[产品建档日期],[产品单位],[产品颜色],[产品备注],[实际总重],
                                                [产品类别],[除数],[内部版本号],[企业版本号])");
                        strBuilder.AppendFormat("VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},,{11},{12})",
                            rowHead["编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["编号"].ToString()),
                            rowHead["电子帐册编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["电子帐册编号"].ToString()),
                            rowHead["产品型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品型号"].ToString()),
                            rowHead["产品型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品型号"].ToString()),
                            rowHead["产品建档日期"] == DBNull.Value ? "NULL" : StringTools.SqlQ(Convert.ToDateTime(rowHead["产品建档日期"]).ToString("yyyy-MM-dd HH:mm:ss")),
                            rowHead["产品单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品单位"].ToString()),
                            rowHead["产品颜色"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品颜色"].ToString()),
                            rowHead["产品备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品备注"].ToString()),
                            rowHead["实际总重"] == DBNull.Value ? "NULL" : rowHead["实际总重"],
                            rowHead["产品类别"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品类别"].ToString()),
                            rowHead["除数"] == DBNull.Value ? "NULL" : rowHead["除数"],
                            rowHead["内部版本号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["内部版本号"].ToString()),
                            rowHead["企业版本号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["企业版本号"].ToString()));
                        strBuilder.AppendLine("select @@IDENTITY--新增预先录入订单时，自动生成的订单ID");
                        DataTable dtInsert = dataAccess.GetTable(strBuilder.ToString(), null);
                        object 产品id = dtInsert.Rows[0][0]; // dataAccess.ExecScalar(strBuilder.ToString(), null);
                        rowHead["产品id"] = 产品id;
                        strBuilder.Clear();
                        #endregion
                        giOrderID = Convert.ToInt32(产品id);
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
                            strBuilder.AppendFormat(@"UPDATE [产品资料表] set [编号]={0},[电子帐册编号]={1},[产品型号]={2},[产品名]={3},[产品建档日期]={4},[产品单位]={5},
                                        [产品颜色]={6},[产品备注]={7},[实际总重]={8},[产品类别]={9},[除数]={10},[内部版本号]={11},[企业版本号]={12} where 产品id={13}",
                           rowHead["编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["编号"].ToString()),
                            rowHead["电子帐册编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["电子帐册编号"].ToString()),
                            rowHead["产品型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品型号"].ToString()),
                            rowHead["产品型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品型号"].ToString()),
                            rowHead["产品建档日期"] == DBNull.Value ? "NULL" : StringTools.SqlQ(Convert.ToDateTime(rowHead["产品建档日期"]).ToString("yyyy-MM-dd HH:mm:ss")),
                            rowHead["产品单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品单位"].ToString()),
                            rowHead["产品颜色"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品颜色"].ToString()),
                            rowHead["产品备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品备注"].ToString()),
                            rowHead["实际总重"] == DBNull.Value ? "NULL" : rowHead["实际总重"],
                            rowHead["产品类别"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["产品类别"].ToString()),
                            rowHead["除数"] == DBNull.Value ? "NULL" : rowHead["除数"],
                            rowHead["内部版本号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["内部版本号"].ToString()),
                            rowHead["企业版本号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(rowHead["企业版本号"].ToString()),
                            rowHead["产品id"]);
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
            FormBaseDialogInput objForm = new FormBaseDialogInput();
            objForm.strDefault = txt_产品型号.Text;
            objForm.strFormText = "产品资料克隆(请输入源产品型号：)";
            if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (objForm.strReturn.Trim().Length > 0)
                {
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    string strSQL = string.Format("SELECT * FROM 产品资料表 WHERE 产品型号 = {0}", StringTools.SqlQ(objForm.strReturn));
                    DataTable dtTemp = dataAccess.GetTable(strSQL.ToString(), null);
                    dataAccess.Close();
                    if (dtTemp.Rows.Count == 0)
                    {
                        SysMessage.InformationMsg("指定的产品不存存！");
                    }
                    else
                    {
                        // "产品id", "产品型号", "产品建档日期"  不做处理
                        foreach (DataColumn col in dtTemp.Columns)
                        {
                            if (col.ColumnName != "产品id" && col.ColumnName != "产品型号" && col.ColumnName != "产品建档日期")
                                rowHead[col.ColumnName] = dtTemp.Rows[0][col.ColumnName];
                        }
                        fillControl(rowHead);
                    }
                }
            }
        }
        //BOM结构
        private void tool1_BOM_Click(object sender, EventArgs e)
        {
            if (rowHead.RowState == DataRowState.Added)
            {
                SysMessage.InformationMsg("新增产品资料未保存，不允许执行该操作！");
                return;
            }
            #region 判断是否已经有打开的BOM窗体
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormFitBOM")
                {
                    FormProductBOM orderBomForm = (FormProductBOM)childFrm;
                    if (orderBomForm.mnPId ==Convert.ToInt32(rowHead["产品id"]))
                    {
                        childFrm.Activate();
                        return;
                    }
                }
            }
            #endregion

            FormProductBOM formBOM = new FormProductBOM();
            formBOM.mbShow = false;
            formBOM.mnPId = Convert.ToInt32(rowHead["产品id"]);
            formBOM.mstrName = rowHead["产品型号"].ToString();
            formBOM.mstrColor = rowHead["产品颜色"].ToString();
            formBOM.MdiParent = this.MdiParent;
            formBOM.Show();
        }
        //关闭
        private void tool1_Close_Click(object sender, EventArgs e)
        {
            this.Close();
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
                case "产品型号":
                    #region 产品型号
                    if (rowHead.RowState == DataRowState.Added ||
                        (rowHead.RowState == DataRowState.Modified && rowHead["产品型号", DataRowVersion.Original].ToString() != txtBox.Text))
                    {
                        strSQL = string.Format("SELECT 产品id FROM 产品资料表 WHERE 产品型号 = {0}", StringTools.SqlQ(txtBox.Text));
                        dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                        dataAccess.Open();
                        DataTable dtManual = dataAccess.GetTable(strSQL.ToString(), null);
                        dataAccess.Close();
                        if (dtManual.Rows.Count > 0)
                        {
                            SysMessage.InformationMsg("此产品型号已存在，请重新输入！");
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
        private void cbox_产品类别_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bcbox_SelectedIndexChanged)
            {
                myComboBox cbox = (myComboBox)sender;
                string fieldName = cbox.Name.Replace("cbox_", "");
                rowHead[fieldName] = cbox.SelectedValue;
            }
        }
        #endregion

    }
}
