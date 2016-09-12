namespace UniqueDeclaration
{
    partial class FormFinishedProductOutQueryList
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tool1_First = new System.Windows.Forms.ToolStripButton();
            this.tool1_up = new System.Windows.Forms.ToolStripButton();
            this.tool1_Down = new System.Windows.Forms.ToolStripButton();
            this.tool1_End = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_Import = new System.Windows.Forms.ToolStripButton();
            this.tool1_Modify = new System.Windows.Forms.ToolStripButton();
            this.tool1_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_BOM = new System.Windows.Forms.ToolStripButton();
            this.tool1_Query = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_Print = new System.Windows.Forms.ToolStripButton();
            this.tool1_ExportExcel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewHead = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.tabControl1 = new UniqueDeclarationBaseForm.Controls.myTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewDetails = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewDetailsSumCount = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myContextHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextDetails = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextDetailsSumCount = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.btnMaterialComparison = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnExportExcel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnPrint = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnDelete = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnCheckData = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myCheckBox1 = new UniqueDeclarationBaseForm.Controls.myCheckBox();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHead)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetailsSumCount)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool1_First,
            this.tool1_up,
            this.tool1_Down,
            this.tool1_End,
            this.toolStripSeparator1,
            this.tool1_Import,
            this.tool1_Modify,
            this.tool1_Delete,
            this.toolStripSeparator2,
            this.tool1_BOM,
            this.tool1_Query,
            this.toolStripSeparator4,
            this.tool1_Print,
            this.tool1_ExportExcel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1168, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tool1_First
            // 
            this.tool1_First.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_First.Image = global::UniqueDeclaration.Properties.Resources.first_24px;
            this.tool1_First.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_First.Name = "tool1_First";
            this.tool1_First.Size = new System.Drawing.Size(23, 22);
            this.tool1_First.Text = "首笔";
            this.tool1_First.Click += new System.EventHandler(this.tool1_First_Click);
            // 
            // tool1_up
            // 
            this.tool1_up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_up.Image = global::UniqueDeclaration.Properties.Resources.back_24px;
            this.tool1_up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_up.Name = "tool1_up";
            this.tool1_up.Size = new System.Drawing.Size(23, 22);
            this.tool1_up.Text = "上笔";
            this.tool1_up.Click += new System.EventHandler(this.tool1_up_Click);
            // 
            // tool1_Down
            // 
            this.tool1_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Down.Image = global::UniqueDeclaration.Properties.Resources.next_24px;
            this.tool1_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Down.Name = "tool1_Down";
            this.tool1_Down.Size = new System.Drawing.Size(23, 22);
            this.tool1_Down.Text = "下笔";
            this.tool1_Down.Click += new System.EventHandler(this.tool1_Down_Click);
            // 
            // tool1_End
            // 
            this.tool1_End.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_End.Image = global::UniqueDeclaration.Properties.Resources.last_24px;
            this.tool1_End.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_End.Name = "tool1_End";
            this.tool1_End.Size = new System.Drawing.Size(23, 22);
            this.tool1_End.Text = "末笔";
            this.tool1_End.Click += new System.EventHandler(this.tool1_End_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool1_Import
            // 
            this.tool1_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Import.Image = global::UniqueDeclaration.Properties.Resources.shopping_webshop_24px;
            this.tool1_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Import.Name = "tool1_Import";
            this.tool1_Import.Size = new System.Drawing.Size(23, 22);
            this.tool1_Import.Text = "导入BOM";
            this.tool1_Import.Click += new System.EventHandler(this.tool1_Import_Click);
            // 
            // tool1_Modify
            // 
            this.tool1_Modify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Modify.Image = global::UniqueDeclaration.Properties.Resources.Edit_24px;
            this.tool1_Modify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Modify.Name = "tool1_Modify";
            this.tool1_Modify.Size = new System.Drawing.Size(23, 22);
            this.tool1_Modify.Text = "修改";
            this.tool1_Modify.Click += new System.EventHandler(this.tool1_Modify_Click);
            // 
            // tool1_Delete
            // 
            this.tool1_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Delete.Image = global::UniqueDeclaration.Properties.Resources.Delete_24px;
            this.tool1_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Delete.Name = "tool1_Delete";
            this.tool1_Delete.Size = new System.Drawing.Size(23, 22);
            this.tool1_Delete.Text = "删除";
            this.tool1_Delete.Click += new System.EventHandler(this.tool1_Delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tool1_BOM
            // 
            this.tool1_BOM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_BOM.Image = global::UniqueDeclaration.Properties.Resources.structure_24px;
            this.tool1_BOM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_BOM.Name = "tool1_BOM";
            this.tool1_BOM.Size = new System.Drawing.Size(23, 22);
            this.tool1_BOM.Text = "BOM结构";
            this.tool1_BOM.Click += new System.EventHandler(this.tool1_BOM_Click);
            // 
            // tool1_Query
            // 
            this.tool1_Query.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Query.Image = global::UniqueDeclaration.Properties.Resources.Find_24px;
            this.tool1_Query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Query.Name = "tool1_Query";
            this.tool1_Query.Size = new System.Drawing.Size(23, 22);
            this.tool1_Query.Text = "查询";
            this.tool1_Query.ToolTipText = "查询";
            this.tool1_Query.Click += new System.EventHandler(this.tool1_Query_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tool1_Print
            // 
            this.tool1_Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Print.Image = global::UniqueDeclaration.Properties.Resources.Print_24px;
            this.tool1_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Print.Name = "tool1_Print";
            this.tool1_Print.Size = new System.Drawing.Size(23, 22);
            this.tool1_Print.Text = "打印";
            this.tool1_Print.Click += new System.EventHandler(this.tool1_Print_Click);
            // 
            // tool1_ExportExcel
            // 
            this.tool1_ExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_ExportExcel.Image = global::UniqueDeclaration.Properties.Resources.Excel_2013_24px;
            this.tool1_ExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_ExportExcel.Name = "tool1_ExportExcel";
            this.tool1_ExportExcel.Size = new System.Drawing.Size(23, 22);
            this.tool1_ExportExcel.Text = "导出EXCEL";
            this.tool1_ExportExcel.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewHead);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 496);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.TabIndex = 5;
            // 
            // dataGridViewHead
            // 
            this.dataGridViewHead.AllowUserToAddRows = false;
            this.dataGridViewHead.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHead.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewHead.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHead.Name = "dataGridViewHead";
            this.dataGridViewHead.ReadOnly = true;
            this.dataGridViewHead.RowTemplate.Height = 23;
            this.dataGridViewHead.Size = new System.Drawing.Size(345, 496);
            this.dataGridViewHead.TabIndex = 0;
            this.dataGridViewHead.SelectionChanged += new System.EventHandler(this.dataGridViewHead_SelectionChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(819, 496);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewDetails);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(811, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "订单内容";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToAddRows = false;
            this.dataGridViewDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewDetails.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.ReadOnly = true;
            this.dataGridViewDetails.RowTemplate.Height = 23;
            this.dataGridViewDetails.Size = new System.Drawing.Size(805, 464);
            this.dataGridViewDetails.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewDetailsSumCount);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(843, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "材料总用量表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDetailsSumCount
            // 
            this.dataGridViewDetailsSumCount.AllowUserToAddRows = false;
            this.dataGridViewDetailsSumCount.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewDetailsSumCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetailsSumCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetailsSumCount.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewDetailsSumCount.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewDetailsSumCount.Name = "dataGridViewDetailsSumCount";
            this.dataGridViewDetailsSumCount.ReadOnly = true;
            this.dataGridViewDetailsSumCount.RowTemplate.Height = 23;
            this.dataGridViewDetailsSumCount.Size = new System.Drawing.Size(837, 464);
            this.dataGridViewDetailsSumCount.TabIndex = 1;
            // 
            // myContextHead
            // 
            this.myContextHead.MyDataGridView = this.dataGridViewHead;
            this.myContextHead.Name = "myContextHead";
            this.myContextHead.Size = new System.Drawing.Size(101, 26);
            // 
            // myContextDetails
            // 
            this.myContextDetails.MyDataGridView = this.dataGridViewDetails;
            this.myContextDetails.Name = "myContextDetails";
            this.myContextDetails.Size = new System.Drawing.Size(101, 26);
            // 
            // myContextDetailsSumCount
            // 
            this.myContextDetailsSumCount.MyDataGridView = this.dataGridViewDetailsSumCount;
            this.myContextDetailsSumCount.Name = "myContextDetailsSumCount";
            this.myContextDetailsSumCount.Size = new System.Drawing.Size(101, 26);
            // 
            // btnMaterialComparison
            // 
            this.btnMaterialComparison.Location = new System.Drawing.Point(349, 2);
            this.btnMaterialComparison.Name = "btnMaterialComparison";
            this.btnMaterialComparison.Size = new System.Drawing.Size(80, 23);
            this.btnMaterialComparison.TabIndex = 6;
            this.btnMaterialComparison.Text = "材料对照表";
            this.btnMaterialComparison.UseVisualStyleBackColor = true;
            this.btnMaterialComparison.Visible = false;
            this.btnMaterialComparison.Click += new System.EventHandler(this.btnMaterialComparison_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(436, 2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(80, 23);
            this.btnExportExcel.TabIndex = 7;
            this.btnExportExcel.Text = "导出到Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(523, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 23);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "打印订单";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(610, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "删除订单";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCheckData
            // 
            this.btnCheckData.Location = new System.Drawing.Point(697, 2);
            this.btnCheckData.Name = "btnCheckData";
            this.btnCheckData.Size = new System.Drawing.Size(80, 23);
            this.btnCheckData.TabIndex = 10;
            this.btnCheckData.Text = "数据检查";
            this.btnCheckData.UseVisualStyleBackColor = true;
            this.btnCheckData.Click += new System.EventHandler(this.btnCheckData_Click);
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.AutoSize = true;
            this.myCheckBox1.Checked = true;
            this.myCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.myCheckBox1.Location = new System.Drawing.Point(784, 5);
            this.myCheckBox1.Name = "myCheckBox1";
            this.myCheckBox1.Size = new System.Drawing.Size(72, 16);
            this.myCheckBox1.TabIndex = 11;
            this.myCheckBox1.Text = "导出实重";
            this.myCheckBox1.UseVisualStyleBackColor = true;
            // 
            // FormFinishedProductOutQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1168, 521);
            this.Controls.Add(this.myCheckBox1);
            this.Controls.Add(this.btnCheckData);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnMaterialComparison);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "FormFinishedProductOutQueryList";
            this.Text = "成品出货查询";
            this.Load += new System.EventHandler(this.FormFinishedProductOutQueryList_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHead)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetailsSumCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip2;
        public System.Windows.Forms.ToolStripButton tool1_First;
        public System.Windows.Forms.ToolStripButton tool1_up;
        public System.Windows.Forms.ToolStripButton tool1_Down;
        public System.Windows.Forms.ToolStripButton tool1_End;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tool1_Import;
        public System.Windows.Forms.ToolStripButton tool1_Modify;
        public System.Windows.Forms.ToolStripButton tool1_Delete;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton tool1_Query;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripButton tool1_Print;
        public System.Windows.Forms.ToolStripButton tool1_ExportExcel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UniqueDeclarationBaseForm.Controls.myDataGridView dataGridViewHead;
        private UniqueDeclarationBaseForm.Controls.myTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private UniqueDeclarationBaseForm.Controls.myDataGridView dataGridViewDetails;
        private System.Windows.Forms.TabPage tabPage2;
        private UniqueDeclarationBaseForm.Controls.myDataGridView dataGridViewDetailsSumCount;
        private System.Windows.Forms.ToolStripButton tool1_BOM;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextHead;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetails;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetailsSumCount;
        private UniqueDeclarationBaseForm.Controls.myButton btnMaterialComparison;
        private UniqueDeclarationBaseForm.Controls.myButton btnExportExcel;
        private UniqueDeclarationBaseForm.Controls.myButton btnPrint;
        private UniqueDeclarationBaseForm.Controls.myButton btnDelete;
        private UniqueDeclarationBaseForm.Controls.myButton btnCheckData;
        private UniqueDeclarationBaseForm.Controls.myCheckBox myCheckBox1;

    }
}
