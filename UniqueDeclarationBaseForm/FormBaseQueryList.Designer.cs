namespace UniqueDeclarationBaseForm
{
    partial class FormBaseQueryList
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_Query = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_Print = new System.Windows.Forms.ToolStripButton();
            this.tool1_ExportExcel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new UniqueDeclarationBaseForm.Controls.myTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnExportDetails = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnExportExcel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnDelete = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myCheckBox1 = new UniqueDeclarationBaseForm.Controls.myCheckBox();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.toolStripSeparator3,
            this.tool1_Query,
            this.toolStripSeparator4,
            this.tool1_Print,
            this.tool1_ExportExcel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1113, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tool1_First
            // 
            this.tool1_First.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_First.Image = global::UniqueDeclarationBaseForm.Properties.Resources.first_24px;
            this.tool1_First.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_First.Name = "tool1_First";
            this.tool1_First.Size = new System.Drawing.Size(23, 22);
            this.tool1_First.Text = "首笔";
            this.tool1_First.Click += new System.EventHandler(this.tool1_First_Click);
            // 
            // tool1_up
            // 
            this.tool1_up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_up.Image = global::UniqueDeclarationBaseForm.Properties.Resources.back_24px;
            this.tool1_up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_up.Name = "tool1_up";
            this.tool1_up.Size = new System.Drawing.Size(23, 22);
            this.tool1_up.Text = "上笔";
            this.tool1_up.Click += new System.EventHandler(this.tool1_up_Click);
            // 
            // tool1_Down
            // 
            this.tool1_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Down.Image = global::UniqueDeclarationBaseForm.Properties.Resources.next_24px;
            this.tool1_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Down.Name = "tool1_Down";
            this.tool1_Down.Size = new System.Drawing.Size(23, 22);
            this.tool1_Down.Text = "下笔";
            this.tool1_Down.Click += new System.EventHandler(this.tool1_Down_Click);
            // 
            // tool1_End
            // 
            this.tool1_End.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_End.Image = global::UniqueDeclarationBaseForm.Properties.Resources.last_24px;
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
            this.tool1_Import.Image = global::UniqueDeclarationBaseForm.Properties.Resources.shopping_webshop_24px;
            this.tool1_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Import.Name = "tool1_Import";
            this.tool1_Import.Size = new System.Drawing.Size(23, 22);
            this.tool1_Import.Text = "导入BOM";
            this.tool1_Import.Visible = false;
            this.tool1_Import.Click += new System.EventHandler(this.tool1_Import_Click);
            // 
            // tool1_Modify
            // 
            this.tool1_Modify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Modify.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Edit_24px;
            this.tool1_Modify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Modify.Name = "tool1_Modify";
            this.tool1_Modify.Size = new System.Drawing.Size(23, 22);
            this.tool1_Modify.Text = "修改";
            this.tool1_Modify.Click += new System.EventHandler(this.tool1_Modify_Click);
            // 
            // tool1_Delete
            // 
            this.tool1_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Delete.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Delete_24px;
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
            this.tool1_BOM.Image = global::UniqueDeclarationBaseForm.Properties.Resources.structure_24px;
            this.tool1_BOM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_BOM.Name = "tool1_BOM";
            this.tool1_BOM.Size = new System.Drawing.Size(23, 22);
            this.tool1_BOM.Text = "Bom";
            this.tool1_BOM.Click += new System.EventHandler(this.tool1_BOM_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tool1_Query
            // 
            this.tool1_Query.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Query.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Find_24px;
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
            this.tool1_Print.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Print_24px;
            this.tool1_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Print.Name = "tool1_Print";
            this.tool1_Print.Size = new System.Drawing.Size(23, 22);
            this.tool1_Print.Text = "打印";
            this.tool1_Print.Visible = false;
            this.tool1_Print.Click += new System.EventHandler(this.tool1_Print_Click);
            // 
            // tool1_ExportExcel
            // 
            this.tool1_ExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_ExportExcel.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Excel_2013_24px;
            this.tool1_ExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_ExportExcel.Name = "tool1_ExportExcel";
            this.tool1_ExportExcel.Size = new System.Drawing.Size(23, 22);
            this.tool1_ExportExcel.Text = "导出EXCEL";
            this.tool1_ExportExcel.Click += new System.EventHandler(this.tool1_ExportExcel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1113, 524);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 522);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(800, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "订单内容";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(658, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "归并后材料总用量表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(658, 387);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "归并前材料总用量表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(658, 387);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "归并前材料明细总用量表";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnExportDetails
            // 
            this.btnExportDetails.Location = new System.Drawing.Point(484, 1);
            this.btnExportDetails.Name = "btnExportDetails";
            this.btnExportDetails.Size = new System.Drawing.Size(90, 23);
            this.btnExportDetails.TabIndex = 4;
            this.btnExportDetails.Text = "导出材料明细";
            this.btnExportDetails.UseVisualStyleBackColor = true;
            this.btnExportDetails.Click += new System.EventHandler(this.btnExportDetails_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(580, 1);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(90, 23);
            this.btnExportExcel.TabIndex = 5;
            this.btnExportExcel.Text = "导出到Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(676, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除预先订单";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.AutoSize = true;
            this.myCheckBox1.Checked = true;
            this.myCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.myCheckBox1.Location = new System.Drawing.Point(773, 4);
            this.myCheckBox1.Name = "myCheckBox1";
            this.myCheckBox1.Size = new System.Drawing.Size(72, 16);
            this.myCheckBox1.TabIndex = 7;
            this.myCheckBox1.Text = "导出实重";
            this.myCheckBox1.UseVisualStyleBackColor = true;
            // 
            // FormBaseQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1113, 549);
            this.Controls.Add(this.myCheckBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnExportDetails);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.IsScaling = false;
            this.Name = "FormBaseQueryList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询列表基本窗体";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
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
        public System.Windows.Forms.ToolStripButton tool1_Modify;
        public System.Windows.Forms.ToolStripButton tool1_Delete;
        public System.Windows.Forms.ToolStripButton tool1_BOM;
        public System.Windows.Forms.ToolStripButton tool1_Query;
        public System.Windows.Forms.ToolStripButton tool1_Print;
        public System.Windows.Forms.ToolStripButton tool1_ExportExcel;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public UniqueDeclarationBaseForm.Controls.myTabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.TabPage tabPage4;
        public Controls.myButton btnExportDetails;
        public Controls.myButton btnExportExcel;
        public Controls.myButton btnDelete;
        private Controls.myCheckBox myCheckBox1;
        public System.Windows.Forms.ToolStripButton tool1_Import;
    }
}
