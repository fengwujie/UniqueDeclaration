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

        public bool abOK = false;

        public override void FormBaseDataQueryList_Load(object sender, EventArgs e)
        {
            base.tool1_ExportExcel.Visible = false;
            base.tool1_Print.Visible = false;
            if (!abOK)
            {
                this.gstrSQL ="SELECT * FROM 产品资料表 {0} ORDER BY 产品型号";
            }
            else
            {
                this.gstrSQL = @"SELECT *,A.产品A FROM 产品资料表 left outer join (SELECT DISTINCT 产品组成表.产品ID AS 产品A 
                     FROM 产品组成表 where 产品组成表.备注 LIKE '组合好转' or  产品组成表.备注 LIKE '组合转' 
                     GROUP BY 产品组成表.产品id) A on A.产品A = 产品资料表.产品id {0} ORDER BY 产品型号";
            }
            this.gstrDetailFirstField = "编号";
            base.FormBaseDataQueryList_Load(sender, e);
        }

        public override void initGrid()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["产品id"].Visible = false;
            this.myDataGridViewHead.Columns["除数"].Visible = false;
            this.myDataGridViewHead.Columns["明细备注"].Visible = false;
            this.myDataGridViewHead.Columns["工时分"].Visible = false;
            this.myDataGridViewHead.Columns["工时秒"].Visible = false;
            if (abOK)
            {
                this.myDataGridViewHead.Columns["产品A"].Visible = false;
                this.myDataGridViewHead.Columns["产品A1"].Visible = false;
            }

            this.myDataGridViewHead.Columns["编号"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["电子帐册编号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["产品型号"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["产品型号"].HeaderText = "型号";
            this.myDataGridViewHead.Columns["产品名"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["产品单位"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["产品单位"].HeaderText = "单位";
            this.myDataGridViewHead.Columns["产品颜色"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["产品颜色"].HeaderText = "颜色";
            this.myDataGridViewHead.Columns["产品类别"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["产品类别"].HeaderText = "类别";
            this.myDataGridViewHead.Columns["实际总重"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["内部版本号"].DisplayIndex = 8;
            this.myDataGridViewHead.Columns["企业版本号"].DisplayIndex = 9;
            this.myDataGridViewHead.Columns["产品备注"].DisplayIndex = 10;
            this.myDataGridViewHead.Columns["产品备注"].HeaderText = "备注";
            this.myDataGridViewHead.Columns["产品建档日期"].DisplayIndex = 11;
            this.myDataGridViewHead.Columns["产品建档日期"].HeaderText = "建档时间";
            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dataGridViewCellStyle1.Format = "F1";
            //dataGridViewCellStyle1.NullValue = null;
            //this.myDataGridViewHead.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;
            //this.myDataGridViewHead.Columns["换算因子"].DefaultCellStyle = dataGridViewCellStyle1;
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
            int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["产品id"].Value);
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormProductInput")
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
                string strSQL = string.Format("删除指定的产品资料 {0}", this.myDataGridViewHead.CurrentRow.Cells["产品id"].Value);
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
                abOK = queryConditionForm.abOK;
                LoadDataSource();
            }
        }
        public override void tool1_BOM_Click(object sender, EventArgs e)
        {
            base.tool1_BOM_Click(sender, e);
            if (this.myDataGridViewHead.RowCount == 0) return;
            if (this.myDataGridViewHead.CurrentRow.Cells["产品id"].Value == DBNull.Value) return;
            #region 判断是否已经有打开的BOM窗体
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormProductBOM")
                {
                    FormProductBOM orderBomForm = (FormProductBOM)childFrm;
                    if (orderBomForm.mnPId == Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["产品id"].Value))
                    {
                        childFrm.Activate();
                        return;
                    }
                }
            }
            #endregion

            FormProductBOM formBOM = new FormProductBOM();
            formBOM.mbShow = false;
            formBOM.mnPId =Convert.ToInt32( this.myDataGridViewHead.CurrentRow.Cells["产品id"].Value);
            formBOM.mstrName = this.myDataGridViewHead.CurrentRow.Cells["产品型号"].Value.ToString();
            formBOM.mstrColor = this.myDataGridViewHead.CurrentRow.Cells["产品颜色"].Value.ToString();
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
