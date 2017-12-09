namespace UniqueDeclaration
{
    partial class FormOrderBOM
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
            this.tabPage3.Margin = new System.Windows.Forms.Padding(5);
            // 
            // tabPage1
            // 
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // tabPage2
            // 
            this.tabPage2.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5);
            // 
            // btnModifyHeadDelete
            // 
            this.btnModifyHeadDelete.Location = new System.Drawing.Point(1340, 301);
            this.btnModifyHeadDelete.Margin = new System.Windows.Forms.Padding(5);
            this.btnModifyHeadDelete.Size = new System.Drawing.Size(103, 28);
            // 
            // btnModifyDetailDelete
            // 
            this.btnModifyDetailDelete.Location = new System.Drawing.Point(1340, 258);
            this.btnModifyDetailDelete.Margin = new System.Windows.Forms.Padding(5);
            this.btnModifyDetailDelete.Size = new System.Drawing.Size(103, 28);
            // 
            // txt_总重
            // 
            this.txt_总重.Location = new System.Drawing.Point(835, 262);
            this.txt_总重.Margin = new System.Windows.Forms.Padding(5);
            this.txt_总重.Size = new System.Drawing.Size(63, 25);
            // 
            // txt_实际总重
            // 
            this.txt_实际总重.Location = new System.Drawing.Point(700, 262);
            this.txt_实际总重.Margin = new System.Windows.Forms.Padding(5);
            this.txt_实际总重.Size = new System.Drawing.Size(63, 25);
            // 
            // myLable2
            // 
            this.myLable2.Location = new System.Drawing.Point(785, 267);
            this.myLable2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            // 
            // myLable1
            // 
            this.myLable1.Location = new System.Drawing.Point(620, 267);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1549, 637);
            // 
            // FormOrderBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1567, 703);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "FormOrderBOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOrderBOM_FormClosing);
            this.Load += new System.EventHandler(this.FormOrderBOM_Load);
            this.Controls.SetChildIndex(this.myTabControl1, 0);
            this.myTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
