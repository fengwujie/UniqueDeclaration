namespace UniqueDeclaration.Base
{
    partial class FormCheckOutImportSet
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
            this.myLable5 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable6 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.cbox_手册编号 = new UniqueDeclarationBaseForm.Controls.myComboBox();
            this.btnOK = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnCancel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.SuspendLayout();
            // 
            // date_出货日期2
            // 
            this.date_出货日期2.Checked = false;
            this.date_出货日期2.CustomFormat = "yyyy-MM-dd";
            this.date_出货日期2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_出货日期2.Location = new System.Drawing.Point(83, 49);
            this.date_出货日期2.Name = "date_出货日期2";
            this.date_出货日期2.Size = new System.Drawing.Size(134, 21);
            this.date_出货日期2.TabIndex = 55;
            this.date_出货日期2.Tag = "";
            // 
            // date_出货日期1
            // 
            this.date_出货日期1.Checked = false;
            this.date_出货日期1.CustomFormat = "yyyy-MM-dd";
            this.date_出货日期1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_出货日期1.Location = new System.Drawing.Point(83, 12);
            this.date_出货日期1.Name = "date_出货日期1";
            this.date_出货日期1.Size = new System.Drawing.Size(134, 21);
            this.date_出货日期1.TabIndex = 54;
            this.date_出货日期1.Tag = "";
            // 
            // myLable5
            // 
            this.myLable5.Location = new System.Drawing.Point(55, 53);
            this.myLable5.Name = "myLable5";
            this.myLable5.Size = new System.Drawing.Size(29, 12);
            this.myLable5.TabIndex = 57;
            this.myLable5.Text = "到：";
            this.myLable5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myLable6
            // 
            this.myLable6.Location = new System.Drawing.Point(2, 16);
            this.myLable6.Name = "myLable6";
            this.myLable6.Size = new System.Drawing.Size(82, 12);
            this.myLable6.TabIndex = 56;
            this.myLable6.Text = "出货日期从：";
            this.myLable6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myLable1
            // 
            this.myLable1.Location = new System.Drawing.Point(14, 90);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(70, 12);
            this.myLable1.TabIndex = 58;
            this.myLable1.Text = "手册编号：";
            this.myLable1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbox_手册编号
            // 
            this.cbox_手册编号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_手册编号.FormattingEnabled = true;
            this.cbox_手册编号.Location = new System.Drawing.Point(83, 86);
            this.cbox_手册编号.Name = "cbox_手册编号";
            this.cbox_手册编号.Size = new System.Drawing.Size(134, 20);
            this.cbox_手册编号.TabIndex = 59;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(57, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(138, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 61;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormCheckOutImportSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(262, 153);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbox_手册编号);
            this.Controls.Add(this.myLable1);
            this.Controls.Add(this.date_出货日期2);
            this.Controls.Add(this.date_出货日期1);
            this.Controls.Add(this.myLable5);
            this.Controls.Add(this.myLable6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCheckOutImportSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "条件设定";
            this.Load += new System.EventHandler(this.FormCheckOutImportSet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出货日期2;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出货日期1;
        private UniqueDeclarationBaseForm.Controls.myLable myLable5;
        private UniqueDeclarationBaseForm.Controls.myLable myLable6;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myComboBox cbox_手册编号;
        private UniqueDeclarationBaseForm.Controls.myButton btnOK;
        private UniqueDeclarationBaseForm.Controls.myButton btnCancel;
    }
}
