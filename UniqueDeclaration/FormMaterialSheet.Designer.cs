namespace UniqueDeclaration
{
    partial class FormMaterialSheet
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
            this.tool1_ExportExcel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.myDataGridView1 = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.myDataGridView2 = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myDataGridView3 = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myLable3 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myContextMenuStripCell1 = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextMenuStripCell2 = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextMenuStripCell3 = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.btnExportMaterialSheet = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportMaterialSheet,
            this.tool1_ExportExcel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1006, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tool1_ExportExcel
            // 
            this.tool1_ExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_ExportExcel.Image = global::UniqueDeclaration.Properties.Resources.Excel_2013_24px;
            this.tool1_ExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_ExportExcel.Name = "tool1_ExportExcel";
            this.tool1_ExportExcel.Size = new System.Drawing.Size(23, 22);
            this.tool1_ExportExcel.Text = "导出EXCEL";
            this.tool1_ExportExcel.Click += new System.EventHandler(this.tool1_ExportExcel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.myDataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.myLable1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1006, 543);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.TabIndex = 5;
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.AllowUserToAddRows = false;
            this.myDataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridView1.Location = new System.Drawing.Point(0, 15);
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.ReadOnly = true;
            this.myDataGridView1.RowTemplate.Height = 23;
            this.myDataGridView1.Size = new System.Drawing.Size(1006, 167);
            this.myDataGridView1.TabIndex = 1;
            // 
            // myLable1
            // 
            this.myLable1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myLable1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myLable1.Location = new System.Drawing.Point(0, 0);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(1006, 15);
            this.myLable1.TabIndex = 0;
            this.myLable1.Text = "归并后料件清单";
            this.myLable1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.myDataGridView2);
            this.splitContainer2.Panel1.Controls.Add(this.myLable2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.myDataGridView3);
            this.splitContainer2.Panel2.Controls.Add(this.myLable3);
            this.splitContainer2.Size = new System.Drawing.Size(1006, 357);
            this.splitContainer2.SplitterDistance = 173;
            this.splitContainer2.TabIndex = 0;
            // 
            // myDataGridView2
            // 
            this.myDataGridView2.AllowUserToAddRows = false;
            this.myDataGridView2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridView2.Location = new System.Drawing.Point(0, 15);
            this.myDataGridView2.Name = "myDataGridView2";
            this.myDataGridView2.ReadOnly = true;
            this.myDataGridView2.RowTemplate.Height = 23;
            this.myDataGridView2.Size = new System.Drawing.Size(1006, 158);
            this.myDataGridView2.TabIndex = 3;
            // 
            // myLable2
            // 
            this.myLable2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myLable2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myLable2.Location = new System.Drawing.Point(0, 0);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(1006, 15);
            this.myLable2.TabIndex = 2;
            this.myLable2.Text = "归并前料件清单";
            this.myLable2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myDataGridView3
            // 
            this.myDataGridView3.AllowUserToAddRows = false;
            this.myDataGridView3.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridView3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridView3.Location = new System.Drawing.Point(0, 15);
            this.myDataGridView3.Name = "myDataGridView3";
            this.myDataGridView3.ReadOnly = true;
            this.myDataGridView3.RowTemplate.Height = 23;
            this.myDataGridView3.Size = new System.Drawing.Size(1006, 165);
            this.myDataGridView3.TabIndex = 3;
            // 
            // myLable3
            // 
            this.myLable3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myLable3.Dock = System.Windows.Forms.DockStyle.Top;
            this.myLable3.Location = new System.Drawing.Point(0, 0);
            this.myLable3.Name = "myLable3";
            this.myLable3.Size = new System.Drawing.Size(1006, 15);
            this.myLable3.TabIndex = 2;
            this.myLable3.Text = "归并前料件明细清单";
            this.myLable3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myContextMenuStripCell1
            // 
            this.myContextMenuStripCell1.MyDataGridView = this.myDataGridView1;
            this.myContextMenuStripCell1.Name = "myContextMenuStripCell1";
            this.myContextMenuStripCell1.Size = new System.Drawing.Size(101, 26);
            // 
            // myContextMenuStripCell2
            // 
            this.myContextMenuStripCell2.MyDataGridView = this.myDataGridView2;
            this.myContextMenuStripCell2.Name = "myContextMenuStripCell2";
            this.myContextMenuStripCell2.Size = new System.Drawing.Size(101, 26);
            // 
            // myContextMenuStripCell3
            // 
            this.myContextMenuStripCell3.MyDataGridView = this.myDataGridView3;
            this.myContextMenuStripCell3.Name = "myContextMenuStripCell3";
            this.myContextMenuStripCell3.Size = new System.Drawing.Size(101, 26);
            // 
            // btnExportMaterialSheet
            // 
            this.btnExportMaterialSheet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportMaterialSheet.Image = global::UniqueDeclaration.Properties.Resources.Excel_2013_24px;
            this.btnExportMaterialSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportMaterialSheet.Name = "btnExportMaterialSheet";
            this.btnExportMaterialSheet.Size = new System.Drawing.Size(23, 22);
            this.btnExportMaterialSheet.Text = "导出商品归并关系表";
            this.btnExportMaterialSheet.Click += new System.EventHandler(this.btnExportMaterialSheet_Click);
            // 
            // FormMaterialSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1006, 568);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "FormMaterialSheet";
            this.Text = "商品归并关系表查询";
            this.Load += new System.EventHandler(this.FormMaterialSheet_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip2;
        public System.Windows.Forms.ToolStripButton tool1_ExportExcel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridView1;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridView2;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridView3;
        private UniqueDeclarationBaseForm.Controls.myLable myLable3;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuStripCell1;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuStripCell2;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuStripCell3;
        public System.Windows.Forms.ToolStripButton btnExportMaterialSheet;
    }
}
