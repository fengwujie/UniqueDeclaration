﻿namespace UniqueDeclaration
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.Order = new System.Windows.Forms.ToolStripMenuItem();
            this.FormOrderInput = new System.Windows.Forms.ToolStripMenuItem();
            this.FormOrderQueryCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.FormMakeNoticeInput = new System.Windows.Forms.ToolStripMenuItem();
            this.FormMakeNoticeQueryCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.测试窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Materials = new System.Windows.Forms.ToolStripMenuItem();
            this.FormMaterialsOut = new System.Windows.Forms.ToolStripMenuItem();
            this.FormMaterialsOutQueryCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.Business = new System.Windows.Forms.ToolStripMenuItem();
            this.FormFinishedProductOutInput = new System.Windows.Forms.ToolStripMenuItem();
            this.FormFinishedProductOutQueryCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Order,
            this.Materials,
            this.Business,
            this.windowsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(761, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // Order
            // 
            this.Order.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormOrderInput,
            this.FormOrderQueryCondition,
            this.FormMakeNoticeInput,
            this.FormMakeNoticeQueryCondition,
            this.测试窗体ToolStripMenuItem});
            this.Order.Name = "Order";
            this.Order.Size = new System.Drawing.Size(68, 21);
            this.Order.Text = "订单管理";
            // 
            // FormOrderInput
            // 
            this.FormOrderInput.Name = "FormOrderInput";
            this.FormOrderInput.Size = new System.Drawing.Size(160, 22);
            this.FormOrderInput.Text = "预先订单录入";
            this.FormOrderInput.Click += new System.EventHandler(this.FormOrderInput_Click);
            // 
            // FormOrderQueryCondition
            // 
            this.FormOrderQueryCondition.Name = "FormOrderQueryCondition";
            this.FormOrderQueryCondition.Size = new System.Drawing.Size(160, 22);
            this.FormOrderQueryCondition.Text = "预先订单查询";
            this.FormOrderQueryCondition.Click += new System.EventHandler(this.FormOrderQueryCondition_Click);
            // 
            // FormMakeNoticeInput
            // 
            this.FormMakeNoticeInput.Name = "FormMakeNoticeInput";
            this.FormMakeNoticeInput.Size = new System.Drawing.Size(160, 22);
            this.FormMakeNoticeInput.Text = "制造通知单录入";
            this.FormMakeNoticeInput.Click += new System.EventHandler(this.FormMakeNoticeInput_Click);
            // 
            // FormMakeNoticeQueryCondition
            // 
            this.FormMakeNoticeQueryCondition.Name = "FormMakeNoticeQueryCondition";
            this.FormMakeNoticeQueryCondition.Size = new System.Drawing.Size(160, 22);
            this.FormMakeNoticeQueryCondition.Text = "制造通知单查询";
            this.FormMakeNoticeQueryCondition.Click += new System.EventHandler(this.FormMakeNoticeQueryCondition_Click);
            // 
            // 测试窗体ToolStripMenuItem
            // 
            this.测试窗体ToolStripMenuItem.Enabled = false;
            this.测试窗体ToolStripMenuItem.Name = "测试窗体ToolStripMenuItem";
            this.测试窗体ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.测试窗体ToolStripMenuItem.Text = "测试窗体";
            this.测试窗体ToolStripMenuItem.Click += new System.EventHandler(this.测试窗体ToolStripMenuItem_Click);
            // 
            // Materials
            // 
            this.Materials.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormMaterialsOut,
            this.FormMaterialsOutQueryCondition});
            this.Materials.Name = "Materials";
            this.Materials.Size = new System.Drawing.Size(72, 21);
            this.Materials.Text = " 料件管理";
            // 
            // FormMaterialsOut
            // 
            this.FormMaterialsOut.Name = "FormMaterialsOut";
            this.FormMaterialsOut.Size = new System.Drawing.Size(152, 22);
            this.FormMaterialsOut.Text = "料件出库";
            this.FormMaterialsOut.Click += new System.EventHandler(this.FormMaterialsOut_Click);
            // 
            // FormMaterialsOutQueryCondition
            // 
            this.FormMaterialsOutQueryCondition.Name = "FormMaterialsOutQueryCondition";
            this.FormMaterialsOutQueryCondition.Size = new System.Drawing.Size(152, 22);
            this.FormMaterialsOutQueryCondition.Text = "料件出库查询";
            this.FormMaterialsOutQueryCondition.Click += new System.EventHandler(this.FormMaterialsOutQueryCondition_Click);
            // 
            // Business
            // 
            this.Business.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormFinishedProductOutInput,
            this.FormFinishedProductOutQueryCondition});
            this.Business.Name = "Business";
            this.Business.Size = new System.Drawing.Size(68, 21);
            this.Business.Text = "业务管理";
            // 
            // FormFinishedProductOutInput
            // 
            this.FormFinishedProductOutInput.Enabled = false;
            this.FormFinishedProductOutInput.Name = "FormFinishedProductOutInput";
            this.FormFinishedProductOutInput.Size = new System.Drawing.Size(152, 22);
            this.FormFinishedProductOutInput.Text = "成品出货录入";
            this.FormFinishedProductOutInput.Click += new System.EventHandler(this.FormFinishedProductOutInput_Click);
            // 
            // FormFinishedProductOutQueryCondition
            // 
            this.FormFinishedProductOutQueryCondition.Name = "FormFinishedProductOutQueryCondition";
            this.FormFinishedProductOutQueryCondition.Size = new System.Drawing.Size(152, 22);
            this.FormFinishedProductOutQueryCondition.Text = "成品出货查询";
            this.FormFinishedProductOutQueryCondition.Click += new System.EventHandler(this.FormFinishedProductOutQueryCondition_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(64, 21);
            this.windowsMenu.Text = "窗口(&W)";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.newWindowToolStripMenuItem.Text = "新建窗口(&N)";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.cascadeToolStripMenuItem.Text = "层叠(&C)";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.tileVerticalToolStripMenuItem.Text = "垂直平铺(&V)";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.tileHorizontalToolStripMenuItem.Text = "水平平铺(&H)";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.closeAllToolStripMenuItem.Text = "全部关闭(&L)";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.arrangeIconsToolStripMenuItem.Text = "排列图标(&A)";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(61, 21);
            this.helpMenu.Text = "帮助(&H)";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.contentsToolStripMenuItem.Text = "目录(&C)";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.indexToolStripMenuItem.Text = "索引(&I)";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.searchToolStripMenuItem.Text = "搜索(&S)";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(163, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.aboutToolStripMenuItem.Text = "关于(&A) ... ...";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 419);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(761, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel.Text = "状态";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(761, 441);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form_Main";
            this.Text = "优丽报关管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.SizeChanged += new System.EventHandler(this.Form_Main_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem Order;
        private System.Windows.Forms.ToolStripMenuItem FormOrderInput;
        private System.Windows.Forms.ToolStripMenuItem FormOrderQueryCondition;
        private System.Windows.Forms.ToolStripMenuItem FormMakeNoticeInput;
        private System.Windows.Forms.ToolStripMenuItem FormMakeNoticeQueryCondition;
        private System.Windows.Forms.ToolStripMenuItem 测试窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Materials;
        private System.Windows.Forms.ToolStripMenuItem FormMaterialsOut;
        private System.Windows.Forms.ToolStripMenuItem FormMaterialsOutQueryCondition;
        private System.Windows.Forms.ToolStripMenuItem Business;
        private System.Windows.Forms.ToolStripMenuItem FormFinishedProductOutInput;
        private System.Windows.Forms.ToolStripMenuItem FormFinishedProductOutQueryCondition;
    }
}



