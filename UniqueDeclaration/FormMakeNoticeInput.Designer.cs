﻿namespace UniqueDeclaration
{
    partial class FormMakeNoticeInput
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
            this.date_录入日期 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_出货日期 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.cbox_电子帐册号 = new UniqueDeclarationBaseForm.Controls.myComboBox();
            this.txt_客户名称 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_客户代码 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_总单号码 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_制造通知单号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_录入日期 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_出货日期 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_电子帐册号 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_客户名称 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_客户代码 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_总单号码 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.lab_制造通知单号 = new UniqueDeclarationBaseForm.Controls.myLable();
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
            this.groupBox1.Controls.Add(this.txt_总单号码);
            this.groupBox1.Controls.Add(this.txt_制造通知单号);
            this.groupBox1.Controls.Add(this.lab_录入日期);
            this.groupBox1.Controls.Add(this.lab_出货日期);
            this.groupBox1.Controls.Add(this.lab_电子帐册号);
            this.groupBox1.Controls.Add(this.lab_客户名称);
            this.groupBox1.Controls.Add(this.lab_客户代码);
            this.groupBox1.Controls.Add(this.lab_总单号码);
            this.groupBox1.Controls.Add(this.lab_制造通知单号);
            this.groupBox1.Size = new System.Drawing.Size(919, 91);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 116);
            this.groupBox2.Size = new System.Drawing.Size(919, 324);
            // 
            // date_录入日期
            // 
            this.date_录入日期.Location = new System.Drawing.Point(551, 55);
            this.date_录入日期.Name = "date_录入日期";
            this.date_录入日期.Size = new System.Drawing.Size(119, 21);
            this.date_录入日期.TabIndex = 55;
            this.date_录入日期.ValueChanged += new System.EventHandler(this.date_录入日期_ValueChanged);
            // 
            // date_出货日期
            // 
            this.date_出货日期.Location = new System.Drawing.Point(325, 55);
            this.date_出货日期.Name = "date_出货日期";
            this.date_出货日期.Size = new System.Drawing.Size(119, 21);
            this.date_出货日期.TabIndex = 54;
            this.date_出货日期.ValueChanged += new System.EventHandler(this.date_出货日期_ValueChanged);
            // 
            // cbox_电子帐册号
            // 
            this.cbox_电子帐册号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_电子帐册号.FormattingEnabled = true;
            this.cbox_电子帐册号.Location = new System.Drawing.Point(99, 55);
            this.cbox_电子帐册号.Name = "cbox_电子帐册号";
            this.cbox_电子帐册号.Size = new System.Drawing.Size(119, 20);
            this.cbox_电子帐册号.TabIndex = 53;
            this.cbox_电子帐册号.SelectedIndexChanged += new System.EventHandler(this.cbox_电子帐册号_SelectedIndexChanged);
            // 
            // txt_客户名称
            // 
            this.txt_客户名称.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_客户名称.Location = new System.Drawing.Point(775, 20);
            this.txt_客户名称.Name = "txt_客户名称";
            this.txt_客户名称.Size = new System.Drawing.Size(119, 21);
            this.txt_客户名称.TabIndex = 52;
            this.txt_客户名称.Validated += new System.EventHandler(this.txt_客户名称_Validated);
            // 
            // txt_客户代码
            // 
            this.txt_客户代码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_客户代码.Location = new System.Drawing.Point(551, 20);
            this.txt_客户代码.Name = "txt_客户代码";
            this.txt_客户代码.Size = new System.Drawing.Size(119, 21);
            this.txt_客户代码.TabIndex = 51;
            this.txt_客户代码.Validating += new System.ComponentModel.CancelEventHandler(this.txt_客户代码_Validating);
            this.txt_客户代码.Validated += new System.EventHandler(this.txt_客户代码_Validated);
            // 
            // txt_总单号码
            // 
            this.txt_总单号码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_总单号码.Location = new System.Drawing.Point(325, 20);
            this.txt_总单号码.Name = "txt_总单号码";
            this.txt_总单号码.Size = new System.Drawing.Size(119, 21);
            this.txt_总单号码.TabIndex = 50;
            this.txt_总单号码.Validated += new System.EventHandler(this.txt_总单号码_Validated);
            // 
            // txt_制造通知单号
            // 
            this.txt_制造通知单号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_制造通知单号.Location = new System.Drawing.Point(99, 20);
            this.txt_制造通知单号.Name = "txt_制造通知单号";
            this.txt_制造通知单号.Size = new System.Drawing.Size(119, 21);
            this.txt_制造通知单号.TabIndex = 49;
            this.txt_制造通知单号.Validating += new System.ComponentModel.CancelEventHandler(this.txt_制造通知单号_Validating);
            this.txt_制造通知单号.Validated += new System.EventHandler(this.txt_制造通知单号_Validated);
            // 
            // lab_录入日期
            // 
            this.lab_录入日期.AutoSize = true;
            this.lab_录入日期.Location = new System.Drawing.Point(489, 59);
            this.lab_录入日期.Name = "lab_录入日期";
            this.lab_录入日期.Size = new System.Drawing.Size(65, 12);
            this.lab_录入日期.TabIndex = 48;
            this.lab_录入日期.Text = "录入日期：";
            // 
            // lab_出货日期
            // 
            this.lab_出货日期.AutoSize = true;
            this.lab_出货日期.Location = new System.Drawing.Point(263, 59);
            this.lab_出货日期.Name = "lab_出货日期";
            this.lab_出货日期.Size = new System.Drawing.Size(65, 12);
            this.lab_出货日期.TabIndex = 47;
            this.lab_出货日期.Text = "出货日期：";
            // 
            // lab_电子帐册号
            // 
            this.lab_电子帐册号.AutoSize = true;
            this.lab_电子帐册号.Location = new System.Drawing.Point(25, 59);
            this.lab_电子帐册号.Name = "lab_电子帐册号";
            this.lab_电子帐册号.Size = new System.Drawing.Size(77, 12);
            this.lab_电子帐册号.TabIndex = 46;
            this.lab_电子帐册号.Text = "电子帐册号：";
            // 
            // lab_客户名称
            // 
            this.lab_客户名称.AutoSize = true;
            this.lab_客户名称.Location = new System.Drawing.Point(715, 24);
            this.lab_客户名称.Name = "lab_客户名称";
            this.lab_客户名称.Size = new System.Drawing.Size(65, 12);
            this.lab_客户名称.TabIndex = 45;
            this.lab_客户名称.Text = "客户名称：";
            // 
            // lab_客户代码
            // 
            this.lab_客户代码.AutoSize = true;
            this.lab_客户代码.Location = new System.Drawing.Point(489, 24);
            this.lab_客户代码.Name = "lab_客户代码";
            this.lab_客户代码.Size = new System.Drawing.Size(65, 12);
            this.lab_客户代码.TabIndex = 44;
            this.lab_客户代码.Text = "客户代码：";
            // 
            // lab_总单号码
            // 
            this.lab_总单号码.AutoSize = true;
            this.lab_总单号码.Location = new System.Drawing.Point(251, 23);
            this.lab_总单号码.Name = "lab_总单号码";
            this.lab_总单号码.Size = new System.Drawing.Size(77, 12);
            this.lab_总单号码.TabIndex = 43;
            this.lab_总单号码.Text = "客人订单号：";
            // 
            // lab_制造通知单号
            // 
            this.lab_制造通知单号.AutoSize = true;
            this.lab_制造通知单号.Location = new System.Drawing.Point(12, 23);
            this.lab_制造通知单号.Name = "lab_制造通知单号";
            this.lab_制造通知单号.Size = new System.Drawing.Size(89, 12);
            this.lab_制造通知单号.TabIndex = 42;
            this.lab_制造通知单号.Text = "制造通知单号：";
            // 
            // FormMakeNoticeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(919, 440);
            this.Name = "FormMakeNoticeInput";
            this.Text = "制造通知单录入";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_录入日期;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出货日期;
        private UniqueDeclarationBaseForm.Controls.myComboBox cbox_电子帐册号;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_客户名称;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_客户代码;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_总单号码;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_制造通知单号;
        private UniqueDeclarationBaseForm.Controls.myLable lab_录入日期;
        private UniqueDeclarationBaseForm.Controls.myLable lab_出货日期;
        private UniqueDeclarationBaseForm.Controls.myLable lab_电子帐册号;
        private UniqueDeclarationBaseForm.Controls.myLable lab_客户名称;
        private UniqueDeclarationBaseForm.Controls.myLable lab_客户代码;
        private UniqueDeclarationBaseForm.Controls.myLable lab_总单号码;
        private UniqueDeclarationBaseForm.Controls.myLable lab_制造通知单号;
    }
}
