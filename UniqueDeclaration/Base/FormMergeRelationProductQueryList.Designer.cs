namespace UniqueDeclaration.Base
{
    partial class FormMergeRelationProductQueryList
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
            this.btnBaseDataExport = new UniqueDeclarationBaseForm.Controls.myButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myLable1
            // 
            this.myLable1.Text = "归并前成品清单";
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
            // btnBaseDataExport
            // 
            this.btnBaseDataExport.Location = new System.Drawing.Point(288, 2);
            this.btnBaseDataExport.Name = "btnBaseDataExport";
            this.btnBaseDataExport.Size = new System.Drawing.Size(109, 23);
            this.btnBaseDataExport.TabIndex = 9;
            this.btnBaseDataExport.Text = "基本数据导出";
            this.btnBaseDataExport.UseVisualStyleBackColor = true;
            this.btnBaseDataExport.Click += new System.EventHandler(this.btnBaseDataExport_Click);
            // 
            // FormMergeRelationProductQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1125, 514);
            this.Controls.Add(this.btnBaseDataExport);
            this.Name = "FormMergeRelationProductQueryList";
            this.Text = "商品归并关系表（成品）查询";
            this.Load += new System.EventHandler(this.FormMergeRelationProductQueryList_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnBaseDataExport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextHead;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetails;
        private UniqueDeclarationBaseForm.Controls.myButton btnBaseDataExport;
    }
}
