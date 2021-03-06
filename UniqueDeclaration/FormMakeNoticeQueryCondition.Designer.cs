﻿namespace UniqueDeclaration
{
    partial class FormMakeNoticeQueryCondition
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
            this.myLable6 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_制造通知单号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_客户代码 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.date_录入日期2 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_录入日期1 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_出货日期2 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_出货日期1 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.myLable3 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable4 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_录入日期2);
            this.groupBox1.Controls.Add(this.date_录入日期1);
            this.groupBox1.Controls.Add(this.date_出货日期2);
            this.groupBox1.Controls.Add(this.date_出货日期1);
            this.groupBox1.Controls.Add(this.myLable3);
            this.groupBox1.Controls.Add(this.myLable4);
            this.groupBox1.Controls.Add(this.myLable2);
            this.groupBox1.Controls.Add(this.myLable1);
            this.groupBox1.Controls.Add(this.txt_客户代码);
            this.groupBox1.Controls.Add(this.txt_制造通知单号);
            this.groupBox1.Controls.Add(this.myLable6);
            this.groupBox1.Controls.Add(this.myLable5);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Size = new System.Drawing.Size(240, 218);
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.Location = new System.Drawing.Point(273, 92);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(266, 18);
            this.btnOK.Size = new System.Drawing.Size(79, 22);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(266, 56);
            this.btnCancel.Size = new System.Drawing.Size(79, 22);
            // 
            // myLable5
            // 
            this.myLable5.AutoSize = true;
            this.myLable5.Location = new System.Drawing.Point(16, 37);
            this.myLable5.Name = "myLable5";
            this.myLable5.Size = new System.Drawing.Size(89, 12);
            this.myLable5.TabIndex = 12;
            this.myLable5.Text = "制造通知单号：";
            // 
            // myLable6
            // 
            this.myLable6.AutoSize = true;
            this.myLable6.Location = new System.Drawing.Point(40, 67);
            this.myLable6.Name = "myLable6";
            this.myLable6.Size = new System.Drawing.Size(65, 12);
            this.myLable6.TabIndex = 13;
            this.myLable6.Text = "客户代码：";
            // 
            // txt_制造通知单号
            // 
            this.txt_制造通知单号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_制造通知单号.Location = new System.Drawing.Point(103, 33);
            this.txt_制造通知单号.Name = "txt_制造通知单号";
            this.txt_制造通知单号.Size = new System.Drawing.Size(112, 21);
            this.txt_制造通知单号.TabIndex = 14;
            this.txt_制造通知单号.Tag = "报关制造通知单表.制造通知单号";
            // 
            // txt_客户代码
            // 
            this.txt_客户代码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_客户代码.Location = new System.Drawing.Point(103, 63);
            this.txt_客户代码.Name = "txt_客户代码";
            this.txt_客户代码.Size = new System.Drawing.Size(112, 21);
            this.txt_客户代码.TabIndex = 15;
            this.txt_客户代码.Tag = "报关制造通知单表.客户代码";
            // 
            // date_录入日期2
            // 
            this.date_录入日期2.Checked = false;
            this.date_录入日期2.CustomFormat = "yyyy-MM-dd";
            this.date_录入日期2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_录入日期2.Location = new System.Drawing.Point(103, 188);
            this.date_录入日期2.Name = "date_录入日期2";
            this.date_录入日期2.ShowCheckBox = true;
            this.date_录入日期2.Size = new System.Drawing.Size(113, 21);
            this.date_录入日期2.TabIndex = 33;
            this.date_录入日期2.Tag = "2,报关制造通知单表.录入日期";
            // 
            // date_录入日期1
            // 
            this.date_录入日期1.Checked = false;
            this.date_录入日期1.CustomFormat = "yyyy-MM-dd";
            this.date_录入日期1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_录入日期1.Location = new System.Drawing.Point(103, 157);
            this.date_录入日期1.Name = "date_录入日期1";
            this.date_录入日期1.ShowCheckBox = true;
            this.date_录入日期1.Size = new System.Drawing.Size(113, 21);
            this.date_录入日期1.TabIndex = 32;
            this.date_录入日期1.Tag = "1,报关制造通知单表.录入日期";
            // 
            // date_出货日期2
            // 
            this.date_出货日期2.Checked = false;
            this.date_出货日期2.CustomFormat = "yyyy-MM-dd";
            this.date_出货日期2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_出货日期2.Location = new System.Drawing.Point(103, 126);
            this.date_出货日期2.Name = "date_出货日期2";
            this.date_出货日期2.ShowCheckBox = true;
            this.date_出货日期2.Size = new System.Drawing.Size(113, 21);
            this.date_出货日期2.TabIndex = 31;
            this.date_出货日期2.Tag = "2,报关制造通知单表.出货日期";
            // 
            // date_出货日期1
            // 
            this.date_出货日期1.Checked = false;
            this.date_出货日期1.CustomFormat = "yyyy-MM-dd";
            this.date_出货日期1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_出货日期1.Location = new System.Drawing.Point(103, 95);
            this.date_出货日期1.Name = "date_出货日期1";
            this.date_出货日期1.ShowCheckBox = true;
            this.date_出货日期1.Size = new System.Drawing.Size(113, 21);
            this.date_出货日期1.TabIndex = 30;
            this.date_出货日期1.Tag = "1,报关制造通知单表.出货日期";
            // 
            // myLable3
            // 
            this.myLable3.AutoSize = true;
            this.myLable3.Location = new System.Drawing.Point(76, 192);
            this.myLable3.Name = "myLable3";
            this.myLable3.Size = new System.Drawing.Size(29, 12);
            this.myLable3.TabIndex = 29;
            this.myLable3.Text = "到：";
            // 
            // myLable4
            // 
            this.myLable4.AutoSize = true;
            this.myLable4.Location = new System.Drawing.Point(40, 161);
            this.myLable4.Name = "myLable4";
            this.myLable4.Size = new System.Drawing.Size(65, 12);
            this.myLable4.TabIndex = 28;
            this.myLable4.Text = "录入日期：";
            // 
            // myLable2
            // 
            this.myLable2.AutoSize = true;
            this.myLable2.Location = new System.Drawing.Point(76, 130);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(29, 12);
            this.myLable2.TabIndex = 27;
            this.myLable2.Text = "到：";
            // 
            // myLable1
            // 
            this.myLable1.AutoSize = true;
            this.myLable1.Location = new System.Drawing.Point(40, 99);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(65, 12);
            this.myLable1.TabIndex = 26;
            this.myLable1.Text = "出货日期：";
            // 
            // FormMakeNoticeQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(359, 235);
            this.Name = "FormMakeNoticeQueryCondition";
            this.Text = "【制造通知单】查询条件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myTextBox txt_客户代码;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_制造通知单号;
        private UniqueDeclarationBaseForm.Controls.myLable myLable6;
        private UniqueDeclarationBaseForm.Controls.myLable myLable5;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_录入日期2;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_录入日期1;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出货日期2;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出货日期1;
        private UniqueDeclarationBaseForm.Controls.myLable myLable3;
        private UniqueDeclarationBaseForm.Controls.myLable myLable4;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
    }
}
