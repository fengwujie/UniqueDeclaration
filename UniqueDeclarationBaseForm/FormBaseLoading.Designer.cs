namespace UniqueDeclarationBaseForm
{
    partial class FormBaseLoading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labLoading = new UniqueDeclarationBaseForm.Controls.myLable();
            this.SuspendLayout();
            // 
            // labLoading
            // 
            this.labLoading.BackColor = System.Drawing.Color.Transparent;
            this.labLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labLoading.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labLoading.Location = new System.Drawing.Point(0, 0);
            this.labLoading.Name = "labLoading";
            this.labLoading.Size = new System.Drawing.Size(768, 84);
            this.labLoading.TabIndex = 0;
            this.labLoading.Text = "资料加载中，请稍等......";
            this.labLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormBaseLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(768, 84);
            this.Controls.Add(this.labLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBaseLoading";
            this.Opacity = 0.1D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBaseLoading";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBaseLoading_FormClosing);
            this.Load += new System.EventHandler(this.FormBaseLoading_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.myLable labLoading;
    }
}