namespace UniqueDeclaration
{
    partial class FormMaterialsJXCQueryCondition
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
            this.txt_料号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable7 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.datetime_入库时间2 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.datetime_入库时间1 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.myLable5 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable4 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.cbox_电子帐册号 = new UniqueDeclarationBaseForm.Controls.myComboBox();
            this.myLable3 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txt_料号);
            this.groupBox1.Controls.Add(this.myLable7);
            this.groupBox1.Controls.Add(this.datetime_入库时间2);
            this.groupBox1.Controls.Add(this.datetime_入库时间1);
            this.groupBox1.Controls.Add(this.myLable5);
            this.groupBox1.Controls.Add(this.myLable4);
            this.groupBox1.Controls.Add(this.cbox_电子帐册号);
            this.groupBox1.Controls.Add(this.myLable3);
            this.groupBox1.Location = new System.Drawing.Point(17, 13);
            this.groupBox1.Size = new System.Drawing.Size(299, 256);
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.Location = new System.Drawing.Point(357, 108);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(330, 22);
            this.btnOK.Size = new System.Drawing.Size(99, 26);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(330, 66);
            this.btnCancel.Size = new System.Drawing.Size(99, 26);
            // 
            // txt_料号
            // 
            this.txt_料号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_料号.Location = new System.Drawing.Point(92, 33);
            this.txt_料号.Name = "txt_料号";
            this.txt_料号.Size = new System.Drawing.Size(173, 21);
            this.txt_料号.TabIndex = 25;
            this.txt_料号.Tag = "发票号";
            // 
            // myLable7
            // 
            this.myLable7.AutoSize = true;
            this.myLable7.Location = new System.Drawing.Point(54, 37);
            this.myLable7.Name = "myLable7";
            this.myLable7.Size = new System.Drawing.Size(41, 12);
            this.myLable7.TabIndex = 32;
            this.myLable7.Text = "料号：";
            // 
            // datetime_入库时间2
            // 
            this.datetime_入库时间2.Checked = false;
            this.datetime_入库时间2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.datetime_入库时间2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_入库时间2.Location = new System.Drawing.Point(92, 143);
            this.datetime_入库时间2.Name = "datetime_入库时间2";
            this.datetime_入库时间2.ShowCheckBox = true;
            this.datetime_入库时间2.Size = new System.Drawing.Size(173, 21);
            this.datetime_入库时间2.TabIndex = 28;
            this.datetime_入库时间2.Tag = "2,入库时间";
            // 
            // datetime_入库时间1
            // 
            this.datetime_入库时间1.Checked = false;
            this.datetime_入库时间1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.datetime_入库时间1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_入库时间1.Location = new System.Drawing.Point(92, 106);
            this.datetime_入库时间1.Name = "datetime_入库时间1";
            this.datetime_入库时间1.ShowCheckBox = true;
            this.datetime_入库时间1.Size = new System.Drawing.Size(173, 21);
            this.datetime_入库时间1.TabIndex = 27;
            this.datetime_入库时间1.Tag = "1,入库时间";
            // 
            // myLable5
            // 
            this.myLable5.AutoSize = true;
            this.myLable5.Location = new System.Drawing.Point(66, 147);
            this.myLable5.Name = "myLable5";
            this.myLable5.Size = new System.Drawing.Size(29, 12);
            this.myLable5.TabIndex = 31;
            this.myLable5.Text = "到：";
            // 
            // myLable4
            // 
            this.myLable4.AutoSize = true;
            this.myLable4.Location = new System.Drawing.Point(18, 110);
            this.myLable4.Name = "myLable4";
            this.myLable4.Size = new System.Drawing.Size(77, 12);
            this.myLable4.TabIndex = 30;
            this.myLable4.Text = "查询时间从：";
            // 
            // cbox_电子帐册号
            // 
            this.cbox_电子帐册号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_电子帐册号.FormattingEnabled = true;
            this.cbox_电子帐册号.Location = new System.Drawing.Point(92, 70);
            this.cbox_电子帐册号.Name = "cbox_电子帐册号";
            this.cbox_电子帐册号.Size = new System.Drawing.Size(173, 20);
            this.cbox_电子帐册号.TabIndex = 26;
            this.cbox_电子帐册号.Tag = "string,电子帐册号";
            // 
            // myLable3
            // 
            this.myLable3.AutoSize = true;
            this.myLable3.Location = new System.Drawing.Point(18, 74);
            this.myLable3.Name = "myLable3";
            this.myLable3.Size = new System.Drawing.Size(77, 12);
            this.myLable3.TabIndex = 29;
            this.myLable3.Tag = "";
            this.myLable3.Text = "电子帐册号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(6, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 44);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(200, 22);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "归并后";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(119, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "归并前";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "归并前明细";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // FormMaterialsJXCQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(448, 280);
            this.Name = "FormMaterialsJXCQueryCondition";
            this.Text = "【料件进销存】查询条件";
            this.Load += new System.EventHandler(this.FormMaterialsJXCQueryCondition_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_料号;
        private UniqueDeclarationBaseForm.Controls.myLable myLable7;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker datetime_入库时间2;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker datetime_入库时间1;
        private UniqueDeclarationBaseForm.Controls.myLable myLable5;
        private UniqueDeclarationBaseForm.Controls.myLable myLable4;
        private UniqueDeclarationBaseForm.Controls.myComboBox cbox_电子帐册号;
        private UniqueDeclarationBaseForm.Controls.myLable myLable3;
    }
}
