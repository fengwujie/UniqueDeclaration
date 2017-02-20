using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace UniqueDeclaration.Base
{
    public partial class FormCheckOutQueryCondition : UniqueDeclarationBaseForm.FormBaseQueryCondition
    {
        public FormCheckOutQueryCondition()
        {
            InitializeComponent();
        }

        private void FormCheckOutQueryCondition_Load(object sender, EventArgs e)
        {
            this.txt_手册编号.Text = ConfigurationManager.AppSettings["defaultManualCode"].ToString();
        }
    }
}
