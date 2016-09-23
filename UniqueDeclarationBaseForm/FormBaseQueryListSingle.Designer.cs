namespace UniqueDeclarationBaseForm
{
    partial class FormBaseQueryListSingle
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_Details = new System.Windows.Forms.ToolStripButton();
            this.tool_ExportExcel = new System.Windows.Forms.ToolStripButton();
            this.myDataGridView1 = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lab_Date = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_Count = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myContextMenuStripCell1 = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_Details,
            this.tool_ExportExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1048, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_Details
            // 
            this.tool_Details.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_Details.Image = global::UniqueDeclarationBaseForm.Properties.Resources.structure_24px;
            this.tool_Details.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_Details.Name = "tool_Details";
            this.tool_Details.Size = new System.Drawing.Size(23, 22);
            this.tool_Details.Text = "明细";
            this.tool_Details.Click += new System.EventHandler(this.tool_Details_Click);
            // 
            // tool_ExportExcel
            // 
            this.tool_ExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_ExportExcel.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Excel_2013_24px;
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
            this.myDataGridView1.Size = new System.Drawing.Size(1048, 538);
            this.myDataGridView1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lab_Date, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lab_Count, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 563);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1048, 25);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lab_Date
            // 
            this.lab_Date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_Date.Location = new System.Drawing.Point(528, 2);
            this.lab_Date.Name = "lab_Date";
            this.lab_Date.Size = new System.Drawing.Size(515, 21);
            this.lab_Date.TabIndex = 1;
            this.lab_Date.Text = "日期从";
            this.lab_Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_Count
            // 
            this.lab_Count.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_Count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_Count.Location = new System.Drawing.Point(5, 2);
            this.lab_Count.Name = "lab_Count";
            this.lab_Count.Size = new System.Drawing.Size(515, 21);
            this.lab_Count.TabIndex = 0;
            this.lab_Count.Text = "记录数量";
            this.lab_Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // myContextMenuStripCell1
            // 
            this.myContextMenuStripCell1.MyDataGridView = this.myDataGridView1;
            this.myContextMenuStripCell1.Name = "myContextMenuStripCell1";
            this.myContextMenuStripCell1.Size = new System.Drawing.Size(101, 26);
            // 
            // FormBaseJXCList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1048, 588);
            this.Controls.Add(this.myDataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormBaseJXCList";
            this.Text = "进销存查询基本窗体";
            this.Load += new System.EventHandler(this.FormBaseJXCList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tool_Details;
        public System.Windows.Forms.ToolStripButton tool_ExportExcel;
        public Controls.myDataGridView myDataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public Controls.myLable lab_Count;
        public Controls.myLable lab_Date;
        private Controls.myContextMenuStripCell myContextMenuStripCell1;
    }
}
