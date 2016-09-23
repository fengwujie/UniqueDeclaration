namespace UniqueDeclarationBaseForm
{
    partial class FormBaseBOMCompare
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_ModifyHead = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.dgv_ModifyDetail = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myLable1 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.myLable2 = new UniqueDeclarationBaseForm.Controls.myLable();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnApplyModifyDetail = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnAppHistoryModifyDetail = new UniqueDeclarationBaseForm.Controls.myButton();
            this.myContextModifyHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextModifyDetail = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgv_HistoryModifyHead = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.dgv_HistoryModifyDetail = new UniqueDeclarationBaseForm.Controls.myDataGridView();
            this.myContextHistoryModifyHead = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            this.myContextHistoryModifyDetail = new UniqueDeclarationBaseForm.Controls.myContextMenuStripCell();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HistoryModifyHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HistoryModifyDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.myLable1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.myLable2);
            this.splitContainer1.Size = new System.Drawing.Size(1109, 523);
            this.splitContainer1.SplitterDistance = 517;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 29);
            this.panel1.TabIndex = 1;
            // 
            // dgv_ModifyHead
            // 
            this.dgv_ModifyHead.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ModifyHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ModifyHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ModifyHead.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ModifyHead.Location = new System.Drawing.Point(0, 0);
            this.dgv_ModifyHead.Name = "dgv_ModifyHead";
            this.dgv_ModifyHead.ReadOnly = true;
            this.dgv_ModifyHead.RowTemplate.Height = 23;
            this.dgv_ModifyHead.Size = new System.Drawing.Size(515, 220);
            this.dgv_ModifyHead.TabIndex = 1;
            // 
            // dgv_ModifyDetail
            // 
            this.dgv_ModifyDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ModifyDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ModifyDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ModifyDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ModifyDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_ModifyDetail.Name = "dgv_ModifyDetail";
            this.dgv_ModifyDetail.ReadOnly = true;
            this.dgv_ModifyDetail.RowTemplate.Height = 23;
            this.dgv_ModifyDetail.Size = new System.Drawing.Size(515, 242);
            this.dgv_ModifyDetail.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnApplyModifyDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 489);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 32);
            this.panel2.TabIndex = 2;
            // 
            // myLable1
            // 
            this.myLable1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myLable1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myLable1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myLable1.ForeColor = System.Drawing.Color.Green;
            this.myLable1.Location = new System.Drawing.Point(0, 0);
            this.myLable1.Name = "myLable1";
            this.myLable1.Size = new System.Drawing.Size(515, 23);
            this.myLable1.TabIndex = 3;
            this.myLable1.Text = "改样明细";
            this.myLable1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myLable2
            // 
            this.myLable2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myLable2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myLable2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myLable2.ForeColor = System.Drawing.Color.Blue;
            this.myLable2.Location = new System.Drawing.Point(0, 0);
            this.myLable2.Name = "myLable2";
            this.myLable2.Size = new System.Drawing.Size(586, 23);
            this.myLable2.TabIndex = 4;
            this.myLable2.Text = "历史改样明细";
            this.myLable2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnAppHistoryModifyDetail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 489);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(586, 32);
            this.panel3.TabIndex = 5;
            // 
            // btnApplyModifyDetail
            // 
            this.btnApplyModifyDetail.Location = new System.Drawing.Point(152, 3);
            this.btnApplyModifyDetail.Name = "btnApplyModifyDetail";
            this.btnApplyModifyDetail.Size = new System.Drawing.Size(194, 23);
            this.btnApplyModifyDetail.TabIndex = 0;
            this.btnApplyModifyDetail.Text = "应用改样明细";
            this.btnApplyModifyDetail.UseVisualStyleBackColor = true;
            this.btnApplyModifyDetail.Click += new System.EventHandler(this.btnApplyModifyDetail_Click);
            // 
            // btnAppHistoryModifyDetail
            // 
            this.btnAppHistoryModifyDetail.Location = new System.Drawing.Point(195, 4);
            this.btnAppHistoryModifyDetail.Name = "btnAppHistoryModifyDetail";
            this.btnAppHistoryModifyDetail.Size = new System.Drawing.Size(194, 23);
            this.btnAppHistoryModifyDetail.TabIndex = 1;
            this.btnAppHistoryModifyDetail.Text = "应用历史改样明细";
            this.btnAppHistoryModifyDetail.UseVisualStyleBackColor = true;
            this.btnAppHistoryModifyDetail.Click += new System.EventHandler(this.btnAppHistoryModifyDetail_Click);
            // 
            // myContextModifyHead
            // 
            this.myContextModifyHead.MyDataGridView = this.dgv_ModifyHead;
            this.myContextModifyHead.Name = "myContextModifyHead";
            this.myContextModifyHead.Size = new System.Drawing.Size(101, 26);
            // 
            // myContextModifyDetail
            // 
            this.myContextModifyDetail.MyDataGridView = this.dgv_ModifyDetail;
            this.myContextModifyDetail.Name = "myContextModifyDetail";
            this.myContextModifyDetail.Size = new System.Drawing.Size(101, 26);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 23);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv_ModifyHead);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_ModifyDetail);
            this.splitContainer2.Size = new System.Drawing.Size(515, 466);
            this.splitContainer2.SplitterDistance = 220;
            this.splitContainer2.TabIndex = 4;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 23);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgv_HistoryModifyHead);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgv_HistoryModifyDetail);
            this.splitContainer3.Size = new System.Drawing.Size(586, 466);
            this.splitContainer3.SplitterDistance = 220;
            this.splitContainer3.TabIndex = 6;
            // 
            // dgv_HistoryModifyHead
            // 
            this.dgv_HistoryModifyHead.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_HistoryModifyHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HistoryModifyHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_HistoryModifyHead.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_HistoryModifyHead.Location = new System.Drawing.Point(0, 0);
            this.dgv_HistoryModifyHead.Name = "dgv_HistoryModifyHead";
            this.dgv_HistoryModifyHead.ReadOnly = true;
            this.dgv_HistoryModifyHead.RowTemplate.Height = 23;
            this.dgv_HistoryModifyHead.Size = new System.Drawing.Size(586, 220);
            this.dgv_HistoryModifyHead.TabIndex = 1;
            // 
            // dgv_HistoryModifyDetail
            // 
            this.dgv_HistoryModifyDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_HistoryModifyDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HistoryModifyDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_HistoryModifyDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_HistoryModifyDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_HistoryModifyDetail.Name = "dgv_HistoryModifyDetail";
            this.dgv_HistoryModifyDetail.ReadOnly = true;
            this.dgv_HistoryModifyDetail.RowTemplate.Height = 23;
            this.dgv_HistoryModifyDetail.Size = new System.Drawing.Size(586, 242);
            this.dgv_HistoryModifyDetail.TabIndex = 0;
            // 
            // myContextHistoryModifyHead
            // 
            this.myContextHistoryModifyHead.MyDataGridView = this.dgv_HistoryModifyHead;
            this.myContextHistoryModifyHead.Name = "myContextHistoryModifyHead";
            this.myContextHistoryModifyHead.Size = new System.Drawing.Size(101, 26);
            // 
            // myContextHistoryModifyDetail
            // 
            this.myContextHistoryModifyDetail.MyDataGridView = this.dgv_HistoryModifyDetail;
            this.myContextHistoryModifyDetail.Name = "myContextHistoryModifyDetail";
            this.myContextHistoryModifyDetail.Size = new System.Drawing.Size(101, 26);
            // 
            // FormBaseBOMCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 552);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FormBaseBOMCompare";
            this.Text = "BOM结构比较";
            this.Load += new System.EventHandler(this.FormBaseBOMCompare_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModifyDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HistoryModifyHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HistoryModifyDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.myLable myLable1;
        private System.Windows.Forms.Panel panel2;
        private Controls.myLable myLable2;
        private System.Windows.Forms.Panel panel1;
        private Controls.myButton btnApplyModifyDetail;
        private System.Windows.Forms.Panel panel3;
        private Controls.myButton btnAppHistoryModifyDetail;
        private Controls.myContextMenuStripCell myContextModifyHead;
        private Controls.myContextMenuStripCell myContextModifyDetail;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public Controls.myDataGridView dgv_HistoryModifyHead;
        public Controls.myDataGridView dgv_HistoryModifyDetail;
        private Controls.myContextMenuStripCell myContextHistoryModifyHead;
        private Controls.myContextMenuStripCell myContextHistoryModifyDetail;
        public Controls.myDataGridView dgv_ModifyHead;
        public Controls.myDataGridView dgv_ModifyDetail;
    }
}