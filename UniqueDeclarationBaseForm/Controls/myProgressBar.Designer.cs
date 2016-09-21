namespace UniqueDeclarationBaseForm.Controls
{
    partial class myProgressBar
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Blue;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.ForeColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(402, 30);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Value = 50;
            // 
            // myLable1
            // 
            this.myLable1.BackColor = System.Drawing.Color.Transparent;
            this.myLable1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myLable1.Dock = System.Windows.Forms.DockStyle.Right;
            this.myLable1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.myLable1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myLable1.ForeColor = System.Drawing.Color.Blue;
            this.myLable1.Location = new System.Drawing.Point(402, 0);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(30, 30);
            this.myLable1.TabIndex = 1;
            this.myLable1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.myLable1);
            this.Name = "myProgressBar";
            this.Size = new System.Drawing.Size(432, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private myLable myLable1;
    }
}
