namespace UniqueDeclaration
{
    partial class FormOuterMaterialTotal
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
            this.tool1_Query = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_ExportExcel = new System.Windows.Forms.ToolStripButton();
            this.myDataGridViewHead = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myContextMenuStripCell1 = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.手册编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.成品名称及商编 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.料件编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.料件名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.料件数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.料件单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewHead)).BeginInit();
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
            this.tool1_Query,
            this.toolStripSeparator4,
            this.tool1_ExportExcel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(817, 25);
            this.toolStrip2.TabIndex = 3;
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
            // myDataGridViewHead
            // 
            this.myDataGridViewHead.AllowUserToAddRows = false;
            this.myDataGridViewHead.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridViewHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridViewHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.手册编号,
            this.成品名称及商编,
            this.料件编号,
            this.料件名称,
            this.料件数量,
            this.料件单位});
            this.myDataGridViewHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridViewHead.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridViewHead.Location = new System.Drawing.Point(0, 25);
            this.myDataGridViewHead.Name = "myDataGridViewHead";
            this.myDataGridViewHead.RowTemplate.Height = 23;
            this.myDataGridViewHead.Size = new System.Drawing.Size(817, 506);
            this.myDataGridViewHead.TabIndex = 4;
            // 
            // myContextMenuStripCell1
            // 
            this.myContextMenuStripCell1.MyDataGridView = this.myDataGridViewHead;
            this.myContextMenuStripCell1.Name = "myContextMenuStripCell1";
            this.myContextMenuStripCell1.Size = new System.Drawing.Size(101, 26);
            // 
            // 手册编号
            // 
            this.手册编号.ContextMenuStrip = this.myContextMenuStripCell1;
            this.手册编号.DataPropertyName = "手册编号";
            this.手册编号.HeaderText = "手册编号";
            this.手册编号.Name = "手册编号";
            this.手册编号.ReadOnly = true;
            // 
            // 成品名称及商编
            // 
            this.成品名称及商编.ContextMenuStrip = this.myContextMenuStripCell1;
            this.成品名称及商编.DataPropertyName = "成品名称及商编";
            this.成品名称及商编.HeaderText = "成品名称及商编";
            this.成品名称及商编.Name = "成品名称及商编";
            this.成品名称及商编.ReadOnly = true;
            this.成品名称及商编.Width = 130;
            // 
            // 料件编号
            // 
            this.料件编号.ContextMenuStrip = this.myContextMenuStripCell1;
            this.料件编号.DataPropertyName = "料件编号";
            this.料件编号.HeaderText = "料件编号";
            this.料件编号.Name = "料件编号";
            this.料件编号.ReadOnly = true;
            // 
            // 料件名称
            // 
            this.料件名称.ContextMenuStrip = this.myContextMenuStripCell1;
            this.料件名称.DataPropertyName = "料件名称";
            this.料件名称.HeaderText = "料件名称";
            this.料件名称.Name = "料件名称";
            this.料件名称.ReadOnly = true;
            this.料件名称.Width = 150;
            // 
            // 料件数量
            // 
            this.料件数量.ContextMenuStrip = this.myContextMenuStripCell1;
            this.料件数量.DataPropertyName = "料件数量";
            this.料件数量.HeaderText = "料件数量";
            this.料件数量.Name = "料件数量";
            this.料件数量.ReadOnly = true;
            // 
            // 料件单位
            // 
            this.料件单位.ContextMenuStrip = this.myContextMenuStripCell1;
            this.料件单位.DataPropertyName = "料件单位";
            this.料件单位.HeaderText = "料件单位";
            this.料件单位.Name = "料件单位";
            this.料件单位.ReadOnly = true;
            // 
            // FormOuterMaterialTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(817, 531);
            this.Controls.Add(this.myDataGridViewHead);
            this.Controls.Add(this.toolStrip2);
            this.Name = "FormOuterMaterialTotal";
            this.Text = "出口料件统计";
            this.Load += new System.EventHandler(this.FormOuterMaterialTotal_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewHead)).EndInit();
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
        public System.Windows.Forms.ToolStripButton tool1_Query;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripButton tool1_ExportExcel;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridViewHead;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuStripCell1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 手册编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 成品名称及商编;
        private System.Windows.Forms.DataGridViewTextBoxColumn 料件编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 料件名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 料件数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 料件单位;
    }
}
