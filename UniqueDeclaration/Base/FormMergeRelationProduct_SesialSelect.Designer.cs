namespace UniqueDeclaration.Base
{
    partial class FormMergeRelationProduct_SesialSelect
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
            this.lab_SerialBegin = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_SerialBegin = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_SerialEnd = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.lab_SerialEnd = new UniqueDeclarationBaseForm.Controls.myLable();
            this.btnOK = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnCancel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.SuspendLayout();
            // 
            // lab_SerialBegin
            // 
            this.lab_SerialBegin.Location = new System.Drawing.Point(38, 25);
            this.lab_SerialBegin.Name = "lab_SerialBegin";
            this.lab_SerialBegin.Size = new System.Drawing.Size(68, 23);
            this.lab_SerialBegin.TabIndex = 0;
            this.lab_SerialBegin.Text = "序号从：";
            this.lab_SerialBegin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SerialBegin
            // 
            this.txt_SerialBegin.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_SerialBegin.Location = new System.Drawing.Point(113, 26);
            this.txt_SerialBegin.Name = "txt_SerialBegin";
            this.txt_SerialBegin.Size = new System.Drawing.Size(100, 21);
            this.txt_SerialBegin.TabIndex = 1;
            // 
            // txt_SerialEnd
            // 
            this.txt_SerialEnd.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_SerialEnd.Location = new System.Drawing.Point(113, 53);
            this.txt_SerialEnd.Name = "txt_SerialEnd";
            this.txt_SerialEnd.Size = new System.Drawing.Size(100, 21);
            this.txt_SerialEnd.TabIndex = 3;
            // 
            // lab_SerialEnd
            // 
            this.lab_SerialEnd.Location = new System.Drawing.Point(38, 52);
            this.lab_SerialEnd.Name = "lab_SerialEnd";
            this.lab_SerialEnd.Size = new System.Drawing.Size(68, 23);
            this.lab_SerialEnd.TabIndex = 2;
            this.lab_SerialEnd.Text = "终止号：";
            this.lab_SerialEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(52, 90);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(138, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormMergeRelationProduct_SesialSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(288, 125);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txt_SerialEnd);
            this.Controls.Add(this.lab_SerialEnd);
            this.Controls.Add(this.txt_SerialBegin);
            this.Controls.Add(this.lab_SerialBegin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormMergeRelationProduct_SesialSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "条件设定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myLable lab_SerialBegin;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_SerialBegin;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_SerialEnd;
        private UniqueDeclarationBaseForm.Controls.myLable lab_SerialEnd;
        private UniqueDeclarationBaseForm.Controls.myButton btnOK;
        private UniqueDeclarationBaseForm.Controls.myButton btnCancel;
    }
}
