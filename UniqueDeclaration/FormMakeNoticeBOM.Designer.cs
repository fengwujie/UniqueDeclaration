namespace UniqueDeclaration
{
    partial class FormMakeNoticeBOM
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
            this.myTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // myTabControl1
            // 
            this.myTabControl1.Size = new System.Drawing.Size(1527, 641);
            this.myTabControl1.SelectedIndexChanged += new System.EventHandler(this.myTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPage1.Size = new System.Drawing.Size(1519, 612);
            // 
            // tabPage2
            // 
            this.tabPage2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPage2.Size = new System.Drawing.Size(1519, 612);
            // 
            // btnModifyHeadDelete
            // 
            this.btnModifyHeadDelete.Location = new System.Drawing.Point(1366, 14);
            // 
            // btnModifyDetailDelete
            // 
            this.btnModifyDetailDelete.Location = new System.Drawing.Point(1366, 12);
            // 
            // txt_总重
            // 
            this.txt_总重.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // txt_实际总重
            // 
            this.txt_实际总重.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1509, 602);
            // 
            // FormMakeNoticeBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1527, 668);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "FormMakeNoticeBOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMakeNoticeBOM_FormClosing);
            this.Load += new System.EventHandler(this.FormMakeNoticeBOM_Load);
            this.Controls.SetChildIndex(this.myTabControl1, 0);
            this.myTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
