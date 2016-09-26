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
using System.IO;

namespace UniqueDeclaration
{
    public partial class FormArticlesFile : UniqueDeclarationBaseForm.FormBase
    {
        public FormArticlesFile()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 外面传进来的查询客户值
        /// </summary>
        public string CustValue = string.Empty;
        private bool bcbox_Type_SelectedIndexChanged = true;

        //查询时，条件预存历史值
        private string gstrCust = string.Empty;
        private string gstrSecondField = string.Empty;
        private string gstrKeyField = string.Empty;
        private string gstrColors = string.Empty;

        //导出EXCEL时，条件预存历史值
        private string strSecondFieldBeingExcel = string.Empty;
        private string strSecondFieldEndExcel = string.Empty;
        private string strKeyFieldBeingExcel = string.Empty;
        private string strKeyFieldEndExcel = string.Empty;
        private string strCustExcel = string.Empty;

        private void FormArticlesFile_Load(object sender, EventArgs e)
        {
            bcbox_Type_SelectedIndexChanged = false;
            this.cbox_Type.InitialData(DataAccessEnum.DataAccessName.DataAccessName_Manufacture, "select * from sort order by 产品类别描述", "产品类别", "产品类别描述");
            bcbox_Type_SelectedIndexChanged = true;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtArticle = dataAccess.GetTable(string.Format("SELECT tabArticle.* FROM tabArticle where Cust like '%{0}%' ORDER BY Cust,SecondField",StringTools.SqlLikeQ(CustValue)),null);
            dataAccess.Close();
            this.myTabControl1.SelectedIndex = 1;
            this.myDataGridView1.DataSource = dtArticle;
            InitGrid();
            if (myDataGridView1.RowCount > 0)
            {
                this.myDataGridView1.Rows[0].Selected = true;
            }
            this.myTabControl1.SelectedIndex = 0;
            setTool1Enabled();
            SetControlReadOnly(true);
            this.myDataGridView1_SelectionChanged(null, null);  //初期赋值时，不是GRID页签，CurrentRow为NULL，所以不能用这句
            //if (dtArticle.Rows.Count > 0)
            //    fillControl((myDataGridView1.Rows[0].DataBoundItem as DataRowView).Row);
            //else
            //    fillControl(null);


            this.txt_Notice.Validated += new System.EventHandler(this.txt_Notice_Validated);
            this.txt_SecondField.GotFocus += new System.EventHandler(this.txt_SecondField_GotFocus);
            this.txt_KeyField.GotFocus += new System.EventHandler(this.txt_KeyField_GotFocus);
            this.txt_Cust.GotFocus += new System.EventHandler(this.txt_Cust_GotFocus);
            this.txt_Colors.GotFocus += new System.EventHandler(this.txt_Colors_GotFocus);
        }
        private void FormArticlesFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !Save();
        }

        private void myDataGridView1_SelectionChanged(object sender, EventArgs e)
        {            
            //if (this.myDataGridView1.CurrentRowNew == null)
            //    fillControl(null);
            //else
            //    fillControl((myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row);
            fillControl(this.myDataGridView1.CurrentRowNew);
            setTool1Enabled();
        }


