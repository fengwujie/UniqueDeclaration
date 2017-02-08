using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration.Base
{
    public partial class FormFitBOM : UniqueDeclarationBaseForm.FormBase
    {
        public FormFitBOM()
        {
            InitializeComponent();
        }
        #region 自定义变量
        public int mnFId = 0;
        public bool mbShow = false;
        public string mstrName =string.Empty;
        public string mstrGroup= string.Empty;
        #endregion

        #region 窗体事件
        private void FormFitBOM_Load(object sender, EventArgs e)
        {

        }

        private void FormFitBOM_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion
    }
}
