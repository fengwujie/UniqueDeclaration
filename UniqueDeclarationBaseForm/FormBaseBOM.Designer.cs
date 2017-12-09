namespace UniqueDeclarationBaseForm
{
    partial class FormBaseBOM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_Import = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_ExportExcel = new System.Windows.Forms.ToolStripButton();
            this.tool_Close = new System.Windows.Forms.ToolStripButton();
            this.myTabControl1 = new UniqueDeclarationBaseForm.Controls.myTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_ModifyBefore = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_ModifyAfterHead = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnModifyHeadDelete = new UniqueDeclarationBaseForm.Controls.myButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_ModifyAfterDetail = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnModifyDetailDelete = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_总重 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_实际总重 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv_MergerAfterHead = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.dgv_MergerAfterDetail = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myContextModifyBefore = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextModifyAfterHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextModifyAfterDetail = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextMergerAfterHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextMergerAfterDetail = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.toolStrip1.SuspendLayout();
            this.myTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyBefore)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyAfterHead)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyAfterDetail)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MergerAfterHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MergerAfterDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_Save,
            this.toolStripSeparator1,
            this.tool_Import,
            this.toolStripSeparator2,
            this.tool_ExportExcel,
            this.tool_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1567, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_Save
            // 
            this.tool_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_Save.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Save_24pxt;
            this.tool_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_Save.Name = "tool_Save";
            this.tool_Save.Size = new System.Drawing.Size(24, 24);
            this.tool_Save.Text = "保存";
            this.tool_Save.Click += new System.EventHandler(this.tool_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tool_Import
            // 
            this.tool_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_Import.Image = global::UniqueDeclarationBaseForm.Properties.Resources.shopping_webshop_24px;
            this.tool_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_Import.Name = "tool_Import";
            this.tool_Import.Size = new System.Drawing.Size(24, 24);
            this.tool_Import.Text = "导入";
            this.tool_Import.Click += new System.EventHandler(this.tool_Import_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tool_ExportExcel
            // 
            this.tool_ExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_ExportExcel.Image = global::UniqueDeclarationBaseForm.Properties.Resources.Excel_2013_24px;
            this.tool_ExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_ExportExcel.Name = "tool_ExportExcel";
            this.tool_ExportExcel.Size = new System.Drawing.Size(24, 24);
            this.tool_ExportExcel.Text = "toolStripButton1";
            this.tool_ExportExcel.Visible = false;
            this.tool_ExportExcel.Click += new System.EventHandler(this.tool_ExportExcel_Click);
            // 
            // tool_Close
            // 
            this.tool_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_Close.Image = global::UniqueDeclarationBaseForm.Properties.Resources.close_24px;
            this.tool_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_Close.Name = "tool_Close";
            this.tool_Close.Size = new System.Drawing.Size(24, 24);
            this.tool_Close.Text = "关闭";
            this.tool_Close.Click += new System.EventHandler(this.tool_Close_Click);
            // 
            // myTabControl1
            // 
            this.myTabControl1.Controls.Add(this.tabPage1);
            this.myTabControl1.Controls.Add(this.tabPage2);
            this.myTabControl1.Controls.Add(this.tabPage3);
            this.myTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControl1.Location = new System.Drawing.Point(0, 27);
            this.myTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.myTabControl1.Name = "myTabControl1";
            this.myTabControl1.SelectedIndex = 0;
            this.myTabControl1.Size = new System.Drawing.Size(1567, 676);
            this.myTabControl1.TabIndex = 1;
            this.myTabControl1.SelectedIndexChanged += new System.EventHandler(this.myTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1559, 647);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "改样前组成";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_ModifyBefore);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1551, 639);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "料件组成";
            // 
            // dgv_ModifyBefore
            // 
            this.dgv_ModifyBefore.AllowUserToAddRows = false;
            this.dgv_ModifyBefore.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ModifyBefore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ModifyBefore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ModifyBefore.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ModifyBefore.Location = new System.Drawing.Point(4, 22);
            this.dgv_ModifyBefore.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_ModifyBefore.MultiSelect = false;
            this.dgv_ModifyBefore.Name = "dgv_ModifyBefore";
            this.dgv_ModifyBefore.RowTemplate.Height = 23;
            this.dgv_ModifyBefore.Size = new System.Drawing.Size(1543, 613);
            this.dgv_ModifyBefore.TabIndex = 0;
            this.dgv_ModifyBefore.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ModifyBefore_CellEndEdit);
            this.dgv_ModifyBefore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_ModifyBefore_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1559, 647);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "改样后组成";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1551, 639);
            this.splitContainer1.SplitterDistance = 346;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1551, 346);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "料件组成";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_ModifyAfterHead);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1543, 279);
            this.panel1.TabIndex = 3;
            // 
            // dgv_ModifyAfterHead
            // 
            this.dgv_ModifyAfterHead.AllowUserToAddRows = false;
            this.dgv_ModifyAfterHead.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ModifyAfterHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ModifyAfterHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ModifyAfterHead.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ModifyAfterHead.Location = new System.Drawing.Point(0, 0);
            this.dgv_ModifyAfterHead.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_ModifyAfterHead.MultiSelect = false;
            this.dgv_ModifyAfterHead.Name = "dgv_ModifyAfterHead";
            this.dgv_ModifyAfterHead.RowTemplate.Height = 23;
            this.dgv_ModifyAfterHead.Size = new System.Drawing.Size(1543, 279);
            this.dgv_ModifyAfterHead.TabIndex = 2;
            this.dgv_ModifyAfterHead.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ModifyAfterHead_CellEndEdit);
            this.dgv_ModifyAfterHead.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_ModifyAfterHead_CellValidating);
            this.dgv_ModifyAfterHead.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_ModifyAfterHead_DataError);
            this.dgv_ModifyAfterHead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_ModifyAfterHead_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.Controls.Add(this.btnModifyHeadDelete, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 301);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1543, 41);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnModifyHeadDelete
            // 
            this.btnModifyHeadDelete.Location = new System.Drawing.Point(1396, 4);
            this.btnModifyHeadDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnModifyHeadDelete.Name = "btnModifyHeadDelete";
            this.btnModifyHeadDelete.Size = new System.Drawing.Size(100, 33);
            this.btnModifyHeadDelete.TabIndex = 1;
            this.btnModifyHeadDelete.Text = "删除";
            this.btnModifyHeadDelete.UseVisualStyleBackColor = true;
            this.btnModifyHeadDelete.Click += new System.EventHandler(this.btnModifyHeadDelete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1551, 288);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "报关料件明细";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_ModifyAfterDetail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1543, 222);
            this.panel3.TabIndex = 9;
            // 
            // dgv_ModifyAfterDetail
            // 
            this.dgv_ModifyAfterDetail.AllowUserToAddRows = false;
            this.dgv_ModifyAfterDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ModifyAfterDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ModifyAfterDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ModifyAfterDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ModifyAfterDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_ModifyAfterDetail.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_ModifyAfterDetail.MultiSelect = false;
            this.dgv_ModifyAfterDetail.Name = "dgv_ModifyAfterDetail";
            this.dgv_ModifyAfterDetail.RowTemplate.Height = 23;
            this.dgv_ModifyAfterDetail.Size = new System.Drawing.Size(1543, 222);
            this.dgv_ModifyAfterDetail.TabIndex = 3;
            this.dgv_ModifyAfterDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ModifyAfterDetail_CellEndEdit);
            this.dgv_ModifyAfterDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_ModifyAfterDetail_DataError);
            this.dgv_ModifyAfterDetail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_ModifyAfterDetail_KeyPress);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel2.Controls.Add(this.btnModifyDetailDelete, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.myLable1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_总重, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_实际总重, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.myLable2, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 244);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1543, 40);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // btnModifyDetailDelete
            // 
            this.btnModifyDetailDelete.Location = new System.Drawing.Point(1396, 4);
            this.btnModifyDetailDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnModifyDetailDelete.Name = "btnModifyDetailDelete";
            this.btnModifyDetailDelete.Size = new System.Drawing.Size(100, 32);
            this.btnModifyDetailDelete.TabIndex = 4;
            this.btnModifyDetailDelete.Text = "删除";
            this.btnModifyDetailDelete.UseVisualStyleBackColor = true;
            this.btnModifyDetailDelete.Click += new System.EventHandler(this.btnModifyDetailDelete_Click);
            // 
            // myLable1
            // 
            this.myLable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLable1.Location = new System.Drawing.Point(485, 0);
            this.myLable1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(92, 40);
            this.myLable1.TabIndex = 5;
            this.myLable1.Text = "实际总重：";
            this.myLable1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_总重
            // 
            this.txt_总重.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_总重.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_总重.Location = new System.Drawing.Point(795, 4);
            this.txt_总重.Margin = new System.Windows.Forms.Padding(4);
            this.txt_总重.Name = "txt_总重";
            this.txt_总重.ReadOnly = true;
            this.txt_总重.Size = new System.Drawing.Size(112, 25);
            this.txt_总重.TabIndex = 8;
            // 
            // txt_实际总重
            // 
            this.txt_实际总重.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_实际总重.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_实际总重.Location = new System.Drawing.Point(585, 4);
            this.txt_实际总重.Margin = new System.Windows.Forms.Padding(4);
            this.txt_实际总重.Name = "txt_实际总重";
            this.txt_实际总重.ReadOnly = true;
            this.txt_实际总重.Size = new System.Drawing.Size(112, 25);
            this.txt_实际总重.TabIndex = 6;
            // 
            // myLable2
            // 
            this.myLable2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLable2.Location = new System.Drawing.Point(725, 0);
            this.myLable2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(62, 40);
            this.myLable2.TabIndex = 7;
            this.myLable2.Text = "总重：";
            this.myLable2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1559, 647);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "归并后组成";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.splitContainer2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1559, 647);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "料件组成";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(4, 22);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv_MergerAfterHead);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_MergerAfterDetail);
            this.splitContainer2.Size = new System.Drawing.Size(1551, 621);
            this.splitContainer2.SplitterDistance = 331;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgv_MergerAfterHead
            // 
            this.dgv_MergerAfterHead.AllowUserToAddRows = false;
            this.dgv_MergerAfterHead.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_MergerAfterHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MergerAfterHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_MergerAfterHead.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_MergerAfterHead.Location = new System.Drawing.Point(0, 0);
            this.dgv_MergerAfterHead.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_MergerAfterHead.MultiSelect = false;
            this.dgv_MergerAfterHead.Name = "dgv_MergerAfterHead";
            this.dgv_MergerAfterHead.RowTemplate.Height = 23;
            this.dgv_MergerAfterHead.Size = new System.Drawing.Size(1551, 331);
            this.dgv_MergerAfterHead.TabIndex = 0;
            this.dgv_MergerAfterHead.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MergerAfterHead_CellEndEdit);
            this.dgv_MergerAfterHead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_MergerAfterHead_KeyPress);
            // 
            // dgv_MergerAfterDetail
            // 
            this.dgv_MergerAfterDetail.AllowUserToAddRows = false;
            this.dgv_MergerAfterDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_MergerAfterDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MergerAfterDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_MergerAfterDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_MergerAfterDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_MergerAfterDetail.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_MergerAfterDetail.MultiSelect = false;
            this.dgv_MergerAfterDetail.Name = "dgv_MergerAfterDetail";
            this.dgv_MergerAfterDetail.RowTemplate.Height = 23;
            this.dgv_MergerAfterDetail.Size = new System.Drawing.Size(1551, 285);
            this.dgv_MergerAfterDetail.TabIndex = 0;
            // 
            // myContextModifyBefore
            // 
            this.myContextModifyBefore.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.myContextModifyBefore.MyDataGridView = this.dgv_ModifyBefore;
            this.myContextModifyBefore.Name = "myContextModifyBefore";
            this.myContextModifyBefore.Size = new System.Drawing.Size(115, 30);
            // 
            // myContextModifyAfterHead
            // 
            this.myContextModifyAfterHead.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.myContextModifyAfterHead.MyDataGridView = this.dgv_ModifyAfterHead;
            this.myContextModifyAfterHead.Name = "myContextMenuStripCell1";
            this.myContextModifyAfterHead.Size = new System.Drawing.Size(115, 30);
            // 
            // myContextModifyAfterDetail
            // 
            this.myContextModifyAfterDetail.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.myContextModifyAfterDetail.MyDataGridView = this.dgv_ModifyAfterDetail;
            this.myContextModifyAfterDetail.Name = "myContextMenuStripCell1";
            this.myContextModifyAfterDetail.Size = new System.Drawing.Size(115, 30);
            // 
            // myContextMergerAfterHead
            // 
            this.myContextMergerAfterHead.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.myContextMergerAfterHead.MyDataGridView = this.dgv_MergerAfterHead;
            this.myContextMergerAfterHead.Name = "myContextMenuStripCell1";
            this.myContextMergerAfterHead.Size = new System.Drawing.Size(115, 30);
            // 
            // myContextMergerAfterDetail
            // 
            this.myContextMergerAfterDetail.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.myContextMergerAfterDetail.MyDataGridView = this.dgv_MergerAfterDetail;
            this.myContextMergerAfterDetail.Name = "myContextMenuStripCell1";
            this.myContextMergerAfterDetail.Size = new System.Drawing.Size(115, 30);
            // 
            // FormBaseBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1567, 703);
            this.Controls.Add(this.myTabControl1);
            this.Controls.Add(this.toolStrip1);
            this.IsScaling = false;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormBaseBOM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBaseBOM";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.myTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyBefore)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyAfterHead)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyAfterDetail)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MergerAfterHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MergerAfterDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tool_Save;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tool_Import;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton tool_Close;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.TabPage tabPage3;
        public Controls.myTabControl myTabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public Controls.myDataGridView dgv_ModifyBefore;
        public Controls.myDataGridView dgv_ModifyAfterHead;
        public Controls.myButton btnModifyHeadDelete;
        public Controls.myButton btnModifyDetailDelete;
        public Controls.myTextBox txt_总重;
        public Controls.myTextBox txt_实际总重;
        public Controls.myDataGridView dgv_MergerAfterHead;
        public Controls.myDataGridView dgv_MergerAfterDetail;
        public Controls.myDataGridView dgv_ModifyAfterDetail;
        public Controls.myContextMenuStripCell myContextModifyBefore;
        public Controls.myContextMenuStripCell myContextModifyAfterHead;
        public Controls.myContextMenuStripCell myContextModifyAfterDetail;
        public Controls.myContextMenuStripCell myContextMergerAfterHead;
        public Controls.myContextMenuStripCell myContextMergerAfterDetail;
        public Controls.myLable myLable2;
        public Controls.myLable myLable1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ToolStripButton tool_ExportExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}