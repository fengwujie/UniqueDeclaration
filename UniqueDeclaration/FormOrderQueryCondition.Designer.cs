namespace UniqueDeclaration
{
    partial class FormOrderQueryCondition
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
            this.txt_流水号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable6 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_客户代码 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable7 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_客户代码);
            this.groupBox1.Controls.Add(this.myLable7);
            this.groupBox1.Controls.Add(this.txt_流水号);
            this.groupBox1.Controls.Add(this.myLable6);
            this.groupBox1.Controls.Add(this.txt_订单号码);
            this.groupBox1.Controls.Add(this.myLable5);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Size = new System.Drawing.Size(200, 220);
            this.groupBox1.Text = "查询条件";
            this.groupBox1.Controls.SetChildIndex(this.myLable1, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable2, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable3, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable4, 0);
            this.groupBox1.Controls.SetChildIndex(this.date_出货日期1, 0);
            this.groupBox1.Controls.SetChildIndex(this.date_出货日期2, 0);
            this.groupBox1.Controls.SetChildIndex(this.date_录入日期1, 0);
            this.groupBox1.Controls.SetChildIndex(this.date_录入日期2, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable5, 0);
            this.groupBox1.Controls.SetChildIndex(this.txt_订单号码, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable6, 0);
            this.groupBox1.Controls.SetChildIndex(this.txt_流水号, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable7, 0);
            this.groupBox1.Controls.SetChildIndex(this.txt_客户代码, 0);
            // 
            // date_出货日期1
            // 
            this.date_出货日期1.Location = new System.Drawing.Point(76, 105);
            this.date_出货日期1.Tag = "1,报关预先订单表.出货日期";
            // 
            // date_录入日期2
            // 
            this.date_录入日期2.Location = new System.Drawing.Point(76, 188);
            this.date_录入日期2.Tag = "2,报关预先订单表.录入日期";
            // 
            // date_录入日期1
            // 
            this.date_录入日期1.Location = new System.Drawing.Point(76, 161);
            this.date_录入日期1.Tag = "1,报关预先订单表.录入日期";
            // 
            // date_出货日期2
            // 
            this.date_出货日期2.Location = new System.Drawing.Point(76, 133);
            this.date_出货日期2.Tag = "2,报关预先订单表.出货日期";
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.Location = new System.Drawing.Point(235, 94);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(232, 19);
            this.btnOK.Size = new System.Drawing.Size(75, 19);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 58);
            this.btnCancel.Size = new System.Drawing.Size(75, 19);
            // 
            // myLable4
            // 
            this.myLable4.Location = new System.Drawing.Point(52, 192);
            // 
            // myLable3
            // 
            this.myLable3.Location = new System.Drawing.Point(16, 164);
            // 
            // myLable2
            // 
            this.myLable2.Location = new System.Drawing.Point(52, 136);
            // 
            // myLable1
            // 
            this.myLable1.Location = new System.Drawing.Point(16, 109);
            // 
            // myLable5
            // 
            this.myLable5.AutoSize = true;
            this.myLable5.Location = new System.Drawing.Point(13, 24);
            this.myLable5.Name = "myLable5";
            this.myLable5.Size = new System.Drawing.Size(65, 12);
            this.myLable5.TabIndex = 12;
            this.myLable5.Text = "订单号码：";
            // 
            // txt_订单号码
            // 
            this.txt_订单号码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_订单号码.Location = new System.Drawing.Point(73, 20);
            this.txt_订单号码.Name = "txt_订单号码";
            this.txt_订单号码.Size = new System.Drawing.Size(109, 21);
            this.txt_订单号码.TabIndex = 13;
            this.txt_订单号码.Tag = "报关预先订单表.订单号码";
            // 
            // txt_流水号
            // 
            this.txt_流水号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_流水号.Location = new System.Drawing.Point(73, 51);
            this.txt_流水号.Name = "txt_流水号";
            this.txt_流水号.Size = new System.Drawing.Size(109, 21);
            this.txt_流水号.TabIndex = 15;
            this.txt_流水号.Tag = "报关预先订单表.流水号";
            // 
            // myLable6
            // 
            this.myLable6.AutoSize = true;
            this.myLable6.Location = new System.Drawing.Point(13, 55);
            this.myLable6.Name = "myLable6";
            this.myLable6.Size = new System.Drawing.Size(65, 12);
            this.myLable6.TabIndex = 14;
            this.myLable6.Text = "流 水 号：";
            // 
            // txt_客户代码
            // 
            this.txt_客户代码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_客户代码.Location = new System.Drawing.Point(73, 82);
            this.txt_客户代码.Name = "txt_客户代码";
            this.txt_客户代码.Size = new System.Drawing.Size(109, 21);
            this.txt_客户代码.TabIndex = 17;
            this.txt_客户代码.Tag = "报关预先订单表.客户代码";
            // 
            // myLable7
            // 
            this.myLable7.AutoSize = true;
            this.myLable7.Location = new System.Drawing.Point(13, 86);
            this.myLable7.Name = "myLable7";
            this.myLable7.Size = new System.Drawing.Size(65, 12);
            this.myLable7.TabIndex = 16;
            this.myLable7.Text = "客户代码：";
            // 
            // FormOrderQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(316, 265);
            this.Name = "FormOrderQueryCondition";
            this.Text = "【预先订单录入】查询条件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myTextBox txt_订单号码;
        private UniqueDeclarationBaseForm.Controls.myLable myLable5;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_客户代码;
        private UniqueDeclarationBaseForm.Controls.myLable myLable7;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_流水号;
        private UniqueDeclarationBaseForm.Controls.myLable myLable6;
    }
}
