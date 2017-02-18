namespace UniqueDeclaration.Base
{
    partial class FormFitBOM
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
            this.tool1_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_BOM = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_Close = new System.Windows.Forms.ToolStripButton();
            this.myTabControl1 = new UniqueDeclarationBaseForm.Controls.myTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteFit = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myDataGridViewFit = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteMaterials = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myDataGridViewMaterials = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_明细备注 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myDataGridViewMaterialsDetails = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_实际总重 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.btnDeleteDeclarationMaterialsDetails = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myDataGridViewDeclarationMaterialsDetails = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.toolStrip1.SuspendLayout();
            this.myTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewFit)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewMaterials)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewMaterialsDetails)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewDeclarationMaterialsDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool1_Save,
            this.toolStripSeparator1,
            this.tool1_BOM,
            this.toolStripSeparator2,
            this.tool1_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(706, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool1_Save
            // 
            this.tool1_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Save.Image = global::UniqueDeclaration.Properties.Resources.Save_24pxt;
            this.tool1_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Save.Name = "tool1_Save";
            this.tool1_Save.Size = new System.Drawing.Size(23, 22);
            this.tool1_Save.Text = "保存";
            this.tool1_Save.Click += new System.EventHandler(this.tool1_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool1_BOM
            // 
            this.tool1_BOM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_BOM.Image = global::UniqueDeclaration.Properties.Resources.structure_24px;
            this.tool1_BOM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_BOM.Name = "tool1_BOM";
            this.tool1_BOM.Size = new System.Drawing.Size(23, 22);
            this.tool1_BOM.Text = "结构组成";
            this.tool1_BOM.Click += new System.EventHandler(this.tool1_BOM_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tool1_Close
            // 
            this.tool1_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Close.Image = global::UniqueDeclaration.Properties.Resources.close_24px;
            this.tool1_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Close.Name = "tool1_Close";
            this.tool1_Close.Size = new System.Drawing.Size(23, 22);
            this.tool1_Close.Text = "关闭";
            this.tool1_Close.Click += new System.EventHandler(this.tool1_Close_Click);
            // 
            // myTabControl1
            // 
            this.myTabControl1.Controls.Add(this.tabPage1);
            this.myTabControl1.Controls.Add(this.tabPage2);
            this.myTabControl1.Controls.Add(this.tabPage3);
            this.myTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControl1.Location = new System.Drawing.Point(0, 25);
            this.myTabControl1.Name = "myTabControl1";
            this.myTabControl1.SelectedIndex = 0;
            this.myTabControl1.Size = new System.Drawing.Size(706, 435);
            this.myTabControl1.TabIndex = 2;
            this.myTabControl1.SelectedIndexChanged += new System.EventHandler(this.myTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(698, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "料件及配件组成";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteFit);
            this.groupBox2.Controls.Add(this.myDataGridViewFit);
            this.groupBox2.Location = new System.Drawing.Point(8, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 175);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配件组成";
            // 
            // btnDeleteFit
            // 
            this.btnDeleteFit.Location = new System.Drawing.Point(582, 152);
            this.btnDeleteFit.Name = "btnDeleteFit";
            this.btnDeleteFit.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFit.TabIndex = 1;
            this.btnDeleteFit.Text = "删除";
            this.btnDeleteFit.UseVisualStyleBackColor = true;
            this.btnDeleteFit.Click += new System.EventHandler(this.btnDeleteFit_Click);
            // 
            // myDataGridViewFit
            // 
            this.myDataGridViewFit.AllowUserToAddRows = false;
            this.myDataGridViewFit.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridViewFit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridViewFit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridViewFit.Location = new System.Drawing.Point(7, 21);
            this.myDataGridViewFit.MultiSelect = false;
            this.myDataGridViewFit.Name = "myDataGridViewFit";
            this.myDataGridViewFit.RowTemplate.Height = 23;
            this.myDataGridViewFit.Size = new System.Drawing.Size(668, 129);
            this.myDataGridViewFit.TabIndex = 0;
            this.myDataGridViewFit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridViewFit_CellContentClick);
            this.myDataGridViewFit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridViewFit_CellEndEdit);
            this.myDataGridViewFit.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.myDataGridViewFit_DataError);
            this.myDataGridViewFit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myDataGridViewFit_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteMaterials);
            this.groupBox1.Controls.Add(this.myDataGridViewMaterials);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "料件组成";
            // 
            // btnDeleteMaterials
            // 
            this.btnDeleteMaterials.Location = new System.Drawing.Point(581, 195);
            this.btnDeleteMaterials.Name = "btnDeleteMaterials";
            this.btnDeleteMaterials.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMaterials.TabIndex = 1;
            this.btnDeleteMaterials.Text = "删除";
            this.btnDeleteMaterials.UseVisualStyleBackColor = true;
            this.btnDeleteMaterials.Click += new System.EventHandler(this.btnDeleteMaterials_Click);
            // 
            // myDataGridViewMaterials
            // 
            this.myDataGridViewMaterials.AllowUserToAddRows = false;
            this.myDataGridViewMaterials.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridViewMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridViewMaterials.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridViewMaterials.Location = new System.Drawing.Point(7, 21);
            this.myDataGridViewMaterials.MultiSelect = false;
            this.myDataGridViewMaterials.Name = "myDataGridViewMaterials";
            this.myDataGridViewMaterials.RowTemplate.Height = 23;
            this.myDataGridViewMaterials.Size = new System.Drawing.Size(668, 173);
            this.myDataGridViewMaterials.TabIndex = 0;
            this.myDataGridViewMaterials.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridViewMaterials_CellEndEdit);
            this.myDataGridViewMaterials.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.myDataGridViewMaterials_DataError);
            this.myDataGridViewMaterials.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myDataGridViewMaterials_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(698, 409);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "料件组成明细";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_明细备注);
            this.groupBox3.Controls.Add(this.myLable1);
            this.groupBox3.Controls.Add(this.myDataGridViewMaterialsDetails);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(681, 395);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "料件明细";
            // 
            // txt_明细备注
            // 
            this.txt_明细备注.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_明细备注.Location = new System.Drawing.Point(75, 331);
            this.txt_明细备注.Multiline = true;
            this.txt_明细备注.Name = "txt_明细备注";
            this.txt_明细备注.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_明细备注.Size = new System.Drawing.Size(600, 58);
            this.txt_明细备注.TabIndex = 2;
            // 
            // myLable1
            // 
            this.myLable1.Location = new System.Drawing.Point(6, 330);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(69, 23);
            this.myLable1.TabIndex = 1;
            this.myLable1.Text = "明细备注：";
            this.myLable1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myDataGridViewMaterialsDetails
            // 
            this.myDataGridViewMaterialsDetails.AllowUserToAddRows = false;
            this.myDataGridViewMaterialsDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridViewMaterialsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridViewMaterialsDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridViewMaterialsDetails.Location = new System.Drawing.Point(7, 21);
            this.myDataGridViewMaterialsDetails.MultiSelect = false;
            this.myDataGridViewMaterialsDetails.Name = "myDataGridViewMaterialsDetails";
            this.myDataGridViewMaterialsDetails.RowTemplate.Height = 23;
            this.myDataGridViewMaterialsDetails.Size = new System.Drawing.Size(668, 306);
            this.myDataGridViewMaterialsDetails.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(698, 409);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "报关材料组成";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_实际总重);
            this.groupBox4.Controls.Add(this.btnDeleteDeclarationMaterialsDetails);
            this.groupBox4.Controls.Add(this.myLable2);
            this.groupBox4.Controls.Add(this.myDataGridViewDeclarationMaterialsDetails);
            this.groupBox4.Location = new System.Drawing.Point(9, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(681, 395);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "报关料件明细";
            // 
            // txt_实际总重
            // 
            this.txt_实际总重.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_实际总重.Location = new System.Drawing.Point(409, 364);
            this.txt_实际总重.Name = "txt_实际总重";
            this.txt_实际总重.Size = new System.Drawing.Size(100, 21);
            this.txt_实际总重.TabIndex = 3;
            // 
            // btnDeleteDeclarationMaterialsDetails
            // 
            this.btnDeleteDeclarationMaterialsDetails.Location = new System.Drawing.Point(591, 363);
            this.btnDeleteDeclarationMaterialsDetails.Name = "btnDeleteDeclarationMaterialsDetails";
            this.btnDeleteDeclarationMaterialsDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDeclarationMaterialsDetails.TabIndex = 2;
            this.btnDeleteDeclarationMaterialsDetails.Text = "删除";
            this.btnDeleteDeclarationMaterialsDetails.UseVisualStyleBackColor = true;
            this.btnDeleteDeclarationMaterialsDetails.Click += new System.EventHandler(this.btnDeleteDeclarationMaterialsDetails_Click);
            // 
            // myLable2
            // 
            this.myLable2.Location = new System.Drawing.Point(330, 364);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(81, 19);
            this.myLable2.TabIndex = 1;
            this.myLable2.Text = "实际总重：";
            this.myLable2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myDataGridViewDeclarationMaterialsDetails
            // 
            this.myDataGridViewDeclarationMaterialsDetails.AllowUserToAddRows = false;
            this.myDataGridViewDeclarationMaterialsDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridViewDeclarationMaterialsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridViewDeclarationMaterialsDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridViewDeclarationMaterialsDetails.Location = new System.Drawing.Point(7, 21);
            this.myDataGridViewDeclarationMaterialsDetails.MultiSelect = false;
            this.myDataGridViewDeclarationMaterialsDetails.Name = "myDataGridViewDeclarationMaterialsDetails";
            this.myDataGridViewDeclarationMaterialsDetails.ReadOnly = true;
            this.myDataGridViewDeclarationMaterialsDetails.RowTemplate.Height = 23;
            this.myDataGridViewDeclarationMaterialsDetails.Size = new System.Drawing.Size(668, 336);
            this.myDataGridViewDeclarationMaterialsDetails.TabIndex = 0;
            this.myDataGridViewDeclarationMaterialsDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridViewDeclarationMaterialsDetails_CellEndEdit);
            this.myDataGridViewDeclarationMaterialsDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.myDataGridViewDeclarationMaterialsDetails_DataError);
            this.myDataGridViewDeclarationMaterialsDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myDataGridViewDeclarationMaterialsDetails_KeyPress);
            // 
            // FormFitBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(706, 460);
            this.Controls.Add(this.myTabControl1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormFitBOM";
            this.Text = "结构组成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFitBOM_FormClosing);
            this.Load += new System.EventHandler(this.FormFitBOM_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.myTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewFit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewMaterials)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewMaterialsDetails)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewDeclarationMaterialsDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool1_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tool1_Close;
        private UniqueDeclarationBaseForm.Controls.myTabControl myTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridViewMaterials;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private UniqueDeclarationBaseForm.Controls.myButton btnDeleteMaterials;
        private System.Windows.Forms.GroupBox groupBox2;
        private UniqueDeclarationBaseForm.Controls.myButton btnDeleteFit;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridViewFit;
        private System.Windows.Forms.GroupBox groupBox3;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_明细备注;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridViewMaterialsDetails;
        private System.Windows.Forms.GroupBox groupBox4;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_实际总重;
        private UniqueDeclarationBaseForm.Controls.myButton btnDeleteDeclarationMaterialsDetails;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridViewDeclarationMaterialsDetails;
        private System.Windows.Forms.ToolStripButton tool1_BOM;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
