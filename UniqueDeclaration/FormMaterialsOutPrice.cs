using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration
{
    public partial class FormMaterialsOutPrice : UniqueDeclarationBaseForm.FormBase
    {
        public FormMaterialsOutPrice()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnQuery.Enabled = false;

                DateTime d1 = new DateTime(this.myDateTimePicker1.Value.Year, this.myDateTimePicker1.Value.Month, 1);
                DateTime dT = this.myDateTimePicker1.Value.AddMonths(1);
                DateTime d2 = new DateTime(dT.Year, dT.Month, 1);
                int days = ((TimeSpan)(d2 - d1)).Days;
                DateTime beginDT = new DateTime(this.myDateTimePicker1.Value.Year, this.myDateTimePicker1.Value.Month, 1, 00, 00, 00);
                DateTime endDT = new DateTime(this.myDateTimePicker1.Value.Year, this.myDateTimePicker1.Value.Month, days, 23, 59, 59);
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                DataTable dtData = dataAccess.GetTable(string.Format("exec 报关制造通知单料件月份统计 '{0}','{1}','{2}'", beginDT, endDT, ConfigurationManager.AppSettings["defaultManualCode"].ToString()));
                dataAccess.Close();
                this.myDataGridView1.DataSource = dtData;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(ex.Message);
            }
            finally
            {
                this.btnQuery.Enabled = true;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnExportExcel.Enabled = false;

                if (this.myDataGridView1.DataSource == null)
                {
                    SysMessage.InformationMsg("没有数据可导出！");
                    return;
                }
                DataTable dtData = (DataTable)this.myDataGridView1.DataSource;
                if (dtData.Rows.Count == 0)
                {
                    SysMessage.InformationMsg("没有数据可导出！");
                    return;
                }
                ExcelCommonMethod.ExportIntoExcel(dtData, this.Text);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(ex.Message);
            }
            finally
            {
                this.btnExportExcel.Enabled = true;
            }
        }

        private void FormMaterialsOutPrice_Load(object sender, EventArgs e)
        {
            this.myDateTimePicker1.Value = DateTime.Now;
        }
    }
}
