namespace UniqueDeclaration
{
    partial class FormFinishedProductOutBOM
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnModifyBeforeDetailDelete = new UniqueDeclarationBaseForm.Controls.myButton();
            this.dgv_ModifyBeforeDetail = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myContextModifyBeforeDetail = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyBeforeDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.SetChildIndex(this.groupBox5, 0);
            this.tabPage1.Controls.SetChildIndex(this.groupBox1, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(1131, 295);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnModifyBeforeDetailDelete);
            this.groupBox5.Controls.Add(this.dgv_ModifyBeforeDetail);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 298);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1131, 182);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "报关料件明细";
            // 
            // btnModifyBeforeDetailDelete
            // 
            this.btnModifyBeforeDetailDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifyBeforeDetailDelete.Location = new System.Drawing.Point(985, 159);
            this.btnModifyBeforeDetailDelete.Name = "btnModifyBeforeDetailDelete";
            this.btnModifyBeforeDetailDelete.Size = new System.Drawing.Size(75, 23);
            this.btnModifyBeforeDetailDelete.TabIndex = 1;
            this.btnModifyBeforeDetailDelete.Text = "删除";
            this.btnModifyBeforeDetailDelete.UseVisualStyleBackColor = true;
            this.btnModifyBeforeDetailDelete.Click += new System.EventHandler(this.btnModifyBeforeDetailDelete_Click);
            // 
            // dgv_ModifyBeforeDetail
            // 
            this.dgv_ModifyBeforeDetail.AllowUserToAddRows = false;
            this.dgv_ModifyBeforeDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ModifyBeforeDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ModifyBeforeDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ModifyBeforeDetail.Location = new System.Drawing.Point(2, 18);
            this.dgv_ModifyBeforeDetail.Name = "dgv_ModifyBeforeDetail";
            this.dgv_ModifyBeforeDetail.RowTemplate.Height = 23;
            this.dgv_ModifyBeforeDetail.Size = new System.Drawing.Size(1126, 138);
            this.dgv_ModifyBeforeDetail.TabIndex = 0;
            this.dgv_ModifyBeforeDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ModifyBeforeDetail_CellEndEdit);
            this.dgv_ModifyBeforeDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_ModifyBeforeDetail_DataError);
            this.dgv_ModifyBeforeDetail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_ModifyBeforeDetail_KeyPress);
            // 
            // myContextModifyBeforeDetail
            // 
            this.myContextModifyBeforeDetail.MyDataGridView = this.dgv_ModifyBeforeDetail;
            this.myContextModifyBeforeDetail.Name = "myContextModifyBeforeDetail";
            this.myContextModifyBeforeDetail.Size = new System.Drawing.Size(101, 26);
            // 
            // FormFinishedProductOutBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1145, 534);
            this.Name = "FormFinishedProductOutBOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFinishedProductOutBOM_FormClosing);
            this.Load += new System.EventHandler(this.FormFinishedProductOutBOM_Load);
            this.Controls.SetChildIndex(this.myTabControl1, 0);
            this.myTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyBeforeDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private UniqueDeclarationBaseForm.Controls.myDataGridView dgv_ModifyBeforeDetail;
        private UniqueDeclarationBaseForm.Controls.myButton btnModifyBeforeDetailDelete;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextModifyBeforeDetail;
    }
}
