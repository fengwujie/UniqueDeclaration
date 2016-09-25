namespace UniqueDeclaration
{
    partial class FormArticlesFile_Find
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
            this.txt_Cust = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_Cust = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_SecondField = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_StyleNo = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_KeyField = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_Unique_No = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_Colors = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_Color = new UniqueDeclarationBaseForm.Controls.myLable();
            this.btnCancel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnOK = new UniqueDeclarationBaseForm.Controls.myButton();
            this.SuspendLayout();
            // 
            // txt_Cust
            // 
            this.txt_Cust.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_Cust.Location = new System.Drawing.Point(90, 12);
            this.txt_Cust.Name = "txt_Cust";
            this.txt_Cust.Size = new System.Drawing.Size(154, 21);
            this.txt_Cust.TabIndex = 0;
            // 
            // lab_Cust
            // 
            this.lab_Cust.Location = new System.Drawing.Point(10, 12);
            this.lab_Cust.Name = "lab_Cust";
            this.lab_Cust.Size = new System.Drawing.Size(84, 20);
            this.lab_Cust.TabIndex = 2;
            this.lab_Cust.Text = "Cust：";
            this.lab_Cust.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SecondField
            // 
            this.txt_SecondField.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_SecondField.Location = new System.Drawing.Point(90, 50);
            this.txt_SecondField.Name = "txt_SecondField";
            this.txt_SecondField.Size = new System.Drawing.Size(154, 21);
            this.txt_SecondField.TabIndex = 1;
            // 
            // lab_StyleNo
            // 
            this.lab_StyleNo.Location = new System.Drawing.Point(9, 50);
            this.lab_StyleNo.Name = "lab_StyleNo";
            this.lab_StyleNo.Size = new System.Drawing.Size(84, 20);
            this.lab_StyleNo.TabIndex = 6;
            this.lab_StyleNo.Text = "StyleNO：";
            this.lab_StyleNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_KeyField
            // 
            this.txt_KeyField.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_KeyField.Location = new System.Drawing.Point(90, 88);
            this.txt_KeyField.Name = "txt_KeyField";
            this.txt_KeyField.Size = new System.Drawing.Size(154, 21);
            this.txt_KeyField.TabIndex = 2;
            // 
            // lab_Unique_No
            // 
            this.lab_Unique_No.Location = new System.Drawing.Point(10, 88);
            this.lab_Unique_No.Name = "lab_Unique_No";
            this.lab_Unique_No.Size = new System.Drawing.Size(84, 20);
            this.lab_Unique_No.TabIndex = 10;
            this.lab_Unique_No.Text = "Unique_NO：";
            this.lab_Unique_No.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Colors
            // 
            this.txt_Colors.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_Colors.Location = new System.Drawing.Point(90, 126);
            this.txt_Colors.Name = "txt_Colors";
            this.txt_Colors.Size = new System.Drawing.Size(154, 21);
            this.txt_Colors.TabIndex = 3;
            // 
            // lab_Color
            // 
            this.lab_Color.Location = new System.Drawing.Point(9, 126);
            this.lab_Color.Name = "lab_Color";
            this.lab_Color.Size = new System.Drawing.Size(84, 20);
            this.lab_Color.TabIndex = 17;
            this.lab_Color.Text = "Color：";
            this.lab_Color.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(152, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(43, 166);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "CONFIRM";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormArticlesFile_Find
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(281, 201);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txt_Colors);
            this.Controls.Add(this.lab_Color);
            this.Controls.Add(this.txt_KeyField);
            this.Controls.Add(this.lab_Unique_No);
            this.Controls.Add(this.txt_SecondField);
            this.Controls.Add(this.lab_StyleNo);
            this.Controls.Add(this.txt_Cust);
            this.Controls.Add(this.lab_Cust);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormArticlesFile_Find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Condition";
            this.Load += new System.EventHandler(this.FormArticlesFile_Find_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myTextBox txt_Cust;
        private UniqueDeclarationBaseForm.Controls.myLable lab_Cust;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_SecondField;
        private UniqueDeclarationBaseForm.Controls.myLable lab_StyleNo;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_KeyField;
        private UniqueDeclarationBaseForm.Controls.myLable lab_Unique_No;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_Colors;
        private UniqueDeclarationBaseForm.Controls.myLable lab_Color;
        private UniqueDeclarationBaseForm.Controls.myButton btnCancel;
        private UniqueDeclarationBaseForm.Controls.myButton btnOK;
    }
}
