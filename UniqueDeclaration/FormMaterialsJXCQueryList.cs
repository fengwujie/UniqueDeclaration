using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration
{
    public partial class FormMaterialsJXCQueryList : UniqueDeclarationBaseForm.FormBase
    {
        public FormMaterialsJXCQueryList()
        {
            InitializeComponent();
        }

        /*
         frm.mQueryWay = rpt料件进销存
         */
        public string gstrWhere = string.Empty;
        public string mdFromDate = string.Empty;
        public string mdToDate = string.Empty;
        public string mdFromDateString = string.Empty;
        public string mdToDateString = string.Empty;
        public string ManualCode = string.Empty;
        public int passvalue;
    }
}
