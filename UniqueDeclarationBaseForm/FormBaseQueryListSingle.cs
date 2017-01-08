using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;
using DataAccess;

namespace UniqueDeclarationBaseForm
{
    public partial class FormBaseQueryListSingle : UniqueDeclarationBaseForm.FormBase
    {
        public FormBaseQueryListSingle()
        {
            InitializeComponent();
        }

        public ReportsEnum mQueryWay;
        public string ManualCode = string.Empty;
        public DateTime mdEndDateTime;
        public string mdFromDate=string.Empty;
        public string mdToDate = string.Empty;
        public string mstrCode=string.Empty;
        public string mstrOrderCode = string.Empty;
        public string mdFromDateString = string.Empty;
        public string mdToDateString = string.Empty;
        public string gstrWhere = string.Empty;
        public int passvalue;

        DataTable dtData = null;
        public virtual void FormBaseJXCList_Load(object sender, EventArgs e)
        {
            LoadDataSource();
            InitGrid();
        }

        public virtual void LoadDataSource()
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            string strSQL = string.Empty;
            switch (mQueryWay)
            {
                case ReportsEnum.ReportsEnum_rpt剩余量:
                    this.Text = "制造通知单剩余量查询";
                    dataAccess.Open();
                    dtData = dataAccess.GetTable(string.Format("报关制造通知单剩余量查询 '{0}','{1}'",ManualCode,mstrCode), null);
                    dataAccess.Close();
                    this.myDataGridView1.DataSource = dtData;
                    this.lab_Count.Text =string.Format("记录总数：{0}", dtData.Rows.Count);
                    break;
                case ReportsEnum.ReportsEnum_rpt制造通知单在线量产品明细查询:
                    this.Text = "制造通知单在线量产品明细查询";
                    dataAccess.Open();
                    dataAccess.ExecuteNonQuery("delete from 装箱单明细临时表", null);
                    dataAccess.ExecuteNonQuery(string.Format(@"Insert into 装箱单明细临时表(手册编号,数量,归并前成品序号,日期,成品项号,订单号码) 
                                                        SELECT  XM.手册编号,XM.数量,XM.归并前成品序号,X.录入日期,XM.成品项号,XM.订单号码 
                                                        FROM OPENDATASOURCE('SQLOLEDB','Data Source=unique;User ID=SA;Password=').uniquegrade.dbo.装箱单表 X 
                                                        LEFT OUTER JOIN OPENDATASOURCE('SQLOLEDB','Data Source=unique;User ID=SA;Password=').uniquegrade.dbo.装箱单明细表 XM ON X.订单id = XM.订单id 
                                                        WHERE X.出口状态=1 and XM.手册编号='{0}'",ManualCode), null);
                    dtData = dataAccess.GetTable(string.Format("制造通知单在线量产品明细查询 '{0}','{1}','{2}'",ManualCode,mstrCode,mstrOrderCode),null);
                    dataAccess.Close();
                    this.myDataGridView1.DataSource = dtData;
                    this.lab_Count.Text =string.Format("记录总数：{0}", dtData.Rows.Count);
                    break;
                case ReportsEnum.ReportsEnum_rpt分组发货单:
                    break;
                case ReportsEnum.ReportsEnum_rpt料件总单:
                    break;
                case ReportsEnum.ReportsEnum_rpt料件进销存:
                    this.Text = "料件进销存";
                    if (passvalue == 1)
                    {
                        strSQL = string.Format("进口料件归并前明细进销存 {0}", gstrWhere);
                    }
                    else if (passvalue == 2)
                    {
                        strSQL = string.Format("进口料件归并前进销存 {0}", gstrWhere);
                    }
                    else if (passvalue == 3)
                    {
                        strSQL = string.Format("进口料件归并后进销存 {0}", gstrWhere);
                    }
                    else
                    {
                        strSQL = string.Format("进口料件进销存明细查询 {0}", gstrWhere);
                    }
                    dataAccess.Open();
                    dtData = dataAccess.GetTable(strSQL,null);
                    dataAccess.Close();
                    this.myDataGridView1.DataSource = dtData;
                    DataTableTools.AddEmptyRow(dtData);
                    this.lab_Count.Text =string.Format("记录总数：{0}", dtData.Rows.Count);
                    this.lab_Date.Text = string.Format("日期从：{0} 到 {1}",mdFromDateString,mdToDateString);
                    break;
                case  ReportsEnum.ReportsEnum_rpt预先订单用量明细表:
                    if(passvalue ==1 )
                    {
                        dtData = dataAccess.GetTable(string.Format("预先订单归并前明细订单用量明细表查询 {0}",gstrWhere),null);
                    }
                    tool_Details.Visible = false;
                    break;
                case ReportsEnum.ReportsEnum_rpt预先订单用量需求表:
                    this.Text = "预先订单用量需求表";
                    if (passvalue == 1)
                    {
                        strSQL = string.Format("预先订单归并前明细用量需求表查询 {0}", gstrWhere);
                    }
                    else if (passvalue == 2)
                    {
                        strSQL = string.Format("预先订单归并前用量需求表查询 {0}", gstrWhere);
                        tool_Details.Visible = false;
                    }
                    else if (passvalue == 3)
                    {
                        strSQL = string.Format("预先订单归并后用量需求表查询 {0}", gstrWhere);
                        tool_Details.Visible = false;
                    }
                    dataAccess.Open();
                    dtData = dataAccess.GetTable(strSQL,null);
                    dataAccess.Close();
                    this.myDataGridView1.DataSource = dtData;
                    this.lab_Count.Text =string.Format("记录总数：{0}", dtData.Rows.Count);
                    break;
                case ReportsEnum.ReportsEnum_rpt料件在线量查询:
//                    this.Text = "料件库存表";
//                    DataTable drs = null;
//                    DataTable crs = null;
//                    if (passvalue == 1)
//                    {
//                        dataAccess.Open();
//                        dataAccess.ExecuteNonQuery("delete from 装箱单明细临时表", null);
//                        dataAccess.ExecuteNonQuery(string.Format(@"Insert into 装箱单明细临时表(手册编号,数量,归并前成品序号,日期,成品项号,订单号码) 
//                                                        SELECT  XM.手册编号,XM.数量, XM.归并前成品序号,X.录入日期,XM.成品项号,XM.订单号码 
//                                                        FROM OPENDATASOURCE('SQLOLEDB','Data Source=unique;User ID=SA;Password=').uniquegrade.dbo.装箱单表 X 
//                                                        LEFT OUTER JOIN OPENDATASOURCE('SQLOLEDB','Data Source=unique;User ID=SA;Password=').uniquegrade.dbo.装箱单明细表 XM ON X.订单id = XM.订单id 
//                                                        WHERE X.出口状态=1 and X.出货日期<='{0}' and XM.手册编号='{1}'",mdEndDateTime,ManualCode),null);
//                        dataAccess.Close();
//                    }
                    break;
            }
        }

        public virtual void InitGrid()
        {
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridView1.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMenuStripCell1;
            }
        }

