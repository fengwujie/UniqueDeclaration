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
            this.myDataGridViewDetails2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridViewDetails2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridViewDetails2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myDataGridViewDetails2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridViewDetails2.Location = new System.Drawing.Point(0, 172);
            this.myDataGridViewDetails2.Name = "myDataGridViewDetails2";
            this.myDataGridViewDetails2.RowTemplate.Height = 23;
            this.myDataGridViewDetails2.Size = new System.Drawing.Size(1123, 148);
            this.myDataGridViewDetails2.TabIndex = 2;
            // 
            // FormInvoiceOutQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1125, 514);
            this.Name = "FormInvoiceOutQueryList";
            this.Text = "InvoiceOut";
            this.Load += new System.EventHandler(this.FormInvoiceOutQueryList_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewDetails2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridViewDetails2;
    }
}
