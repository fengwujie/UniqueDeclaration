namespace UniqueDeclaration
{
    partial class FormTest
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStripCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyCell = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.myProgressBar1 = new UniqueDeclarationBaseForm.Controls.myProgressBar();
            this.myButton4 = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myButton3 = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myDataGridView1 = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.订单号码2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myContextMenuStripCell1 = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.客户代码2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客户名称2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myButton1 = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myDataGridView2 = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.订单号码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myContextMenuStripCell2 = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.客户代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客户名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myButton2 = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myTextBox1 = new UniqueDeclarationBaseForm.Controls.myTextBox();
            this.contextMenuStripCell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripCell
            // 
            this.contextMenuStripCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyCell});
            this.contextMenuStripCell.Name = "contextMenuStripCell";
            this.contextMenuStripCell.Size = new System.Drawing.Size(101, 26);
            // 
            // CopyCell
            // 
            this.CopyCell.Name = "CopyCell";
            this.CopyCell.Size = new System.Drawing.Size(100, 22);
            this.CopyCell.Text = "复制";
            this.CopyCell.Click += new System.EventHandler(this.CopyCell_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 42);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.myDataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.myButton1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.myDataGridView2);
            this.splitContainer1.Panel2.Controls.Add(this.myButton2);
            this.splitContainer1.Size = new System.Drawing.Size(818, 281);
            this.splitContainer1.SplitterDistance = 420;
            this.splitContainer1.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(559, 387);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Value = 50;
            // 
            // myProgressBar1
            // 
            this.myProgressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.myProgressBar1.Location = new System.Drawing.Point(26, 367);
            this.myProgressBar1.Maximum = 0;
            this.myProgressBar1.Name = "myProgressBar1";
            this.myProgressBar1.Size = new System.Drawing.Size(434, 24);
            this.myProgressBar1.Step = 0;
            this.myProgressBar1.TabIndex = 13;
            // 
            // myButton4
            // 
            this.myButton4.ContextMenuStrip = this.contextMenuStripCell;
            this.myButton4.Location = new System.Drawing.Point(26, 337);
            this.myButton4.Name = "myButton4";
            this.myButton4.Size = new System.Drawing.Size(75, 23);
            this.myButton4.TabIndex = 10;
            this.myButton4.Text = "进度条";
            this.myButton4.UseVisualStyleBackColor = true;
            this.myButton4.Click += new System.EventHandler(this.myButton4_Click);
            // 
            // myButton3
            // 
            this.myButton3.ContextMenuStrip = this.contextMenuStripCell;
            this.myButton3.Location = new System.Drawing.Point(559, 337);
            this.myButton3.Name = "myButton3";
            this.myButton3.Size = new System.Drawing.Size(130, 23);
            this.myButton3.TabIndex = 6;
            this.myButton3.Text = "代码创建进度条";
            this.myButton3.UseVisualStyleBackColor = true;
            this.myButton3.Click += new System.EventHandler(this.myButton3_Click);
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.订单号码2,
            this.客户代码2,
            this.客户名称2});
            this.myDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridView1.Location = new System.Drawing.Point(29, 29);
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.RowTemplate.Height = 23;
            this.myDataGridView1.Size = new System.Drawing.Size(383, 239);
            this.myDataGridView1.TabIndex = 1;
            // 
            // 订单号码2
            // 
            this.订单号码2.ContextMenuStrip = this.myContextMenuStripCell1;
            this.订单号码2.DataPropertyName = "订单号码";
            this.订单号码2.HeaderText = "订单号码2";
            this.订单号码2.Name = "订单号码2";
            // 
            // myContextMenuStripCell1
            // 
            this.myContextMenuStripCell1.MyDataGridView = this.myDataGridView1;
            this.myContextMenuStripCell1.Name = "myContextMenuStripCell1";
            this.myContextMenuStripCell1.Size = new System.Drawing.Size(101, 26);
            // 
            // 客户代码2
            // 
            this.客户代码2.ContextMenuStrip = this.myContextMenuStripCell1;
            this.客户代码2.DataPropertyName = "客户代码";
            this.客户代码2.HeaderText = "客户代码2";
            this.客户代码2.Name = "客户代码2";
            // 
            // 客户名称2
            // 
            this.客户名称2.ContextMenuStrip = this.myContextMenuStripCell1;
            this.客户名称2.DataPropertyName = "客户名称";
            this.客户名称2.HeaderText = "客户名称2";
            this.客户名称2.Name = "客户名称2";
            // 
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(65, 0);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(75, 23);
            this.myButton1.TabIndex = 0;
            this.myButton1.Text = "myButton1";
            this.myButton1.UseVisualStyleBackColor = true;
            this.myButton1.Click += new System.EventHandler(this.myButton1_Click);
            // 
            // myDataGridView2
            // 
            this.myDataGridView2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.myDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.订单号码,
            this.客户代码,
            this.客户名称});
            this.myDataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.myDataGridView2.Location = new System.Drawing.Point(15, 53);
            this.myDataGridView2.Name = "myDataGridView2";
            this.myDataGridView2.RowTemplate.Height = 23;
            this.myDataGridView2.Size = new System.Drawing.Size(308, 215);
            this.myDataGridView2.TabIndex = 2;
            // 
            // 订单号码
            // 
            this.订单号码.ContextMenuStrip = this.myContextMenuStripCell2;
            this.订单号码.DataPropertyName = "订单号码";
            this.订单号码.HeaderText = "订单号码";
            this.订单号码.Name = "订单号码";
            this.订单号码.ReadOnly = true;
            // 
            // myContextMenuStripCell2
            // 
            this.myContextMenuStripCell2.MyDataGridView = this.myDataGridView2;
            this.myContextMenuStripCell2.Name = "myContextMenuStripCell2";
            this.myContextMenuStripCell2.Size = new System.Drawing.Size(101, 26);
            // 
            // 客户代码
            // 
            this.客户代码.ContextMenuStrip = this.myContextMenuStripCell2;
            this.客户代码.DataPropertyName = "客户代码";
            this.客户代码.HeaderText = "客户代码";
            this.客户代码.Name = "客户代码";
            // 
            // 客户名称
            // 
            this.客户名称.ContextMenuStrip = this.myContextMenuStripCell2;
            this.客户名称.DataPropertyName = "客户名称";
            this.客户名称.HeaderText = "客户名称";
            this.客户名称.Name = "客户名称";
            // 
            // myButton2
            // 
            this.myButton2.ContextMenuStrip = this.contextMenuStripCell;
            this.myButton2.Location = new System.Drawing.Point(6, 9);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(75, 23);
            this.myButton2.TabIndex = 4;
            this.myButton2.Text = "myButton2";
            this.myButton2.UseVisualStyleBackColor = true;
            // 
            // myTextBox1
            // 
            this.myTextBox1.DataType = UniqueDeclarationBaseForm.Controls.myTextBox.DataTypeEnum.DataTypeString;
            this.myTextBox1.Location = new System.Drawing.Point(118, 337);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.Size = new System.Drawing.Size(100, 21);
            this.myTextBox1.TabIndex = 19;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 438);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.myProgressBar1);
            this.Controls.Add(this.myButton4);
            this.Controls.Add(this.myButton3);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.contextMenuStripCell.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniqueDeclarationBaseForm.Controls.myButton myButton1;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridView1;
        private UniqueDeclarationBaseForm.Controls.myDataGridView myDataGridView2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCell;
        private System.Windows.Forms.ToolStripMenuItem CopyCell;
        private UniqueDeclarationBaseForm.Controls.myButton myButton2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 订单号码2;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuStripCell1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户代码2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户名称2;
        private UniqueDeclarationBaseForm.Controls.myContextMenuStripCell myContextMenuStripCell2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 订单号码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户名称;
        private UniqueDeclarationBaseForm.Controls.myButton myButton3;
        private UniqueDeclarationBaseForm.Controls.myButton myButton4;
        private UniqueDeclarationBaseForm.Controls.myProgressBar myProgressBar1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private UniqueDeclarationBaseForm.Controls.myTextBox myTextBox1;
    }
}