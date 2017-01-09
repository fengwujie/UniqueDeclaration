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
    public partial class FormMaterialsQueryList : UniqueDeclaration.Base.FormBaseDataQueryList
    {
        public FormMaterialsQueryList()
        {
            InitializeComponent();
        }

        public override void FormBaseDataQueryList_Load(object sender, EventArgs e)
        {
            this.gstrSQL = "SELECT 料件资料表.*,料件类别表.料件类别说明 FROM 料件资料表 inner join 料件类别表 on 料件资料表.料件类别=料件类别表.料件类别 {0} ORDER BY 料件型号";
            this.gstrDetailFirstField = "报关类别";
            base.FormBaseDataQueryList_Load(sender, e);           
        }

        public override void initGrid()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["料件id"].Visible = false;
            this.myDataGridViewHead.Columns["显示型号L"].Visible = false;
            this.myDataGridViewHead.Columns["料件类别"].Visible = false;
            this.myDataGridViewHead.Columns["料件项号"].Visible = false;
            this.myDataGridViewHead.Columns["归并序号"].Visible = false;
            this.myDataGridViewHead.Columns["仓位"].Visible = false;
            this.myDataGridViewHead.Columns["料件基本编号"].Visible = false;
            this.myDataGridViewHead.Columns["计算库存"].Visible = false;
            this.myDataGridViewHead.Columns["料件规格"].Visible = false;
            this.myDataGridViewHead.Columns["所属仓库"].Visible = false;

            this.myDataGridViewHead.Columns["报关类别"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["料件型号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["料件型号"].HeaderText = "内部型号";
            this.myDataGridViewHead.Columns["显示型号"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["显示型号"].HeaderText = "型号";
            this.myDataGridViewHead.Columns["电子帐册型号"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["料件名"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["仓库数量1"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["仓库数量1"].HeaderText = "入库数量(大)";
            this.myDataGridViewHead.Columns["仓库单位1"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["仓库单位1"].HeaderText = "入库单位(大)";
            this.myDataGridViewHead.Columns["仓库数量2"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["仓库数量2"].HeaderText = "入库数量(小)";
            this.myDataGridViewHead.Columns["仓库单位2"].DisplayIndex = 8;
            this.myDataGridViewHead.Columns["仓库单位2"].HeaderText = "入库单位(小)";
            this.myDataGridViewHead.Columns["单位数量"].DisplayIndex = 9;
            this.myDataGridViewHead.Columns["料件单位"].DisplayIndex = 10;
            this.myDataGridViewHead.Columns["料件单位"].HeaderText = "企业单位";
            this.myDataGridViewHead.Columns["领料数量1"].DisplayIndex = 11;
            this.myDataGridViewHead.Columns["领料数量1"].HeaderText = "领料数量(大)";
            this.myDataGridViewHead.Columns["领料单位1"].DisplayIndex = 12;
            this.myDataGridViewHead.Columns["领料单位1"].HeaderText = "领料单位(大)";
            this.myDataGridViewHead.Columns["领料数量2"].DisplayIndex = 13;
            this.myDataGridViewHead.Columns["领料数量2"].HeaderText = "领料数量(小)";
            this.myDataGridViewHead.Columns["领料单位2"].DisplayIndex = 14;
            this.myDataGridViewHead.Columns["领料单位2"].HeaderText = "领料单位(小)";
            this.myDataGridViewHead.Columns["换算单位"].DisplayIndex = 15;
            this.myDataGridViewHead.Columns["换算数量"].DisplayIndex = 16;
            this.myDataGridViewHead.Columns["换算数量"].HeaderText = "换算率";
            this.myDataGridViewHead.Columns["保税"].DisplayIndex = 17;
            this.myDataGridViewHead.Columns["安全存量"].DisplayIndex = 18;
            this.myDataGridViewHead.Columns["料件类别说明"].DisplayIndex = 19;
            this.myDataGridViewHead.Columns["料件类别说明"].HeaderText = "料件类别";
            this.myDataGridViewHead.Columns["采购区域"].DisplayIndex = 20;
            this.myDataGridViewHead.Columns["料件存放位置"].DisplayIndex = 21;
            this.myDataGridViewHead.Columns["料件存放位置"].HeaderText = "存放位置";
            this.myDataGridViewHead.Columns["料件备注"].DisplayIndex = 22;
            this.myDataGridViewHead.Columns["料件备注"].HeaderText = "备注";
            this.myDataGridViewHead.Columns["料件建档日期"].DisplayIndex = 23;
            this.myDataGridViewHead.Columns["料件建档日期"].HeaderText = "料件时间";
            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dataGridViewCellStyle1.Format = "F1";
            //dataGridViewCellStyle1.NullValue = null;
            //this.myDataGridViewHead.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;
            //this.myDataGridViewHead.Columns["换算因子"].DefaultCellStyle = dataGridViewCellStyle1;
            foreach (DataGridViewColumn textBoxColumn in this.myDataGridViewHead.Columns)
            {
                if (textBoxColumn.Name!="计算库存")
                {
                    textBoxColumn.ContextMenuStrip = this.myContextMenu;
                }
            }
        }

        #region tool1事件
        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            //base.tool1_Add_Click(sender, e);
            FormMaterialsInput objForm = new FormMaterialsInput();
            objForm.MdiParent = this.MdiParent;
            objForm.giOrderID = 0;
            objForm.Show();
        }
        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            //base.tool1_Modify_Click(sender, e);
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["料件id"].Value);
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormMaterialsInput")
                {
                    FormMaterialsInput inputForm = (FormMaterialsInput)childFrm;
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
                FormMaterialsInput objForm = new FormMaterialsInput();
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
                if (SysMessage.YesNoMsg(string.Format("真的要删除料件型号【{0}】，料件名称【{1}】吗？", this.myDataGridViewHead.CurrentRow.Cells["料件型号"].Value, this.myDataGridViewHead.CurrentRow.Cells["料件名称"].Value)) == System.Windows.Forms.DialogResult.No) return;
                string strSQL = string.Format("delete 料件资料表 where 料件id={0}", this.myDataGridViewHead.CurrentRow.Cells["料件id"].Value);
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
                string strSuccess = string.Format("{0} 料件型号【{0}】，料件名称【{1}】成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["料件型号"].Value, this.myDataGridViewHead.CurrentRow.Cells["料件名称"].Value);
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
            FormMaterialsQueryCondition queryConditionForm = new FormMaterialsQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrWhere = queryConditionForm.strReturnWhere;
                LoadDataSource();
            }
        }
        public override void tool1_BOM_Click(object sender, EventArgs e)
        {
            base.tool1_BOM_Click(sender, e);
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
