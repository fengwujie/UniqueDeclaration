namespace UniqueDeclaration
{
    partial class FormOuterMaterialTotalQueryCondition
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
            this.date_出货日期2 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_出货日期1 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_订单号码 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable5 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myCheckBox2 = new UniqueDeclarationBaseForm.Controls.myCheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myCheckBox2);
            this.groupBox1.Controls.Add(this.date_出货日期2);
            this.groupBox1.Controls.Add(this.date_出货日期1);
            this.groupBox1.Controls.Add(this.myLable2);
            this.groupBox1.Controls.Add(this.myLable1);
            this.groupBox1.Controls.Add(this.txt_订单号码);
            this.groupBox1.Controls.Add(this.myLable5);
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Size = new System.Drawing.Size(226, 156);
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.Location = new System.Drawing.Point(253, 91);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(250, 14);
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 48);
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            // 
            // date_出货日期2
            // 
            this.date_出货日期2.Checked = false;
            this.date_出货日期2.CustomFormat = "yyyy-MM-dd";
            this.date_出货日期2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_出货日期2.Location = new System.Drawing.Point(77, 92);
            this.date_出货日期2.Name = "date_出货日期2";
            this.date_出货日期2.ShowCheckBox = true;
            this.date_出货日期2.Size = new System.Drawing.Size(113, 21);
            this.date_出货日期2.TabIndex = 43;
            this.date_出货日期2.Tag = "2,装箱单表.出货日期";
            // 
            // date_出货日期1
            // 
            this.date_出货日期1.Checked = false;
            this.date_出货日期1.CustomFormat = "yyyy-MM-dd";
            this.date_出货日期1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_出货日期1.Location = new System.Drawing.Point(77, 61);
            this.date_出货日期1.Name = "date_出货日期1";
            this.date_出货日期1.ShowCheckBox = true;
            this.date_出货日期1.Size = new System.Drawing.Size(113, 21);
            this.date_出货日期1.TabIndex = 42;
            this.date_出货日期1.Tag = "1,装箱单表.出货日期";
            // 
            // myLable2
            // 
            this.myLable2.AutoSize = true;
            this.myLable2.Location = new System.Drawing.Point(55, 96);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(29, 12);
            this.myLable2.TabIndex = 41;
            this.myLable2.Text = "到：";
            // 
            // myLable1
            // 
            this.myLable1.AutoSize = true;
            this.myLable1.Location = new System.Drawing.Point(19, 65);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(65, 12);
            this.myLable1.TabIndex = 40;
            this.myLable1.Text = "出货日期：";
            // 
            // txt_订单号码
            // 
            this.txt_订单号码.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_订单号码.Location = new System.Drawing.Point(77, 30);
            this.txt_订单号码.Name = "txt_订单号码";
            this.txt_订单号码.Size = new System.Drawing.Size(113, 21);
            this.txt_订单号码.TabIndex = 39;
            this.txt_订单号码.Tag = "装箱单表.订单号码";
            // 
            // myLable5
            // 
            this.myLable5.AutoSize = true;
            this.myLable5.Location = new System.Drawing.Point(19, 33);
            this.myLable5.Name = "myLable5";
            this.myLable5.Size = new System.Drawing.Size(65, 12);
            this.myLable5.TabIndex = 38;
            this.myLable5.Text = "订单号码：";
            // 
            // myCheckBox2
            // 
            this.myCheckBox2.AutoSize = true;
            this.myCheckBox2.Location = new System.Drawing.Point(57, 126);
            this.myCheckBox2.Name = "myCheckBox2";
            this.myCheckBox2.Size = new System.Drawing.Size(132, 16);
            this.myCheckBox2.TabIndex = 44;
            this.myCheckBox2.Text = "显示出口成品及商编";
            this.myCheckBox2.UseVisualStyleBackColor = true;
            // 
            // FormOuterMaterialTotalQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(337, 176);
            this.Name = "FormOuterMaterialTotalQueryCondition";
            this.Text = "【出货料件统计】查询条件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出货日期2;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出货日期1;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_订单号码;
        private UniqueDeclarationBaseForm.Controls.myLable myLable5;
        private UniqueDeclarationBaseForm.Controls.myCheckBox myCheckBox2;
    }
}
