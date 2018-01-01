namespace UniqueDeclaration
{
    partial class FormMaterialsOutPrice
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportExcel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnQuery = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myDateTimePicker1 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.myDataGridView1 = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.myLable1);
            this.panel1.Controls.Add(this.myDateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1368, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(374, 8);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(101, 32);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "导出EXCEL";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(269, 8);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(99, 32);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // myLable1
            // 
            this.myLable1.AutoSize = true;
            this.myLable1.Location = new System.Drawing.Point(28, 17);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(82, 15);
            this.myLable1.TabIndex = 1;
            this.myLable1.Text = "统计月份：";
            // 
            // myDateTimePicker1
            // 
            this.myDateTimePicker1.CustomFormat = "yyyy年MM月";
            this.myDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.myDateTimePicker1.Location = new System.Drawing.Point(116, 12);
            this.myDateTimePicker1.Name = "myDateTimePicker1";
            this.myDateTimePicker1.ShowUpDown = true;
            this.myDateTimePicker1.Size = new System.Drawing.Size(115, 25);
            this.myDateTimePicker1.TabIndex = 0;
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.AllowUserToAddRows = false;
            this.myDataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridView1.Location = new System.Drawing.Point(0, 44);
            this.myDataGridView1.MultiSelect = false;
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.ReadOnly = true;
            this.myDataGridView1.RowTemplate.Height = 23;
            this.myDataGridView1.Size = new System.Drawing.Size(1368, 678);
            this.myDataGridView1.TabIndex = 1;
            // 
            // FormMaterialsOutPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1368, 722);
            this.Controls.Add(this.myDataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormMaterialsOutPrice";
            this.Text = "料件出口报关统计（成本价）";
            this.Load += new System.EventHandler(this.FormMaterialsOutPrice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridView1;
        private UniqueDeclarationBaseForm.Controls.myButton btnExportExcel;
        private UniqueDeclarationBaseForm.Controls.myButton btnQuery;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker myDateTimePicker1;
    }
}
