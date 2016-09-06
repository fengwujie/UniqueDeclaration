using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace UniqueDeclaration
{
    public partial class FormFinishedProductOutQueryCondition : UniqueDeclarationBaseForm.FormBaseQueryCondition
    {
        public FormFinishedProductOutQueryCondition()
        {
            InitializeComponent();
        }

        private void FormFinishedProductOutQueryCondition_Load(object sender, EventArgs e)
        {
            this.txt_手册编号.Text = ConfigurationManager.AppSettings["defaultManualCode"].ToString();
        }
    }
}
