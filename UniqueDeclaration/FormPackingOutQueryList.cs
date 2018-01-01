using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;
using System.IO;

namespace UniqueDeclaration
{
    public partial class FormPackingOutQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormPackingOutQueryList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否触发行变化事件
        /// </summary>
        private bool bTriggerGridViewHead_SelectionChanged = true;
        /// <summary>
        /// 查询窗体的返回来的条件
        /// </summary>
        public string gstrWhere = string.Empty;
        private void FormPackingQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_Import.Visible = false;
            this.tool1_Print.Visible = true;
            LoadDataSourceHead();
            InitGridDetails();
            InitGridHead();
        }

        private void InitGridHead()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["Pid"].Visible = false;
            this.myDataGridViewHead.Columns["Pid"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["custid"].Visible = false;
            this.myDataGridViewHead.Columns["custid"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["comid"].Visible = false;
            this.myDataGridViewHead.Columns["comid"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Priceterm"].Visible = false;
            this.myDataGridViewHead.Columns["Priceterm"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["remark1"].Visible = false;
            this.myDataGridViewHead.Columns["remark1"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["remark2"].Visible = false;
            this.myDataGridViewHead.Columns["remark2"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["remark3"].Visible = false;
            this.myDataGridViewHead.Columns["remark3"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["remark4"].Visible = false;
            this.myDataGridViewHead.Columns["remark4"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["InvoiceNo"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["InvoiceNo"].Width = 78;
            this.myDataGridViewHead.Columns["InvoiceNo"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["装箱单号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["装箱单号"].Width = 78;
            this.myDataGridViewHead.Columns["装箱单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["报关单号"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["报关单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["ExportDate"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["ExportDate"].HeaderText = "出口日期";
            this.myDataGridViewHead.Columns["ExportDate"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["shipdate"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["shipdate"].HeaderText = "船期";
            this.myDataGridViewHead.Columns["shipdate"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Messrs"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["Messrs"].Width = 230;
            this.myDataGridViewHead.Columns["Messrs"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["company"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["company"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["per"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["per"].HeaderText = "Shipped Per";
            this.myDataGridViewHead.Columns["per"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["sailingabout"].DisplayIndex = 8;
            this.myDataGridViewHead.Columns["sailingabout"].HeaderText = "sailing On or about";
            this.myDataGridViewHead.Columns["sailingabout"].Width = 150;
            this.myDataGridViewHead.Columns["sailingabout"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["PackingFrom"].DisplayIndex = 9;
            this.myDataGridViewHead.Columns["PackingFrom"].HeaderText = "From";
            this.myDataGridViewHead.Columns["PackingFrom"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["PackingTo"].DisplayIndex = 10;
            this.myDataGridViewHead.Columns["PackingTo"].HeaderText = "To";
            this.myDataGridViewHead.Columns["PackingTo"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["ContractNo"].DisplayIndex = 11;
            this.myDataGridViewHead.Columns["ContractNo"].HeaderText = "Contract No";
            this.myDataGridViewHead.Columns["ContractNo"].Width = 100;
            this.myDataGridViewHead.Columns["ContractNo"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["YourOrderNo"].DisplayIndex = 12;
            this.myDataGridViewHead.Columns["YourOrderNo"].HeaderText = "Your Order No";
            this.myDataGridViewHead.Columns["YourOrderNo"].Width = 110;
            this.myDataGridViewHead.Columns["YourOrderNo"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["InputDate"].DisplayIndex = 13;
            this.myDataGridViewHead.Columns["InputDate"].Width = 78;
            this.myDataGridViewHead.Columns["InputDate"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["InputUser"].DisplayIndex = 14;
            this.myDataGridViewHead.Columns["InputUser"].Width = 78;
            this.myDataGridViewHead.Columns["InputUser"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Remark"].DisplayIndex = 15;
            this.myDataGridViewHead.Columns["Remark"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark1"].DisplayIndex = 16;
            this.myDataGridViewHead.Columns["Mark1"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark2"].DisplayIndex = 17;
            this.myDataGridViewHead.Columns["Mark2"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark3"].DisplayIndex = 18;
            this.myDataGridViewHead.Columns["Mark3"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark4"].DisplayIndex = 19;
            this.myDataGridViewHead.Columns["Mark4"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark5"].DisplayIndex = 20;
            this.myDataGridViewHead.Columns["Mark5"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark6"].DisplayIndex = 21;
            this.myDataGridViewHead.Columns["Mark6"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark7"].DisplayIndex = 22;
            this.myDataGridViewHead.Columns["Mark7"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["工缴费率"].DisplayIndex = 23;
            this.myDataGridViewHead.Columns["工缴费率"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["工缴费率"].Visible = false;
            this.myDataGridViewHead.Columns["发票号"].DisplayIndex = 23;
            this.myDataGridViewHead.Columns["发票号"].ContextMenuStrip = this.myContextHead;
        }

        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["BM"].Visible = false;
            this.myDataGridViewDetails.Columns["BM"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["id"].Visible = false;
            this.myDataGridViewDetails.Columns["id"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["出口成品id"].Visible = false;
            this.myDataGridViewDetails.Columns["出口成品id"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["Unit1"].Visible = false;
            this.myDataGridViewDetails.Columns["Unit1"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["Unit2"].Visible = false;
            this.myDataGridViewDetails.Columns["Unit2"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["剩余量"].Visible = false;
            this.myDataGridViewDetails.Columns["剩余量"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["PackageNo"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["PackageNo"].HeaderText = "Packing No(箱号)";
            this.myDataGridViewDetails.Columns["PackageNo"].Width = 130;
            this.myDataGridViewDetails.Columns["PackageNo"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["手册编号"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["手册编号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["序号"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["序号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["品名规格型号"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["品名规格型号"].HeaderText = "Deacription of Goods";
            this.myDataGridViewDetails.Columns["品名规格型号"].Width = 150;
            this.myDataGridViewDetails.Columns["品名规格型号"].ContextMenuStrip = this.myContextDetails;
            //this.myDataGridViewDetails.Columns["BoxNum"].DisplayIndex = 4;
            //this.myDataGridViewDetails.Columns["BoxNum"].HeaderText = "箱数";
            //this.myDataGridViewDetails.Columns["BoxNum"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["Quantity"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["Quantity"].HeaderText = "Quantity箱";
            this.myDataGridViewDetails.Columns["Quantity"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.myDataGridViewDetails.Columns["Quantity"].DefaultCellStyle = dataGridViewCellStyle1;

            this.myDataGridViewDetails.Columns["Unit"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["Unit"].HeaderText = "单位";
            this.myDataGridViewDetails.Columns["Unit"].ContextMenuStrip = this.myContextDetails;

            this.myDataGridViewDetails.Columns["UnitPrice"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["UnitPrice"].HeaderText = "单价";
            this.myDataGridViewDetails.Columns["UnitPrice"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["UnitPrice"].DefaultCellStyle = dataGridViewCellStyle1;

            this.myDataGridViewDetails.Columns["TotalPrice"].DisplayIndex = 9;
            this.myDataGridViewDetails.Columns["TotalPrice"].HeaderText = "总金额";
            this.myDataGridViewDetails.Columns["TotalPrice"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["TotalPrice"].DefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridViewDetails.Columns["nw"].DisplayIndex = 10;
            this.myDataGridViewDetails.Columns["nw"].HeaderText = "Net Weight";
            this.myDataGridViewDetails.Columns["nw"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["nw"].DefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridViewDetails.Columns["gw"].DisplayIndex = 11;
            this.myDataGridViewDetails.Columns["gw"].HeaderText = "Gross Weight";
            this.myDataGridViewDetails.Columns["gw"].Width = 100;
            this.myDataGridViewDetails.Columns["gw"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["gw"].DefaultCellStyle = dataGridViewCellStyle1;

        }

        #region 加载数据
        /// <summary>
        /// 加载表头数据
        /// </summary>
        private void LoadDataSourceHead()
        {
            try
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = @"select Packing1.*, Company.com_Abbr AS company, Customer.E_Name AS Messrs
                                  FROM Company right outer JOIN Packing1 ON Company.comid = Packing1.comid left outer JOIN Customer ON Packing1.custid = Customer.custId" + 
                                    (gstrWhere.Length > 0 ? " where " : "") + gstrWhere + " ORDER BY inputdate DESC";
                DataTable dtHead = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                bTriggerGridViewHead_SelectionChanged = false;
                this.myDataGridViewHead.DataSource = dtHead;
                DataTableTools.AddEmptyRow(dtHead);
                bTriggerGridViewHead_SelectionChanged = true;
                this.myDataGridViewHead_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【出口装箱单】数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        /// <summary>
        /// 加载订单内容数据
        /// </summary>
        private void LoadDataSourceDetails()
        {
            try
            {
                int iOrderID = 0;
                string strBooksNo = string.Empty;
                if (this.myDataGridViewHead.CurrentRowNew != null)
                {
                    if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["Pid"].Value != DBNull.Value)
                    {
                        iOrderID = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["Pid"].Value;
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = string.Format("exec 出口装箱单录入查询 {0}", iOrderID);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtDetails);
                this.myDataGridViewDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【PACKING LIST】出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        #endregion

        #region tools事件
        public override void tool1_First_Click(object sender, EventArgs e)
        {
            base.tool1_First_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells["InvoiceNo"];
            setTool1Enabled();
        }

        public override void tool1_up_Click(object sender, EventArgs e)
        {
            base.tool1_up_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells["InvoiceNo"];
            setTool1Enabled();

        }

        public override void tool1_Down_Click(object sender, EventArgs e)
        {
            base.tool1_Down_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells["InvoiceNo"];
            setTool1Enabled();
        }

        public override void tool1_End_Click(object sender, EventArgs e)
        {
            base.tool1_End_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells["InvoiceNo"];
            setTool1Enabled();
        }

        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            base.tool1_Add_Click(sender, e);
            FormPackingOutInput objForm = new FormPackingOutInput();
            objForm.MdiParent = this.MdiParent;
            objForm.Show();
        }

        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            base.tool1_Modify_Click(sender, e);
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["Pid"].Value);
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormPackingOutInput")
                {
                    FormPackingOutInput inputForm = (FormPackingOutInput)childFrm;
                    if (inputForm.giOrderID != 0 && inputForm.giOrderID == iOrderID)
                    {
                        bHave = true;
                        childFrm.Activate();
                        break;
                    }
                }
            }
            if (!bHave)
            {
                FormPackingOutInput objForm = new FormPackingOutInput();
                objForm.MdiParent = this.MdiParent;
                objForm.giOrderID = iOrderID;
                objForm.Show();
            }
        }

        public override void tool1_Delete_Click(object sender, EventArgs e)
        {
            base.tool1_Delete_Click(sender, e);
            if (this.myDataGridViewHead.CurrentRow == null) return;
            string strText = string.Format("真的要删除单号 【{0}】 吗？", this.myDataGridViewHead.CurrentRow.Cells["InvoiceNo"].Value);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.Cancel) return;
            try
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = string.Format("删除指定的出口装箱单 {0}", this.myDataGridViewHead.CurrentRow.Cells["Pid"].Value);
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["InvoiceNo"].Value);
                this.myDataGridViewHead.Rows.Remove(this.myDataGridViewHead.CurrentRow);
                setTool1Enabled();
                SysMessage.InformationMsg(strSuccess);
            }
            catch (Exception ex)
            {
                string strError = string.Format("{0} 出现错误：错误信息：{1}", tool1_Delete.Text, ex.Message);
                SysMessage.ErrorMsg(strError);
            }
        }

        public override void tool1_Query_Click(object sender, EventArgs e)
        {
            base.tool1_Query_Click(sender, e);
            FormPackingOutQueryCondition queryConditionForm = new FormPackingOutQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrWhere = queryConditionForm.strReturnWhere;
                LoadDataSourceHead();
            }
        }

        public override void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            base.tool1_ExportExcel_Click(sender, e);

            if (this.myDataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;

            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridViewDetails.DataSource, string.Empty);
        }

        public override void tool1_Print_Click(object sender, EventArgs e)
        {
            base.tool1_Print_Click(sender, e);
            int custid = 0;
            DataGridViewRow dgv = null;
            if (this.myDataGridViewHead.CurrentRowNew != null)
            {
                if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["custid"].Value != DBNull.Value)
                {
                    custid = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["custid"].Value;
                    dgv = this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index];
                }
                else
                    return;
            }
            else
                return;
            string sql = string.Empty;
            DataTable rs = null;
            DataTable rs1 = null;
            DataTable rs2 = null;
            string st3 = string.Empty;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            sql = string.Format("select * from customer where custid={0}", custid);
            rs = dataAccess.GetTable(sql, null);
            dataAccess.Close();
            List<string> listMark = new List<string>();
            if (dgv.Cells["mark1"].Value != DBNull.Value && dgv.Cells["mark1"].ToString().Trim() != "")
            {
                listMark.Add(dgv.Cells["mark1"].Value.ToString());
            }
            if (dgv.Cells["mark2"].Value != DBNull.Value && dgv.Cells["mark2"].ToString().Trim() != "")
            {
                listMark.Add(dgv.Cells["mark2"].Value.ToString());
            }
            if (dgv.Cells["mark3"].Value != DBNull.Value && dgv.Cells["mark3"].ToString().Trim() != "")
            {
                listMark.Add(dgv.Cells["mark3"].Value.ToString());
            }
            if (dgv.Cells["mark4"].Value != DBNull.Value && dgv.Cells["mark4"].ToString().Trim() != "")
            {
                listMark.Add(dgv.Cells["mark4"].Value.ToString());
            }
            if (dgv.Cells["mark5"].Value != DBNull.Value && dgv.Cells["mark5"].ToString().Trim() != "")
            {
                listMark.Add(dgv.Cells["mark5"].Value.ToString());
            }
            if (dgv.Cells["mark6"].Value != DBNull.Value && dgv.Cells["mark6"].ToString().Trim() != "")
            {
                listMark.Add(dgv.Cells["mark6"].Value.ToString());
            }
            if (dgv.Cells["mark7"].Value != DBNull.Value && dgv.Cells["mark7"].ToString().Trim() != "")
            {
                listMark.Add(dgv.Cells["mark7"].Value.ToString());
            }
            int pid = Convert.ToInt32(dgv.Cells["pid"].Value);
            sql = string.Format("SELECT SUM(Quantity) AS Quantity, Unit FROM PackingDetail1 where pid = {0} GROUP BY Unit", pid);  //单位数量汇总
            dataAccess.Open();
            rs2 = dataAccess.GetTable(sql);
            sql = string.Format("SELECT count(id) AS totalbox FROM dbo.PackingDetail1 WHERE (PackageNo IS NOT NULL) and pid={0}", pid);  //总数量汇总
            rs1 = dataAccess.GetTable(sql);
            //sql = string.Format("SELECT SUM(Quantity*unitprice) AS Totalprice FROM PackingDetail1 where pid={0}", pid);   //总金额汇总
            //DataTable rs5 = dataAccess.GetTable(sql);
            //decimal totalPrice = 0;
            //if (rs5.Rows.Count > 0)
            //    totalPrice = Convert.ToDecimal(rs5.Rows[0]["Totalprice"]);
            dataAccess.Close();

            string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\出口装箱单明细.xls");
            string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\出口装箱单明细{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
            File.Copy(strSourceFile, strDestFile);
            File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
            string fn = strDestFile;
            //string fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\制造单清单明细表.xls");
            ExcelTools ea = new ExcelTools();
            ea.SafeOpen(fn);
            ea.ActiveSheet(1); // 激活
            DataRow rowCust = rs.Rows[0];
            ea.SetValue("C9", "     " + dgv.Cells["INVOICENO"].Value.ToString());
            ea.SetValue("I9", "     " + Convert.ToDateTime(dgv.Cells["ExportDate"].Value).ToString("yyyy-MM-dd"));
            ea.SetValue("C12", "     " + rowCust["e_name"].ToString());
            ea.SetValue("F14", "    " + dgv.Cells["PackingFrom"].Value.ToString());
            ea.SetValue("C15", "    " + dgv.Cells["PackingTo"].Value.ToString());
            int iMark = 11;
            for(int i = 0; i< listMark.Count; i++)
            {
                ea.SetValue(string.Format("H{0}", iMark + i), listMark[i]);
            }

            int iExcelModelBeginIndex = 19;
            DataTable dtDetail = (DataTable)this.myDataGridViewDetails.DataSource;
            int iIndex = iExcelModelBeginIndex;
            int iCount = dtDetail.Rows.Count;

            decimal nw = 0;
            decimal gw = 0;
            for (int iRow = 0; iRow < dtDetail.Rows.Count; iRow++)
            {
                DataRow row = dtDetail.Rows[iRow];
                //if (iCount > 1 && iRow < iCount - 1)
                //{
                    ea.InsertRows(iIndex +1);
                    ea.SetMerge(string.Format("A{0}:B{0}", iIndex));
                    ea.SetHorisontalAlignment(string.Format("A{0}:B{0}", iIndex), 3);  //居中
                    //ea.SetBorderStyle(string.Format("A{0}:B{0}", iIndex), 1);

                    ea.SetMerge(string.Format("C{0}:F{0}", iIndex));
                    ea.SetHorisontalAlignment(string.Format("C{0}:F{0}", iIndex), 1);  //左对齐
                    
                    ea.SetHorisontalAlignment(string.Format("G{0}", iIndex), 4);   //右对齐

                    ea.SetMerge(string.Format("H{0}:I{0}", iIndex));
                    ea.SetHorisontalAlignment(string.Format("H{0}:I{0}", iIndex), 4);
                    //ea.SetBorderStyle(string.Format("H{0}:I{0}", iIndex), 4);
                    ea.SetHorisontalAlignment(string.Format("J{0}", iIndex), 4);
                //}
                ea.SetValue(string.Format("A{0}", iIndex), row["PackageNo"] == DBNull.Value ? "" : row["PackageNo"].ToString());
                ea.SetValue(string.Format("C{0}", iIndex), row["品名规格型号"] == DBNull.Value ? "" : row["品名规格型号"].ToString());
                ea.SetValue(string.Format("G{0}", iIndex), string.Format("{0}{1}", row["QUANTITY"] == DBNull.Value ? "" : Convert.ToDecimal(row["QUANTITY"]).ToString("F2"),row["UNIT"].ToString().Trim()));
                ea.SetValue(string.Format("H{0}", iIndex), string.Format("{0}{1}", row["NW"] == DBNull.Value ? "" : Convert.ToDecimal(row["NW"]).ToString("F2"), row["UNIT1"].ToString().Trim()));
                ea.SetValue(string.Format("J{0}", iIndex), string.Format("{0}{1}", row["GW"] ==DBNull.Value ? "" : Convert.ToDecimal(row["GW"]).ToString("F2"), row["UNIT2"].ToString().Trim()));
                nw += (row["NW"] == DBNull.Value ? 0 : Convert.ToDecimal(row["NW"]));
                gw += (row["GW"] == DBNull.Value ? 0 : Convert.ToDecimal(row["GW"]));
                ea.SetRowHeight(string.Format("A{0}", iIndex), 20);
                iIndex++;
            }
            ea.SetRowHeight(string.Format("A{0}", iIndex), 2);
            ea.SetRowHeight(string.Format("A{0}", iIndex+1), 2);
            iIndex = iIndex + 2;
            //ea.SetValue(string.Format("C{0}", iIndex), "TOTAL:");
            //ea.SetHorisontalAlignment(string.Format("C{0}", iIndex), 4);   //右对齐
            //Font font = new Font("楷体", 12, FontStyle.Bold);
            //ea.SetFont(string.Format("C{0}", iIndex), font);

            ea.SetValue(string.Format("D{0}", iIndex), rs1.Rows[0]["totalbox"].ToString());
            //ea.SetHorisontalAlignment(string.Format("D{0}", iIndex), 3);  //居中
            //ea.SetFont(string.Format("D{0}", iIndex), font);

            //ea.SetValue(string.Format("E{0}", iIndex), "CARTONS");
            //ea.SetHorisontalAlignment(string.Format("E{0}", iIndex), 1);  //左对齐
            ////Font font = new Font("楷体", 12, FontStyle.Bold);
            //ea.SetFont(string.Format("E{0}",iIndex), font);
            if (nw > 0)
            {
                ea.SetMerge(string.Format("H{0}:I{0}", iIndex));
                ea.SetValue(string.Format("H{0}", iIndex), nw.ToString("F2") + "KGS");
                ea.SetHorisontalAlignment(string.Format("H{0}", iIndex), 4);   //右对齐
            }
            if (gw > 0)
            {
                ea.SetValue(string.Format("J{0}", iIndex), gw.ToString("F2") + "KGS");
                ea.SetHorisontalAlignment(string.Format("J{0}", iIndex), 4);   //右对齐
            }
            for (int i=0;i<rs2.Rows.Count; i++)
            {
                DataRow row = rs2.Rows[i];
                ea.SetValue(string.Format("G{0}", iIndex), string.Format("{0}{1}", row["QUANTITY"] == DBNull.Value ? "" : Convert.ToDecimal(row["QUANTITY"]).ToString("F2"), row["UNIT"].ToString().Trim()));
                ea.SetHorisontalAlignment(string.Format("G{0}", iIndex), 4);
                ea.SetRowHeight(string.Format("A{0}", iIndex), 20);
                iIndex++;
            }
            ea.Visible = true;
            ea.Dispose();
        }
        //过帐或取消过帐处理
        public override void tool1_Import_Click(object sender, EventArgs e)
        {
            base.tool1_Import_Click(sender, e);
            if (this.myDataGridViewHead.CurrentRow == null) return;
            string strTemp = string.Empty;
            int i过帐标志 = 0;
            if (this.myDataGridViewHead.CurrentRow.Cells["过帐标志"].Value != DBNull.Value && this.myDataGridViewHead.CurrentRow.Cells["过帐标志"].Value != null
                && Convert.ToBoolean(this.myDataGridViewHead.CurrentRow.Cells["过帐标志"].Value) == true)
            {
                strTemp = "取消";
                i过帐标志 = 0;
            }
            else
            {
                i过帐标志 = 1;
            }

            string strText = string.Format("确定要{0}过帐出库单号【{1}】 吗？", strTemp, this.myDataGridViewHead.CurrentRow.Cells["出库单号"].Value);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.Cancel) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            string strSQL = string.Format("UPDATE 进口料件出库表 SET 过帐标志 ={0} WHERE 料件出库表id ={1}", i过帐标志, this.myDataGridViewHead.CurrentRow.Cells["料件出库表id"].Value);
            dataAccess.ExecuteNonQuery(strSQL, null);
            dataAccess.Close();
            this.myDataGridViewHead.CurrentRow.Cells["过帐标志"].Value = i过帐标志;
            //string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["出库单号"].Value);
            //SysMessage.InformationMsg(strSuccess);
        }
        /// <summary>
        /// 设置tools的按钮是否可用
        /// </summary>
        private void setTool1Enabled()
        {
            this.tool1_Query.Enabled = true;
            this.tool1_Add.Enabled = true;
            DataTable dtTable = (DataTable)myDataGridViewHead.DataSource;
            if (dtTable.Rows.Count > 0)
            {
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
                    if (this.myDataGridViewHead.CurrentRow == null) return;
                    if (this.myDataGridViewHead.CurrentRow.Index == 0)
                    {
                        this.tool1_First.Enabled = false;
                        this.tool1_up.Enabled = false;
                        this.tool1_Down.Enabled = true;
                        this.tool1_End.Enabled = true;
                    }
                    else if (this.myDataGridViewHead.CurrentRow.Index == this.myDataGridViewHead.RowCount - 1)  //如果行索引为最后一行
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

                this.tool1_Modify.Enabled = true;
                this.tool1_Delete.Enabled = true;
                this.tool1_ExportExcel.Enabled = true;
                this.tool1_Print.Enabled = true;
            }
            else
            {
                this.tool1_First.Enabled = false;
                this.tool1_up.Enabled = false;
                this.tool1_Down.Enabled = false;
                this.tool1_End.Enabled = false;

                this.tool1_Modify.Enabled = false;
                this.tool1_Delete.Enabled = false;
                this.tool1_ExportExcel.Enabled = false;
                this.tool1_Print.Enabled = false;
            }
        }
        #endregion

        public override void myDataGridViewHead_SelectionChanged(object sender, EventArgs e)
        {
            base.myDataGridViewHead_SelectionChanged(sender, e);
            if (bTriggerGridViewHead_SelectionChanged)
            {
                setTool1Enabled();
                LoadDataSourceDetails();
            }
        }
    }
}
