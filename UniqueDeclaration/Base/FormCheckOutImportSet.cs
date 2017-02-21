using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using DataAccess;

namespace UniqueDeclaration.Base
{
    public partial class FormCheckOutImportSet : UniqueDeclarationBaseForm.FormBase
    {
        public FormCheckOutImportSet()
        {
            InitializeComponent();
        }
        public string date1=string.Empty;
        public string date2 =string.Empty;
        public int 手册id = 0;
        public string 手册编号 = string.Empty;
        private void FormCheckOutImportSet_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;  
            date_出货日期1.Value = dt.AddDays(-(dt.Day) + 1);
            date_出货日期2.Value = Convert.ToDateTime(string.Format("{0}-12-1", dt.Year)).AddMonths(1).AddDays(-1);
            IDataAccess dataAccessUniquegrade = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccessUniquegrade.Open();
            int id =Convert.ToInt32( dataAccessUniquegrade.GetTable(string.Format("SELECT 手册id FROM 手册资料表 where 手册编号='{0}'", ConfigurationManager.AppSettings["defaultManualCode"].ToString()), null).Rows[0]["手册id"]);
            dataAccessUniquegrade.Close();
            this.cbox_手册编号.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade,
                "SELECT 手册id,手册编号 FROM 手册资料表 ORDER BY 有效期限 DESC", "手册id", "手册编号", id);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            date1 = date_出货日期1.Value.ToString("yyyy-MM-dd") + " 00:00:01";
            date2 = date_出货日期2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            手册id = Convert.ToInt32(cbox_手册编号.SelectedValue);
            手册编号 = cbox_手册编号.Text;
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
