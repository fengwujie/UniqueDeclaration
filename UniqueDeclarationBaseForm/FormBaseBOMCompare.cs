using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclarationBaseForm
{
    public partial class FormBaseBOMCompare : Form
    {
        public FormBaseBOMCompare()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 型号
        /// </summary>
        public string mstrName = string.Empty;
        public DataTable dtModifyHeadTemp = null;
        public DataTable dtModifyDetailTemp = null;
        public DataTable dtModifyHeadHistoryTemp = null;
        public DataTable dtModifyDetailHistoryTemp = null;

        public DataTable dtReturnHead = null;
        public DataTable dtReturnDetail = null;
        private void FormBaseBOMCompare_Load(object sender, EventArgs e)
        {
            this.dgv_ModifyHead.DataSource = dtModifyHeadTemp;
            this.dgv_ModifyDetail.DataSource = dtModifyDetailTemp;
            this.dgv_HistoryModifyHead.DataSource = dtModifyHeadHistoryTemp;
            this.dgv_HistoryModifyDetail.DataSource = dtModifyDetailHistoryTemp;
        }

        //应用改样明细
        private void btnApplyModifyDetail_Click(object sender, EventArgs e)
        {
            dtReturnHead = dtModifyHeadTemp;
            dtReturnDetail = dtModifyDetailTemp;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        //应用历史改样明细
        private void btnAppHistoryModifyDetail_Click(object sender, EventArgs e)
        {
            dtReturnHead = dtModifyHeadHistoryTemp;
            dtReturnDetail = dtModifyDetailHistoryTemp;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
