namespace UniqueDeclaration
{
    partial class FormReportArticlesFile
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dtHeadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetArticlesFile = new UniqueDeclaration.DataSetArticlesFile();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dtHeadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetArticlesFile)).BeginInit();
            this.SuspendLayout();
            // 
            // dtHeadBindingSource
            // 
            this.dtHeadBindingSource.DataMember = "dtHead";
            this.dtHeadBindingSource.DataSource = this.DataSetArticlesFile;
            // 
            // DataSetArticlesFile
            // 
            this.DataSetArticlesFile.DataSetName = "DataSetArticlesFile";
            this.DataSetArticlesFile.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetArticlesFile";
            reportDataSource2.Value = this.dtHeadBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UniqueDeclaration.ReportArticlesFile.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(791, 578);
            this.reportViewer1.TabIndex = 0;
            // 
            // FormReportArticlesFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(791, 578);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReportArticlesFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Article";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReportArticlesFile_FormClosing);
            this.Load += new System.EventHandler(this.FormReportArticlesFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtHeadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetArticlesFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dtHeadBindingSource;
        private DataSetArticlesFile DataSetArticlesFile;
    }
}
