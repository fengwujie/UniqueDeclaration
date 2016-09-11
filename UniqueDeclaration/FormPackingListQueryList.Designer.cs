namespace UniqueDeclaration
{
    partial class FormPackingListQueryList
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitContainer1.SplitterDistance = 258;
            // 
            // myLable1
            // 
            this.myLable1.Size = new System.Drawing.Size(655, 20);
            this.myLable1.Text = "装箱单明细";
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
            // FormPackingListQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(919, 440);
            this.Name = "FormPackingListQueryList";
            this.Text = "装箱单明细查询";
            this.Load += new System.EventHandler(this.FormPackingListQueryList_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextHead;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetails;
    }
}
