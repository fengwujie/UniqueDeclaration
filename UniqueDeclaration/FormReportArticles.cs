using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace UniqueDeclaration.Report
{
    public partial class FormReportArticles : Form
    {
        public FormReportArticles()
        {
            InitializeComponent();
        }

        public DataSet ds = null;
        private void FormReportArticles_Load(object sender, EventArgs e)
        {
            //string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Report\ReportArticlesFile.rdlc");
            reportViewer1.LocalReport.ReportPath ="F:\\Unique\\UniqueDeclaration\\UniqueDeclaration\\Report\\ReportArticlesFile.rdlc" ;//strSourceFile;
            //(上面这句我运行时候出现中不到Report1定义，在Report1属性中查看了下路径改过来就行，reportViewer1.LocalReport.ReportPath = 
            //"D:\\程序\\C#\\WindowsFormsApplication1\\WindowsFormsApplication1" + "\\Report1.rdlc";)
             //指定数据集,数据集名称后为表,不是DataSet类型的数据集
             this.reportViewer1.LocalReport.DataSources.Clear();
             this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetArticlesFile1", ds.Tables[0]));
             this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetArticlesFile2", ds.Tables[1]));
             //显示报表
            this.reportViewer1.RefreshReport();

            //DataSet dts = new DataSet();
            ////控件要绑定的rdlc
            //this.reportViewer1.LocalReport.ReportPath = @"Report/ReportArticles.rdlc";
            ////给数据源添加数据源实例
            //ReportDataSource datasource = new ReportDataSource();
            //datasource.Name = "DataSet1";
            //datasource.Value = dtData;  // dts.Tables[0];            
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(datasource);
            //reportViewer1.LocalReport.Refresh();
        }
    }
}
