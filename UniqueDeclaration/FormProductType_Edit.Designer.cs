namespace UniqueDeclaration
{
    partial class FormProductType_Edit
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
            this.myTextBox1 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.btnOK = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnCancel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.SuspendLayout();
            // 
            // myTextBox1
            // 
            this.myTextBox1.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.myTextBox1.Location = new System.Drawing.Point(12, 74);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.Size = new System.Drawing.Size(298, 21);
            this.myTextBox1.TabIndex = 0;
            // 
            // myLable1
            // 
            this.myLable1.AutoSize = true;
            this.myLable1.Location = new System.Drawing.Point(12, 18);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(53, 12);
            this.myLable1.TabIndex = 1;
            this.myLable1.Text = "myLable1";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(235, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(235, 42);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormProductType_Edit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(323, 104);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.myLable1);
            this.Controls.Add(this.myTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormProductType_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品类别资料输入";
            this.Load += new System.EventHandler(this.FormProductType_Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myTextBox myTextBox1;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myButton btnOK;
        private UniqueDeclarationBaseForm.Controls.myButton btnCancel;
    }
}
