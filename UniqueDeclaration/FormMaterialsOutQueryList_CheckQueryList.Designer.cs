namespace UniqueDeclaration
{
    partial class FormMaterialsOutQueryList_CheckQueryList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMaterialsOutQueryList_CheckQueryList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_ExportExcel = new System.Windows.Forms.ToolStripButton();
            this.myDataGridView1 = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myContextMenuStripCell1 = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_ExportExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(919, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_ExportExcel
            // 
            this.tool_ExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_ExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("tool_ExportExcel.Image")));
            this.tool_ExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_ExportExcel.Name = "tool_ExportExcel";
            this.tool_ExportExcel.Size = new System.Drawing.Size(23, 22);
            this.tool_ExportExcel.Text = "导出EXCEL";
            this.tool_ExportExcel.Click += new System.EventHandler(this.tool_ExportExcel_Click);
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.AllowUserToAddRows = false;
            this.myDataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridView1.Location = new System.Drawing.Point(0, 25);
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.ReadOnly = true;
            this.myDataGridView1.RowTemplate.Height = 23;
            this.myDataGridView1.Size = new System.Drawing.Size(919, 415);
            this.myDataGridView1.TabIndex = 1;
            // 
            // myContextMenuStripCell1
            // 
            this.myContextMenuStripCell1.MyDataGridView = this.myDataGridView1;
            this.myContextMenuStripCell1.Name = "myContextMenuStripCell1";
            this.myContextMenuStripCell1.Size = new System.Drawing.Size(101, 26);
            // 
            // FormMaterialsOutQueryList_CheckQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(919, 440);
            this.Controls.Add(this.myDataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormMaterialsOutQueryList_CheckQueryList";
            this.Text = "进口料件明细表";
            this.Load += new System.EventHandler(this.FormMaterialsOutQueryList_CheckQueryList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_ExportExcel;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridView1;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuStripCell1;
    }
}
