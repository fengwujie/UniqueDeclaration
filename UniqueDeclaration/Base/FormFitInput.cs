using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration.Base
{
    public partial class FormFitInput : UniqueDeclarationBaseForm.FormBase
    {
        public FormFitInput()
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
        /// 是否触发下拉控件的变化事件
        /// </summary>
        private bool bcbox_SelectedIndexChanged = false;
        /// <summary>
        /// 是否触发料件建档日期事件
        /// </summary>
        private bool bdatetime_料件建档日期_ValueChanged = false;
        /// <summary>
        /// 是否触发复选框值变化事件
        /// </summary>
        private bool bchk_计算库存_CheckedChanged = false;
        /// <summary>
        /// 文本控件失去焦点事件
        /// </summary>
        private bool btxt_LostFocus = false;
        #endregion

        private void FormFitInput_Load(object sender, EventArgs e)
        {

        }
    }
}
