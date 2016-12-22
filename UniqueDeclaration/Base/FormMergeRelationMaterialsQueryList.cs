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
    public partial class FormMergeRelationMaterialsQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormMergeRelationMaterialsQueryList()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 是否触发行变化事件
        /// </summary>
        private bool bTriggerGridViewHead_SelectionChanged = true;
        /// <summary>
        /// 查询窗体的传进来的手册编号
        /// </summary>
        public string gstrManualNo = string.Empty;

        private void FormMergeRelationMaterialsQueryList_Load(object sender, EventArgs e)
        {
            base.tool1_Number.Visible = false;
            base.tool1_Import.Visible = false;
            base.tool1_Print.Visible = true;
            LoadDataSourceHead();

            //InitGridHead();
            //InitGridDetails();
            //InitGridDetails2();
        }

        #region 加载数据
        /// <summary>
        /// 加载表头数据
        /// </summary>
        private void LoadDataSourceHead()
        {
            try
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL =string.Format( "select * FROM 归并后料件清单 where 电子帐册号={0} ORDER BY 序号",StringTools.SqlQ( gstrManualNo));
                DataTable dtHead = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                bTriggerGridViewHead_SelectionChanged = false;
                DataTableTools.AddEmptyRow(dtHead);
                this.myDataGridViewHead.DataSource = dtHead;
                bTriggerGridViewHead_SelectionChanged = true;
                //if (this.dataGridViewHead.RowCount > 0)
                //{
                //    this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[0].Cells["电子帐册号"];
                //    this.dataGridViewHead.Rows[0].Selected = true;
                //}
                this.myDataGridViewHead_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载数据出错LoadDataSourceHead，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        /// <summary>
        /// 加载订单内容数据
        /// </summary>
        private void LoadDataSourceDetails()
        {
            //bool bShow = false;
            //if (formBaseLoading == null)
            //{
            //    formBaseLoading = new FormBaseLoading();
            //    bShow = true;
            //    formBaseLoading.strLoadText =string.Format("加载【{0}】数据，请稍等。。。。。。", this.tabPage1.Text);
            //    formBaseLoading.Show();
            //    formBaseLoading.Refresh();
            //}
            try
            {
                int iOrderID = 0;
                if (this.myDataGridViewHead.CurrentRowNew != null && this.myDataGridViewHead.CurrentRowNew.Index >= 0)
                {
                    if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["归并后料件id"].Value != DBNull.Value)
                        iOrderID = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["归并后料件id"].Value;
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("exec 商品归并表录入查询 {0}", iOrderID);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();

                DataTableTools.AddEmptyRow(dtDetails);
                this.myDataGridViewDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载数据出错LoadDataSourceDetails，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
            //finally
            //{
            //    if (bShow && formBaseLoading != null)
            //    {
            //        formBaseLoading.Close();
            //        formBaseLoading.Dispose();
            //        formBaseLoading = null;
            //    }
            //}
        }
        /// <summary>
        /// 加载归并前材料明细用量表
        /// </summary>
        private void LoadDataSourceDetails2()
        {
            //bool bShow = false;
            //if (formBaseLoading == null)
            //{
            //    formBaseLoading = new FormBaseLoading();
            //    bShow = true;
            //    formBaseLoading.strLoadText = string.Format("加载【{0}】数据，请稍等。。。。。。", this.tabPage4.Text);
            //    formBaseLoading.Show();
            //    formBaseLoading.Refresh();
            //}
            try
            {
                string 序号id = string.Empty;
                string 项号id = string.Empty;
                string 电子帐册号 = string.Empty;

                if (this.myDataGridViewHead.CurrentRowNew != null && this.myDataGridViewHead.CurrentRowNew.Index >= 0)
                {
                    if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["归并后料件id"].Value != DBNull.Value)
                    {
                        序号id = this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["序号"].Value.ToString().Trim();
                        if (序号id.Length == 1) 
                            序号id = string.Format("0{0}",序号id);
                        电子帐册号 = this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["电子帐册号"].Value.ToString().Trim();
                    }
                }
                if (this.myDataGridViewDetails.CurrentRowNew != null && this.myDataGridViewDetails.CurrentRowNew.Index >= 0)
                {
                    if (this.myDataGridViewDetails.Rows[this.myDataGridViewDetails.CurrentRowNew.Index].Cells["归并前料件id"].Value != DBNull.Value)
                    {
                        项号id = this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["序号"].Value.ToString().Trim();
                        if (项号id.Length == 1)
                            项号id = string.Format("0{0}", 项号id);
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("exec 归并前料件清单明细查询 '{0}','{1}','{2}'", 序号id, 项号id,电子帐册号);
                DataTable dtDetails2 = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();

                DataTableTools.AddEmptyRow(dtDetails2);
                this.myDataGridViewDetails2.DataSource = dtDetails2;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载数据出错LoadDataSourceDetails2，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
            //finally
            //{
            //    if (bShow && formBaseLoading != null)
            //    {
            //        formBaseLoading.Close();
            //        formBaseLoading.Dispose();
            //        formBaseLoading = null;
            //    }
            //}
        }
        #endregion
        
        #region 初始化GRID
        private void InitGridHead()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["订单id"].Visible = false;

            this.myDataGridViewHead.Columns["订单号码"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["手册编号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["客户代码"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["客户代码"].Width = 78;
            this.myDataGridViewHead.Columns["客户名称"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["出货日期"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["出货日期"].Width = 78;
            this.myDataGridViewHead.Columns["录入日期"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["录入日期"].Width = 78;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewHead.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextHead;
            }
        }
        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["BM"].Visible = false;
            this.myDataGridViewDetails.Columns["订单明细表id"].Visible = false;
            //this.myDataGridViewDetails.Columns["订单id"].Visible = false;
            this.myDataGridViewDetails.Columns["制造通知单id"].Visible = false;
            this.myDataGridViewDetails.Columns["产品id"].Visible = false;
            this.myDataGridViewDetails.Columns["配件id"].Visible = false;

            this.myDataGridViewDetails.Columns["制造通知单号"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["制造通知单号"].Width = 100;
            this.myDataGridViewDetails.Columns["客人型号"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["客人型号"].Width = 78;
            this.myDataGridViewDetails.Columns["优丽型号"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["优丽型号"].Width = 78;
            this.myDataGridViewDetails.Columns["颜色"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["颜色"].Width = 55;
            this.myDataGridViewDetails.Columns["订单数量"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["订单数量"].Width = 78;
            this.myDataGridViewDetails.Columns["单位"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["单位"].Width = 55;
            this.myDataGridViewDetails.Columns["箱数"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["箱数"].Width = 55;
            this.myDataGridViewDetails.Columns["型号"].DisplayIndex = 7;
            //this.myDataGridViewDetails.Columns["型号"].Width = 78;
            this.myDataGridViewDetails.Columns["型号"].HeaderText = "生产型号";
            this.myDataGridViewDetails.Columns["生产数量"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["生产数量"].Width = 78;
            this.myDataGridViewDetails.Columns["实际总重"].DisplayIndex = 9;
            this.myDataGridViewDetails.Columns["实际总重"].Width = 78;
            this.myDataGridViewDetails.Columns["总重"].DisplayIndex = 10;
            this.myDataGridViewDetails.Columns["总重"].Width = 55;
            this.myDataGridViewDetails.Columns["版本号"].DisplayIndex = 11;
            this.myDataGridViewDetails.Columns["版本号"].Width = 90;
            this.myDataGridViewDetails.Columns["版本号"].HeaderText = "企业版本号";
            this.myDataGridViewDetails.Columns["内部版本号"].DisplayIndex = 12;
            this.myDataGridViewDetails.Columns["内部版本号"].Width = 90;
            this.myDataGridViewDetails.Columns["成品项号"].DisplayIndex = 13;
            this.myDataGridViewDetails.Columns["成品项号"].Width = 78;
            this.myDataGridViewDetails.Columns["成品名称及商编"].DisplayIndex = 14;
            this.myDataGridViewDetails.Columns["成品名称及商编"].Width = 130;
            this.myDataGridViewDetails.Columns["成品规格型号"].DisplayIndex = 15;
            this.myDataGridViewDetails.Columns["成品规格型号"].Width = 110;
            this.myDataGridViewDetails.Columns["申报单位"].DisplayIndex = 16;
            this.myDataGridViewDetails.Columns["申报单位"].Width = 78;
            this.myDataGridViewDetails.Columns["法定单位"].DisplayIndex = 17;
            this.myDataGridViewDetails.Columns["法定单位"].Width = 78;
            this.myDataGridViewDetails.Columns["变更规格型号"].DisplayIndex = 18;
            this.myDataGridViewDetails.Columns["变更规格型号"].Width = 100;
            this.myDataGridViewDetails.Columns["订单备注"].DisplayIndex = 19;
            this.myDataGridViewDetails.Columns["订单备注"].Width = 78;

            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewDetails.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextDetails;
            }
        }
        private void InitGridDetails2()
        {
            if (this.myDataGridViewDetails2.DataSource != null)
            {
                this.myDataGridViewDetails2.Columns["序号"].DisplayIndex = 0;
                this.myDataGridViewDetails2.Columns["序号"].Width = 55;
                this.myDataGridViewDetails2.Columns["商品编码"].DisplayIndex = 1;
                this.myDataGridViewDetails2.Columns["商品编码"].Width = 78;
                this.myDataGridViewDetails2.Columns["商品名称"].DisplayIndex = 2;
                this.myDataGridViewDetails2.Columns["商品名称"].Width = 78;
                this.myDataGridViewDetails2.Columns["规格型号"].DisplayIndex = 3;
                this.myDataGridViewDetails2.Columns["规格型号"].Width = 150;
                this.myDataGridViewDetails2.Columns["计量单位"].DisplayIndex = 4;
                this.myDataGridViewDetails2.Columns["计量单位"].Width = 78;
                this.myDataGridViewDetails2.Columns["损耗率"].DisplayIndex = 5;
                this.myDataGridViewDetails2.Columns["损耗率"].Width = 70;
                this.myDataGridViewDetails2.Columns["总用量"].DisplayIndex = 6;
                this.myDataGridViewDetails2.Columns["总用量"].Width = 70;
                this.myDataGridViewDetails2.Columns["单耗"].Visible = false;
                foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewDetails2.Columns)
                {
                    textBoxColumn.ContextMenuStrip = this.myContextDetails2;
                }
            }
        }
        #endregion
        
        #region tools事件
        public override void tool1_First_Click(object sender, EventArgs e)
        {
            base.tool1_First_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells["电子帐册号"];
            setTool1Enabled();
        }

        public override void tool1_up_Click(object sender, EventArgs e)
        {
            base.tool1_up_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells["电子帐册号"];
            setTool1Enabled();

        }

        public override void tool1_Down_Click(object sender, EventArgs e)
        {
            base.tool1_Down_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells["电子帐册号"];
            setTool1Enabled();
        }

        public override void tool1_End_Click(object sender, EventArgs e)
        {
            base.tool1_End_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells["电子帐册号"];
            setTool1Enabled();
        }

        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            base.tool1_Add_Click(sender, e);
        }

        public override void tool1_Delete_Click(object sender, EventArgs e)
        {
            base.tool1_Delete_Click(sender, e);
        }

        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            base.tool1_Modify_Click(sender, e);
        }

        public override void tool1_Query_Click(object sender, EventArgs e)
        {
            base.tool1_Query_Click(sender, e);
            FormMergeRelationMaterialsQueryCondition queryConditionForm = new FormMergeRelationMaterialsQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrManualNo = queryConditionForm.cManualNo;
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
            if (bTriggerGridViewHead_SelectionChanged)
            {
                LoadDataSourceDetails();
            }
        }
    }
}
