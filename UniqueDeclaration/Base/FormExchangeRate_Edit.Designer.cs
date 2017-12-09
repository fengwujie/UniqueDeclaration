namespace UniqueDeclaration.Base
{
    partial class FormExchangeRate_Edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lab_Year = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_Year = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_Month = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_Month = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_Rate = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_Rate = new UniqueDeclarationBaseForm.Controls.myLable();
            this.btnOK = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnCancel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.SuspendLayout();
            // 
            // lab_Year
            // 
            this.lab_Year.AutoSize = true;
            this.lab_Year.Location = new System.Drawing.Point(58, 32);
            this.lab_Year.Name = "lab_Year";
            this.lab_Year.Size = new System.Drawing.Size(52, 15);
            this.lab_Year.TabIndex = 0;
            this.lab_Year.Text = "年份：";
            // 
            // txt_Year
            // 
            this.txt_Year.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_Year.Location = new System.Drawing.Point(116, 29);
            this.txt_Year.Name = "txt_Year";
            this.txt_Year.Size = new System.Drawing.Size(100, 25);
            this.txt_Year.TabIndex = 1;
            // 
            // txt_Month
            // 
            this.txt_Month.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_Month.Location = new System.Drawing.Point(116, 79);
            this.txt_Month.Name = "txt_Month";
            this.txt_Month.Size = new System.Drawing.Size(100, 25);
            this.txt_Month.TabIndex = 3;
            // 
            // lab_Month
            // 
            this.lab_Month.AutoSize = true;
            this.lab_Month.Location = new System.Drawing.Point(58, 82);
            this.lab_Month.Name = "lab_Month";
            this.lab_Month.Size = new System.Drawing.Size(52, 15);
            this.lab_Month.TabIndex = 2;
            this.lab_Month.Text = "月份：";
            // 
            // txt_Rate
            // 
            this.txt_Rate.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_Rate.Location = new System.Drawing.Point(116, 127);
            this.txt_Rate.Name = "txt_Rate";
            this.txt_Rate.Size = new System.Drawing.Size(100, 25);
            this.txt_Rate.TabIndex = 5;
            // 
            // lab_Rate
            // 
            this.lab_Rate.AutoSize = true;
            this.lab_Rate.Location = new System.Drawing.Point(58, 130);
            this.lab_Rate.Name = "lab_Rate";
            this.lab_Rate.Size = new System.Drawing.Size(52, 15);
            this.lab_Rate.TabIndex = 4;
            this.lab_Rate.Text = "汇率：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(52, 185);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(160, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormExchangeRate_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 241);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txt_Rate);
            this.Controls.Add(this.lab_Rate);
            this.Controls.Add(this.txt_Month);
            this.Controls.Add(this.lab_Month);
            this.Controls.Add(this.txt_Year);
            this.Controls.Add(this.lab_Year);
            this.Name = "FormExchangeRate_Edit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "汇率维护";
            this.Load += new System.EventHandler(this.FormExchangeRate_Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myLable lab_Year;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_Year;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_Month;
        private UniqueDeclarationBaseForm.Controls.myLable lab_Month;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_Rate;
        private UniqueDeclarationBaseForm.Controls.myLable lab_Rate;
        private UniqueDeclarationBaseForm.Controls.myButton btnOK;
        private UniqueDeclarationBaseForm.Controls.myButton btnCancel;
    }
}