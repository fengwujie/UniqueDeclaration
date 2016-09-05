namespace UniqueDeclaration
{
    partial class FormMaterialsOutQueryList
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
            this.myContextHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextDetails = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.btnCheckIn = new UniqueDeclarationBaseForm.Controls.myButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(997, 533);
            this.splitContainer1.SplitterDistance = 245;
            // 
            // myLable1
            // 
            this.myLable1.Size = new System.Drawing.Size(995, 24);
            this.myLable1.Text = "出库单明细";
            // 
            // myContextHead
            // 
            this.myContextHead.MyDataGridView = this.myDataGridViewHead;
            this.myContextHead.Name = "myContextHead";
            this.myContextHead.Size = new System.Drawing.Size(101, 26);
            // 
            // myContextDetails
            // 
            this.myContextDetails.MyDataGridView = this.myDataGridViewDetails;
            this.myContextDetails.Name = "myContextDetails";
            this.myContextDetails.Size = new System.Drawing.Size(101, 26);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(681, 2);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(75, 23);
            this.btnCheckIn.TabIndex = 7;
            this.btnCheckIn.Text = "进口料件核查";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // FormMaterialsOutQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(997, 558);
            this.Controls.Add(this.btnCheckIn);
            this.Name = "FormMaterialsOutQueryList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "料件出库查询";
            this.Load += new System.EventHandler(this.FormMaterialsOutQueryList_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnCheckIn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextHead;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetails;
        private UniqueDeclarationBaseForm.Controls.myButton btnCheckIn;
    }
}
