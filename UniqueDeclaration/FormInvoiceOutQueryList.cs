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
    public partial class FormInvoiceOutQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormInvoiceOutQueryList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否触发行变化事件
        /// </summary>
        private bool bTriggerGridViewHead_SelectionChanged = true;
        /// <summary>
        /// 是否触发行变化事件
        /// </summary>
        private bool bTriggerGridViewDetails_SelectionChanged = true;
        /// <summary>
        /// 查询窗体的返回来的条件
        /// </summary>
        public string gstrWhere = string.Empty;

        private void FormInvoiceOutQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_Import.Visible = false;
            this.tool1_Add.Visible = false;
            this.tool1_Delete.Visible = false;
            this.tool1_Modify.Visible = false;
            this.tool1_Number.Visible = true;
            
            this.myDataGridViewDetails.SelectionChanged += new EventHandler(myDataGridViewDetails_SelectionChanged);
            LoadDataSourceHead();
            InitGridHead();
            InitGridDetails();
            InitGridDetails2();
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
                string strSQL = @"select packing1.*, Company.com_Abbr AS cust, Customer.E_Name AS Messrs 
                                    FROM Company right outer JOIN packing1 ON Company.comid = packing1.comid left outer JOIN Customer ON packing1.custid = Customer.custId " +
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
                SysMessage.ErrorMsg(string.Format("加载【InvoiceOut】数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
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
                string strSQL = string.Format("exec 出口装箱单查询 {0}", iOrderID);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();                
                DataTableTools.AddEmptyRow(dtDetails);
                bTriggerGridViewDetails_SelectionChanged = false;
                this.myDataGridViewDetails.DataSource = dtDetails;
                bTriggerGridViewDetails_SelectionChanged = true;
                this.myDataGridViewDetails_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【InvoiceOut】出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        /// <summary>
        /// 加载第二个明细GRID数据
        /// </summary>
        private void LoadDataSourceDetails2()
        {
            try
            {
                string idvalue = DateTime.Now.ToString("yyyyMMddHHmmss");
                string str装箱单号=this.myDataGridViewHead.CurrentRowNew == null ? string.Empty : (this.myDataGridViewHead.CurrentRowNew.Cells["装箱单号"].Value ==DBNull.Value ? string.Empty : this.myDataGridViewHead.CurrentRowNew.Cells["装箱单号"].Value.ToString());
                int i序号 =this.myDataGridViewDetails.CurrentRowNew==null ? 0 : (this.myDataGridViewDetails.CurrentRowNew.Cells["序号"].Value == DBNull.Value ? 0 : Convert.ToInt32(this.myDataGridViewDetails.CurrentRowNew.Cells["序号"].Value));
                
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = string.Format("SELECT 装箱单表.订单号码,装箱单明细表.成品项号,装箱单明细表.归并前成品序号, 装箱单明细表.数量 FROM 装箱单表 LEFT OUTER JOIN 装箱单明细表 ON 装箱单表.订单id =装箱单明细表.订单id WHERE 装箱单表.装箱单号={0} and 装箱单明细表.成品项号={1}", StringTools.SqlQ(str装箱单号),i序号);
                DataTable crs = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (crs.Rows.Count > 0)
                {
                    DataTable drs = null;
                    IDataAccess dataManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataManufacture.Open();
                    foreach (DataRow row in crs.Rows)
                    {
                        drs = dataManufacture.GetTable(string.Format(@"SELECT 报关订单表.订单号码,报关订单明细表.订单id,报关订单明细表.订单明细表id,报关订单明细表.成品项号,报关订单明细表.版本号 
                                                                       FROM 报关订单明细表 RIGHT OUTER JOIN 报关订单表 ON 报关订单明细表.订单id = 报关订单表.订单id 
                                                                      where 报关订单表.订单号码='{0}' and 报关订单明细表.成品项号={1} and 报关订单明细表.版本号={2}",
                                                                        row["订单号码"], row["成品项号"], row["归并前成品序号"]), null);
                        if (drs.Rows.Count > 0)
                        {
                            dataManufacture.ExecuteNonQuery(string.Format("INSERT INTO 装箱单订单明细表(idv,订单id,订单明细表id,数量) VALUES('{0}',{1},{2},{3})",
                                    idvalue, drs.Rows[0]["订单ID"], drs.Rows[0]["订单明细表id"], row["数量"]), null);
                        }
                    }
                    dataManufacture.ExecuteNonQuery(string.Format("装箱单平均单耗明细 '{0}','{1}','',{2}",
                        idvalue, this.myDataGridViewDetails.CurrentRowNew.Cells["产品编号"].Value == DBNull.Value ? string.Empty : this.myDataGridViewDetails.CurrentRowNew.Cells["产品编号"].Value.ToString(),
                        this.myDataGridViewDetails.CurrentRowNew.Cells["Quantity"].Value == DBNull.Value ? 0 : Convert.ToDecimal(this.myDataGridViewDetails.CurrentRowNew.Cells["Quantity"].Value)), null);
                    dataManufacture.ExecuteNonQuery(string.Format("DELETE FROM 装箱单订单明细表 where idv='{0}'", idvalue), null);
                    DataTable dtTemp = dataManufacture.GetTable(string.Format(@"SELECT ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) as 项号,
                                                        left(ltrim(料号),3) as 料号,max(商品编码) as 商品编码, max(商品名称) as 商品名称, max(商品规格) as 商品规格, max(计量单位) as 计量单位, 
                                                        str(sum(case when 数量=0 or 数量 is null then 0 else 单耗/数量 end),10,5) as 单耗,max(损耗率) as 损耗率, max(非保科料件比例) as 非保科料件比例 
                                                        FROM 装箱单平均单耗 where idv='{0}' group by ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end),
                                                        left(ltrim(料号),3)", idvalue), null);
                    this.myDataGridViewDetails2.DataSource = dtTemp;
                    DataTableTools.AddEmptyRow(dtTemp);
                    dataManufacture.ExecuteNonQuery(string.Format("DELETE FROM 装箱单平均单耗 where idv='{0}'", idvalue), null);
                    dataManufacture.Close();
                }
                else
                {
                    IDataAccess dataManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataManufacture.Open();
                    DataTable dtTemp = dataManufacture.GetTable(string.Format(@"SELECT ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) as 项号,
                                                        left(ltrim(料号),3) as 料号,max(商品编码) as 商品编码, max(商品名称) as 商品名称, max(商品规格) as 商品规格, max(计量单位) as 计量单位, 
                                                        str(sum(case when 数量=0 or 数量 is null then 0 else 单耗/数量 end),10,5) as 单耗,max(损耗率) as 损耗率, max(非保科料件比例) as 非保科料件比例 
                                                        FROM 装箱单平均单耗 where idv='{0}' group by ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end),
                                                        left(ltrim(料号),3)", idvalue), null);
                    this.myDataGridViewDetails2.DataSource = dtTemp;
                    DataTableTools.AddEmptyRow(dtTemp);
                    dataManufacture.Close();
                }
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【InvoiceOut】出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        #endregion

        private void InitGridHead()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["Pid"].Visible = false;
            this.myDataGridViewHead.Columns["Pid"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["custid"].Visible = false;
            this.myDataGridViewHead.Columns["custid"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["cust"].Visible = false;
            this.myDataGridViewHead.Columns["cust"].ContextMenuStrip = this.myContextHead;
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
            //this.myDataGridViewHead.Columns["company"].DisplayIndex = 6;
            //this.myDataGridViewHead.Columns["company"].ContextMenuStrip = this.myContextHead;
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
        }

        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["Pid"].Visible = false;
            this.myDataGridViewDetails.Columns["Pid"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["Package"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["Package"].HeaderText = "PACKAGE";
            this.myDataGridViewDetails.Columns["Package"].Width = 70;
            this.myDataGridViewDetails.Columns["Package"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["手册编号"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["手册编号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["序号"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["序号"].Width = 55;
            this.myDataGridViewDetails.Columns["序号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["产品编号"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["产品编号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["品名规格型号"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["品名规格型号"].HeaderText = "Description of Goods";
            this.myDataGridViewDetails.Columns["品名规格型号"].Width = 150;
            this.myDataGridViewDetails.Columns["品名规格型号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["Quantity"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["Quantity"].HeaderText = "Quantity箱";
            this.myDataGridViewDetails.Columns["Quantity"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.myDataGridViewDetails.Columns["Quantity"].DefaultCellStyle = dataGridViewCellStyle1;

            this.myDataGridViewDetails.Columns["Unit"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["Unit"].HeaderText = "UNIT";
            this.myDataGridViewDetails.Columns["Unit"].ContextMenuStrip = this.myContextDetails;

            this.myDataGridViewDetails.Columns["单价"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["单价"].HeaderText = "UnitPrice";
            this.myDataGridViewDetails.Columns["单价"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;

            this.myDataGridViewDetails.Columns["币种"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["币种"].HeaderText = "CUR";
            this.myDataGridViewDetails.Columns["币种"].Width = 55;
            this.myDataGridViewDetails.Columns["币种"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["Amount"].DisplayIndex = 10;
            this.myDataGridViewDetails.Columns["Amount"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["Amount"].DefaultCellStyle = dataGridViewCellStyle1;

        }

        private void InitGridDetails2()
        {
            this.myDataGridViewDetails2.AutoGenerateColumns = false;

            this.myDataGridViewDetails2.Columns["项号"].Width = 55;
            this.myDataGridViewDetails2.Columns["项号"].ContextMenuStrip = this.myContextDetails2;
            //this.myDataGridViewDetails2.Columns["料号"].Width = 70;
            this.myDataGridViewDetails2.Columns["料号"].ContextMenuStrip = this.myContextDetails2;
            //this.myDataGridViewDetails2.Columns["商品编码"].Width = 78;
            this.myDataGridViewDetails2.Columns["商品编码"].ContextMenuStrip = this.myContextDetails2;
            //this.myDataGridViewDetails2.Columns["商品名称"].Width = 55;
            this.myDataGridViewDetails2.Columns["商品名称"].ContextMenuStrip = this.myContextDetails2;
            //this.myDataGridViewDetails2.Columns["商品规格"].Width = 55;
            this.myDataGridViewDetails2.Columns["商品规格"].ContextMenuStrip = this.myContextDetails2;
            this.myDataGridViewDetails2.Columns["计量单位"].Width = 78;
            this.myDataGridViewDetails2.Columns["计量单位"].ContextMenuStrip = this.myContextDetails2;
            //this.myDataGridViewDetails2.Columns["单耗"].Width = 80;
            this.myDataGridViewDetails2.Columns["单耗"].HeaderText = "单耗/净耗";
            this.myDataGridViewDetails2.Columns["单耗"].ContextMenuStrip = this.myContextDetails2;
            this.myDataGridViewDetails2.Columns["损耗率"].Width = 70;
            this.myDataGridViewDetails2.Columns["损耗率"].ContextMenuStrip = this.myContextDetails2;
            this.myDataGridViewDetails2.Columns["非保科料件比例"].Width = 130;
            this.myDataGridViewDetails2.Columns["非保科料件比例"].ContextMenuStrip = this.myContextDetails2;
        }

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

        public override void tool1_Number_Click(object sender, EventArgs e)
        {
            base.tool1_Number_Click(sender, e);

            if (this.myDataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;

            string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\单损耗调整导入.xls");
            string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\单损耗调整导入{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
            File.Copy(strSourceFile, strDestFile);
            File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
            string fn = strDestFile;
            ExcelTools ea = new ExcelTools();
            ea.SafeOpen(fn);
            ea.ActiveSheet(1); // 激活
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable xrs = dataAccess.GetTable(string.Format("出口装箱单查询 {0}",this.myDataGridViewHead.CurrentRow.Cells["Pid"].Value), null);
            dataAccess.Close();
            if (xrs.Rows.Count > 0)
            {
                string idvalue = DateTime.Now.ToString("yyyyMMddHHmmss");
                string codevalue = string.Empty;
                long n = 2;   //EXCEL的起始行
                foreach (DataRow xrsRow in xrs.Rows)
                {
                    dataAccess.Open();
                    DataTable crs = dataAccess.GetTable(string.Format(@"SELECT 装箱单表.订单号码,装箱单明细表.成品项号,装箱单明细表.归并前成品序号, 装箱单明细表.数量 
                                                                FROM 装箱单表 LEFT OUTER JOIN 装箱单明细表 ON 装箱单表.订单id =装箱单明细表.订单id 
                                                                WHERE 装箱单表.装箱单号={0} and 装箱单明细表.成品项号={1}",
                    this.myDataGridViewHead.CurrentRow.Cells["装箱单号"].Value == DBNull.Value ? StringTools.SqlQ(string.Empty) : StringTools.SqlQ(this.myDataGridViewHead.CurrentRow.Cells["装箱单号"].Value.ToString()),
                    xrsRow["序号"] == DBNull.Value ? 0 : Convert.ToInt32(xrsRow["序号"])), null);
                    dataAccess.Close();
                    if (crs.Rows.Count > 0)
                    {
                        IDataAccess dataManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                        foreach (DataRow crsRow in crs.Rows)
                        {
                            dataManufacture.Open();
                            DataTable drs = dataManufacture.GetTable(string.Format(@"SELECT 报关订单表.订单号码,报关订单明细表.订单id,报关订单明细表.订单明细表id,报关订单明细表.成品项号,报关订单明细表.版本号 
                                                                                    FROM 报关订单明细表 RIGHT OUTER JOIN 报关订单表 ON 报关订单明细表.订单id = 报关订单表.订单id 
                                                                                    where 报关订单表.订单号码={0} and 报关订单明细表.成品项号={1} and 报关订单明细表.版本号={2}",
                                                StringTools.SqlQ( crsRow["订单号码"].ToString()),crsRow["成品项号"]==DBNull.Value ? 0 : Convert.ToInt32(crsRow["成品项号"]),
                                                crsRow["归并前成品序号"] == DBNull.Value ? 0 : Convert.ToInt32(crsRow["归并前成品序号"])),null);
                            if (drs.Rows.Count > 0)
                            {
                                dataManufacture.ExecuteNonQuery(string.Format("INSERT INTO 装箱单订单明细表(idv,订单id,订单明细表id,数量) VALUES('{0}',{1},{2},{3})",
                                    idvalue, drs.Rows[0]["订单id"], drs.Rows[0]["订单明细表id"], crsRow["数量"] == DBNull.Value ? "NULL" : crsRow["数量"]), null);
                            }
                            dataManufacture.Close();
                        }
                        dataManufacture.Open();
                        dataManufacture.ExecuteNonQuery(string.Format("装箱单平均单耗明细 '{0}',{1},'',{2}",
                                        idvalue,xrsRow["产品编号"] == DBNull.Value ? string.Empty : StringTools.SqlQ( xrsRow["产品编号"].ToString()),
                                        xrsRow["Quantity"] == DBNull.Value ? 0 : xrsRow["Quantity"]),null);
                        dataManufacture.ExecuteNonQuery(string.Format("DELETE FROM 装箱单订单明细表 where idv='{0}'",idvalue), null);
                        DataTable lrs = dataManufacture.GetTable(string.Format(@"SELECT ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) as 项号,
                                        left(ltrim(料号),3) as 料号,max(商品编码) as 商品编码, max(商品名称) as 商品名称, max(商品规格) as 商品规格, max(计量单位) as 计量单位, 
                                        str(sum(case when 数量=0 or 数量 is null then 0 else 单耗/数量 end),10,5) as 单耗,max(损耗率) as 损耗率, max(非保科料件比例) as 非保科料件比例 
                                        FROM 装箱单平均单耗 where idv='{0}' group by ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end),left(ltrim(料号),3)",
                                                                  idvalue), null);
                        dataManufacture.ExecuteNonQuery(string.Format("DELETE FROM 装箱单平均单耗 where idv='{0}'",idvalue), null);
                        DataTable Yrs = dataAccess.GetTable(string.Format(@"SELECT 装箱单明细表.内部版本号 FROM 装箱单表 LEFT OUTER JOIN 装箱单明细表 ON 装箱单表.订单id = 装箱单明细表.订单id 
                                        WHERE 装箱单表.装箱单号={0} AND 装箱单明细表.成品项号={1}",
                        this.myDataGridViewHead.CurrentRow.Cells["装箱单号"].Value == DBNull.Value ? StringTools.SqlQ(string.Empty) : StringTools.SqlQ(this.myDataGridViewHead.CurrentRow.Cells["装箱单号"].Value.ToString()),
                        xrsRow["序号"] == DBNull.Value ? 0 : Convert.ToInt32(xrsRow["序号"])),null);
                        dataManufacture.Close();
                        if (Yrs.Rows.Count > 0)
                        {
                            codevalue = Yrs.Rows[0]["内部版本号"] == DBNull.Value ? string.Empty : Yrs.Rows[0]["内部版本号"].ToString();
                        }
                        else
                        {
                            codevalue = string.Empty;
                        }
                        if (lrs.Rows.Count > 0)
                        {
                            foreach(DataRow lrsRow in lrs.Rows)
                            {
                                ea.SetValue(string.Format("C{0}", n), xrsRow["序号"] == DBNull.Value ? string.Empty : xrsRow["序号"].ToString());
                                ea.SetValue(string.Format("D{0}", n), codevalue);
                                ea.SetValue(string.Format("F{0}", n), lrsRow["项号"] == DBNull.Value ? string.Empty : lrsRow["项号"].ToString());
                                ea.SetValue(string.Format("G{0}", n), lrsRow["单耗"] == DBNull.Value ? string.Empty : lrsRow["单耗"].ToString());
                                ea.SetValue(string.Format("H{0}", n), lrsRow["损耗率"] == DBNull.Value ? string.Empty : (Convert.ToDecimal(lrsRow["损耗率"]) * 100).ToString());
                                ea.SetValue(string.Format("R{0}", n), "1900-01-01");
                                ea.SetValue(string.Format("S{0}", n), "2050-12-31");
                                n++;
                            }
                        }
                    }
                }
            }
            //ea.Save(saveFileDialog.FileName);

            ea.Visible = true;
            ea.Dispose();
            /*
             Set xrs = DataEn.cnnPublic.Execute("出口装箱单查询 " & mRs!Pid)
            If xrs.RecordCount > 0 Then
                xrs.MoveFirst
                idvalue = Format(Now, "yyyyMMddhhmmss")
                n = 0
                Do While Not xrs.EOF
                    Set crs = DataEn.cnnPublic.Execute("SELECT 装箱单表.订单号码,装箱单明细表.成品项号,装箱单明细表.归并前成品序号, 装箱单明细表.数量 FROM 装箱单表 LEFT OUTER JOIN 装箱单明细表 ON 装箱单表.订单id =装箱单明细表.订单id WHERE 装箱单表.装箱单号='" & Trim(mRs!装箱单号 & "") & "' and 装箱单明细表.成品项号=" & xrs!序号)
                    If crs.RecordCount > 0 Then
                        crs.MoveFirst
                        Do While Not crs.EOF
                            Set drs = deManufacture.cnnPublic.Execute("SELECT 报关订单表.订单号码,报关订单明细表.订单id,报关订单明细表.订单明细表id,报关订单明细表.成品项号,报关订单明细表.版本号 FROM 报关订单明细表 RIGHT OUTER JOIN 报关订单表 ON 报关订单明细表.订单id = 报关订单表.订单id where 报关订单表.订单号码='" & crs!订单号码 & "' and 报关订单明细表.成品项号=" & crs!成品项号 & " and 报关订单明细表.版本号=" & crs!归并前成品序号)
                            If drs.RecordCount > 0 Then
                                deManufacture.cnnPublic.Execute ("INSERT INTO 装箱单订单明细表(idv,订单id,订单明细表id,数量) VALUES('" & idvalue & "'," & drs!订单id & "," & drs!订单明细表id & "," & crs!数量 & ")")
                            End If
                            crs.MoveNext
                        Loop
                        deManufacture.cnnPublic.Execute ("装箱单平均单耗明细 '" & idvalue & "','" & Trim(xrs!产品编号 & "") & "',''," & xrs!Quantity)
                        deManufacture.cnnPublic.Execute ("DELETE FROM 装箱单订单明细表 where idv='" & Trim(idvalue) & "'")
                        Set lrs = deManufacture.cnnPublic.Execute("SELECT ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) as 项号,left(ltrim(料号),3) as 料号,max(商品编码) as 商品编码, max(商品名称) as 商品名称, max(商品规格) as 商品规格, max(计量单位) as 计量单位, str(sum(case when 数量=0 or 数量 is null then 0 else 单耗/数量 end),10,5) as 单耗,max(损耗率) as 损耗率, max(非保科料件比例) as 非保科料件比例 FROM 装箱单平均单耗 where idv='" & Trim(idvalue) & "' group by ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end),left(ltrim(料号),3)")
                        deManufacture.cnnPublic.Execute ("DELETE FROM 装箱单平均单耗 where idv='" & Trim(idvalue) & "'")
                        Set Yrs = DataEn.cnnPublic.Execute("SELECT 装箱单明细表.内部版本号 FROM 装箱单表 LEFT OUTER JOIN 装箱单明细表 ON 装箱单表.订单id = 装箱单明细表.订单id WHERE 装箱单表.装箱单号='" & mRs!装箱单号 & "' AND 装箱单明细表.成品项号=" & Val(xrs!序号 & ""))
                        If Yrs.RecordCount > 0 Then
                           Yrs.MoveFirst
                           codevalue = Yrs!内部版本号
                        Else
                           codevalue = ""
                        End If
                        If lrs.RecordCount > 0 Then
                            lrs.MoveFirst
                            Do While Not lrs.EOF
                                objExcelWorkSheet.Range("C2").Offset(n, 0) = xrs!序号
                                objExcelWorkSheet.Range("D2").Offset(n, 0) = codevalue
                                objExcelWorkSheet.Range("F2").Offset(n, 0) = lrs!项号 & ""
                                objExcelWorkSheet.Range("G2").Offset(n, 0) = lrs!单耗 & ""
                                objExcelWorkSheet.Range("H2").Offset(n, 0) = lrs!损耗率 * 100 & ""
                                objExcelWorkSheet.Range("R2").Offset(n, 0) = "1900-01-01"
                                objExcelWorkSheet.Range("S2").Offset(n, 0) = "2050-12-31"
                                n = n + 1
                                lrs.MoveNext
                            Loop
                        End If
                    End If
                    xrs.MoveNext
                Loop
                Set objExcelWorkSheet = Nothing
                Set objExcelWorkBook = Nothing
                Set objExcelApp = Nothing
                Me.MousePointer = 0
            End If
            Exit Sub
             */
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

            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridViewHead.DataSource, string.Empty);
        }

        public override void tool1_Print_Click(object sender, EventArgs e)
        {
            base.tool1_Print_Click(sender, e);
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

        private void myDataGridViewDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (bTriggerGridViewDetails_SelectionChanged)
            {
                LoadDataSourceDetails2();
            }
        }
    }
}
