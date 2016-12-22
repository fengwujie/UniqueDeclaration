using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration.Base
{
    public partial class FormMergeRelationMaterialsInput : UniqueDeclarationBaseForm.FormBase
    {
        public FormMergeRelationMaterialsInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询窗体的传进来的手册编号
        /// </summary>
        public string gstrManualNo = string.Empty;
        private void FormMergeRelationMaterialsInput_Load(object sender, EventArgs e)
        {

        }
    }
}
