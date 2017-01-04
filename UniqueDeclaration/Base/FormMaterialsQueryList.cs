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
            this.gstrSQL ="SELECT * FROM 料件资料表 {0} ORDER BY 料件型号";
            this.gstrDetailFirstField = "报关类别";
            base.FormBaseDataQueryList_Load(sender, e);
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
                UniqueDeclaration.Base.FormMaterialsQueryList queryListForm = new UniqueDeclaration.Base.FormMaterialsQueryList();
                queryListForm.gstrWhere = queryConditionForm.strReturnWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
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
