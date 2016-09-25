namespace UniqueDeclaration
{
    partial class FormArticlesFile_ExportExcel
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
            this.btnCancel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnOK = new UniqueDeclarationBaseForm.Controls.myButton();
            this.txt_Cust = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_Cust = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_KeyFieldBegin = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_Unique_No = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_SecondFieldBegin = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_StyleNo = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_SecondFieldEnd = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_KeyFieldEnd = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(178, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(69, 203);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "CONFIRM";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txt_Cust
            // 
            this.txt_Cust.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_Cust.Location = new System.Drawing.Point(116, 161);
            this.txt_Cust.Name = "txt_Cust";
            this.txt_Cust.Size = new System.Drawing.Size(154, 21);
            this.txt_Cust.TabIndex = 4;
            // 
            // lab_Cust
            // 
            this.lab_Cust.Location = new System.Drawing.Point(35, 161);
            this.lab_Cust.Name = "lab_Cust";
            this.lab_Cust.Size = new System.Drawing.Size(84, 20);
            this.lab_Cust.TabIndex = 27;
            this.lab_Cust.Text = "Cust：";
            this.lab_Cust.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_KeyFieldBegin
            // 
            this.txt_KeyFieldBegin.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_KeyFieldBegin.Location = new System.Drawing.Point(116, 91);
            this.txt_KeyFieldBegin.Name = "txt_KeyFieldBegin";
            this.txt_KeyFieldBegin.Size = new System.Drawing.Size(154, 21);
            this.txt_KeyFieldBegin.TabIndex = 2;
            // 
            // lab_Unique_No
            // 
            this.lab_Unique_No.Location = new System.Drawing.Point(36, 91);
            this.lab_Unique_No.Name = "lab_Unique_No";
            this.lab_Unique_No.Size = new System.Drawing.Size(84, 20);
            this.lab_Unique_No.TabIndex = 25;
            this.lab_Unique_No.Text = "Unique_NO：";
            this.lab_Unique_No.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SecondFieldBegin
            // 
            this.txt_SecondFieldBegin.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_SecondFieldBegin.Location = new System.Drawing.Point(116, 21);
            this.txt_SecondFieldBegin.Name = "txt_SecondFieldBegin";
            this.txt_SecondFieldBegin.Size = new System.Drawing.Size(154, 21);
            this.txt_SecondFieldBegin.TabIndex = 0;
            // 
            // lab_StyleNo
            // 
            this.lab_StyleNo.Location = new System.Drawing.Point(35, 21);
            this.lab_StyleNo.Name = "lab_StyleNo";
            this.lab_StyleNo.Size = new System.Drawing.Size(84, 20);
            this.lab_StyleNo.TabIndex = 23;
            this.lab_StyleNo.Text = "StyleNO：";
            this.lab_StyleNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SecondFieldEnd
            // 
            this.txt_SecondFieldEnd.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_SecondFieldEnd.Location = new System.Drawing.Point(116, 56);
            this.txt_SecondFieldEnd.Name = "txt_SecondFieldEnd";
            this.txt_SecondFieldEnd.Size = new System.Drawing.Size(154, 21);
            this.txt_SecondFieldEnd.TabIndex = 1;
            // 
            // txt_KeyFieldEnd
            // 
            this.txt_KeyFieldEnd.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_KeyFieldEnd.Location = new System.Drawing.Point(116, 126);
            this.txt_KeyFieldEnd.Name = "txt_KeyFieldEnd";
            this.txt_KeyFieldEnd.Size = new System.Drawing.Size(154, 21);
            this.txt_KeyFieldEnd.TabIndex = 3;
            // 
            // FormArticlesFile_ExportExcel
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(345, 248);
            this.Controls.Add(this.txt_KeyFieldEnd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txt_Cust);
            this.Controls.Add(this.lab_Cust);
            this.Controls.Add(this.txt_KeyFieldBegin);
            this.Controls.Add(this.lab_Unique_No);
            this.Controls.Add(this.txt_SecondFieldBegin);
            this.Controls.Add(this.lab_StyleNo);
            this.Controls.Add(this.txt_SecondFieldEnd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormArticlesFile_ExportExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Condition";
            this.Load += new System.EventHandler(this.FormArticlesFile_ExportExcel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myButton btnCancel;
        private UniqueDeclarationBaseForm.Controls.myButton btnOK;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_Cust;
        private UniqueDeclarationBaseForm.Controls.myLable lab_Cust;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_KeyFieldBegin;
        private UniqueDeclarationBaseForm.Controls.myLable lab_Unique_No;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_SecondFieldBegin;
        private UniqueDeclarationBaseForm.Controls.myLable lab_StyleNo;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_SecondFieldEnd;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_KeyFieldEnd;
    }
}
