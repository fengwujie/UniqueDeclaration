﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UniqueDeclaration
{
    public partial class Form_Main : Form
    {

        public Form_Main()
        {
            InitializeComponent();
        }

        #region 窗口
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion


        private void Form_Main_Load(object sender, EventArgs e)
        {
            SetBackgroupImage();
            Form_Login loginForm = new Form_Login();
            loginForm.ShowDialog();
            DeleteExcelTempAllFile();
        }

        /// <summary>
        /// 删除ExcelTemp目录下的临时文件
        /// </summary>
        public static void DeleteExcelTempAllFile()
        {
            string strDestRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ExcelTemp\");
            DirectoryInfo aDirectoryInfo = new DirectoryInfo(Path.GetDirectoryName(strDestRoot));
            FileInfo[] files = aDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo f in files)
            {
                //File.SetAttributes(f.FullName, File.GetAttributes(f.FullName) | FileAttributes.Archive);
                f.Attributes = FileAttributes.Archive;
                File.Delete(f.FullName);
            }
        }  

        private void FormOrderInput_Click(object sender, EventArgs e)
        {
            FormOrderInput objForm = new FormOrderInput();
            objForm.MdiParent = this;
            objForm.Show();
        }

        private void FormOrderQueryCondition_Click(object sender, EventArgs e)
        {
            FormOrderQueryCondition queryConditionForm = new FormOrderQueryCondition();
            //queryConditionForm.MdiParent = this;
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strWhere = queryConditionForm.strReturnWhere;
                FormOrderQueryList queryListForm = new FormOrderQueryList();
                queryListForm.gstrWhere = strWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }

        private void FormMakeNoticeInput_Click(object sender, EventArgs e)
        {
            FormMakeNoticeInput objForm = new FormMakeNoticeInput();
            objForm.MdiParent = this;
            objForm.Show();
        }

        private void FormMakeNoticeQueryCondition_Click(object sender, EventArgs e)
        {
            FormMakeNoticeQueryCondition queryConditionForm = new FormMakeNoticeQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strWhere = queryConditionForm.strReturnWhere;
                FormMakeNoticeQueryList queryListForm = new FormMakeNoticeQueryList();
                queryListForm.gstrWhere = strWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }

        private void 测试窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTest objForm = new FormTest();
            objForm.MdiParent = this;
            objForm.Show();
        }
        /// <summary>
        /// 设置主窗体背景图片
        /// </summary>
        private void SetBackgroupImage()
        {
            //设置背景图
            System.IO.FileInfo file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Image\bg.jpg"));
            Image bImg = Image.FromFile(file.FullName, false);
            this.BackgroundImage = bImg;
        }

        private void Form_Main_SizeChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
            SetBackgroupImage();
        }

        private void FormMaterialsOutQueryCondition_Click(object sender, EventArgs e)
        {
            FormMaterialsOutQueryCondition queryConditionForm = new FormMaterialsOutQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strWhere = queryConditionForm.strReturnWhere;
                FormMaterialsOutQueryList queryListForm = new FormMaterialsOutQueryList();
                queryListForm.gstrWhere = strWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }

        private void FormMaterialsOut_Click(object sender, EventArgs e)
        {
            FormMaterialsOutInput objForm = new FormMaterialsOutInput();
            objForm.MdiParent = this;
            objForm.Show();
        }
    }
}
