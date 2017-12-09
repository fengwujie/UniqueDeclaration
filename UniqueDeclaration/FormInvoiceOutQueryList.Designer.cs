namespace UniqueDeclaration
{
    partial class FormInvoiceOutQueryList
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
            this.myDataGridViewDetails2 = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myContextHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextDetails = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextDetails2 = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.btnOutContact = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnMoneyContact = new UniqueDeclarationBaseForm.Controls.myButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewDetails2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.myDataGridViewDetails2);
            this.splitContainer1.SplitterDistance = 163;
            // 
            // myLable1
            // 
            this.myLable1.Visible = false;
            // 
            // myDataGridViewDetails2
            // 
            this.myDataGridViewDetails2.AllowUserToAddRows = false;
            this.myDataGridViewDetails2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridViewDetails2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridViewDetails2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myDataGridViewDetails2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridViewDetails2.Location = new System.Drawing.Point(0, 260);
            this.myDataGridViewDetails2.Margin = new System.Windows.Forms.Padding(4);
            this.myDataGridViewDetails2.MultiSelect = false;
            this.myDataGridViewDetails2.Name = "myDataGridViewDetails2";
            this.myDataGridViewDetails2.ReadOnly = true;
            this.myDataGridViewDetails2.RowTemplate.Height = 23;
            this.myDataGridViewDetails2.Size = new System.Drawing.Size(1498, 185);
            this.myDataGridViewDetails2.TabIndex = 2;
            // 
            // myContextHead
            // 
            this.myContextHead.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.myContextHead.MyDataGridView = this.myDataGridViewHead;
            this.myContextHead.Name = "myContextHead";
            this.myContextHead.Size = new System.Drawing.Size(115, 30);
            // 
            // myContextDetails
            // 
            this.myContextDetails.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.myContextDetails.MyDataGridView = this.myDataGridViewDetails;
            this.myContextDetails.Name = "myContextDetails";
            this.myContextDetails.Size = new System.Drawing.Size(115, 30);
            // 
            // myContextDetails2
            // 
            this.myContextDetails2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.myContextDetails2.MyDataGridView = null;
            this.myContextDetails2.Name = "myContextDetails2";
            this.myContextDetails2.Size = new System.Drawing.Size(115, 30);
            // 
            // btnOutContact
            // 
            this.btnOutContact.Location = new System.Drawing.Point(355, -1);
            this.btnOutContact.Name = "btnOutContact";
            this.btnOutContact.Size = new System.Drawing.Size(93, 29);
            this.btnOutContact.TabIndex = 8;
            this.btnOutContact.Text = "出口合同";
            this.btnOutContact.UseVisualStyleBackColor = true;
            this.btnOutContact.Click += new System.EventHandler(this.btnOutContact_Click);
            // 
            // btnMoneyContact
            // 
            this.btnMoneyContact.Location = new System.Drawing.Point(470, -1);
            this.btnMoneyContact.Name = "btnMoneyContact";
            this.btnMoneyContact.Size = new System.Drawing.Size(92, 29);
            this.btnMoneyContact.TabIndex = 9;
            this.btnMoneyContact.Text = "财务合同";
            this.btnMoneyContact.UseVisualStyleBackColor = true;
            this.btnMoneyContact.Click += new System.EventHandler(this.btnMoneyContact_Click);
            // 
            // FormInvoiceOutQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1500, 642);
            this.Controls.Add(this.btnMoneyContact);
            this.Controls.Add(this.btnOutContact);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "FormInvoiceOutQueryList";
            this.Text = "InvoiceOut";
            this.Load += new System.EventHandler(this.FormInvoiceOutQueryList_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnOutContact, 0);
            this.Controls.SetChildIndex(this.btnMoneyContact, 0);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewDetails2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridViewDetails2;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextHead;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetails;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetails2;
        private UniqueDeclarationBaseForm.Controls.myButton btnOutContact;
        private UniqueDeclarationBaseForm.Controls.myButton btnMoneyContact;
    }
}
