using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using System.Configuration;

namespace UniqueDeclarationBaseForm
{
    public partial class FormBaseManualCondition : Form
    {
        public FormBaseManualCondition()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择的手册编号
        /// </summary>
        public string cManualNo = string.Empty;
        private void FormBaseManualCondition_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                string strSQL = "SELECT distinct 电子帐册号 AS 手册编号,电子帐册号 AS 手册编号2 FROM 归并后料件清单";
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                DataTable dt手册编号 = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                cbox_手册编号.InitialData(dt手册编号, "手册编号", "手册编号2", (object)ConfigurationManager.AppSettings["defaultManualCode"]);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cManualNo = cbox_手册编号.SelectedValue.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
