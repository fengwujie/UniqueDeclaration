namespace UniqueDeclaration.Base
{
    partial class FormMaterialsQueryCondition
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
            this.txt_料件型号 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.txt_料件名 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable3 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.cbox_料件类别 = new UniqueDeclarationBaseForm.Controls.myComboBox();
            this.cbox_报关类别 = new UniqueDeclarationBaseForm.Controls.myComboBox();
            this.myLable4 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.txt_料件存放位置 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.myLable5 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.cbox_采购区域 = new UniqueDeclarationBaseForm.Controls.myComboBox();
            this.myLable6 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.datetime_料件建档日期2 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.datetime_料件建档日期1 = new UniqueDeclarationBaseForm.Controls.myDateTimePicker();
            this.myLable7 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable8 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myLable7);
            this.groupBox1.Controls.Add(this.myLable8);
            this.groupBox1.Controls.Add(this.datetime_料件建档日期2);
            this.groupBox1.Controls.Add(this.datetime_料件建档日期1);
            this.groupBox1.Controls.Add(this.cbox_采购区域);
            this.groupBox1.Controls.Add(this.myLable6);
            this.groupBox1.Controls.Add(this.txt_料件存放位置);
            this.groupBox1.Controls.Add(this.myLable5);
            this.groupBox1.Controls.Add(this.cbox_报关类别);
            this.groupBox1.Controls.Add(this.myLable4);
            this.groupBox1.Controls.Add(this.cbox_料件类别);
            this.groupBox1.Controls.Add(this.myLable3);
            this.groupBox1.Controls.Add(this.txt_料件名);
            this.groupBox1.Controls.Add(this.myLable2);
            this.groupBox1.Controls.Add(this.txt_料件型号);
            this.groupBox1.Controls.Add(this.myLable1);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Size = new System.Drawing.Size(284, 255);
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.Location = new System.Drawing.Point(336, 108);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(314, 22);
            this.btnOK.Size = new System.Drawing.Size(94, 26);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(314, 66);
            this.btnCancel.Size = new System.Drawing.Size(94, 26);
            // 
            // myLable1
            // 
            this.myLable1.Location = new System.Drawing.Point(6, 30);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(80, 23);
            this.myLable1.TabIndex = 0;
            this.myLable1.Text = "型号：";
            this.myLable1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_料件型号
            // 
            this.txt_料件型号.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_料件型号.Location = new System.Drawing.Point(92, 30);
            this.txt_料件型号.Name = "txt_料件型号";
            this.txt_料件型号.Size = new System.Drawing.Size(173, 21);
            this.txt_料件型号.TabIndex = 1;
            this.txt_料件型号.Tag = "料件型号";
            // 
            // txt_料件名
            // 
            this.txt_料件名.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_料件名.Location = new System.Drawing.Point(92, 58);
            this.txt_料件名.Name = "txt_料件名";
            this.txt_料件名.Size = new System.Drawing.Size(173, 21);
            this.txt_料件名.TabIndex = 3;
            this.txt_料件名.Tag = "料件型号";
            // 
            // myLable2
            // 
            this.myLable2.Location = new System.Drawing.Point(6, 58);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(80, 23);
            this.myLable2.TabIndex = 2;
            this.myLable2.Text = "料件名：";
            this.myLable2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myLable3
            // 
            this.myLable3.Location = new System.Drawing.Point(6, 84);
            this.myLable3.Name = "myLable3";
            this.myLable3.Size = new System.Drawing.Size(80, 23);
            this.myLable3.TabIndex = 4;
            this.myLable3.Text = "料件类别：";
            this.myLable3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbox_料件类别
            // 
            this.cbox_料件类别.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_料件类别.FormattingEnabled = true;
            this.cbox_料件类别.Location = new System.Drawing.Point(92, 86);
            this.cbox_料件类别.Name = "cbox_料件类别";
            this.cbox_料件类别.Size = new System.Drawing.Size(173, 20);
            this.cbox_料件类别.TabIndex = 5;
            this.cbox_料件类别.Tag = "string,料件类别";
            // 
            // cbox_报关类别
            // 
            this.cbox_报关类别.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_报关类别.FormattingEnabled = true;
            this.cbox_报关类别.Location = new System.Drawing.Point(92, 112);
            this.cbox_报关类别.Name = "cbox_报关类别";
            this.cbox_报关类别.Size = new System.Drawing.Size(173, 20);
            this.cbox_报关类别.TabIndex = 7;
            this.cbox_报关类别.Tag = "string,报关类别";
            // 
            // myLable4
            // 
            this.myLable4.Location = new System.Drawing.Point(6, 110);
            this.myLable4.Name = "myLable4";
            this.myLable4.Size = new System.Drawing.Size(80, 23);
            this.myLable4.TabIndex = 6;
            this.myLable4.Text = "报关类别：";
            this.myLable4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_料件存放位置
            // 
            this.txt_料件存放位置.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.txt_料件存放位置.Location = new System.Drawing.Point(92, 138);
            this.txt_料件存放位置.Name = "txt_料件存放位置";
            this.txt_料件存放位置.Size = new System.Drawing.Size(173, 21);
            this.txt_料件存放位置.TabIndex = 9;
            this.txt_料件存放位置.Tag = "料件存放位置";
            // 
            // myLable5
            // 
            this.myLable5.Location = new System.Drawing.Point(6, 138);
            this.myLable5.Name = "myLable5";
            this.myLable5.Size = new System.Drawing.Size(80, 23);
            this.myLable5.TabIndex = 8;
            this.myLable5.Text = "存放位置：";
            this.myLable5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbox_采购区域
            // 
            this.cbox_采购区域.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_采购区域.FormattingEnabled = true;
            this.cbox_采购区域.Location = new System.Drawing.Point(92, 165);
            this.cbox_采购区域.Name = "cbox_采购区域";
            this.cbox_采购区域.Size = new System.Drawing.Size(173, 20);
            this.cbox_采购区域.TabIndex = 11;
            this.cbox_采购区域.Tag = "string,采购区域";
            // 
            // myLable6
            // 
            this.myLable6.Location = new System.Drawing.Point(6, 163);
            this.myLable6.Name = "myLable6";
            this.myLable6.Size = new System.Drawing.Size(80, 23);
            this.myLable6.TabIndex = 10;
            this.myLable6.Text = "采购区域：";
            this.myLable6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datetime_料件建档日期2
            // 
            this.datetime_料件建档日期2.Checked = false;
            this.datetime_料件建档日期2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.datetime_料件建档日期2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_料件建档日期2.Location = new System.Drawing.Point(92, 218);
            this.datetime_料件建档日期2.Name = "datetime_料件建档日期2";
            this.datetime_料件建档日期2.ShowCheckBox = true;
            this.datetime_料件建档日期2.Size = new System.Drawing.Size(173, 21);
            this.datetime_料件建档日期2.TabIndex = 50;
            this.datetime_料件建档日期2.Tag = "2,料件建档日期";
            // 
            // datetime_料件建档日期1
            // 
            this.datetime_料件建档日期1.Checked = false;
            this.datetime_料件建档日期1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.datetime_料件建档日期1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_料件建档日期1.Location = new System.Drawing.Point(92, 191);
            this.datetime_料件建档日期1.Name = "datetime_料件建档日期1";
            this.datetime_料件建档日期1.ShowCheckBox = true;
            this.datetime_料件建档日期1.Size = new System.Drawing.Size(173, 21);
            this.datetime_料件建档日期1.TabIndex = 49;
            this.datetime_料件建档日期1.Tag = "1,料件建档日期";
            // 
            // myLable7
            // 
            this.myLable7.Location = new System.Drawing.Point(6, 216);
            this.myLable7.Name = "myLable7";
            this.myLable7.Size = new System.Drawing.Size(80, 23);
            this.myLable7.TabIndex = 52;
            this.myLable7.Text = "到：";
            this.myLable7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myLable8
            // 
            this.myLable8.Location = new System.Drawing.Point(6, 191);
            this.myLable8.Name = "myLable8";
            this.myLable8.Size = new System.Drawing.Size(80, 23);
            this.myLable8.TabIndex = 51;
            this.myLable8.Text = "建档日期：";
            this.myLable8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMaterialsQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(426, 278);
            this.Name = "FormMaterialsQueryCondition";
            this.Text = "【料件资料】查询条件";
            this.Load += new System.EventHandler(this.FormMaterialsQueryList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myLable myLable1;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_料件型号;
        private UniqueDeclarationBaseForm.Controls.myComboBox cbox_采购区域;
        private UniqueDeclarationBaseForm.Controls.myLable myLable6;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_料件存放位置;
        private UniqueDeclarationBaseForm.Controls.myLable myLable5;
        private UniqueDeclarationBaseForm.Controls.myComboBox cbox_报关类别;
        private UniqueDeclarationBaseForm.Controls.myLable myLable4;
        private UniqueDeclarationBaseForm.Controls.myComboBox cbox_料件类别;
        private UniqueDeclarationBaseForm.Controls.myLable myLable3;
        private UniqueDeclarationBaseForm.Controls.myTextBox txt_料件名;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myLable myLable7;
        private UniqueDeclarationBaseForm.Controls.myLable myLable8;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker datetime_料件建档日期2;
        private UniqueDeclarationBaseForm.Controls.myDateTimePicker datetime_料件建档日期1;
    }
}
