using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration.Base
{
    public partial class FormManualBOM : Form
    {
        public FormManualBOM()
        {
            InitializeComponent();
        }

        #region 外部传进来的变量
        /// <summary>
        /// 手册id
        /// </summary>
        public int mIntID = 0;
        /// <summary>
        /// 手册编号       
        /// </summary>
        public string mstrNo = string.Empty;
        /// <summary>
        /// 出口成品id
        /// </summary>
        public int mnPId = 0;
        /// <summary>
        /// 品名规格型号
        /// </summary>
        public string mstrName = string.Empty;
        #endregion

        #region 自定义变量
        /// <summary>
        /// 控制是否触发单元格回车事件，如果是回车事件后，指定到某个单元格，这种情况下就不再触发回车事件
        /// </summary>
        private bool bCellKeyPress = true;
        /// <summary>
        /// 是否触发单元格结束编辑事件
        /// </summary>
        private bool bCellEndEdit = true;
        /// <summary>
        /// 数据集
        /// </summary>
        private DataTable dtBOM = null;
        #endregion


        #region 窗体事件
        private void FormManualBOM_Load(object sender, EventArgs e)
        {

        }

        private void FormManualBOM_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region 按钮事件
        private void tool_Save_Click(object sender, EventArgs e)
        {

        }

        private void tool_Close_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
