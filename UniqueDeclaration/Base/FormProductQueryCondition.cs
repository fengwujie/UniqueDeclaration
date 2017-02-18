using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration.Base
{
    public partial class FormProductQueryCondition : UniqueDeclarationBaseForm.FormBaseQueryCondition
    {
        public FormProductQueryCondition()
        {
            InitializeComponent();
        }

        private void FormFitQueryCondition_Load(object sender, EventArgs e)
        {
            datetime_配件建档日期1.Value = Convert.ToDateTime(string.Format("{0} 00:00:01", DateTime.Now.ToShortDateString()));
            datetime_配件建档日期2.Value = Convert.ToDateTime(string.Format("{0} 23:59:59", DateTime.Now.ToShortDateString()));
            datetime_配件建档日期1.Checked = false;
            datetime_配件建档日期2.Checked = false;
        }
    }
}
