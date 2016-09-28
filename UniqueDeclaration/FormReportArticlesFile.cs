using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UniqueDeclaration
{
    public partial class FormReportArticlesFile : UniqueDeclarationBaseForm.FormBase
    {
        public FormReportArticlesFile()
        {
            InitializeComponent();
        }
        //public DataSet ds = null;
        public DataTable dtData = null;
        private void FormReportArticlesFile_Load(object sender, EventArgs e)
        {
            //reportViewer1.LocalReport.ReportPath = "F:\\Unique\\UniqueDeclaration\\UniqueDeclaration\\ReportArticlesFile.rdlc";
            //string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Report\ReportArticlesFile.rdlc");
            reportViewer1.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Report\ReportArticlesFile.rdlc");
                //(上面这句我运行时候出现中不到Report1定义，在Report1属性中查看了下路径改过来就行，reportViewer1.LocalReport.ReportPath = 
                //"D:\\程序\\C#\\WindowsFormsApplication1\\WindowsFormsApplication1" + "\\Report1.rdlc";)
             //指定数据集,数据集名称后为表,不是DataSet类型的数据集
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetArticlesFile", dtData));
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetArticlesFileHead", dtData));
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetArticlesFileDetail", dtData));
            this.reportViewer1.RefreshReport();
        }
    }
}
