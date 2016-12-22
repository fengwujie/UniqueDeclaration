namespace UniqueDeclarationBaseForm
{
    partial class FormBaseManualCondition
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
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.cbox_手册编号 = new UniqueDeclarationBaseForm.Controls.myComboBox();
            this.btnOK = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnCancel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.SuspendLayout();
            // 
            // myLable1
            // 
            this.myLable1.AutoSize = true;
            this.myLable1.Location = new System.Drawing.Point(22, 32);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(65, 12);
            this.myLable1.TabIndex = 0;
            this.myLable1.Text = "手册编号：";
            // 
            // cbox_手册编号
            // 
            this.cbox_手册编号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_手册编号.FormattingEnabled = true;
            this.cbox_手册编号.Location = new System.Drawing.Point(93, 29);
            this.cbox_手册编号.Name = "cbox_手册编号";
            this.cbox_手册编号.Size = new System.Drawing.Size(138, 20);
            this.cbox_手册编号.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(51, 73);
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
            this.btnCancel.Location = new System.Drawing.Point(156, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormBaseManualCondition
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 122);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbox_手册编号);
            this.Controls.Add(this.myLable1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormBaseManualCondition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择手册编号";
            this.Load += new System.EventHandler(this.FormBaseManualCondition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.myLable myLable1;
        private Controls.myComboBox cbox_手册编号;
        private Controls.myButton btnOK;
        private Controls.myButton btnCancel;
    }
}