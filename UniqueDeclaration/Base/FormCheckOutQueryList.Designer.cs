namespace UniqueDeclaration.Base
{
    partial class FormCheckOutQueryList
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
            this.myContextMenuDetails = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextMenuHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myContextMenuDetails
            // 
            this.myContextMenuDetails.MyDataGridView = this.myDataGridViewDetails;
            this.myContextMenuDetails.Name = "myContextMenuDetails";
            this.myContextMenuDetails.Size = new System.Drawing.Size(153, 48);
            // 
            // myContextMenuHead
            // 
            this.myContextMenuHead.MyDataGridView = this.myDataGridViewHead;
            this.myContextMenuHead.Name = "myContextMenuHead";
            this.myContextMenuHead.Size = new System.Drawing.Size(101, 26);
            // 
            // FormCheckOutQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1125, 514);
            this.Name = "FormCheckOutQueryList";
            this.Text = "报关产品申报资料查询";
            this.Load += new System.EventHandler(this.FormCheckOutQueryList_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuDetails;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuHead;
    }
}
