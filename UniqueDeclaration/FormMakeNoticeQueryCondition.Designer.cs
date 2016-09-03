namespace UniqueDeclaration
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_客户代码);
            this.groupBox1.Controls.Add(this.txt_制造通知单号);
            this.groupBox1.Controls.Add(this.myLable6);
            this.groupBox1.Controls.Add(this.myLable5);
            this.groupBox1.Size = new System.Drawing.Size(238, 242);
            this.groupBox1.Text = "查询条件";
            this.groupBox1.Controls.SetChildIndex(this.myLable5, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable1, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable2, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable3, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable4, 0);
            this.groupBox1.Controls.SetChildIndex(this.date_出货日期1, 0);
            this.groupBox1.Controls.SetChildIndex(this.date_出货日期2, 0);
            this.groupBox1.Controls.SetChildIndex(this.date_录入日期1, 0);
            this.groupBox1.Controls.SetChildIndex(this.date_录入日期2, 0);
            this.groupBox1.Controls.SetChildIndex(this.myLable6, 0);
            this.groupBox1.Controls.SetChildIndex(this.txt_制造通知单号, 0);
            this.groupBox1.Controls.SetChildIndex(this.txt_客户代码, 0);
            // 
            // date_出货日期1
            // 
            this.date_出货日期1.Location = new System.Drawing.Point(103, 97);
            this.date_出货日期1.Tag = "1,报关制造通知单表.出货日期";
            // 
            // date_录入日期2
            // 
            this.date_录入日期2.Location = new System.Drawing.Point(103, 193);
            this.date_录入日期2.Tag = "2,报关制造通知单表.录入日期";
            // 
            // date_录入日期1
            // 
            this.date_录入日期1.Location = new System.Drawing.Point(103, 161);
            this.date_录入日期1.Tag = "1,报关制造通知单表.录入日期";
            // 
            // date_出货日期2
            // 
            this.date_出货日期2.Location = new System.Drawing.Point(103, 129);
            this.date_出货日期2.Tag = "2,报关制造通知单表.出货日期";
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.Location = new System.Drawing.Point(269, 112);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(266, 26);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(266, 70);
            // 
            // myLable4
            // 
            this.myLable4.Location = new System.Drawing.Point(68, 197);
            // 
            // myLable3
            // 
            this.myLable3.Location = new System.Drawing.Point(32, 165);
            // 
            // myLable2
            // 
            this.myLable2.Location = new System.Drawing.Point(68, 133);
            // 
            // myLable1
            // 
            this.myLable1.Location = new System.Drawing.Point(32, 101);
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
            this.myLable6.Location = new System.Drawing.Point(32, 69);
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
            this.txt_制造通知单号.Size = new System.Drawing.Size(109, 21);
            this.txt_制造通知单号.TabIndex = 14;
            this.txt_制造通知单号.Tag = "报关制造通知单表.制造通知单号";
            // 
            // txt_客户代码
            // 
            this.txt_客户代码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_客户代码.Location = new System.Drawing.Point(103, 65);
            this.txt_客户代码.Name = "txt_客户代码";
            this.txt_客户代码.Size = new System.Drawing.Size(109, 21);
            this.txt_客户代码.TabIndex = 15;
            this.txt_客户代码.Tag = "报关制造通知单表.客户代码";
            // 
            // FormMakeNoticeQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(362, 273);
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
    }
}
