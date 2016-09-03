namespace UniqueDeclarationBaseForm.Controls
{
    partial class myContextMenuStripCell
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CopyCell = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // CopyCell
            // 
            this.CopyCell.Name = "CopyCell";
            this.CopyCell.Size = new System.Drawing.Size(100, 22);
            this.CopyCell.Text = "复制";
            this.CopyCell.Click += new System.EventHandler(this.CopyCell_Click);
            // 
            // myContextMenuStripCell
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyCell});
            this.Size = new System.Drawing.Size(101, 26);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolStripMenuItem CopyCell;

    }
}
