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
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Size = new System.Drawing.Size(998, 406);
            // 
            // btnModifyHeadDelete
            // 
            this.btnModifyHeadDelete.Location = new System.Drawing.Point(969, 226);
            this.btnModifyHeadDelete.Size = new System.Drawing.Size(77, 22);
            // 
            // btnModifyDetailDelete
            // 
            this.btnModifyDetailDelete.Location = new System.Drawing.Point(969, 191);
            this.btnModifyDetailDelete.Size = new System.Drawing.Size(77, 22);
            // 
            // txt_总重
            // 
            this.txt_总重.Location = new System.Drawing.Point(625, 192);
            this.txt_总重.Size = new System.Drawing.Size(48, 21);
            // 
            // txt_实际总重
            // 
            this.txt_实际总重.Size = new System.Drawing.Size(48, 21);
            // 
            // myLable2
            // 
            this.myLable2.Location = new System.Drawing.Point(587, 196);
            // 
            // FormOrderBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1145, 534);
            this.Name = "FormOrderBOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOrderBOM_FormClosing);
            this.Load += new System.EventHandler(this.FormOrderBOM_Load);
            this.Controls.SetChildIndex(this.myTabControl1, 0);
            this.myTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
