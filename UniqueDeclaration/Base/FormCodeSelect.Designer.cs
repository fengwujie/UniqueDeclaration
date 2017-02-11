namespace UniqueDeclaration.Base
{
    partial class FormCodeSelect
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
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myTextBox1 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myTextBox2 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myTextBox3 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable3 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.btnOK = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnCancel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.SuspendLayout();
            // 
            // myLable1
            // 
            this.myLable1.Location = new System.Drawing.Point(23, 23);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(69, 15);
            this.myLable1.TabIndex = 0;
            this.myLable1.Text = "起止号：";
            this.myLable1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myTextBox1
            // 
            this.myTextBox1.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.myTextBox1.Location = new System.Drawing.Point(88, 21);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.ReadOnly = true;
            this.myTextBox1.Size = new System.Drawing.Size(100, 21);
            this.myTextBox1.TabIndex = 1;
            // 
            // myTextBox2
            // 
            this.myTextBox2.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.myTextBox2.Location = new System.Drawing.Point(88, 57);
            this.myTextBox2.Name = "myTextBox2";
            this.myTextBox2.Size = new System.Drawing.Size(100, 21);
            this.myTextBox2.TabIndex = 3;
            this.myTextBox2.TextChanged += new System.EventHandler(this.myTextBox2_TextChanged);
            // 
            // myLable2
            // 
            this.myLable2.Location = new System.Drawing.Point(23, 59);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(69, 15);
            this.myLable2.TabIndex = 2;
            this.myLable2.Text = "申请数：";
            this.myLable2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myTextBox3
            // 
            this.myTextBox3.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.myTextBox3.Location = new System.Drawing.Point(88, 93);
            this.myTextBox3.Name = "myTextBox3";
            this.myTextBox3.ReadOnly = true;
            this.myTextBox3.Size = new System.Drawing.Size(100, 21);
            this.myTextBox3.TabIndex = 5;
            // 
            // myLable3
            // 
            this.myLable3.Location = new System.Drawing.Point(23, 95);
            this.myLable3.Name = "myLable3";
            this.myLable3.Size = new System.Drawing.Size(69, 15);
            this.myLable3.TabIndex = 4;
            this.myLable3.Text = "终止号：";
            this.myLable3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(37, 131);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(131, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormCodeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(246, 177);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.myTextBox3);
            this.Controls.Add(this.myLable3);
            this.Controls.Add(this.myTextBox2);
            this.Controls.Add(this.myLable2);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.myLable1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormCodeSelect";
            this.Text = "条件设定";
            this.Load += new System.EventHandler(this.FormCodeSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myTextBox myTextBox1;
        private UniqueDeclarationBaseForm.Controls.myTextBox myTextBox2;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myTextBox myTextBox3;
        private UniqueDeclarationBaseForm.Controls.myLable myLable3;
        private UniqueDeclarationBaseForm.Controls.myButton btnOK;
        private UniqueDeclarationBaseForm.Controls.myButton btnCancel;
    }
}
