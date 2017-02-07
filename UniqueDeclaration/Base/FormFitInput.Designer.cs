namespace UniqueDeclaration.Base
{
    partial class FormFitInput
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
            this.tool1_Add = new System.Windows.Forms.ToolStripButton();
            this.tool1_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClone = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_BOM = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datetime_配件建档日期 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.myLable9 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_配件备注 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable8 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_配件存放位置 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable7 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_实际总重 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable6 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_配件组别 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_配件名 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable4 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_配件型号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_配件型号 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_电子帐册编号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_编号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_配件组别 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool1_Add,
            this.tool1_Save,
            this.toolStripSeparator2,
            this.btnClone,
            this.toolStripSeparator1,
            this.tool1_BOM,
            this.toolStripSeparator3,
            this.tool1_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(445, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool1_Add
            // 
            this.tool1_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Add.Image = global::UniqueDeclaration.Properties.Resources.Add_24px;
            this.tool1_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Add.Name = "tool1_Add";
            this.tool1_Add.Size = new System.Drawing.Size(23, 22);
            this.tool1_Add.Text = "新增";
            this.tool1_Add.Click += new System.EventHandler(this.tool1_Add_Click);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClone
            // 
            this.btnClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClone.Image = global::UniqueDeclaration.Properties.Resources.copy_24px;
            this.btnClone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(23, 22);
            this.btnClone.Text = "克隆";
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
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
            this.tool1_BOM.Text = "配件组成";
            this.tool1_BOM.Click += new System.EventHandler(this.tool1_BOM_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_配件组别);
            this.groupBox1.Controls.Add(this.datetime_配件建档日期);
            this.groupBox1.Controls.Add(this.myLable9);
            this.groupBox1.Controls.Add(this.txt_配件备注);
            this.groupBox1.Controls.Add(this.myLable8);
            this.groupBox1.Controls.Add(this.txt_配件存放位置);
            this.groupBox1.Controls.Add(this.myLable7);
            this.groupBox1.Controls.Add(this.txt_实际总重);
            this.groupBox1.Controls.Add(this.myLable6);
            this.groupBox1.Controls.Add(this.lab_配件组别);
            this.groupBox1.Controls.Add(this.txt_配件名);
            this.groupBox1.Controls.Add(this.myLable4);
            this.groupBox1.Controls.Add(this.txt_配件型号);
            this.groupBox1.Controls.Add(this.lab_配件型号);
            this.groupBox1.Controls.Add(this.txt_电子帐册编号);
            this.groupBox1.Controls.Add(this.myLable2);
            this.groupBox1.Controls.Add(this.txt_编号);
            this.groupBox1.Controls.Add(this.myLable1);
            this.groupBox1.Location = new System.Drawing.Point(13, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 283);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配件资料";
            // 
            // datetime_配件建档日期
            // 
            this.datetime_配件建档日期.Checked = false;
            this.datetime_配件建档日期.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.datetime_配件建档日期.Enabled = false;
            this.datetime_配件建档日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_配件建档日期.Location = new System.Drawing.Point(71, 244);
            this.datetime_配件建档日期.Name = "datetime_配件建档日期";
            this.datetime_配件建档日期.Size = new System.Drawing.Size(175, 21);
            this.datetime_配件建档日期.TabIndex = 19;
            // 
            // myLable9
            // 
            this.myLable9.Location = new System.Drawing.Point(6, 244);
            this.myLable9.Name = "myLable9";
            this.myLable9.Size = new System.Drawing.Size(68, 16);
            this.myLable9.TabIndex = 17;
            this.myLable9.Text = "建档时间：";
            this.myLable9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_配件备注
            // 
            this.txt_配件备注.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_配件备注.Location = new System.Drawing.Point(71, 208);
            this.txt_配件备注.Name = "txt_配件备注";
            this.txt_配件备注.Size = new System.Drawing.Size(317, 21);
            this.txt_配件备注.TabIndex = 16;
            // 
            // myLable8
            // 
            this.myLable8.Location = new System.Drawing.Point(6, 208);
            this.myLable8.Name = "myLable8";
            this.myLable8.Size = new System.Drawing.Size(68, 16);
            this.myLable8.TabIndex = 15;
            this.myLable8.Text = "备注：";
            this.myLable8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_配件存放位置
            // 
            this.txt_配件存放位置.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_配件存放位置.Location = new System.Drawing.Point(71, 172);
            this.txt_配件存放位置.Name = "txt_配件存放位置";
            this.txt_配件存放位置.Size = new System.Drawing.Size(317, 21);
            this.txt_配件存放位置.TabIndex = 14;
            // 
            // myLable7
            // 
            this.myLable7.Location = new System.Drawing.Point(6, 172);
            this.myLable7.Name = "myLable7";
            this.myLable7.Size = new System.Drawing.Size(68, 16);
            this.myLable7.TabIndex = 13;
            this.myLable7.Text = "存放位置：";
            this.myLable7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_实际总重
            // 
            this.txt_实际总重.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_实际总重.Location = new System.Drawing.Point(275, 136);
            this.txt_实际总重.Name = "txt_实际总重";
            this.txt_实际总重.Size = new System.Drawing.Size(113, 21);
            this.txt_实际总重.TabIndex = 12;
            // 
            // myLable6
            // 
            this.myLable6.Location = new System.Drawing.Point(177, 137);
            this.myLable6.Name = "myLable6";
            this.myLable6.Size = new System.Drawing.Size(102, 16);
            this.myLable6.TabIndex = 11;
            this.myLable6.Text = "实际总重：";
            this.myLable6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_配件组别
            // 
            this.lab_配件组别.Location = new System.Drawing.Point(6, 135);
            this.lab_配件组别.Name = "lab_配件组别";
            this.lab_配件组别.Size = new System.Drawing.Size(68, 16);
            this.lab_配件组别.TabIndex = 8;
            this.lab_配件组别.Text = "组别：";
            this.lab_配件组别.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_配件名
            // 
            this.txt_配件名.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_配件名.Location = new System.Drawing.Point(71, 96);
            this.txt_配件名.Name = "txt_配件名";
            this.txt_配件名.Size = new System.Drawing.Size(317, 21);
            this.txt_配件名.TabIndex = 7;
            // 
            // myLable4
            // 
            this.myLable4.Location = new System.Drawing.Point(6, 96);
            this.myLable4.Name = "myLable4";
            this.myLable4.Size = new System.Drawing.Size(68, 16);
            this.myLable4.TabIndex = 6;
            this.myLable4.Text = "配件名：";
            this.myLable4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_配件型号
            // 
            this.txt_配件型号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_配件型号.Location = new System.Drawing.Point(71, 57);
            this.txt_配件型号.Name = "txt_配件型号";
            this.txt_配件型号.Size = new System.Drawing.Size(317, 21);
            this.txt_配件型号.TabIndex = 5;
            // 
            // lab_配件型号
            // 
            this.lab_配件型号.Location = new System.Drawing.Point(6, 57);
            this.lab_配件型号.Name = "lab_配件型号";
            this.lab_配件型号.Size = new System.Drawing.Size(68, 16);
            this.lab_配件型号.TabIndex = 4;
            this.lab_配件型号.Text = "型号：";
            this.lab_配件型号.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_电子帐册编号
            // 
            this.txt_电子帐册编号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_电子帐册编号.Location = new System.Drawing.Point(275, 20);
            this.txt_电子帐册编号.Name = "txt_电子帐册编号";
            this.txt_电子帐册编号.Size = new System.Drawing.Size(113, 21);
            this.txt_电子帐册编号.TabIndex = 3;
            // 
            // myLable2
            // 
            this.myLable2.Location = new System.Drawing.Point(177, 21);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(102, 16);
            this.myLable2.TabIndex = 2;
            this.myLable2.Text = "电子帐册编号：";
            this.myLable2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_编号
            // 
            this.txt_编号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_编号.Location = new System.Drawing.Point(71, 21);
            this.txt_编号.Name = "txt_编号";
            this.txt_编号.Size = new System.Drawing.Size(100, 21);
            this.txt_编号.TabIndex = 1;
            // 
            // myLable1
            // 
            this.myLable1.Location = new System.Drawing.Point(6, 21);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(68, 16);
            this.myLable1.TabIndex = 0;
            this.myLable1.Text = "编号：";
            this.myLable1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_配件组别
            // 
            this.txt_配件组别.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_配件组别.Location = new System.Drawing.Point(71, 134);
            this.txt_配件组别.Name = "txt_配件组别";
            this.txt_配件组别.Size = new System.Drawing.Size(113, 21);
            this.txt_配件组别.TabIndex = 20;
            // 
            // FormFitInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(445, 332);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormFitInput";
            this.Text = "配件资料录入";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFitInput_FormClosing);
            this.Load += new System.EventHandler(this.FormFitInput_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool1_Add;
        private System.Windows.Forms.ToolStripButton tool1_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tool1_BOM;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tool1_Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker datetime_配件建档日期;
        private UniqueDeclarationBaseForm.Controls.myLable myLable9;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_配件备注;
        private UniqueDeclarationBaseForm.Controls.myLable myLable8;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_配件存放位置;
        private UniqueDeclarationBaseForm.Controls.myLable myLable7;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_实际总重;
        private UniqueDeclarationBaseForm.Controls.myLable myLable6;
        private UniqueDeclarationBaseForm.Controls.myLable lab_配件组别;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_配件名;
        private UniqueDeclarationBaseForm.Controls.myLable myLable4;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_配件型号;
        private UniqueDeclarationBaseForm.Controls.myLable lab_配件型号;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_电子帐册编号;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_编号;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_配件组别;
    }
}
