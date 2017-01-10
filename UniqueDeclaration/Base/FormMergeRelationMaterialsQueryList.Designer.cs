namespace UniqueDeclaration.Base
{
    partial class FormMergeRelationMaterialsQueryList
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGridViewDetails2 = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myContextHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextDetails = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextDetails2 = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.btnBaseDataExport = new UniqueDeclarationBaseForm.Controls.myButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewDetails2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.SplitterDistance = 126;
            // 
            // myLable1
            // 
            this.myLable1.Text = "归并前料件清单";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.myDataGridViewDetails2);
            this.panel2.Controls.Add(this.myLable2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1123, 203);
            this.panel2.TabIndex = 2;
            // 
            // myDataGridViewDetails2
            // 
            this.myDataGridViewDetails2.AllowUserToAddRows = false;
            this.myDataGridViewDetails2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridViewDetails2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridViewDetails2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridViewDetails2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridViewDetails2.Location = new System.Drawing.Point(0, 20);
            this.myDataGridViewDetails2.MultiSelect = false;
            this.myDataGridViewDetails2.Name = "myDataGridViewDetails2";
            this.myDataGridViewDetails2.ReadOnly = true;
            this.myDataGridViewDetails2.RowTemplate.Height = 23;
            this.myDataGridViewDetails2.Size = new System.Drawing.Size(1121, 181);
            this.myDataGridViewDetails2.TabIndex = 1;
            // 
            // myLable2
            // 
            this.myLable2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myLable2.Location = new System.Drawing.Point(0, 0);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(1121, 20);
            this.myLable2.TabIndex = 0;
            this.myLable2.Text = "归并前料件清单明细";
            this.myLable2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // myContextDetails2
            // 
            this.myContextDetails2.MyDataGridView = this.myDataGridViewDetails2;
            this.myContextDetails2.Name = "myContextMenuStripCell3";
            this.myContextDetails2.Size = new System.Drawing.Size(101, 26);
            // 
            // btnBaseDataExport
            // 
            this.btnBaseDataExport.Location = new System.Drawing.Point(288, 2);
            this.btnBaseDataExport.Name = "btnBaseDataExport";
            this.btnBaseDataExport.Size = new System.Drawing.Size(109, 23);
            this.btnBaseDataExport.TabIndex = 8;
            this.btnBaseDataExport.Text = "基本数据导出";
            this.btnBaseDataExport.UseVisualStyleBackColor = true;
            this.btnBaseDataExport.Click += new System.EventHandler(this.btnBaseDataExport_Click);
            // 
            // FormMergeRelationMaterialsQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1125, 514);
            this.Controls.Add(this.btnBaseDataExport);
            this.Name = "FormMergeRelationMaterialsQueryList";
            this.Text = "商品归并关系表（料件）查询";
            this.Load += new System.EventHandler(this.FormMergeRelationMaterialsQueryList_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnBaseDataExport, 0);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewDetails2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridViewDetails2;
        private UniqueDeclarationBaseForm.Controls.myLable myLable2;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextHead;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetails;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextDetails2;
        private UniqueDeclarationBaseForm.Controls.myButton btnBaseDataExport;
    }
}