        #region 菜单按钮事件
        private void tool1_First_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.myDataGridView1.ClearSelection();
                this.myDataGridView1.Rows[0].Selected = true;
                this.myDataGridView1.CurrentCell = this.myDataGridView1.Rows[0].Cells["Cust"];
                setTool1Enabled();
            }
        }

        private void tool1_up_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                int iSelectRow = this.myDataGridView1.CurrentRowNew.Index;
                this.myDataGridView1.ClearSelection();
                this.myDataGridView1.Rows[iSelectRow - 1].Selected = true;
                this.myDataGridView1.CurrentCell = this.myDataGridView1.Rows[iSelectRow - 1].Cells["Cust"];
                setTool1Enabled();
            }
        }

        private void tool1_Down_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                int iSelectRow = this.myDataGridView1.CurrentRowNew.Index;
                this.myDataGridView1.ClearSelection();
                this.myDataGridView1.Rows[iSelectRow + 1].Selected = true;
                this.myDataGridView1.CurrentCell = this.myDataGridView1.Rows[iSelectRow + 1].Cells["Cust"];
                setTool1Enabled();
            }
        }

        private void tool1_End_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.myDataGridView1.ClearSelection();
                this.myDataGridView1.Rows[this.myDataGridView1.RowCount - 1].Selected = true;
                this.myDataGridView1.CurrentCell = this.myDataGridView1.Rows[this.myDataGridView1.RowCount - 1].Cells["Cust"];
                setTool1Enabled();
            }
        }

        private void tool1_Add_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                DataTable dtArticle = (DataTable)this.myDataGridView1.DataSource;
                DataRow newRow = dtArticle.NewRow();
                newRow["InputDate"] = DateTime.Now.Date;
                newRow["CostCurrencys"] = "USD";
                txt_Cust.Focus();
                dtArticle.Rows.Add(newRow);
                //this.myDataGridView1.Rows[this.myDataGridView1.RowCount - 1].Selected = true;
                this.myTabControl1.SelectedIndex = 0;
                this.tool1_End_Click(null, null);
                SetControlReadOnly(false);
            }
        }

        private void tool1_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tool1_Undo_Click(object sender, EventArgs e)
        {
            DataTable dtData = (DataTable)this.myDataGridView1.DataSource;
            dtData.RejectChanges();
        }

        private void tool1_Modify_Click(object sender, EventArgs e)
        {
            SetControlReadOnly(false);
        }

        private void tool1_Delete_Click(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            if (SysMessage.YesNoMsg("确定要删除选中行？") == System.Windows.Forms.DialogResult.No) return;
            DataTable dtData = (DataTable)this.myDataGridView1.DataSource;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            object ID = row["ID"];
            if (ID == DBNull.Value && ID == null)
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                dataAccess.ExecuteNonQuery(string.Format("DELETE FROM [tabArticle] WHERE ID={0}",ID),null);
                dataAccess.Close();
            }
            this.myDataGridView1.Rows.Remove(this.myDataGridView1.CurrentRowNew);
            dtData.AcceptChanges();
            setTool1Enabled();
            if (txt_Cust.ReadOnly == false)  //如果删除前是非只读的，才需要重新判断控件只读状态，没数据是设成只读。如果原来是只读的，就不需要再处理了。
            {
                SetControlReadOnly(dtData.Rows.Count<=0);
            }
        }

        private void tool1_Query_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                FormArticlesFile_Find objForm = new FormArticlesFile_Find();
                objForm.gstrCust = gstrCust;
                objForm.gstrColors = gstrColors;
                objForm.gstrKeyField = gstrKeyField;
                objForm.gstrSecondField = gstrSecondField;
                if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    gstrCust = objForm.gstrCust;
                    gstrKeyField = objForm.gstrKeyField;
                    gstrSecondField = objForm.gstrSecondField;
                    gstrColors = objForm.gstrColors;
                    DataTable dtData = (DataTable)this.myDataGridView1.DataSource;
                    string strWhere = string.Empty;
                    if (gstrCust.Length > 0)
                    {
                        strWhere =string.Format("Cust like '%{0}%'",StringTools.SqlLikeQ(gstrCust));
                    }
                    if (gstrKeyField.Length > 0)
                    {
                        strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("KeyField like '%{0}%'", StringTools.SqlLikeQ(gstrKeyField));
                    }
                    if (gstrSecondField.Length > 0)
                    {
                        strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("SecondField like '%{0}%'", StringTools.SqlLikeQ(gstrSecondField));
                    }
                    if (gstrColors.Length > 0)
                    {
                        strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("Colors like '%{0}%'", StringTools.SqlLikeQ(gstrColors));
                    }
                    DataRow[] rows = dtData.Select(strWhere);
                    if (rows.Length == 0)
                    {
                        SysMessage.InformationMsg("查找不到条件条件的数据！");
                        return;
                    }
                    else
                    {
                        int ID = Convert.ToInt32(rows[0]["ID"]);
                        int iRow =0;
                        for (int index = 0; index < this.myDataGridView1.RowCount; index++)
                        {
                            if (ID == Convert.ToInt32(this.myDataGridView1.Rows[index].Cells["ID"].Value))
                            {
                                iRow = index;
                                break;
                            }
                        }
                        this.myDataGridView1.Rows[iRow].Selected = true;
                        this.myDataGridView1.CurrentCell = this.myDataGridView1.Rows[iRow].Cells["Cust"];
                    }
                }
            }
        }

        private void tool1_Print_Click(object sender, EventArgs e)
        {FormArticlesFile_ExportExcel objForm = new FormArticlesFile_ExportExcel();
            objForm.strCustExcel = strCustExcel;
            objForm.strKeyFieldBeingExcel = strKeyFieldBeingExcel;
            objForm.strKeyFieldEndExcel = strKeyFieldEndExcel;
            objForm.strSecondFieldBeingExcel = strSecondFieldBeingExcel;
            objForm.strSecondFieldEndExcel = strSecondFieldEndExcel;
            if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strCustExcel = objForm.strCustExcel;
                strKeyFieldBeingExcel = objForm.strKeyFieldBeingExcel;
                strKeyFieldEndExcel = objForm.strKeyFieldEndExcel;
                strSecondFieldBeingExcel = objForm.strSecondFieldBeingExcel;
                strSecondFieldEndExcel = objForm.strSecondFieldEndExcel;
                DataTable dtDetail = getPrintDetailTable();
                if (dtDetail == null) return;
                dtDetail.Columns["Unique#"].ColumnName = "UniqueNo";
                DataSet ds = new DataSet();
                ds.Tables.Add(getPrintHeadTable());
                ds.Tables.Add(dtDetail);

                UniqueDeclaration.Report.FormReportArticles report = new Report.FormReportArticles();
                report.ds = ds;
                report.ShowDialog();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            if (!Save()) return;
            SetControlReadOnly(false);
            double priceValue;
            string packingValue, remarkValue, noticeValue, remark1Value, remark2Value, remark3Value, unitValue, descriptValue, custValue, secondFieldValue, keyFieldValue, colorsValue;
            DataRow currentRow = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            priceValue = currentRow["price"] == DBNull.Value ? 0 : Convert.ToDouble(currentRow["price"]);
            packingValue = currentRow["packing"].ToString();
            remarkValue = currentRow["remark"].ToString();
            noticeValue = currentRow["notice"].ToString();
            remark1Value = currentRow["remark1"].ToString();
            remark2Value = currentRow["remark2"].ToString();
            remark3Value = currentRow["remark3"].ToString();
            unitValue = currentRow["unit"].ToString();
            descriptValue = currentRow["descript"].ToString();
            custValue = currentRow["cust"].ToString();
            secondFieldValue = currentRow["secondField"].ToString();
            keyFieldValue = currentRow["keyField"].ToString();
            colorsValue = currentRow["colors"].ToString();

            DataTable dtData = (DataTable)this.myDataGridView1.DataSource;
            DataRow newRow = dtData.NewRow();
            newRow["price"]=priceValue;
            newRow["packing"]=packingValue;
            newRow["remark"]=remarkValue;
            newRow["notice"]=noticeValue;
            newRow["remark1"]=remark1Value;
            newRow["remark2"]=remark2Value;
            newRow["remark3"]=remark3Value;
            newRow["unit"]=unitValue;
            newRow["descript"]=descriptValue;
            newRow["cust"]=custValue;
            newRow["secondField"]=secondFieldValue;
            newRow["keyField"]=keyFieldValue;
            newRow["colors"] = colorsValue + "/";
            this.date_InputDate.Checked = true;
            newRow["InputDate"] = DateTime.Now.Date; 
            newRow["CostCurrencys"] = "USD";
            dtData.Rows.Add(newRow);
            this.tool1_End_Click(null, null);
            txt_Colors.Focus();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            FormArticlesFile_ExportExcel objForm = new FormArticlesFile_ExportExcel();
            objForm.strCustExcel = strCustExcel;
            objForm.strKeyFieldBeingExcel = strKeyFieldBeingExcel;
            objForm.strKeyFieldEndExcel = strKeyFieldEndExcel;
            objForm.strSecondFieldBeingExcel = strSecondFieldBeingExcel;
            objForm.strSecondFieldEndExcel = strSecondFieldEndExcel;
            if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strCustExcel = objForm.strCustExcel;
                strKeyFieldBeingExcel = objForm.strKeyFieldBeingExcel;
                strKeyFieldEndExcel = objForm.strKeyFieldEndExcel;
                strSecondFieldBeingExcel = objForm.strSecondFieldBeingExcel;
                strSecondFieldEndExcel = objForm.strSecondFieldEndExcel;
                //string strWhere = string.Empty;
                //if (strCustExcel.Length > 0)
                //{
                //    strWhere = string.Format("Cust={0}", StringTools.SqlQ(strCustExcel));
                //}
                //if (strKeyFieldBeingExcel.Length > 0)
                //{
                //    strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("KeyField >={0}", StringTools.SqlQ(strKeyFieldBeingExcel));
                //}
                //if (strKeyFieldEndExcel.Length > 0)
                //{
                //    strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("KeyField <={0}", StringTools.SqlQ(strKeyFieldEndExcel));
                //}
                //if (strSecondFieldBeingExcel.Length > 0)
                //{
                //    strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("SecondField >={0}", StringTools.SqlQ(strSecondFieldBeingExcel));
                //}
                //if (strSecondFieldEndExcel.Length > 0)
                //{
                //    strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("SecondField <={0}", StringTools.SqlQ(strSecondFieldEndExcel));
                //}
                //if (strWhere.Length == 0) return;
                ////rs.Open "select KeyField as Unique#,SecondField as Style_No,Colors as Color,Currencys as Curr,Price,Remark from tabArticle where " & FindValue, deManufacture.cnnPublic, adOpenDynamic, adLockBatchOptimistic
                //IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                //dataAccess.Open();
                //DataTable rs = dataAccess.GetTable(string.Format(@"select KeyField as Unique#,SecondField as Style_No,Colors as Color,Currencys as Curr,Price,Remark from tabArticle where {0}",strWhere), null);
                //dataAccess.Close();
                DataTable rs = getPrintDetailTable();
                if (rs == null) return;
                string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\空白模版.xls");
                string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\空白模版{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
                File.Copy(strSourceFile, strDestFile);
                File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
                string fn = strDestFile;
                ExcelTools ea = new ExcelTools();
                ea.SafeOpen(fn);
                ea.ActiveSheet(1); // 激活

                ea.SetValue("A1", "ARTICLE");
                ea.SetValue("A2", "CUST:" + strCustExcel);
                ea.SetValue("C2", "UniqueNo:" + strKeyFieldBeingExcel);
                ea.SetValue("E2", "To:" + strKeyFieldEndExcel);
                ea.SetValue("C3", "StyleNo:" + strSecondFieldBeingExcel);
                ea.SetValue("E3", "To:" + strSecondFieldEndExcel);

                //处理标题行
                ea.SetValue("A4", "Unique#");
                ea.SetValue("B4", "Style_No");
                ea.SetValue("C4", "Color");
                ea.SetValue("D4", "Curr");
                ea.SetValue("E4", "Price");
                ea.SetValue("F4", "Remark");

                Dictionary<string, long> dicColMaxValue = new Dictionary<string, long>();  //存储各列的文本最大长度值
                int n = 5;
                foreach (DataRow row in rs.Rows)
                {
                    ea.SetValue(string.Format("A{0}", n), row["Unique#"].ToString());
                    SetColMaxValue(dicColMaxValue, "A4", row["Unique#"].ToString());
                    ea.SetValue(string.Format( "B{0}",n), row["Style_No"].ToString());
                    SetColMaxValue(dicColMaxValue, "B4", row["Style_No"].ToString());
                    ea.SetValue(string.Format("C{0}", n), row["Color"].ToString());
                    SetColMaxValue(dicColMaxValue, "C4", row["Color"].ToString());
                    ea.SetValue(string.Format("D{0}", n), row["Curr"].ToString());
                    SetColMaxValue(dicColMaxValue, "D4", row["Curr"].ToString());
                    ea.SetValue(string.Format("E{0}", n), row["Price"] == DBNull.Value ? "0" : row["Price"].ToString());
                    SetColMaxValue(dicColMaxValue, "E4", row["Price"] == DBNull.Value ? "0" : row["Price"].ToString());
                    ea.SetValue(string.Format("F{0}", n), row["Remark"].ToString());
                    SetColMaxValue(dicColMaxValue, "F4", row["Remark"].ToString());
                    n++;
                }

                //设置每个列的宽度
                foreach (KeyValuePair<string, long> item in dicColMaxValue)
                {
                    ea.SetColumnWidth(item.Key, item.Value + 2);  //最大字符串长度+2，多出点空隙
                } 

                ea.Visible = true;
                ea.Dispose();
            }
        }
        //报关类别维护
        private void btnType_Click(object sender, EventArgs e)
        {
            FormProductType objForm = new FormProductType();
            objForm.ShowDialog();
            if (objForm.bModify)  //如果资料有维护过，则需要重新加载报关类别
            {
                bcbox_Type_SelectedIndexChanged = false;
                object defaultValue = cbox_Type.SelectedValue == null ? -1 : cbox_Type.SelectedValue;
                this.cbox_Type.InitialData(DataAccessEnum.DataAccessName.DataAccessName_Manufacture, "select * from sort order by 产品类别描述", "产品类别", "产品类别描述", defaultValue);
                bcbox_Type_SelectedIndexChanged = true;
            }
        }
        #endregion

        #region 表头控件事件
        private void txt_Cust_TextChanged(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew != null)
            {
                if (txt_Cust_Lab.Text.Trim().Length == 0 || txt_Cust.Text.Trim() != txt_Cust_Lab.Text.Trim())
                {
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    DataTable rs = dataAccess.GetTable(string.Format("SELECT SecondField,currencys FROM tabCustomer WHERE KeyField = {0}", StringTools.SqlQ(txt_Cust.Text.Trim())), null);
                    dataAccess.Close();
                    txt_Cust_Lab.Text = rs.Rows.Count > 0 ? rs.Rows[0]["SecondField"].ToString() : "";
                    if (txt_Currencys.Text.Trim() == "")
                    {
                        txt_Currencys.Text = rs.Rows.Count > 0 ? rs.Rows[0]["Currencys"].ToString() : "";
                    }
                }
            }
        }
        private void txt_Cust_Validating(object sender, CancelEventArgs e)
        {
            if (this.myDataGridView1.RowCount == 0) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row.RowState == DataRowState.Added)
            {
                if (txt_Cust.Text.Trim() != "")
                {
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    DataTable rs = dataAccess.GetTable(string.Format("帮助录入查询 {0}, 6, 0, 0, 0, '', ''",txt_Cust.Text.Trim()),null);
                    dataAccess.Close();
                    DataRow rsRow = null;
                    if (rs.Rows.Count ==1)
                    {
                        rsRow = rs.Rows[0];
                    }
                    else if (rs.Rows.Count > 1)
                    {
                        FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                        formSelect.strFormText = "选择客户";
                        formSelect.dtData = rs;
                        if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            rsRow = formSelect.returnRow;
                        }
                    }
                    if (rsRow != null)
                    {
                        txt_Cust.Text = rsRow["KeyField"].ToString();
                        row["Cust"] = rsRow["KeyField"];
                        txt_Cust_Lab.Text = rsRow["SecondField"].ToString();
                        row["Cust_Lab"] = rsRow["SecondField"];
                        txt_SecondField.Focus();
                    }
                }
            }
        }
        private void txt_Cust_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Cust"].ToString() != txt_Cust.Text.Trim())
            {
                row["Cust"] = txt_Cust.Text.Trim();
            }
        }
        private void txt_Cust_GotFocus(object sender, EventArgs e)
        {
            txt_Cust.SelectAll();
        }

        private void txt_Cust_Lab_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Cust_Lab"].ToString() != txt_Cust_Lab.Text.Trim())
            {
                row["Cust_Lab"] = txt_Cust_Lab.Text.Trim();
            }
        }

        private void txt_SecondField_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["SecondField"].ToString() != txt_SecondField.Text.Trim())
            {
                row["SecondField"] = txt_SecondField.Text.Trim();
            }
        }
        private void txt_SecondField_GotFocus(object sender, EventArgs e)
        {
            if (txt_Cust.Text.Trim().Length == 0)
                txt_Cust.Focus();
            txt_SecondField.SelectAll();
        }

        private void date_InputDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (date_InputDate.Checked)
            {
                if (row["InputDate"] == DBNull.Value || Convert.ToDateTime(row["InputDate"]) != date_InputDate.Value)
                    row["InputDate"] = date_InputDate.Value;
            }
            else
            {
                if (row["InputDate"] != DBNull.Value)
                    row["InputDate"] = DBNull.Value;
            }
        }

        private void txt_KeyField_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["KeyField"].ToString() != txt_KeyField.Text.Trim())
            {
                row["KeyField"] = txt_KeyField.Text.Trim();
            }
        }
        private void txt_KeyField_GotFocus(object sender, EventArgs e)
        {
            if (txt_KeyField.Text.Trim().Length == 0)
                txt_KeyField.Text = txt_SecondField.Text;
            txt_KeyField.SelectAll();
        }
        private void txt_Cost_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txt_Cost.Text.Trim().Length > 0)
                {
                    float.Parse(txt_Cost.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                SysMessage.ErrorMsg(ex.Message);
            }
        }

        private void txt_Cost_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Cost"].ToString() != txt_Cost.Text.Trim())
            {
                row["Cost"] = txt_Cost.Text.Trim();
            }
        }

        private void txt_CostCurrencys_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["CostCurrencys"].ToString() != txt_CostCurrencys.Text.Trim())
            {
                row["CostCurrencys"] = txt_CostCurrencys.Text.Trim();
            }
        }

        private void txt_Colors_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !CheckValue(txt_Colors);
        }
        private void txt_Colors_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Colors"].ToString() != txt_Colors.Text.Trim())
            {
                row["Colors"] = txt_Colors.Text.Trim();
            }
        }
        private void txt_Colors_GotFocus(object sender, EventArgs e)
        {
            txt_Colors.SelectAll();
        }

        private void txt_Price_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txt_Price.Text.Trim().Length > 0)
                {
                    float.Parse(txt_Price.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                SysMessage.ErrorMsg(ex.Message);
            }
        }
        private void txt_Price_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Price"].ToString() != txt_Price.Text.Trim())
            {
                row["Price"] = txt_Price.Text.Trim();
            }
        }

        private void txt_Currencys_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Currencys"].ToString() != txt_Currencys.Text.Trim())
            {
                row["Currencys"] = txt_Currencys.Text.Trim();
            }
        }

        private void txt_Descript_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Descript"].ToString() != txt_Descript.Text.Trim())
            {
                row["Descript"] = txt_Descript.Text.Trim();
            }
        }
        private void txt_Descript_TextChanged(object sender, EventArgs e)
        {
            txt_typesort.Text = txt_Descript.Text;
        }

        private void txt_typesort_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["typesort"].ToString() != txt_typesort.Text.Trim())
            {
                row["typesort"] = txt_typesort.Text.Trim();
            }
        }

        private void txt_Unit_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Unit"].ToString() != txt_Unit.Text.Trim())
            {
                row["Unit"] = txt_Unit.Text.Trim();
            }
        }

        private void cbox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bcbox_Type_SelectedIndexChanged) return;
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (cbox_Type.SelectedValue == null && row["Type"] == DBNull.Value) return;
            if (cbox_Type.SelectedValue == null)
            {
                row["Type"] = DBNull.Value;
            }
            else if (row["Type"].ToString() != cbox_Type.SelectedValue.ToString())
            {
                if (cbox_Type.SelectedIndex == -1 || cbox_Type.SelectedValue == null)
                {
                    row["Type"] = DBNull.Value;
                }
                else
                {
                    row["Type"] = cbox_Type.SelectedValue;
                }
            }
        }

        private void txt_Weight_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txt_Weight.Text.Trim().Length > 0)
                {
                    float.Parse(txt_Weight.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                SysMessage.ErrorMsg(ex.Message);
            }
        }

        private void txt_Weight_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Weight"].ToString() != txt_Weight.Text.Trim())
            {
                row["Weight"] = txt_Weight.Text.Trim();
            }
        }

        private void txt_UnitN_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["UnitN"].ToString() != txt_UnitN.Text.Trim())
            {
                row["UnitN"] = txt_UnitN.Text.Trim();
            }
        }

        private void txt_Packing_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Packing"].ToString() != txt_Packing.Text.Trim())
            {
                row["Packing"] = txt_Packing.Text.Trim();
            }
        }

        private void txt_Remark_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Remark"].ToString() != txt_Remark.Text.Trim())
            {
                row["Remark"] = txt_Remark.Text.Trim();
            }
        }

        private void txt_Remark1_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Remark1"].ToString() != txt_Remark1.Text.Trim())
            {
                row["Remark1"] = txt_Remark1.Text.Trim();
            }
        }

        private void txt_Remark2_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Remark2"].ToString() != txt_Remark2.Text.Trim())
            {
                row["Remark2"] = txt_Remark2.Text.Trim();
            }
        }

        private void txt_Remark3_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Remark3"].ToString() != txt_Remark3.Text.Trim())
            {
                row["Remark3"] = txt_Remark3.Text.Trim();
            }
        }

        private void txt_Notice_Validated(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew == null) return;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            if (row["Notice"].ToString() != txt_Notice.Text.Trim())
            {
                row["Notice"] = txt_Notice.Text.Trim();
            }
        }
        #endregion

        #region 方法函数
        /// <summary>
        /// 初始化GRID
        /// </summary>
        private void InitGrid()
        {
            this.myDataGridView1.AutoGenerateColumns = false;

            this.myDataGridView1.Columns["ID"].Visible = false;

            this.myDataGridView1.Columns["Cust"].DisplayIndex = 0;
            this.myDataGridView1.Columns["Cust"].Width = 60;
            this.myDataGridView1.Columns["Cust_Lab"].DisplayIndex = 1;
            this.myDataGridView1.Columns["Cust_Lab"].Width = 78;
            this.myDataGridView1.Columns["SecondField"].DisplayIndex = 2;
            this.myDataGridView1.Columns["SecondField"].HeaderText = "Style_No";
            this.myDataGridView1.Columns["SecondField"].Width = 78;
            this.myDataGridView1.Columns["KeyField"].DisplayIndex = 3;
            this.myDataGridView1.Columns["KeyField"].HeaderText = "Unique#";
            this.myDataGridView1.Columns["KeyField"].Width = 78;
            this.myDataGridView1.Columns["Colors"].DisplayIndex = 4;
            this.myDataGridView1.Columns["Colors"].Width = 70;
            this.myDataGridView1.Columns["InputDate"].DisplayIndex = 5;
            this.myDataGridView1.Columns["InputDate"].Width = 70;
            this.myDataGridView1.Columns["Descript"].DisplayIndex = 6;
            this.myDataGridView1.Columns["Descript"].Width = 78;
            this.myDataGridView1.Columns["Type"].DisplayIndex = 7;
            this.myDataGridView1.Columns["Type"].HeaderText = "报关类别";
            this.myDataGridView1.Columns["Type"].Width = 78;
            this.myDataGridView1.Columns["typesort"].DisplayIndex = 8;
            this.myDataGridView1.Columns["typesort"].HeaderText = "种类";
            this.myDataGridView1.Columns["typesort"].Width = 70;
            this.myDataGridView1.Columns["Unit"].DisplayIndex = 9;
            this.myDataGridView1.Columns["Unit"].Width = 55;
            this.myDataGridView1.Columns["Price"].DisplayIndex = 10;
            this.myDataGridView1.Columns["Price"].Width = 60;
            this.myDataGridView1.Columns["Currencys"].DisplayIndex = 11;
            this.myDataGridView1.Columns["Currencys"].Width = 70;
            this.myDataGridView1.Columns["Cost"].DisplayIndex = 12;
            this.myDataGridView1.Columns["Cost"].HeaderText = "Factory Price";
            this.myDataGridView1.Columns["Cost"].Width = 110;
            this.myDataGridView1.Columns["CostCurrencys"].DisplayIndex = 13;
            this.myDataGridView1.Columns["CostCurrencys"].HeaderText = "Currencys";
            this.myDataGridView1.Columns["CostCurrencys"].Width = 70;
            this.myDataGridView1.Columns["Weight"].DisplayIndex = 14;
            this.myDataGridView1.Columns["Weight"].Width = 60;
            this.myDataGridView1.Columns["UnitN"].DisplayIndex = 15;
            this.myDataGridView1.Columns["UnitN"].Width = 55;
            this.myDataGridView1.Columns["Packing"].DisplayIndex = 16;
            this.myDataGridView1.Columns["Packing"].Width = 100;
            this.myDataGridView1.Columns["Remark"].DisplayIndex = 17;
            this.myDataGridView1.Columns["Remark"].Width = 100;
            this.myDataGridView1.Columns["Remark1"].DisplayIndex = 18;
            this.myDataGridView1.Columns["Remark1"].Width = 100;
            this.myDataGridView1.Columns["Remark2"].DisplayIndex = 19;
            this.myDataGridView1.Columns["Remark2"].Width = 100;
            this.myDataGridView1.Columns["Remark3"].DisplayIndex = 20;
            this.myDataGridView1.Columns["Remark3"].Width = 100;
            this.myDataGridView1.Columns["notice"].DisplayIndex = 21;
            this.myDataGridView1.Columns["notice"].HeaderText = "Notice";
            this.myDataGridView1.Columns["notice"].Width = 70;

            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridView1.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMenuStripCell1;
            }

        }
        /// <summary>
        /// 填充控件值
        /// </summary>
        /// <param name="dgvRow">DataGridViewRow行数据</param>
        private void fillControl(DataGridViewRow dgvRow)
        {
            if (dgvRow == null)
            {
                txt_Cust.Text = string.Empty;
                txt_Cust_Lab.Text = string.Empty;
                txt_SecondField.Text = string.Empty;
                date_InputDate.Value = DateTime.Now.Date;
                txt_KeyField.Text = string.Empty;
                txt_Cost.Text = string.Empty;
                txt_CostCurrencys.Text = "USD";
                txt_Colors.Text = string.Empty;
                txt_Price.Text = string.Empty;
                txt_Currencys.Text = string.Empty;
                txt_Descript.Text = string.Empty;
                txt_typesort.Text = string.Empty;
                txt_Unit.Text = string.Empty;
                cbox_Type.SelectedIndex = -1;
                txt_Weight.Text = string.Empty;
                txt_UnitN.Text = string.Empty;
                txt_Packing.Text = string.Empty;
                txt_Remark.Text = string.Empty;
                txt_Remark1.Text = string.Empty;
                txt_Remark2.Text = string.Empty;
                txt_Remark3.Text = string.Empty;
                txt_Notice.Text = string.Empty;
            }
            else
            {
                DataRow row = (dgvRow.DataBoundItem as DataRowView).Row;
                txt_Cust.Text = row["Cust"].ToString();
                txt_Cust_Lab.Text = row["Cust_Lab"].ToString();
                txt_SecondField.Text = row["SecondField"].ToString();
                if (row["InputDate"] == DBNull.Value)
                {
                    date_InputDate.Checked =false;
                }
                else
                {
                    date_InputDate.Value = Convert.ToDateTime(row["InputDate"]);
                }
                txt_KeyField.Text = row["KeyField"].ToString();
                txt_Cost.Text = row["Cost"] == DBNull.Value ? string.Empty : row["Cost"].ToString();
                txt_CostCurrencys.Text = row["CostCurrencys"].ToString();
                txt_Colors.Text = row["Colors"].ToString();
                txt_Price.Text = row["Price"] == DBNull.Value ? string.Empty : row["Price"].ToString();
                txt_Currencys.Text = row["Currencys"].ToString();
                txt_Descript.Text = row["Descript"].ToString();
                txt_typesort.Text = row["typesort"].ToString();
                txt_Unit.Text = row["Unit"].ToString();
                if (row["Type"] == DBNull.Value)
                {
                    cbox_Type.SelectedIndex = -1;
                }
                else
                {
                    cbox_Type.SelectedValue = row["Type"].ToString();
                }
                txt_Weight.Text = row["Weight"] == DBNull.Value ? string.Empty : row["Weight"].ToString();
                txt_UnitN.Text = row["UnitN"].ToString();
                txt_Packing.Text = row["Packing"].ToString();
                txt_Remark.Text = row["Remark"].ToString();
                txt_Remark1.Text = row["Remark1"].ToString();
                txt_Remark2.Text = row["Remark2"].ToString();
                txt_Remark3.Text = row["Remark3"].ToString();
                txt_Notice.Text = row["Notice"].ToString();
            }
        }
        /// <summary>
        /// 检查主键合法性
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        private bool CheckValue(myTextBox txt)
        {
            bool bCheck = true;
            DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
            string strSQL = string.Empty;
            if (row.RowState == DataRowState.Added)
            {
                strSQL = string.Format(@"SELECT * FROM tabArticle WHERE KeyField = {0} AND SecondField = {1} AND Cust = {2} AND Colors = {3}",
                    StringTools.SqlQ(txt_KeyField.Text.Trim()), StringTools.SqlQ(txt_SecondField.Text.Trim()), StringTools.SqlQ(txt_Cust.Text.Trim()),
                    StringTools.SqlQ(txt_Colors.Text.Trim()));
            }
            else if (row.RowState == DataRowState.Modified)
            {
                if (txt_Cust.Text.Trim() != row["Cust", DataRowVersion.Original].ToString() || txt_KeyField.Text.Trim() != row["KeyField", DataRowVersion.Original].ToString()
                    || txt_SecondField.Text.Trim() != row["SecondField", DataRowVersion.Original].ToString() || txt_Colors.Text.Trim() != row["Colors", DataRowVersion.Original].ToString())
                {
                    strSQL = string.Format(@"SELECT * FROM tabArticle WHERE KeyField = {0} AND SecondField = {1} AND Cust = {2} AND Colors = {3}",
                        StringTools.SqlQ(txt_KeyField.Text.Trim()), StringTools.SqlQ(txt_SecondField.Text.Trim()), StringTools.SqlQ(txt_Cust.Text.Trim()),
                        StringTools.SqlQ(txt_Colors.Text.Trim()));
                }
            }
            if (strSQL.Length > 0)
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                DataTable rs = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (rs.Rows.Count > 0)
                {
                    SysMessage.InformationMsg("此相同数据已经存在,请重新输入");
                    bCheck = false;
                    return false;
                }
            }
            return bCheck;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            if (this.myDataGridView1.CurrentRowNew == null) return true;
            bool bSave = false;
            try
            {
                if (txt_Cust.Text.Trim() == "")
                {
                    SysMessage.InformationMsg(string.Format("【{0}】不允许为空！", lab_Cust.Text));
                    txt_Cust.Focus();
                    return bSave;
                }
                if (txt_SecondField.Text.Trim() == "")
                {
                    SysMessage.InformationMsg(string.Format("【{0}】不允许为空！", lab_StyleNo.Text));
                    txt_SecondField.Focus();
                    return bSave;
                }
                if (txt_KeyField.Text.Trim() == "")
                {
                    SysMessage.InformationMsg(string.Format("【{0}】不允许为空！", lab_Unique_No.Text));
                    txt_KeyField.Focus();
                    return bSave;
                }
                if (txt_Colors.Text.Trim() == "")
                {
                    SysMessage.InformationMsg(string.Format("【{0}】不允许为空！", lab_Color.Text));
                    txt_Colors.Focus();
                    return bSave;
                }
                bSave = true;
                DataRow row = (this.myDataGridView1.CurrentRowNew.DataBoundItem as DataRowView).Row;
                if (row.RowState == DataRowState.Unchanged) return bSave;
                if (row.RowState == DataRowState.Added)
                {
                    if (!date_InputDate.Checked)
                        row["InputDate"] = DBNull.Value;
                    string strSQL = string.Format(@"INSERT INTO [tabArticle]([KeyField],[SecondField],[Cust],[Cust_lab],[InputDate],[Descript],[Colors]
                                                ,[Currencys],[Unit],[Price],[CostCurrencys],[Cost],[Weight],[UnitN],[Packing],[Remark],[Remark1],[Remark2]
                                                ,[Remark3],[notice],[TypeSort],[type]) VALUES
                                                ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21})",
                                                    row["KeyField"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["KeyField"].ToString()),
                                                    row["SecondField"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["SecondField"].ToString()),
                                                    row["Cust"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Cust"].ToString()),
                                                    row["Cust_lab"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Cust_lab"].ToString()),
                                                    row["InputDate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["InputDate"].ToString()),
                                                    row["Descript"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Descript"].ToString()),
                                                    row["Colors"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Colors"].ToString()),
                                                    row["Currencys"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Currencys"].ToString()),
                                                    row["Unit"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit"].ToString()),
                                                    row["Price"] == DBNull.Value ? "NULL" : row["Price"],
                                                    row["CostCurrencys"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["CostCurrencys"].ToString()),
                                                    row["Cost"] == DBNull.Value ? "NULL" : row["Cost"],
                                                    row["Weight"] == DBNull.Value ? "NULL" : row["Weight"],
                                                    row["UnitN"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["UnitN"].ToString()),
                                                    row["Packing"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Packing"].ToString()),
                                                    row["Remark"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Remark"].ToString()),
                                                    row["Remark1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Remark1"].ToString()),
                                                    row["Remark2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Remark2"].ToString()),
                                                    row["Remark3"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Remark3"].ToString()),
                                                    row["notice"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["notice"].ToString()),
                                                    row["TypeSort"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["TypeSort"].ToString()),
                                                    row["type"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["type"].ToString()));
                    strSQL += Environment.NewLine + "select @@IDENTITY as ID";
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    //dataAccess.ExecuteNonQuery(strSQL, null);
                    object ID = dataAccess.ExecScalar(strSQL, null);
                    dataAccess.Close();
                    row["ID"] = ID;
                    row.Table.AcceptChanges();
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    if (!date_InputDate.Checked)
                        row["InputDate"] = DBNull.Value;
                    string strSQL = string.Format(@"UPDATE [tabArticle] SET [KeyField]={0},[SecondField]={1},[Cust]={2},[Cust_lab]={3},[InputDate]={4},[Descript]={5},
                                                [Colors]={6},[Currencys]={7},[Unit]={8},[Price]={9},[CostCurrencys]={10},[Cost]={11},[Weight]={12},[UnitN]={13},
                                                [Packing]={14},[Remark]={15},[Remark1]={16},[Remark2]={17},[Remark3]={18},[notice]={19},[TypeSort]={20},[type]={21}
                                                WHERE ID={22}",
                                                    row["KeyField"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["KeyField"].ToString()),
                                                    row["SecondField"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["SecondField"].ToString()),
                                                    row["Cust"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Cust"].ToString()),
                                                    row["Cust_lab"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Cust_lab"].ToString()),
                                                    row["InputDate"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["InputDate"].ToString()),
                                                    row["Descript"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Descript"].ToString()),
                                                    row["Colors"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Colors"].ToString()),
                                                    row["Currencys"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Currencys"].ToString()),
                                                    row["Unit"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Unit"].ToString()),
                                                    row["Price"] == DBNull.Value ? "NULL" : row["Price"],
                                                    row["CostCurrencys"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["CostCurrencys"].ToString()),
                                                    row["Cost"] == DBNull.Value ? "NULL" : row["Cost"],
                                                    row["Weight"] == DBNull.Value ? "NULL" : row["Weight"],
                                                    row["UnitN"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["UnitN"].ToString()),
                                                    row["Packing"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Packing"].ToString()),
                                                    row["Remark"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Remark"].ToString()),
                                                    row["Remark1"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Remark1"].ToString()),
                                                    row["Remark2"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Remark2"].ToString()),
                                                    row["Remark3"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["Remark3"].ToString()),
                                                    row["notice"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["notice"].ToString()),
                                                    row["TypeSort"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["TypeSort"].ToString()),
                                                    row["type"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["type"].ToString()),
                                                    row["ID"]);
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    dataAccess.ExecuteNonQuery(strSQL, null);
                    dataAccess.Close();
                    row.Table.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("保存数据出现错误：{0}", ex.Message));
                bSave = false;
            }
            return bSave;
        }
        /// <summary>
        /// 设置控件只读状态
        /// </summary>
        /// <param name="bReadOnly">是否只读</param>
        private void SetControlReadOnly(bool bReadOnly)
        {
            txt_Cust.ReadOnly = bReadOnly;
            txt_Cust_Lab.ReadOnly = bReadOnly;
            txt_SecondField.ReadOnly = bReadOnly;
            date_InputDate.Enabled = !bReadOnly;
            txt_KeyField.ReadOnly = bReadOnly;
            txt_Cost.ReadOnly = bReadOnly;
            txt_CostCurrencys.ReadOnly = bReadOnly;
            txt_Colors.ReadOnly = bReadOnly;
            txt_Price.ReadOnly = bReadOnly;
            txt_Currencys.ReadOnly = bReadOnly;
            txt_Descript.ReadOnly = bReadOnly;
            txt_typesort.ReadOnly = bReadOnly;
            txt_Unit.ReadOnly = bReadOnly;
            cbox_Type.Enabled = !bReadOnly;
            txt_Weight.ReadOnly = bReadOnly;
            txt_UnitN.ReadOnly = bReadOnly;
            txt_Packing.ReadOnly = bReadOnly;
            txt_Remark.ReadOnly = bReadOnly;
            txt_Remark1.ReadOnly = bReadOnly;
            txt_Remark2.ReadOnly = bReadOnly;
            txt_Remark3.ReadOnly = bReadOnly;
            txt_Notice.ReadOnly = bReadOnly;
        }
        /// <summary>
        /// 设置列名的文本长度
        /// </summary>
        /// <param name="dicColMaxValue">Dictionary数据集</param>
        /// <param name="colName">列名</param>
        /// <param name="colText">文本</param>
        private void SetColMaxValue(Dictionary<string,long> dicColMaxValue,string colName,string colText)
        {
            long lCellLenght = StringTools.TextLenght(colText);
            if (dicColMaxValue.ContainsKey(colName))  //如果字典中已经包含该列的数据，则跟当前文本判断，存储字符长度较长的文本
            {
                if (dicColMaxValue[colName] < lCellLenght)
                    dicColMaxValue[colName] = lCellLenght;
            }
            else
            {
                dicColMaxValue.Add(colName, lCellLenght);
            }
        }
        /// <summary>
        /// 设置tools的按钮是否可用
        /// </summary>
        private void setTool1Enabled()
        {
            this.tool1_Query.Enabled = true;
            this.tool1_Add.Enabled = true;
            DataTable dtTable = (DataTable)myDataGridView1.DataSource;
            if (dtTable.Rows.Count>0)
            {
                this.tool1_Save.Enabled = true;
                this.tool1_Undo.Enabled = true;
                this.tool1_Delete.Enabled = true;
                this.tool1_Modify.Enabled = true;
                this.tool1_Print.Enabled = true;
                this.btnCopy.Enabled = true;
                //如果总行数为1时，则笔数移动按钮都为不可编辑
                if (dtTable.Rows.Count == 1)
                {
                    this.tool1_First.Enabled = false;
                    this.tool1_up.Enabled = false;
                    this.tool1_Down.Enabled = false;
                    this.tool1_End.Enabled = false;
                }
                else
                {
                    //如果当前行索引为0
                    if (this.myDataGridView1.CurrentRowNew == null) return;
                    if (this.myDataGridView1.CurrentRowNew.Index == 0)
                    {
                        this.tool1_First.Enabled = false;
                        this.tool1_up.Enabled = false;
                        this.tool1_Down.Enabled = true;
                        this.tool1_End.Enabled = true;
                    }
                    else if (this.myDataGridView1.CurrentRowNew.Index == this.myDataGridView1.RowCount - 1)  //如果行索引为最后一行
                    {
                        this.tool1_First.Enabled = true;
                        this.tool1_up.Enabled = true;
                        this.tool1_Down.Enabled = false;
                        this.tool1_End.Enabled = false;
                    }
                    else
                    {
                        this.tool1_First.Enabled = true;
                        this.tool1_up.Enabled = true;
                        this.tool1_Down.Enabled = true;
                        this.tool1_End.Enabled = true;
                    }
                }
            }
            else
            {
                this.tool1_First.Enabled = false;
                this.tool1_up.Enabled = false;
                this.tool1_Down.Enabled = false;
                this.tool1_End.Enabled = false;

                this.tool1_Save.Enabled = false;
                this.tool1_Undo.Enabled = false;
                this.tool1_Delete.Enabled = false;
                this.tool1_Modify.Enabled = false;
                this.tool1_Print.Enabled = false;
                this.btnCopy.Enabled = false;
            }
        }
        /// <summary>
        /// 获取报表打印的表头数据
        /// </summary>
        /// <returns></returns>
        private DataTable getPrintHeadTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Cust", typeof(string)));
            dt.Columns.Add(new DataColumn("UniqueNo", typeof(string)));
            dt.Columns.Add(new DataColumn("UniqueNoTo", typeof(string)));
            dt.Columns.Add(new DataColumn("StyleNo", typeof(string)));
            dt.Columns.Add(new DataColumn("StyleNoTo", typeof(string)));
            DataRow newRow = dt.NewRow();
            newRow["Cust"] = strCustExcel;
            newRow["UniqueNo"] = strKeyFieldBeingExcel;
            newRow["UniqueNoTo"] = strKeyFieldEndExcel;
            newRow["StyleNo"] = strSecondFieldBeingExcel;
            newRow["StyleNoTo"] = strSecondFieldEndExcel;
            dt.Rows.Add(newRow);
            return dt;
        }

        /// <summary>
        /// 获取报表打印的表身数据
        /// </summary>
        /// <returns></returns>
        private DataTable getPrintDetailTable()
        {
            DataTable dtData = null;
            string strWhere = string.Empty;
            if (strCustExcel.Length > 0)
            {
                strWhere = string.Format("Cust={0}", StringTools.SqlQ(strCustExcel));
            }
            if (strKeyFieldBeingExcel.Length > 0)
            {
                strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("KeyField >={0}", StringTools.SqlQ(strKeyFieldBeingExcel));
            }
            if (strKeyFieldEndExcel.Length > 0)
            {
                strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("KeyField <={0}", StringTools.SqlQ(strKeyFieldEndExcel));
            }
            if (strSecondFieldBeingExcel.Length > 0)
            {
                strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("SecondField >={0}", StringTools.SqlQ(strSecondFieldBeingExcel));
            }
            if (strSecondFieldEndExcel.Length > 0)
            {
                strWhere += (strWhere.Length > 0 ? " and " : "") + string.Format("SecondField <={0}", StringTools.SqlQ(strSecondFieldEndExcel));
            }
            if (strWhere.Length == 0) return dtData;
            //rs.Open "select KeyField as Unique#,SecondField as Style_No,Colors as Color,Currencys as Curr,Price,Remark from tabArticle where " & FindValue, deManufacture.cnnPublic, adOpenDynamic, adLockBatchOptimistic
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtData = dataAccess.GetTable(string.Format(@"select KeyField as Unique#,SecondField as Style_No,Colors as Color,Currencys as Curr,Price,Remark from tabArticle where {0}", strWhere), null);
            dataAccess.Close();
            return dtData;
        }
        #endregion
        

        
    }
}
