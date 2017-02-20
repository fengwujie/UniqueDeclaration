using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UniqueDeclarationPubilc;
using UniqueDeclaration.Base;

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
            //if (DateTime.Now.Date > Convert.ToDateTime( "2016-12-30"))
            //{
            //    MessageBox.Show("软件已过试用期，将退出系统，请与软件供应商联系！");
            //    Application.Exit();
            //}
            this.toolStatus_Version.Text = string.Format("当前系统版本：{0}",Application.ProductVersion);
            SetBackgroupImage();
            Form_Login loginForm = new Form_Login();
            if (loginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.toolStatus_User.Text = string.Format("当前用户：{0}", SystemGlobal.SystemGlobal_UserInfo.UserName);
                DeleteExcelTempAllFile();
            }
        }

        /// <summary>
        /// 删除ExcelTemp目录下的临时文件
        /// </summary>
        public static void DeleteExcelTempAllFile()
        {
            string strDestRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ExcelTemp\");
            if (Directory.Exists(strDestRoot))
            {
                DirectoryInfo aDirectoryInfo = new DirectoryInfo(Path.GetDirectoryName(strDestRoot));
                FileInfo[] files = aDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
                foreach (FileInfo f in files)
                {
                    f.Attributes = FileAttributes.Archive;
                    File.Delete(f.FullName);
                }
            }
            else
            {
                Directory.CreateDirectory(strDestRoot);
            }
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

        #region 订单管理菜单
        //预先订单录入
        private void FormOrderInput_Click(object sender, EventArgs e)
        {
            FormOrderInput objForm = new FormOrderInput();
            objForm.MdiParent = this;
            objForm.Show();
        }
        //预先订单查询
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
        //制造通知单录入
        private void FormMakeNoticeInput_Click(object sender, EventArgs e)
        {
            FormMakeNoticeInput objForm = new FormMakeNoticeInput();
            objForm.MdiParent = this;
            objForm.Show();
        }
        //制造通知单查询
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
        #endregion

        #region 料件管理菜单
        //料件入库
        private void FormMaterialsInInput_Click(object sender, EventArgs e)
        {
            FormMaterialsInInput objForm = new FormMaterialsInInput();
            objForm.MdiParent = this;
            objForm.Show();
        }
        //料件入库查询
        private void FormMaterialsInQueryCondition_Click(object sender, EventArgs e)
        {
            FormMaterialsInQueryCondition queryConditionForm = new FormMaterialsInQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strWhere = queryConditionForm.strReturnWhere;
                FormMaterialsInQueryList queryListForm = new FormMaterialsInQueryList();
                queryListForm.gstrWhere = strWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //料件进销存查询
        private void FormMaterialsJXCQueryCondition_Click(object sender, EventArgs e)
        {
            FormMaterialsJXCQueryCondition queryConditionForm = new FormMaterialsJXCQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UniqueDeclarationBaseForm.FormBaseQueryListSingle queryListForm = new UniqueDeclarationBaseForm.FormBaseQueryListSingle();
                queryListForm.gstrWhere = queryConditionForm.strReturnWhere;
                queryListForm.mdFromDate = queryConditionForm.mdFromDate;
                queryListForm.mdFromDateString = queryConditionForm.mdFromDateString;
                queryListForm.mdToDate = queryConditionForm.mdToDate;
                queryListForm.mdToDateString = queryConditionForm.mdToDateString;
                queryListForm.ManualCode = queryConditionForm.ManualCode;
                queryListForm.passvalue = queryConditionForm.passvalue;
                queryListForm.mQueryWay = UniqueDeclarationBaseForm.ReportsEnum.ReportsEnum_rpt料件进销存;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //料件出库查询
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
        //料件出库录入
        private void FormMaterialsOut_Click(object sender, EventArgs e)
        {
            FormMaterialsOutInput objForm = new FormMaterialsOutInput();
            objForm.MdiParent = this;
            objForm.Show();
        }
        #endregion
        
        #region 业务管理菜单
        //成品出货录入
        private void FormFinishedProductOutInput_Click(object sender, EventArgs e)
        {
            FormFinishedProductOutInput objForm = new FormFinishedProductOutInput();
            objForm.MdiParent = this;
            objForm.Show();
        }
        //成品出货查询
        private void FormFinishedProductOutQueryCondition_Click(object sender, EventArgs e)
        {
            FormFinishedProductOutQueryCondition queryConditionForm = new FormFinishedProductOutQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strWhere = queryConditionForm.strReturnWhere;
                FormFinishedProductOutQueryList queryListForm = new FormFinishedProductOutQueryList();
                queryListForm.gstrWhere = strWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //装箱单录入
        private void FormPackingListInput_Click(object sender, EventArgs e)
        {
            FormPackingListInput objForm = new FormPackingListInput(); 
            objForm.MdiParent = this;
            objForm.Show();
        }
        //装箱明细单查询
        private void FormPackingListQueryCondition_Click(object sender, EventArgs e)
        {
            FormPackingListQueryCondition queryConditionForm = new FormPackingListQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strWhere = queryConditionForm.strReturnWhere;
                FormPackingListQueryList queryListForm = new FormPackingListQueryList();
                queryListForm.gstrWhere = strWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //Articles
        private void FormCustFindSet_Click(object sender, EventArgs e)
        {
            FormCustFindSet objForm = new FormCustFindSet();
            if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FormArticlesFile formArticlesFile = new FormArticlesFile();
                formArticlesFile.CustValue = objForm.CustValue;
                formArticlesFile.ShowDialog();
            }
        }
        #endregion

        #region 进口管理菜单
        //进口管理——PACKING LIST（录入）
        private void FormPackingInput_Click(object sender, EventArgs e)
        {
            FormPackingInInput objForm = new FormPackingInInput();
            objForm.MdiParent = this;
            objForm.Show();
        }
        //进口管理——PACKING LIST（查询）
        private void FormPackingQueryCondition_Click(object sender, EventArgs e)
        {
            FormPackingInQueryCondition queryConditionForm = new FormPackingInQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strWhere = queryConditionForm.strReturnWhere;
                FormPackingInQueryList queryListForm = new FormPackingInQueryList();
                queryListForm.gstrWhere = strWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        #endregion

        #region 出口管理菜单
        //出口管理——PACKING LIST（录入）
        private void FormPackingOutInput_Click(object sender, EventArgs e)
        {
            FormPackingOutInput objForm = new FormPackingOutInput();
            objForm.MdiParent = this;
            objForm.Show();
        }
        //出口管理——PACKING LIST（查询）
        private void FormPackingOutQueryCondition_Click(object sender, EventArgs e)
        {
            FormPackingOutQueryCondition queryConditionForm = new FormPackingOutQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strWhere = queryConditionForm.strReturnWhere;
                FormPackingOutQueryList queryListForm = new FormPackingOutQueryList();
                queryListForm.gstrWhere = strWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //INVOICE查询
        private void FormInvoiceOutQueryCondition_Click(object sender, EventArgs e)
        {
            FormInvoiceOutQueryCondition queryConditionForm = new FormInvoiceOutQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strWhere = queryConditionForm.strReturnWhere;
                FormInvoiceOutQueryList queryListForm = new FormInvoiceOutQueryList();
                queryListForm.gstrWhere = strWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        #endregion

        #region 成品仓库管理
        private void 成品入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UniquePMS.frmInStock objForm = new UniquePMS.frmInStock();
            objForm.MdiParent = this;
            objForm.Show();
        }

        private void 成品出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UniquePMS.frmOutStock objForm = new UniquePMS.frmOutStock();
            objForm.MdiParent = this;
            objForm.Show();
        }

        private void 成品库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UniquePMS.frmStock objForm = new UniquePMS.frmStock();
            objForm.MdiParent = this;
            objForm.Show();
        }
        #endregion

        #region 基础资料
        //料件资料录入
        private void FormMaterialsInput_Click(object sender, EventArgs e)
        {
            FormMaterialsInput objForm = new FormMaterialsInput();
            objForm.MdiParent = this;
            objForm.giOrderID = 0;
            objForm.Show();
        }
        //料件资料查询
        private void FormMaterialsQueryCondition_Click(object sender, EventArgs e)
        {
            FormMaterialsQueryCondition queryConditionForm = new FormMaterialsQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UniqueDeclaration.Base.FormMaterialsQueryList queryListForm = new UniqueDeclaration.Base.FormMaterialsQueryList();
                queryListForm.gstrWhere = queryConditionForm.strReturnWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //配件资料录入
        private void FormFitInput_Click(object sender, EventArgs e)
        {
            FormFitInput objForm = new FormFitInput();
            objForm.MdiParent = this;
            objForm.giOrderID = 0;
            objForm.Show();
        }
        //配件资料查询
        private void FormFitQueryCondition_Click(object sender, EventArgs e)
        {
            FormFitQueryCondition queryConditionForm = new FormFitQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UniqueDeclaration.Base.FormFitQueryList queryListForm = new UniqueDeclaration.Base.FormFitQueryList();
                queryListForm.gstrWhere = queryConditionForm.strReturnWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //产品资料录入
        private void FormProductInput_Click(object sender, EventArgs e)
        {
            FormProductInput objForm = new FormProductInput();
            objForm.MdiParent = this;
            objForm.giOrderID = 0;
            objForm.Show();
        }
        //产品资料查询
        private void FormProductQueryCondition_Click(object sender, EventArgs e)
        {
            FormProductQueryCondition queryConditionForm = new FormProductQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UniqueDeclaration.Base.FormProductQueryList queryListForm = new UniqueDeclaration.Base.FormProductQueryList();
                queryListForm.gstrWhere = queryConditionForm.strReturnWhere;
                queryListForm.abOK = queryConditionForm.abOK;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //手册资料录入
        private void FromManualInput_Click(object sender, EventArgs e)
        {
            FormManualInput objForm = new FormManualInput();
            objForm.MdiParent = this;
            objForm.giOrderID = 0;
            objForm.Show();
        }
        //手册资料查询
        private void FormManualQueryCondition_Click(object sender, EventArgs e)
        {
            FormManualQueryCondition queryConditionForm = new FormManualQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strWhere = queryConditionForm.strReturnWhere;
                UniqueDeclaration.Base.FormManualQueryList queryListForm = new UniqueDeclaration.Base.FormManualQueryList();
                queryListForm.gstrWhere = strWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //商品归并关系表（料件）录入
        private void FormMergeRelationMaterialsInput_Click(object sender, EventArgs e)
        {
            FormMergeRelationMaterialsInput objForm = new FormMergeRelationMaterialsInput();
            objForm.MdiParent = this;
            objForm.giOrderID = 0;
            objForm.Show();
        }
        //商品归并关系表（料件）查询
        private void FormMergeRelationMaterialsQueryCondition_Click(object sender, EventArgs e)
        {
            FormMergeRelationMaterialsQueryCondition queryConditionForm = new FormMergeRelationMaterialsQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string cManualNo = queryConditionForm.cManualNo;
                UniqueDeclaration.Base.FormMergeRelationMaterialsQueryList queryListForm = new UniqueDeclaration.Base.FormMergeRelationMaterialsQueryList();
                queryListForm.gstrManualNo = cManualNo;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //商品归并关系表（成品）录入
        private void FormMergeRelationProductInput_Click(object sender, EventArgs e)
        {
            FormMergeRelationProductInput objForm = new FormMergeRelationProductInput();
            objForm.MdiParent = this;
            objForm.giOrderID = 0;
            objForm.Show();
        }
        //商品归并关系表（成品）查询
        private void FormMergeRelationProductQueryList_Click(object sender, EventArgs e)
        {
            FormMergeRelationProductQueryCondition queryConditionForm = new FormMergeRelationProductQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string cManualNo = queryConditionForm.cManualNo;
                UniqueDeclaration.Base.FormMergeRelationProductQueryList queryListForm = new UniqueDeclaration.Base.FormMergeRelationProductQueryList();
                queryListForm.gstrManualNo = cManualNo;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        //报关产品确认录入
        private void FormCheckOutInput_Click(object sender, EventArgs e)
        {
            FormCheckOutInput objForm = new FormCheckOutInput();
            objForm.MdiParent = this;
            objForm.giOrderID = 0;
            objForm.Show();
        }
        //报关产品确认查询
        private void FormCheckOutQueryCondition_Click(object sender, EventArgs e)
        {
            FormCheckOutQueryCondition queryConditionForm = new FormCheckOutQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //string cManualNo = queryConditionForm.cManualNo;
                UniqueDeclaration.Base.FormCheckOutQueryList queryListForm = new UniqueDeclaration.Base.FormCheckOutQueryList();
                //queryListForm.gstrManualNo = cManualNo;
                queryListForm.gstrWhere = queryConditionForm.strReturnWhere;
                queryListForm.MdiParent = this;
                queryListForm.Show();
            }
        }
        #endregion
    }
}
