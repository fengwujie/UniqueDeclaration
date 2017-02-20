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
    public partial class FormCheckOutQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormCheckOutQueryList()
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

        private void FormCheckOutQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_Number.Visible = false;
            this.tool1_BOM.Visible = false;
            this.tool1_Print.Visible = true;
            this.tool1_PrintView.Visible = true;
            this.tool1_ExportExcel.Visible = false;

            LoadDataSourceHead();
            InitGridHead();
            InitGridDetails();
        }

        private void InitGridHead()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["手册id"].Visible = false;
            this.myDataGridViewHead.Columns["报关产品表id"].Visible = false;

            this.myDataGridViewHead.Columns["报关订单号"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["手册编号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["客人型号"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["优丽型号"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["成品项号"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["成品项号"].Width = 80;
            this.myDataGridViewHead.Columns["成品名称及商编"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["成品名称及商编"].Width = 400;
            this.myDataGridViewHead.Columns["成品规格型号"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["成品规格型号"].Width = 120;
            this.myDataGridViewHead.Columns["产品表申报单位"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["产品表申报单位"].HeaderText = "申报单位";
            this.myDataGridViewHead.Columns["产品表法定单位"].DisplayIndex = 8;
            this.myDataGridViewHead.Columns["产品表法定单位"].HeaderText = "法定单位";
            this.myDataGridViewHead.Columns["变更规格型号"].DisplayIndex = 9;
            this.myDataGridViewHead.Columns["变更规格型号"].Width = 120;
            this.myDataGridViewHead.Columns["归并前成品序号"].DisplayIndex = 10;
            this.myDataGridViewHead.Columns["归并前成品序号"].Width = 120;
            this.myDataGridViewHead.Columns["录入日期"].DisplayIndex = 11;

            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewHead.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMenuHead;
            }
        }

        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["报关产品组成明细表id"].Visible = false;
            this.myDataGridViewDetails.Columns["料件id"].Visible = false;
            this.myDataGridViewDetails.Columns["报关产品表id"].Visible = false;

            this.myDataGridViewDetails.Columns["料件项号"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["料件项号"].Width = 80;
            this.myDataGridViewDetails.Columns["料件名称及商编"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["料件名称及商编"].Width = 150;
            this.myDataGridViewDetails.Columns["料件规格型号"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["料件规格型号"].Width = 200;
            this.myDataGridViewDetails.Columns["明细表申报单位"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["明细表申报单位"].HeaderText = "申报单位";
            this.myDataGridViewDetails.Columns["明细表申报单位"].Width = 80;
            this.myDataGridViewDetails.Columns["明细表法定单位"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["明细表法定单位"].HeaderText = "法定单位";
            this.myDataGridViewDetails.Columns["明细表法定单位"].Width = 80;
            this.myDataGridViewDetails.Columns["备案净耗单位"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["备案净耗单位"].Width = 120;
            this.myDataGridViewDetails.Columns["备案损耗"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["备案损耗"].Width = 80;
            this.myDataGridViewDetails.Columns["变更净耗单位"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["变更净耗单位"].Width = 120;
            this.myDataGridViewDetails.Columns["变更损耗"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["变更损耗"].Width = 80;
            this.myDataGridViewDetails.Columns["归并前料件序号"].DisplayIndex = 9;
            this.myDataGridViewDetails.Columns["归并前料件序号"].Width = 120;
            this.myDataGridViewDetails.Columns["归并前净耗单位"].DisplayIndex = 10;
            this.myDataGridViewDetails.Columns["归并前净耗单位"].Width = 120;
            this.myDataGridViewDetails.Columns["归并前损耗"].DisplayIndex = 11;
            this.myDataGridViewDetails.Columns["归并前损耗"].Width = 100;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dataGridViewCellStyle1.Format = "F3";
            //dataGridViewCellStyle1.NullValue = null;
            //this.myDataGridViewDetails.Columns["数量"].DefaultCellStyle = dataGridViewCellStyle1;
            //this.myDataGridViewDetails.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;
            //this.myDataGridViewDetails.Columns["总价"].DefaultCellStyle = dataGridViewCellStyle1;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewDetails.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMenuDetails;
            }
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
                string strSQL = string.Format("select 手册资料表.手册编号, 报关产品表.* FROM 报关产品表 left join 手册资料表 on  报关产品表.手册id=手册资料表.手册id {0} {1} order by 手册资料表.手册编号,报关产品表.录入日期", gstrWhere.Length > 0 ? " where " : "", gstrWhere);
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
                SysMessage.ErrorMsg(string.Format("加载数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        /// <summary>
        /// 加载订单内容数据
        /// </summary>
        private void LoadDataSourceDetails()
        {
            try
            {
                int 报关产品表id = 0;
                if (this.myDataGridViewHead.CurrentRowNew != null)
                {
                    报关产品表id = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["报关产品表id"].Value;
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = string.Format("SELECT * from 报关产品组成明细表 where 报关产品表id={0} ORDER BY 料件项号", 报关产品表id);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtDetails);
                this.myDataGridViewDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        #endregion

        #region tools事件
        public override void tool1_First_Click(object sender, EventArgs e)
        {
            base.tool1_First_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells["手册编号"];
            setTool1Enabled();
        }

        public override void tool1_up_Click(object sender, EventArgs e)
        {
            base.tool1_up_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells["手册编号"];
            setTool1Enabled();

        }

        public override void tool1_Down_Click(object sender, EventArgs e)
        {
            base.tool1_Down_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells["手册编号"];
            setTool1Enabled();
        }

        public override void tool1_End_Click(object sender, EventArgs e)
        {
            base.tool1_End_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells["手册编号"];
            setTool1Enabled();
        }

        public override void tool1_Query_Click(object sender, EventArgs e)
        {
            base.tool1_Query_Click(sender, e);
            FormCheckOutQueryCondition queryConditionForm = new FormCheckOutQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrWhere = queryConditionForm.strReturnWhere;
                LoadDataSourceHead();
            }
        }

        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            //base.tool1_Add_Click(sender, e);
            FormCheckOutInput objForm = new FormCheckOutInput();
            objForm.MdiParent = this.MdiParent;
            objForm.giOrderID = 0;
            objForm.Show();
        }

        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["手册id"].Value);
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormCheckOutInput")
                {
                    FormCheckOutInput inputForm = (FormCheckOutInput)childFrm;
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
                FormCheckOutInput objForm = new FormCheckOutInput();
                objForm.MdiParent = this.MdiParent;
                objForm.giOrderID = iOrderID;
                objForm.Show();
            }
        }

        public override void tool1_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.myDataGridViewHead.CurrentRow == null) return;
                int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["手册id"].Value);
                if (SysMessage.OKCancelMsg(string.Format("真的要删除 报关产品表id {0} 吗？", this.myDataGridViewHead.CurrentRow.Cells["报关产品表id"].Value)) == System.Windows.Forms.DialogResult.Cancel) return;

                IDataAccess data = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                data.Open();
                string strSQL = string.Format(@"delete from 报关产品表 where 报关产品表.报关产品表id={0}
                                                delete from 报关产品组成明细表 where 报关产品组成明细表.报关产品表id={0}",
                                                                                                  this.myDataGridViewHead.CurrentRow.Cells["报关产品表id"].Value);
                data.ExecuteNonQuery(strSQL,null);     
                data.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["报关产品表id"].Value);
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

        public override void tool1_BOM_Click(object sender, EventArgs e)
        {
            //base.tool1_BOM_Click(sender, e);
            #region 判断手册编号是否存在
            if (this.myDataGridViewDetails.RowCount == 0) return;
            #endregion

            #region 判断是否已经有打开的BOM窗体
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormManualBOM")
                {
                    FormManualBOM orderBomForm = (FormManualBOM)childFrm;
                    if (orderBomForm.mIntID == Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["手册id"].Value)
                        && orderBomForm.mnPId == Convert.ToInt32(this.myDataGridViewDetails.CurrentRow.Cells["出口成品id"].Value))
                    {
                        childFrm.Activate();
                        return;
                    }
                }
            }
            #endregion

            #region 打开BOM窗体
            FormManualBOM formBOM = new FormManualBOM();
            formBOM.mIntID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["手册id"].Value);
            formBOM.mstrNo = this.myDataGridViewHead.CurrentRow.Cells["手册id"].Value.ToString();
            formBOM.mnPId = Convert.ToInt32(this.myDataGridViewDetails.CurrentRow.Cells["出口成品id"].Value);
            formBOM.mstrName = this.myDataGridViewDetails.CurrentRow.Cells["品名规格型号"].Value.ToString();
            formBOM.MdiParent = this.MdiParent;
            formBOM.Show();
            #endregion
        }

        public override void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            base.tool1_ExportExcel_Click(sender, e);

            if (this.myDataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;
            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridViewDetails.DataSource, string.Empty);

        }

        public override void tool1_PrintView_Click(object sender, EventArgs e)
        {
            base.tool1_PrintView_Click(sender, e);
            if (this.myDataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;
            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridViewDetails.DataSource, string.Empty);
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
    }
}
