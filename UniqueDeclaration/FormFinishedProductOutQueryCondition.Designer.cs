namespace UniqueDeclaration
{
    partial class FormFinishedProductOutQueryCondition
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
            this.myLable5 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_订单号码 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable7 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_客户代码 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable8 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.date_录入日期2 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_录入日期1 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_出货日期2 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_出货日期1 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.myLable3 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable4 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_手册编号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_手册编号);
            this.groupBox1.Controls.Add(this.date_录入日期2);
            this.groupBox1.Controls.Add(this.date_录入日期1);
            this.groupBox1.Controls.Add(this.date_出货日期2);
            this.groupBox1.Controls.Add(this.date_出货日期1);
            this.groupBox1.Controls.Add(this.myLable3);
            this.groupBox1.Controls.Add(this.myLable4);
            this.groupBox1.Controls.Add(this.myLable2);
            this.groupBox1.Controls.Add(this.myLable1);
            this.groupBox1.Controls.Add(this.txt_客户代码);
            this.groupBox1.Controls.Add(this.myLable8);
            this.groupBox1.Controls.Add(this.myLable7);
            this.groupBox1.Controls.Add(this.txt_订单号码);
            this.groupBox1.Controls.Add(this.myLable5);
            this.groupBox1.Size = new System.Drawing.Size(232, 262);
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.Location = new System.Drawing.Point(262, 111);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(257, 22);
            this.btnOK.Size = new System.Drawing.Size(77, 26);
            this.btnOK.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(257, 67);
            this.btnCancel.Size = new System.Drawing.Size(77, 26);
            this.btnCancel.TabIndex = 2;
            // 
            // myLable5
            // 
            this.myLable5.AutoSize = true;
            this.myLable5.Location = new System.Drawing.Point(33, 33);
            this.myLable5.Name = "myLable5";
            this.myLable5.Size = new System.Drawing.Size(53, 12);
            this.myLable5.TabIndex = 12;
            this.myLable5.Text = "订单号：";
            // 
            // txt_订单号码
            // 
            this.txt_订单号码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_订单号码.Location = new System.Drawing.Point(83, 29);
            this.txt_订单号码.Name = "txt_订单号码";
            this.txt_订单号码.Size = new System.Drawing.Size(119, 21);
            this.txt_订单号码.TabIndex = 0;
            this.txt_订单号码.Tag = "订单号码";
            // 
            // myLable7
            // 
            this.myLable7.AutoSize = true;
            this.myLable7.Location = new System.Drawing.Point(9, 64);
            this.myLable7.Name = "myLable7";
            this.myLable7.Size = new System.Drawing.Size(77, 12);
            this.myLable7.TabIndex = 16;
            this.myLable7.Text = "电子帐册号：";
            // 
            // txt_客户代码
            // 
            this.txt_客户代码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_客户代码.Location = new System.Drawing.Point(83, 91);
            this.txt_客户代码.Name = "txt_客户代码";
            this.txt_客户代码.Size = new System.Drawing.Size(119, 21);
            this.txt_客户代码.TabIndex = 2;
            this.txt_客户代码.Tag = "客户代码";
            // 
            // myLable8
            // 
            this.myLable8.AutoSize = true;
            this.myLable8.Location = new System.Drawing.Point(21, 95);
            this.myLable8.Name = "myLable8";
            this.myLable8.Size = new System.Drawing.Size(65, 12);
            this.myLable8.TabIndex = 18;
            this.myLable8.Text = "客户代码：";
            // 
            // date_录入日期2
            // 
            this.date_录入日期2.Checked = false;
            this.date_录入日期2.CustomFormat = "yyyy-MM-dd";
            this.date_录入日期2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_录入日期2.Location = new System.Drawing.Point(83, 219);
            this.date_录入日期2.Name = "date_录入日期2";
            this.date_录入日期2.ShowCheckBox = true;
            this.date_录入日期2.Size = new System.Drawing.Size(119, 21);
            this.date_录入日期2.TabIndex = 6;
            this.date_录入日期2.Tag = "2,录入日期";
            // 
            // date_录入日期1
            // 
            this.date_录入日期1.Checked = false;
            this.date_录入日期1.CustomFormat = "yyyy-MM-dd";
            this.date_录入日期1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_录入日期1.Location = new System.Drawing.Point(83, 187);
            this.date_录入日期1.Name = "date_录入日期1";
            this.date_录入日期1.ShowCheckBox = true;
            this.date_录入日期1.Size = new System.Drawing.Size(119, 21);
            this.date_录入日期1.TabIndex = 5;
            this.date_录入日期1.Tag = "1,录入日期";
            // 
            // date_出货日期2
            // 
            this.date_出货日期2.Checked = false;
            this.date_出货日期2.CustomFormat = "yyyy-MM-dd";
            this.date_出货日期2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_出货日期2.Location = new System.Drawing.Point(83, 155);
            this.date_出货日期2.Name = "date_出货日期2";
            this.date_出货日期2.ShowCheckBox = true;
            this.date_出货日期2.Size = new System.Drawing.Size(119, 21);
            this.date_出货日期2.TabIndex = 4;
            this.date_出货日期2.Tag = "2,出货日期";
            // 
            // date_出货日期1
            // 
            this.date_出货日期1.Checked = false;
            this.date_出货日期1.CustomFormat = "yyyy-MM-dd";
            this.date_出货日期1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_出货日期1.Location = new System.Drawing.Point(83, 123);
            this.date_出货日期1.Name = "date_出货日期1";
            this.date_出货日期1.ShowCheckBox = true;
            this.date_出货日期1.Size = new System.Drawing.Size(119, 21);
            this.date_出货日期1.TabIndex = 3;
            this.date_出货日期1.Tag = "1,出货日期";
            // 
            // myLable3
            // 
            this.myLable3.AutoSize = true;
            this.myLable3.Location = new System.Drawing.Point(57, 223);
            this.myLable3.Name = "myLable3";
            this.myLable3.Size = new System.Drawing.Size(29, 12);
            this.myLable3.TabIndex = 37;
            this.myLable3.Text = "到：";
            // 
            // myLable4
            // 
            this.myLable4.AutoSize = true;
            this.myLable4.Location = new System.Drawing.Point(21, 191);
            this.myLable4.Name = "myLable4";
            this.myLable4.Size = new System.Drawing.Size(65, 12);
            this.myLable4.TabIndex = 36;
            this.myLable4.Text = "录入日期：";
            // 
            // myLable2
            // 
            this.myLable2.AutoSize = true;
            this.myLable2.Location = new System.Drawing.Point(57, 159);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(29, 12);
            this.myLable2.TabIndex = 35;
            this.myLable2.Text = "到：";
            // 
            // myLable1
            // 
            this.myLable1.AutoSize = true;
            this.myLable1.Location = new System.Drawing.Point(21, 127);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(65, 12);
            this.myLable1.TabIndex = 34;
            this.myLable1.Text = "出货日期：";
            // 
            // txt_手册编号
            // 
            this.txt_手册编号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_手册编号.Location = new System.Drawing.Point(83, 61);
            this.txt_手册编号.Name = "txt_手册编号";
            this.txt_手册编号.Size = new System.Drawing.Size(119, 21);
            this.txt_手册编号.TabIndex = 1;
            this.txt_手册编号.Tag = "手册编号";
            // 
            // FormFinishedProductOutQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(347, 287);
            this.Name = "FormFinishedProductOutQueryCondition";
            this.Text = "【成品出货】查询条件";
            this.Load += new System.EventHandler(this.FormFinishedProductOutQueryCondition_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myLable myLable5;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_客户代码;
        private UniqueDeclarationBaseForm.Controls.myLable myLable8;
        private UniqueDeclarationBaseForm.Controls.myLable myLable7;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_订单号码;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_录入日期2;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_录入日期1;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出货日期2;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出货日期1;
        private UniqueDeclarationBaseForm.Controls.myLable myLable3;
        private UniqueDeclarationBaseForm.Controls.myLable myLable4;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_手册编号;
    }
}
