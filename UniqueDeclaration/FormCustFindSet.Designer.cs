namespace UniqueDeclaration
{
    partial class FormCustFindSet
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
            this.txt_CustNo = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.btnOK = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnCancel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.SuspendLayout();
            // 
            // myLable1
            // 
            this.myLable1.AutoSize = true;
            this.myLable1.Location = new System.Drawing.Point(31, 22);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(59, 12);
            this.myLable1.TabIndex = 0;
            this.myLable1.Text = "Cust_No：";
            // 
            // txt_CustNo
            // 
            this.txt_CustNo.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_CustNo.Location = new System.Drawing.Point(86, 19);
            this.txt_CustNo.Name = "txt_CustNo";
            this.txt_CustNo.Size = new System.Drawing.Size(149, 21);
            this.txt_CustNo.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(51, 66);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "CONFIRM";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(160, 66);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormCustFindSet
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(283, 119);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txt_CustNo);
            this.Controls.Add(this.myLable1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCustFindSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.Load += new System.EventHandler(this.FormCustFindSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_CustNo;
        private UniqueDeclarationBaseForm.Controls.myButton btnOK;
        private UniqueDeclarationBaseForm.Controls.myButton btnCancel;
    }
}