        public virtual void tool_Details_Click(object sender, EventArgs e)
        {
            switch (mQueryWay)
            {
                case ReportsEnum.ReportsEnum_rpt料件进销存:
                    if (passvalue == 1)
                    {
                        if (this.myDataGridView1.CurrentRow.Cells["料号"].Value == DBNull.Value) return;
                        FormBaseQueryListSingle objForm = new FormBaseQueryListSingle();
                        objForm.mQueryWay = ReportsEnum.ReportsEnum_rpt料件进销存;
                        objForm.mdFromDate = mdFromDate;
                        objForm.mdToDate = mdToDate;
                        objForm.mdFromDateString = mdFromDateString;
                        objForm.mdToDateString = mdToDateString;
                        objForm.ManualCode = ManualCode;
                        objForm.gstrWhere = string.Format("@料号= '{0}',@期初时间='{1}',@期末时间= '{2}',@电子帐册号='{3}'",
                            this.myDataGridView1.CurrentRow.Cells["料号"].Value == DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["料号"].Value, mdFromDateString, mdToDateString, ManualCode);
                        objForm.passvalue = 4;
                        objForm.Show();
                    }
                    else if (passvalue == 2)
                    {
                        if (this.myDataGridView1.CurrentRow.Cells["料号"].Value == DBNull.Value) return;
                        FormBaseQueryListSingle objForm = new FormBaseQueryListSingle();
                        objForm.mQueryWay = ReportsEnum.ReportsEnum_rpt料件进销存;
                        objForm.mdFromDate = mdFromDate;
                        objForm.mdToDate = mdToDate;
                        objForm.mdFromDateString = mdFromDateString;
                        objForm.mdToDateString = mdToDateString;
                        objForm.ManualCode = ManualCode;
                        objForm.gstrWhere = string.Format("@料号= '{0}',@期初时间='{1}',@期末时间= '{2}',@电子帐册号='{3}'",
                            this.myDataGridView1.CurrentRow.Cells["料号"].Value == DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["料号"].Value, mdFromDateString, mdToDateString, ManualCode);
                        objForm.passvalue = 1;
                        objForm.Show();
                    }
                    else if (passvalue == 3)
                    {
                        if (this.myDataGridView1.CurrentRow.Cells["料号"].Value == DBNull.Value) return;
                        FormBaseQueryListSingle objForm = new FormBaseQueryListSingle();
                        objForm.mQueryWay = ReportsEnum.ReportsEnum_rpt料件进销存;
                        objForm.mdFromDate = mdFromDate;
                        objForm.mdToDate = mdToDate;
                        objForm.mdFromDateString = mdFromDateString;
                        objForm.mdToDateString = mdToDateString;
                        objForm.ManualCode = ManualCode;
                        objForm.gstrWhere = string.Format("@料号= '{0}',@期初时间='{1}',@期末时间= '{2}',@电子帐册号='{3}'",
                            this.myDataGridView1.CurrentRow.Cells["料号"].Value == DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["料号"].Value, mdFromDateString, mdToDateString, ManualCode);
                        objForm.passvalue = 2;
                        objForm.Show();
                    }
                    break;
            }
        }

        public virtual void tool_ExportExcel_Click(object sender, EventArgs e)
        {
            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridView1.DataSource, " ");
        }
    }
    /// <summary>
    /// 进销存窗体查询报表枚举类型
    /// </summary>
    public enum ReportsEnum
    {
        ReportsEnum_rpt制作通知单,
        ReportsEnum_rpt分组发货单,
        ReportsEnum_rpt料件总单,
        ReportsEnum_rpt料件进销存,
        ReportsEnum_rpt库存表,
        ReportsEnum_rpt报关库存表,
        ReportsEnum_rpt剩余量,
        ReportsEnum_rpt制造通知单在线量,
        ReportsEnum_rpt制造通知单在线量产品明细查询,
        ReportsEnum_rpt料件在线量查询,
        ReportsEnum_rpt制造通知单订单用量,
        ReportsEnum_rpt预先订单用量需求表,
        ReportsEnum_rpt预先订单用量明细表
    }
}
