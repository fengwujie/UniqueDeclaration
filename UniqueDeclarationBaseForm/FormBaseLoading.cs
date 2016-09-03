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
    public partial class FormBaseLoading : Form
    {
        public FormBaseLoading()
        {
            InitializeComponent();
        }

        private System.Threading.Thread thread = null;
        /// <summary>
        /// 加载提示窗体显示的文本内容，默认为"正在努力加载中，请稍等......"
        /// </summary>
        public string strLoadText = "正在努力加载中，请稍等......";

        private void FormBaseLoading_Load(object sender, EventArgs e)
        {
            this.labLoading.Text = strLoadText;
        }

        /// <summary>
        /// 设置加载信息文本
        /// </summary>
        /// <param name="strLoadText"></param>
        public void setLoadText(string strLoadText)
        {
            this.labLoading.Text = strLoadText;
        }

        private void FormBaseLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null)
                thread.Abort();
        }

    }
}
