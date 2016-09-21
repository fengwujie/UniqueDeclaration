using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration
{
    public partial class FormMaterialsInQueryCondition : UniqueDeclarationBaseForm.FormBaseQueryCondition
    {
        public FormMaterialsInQueryCondition()
        {
            InitializeComponent();
        }

        private void FormMaterialsInQueryCondition_Load(object sender, EventArgs e)
        {
            this.cbox_电子帐册号.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade, "SELECT 手册编号 FROM 手册资料表 ORDER BY 有效期限 DESC", "手册编号", "手册编号");
        }

    }
}
