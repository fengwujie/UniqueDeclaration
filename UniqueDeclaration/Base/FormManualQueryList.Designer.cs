namespace UniqueDeclaration.Base
{
    partial class FormManualQueryList
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
            this.myDataGridViewDetailsInput = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.myContextMenuHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextMenuDetails = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextMenuDetailsInput = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewDetailsInput)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.SplitterDistance = 160;
            // 
            // myLable1
            // 
            this.myLable1.Text = "出口成品";
            // 
            // myDataGridViewDetailsInput
            // 
            this.myDataGridViewDetailsInput.AllowUserToAddRows = false;
            this.myDataGridViewDetailsInput.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridViewDetailsInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridViewDetailsInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridViewDetailsInput.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridViewDetailsInput.Location = new System.Drawing.Point(0, 19);
            this.myDataGridViewDetailsInput.MultiSelect = false;
            this.myDataGridViewDetailsInput.Name = "myDataGridViewDetailsInput";
            this.myDataGridViewDetailsInput.ReadOnly = true;
            this.myDataGridViewDetailsInput.RowTemplate.Height = 23;
            this.myDataGridViewDetailsInput.Size = new System.Drawing.Size(1123, 144);
            this.myDataGridViewDetailsInput.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGridViewDetailsInput);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1123, 163);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1123, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "进口料件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myContextMenuHead
            // 
            this.myContextMenuHead.MyDataGridView = this.myDataGridViewHead;
            this.myContextMenuHead.Name = "myContextMenuHead";
            this.myContextMenuHead.Size = new System.Drawing.Size(101, 26);
            // 
            // myContextMenuDetails
            // 
            this.myContextMenuDetails.MyDataGridView = this.myDataGridViewDetails;
            this.myContextMenuDetails.Name = "myContextMenuDetails";
            this.myContextMenuDetails.Size = new System.Drawing.Size(101, 26);
            // 
            // myContextMenuDetailsInput
            // 
            this.myContextMenuDetailsInput.MyDataGridView = this.myDataGridViewDetailsInput;
            this.myContextMenuDetailsInput.Name = "myContextMenuDetailsInput";
            this.myContextMenuDetailsInput.Size = new System.Drawing.Size(101, 26);
            // 
            // FormManualQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1125, 514);
            this.Name = "FormManualQueryList";
            this.Text = "手册资料查询";
            this.Load += new System.EventHandler(this.FormManualQueryList_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewDetailsInput)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridViewDetailsInput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuHead;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuDetails;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuDetailsInput;
    }
}
