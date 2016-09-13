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
            this.btnOuterMaterialTotal = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnMaterialDetails = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnBOMExport = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnDataImport = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myCheckBox1 = new UniqueDeclarationBaseForm.Controls.myCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitContainer1.Size = new System.Drawing.Size(1103, 482);
            this.splitContainer1.SplitterDistance = 309;
            // 
            // myLable1
            // 
            this.myLable1.Size = new System.Drawing.Size(788, 20);
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
            // btnOuterMaterialTotal
            // 
            this.btnOuterMaterialTotal.Location = new System.Drawing.Point(314, 1);
            this.btnOuterMaterialTotal.Name = "btnOuterMaterialTotal";
            this.btnOuterMaterialTotal.Size = new System.Drawing.Size(91, 23);
            this.btnOuterMaterialTotal.TabIndex = 7;
            this.btnOuterMaterialTotal.Text = "出口料件统计";
            this.btnOuterMaterialTotal.UseVisualStyleBackColor = true;
            this.btnOuterMaterialTotal.Click += new System.EventHandler(this.btnOuterMaterialTotal_Click);
            // 
            // btnMaterialDetails
            // 
            this.btnMaterialDetails.Location = new System.Drawing.Point(411, 1);
            this.btnMaterialDetails.Name = "btnMaterialDetails";
            this.btnMaterialDetails.Size = new System.Drawing.Size(77, 23);
            this.btnMaterialDetails.TabIndex = 8;
            this.btnMaterialDetails.Text = "用料明细表";
            this.btnMaterialDetails.UseVisualStyleBackColor = true;
            this.btnMaterialDetails.Click += new System.EventHandler(this.btnMaterialDetails_Click);
            // 
            // btnBOMExport
            // 
            this.btnBOMExport.Location = new System.Drawing.Point(494, 1);
            this.btnBOMExport.Name = "btnBOMExport";
            this.btnBOMExport.Size = new System.Drawing.Size(105, 23);
            this.btnBOMExport.TabIndex = 9;
            this.btnBOMExport.Text = "企业工程BOM导出";
            this.btnBOMExport.UseVisualStyleBackColor = true;
            this.btnBOMExport.Click += new System.EventHandler(this.btnBOMExport_Click);
            // 
            // btnDataImport
            // 
            this.btnDataImport.Location = new System.Drawing.Point(605, 1);
            this.btnDataImport.Name = "btnDataImport";
            this.btnDataImport.Size = new System.Drawing.Size(143, 23);
            this.btnDataImport.TabIndex = 10;
            this.btnDataImport.Text = "电子账册清单数据导入";
            this.btnDataImport.UseVisualStyleBackColor = true;
            this.btnDataImport.Click += new System.EventHandler(this.btnDataImport_Click);
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.AutoSize = true;
            this.myCheckBox1.Location = new System.Drawing.Point(754, 4);
            this.myCheckBox1.Name = "myCheckBox1";
            this.myCheckBox1.Size = new System.Drawing.Size(132, 16);
            this.myCheckBox1.TabIndex = 11;
            this.myCheckBox1.Text = "显示出口成品及商编";
            this.myCheckBox1.UseVisualStyleBackColor = true;
            // 
            // FormPackingListQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1103, 507);
            this.Controls.Add(this.myCheckBox1);
            this.Controls.Add(this.btnDataImport);
            this.Controls.Add(this.btnBOMExport);
            this.Controls.Add(this.btnMaterialDetails);
            this.Controls.Add(this.btnOuterMaterialTotal);
            this.Name = "FormPackingListQueryList";
            this.Text = "装箱单明细查询";
            this.Load += new System.EventHandler(this.FormPackingListQueryList_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnOuterMaterialTotal, 0);
            this.Controls.SetChildIndex(this.btnMaterialDetails, 0);
            this.Controls.SetChildIndex(this.btnBOMExport, 0);
            this.Controls.SetChildIndex(this.btnDataImport, 0);
            this.Controls.SetChildIndex(this.myCheckBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextHead;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetails;
        private UniqueDeclarationBaseForm.Controls.myButton btnOuterMaterialTotal;
        private UniqueDeclarationBaseForm.Controls.myButton btnMaterialDetails;
        private UniqueDeclarationBaseForm.Controls.myButton btnBOMExport;
        private UniqueDeclarationBaseForm.Controls.myButton btnDataImport;
        private UniqueDeclarationBaseForm.Controls.myCheckBox myCheckBox1;
    }
}
