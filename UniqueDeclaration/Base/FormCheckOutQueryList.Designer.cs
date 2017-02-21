namespace UniqueDeclaration.Base
{
    partial class FormCheckOutQueryList
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
            this.myContextMenuDetails = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextMenuHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.lab_ImportScale = new UniqueDeclarationBaseForm.Controls.myLable();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // myLable1
            // 
            this.myLable1.Text = "报关材料明细表";
            // 
            // myContextMenuDetails
            // 
            this.myContextMenuDetails.MyDataGridView = this.myDataGridViewDetails;
            this.myContextMenuDetails.Name = "myContextMenuDetails";
            this.myContextMenuDetails.Size = new System.Drawing.Size(101, 26);
            // 
            // myContextMenuHead
            // 
            this.myContextMenuHead.MyDataGridView = this.myDataGridViewHead;
            this.myContextMenuHead.Name = "myContextMenuHead";
            this.myContextMenuHead.Size = new System.Drawing.Size(101, 26);
            // 
            // lab_ImportScale
            // 
            this.lab_ImportScale.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_ImportScale.ForeColor = System.Drawing.Color.Blue;
            this.lab_ImportScale.Location = new System.Drawing.Point(3, 3);
            this.lab_ImportScale.Name = "lab_ImportScale";
            this.lab_ImportScale.Size = new System.Drawing.Size(305, 20);
            this.lab_ImportScale.TabIndex = 7;
            this.lab_ImportScale.Text = "数据正在处理，请耐心等待，现已完成 ";
            this.lab_ImportScale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.lab_ImportScale);
            this.panel2.Location = new System.Drawing.Point(361, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 25);
            this.panel2.TabIndex = 8;
            this.panel2.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(314, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(210, 19);
            this.progressBar1.TabIndex = 8;
            // 
            // FormCheckOutQueryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1125, 514);
            this.Controls.Add(this.panel2);
            this.Name = "FormCheckOutQueryList";
            this.Text = "报关产品申报资料查询";
            this.Load += new System.EventHandler(this.FormCheckOutQueryList_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuDetails;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuHead;
        private UniqueDeclarationBaseForm.Controls.myLable lab_ImportScale;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
