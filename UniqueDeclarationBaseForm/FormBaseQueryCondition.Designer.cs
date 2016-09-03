namespace UniqueDeclarationBaseForm
{
    partial class FormBaseQueryCondition
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.date_录入日期2 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_录入日期1 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_出货日期2 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.date_出货日期1 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.myLable4 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable3 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.btnCancel = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnOK = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myCheckBox1 = new UniqueDeclarationBaseForm.Controls.myCheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_录入日期2);
            this.groupBox1.Controls.Add(this.date_录入日期1);
            this.groupBox1.Controls.Add(this.date_出货日期2);
            this.groupBox1.Controls.Add(this.date_出货日期1);
            this.groupBox1.Controls.Add(this.myLable4);
            this.groupBox1.Controls.Add(this.myLable3);
            this.groupBox1.Controls.Add(this.myLable2);
            this.groupBox1.Controls.Add(this.myLable1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XX查询条件";
            // 
            // date_录入日期2
            // 
            this.date_录入日期2.Checked = false;
            this.date_录入日期2.Location = new System.Drawing.Point(76, 218);
            this.date_录入日期2.Name = "date_录入日期2";
            this.date_录入日期2.ShowCheckBox = true;
            this.date_录入日期2.Size = new System.Drawing.Size(109, 21);
            this.date_录入日期2.TabIndex = 7;
            // 
            // date_录入日期1
            // 
            this.date_录入日期1.Checked = false;
            this.date_录入日期1.Location = new System.Drawing.Point(76, 186);
            this.date_录入日期1.Name = "date_录入日期1";
            this.date_录入日期1.ShowCheckBox = true;
            this.date_录入日期1.Size = new System.Drawing.Size(109, 21);
            this.date_录入日期1.TabIndex = 5;
            // 
            // date_出货日期2
            // 
            this.date_出货日期2.Checked = false;
            this.date_出货日期2.Location = new System.Drawing.Point(76, 154);
            this.date_出货日期2.Name = "date_出货日期2";
            this.date_出货日期2.ShowCheckBox = true;
            this.date_出货日期2.Size = new System.Drawing.Size(109, 21);
            this.date_出货日期2.TabIndex = 3;
            // 
            // date_出货日期1
            // 
            this.date_出货日期1.Checked = false;
            this.date_出货日期1.Location = new System.Drawing.Point(76, 122);
            this.date_出货日期1.Name = "date_出货日期1";
            this.date_出货日期1.ShowCheckBox = true;
            this.date_出货日期1.Size = new System.Drawing.Size(109, 21);
            this.date_出货日期1.TabIndex = 1;
            // 
            // myLable4
            // 
            this.myLable4.AutoSize = true;
            this.myLable4.Location = new System.Drawing.Point(52, 222);
            this.myLable4.Name = "myLable4";
            this.myLable4.Size = new System.Drawing.Size(29, 12);
            this.myLable4.TabIndex = 11;
            this.myLable4.Text = "到：";
            // 
            // myLable3
            // 
            this.myLable3.AutoSize = true;
            this.myLable3.Location = new System.Drawing.Point(16, 190);
            this.myLable3.Name = "myLable3";
            this.myLable3.Size = new System.Drawing.Size(65, 12);
            this.myLable3.TabIndex = 10;
            this.myLable3.Text = "录入日期：";
            // 
            // myLable2
            // 
            this.myLable2.AutoSize = true;
            this.myLable2.Location = new System.Drawing.Point(52, 158);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(29, 12);
            this.myLable2.TabIndex = 9;
            this.myLable2.Text = "到：";
            // 
            // myLable1
            // 
            this.myLable1.AutoSize = true;
            this.myLable1.Location = new System.Drawing.Point(16, 126);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(65, 12);
            this.myLable1.TabIndex = 8;
            this.myLable1.Text = "出货日期：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(232, 23);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确  定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.AutoSize = true;
            this.myCheckBox1.Checked = true;
            this.myCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.myCheckBox1.Location = new System.Drawing.Point(235, 109);
            this.myCheckBox1.Name = "myCheckBox1";
            this.myCheckBox1.Size = new System.Drawing.Size(72, 16);
            this.myCheckBox1.TabIndex = 3;
            this.myCheckBox1.Text = "模糊查询";
            this.myCheckBox1.UseVisualStyleBackColor = true;
            // 
            // FormBaseQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 310);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.myCheckBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormBaseQueryCondition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询条件基本窗体";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public Controls.myDateTimePicker date_出货日期1;
        public Controls.myDateTimePicker date_录入日期2;
        public Controls.myDateTimePicker date_录入日期1;
        public Controls.myDateTimePicker date_出货日期2;
        public Controls.myCheckBox myCheckBox1;
        public Controls.myButton btnOK;
        public Controls.myButton btnCancel;
        public Controls.myLable myLable4;
        public Controls.myLable myLable3;
        public Controls.myLable myLable2;
        public Controls.myLable myLable1;

    }
}