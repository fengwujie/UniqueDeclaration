using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;
using DataAccess;

namespace UniqueDeclaration.Base
{
    public partial class FormProductQueryList : UniqueDeclaration.Base.FormBaseDataQueryList
    {
        public FormProductQueryList()
        {
            InitializeComponent();
        }

        public override void FormBaseDataQueryList_Load(object sender, EventArgs e)
        {
            base.tool1_ExportExcel.Visible = false;
            base.tool1_Print.Visible = false;
            this.gstrSQL = "SELECT * FROM 配件资料表 {0} ORDER BY 配件型号";
            this.gstrDetailFirstField = "编号";
            base.FormBaseDataQueryList_Load(sender, e);
        }

        public override void initGrid()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["配件id"].Visible = false;
            this.myDataGridViewHead.Columns["明细备注"].Visible = false;
            this.myDataGridViewHead.Columns["工时分"].Visible = false;
            this.myDataGridViewHead.Columns["工时秒"].Visible = false;

            this.myDataGridViewHead.Columns["编号"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["电子帐册编号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["配件型号"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["配件型号"].HeaderText = "型号";
            this.myDataGridViewHead.Columns["配件名"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["配件组别"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["配件组别"].HeaderText = "组别";
            this.myDataGridViewHead.Columns["实际总重"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["配件存放位置"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["配件存放位置"].HeaderText = "存放位置";
            this.myDataGridViewHead.Columns["配件备注"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["配件备注"].HeaderText = "备注";
            this.myDataGridViewHead.Columns["配件建档日期"].DisplayIndex = 8;
            this.myDataGridViewHead.Columns["配件建档日期"].HeaderText = "建档时间";
            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dataGridViewCellStyle1.Format = "F1";
            //dataGridViewCellStyle1.NullValue = null;
            //this.myDataGridViewHead.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;
            //this.myDataGridViewHead.Columns["换算因子"].DefaultCellStyle = dataGridViewCellStyle1;
            foreach (DataGridViewColumn textBoxColumn in this.myDataGridViewHead.Columns)
            {
                if (textBoxColumn.Name != "计算库存")
                {
                    textBoxColumn.ContextMenuStrip = this.myContextMenu;
                }
            }
        }

        #region tool1事件
        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            //base.tool1_Add_Click(sender, e);
            FormProductInput objForm = new FormProductInput();
            objForm.MdiParent = this.MdiParent;
            objForm.giOrderID = 0;
            objForm.Show();
        }
        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            //base.tool1_Modify_Click(sender, e);
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["配件id"].Value);
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormFitInput")
                {
                    FormProductInput inputForm = (FormProductInput)childFrm;
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
                FormProductInput objForm = new FormProductInput();
                objForm.MdiParent = this.MdiParent;
                objForm.giOrderID = iOrderID;
                objForm.Show();
            }
        }
        public override void tool1_Delete_Click(object sender, EventArgs e)
        {
            //base.tool1_Delete_Click(sender, e);
            try
            {
                if (this.myDataGridViewHead.CurrentRow == null) return;
                if (SysMessage.YesNoMsg("真的要删除吗？") == System.Windows.Forms.DialogResult.No) return;
                string strSQL = string.Format("删除指定的配件资料 {0}", this.myDataGridViewHead.CurrentRow.Cells["配件id"].Value);
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
                string strSuccess = string.Format("{0} 成功！", tool1_Delete.Text);
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
            //base.tool1_Query_Click(sender, e);
            FormProductQueryCondition queryConditionForm = new FormProductQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrWhere = queryConditionForm.strReturnWhere;
                LoadDataSource();
            }
        }
        public override void tool1_BOM_Click(object sender, EventArgs e)
        {
            base.tool1_BOM_Click(sender, e);
            if (this.myDataGridViewHead.RowCount == 0) return;
            #region 判断是否已经有打开的BOM窗体
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormFitBOM")
                {
                    FormProductBOM orderBomForm = (FormProductBOM)childFrm;
                    if (orderBomForm.mnFId == Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["配件id"].Value))
                    {
                        childFrm.Activate();
                        return;
                    }
                }
            }
            #endregion

            FormProductBOM formBOM = new FormProductBOM();
            formBOM.mbShow = false;
            formBOM.mnFId =Convert.ToInt32( this.myDataGridViewHead.CurrentRow.Cells["配件id"].Value);
            formBOM.mstrName = this.myDataGridViewHead.CurrentRow.Cells["配件型号"].Value.ToString();
            formBOM.mstrGroup = this.myDataGridViewHead.CurrentRow.Cells["配件组别"].Value.ToString();
            formBOM.MdiParent = this.MdiParent;
            formBOM.Show();
        }

        public override void tool1_Print_Click(object sender, EventArgs e)
        {
            base.tool1_Print_Click(sender, e);
        }

        public override void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            base.tool1_ExportExcel_Click(sender, e);
        }
        #endregion
    }
}
