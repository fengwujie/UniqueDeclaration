using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;

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
        /// 查询窗体的返回来的条件
        /// </summary>
        public string gstrWhere = string.Empty;

        private void FormInvoiceOutQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_Import.Visible = false;
            //LoadDataSourceHead();
            //InitGridDetails();
            //InitGridHead();
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
                if (this.myDataGridViewHead.CurrentRow != null)
                {
                    if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRow.Index].Cells["Pid"].Value != DBNull.Value)
                    {
                        iOrderID = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRow.Index].Cells["Pid"].Value;
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
                string str装箱单号=this.myDataGridViewHead.CurrentRow == null ? string.Empty : (this.myDataGridViewHead.CurrentRow.Cells["装箱单号"].Value ==DBNull.Value ? string.Empty : this.myDataGridViewHead.CurrentRow.Cells["装箱单号"].Value.ToString());
                int i序号 =this.myDataGridViewDetails.CurrentRow==null ? 0 : (this.myDataGridViewDetails.CurrentRow.Cells["序号"].Value == DBNull.Value ? 0 : Convert.ToInt32(this.myDataGridViewDetails.CurrentRow.Cells["序号"].Value));
                
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = string.Format("SELECT 装箱单表.订单号码,装箱单明细表.成品项号,装箱单明细表.归并前成品序号, 装箱单明细表.数量 FROM 装箱单表 LEFT OUTER JOIN 装箱单明细表 ON 装箱单表.订单id =装箱单明细表.订单id WHERE 装箱单表.装箱单号={0} and 装箱单明细表.成品项号={1}", StringTools.SqlQ(str装箱单号),i序号);
                DataTable crs = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (crs.Rows.Count > 0)
                {
                    DataTable drs =null;
                    IDataAccess dataManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataManufacture.Open();
                    foreach(DataRow row in crs.Rows)
                    {
                        drs = dataManufacture.GetTable(string.Format(@"SELECT 报关订单表.订单号码,报关订单明细表.订单id,报关订单明细表.订单明细表id,报关订单明细表.成品项号,报关订单明细表.版本号 
                                                                       FROM 报关订单明细表 RIGHT OUTER JOIN 报关订单表 ON 报关订单明细表.订单id = 报关订单表.订单id 
                                                                      where 报关订单表.订单号码='{0}' and 报关订单明细表.成品项号={1} and 报关订单明细表.版本号={2}",
                                                                        row["订单号码"],row["成品项号"],row["归并前成品序号"]),null);
                        if (drs.Rows.Count > 0)
                        {
                            dataManufacture.ExecuteNonQuery(string.Format("INSERT INTO 装箱单订单明细表(idv,订单id,订单明细表id,数量) VALUES('{0}',{1},{2},{3})",
                                    idvalue,drs.Rows[0]["订单ID"],drs.Rows[0]["订单明细表id"],row["数量"]),null);
                        }
                    }
                    dataManufacture.ExecuteNonQuery(string.Format("装箱单平均单耗明细 '{0}','{1}','',{2}",
                        idvalue,this.myDataGridViewDetails.CurrentRow.Cells["产品编号"].Value == DBNull.Value ? string.Empty :this.myDataGridViewDetails.CurrentRow.Cells["产品编号"].Value.ToString() ,
                        this.myDataGridViewDetails.CurrentRow.Cells["Quantity"].Value == DBNull.Value ? 0 : Convert.ToDecimal(this.myDataGridViewDetails.CurrentRow.Cells["Quantity"].Value)),null);
                    dataManufacture.ExecuteNonQuery(string.Format("DELETE FROM 装箱单订单明细表 where idv='{0}'",idvalue),null);
                    DataTable dtTemp = dataManufacture.GetTable(string.Format(@"SELECT ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) as 项号,
                                                        left(ltrim(料号),3) as 料号,max(商品编码) as 商品编码, max(商品名称) as 商品名称, max(商品规格) as 商品规格, max(计量单位) as 计量单位, 
                                                        str(sum(case when 数量=0 or 数量 is null then 0 else 单耗/数量 end),10,5) as 单耗,max(损耗率) as 损耗率, max(非保科料件比例) as 非保科料件比例 
                                                        FROM 装箱单平均单耗 where idv='{0}' group by ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end),
                                                        left(ltrim(料号),3)",idvalue),null);
                    this.myDataGridViewDetails2.DataSource = dtTemp;
                    dataManufacture.ExecuteNonQuery(string.Format("DELETE FROM 装箱单平均单耗 where idv='{0}'",idvalue),null);
                    dataManufacture.Close();
                }
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【InvoiceOut】出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        #endregion
        
    }
}
