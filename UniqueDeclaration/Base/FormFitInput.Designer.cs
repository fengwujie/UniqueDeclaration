namespace UniqueDeclaration.Base
{
    partial class FormFitInput
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool1_Add = new System.Windows.Forms.ToolStripButton();
            this.tool1_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClone = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool1_Close = new System.Windows.Forms.ToolStripButton();
            this.tool1_BOM = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool1_Add,
            this.tool1_Save,
            this.toolStripSeparator2,
            this.btnClone,
            this.toolStripSeparator1,
            this.tool1_BOM,
            this.toolStripSeparator3,
            this.tool1_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(488, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool1_Add
            // 
            this.tool1_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Add.Image = global::UniqueDeclaration.Properties.Resources.Add_24px;
            this.tool1_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Add.Name = "tool1_Add";
            this.tool1_Add.Size = new System.Drawing.Size(23, 22);
            this.tool1_Add.Text = "新增";
            // 
            // tool1_Save
            // 
            this.tool1_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Save.Image = global::UniqueDeclaration.Properties.Resources.Save_24pxt;
            this.tool1_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Save.Name = "tool1_Save";
            this.tool1_Save.Size = new System.Drawing.Size(23, 22);
            this.tool1_Save.Text = "保存";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClone
            // 
            this.btnClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClone.Image = global::UniqueDeclaration.Properties.Resources.copy_24px;
            this.btnClone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(23, 22);
            this.btnClone.Text = "克隆";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool1_Close
            // 
            this.tool1_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_Close.Image = global::UniqueDeclaration.Properties.Resources.close_24px;
            this.tool1_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_Close.Name = "tool1_Close";
            this.tool1_Close.Size = new System.Drawing.Size(23, 22);
            this.tool1_Close.Text = "关闭";
            // 
            // tool1_BOM
            // 
            this.tool1_BOM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool1_BOM.Image = global::UniqueDeclaration.Properties.Resources.structure_24px;
            this.tool1_BOM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1_BOM.Name = "tool1_BOM";
            this.tool1_BOM.Size = new System.Drawing.Size(23, 22);
            this.tool1_BOM.Text = "配件组成";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // FormFitInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(488, 440);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormFitInput";
            this.Text = "配件资料录入";
            this.Load += new System.EventHandler(this.FormFitInput_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool1_Add;
        private System.Windows.Forms.ToolStripButton tool1_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tool1_BOM;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tool1_Close;
    }
}
