using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclarationBaseForm
{
    public partial class FormBaseBOM : UniqueDeclarationBaseForm.FormBase
    {
        public FormBaseBOM()
        {
            InitializeComponent();
        }

        public TabPage oldTabPage = null;

        public virtual void dgv_ModifyAfterHead_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public virtual void dgv_ModifyAfterHead_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        public virtual void dgv_ModifyBefore_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public virtual void dgv_ModifyBefore_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        public virtual void dgv_MergerAfterHead_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public virtual void dgv_MergerAfterHead_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        public virtual void tool_Save_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool_Import_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool_Close_Click(object sender, EventArgs e)
        {

        }

        public virtual void myTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            oldTabPage = this.myTabControl1.SelectedTab;
        }

        public virtual void dgv_ModifyAfterDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        public virtual void dgv_ModifyAfterDetail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public virtual void dgv_ModifyAfterHead_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        public virtual void dgv_ModifyAfterDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        public virtual void dgv_ModifyAfterHead_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        public virtual void btnModifyHeadDelete_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnModifyDetailDelete_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool_ExportExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
