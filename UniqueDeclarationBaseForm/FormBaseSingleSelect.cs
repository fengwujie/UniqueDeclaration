using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;

namespace UniqueDeclarationBaseForm
{
    public partial class FormBaseSingleSelect : UniqueDeclarationBaseForm.FormBase
    {
        public FormBaseSingleSelect()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 数据源
        /// </summary>
        public DataTable dtData = null;
        /// <summary>
        /// 窗体的标题
        /// </summary>
        public string strFormText = string.Empty;
        /// <summary>
        /// 设置指定列的宽度，KEY=列名，VALUE=宽度值
        /// </summary>
        public Dictionary<string, int> dicColWidth = new Dictionary<string, int>();
        /// <summary>
        /// 返回的选中行
        /// </summary>
        public DataRow returnRow = null;
        private void FormBaseSingleSelect_Load(object sender, EventArgs e)
        {
            this.Text = strFormText;
            this.dataGridView1.DataSource = dtData;
            foreach (KeyValuePair<string, int> kv in dicColWidth)
            {
                if (this.dataGridView1.Columns.Contains(kv.Key))
                {
                    this.dataGridView1.Columns[kv.Key].Width = kv.Value;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                SysMessage.InformationMsg("选未选择数据，请先选择");
            }
            returnRow = (dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }
    }
}
