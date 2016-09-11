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
    public partial class FormPackingListQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormPackingListQueryList()
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
        private void FormPackingListQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_Import.Visible = false;
            LoadDataSourceHead();
            InitGridDetails();
            InitGridHead();

        }

        #region 初始化GRID
        private void InitGridHead()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["订单id"].Visible = false;
            this.myDataGridViewHead.Columns["订单id"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["出口状态"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["出口状态"].Width = 78;
            this.myDataGridViewHead.Columns["出口状态"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["装箱单号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["装箱单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["订单号码"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["订单号码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["报关单号"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["报关单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["客户代码"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["客户代码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["客户名称"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["客户名称"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["出货日期"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["出货日期"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["录入日期"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["录入日期"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["备案号"].Visible=false;
            this.myDataGridViewHead.Columns["备案号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["用途"].Visible=false;
            this.myDataGridViewHead.Columns["用途"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["征免方式"].Visible=false;
            this.myDataGridViewHead.Columns["征免方式"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["产销国"].Visible=false;
            this.myDataGridViewHead.Columns["产销国"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["币制"].Visible=false;
            this.myDataGridViewHead.Columns["币制"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["申报地海关代码"].Visible=false;
            this.myDataGridViewHead.Columns["申报地海关代码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["进口岸代码"].Visible=false;
            this.myDataGridViewHead.Columns["进口岸代码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["代理单位代码"].Visible=false;
            this.myDataGridViewHead.Columns["代理单位代码"].ContextMenuStrip = this.myContextHead;
        }

        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["BM"].Visible = false;
            this.myDataGridViewDetails.Columns["BM"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["订单明细表id"].Visible = false;
            this.myDataGridViewDetails.Columns["订单明细表id"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["单价"].Visible = false;
            this.myDataGridViewDetails.Columns["单价"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["箱号"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["箱号"].Width = 55;
            this.myDataGridViewDetails.Columns["箱号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["客人型号"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["客人型号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["优丽型号"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["优丽型号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["订单号码"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["订单号码"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["手册编号"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["手册编号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["归并前成品序号"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["归并前成品序号"].Width = 120;
            this.myDataGridViewDetails.Columns["归并前成品序号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["内部版本号"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["内部版本号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["成品项号"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["成品项号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["成品名称及商编"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["成品名称及商编"].Width = 120;
            this.myDataGridViewDetails.Columns["成品名称及商编"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["成品规格型号"].DisplayIndex = 9;
            this.myDataGridViewDetails.Columns["成品规格型号"].Width = 120;
            this.myDataGridViewDetails.Columns["成品规格型号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["数量"].DisplayIndex = 10;
            this.myDataGridViewDetails.Columns["数量"].Width = 55;
            this.myDataGridViewDetails.Columns["数量"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["单位"].DisplayIndex = 11;
            this.myDataGridViewDetails.Columns["单位"].Width = 55;
            this.myDataGridViewDetails.Columns["单位"].ContextMenuStrip = this.myContextDetails;

        }
        #endregion

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
                string strSQL = "SELECT * from 装箱单表 " + (gstrWhere.Length > 0 ? " where " : "") + gstrWhere + " ORDER BY 录入日期 DESC";
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
                SysMessage.ErrorMsg(string.Format("加载【装箱单】数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
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
                    if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRow.Index].Cells["订单id"].Value != DBNull.Value)
                    {
                        iOrderID = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRow.Index].Cells["订单id"].Value;
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = string.Format("exec 装箱单明细表录入查询 {0}", iOrderID);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtDetails);
                this.myDataGridViewDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【装箱单明细】出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
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
                        this.tool1_Down.Enabled = true;
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
    }
}
