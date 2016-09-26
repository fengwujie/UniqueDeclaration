namespace UniqueDeclaration
{
    partial class FormProductType
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductType));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnMainType = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnSubType = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnModify = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnDelete = new UniqueDeclarationBaseForm.Controls.myButton();
            this.btnExit = new UniqueDeclarationBaseForm.Controls.myButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(298, 465);
            this.treeView1.TabIndex = 0;
            // 
            // btnMainType
            // 
            this.btnMainType.Location = new System.Drawing.Point(320, 13);
            this.btnMainType.Name = "btnMainType";
            this.btnMainType.Size = new System.Drawing.Size(112, 26);
            this.btnMainType.TabIndex = 1;
            this.btnMainType.Text = "添加主类产品";
            this.btnMainType.UseVisualStyleBackColor = true;
            this.btnMainType.Click += new System.EventHandler(this.btnMainType_Click);
            // 
            // btnSubType
            // 
            this.btnSubType.Location = new System.Drawing.Point(320, 62);
            this.btnSubType.Name = "btnSubType";
            this.btnSubType.Size = new System.Drawing.Size(112, 26);
            this.btnSubType.TabIndex = 2;
            this.btnSubType.Text = "添加子类产品";
            this.btnSubType.UseVisualStyleBackColor = true;
            this.btnSubType.Click += new System.EventHandler(this.btnSubType_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(320, 111);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(112, 26);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "修     改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(320, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 26);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删     除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(320, 209);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 26);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退     出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "check_box_24px.png");
            this.imageList1.Images.SetKeyName(1, "unCheck_box_24px.png");
            // 
            // FormProductType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(451, 472);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSubType);
            this.Controls.Add(this.btnMainType);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormProductType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "产品类别";
            this.Load += new System.EventHandler(this.FormProductType_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private UniqueDeclarationBaseForm.Controls.myButton btnMainType;
        private UniqueDeclarationBaseForm.Controls.myButton btnSubType;
        private UniqueDeclarationBaseForm.Controls.myButton btnModify;
        private UniqueDeclarationBaseForm.Controls.myButton btnDelete;
        private UniqueDeclarationBaseForm.Controls.myButton btnExit;
        private System.Windows.Forms.ImageList imageList1;
    }
}
