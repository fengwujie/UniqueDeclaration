namespace UniqueDeclaration.Base
{
    partial class FormManualInput
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
            this.myTabControl1 = new UniqueDeclarationBaseForm.Controls.myTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool1_Add = new System.Windows.Forms.ToolStripButton();
            this.tool1_Save = new System.Windows.Forms.ToolStripButton();
            this.tool1_Close = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_手册编号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_进出口岸一 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_经营单位 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable3 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_贸易方式 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable4 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable5 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_有效期限 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.myLable6 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_收货单位 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable7 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_起抵地 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable8 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_重点标志 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable9 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.myTabControl1.Size = new System.Drawing.Size(772, 555);
            this.myTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_重点标志);
            this.tabPage1.Controls.Add(this.myLable9);
            this.tabPage1.Controls.Add(this.txt_起抵地);
            this.tabPage1.Controls.Add(this.myLable8);
            this.tabPage1.Controls.Add(this.txt_收货单位);
            this.tabPage1.Controls.Add(this.myLable7);
            this.tabPage1.Controls.Add(this.myLable6);
            this.tabPage1.Controls.Add(this.txt_有效期限);
            this.tabPage1.Controls.Add(this.myLable5);
            this.tabPage1.Controls.Add(this.txt_贸易方式);
            this.tabPage1.Controls.Add(this.myLable4);
            this.tabPage1.Controls.Add(this.txt_经营单位);
            this.tabPage1.Controls.Add(this.myLable3);
            this.tabPage1.Controls.Add(this.txt_进出口岸一);
            this.tabPage1.Controls.Add(this.myLable2);
            this.tabPage1.Controls.Add(this.txt_手册编号);
            this.tabPage1.Controls.Add(this.myLable1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(764, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "手册资料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(911, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "出口成品";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool1_Add,
            this.tool1_Save,
            this.tool1_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(772, 25);
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
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(911, 529);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "进口料件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // myLable1
            // 
            this.myLable1.AutoSize = true;
            this.myLable1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myLable1.Location = new System.Drawing.Point(35, 24);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(70, 12);
            this.myLable1.TabIndex = 0;
            this.myLable1.Text = "手册编号：";
            // 
            // txt_手册编号
            // 
            this.txt_手册编号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_手册编号.Location = new System.Drawing.Point(111, 20);
            this.txt_手册编号.Name = "txt_手册编号";
            this.txt_手册编号.Size = new System.Drawing.Size(253, 21);
            this.txt_手册编号.TabIndex = 1;
            // 
            // txt_进出口岸一
            // 
            this.txt_进出口岸一.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_进出口岸一.Location = new System.Drawing.Point(492, 20);
            this.txt_进出口岸一.Name = "txt_进出口岸一";
            this.txt_进出口岸一.Size = new System.Drawing.Size(216, 21);
            this.txt_进出口岸一.TabIndex = 3;
            // 
            // myLable2
            // 
            this.myLable2.AutoSize = true;
            this.myLable2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myLable2.Location = new System.Drawing.Point(403, 24);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(83, 12);
            this.myLable2.TabIndex = 2;
            this.myLable2.Text = "进出口岸一：";
            // 
            // txt_经营单位
            // 
            this.txt_经营单位.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_经营单位.Location = new System.Drawing.Point(97, 66);
            this.txt_经营单位.Name = "txt_经营单位";
            this.txt_经营单位.Size = new System.Drawing.Size(183, 21);
            this.txt_经营单位.TabIndex = 5;
            // 
            // myLable3
            // 
            this.myLable3.AutoSize = true;
            this.myLable3.Location = new System.Drawing.Point(35, 66);
            this.myLable3.Name = "myLable3";
            this.myLable3.Size = new System.Drawing.Size(65, 12);
            this.myLable3.TabIndex = 4;
            this.myLable3.Text = "经营单位：";
            // 
            // txt_贸易方式
            // 
            this.txt_贸易方式.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_贸易方式.Location = new System.Drawing.Point(365, 66);
            this.txt_贸易方式.Name = "txt_贸易方式";
            this.txt_贸易方式.Size = new System.Drawing.Size(99, 21);
            this.txt_贸易方式.TabIndex = 7;
            // 
            // myLable4
            // 
            this.myLable4.AutoSize = true;
            this.myLable4.Location = new System.Drawing.Point(299, 69);
            this.myLable4.Name = "myLable4";
            this.myLable4.Size = new System.Drawing.Size(65, 12);
            this.myLable4.TabIndex = 6;
            this.myLable4.Text = "贸易方式：";
            // 
            // myLable5
            // 
            this.myLable5.AutoSize = true;
            this.myLable5.Location = new System.Drawing.Point(510, 84);
            this.myLable5.Name = "myLable5";
            this.myLable5.Size = new System.Drawing.Size(65, 12);
            this.myLable5.TabIndex = 8;
            this.myLable5.Text = "贸易方式：";
            // 
            // txt_有效期限
            // 
            this.txt_有效期限.Location = new System.Drawing.Point(573, 84);
            this.txt_有效期限.Name = "txt_有效期限";
            this.txt_有效期限.Size = new System.Drawing.Size(107, 21);
            this.txt_有效期限.TabIndex = 9;
            // 
            // myLable6
            // 
            this.myLable6.AutoSize = true;
            this.myLable6.Location = new System.Drawing.Point(686, 90);
            this.myLable6.Name = "myLable6";
            this.myLable6.Size = new System.Drawing.Size(17, 12);
            this.myLable6.TabIndex = 10;
            this.myLable6.Text = "止";
            // 
            // txt_收货单位
            // 
            this.txt_收货单位.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_收货单位.Location = new System.Drawing.Point(97, 102);
            this.txt_收货单位.Name = "txt_收货单位";
            this.txt_收货单位.Size = new System.Drawing.Size(183, 21);
            this.txt_收货单位.TabIndex = 12;
            // 
            // myLable7
            // 
            this.myLable7.AutoSize = true;
            this.myLable7.Location = new System.Drawing.Point(35, 102);
            this.myLable7.Name = "myLable7";
            this.myLable7.Size = new System.Drawing.Size(65, 12);
            this.myLable7.TabIndex = 11;
            this.myLable7.Text = "收货单位：";
            // 
            // txt_起抵地
            // 
            this.txt_起抵地.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_起抵地.Location = new System.Drawing.Point(338, 102);
            this.txt_起抵地.Name = "txt_起抵地";
            this.txt_起抵地.Size = new System.Drawing.Size(183, 21);
            this.txt_起抵地.TabIndex = 14;
            // 
            // myLable8
            // 
            this.myLable8.AutoSize = true;
            this.myLable8.Location = new System.Drawing.Point(288, 102);
            this.myLable8.Name = "myLable8";
            this.myLable8.Size = new System.Drawing.Size(53, 12);
            this.myLable8.TabIndex = 13;
            this.myLable8.Text = "起抵地：";
            // 
            // txt_重点标志
            // 
            this.txt_重点标志.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_重点标志.Location = new System.Drawing.Point(596, 111);
            this.txt_重点标志.Name = "txt_重点标志";
            this.txt_重点标志.Size = new System.Drawing.Size(107, 21);
            this.txt_重点标志.TabIndex = 16;
            // 
            // myLable9
            // 
            this.myLable9.AutoSize = true;
            this.myLable9.Location = new System.Drawing.Point(535, 111);
            this.myLable9.Name = "myLable9";
            this.myLable9.Size = new System.Drawing.Size(65, 12);
            this.myLable9.TabIndex = 15;
            this.myLable9.Text = "重点标志：";
            // 
            // FormManualInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(772, 580);
            this.Controls.Add(this.myTabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormManualInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手册资料录入";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManualInput_FormClosing);
            this.Load += new System.EventHandler(this.FormManualInput_Load);
            this.myTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myTabControl myTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool1_Add;
        private System.Windows.Forms.ToolStripButton tool1_Save;
        private System.Windows.Forms.ToolStripButton tool1_Close;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_重点标志;
        private UniqueDeclarationBaseForm.Controls.myLable myLable9;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_起抵地;
        private UniqueDeclarationBaseForm.Controls.myLable myLable8;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_收货单位;
        private UniqueDeclarationBaseForm.Controls.myLable myLable7;
        private UniqueDeclarationBaseForm.Controls.myLable myLable6;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker txt_有效期限;
        private UniqueDeclarationBaseForm.Controls.myLable myLable5;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_贸易方式;
        private UniqueDeclarationBaseForm.Controls.myLable myLable4;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_经营单位;
        private UniqueDeclarationBaseForm.Controls.myLable myLable3;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_进出口岸一;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_手册编号;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
    }
}
