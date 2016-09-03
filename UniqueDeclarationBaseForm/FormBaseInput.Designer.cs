namespace UniqueDeclarationBaseForm
{
    partial class FormBaseInput
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDetail = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tool2_First = new System.Windows.Forms.ToolStripButton();
            this.tool2_up = new System.Windows.Forms.ToolStripButton();
            this.tool2_Down = new System.Windows.Forms.ToolStripButton();
            this.tool2_End = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool2_Import = new System.Windows.Forms.ToolStripButton();
            this.tool2_Add = new System.Windows.Forms.ToolStripButton();
            this.tool2_Delete = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool1_Add = new System.Windows.Forms.ToolStripButton();
            this.tool1_Save = new System.Windows.Forms.ToolStripButton();
            this.tool1_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewDetail);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(919, 297);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewDetail.Location = new System.Drawing.Point(3, 42);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.RowTemplate.Height = 23;
            this.dataGridViewDetail.Size = new System.Drawing.Size(913, 252);
            this.dataGridViewDetail.TabIndex = 2;
            this.dataGridViewDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetail_CellEndEdit);
            this.dataGridViewDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewDetail_DataError);
            this.dataGridViewDetail.SelectionChanged += new System.EventHandler(this.dataGridViewDetail_SelectionChanged);
            this.dataGridViewDetail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewDetail_KeyPress);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool2_First,
            this.tool2_up,
            this.tool2_Down,
            this.tool2_End,
            this.toolStripSeparator1,
            this.tool2_Import,
            this.tool2_Add,
            this.tool2_Delete});
            this.toolStrip2.Location = new System.Drawing.Point(3, 17);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(913, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tool2_First
            // 
            this.tool2_First.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool2_First.Image = global::UniqueDeclarationBaseForm.Properties.Resources.first_24px;
            this.tool2_First.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool2_First.Name = "tool2_First";
            this.tool2_First.Size = new System.Drawing.Size(23, 22);
            this.tool2_First.Text = "首笔";
            this.tool2_First.Click += new System.EventHandler(this.tool2_First_Click);
            // 
            // tool2_up
            // 
            this.tool2_up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool2_up.Image = global::UniqueDeclarationBaseForm.Properties.Resources.back_24px;
            this.tool2_up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool2_up.Name = "tool2_up";
            this.tool2_up.Size = new System.Drawing.Size(23, 22);
            this.tool2_up.Text = "上笔";
            this.tool2_up.Click += new System.EventHandler(this.tool2_up_Click);
            // 
            // tool2_Down
            // 
            this.tool2_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool2_Down.Image = global::UniqueDeclarationBaseForm.Properties.Resources.next_24px;
            this.tool2_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool2_Down.Name = "tool2_Down";
            this.tool2_Down.Size = new System.Drawing.Size(23, 22);
            this.tool2_Down.Text = "下笔";
            this.tool2_Down.Click += new System.EventHandler(this.tool2_Down_Click);
            // 
            // tool2_End
            // 
            this.tool2_End.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool2_End.Image = global::UniqueDeclarationBaseForm.Properties.Resources.last_24px;
            this.tool2_End.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool2_End.Name = "tool2_End";
            this.tool2_End.Size = new System.Drawing.Size(23, 22);
            this.tool2_End.Text = "末笔";
            this.tool2_End.Click += new System.EventHandler(this.tool2_End_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool2_Import
            // 
            this.tool2_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool2_Import.Image = global::UniqueDeclarationBaseForm.Properties.Resources.shopping_webshop_24px;
            this.tool2_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool2_Import.Name = "tool2_Import";
            this.tool2_Import.Size = new System.Drawing.Size(23, 22);
            this.tool2_Import.Text = "导入";
            this.tool2_Import.Click += new System.EventHandler(this.tool2_Import_Click);
            // 
            // tool2_Add
            // 
            this.tool2_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool2_Add.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Add_24px;
            this.tool2_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool2_Add.Name = "tool2_Add";
            this.tool2_Add.Size = new System.Drawing.Size(23, 22);
            this.tool2_Add.Text = "新增";
            this.tool2_Add.Click += new System.EventHandler(this.tool2_Add_Click);
            // 
            // tool2_Delete
            // 
            this.tool2_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool2_Delete.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Delete_24px;
            this.tool2_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool2_Delete.Name = "tool2_Delete";
            this.tool2_Delete.Size = new System.Drawing.Size(23, 22);
            this.tool2_Delete.Text = "删除";
            this.tool2_Delete.Click += new System.EventHandler(this.tool2_Delete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(919, 118);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool1_Add,
            this.tool1_Save,
            this.tool1_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(919, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool1_Add
            // 
            this.tool1_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Add.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Add_24px;
            this.tool1_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Add.Name = "tool1_Add";
            this.tool1_Add.Size = new System.Drawing.Size(23, 22);
            this.tool1_Add.Text = "新增";
            this.tool1_Add.Click += new System.EventHandler(this.tool1_Add_Click);
            // 
            // tool1_Save
            // 
            this.tool1_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Save.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Save_24pxt;
            this.tool1_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Save.Name = "tool1_Save";
            this.tool1_Save.Size = new System.Drawing.Size(23, 22);
            this.tool1_Save.Text = "保存";
            this.tool1_Save.Click += new System.EventHandler(this.tool1_Save_Click);
            // 
            // tool1_Close
            // 
            this.tool1_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Close.Image = global::UniqueDeclarationBaseForm.Properties.Resources.close_24px;
            this.tool1_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Close.Name = "tool1_Close";
            this.tool1_Close.Size = new System.Drawing.Size(23, 22);
            this.tool1_Close.Text = "关闭";
            this.tool1_Close.Click += new System.EventHandler(this.tool1_Close_Click);
            // 
            // FormBaseInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(919, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormBaseInput";
            this.Text = "录入基本窗体";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBaseInput_FormClosing);
            this.Load += new System.EventHandler(this.FormBaseInput_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStripButton tool1_Close;
        public System.Windows.Forms.ToolStripButton tool1_Add;
        public System.Windows.Forms.ToolStripButton tool1_Save;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ToolStrip toolStrip2;
        public System.Windows.Forms.ToolStripButton tool2_First;
        public System.Windows.Forms.ToolStripButton tool2_up;
        public System.Windows.Forms.ToolStripButton tool2_Down;
        public System.Windows.Forms.ToolStripButton tool2_End;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tool2_Import;
        public System.Windows.Forms.ToolStripButton tool2_Add;
        public System.Windows.Forms.ToolStripButton tool2_Delete;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public Controls.myDataGridView dataGridViewDetail;
    }
}
