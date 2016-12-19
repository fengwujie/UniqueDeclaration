using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration.Base
{
    public partial class FormManualInput : UniqueDeclarationBaseForm.FormBase
    {
        public FormManualInput()
        {
            InitializeComponent();
        }

        #region 自定义变量
        /// <summary>
        /// 订单ID，如果是修改打开的话，需要赋值，重复点击修改的话，需要判断被打开的FORM中是否存在该订单ID，有的话显示窗体，没有的话再创建
        /// </summary>
        public int giOrderID = 0;
        /// <summary>
        /// 表头数据集
        /// </summary>
        public DataTable dtHead = null;
        /// <summary>
        /// 表头数据集的行数据
        /// </summary>
        public DataRow rowHead = null;
        /// <summary>
        /// 表身数据集
        /// </summary>
        public DataTable dtDetails = null;
        /// <summary>
        /// 表身数据集
        /// </summary>
        public DataTable dtDetails2 = null;
        /// <summary>
        /// 明细表的第一个字段
        /// </summary>
        public string gstrDetailFirstField = string.Empty;
        /// <summary>
        /// 控制是否触发单元格回车事件，如果是回车事件后，指定到某个单元格，这种情况下就不再触发回车事件
        /// </summary>
        public bool bCellKeyPress = true;
        /// <summary>
        /// 是否触发单元格结束编辑事件
        /// </summary>
        public bool bCellEndEdit = true;
        #endregion

        #region 窗体事件
        private void FormManualInput_Load(object sender, EventArgs e)
        {
            InitGrid();
            InitControlData();
            LoadDataSource();
        }

        private void FormManualInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = CheckModify();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.Yes:
                    if (Save(false))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                    break;
                case System.Windows.Forms.DialogResult.No:
                    e.Cancel = false;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化GRID
        /// </summary>
        public void InitGrid()
        {
        }
        /// <summary>
        /// 初始化界面上某些控件的初始值
        /// </summary>
        public void InitControlData()
        {

        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadDataSource()
        {
            LoadDataSourceHead();
            LoadDataSourceDetails();
            LoadDataSourceDetails2();
        }
        /// <summary>
        /// 加载表头数据
        /// </summary>
        public void LoadDataSourceHead()
        {
        }
        /// <summary>
        /// 加载表身出口成品数据
        /// </summary>
        public void LoadDataSourceDetails()
        {
        }
        /// <summary>
        /// 加载表身进口料件数据
        /// </summary>
        public void LoadDataSourceDetails2()
        {
        }
        /// <summary>
        /// 检查数据是否有修改，并返回对应的操作选项
        /// Yes：保存资料，并继续;；No：不保存资料，并继续；Cancel：取消操作，返回界面
        /// </summary>
        /// <returns>Yes：保存资料，并继续;；No：不保存资料，并继续；Cancel：取消操作，返回界面</returns>
        public DialogResult CheckModify()
        {
            return DialogResult.No;
        }
        /// <summary>
        /// 保存数据，并返回是否保存成功
        /// <param name="bShowSuccessMsg">保存成功时是否弹出提示信息</param>
        /// </summary>
        public virtual bool Save(bool bShowSuccessMsg)
        {
            bool bSuccess = true;
            return bSuccess;
        }
        #endregion

        #region 表头tool
        private void tool1_Add_Click(object sender, EventArgs e)
        {

        }

        private void tool1_Save_Click(object sender, EventArgs e)
        {

        }

        private void tool1_Close_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
