namespace UniqueDeclaration
{
    partial class FormMaterialsOutInput
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
            this.txt_出库单号1 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_出库单号2 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.date_出库时间 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.myLable3 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_摘要 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable4 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_制造通知单号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable5 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.cbox_电子帐册号 = new UniqueDeclarationBaseForm.Controls.myComboBox();
            this.txt_录入员 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable6 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myContextDetails = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_录入员);
            this.groupBox1.Controls.Add(this.myLable6);
            this.groupBox1.Controls.Add(this.cbox_电子帐册号);
            this.groupBox1.Controls.Add(this.myLable5);
            this.groupBox1.Controls.Add(this.txt_制造通知单号);
            this.groupBox1.Controls.Add(this.myLable4);
            this.groupBox1.Controls.Add(this.txt_摘要);
            this.groupBox1.Controls.Add(this.myLable3);
            this.groupBox1.Controls.Add(this.date_出库时间);
            this.groupBox1.Controls.Add(this.myLable2);
            this.groupBox1.Controls.Add(this.txt_出库单号2);
            this.groupBox1.Controls.Add(this.txt_出库单号1);
            this.groupBox1.Controls.Add(this.myLable1);
            this.groupBox1.Size = new System.Drawing.Size(919, 104);
            this.groupBox1.Text = "出库单内容";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 129);
            this.groupBox2.Size = new System.Drawing.Size(919, 311);
            // 
            // myLable1
            // 
            this.myLable1.Location = new System.Drawing.Point(6, 28);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(104, 12);
            this.myLable1.TabIndex = 0;
            this.myLable1.Text = "出库单号：";
            this.myLable1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_出库单号1
            // 
            this.txt_出库单号1.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_出库单号1.Location = new System.Drawing.Point(107, 24);
            this.txt_出库单号1.Name = "txt_出库单号1";
            this.txt_出库单号1.Size = new System.Drawing.Size(21, 21);
            this.txt_出库单号1.TabIndex = 1;
            this.txt_出库单号1.Validating += new System.ComponentModel.CancelEventHandler(this.txt_出库单号1_Validating);
            this.txt_出库单号1.Validated += new System.EventHandler(this.txt_出库单号1_Validated);
            // 
            // txt_出库单号2
            // 
            this.txt_出库单号2.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_出库单号2.Location = new System.Drawing.Point(130, 24);
            this.txt_出库单号2.Name = "txt_出库单号2";
            this.txt_出库单号2.Size = new System.Drawing.Size(132, 21);
            this.txt_出库单号2.TabIndex = 2;
            this.txt_出库单号2.Validating += new System.ComponentModel.CancelEventHandler(this.txt_出库单号2_Validating);
            this.txt_出库单号2.Validated += new System.EventHandler(this.txt_出库单号2_Validated);
            // 
            // myLable2
            // 
            this.myLable2.Location = new System.Drawing.Point(284, 28);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(104, 12);
            this.myLable2.TabIndex = 3;
            this.myLable2.Text = "出库时间：";
            this.myLable2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // date_出库时间
            // 
            this.date_出库时间.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.date_出库时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_出库时间.Location = new System.Drawing.Point(384, 24);
            this.date_出库时间.Name = "date_出库时间";
            this.date_出库时间.Size = new System.Drawing.Size(155, 21);
            this.date_出库时间.TabIndex = 4;
            this.date_出库时间.Validated += new System.EventHandler(this.date_出库时间_ValueChanged);
            // 
            // myLable3
            // 
            this.myLable3.Location = new System.Drawing.Point(566, 28);
            this.myLable3.Name = "myLable3";
            this.myLable3.Size = new System.Drawing.Size(104, 12);
            this.myLable3.TabIndex = 5;
            this.myLable3.Text = "摘要：";
            this.myLable3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_摘要
            // 
            this.txt_摘要.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_摘要.Location = new System.Drawing.Point(667, 24);
            this.txt_摘要.Name = "txt_摘要";
            this.txt_摘要.Size = new System.Drawing.Size(155, 21);
            this.txt_摘要.TabIndex = 6;
            this.txt_摘要.Validated += new System.EventHandler(this.txt_摘要_Validated);
            // 
            // myLable4
            // 
            this.myLable4.Location = new System.Drawing.Point(6, 67);
            this.myLable4.Name = "myLable4";
            this.myLable4.Size = new System.Drawing.Size(104, 12);
            this.myLable4.TabIndex = 7;
            this.myLable4.Text = "制造通知单号：";
            this.myLable4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_制造通知单号
            // 
            this.txt_制造通知单号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_制造通知单号.Location = new System.Drawing.Point(107, 63);
            this.txt_制造通知单号.Name = "txt_制造通知单号";
            this.txt_制造通知单号.Size = new System.Drawing.Size(155, 21);
            this.txt_制造通知单号.TabIndex = 8;
            this.txt_制造通知单号.Validating += new System.ComponentModel.CancelEventHandler(this.txt_制造通知单号_Validating);
            this.txt_制造通知单号.Validated += new System.EventHandler(this.txt_制造通知单号_Validated);
            // 
            // myLable5
            // 
            this.myLable5.Location = new System.Drawing.Point(284, 67);
            this.myLable5.Name = "myLable5";
            this.myLable5.Size = new System.Drawing.Size(104, 12);
            this.myLable5.TabIndex = 9;
            this.myLable5.Text = "电子帐册号：";
            this.myLable5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbox_电子帐册号
            // 
            this.cbox_电子帐册号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_电子帐册号.FormattingEnabled = true;
            this.cbox_电子帐册号.Location = new System.Drawing.Point(384, 63);
            this.cbox_电子帐册号.Name = "cbox_电子帐册号";
            this.cbox_电子帐册号.Size = new System.Drawing.Size(155, 20);
            this.cbox_电子帐册号.TabIndex = 10;
            this.cbox_电子帐册号.SelectedIndexChanged += new System.EventHandler(this.cbox_电子帐册号_SelectedIndexChanged);
            // 
            // txt_录入员
            // 
            this.txt_录入员.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_录入员.Location = new System.Drawing.Point(667, 63);
            this.txt_录入员.Name = "txt_录入员";
            this.txt_录入员.Size = new System.Drawing.Size(155, 21);
            this.txt_录入员.TabIndex = 12;
            this.txt_录入员.Validated += new System.EventHandler(this.txt_录入员_Validated);
            // 
            // myLable6
            // 
            this.myLable6.Location = new System.Drawing.Point(566, 67);
            this.myLable6.Name = "myLable6";
            this.myLable6.Size = new System.Drawing.Size(104, 12);
            this.myLable6.TabIndex = 11;
            this.myLable6.Text = "录入员：";
            this.myLable6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myContextDetails
            // 
            this.myContextDetails.MyDataGridView = this.dataGridViewDetail;
            this.myContextDetails.Name = "myContextDetails";
            this.myContextDetails.Size = new System.Drawing.Size(101, 26);
            // 
            // FormMaterialsOutInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(919, 440);
            this.Name = "FormMaterialsOutInput";
            this.Text = "料件出库";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myTextBox txt_录入员;
        private UniqueDeclarationBaseForm.Controls.myLable myLable6;
        private UniqueDeclarationBaseForm.Controls.myComboBox cbox_电子帐册号;
        private UniqueDeclarationBaseForm.Controls.myLable myLable5;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_制造通知单号;
        private UniqueDeclarationBaseForm.Controls.myLable myLable4;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_摘要;
        private UniqueDeclarationBaseForm.Controls.myLable myLable3;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker date_出库时间;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_出库单号2;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_出库单号1;
        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetails;
    }
}
