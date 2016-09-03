namespace UniqueDeclaration
{
    partial class FormOrderInput
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
            this.lab_订单号码 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_流水号 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_客户代码 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_客户名称 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_电子帐册号 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_出货日期 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_录入日期 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_订单号码 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_流水号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_客户代码 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_客户名称 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.cbox_电子帐册号 = new UniqueDeclarationBaseForm.Controls.myComboBox();
            this.date_出货日期 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_录入日期 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_录入日期);
            this.groupBox1.Controls.Add(this.date_出货日期);
            this.groupBox1.Controls.Add(this.cbox_电子帐册号);
            this.groupBox1.Controls.Add(this.txt_客户名称);
            this.groupBox1.Controls.Add(this.txt_客户代码);
            this.groupBox1.Controls.Add(this.txt_流水号);
            this.groupBox1.Controls.Add(this.txt_订单号码);
            this.groupBox1.Controls.Add(this.lab_录入日期);
            this.groupBox1.Controls.Add(this.lab_出货日期);
            this.groupBox1.Controls.Add(this.lab_电子帐册号);
            this.groupBox1.Controls.Add(this.lab_客户名称);
            this.groupBox1.Controls.Add(this.lab_客户代码);
            this.groupBox1.Controls.Add(this.lab_流水号);
            this.groupBox1.Controls.Add(this.lab_订单号码);
            this.groupBox1.Size = new System.Drawing.Size(919, 90);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 115);
            this.groupBox2.Size = new System.Drawing.Size(919, 325);
            // 
            // lab_订单号码
            // 
            this.lab_订单号码.AutoSize = true;
            this.lab_订单号码.Location = new System.Drawing.Point(36, 24);
            this.lab_订单号码.Name = "lab_订单号码";
            this.lab_订单号码.Size = new System.Drawing.Size(65, 12);
            this.lab_订单号码.TabIndex = 28;
            this.lab_订单号码.Text = "订单号码：";
            // 
            // lab_流水号
            // 
            this.lab_流水号.AutoSize = true;
            this.lab_流水号.Location = new System.Drawing.Point(262, 24);
            this.lab_流水号.Name = "lab_流水号";
            this.lab_流水号.Size = new System.Drawing.Size(65, 12);
            this.lab_流水号.TabIndex = 29;
            this.lab_流水号.Text = "流 水 号：";
            // 
            // lab_客户代码
            // 
            this.lab_客户代码.AutoSize = true;
            this.lab_客户代码.Location = new System.Drawing.Point(488, 24);
            this.lab_客户代码.Name = "lab_客户代码";
            this.lab_客户代码.Size = new System.Drawing.Size(65, 12);
            this.lab_客户代码.TabIndex = 30;
            this.lab_客户代码.Text = "客户代码：";
            // 
            // lab_客户名称
            // 
            this.lab_客户名称.AutoSize = true;
            this.lab_客户名称.Location = new System.Drawing.Point(714, 24);
            this.lab_客户名称.Name = "lab_客户名称";
            this.lab_客户名称.Size = new System.Drawing.Size(65, 12);
            this.lab_客户名称.TabIndex = 31;
            this.lab_客户名称.Text = "客户名称：";
            // 
            // lab_电子帐册号
            // 
            this.lab_电子帐册号.AutoSize = true;
            this.lab_电子帐册号.Location = new System.Drawing.Point(24, 59);
            this.lab_电子帐册号.Name = "lab_电子帐册号";
            this.lab_电子帐册号.Size = new System.Drawing.Size(77, 12);
            this.lab_电子帐册号.TabIndex = 32;
            this.lab_电子帐册号.Text = "电子帐册号：";
            // 
            // lab_出货日期
            // 
            this.lab_出货日期.AutoSize = true;
            this.lab_出货日期.Location = new System.Drawing.Point(262, 59);
            this.lab_出货日期.Name = "lab_出货日期";
            this.lab_出货日期.Size = new System.Drawing.Size(65, 12);
            this.lab_出货日期.TabIndex = 33;
            this.lab_出货日期.Text = "出货日期：";
            // 
            // lab_录入日期
            // 
            this.lab_录入日期.AutoSize = true;
            this.lab_录入日期.Location = new System.Drawing.Point(488, 59);
            this.lab_录入日期.Name = "lab_录入日期";
            this.lab_录入日期.Size = new System.Drawing.Size(65, 12);
            this.lab_录入日期.TabIndex = 34;
            this.lab_录入日期.Text = "录入日期：";
            // 
            // txt_订单号码
            // 
            this.txt_订单号码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_订单号码.Location = new System.Drawing.Point(98, 20);
            this.txt_订单号码.Name = "txt_订单号码";
            this.txt_订单号码.Size = new System.Drawing.Size(119, 21);
            this.txt_订单号码.TabIndex = 35;
            this.txt_订单号码.Validated += new System.EventHandler(this.txt_订单号码_Validated);
            // 
            // txt_流水号
            // 
            this.txt_流水号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_流水号.Location = new System.Drawing.Point(324, 20);
            this.txt_流水号.Name = "txt_流水号";
            this.txt_流水号.Size = new System.Drawing.Size(119, 21);
            this.txt_流水号.TabIndex = 36;
            this.txt_流水号.Validating += new System.ComponentModel.CancelEventHandler(this.txt_流水号_Validating);
            this.txt_流水号.Validated += new System.EventHandler(this.txt_流水号_Validated);
            // 
            // txt_客户代码
            // 
            this.txt_客户代码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_客户代码.Location = new System.Drawing.Point(550, 20);
            this.txt_客户代码.Name = "txt_客户代码";
            this.txt_客户代码.Size = new System.Drawing.Size(119, 21);
            this.txt_客户代码.TabIndex = 37;
            this.txt_客户代码.Validating += new System.ComponentModel.CancelEventHandler(this.txt_客户代码_Validating);
            this.txt_客户代码.Validated += new System.EventHandler(this.txt_客户代码_Validated);
            // 
            // txt_客户名称
            // 
            this.txt_客户名称.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_客户名称.Location = new System.Drawing.Point(774, 20);
            this.txt_客户名称.Name = "txt_客户名称";
            this.txt_客户名称.Size = new System.Drawing.Size(119, 21);
            this.txt_客户名称.TabIndex = 38;
            this.txt_客户名称.Validated += new System.EventHandler(this.txt_客户名称_Validated);
            // 
            // cbox_电子帐册号
            // 
            this.cbox_电子帐册号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_电子帐册号.FormattingEnabled = true;
            this.cbox_电子帐册号.Location = new System.Drawing.Point(98, 55);
            this.cbox_电子帐册号.Name = "cbox_电子帐册号";
            this.cbox_电子帐册号.Size = new System.Drawing.Size(119, 20);
            this.cbox_电子帐册号.TabIndex = 39;
            this.cbox_电子帐册号.SelectedIndexChanged += new System.EventHandler(this.cbox_电子帐册号_SelectedIndexChanged);
            // 
            // date_出货日期
            // 
            this.date_出货日期.Location = new System.Drawing.Point(324, 55);
            this.date_出货日期.Name = "date_出货日期";
            this.date_出货日期.Size = new System.Drawing.Size(119, 21);
            this.date_出货日期.TabIndex = 40;
            this.date_出货日期.ValueChanged += new System.EventHandler(this.date_出货日期_ValueChanged);
            // 
            // date_录入日期
            // 
            this.date_录入日期.Location = new System.Drawing.Point(550, 55);
            this.date_录入日期.Name = "date_录入日期";
            this.date_录入日期.Size = new System.Drawing.Size(119, 21);
            this.date_录入日期.TabIndex = 41;
            this.date_录入日期.ValueChanged += new System.EventHandler(this.date_录入日期_ValueChanged);
            // 
            // FormOrderInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(919, 440);
            this.Name = "FormOrderInput";
            this.Text = "预先订单录入";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myLable lab_录入日期;
        private UniqueDeclarationBaseForm.Controls.myLable lab_出货日期;
        private UniqueDeclarationBaseForm.Controls.myLable lab_电子帐册号;
        private UniqueDeclarationBaseForm.Controls.myLable lab_客户名称;
        private UniqueDeclarationBaseForm.Controls.myLable lab_客户代码;
        private UniqueDeclarationBaseForm.Controls.myLable lab_流水号;
        private UniqueDeclarationBaseForm.Controls.myLable lab_订单号码;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_客户名称;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_客户代码;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_流水号;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_订单号码;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_录入日期;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出货日期;
        private UniqueDeclarationBaseForm.Controls.myComboBox cbox_电子帐册号;
    }
}
