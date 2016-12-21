namespace UniqueDeclaration.Base
{
    partial class FormManualBOM
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_Save = new System.Windows.Forms.ToolStripButton();
            this.tool_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myDataGridViewBOM = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myContextBOM = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewBOM)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_Save,
            this.tool_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(547, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_Save
            // 
            this.tool_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_Save.Image = global::UniqueDeclaration.Properties.Resources.Save_24pxt;
            this.tool_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_Save.Name = "tool_Save";
            this.tool_Save.Size = new System.Drawing.Size(23, 22);
            this.tool_Save.Text = "保存";
            this.tool_Save.Click += new System.EventHandler(this.tool_Save_Click);
            // 
            // tool_Close
            // 
            this.tool_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_Close.Image = global::UniqueDeclaration.Properties.Resources.close_24px;
            this.tool_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_Close.Name = "tool_Close";
            this.tool_Close.Size = new System.Drawing.Size(23, 22);
            this.tool_Close.Text = "关闭";
            this.tool_Close.Click += new System.EventHandler(this.tool_Close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.myDataGridViewBOM);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 427);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "料件组成";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(421, 398);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // myDataGridViewBOM
            // 
            this.myDataGridViewBOM.AllowUserToAddRows = false;
            this.myDataGridViewBOM.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridViewBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridViewBOM.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridViewBOM.Location = new System.Drawing.Point(6, 20);
            this.myDataGridViewBOM.MultiSelect = false;
            this.myDataGridViewBOM.Name = "myDataGridViewBOM";
            this.myDataGridViewBOM.RowTemplate.Height = 23;
            this.myDataGridViewBOM.Size = new System.Drawing.Size(511, 372);
            this.myDataGridViewBOM.TabIndex = 1;
            this.myDataGridViewBOM.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridViewBOM_CellEndEdit);
            this.myDataGridViewBOM.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.myDataGridViewBOM_DataError);
            this.myDataGridViewBOM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myDataGridViewBOM_KeyPress);
            // 
            // myContextBOM
            // 
            this.myContextBOM.MyDataGridView = this.myDataGridViewBOM;
            this.myContextBOM.Name = "myContextBOM";
            this.myContextBOM.Size = new System.Drawing.Size(101, 26);
            // 
            // FormManualBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 467);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormManualBOM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormManualBOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManualBOM_FormClosing);
            this.Load += new System.EventHandler(this.FormManualBOM_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewBOM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_Save;
        private System.Windows.Forms.ToolStripButton tool_Close;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridViewBOM;
        private System.Windows.Forms.GroupBox groupBox1;
        private UniqueDeclarationBaseForm.Controls.myButton btnDelete;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextBOM;
    }
}