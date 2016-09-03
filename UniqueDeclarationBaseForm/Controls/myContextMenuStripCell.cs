using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclarationBaseForm.Controls
{
    public partial class myContextMenuStripCell : ContextMenuStrip
    {
        //public System.Windows.Forms.ToolStripMenuItem CopyCell = new ToolStripMenuItem();
        public myContextMenuStripCell()
        {
            InitializeComponent();

            //// 
            //// CopyCell
            //// 
            //System.Windows.Forms.ToolStripMenuItem CopyCell = new ToolStripMenuItem ();
            //CopyCell.Name = "CopyCell";
            //CopyCell.Size = new System.Drawing.Size(152, 22);
            //CopyCell.Text = "复制";
            //CopyCell.Click += new System.EventHandler(CopyCell_Click);
            //// 
            //// contextMenuStripCell
            //// 
            //this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //CopyCell});
            ////this.Name = "contextMenuStripCell";
            //this.Size = new System.Drawing.Size(153, 48);

        }

        private myDataGridView _dgv = null;
        /// <summary>
        /// 菜单绑定的myDataGridView控件
        /// </summary>
        [Category("自定义属性")]
        [Description("菜单绑定的myDataGridView控件，方便单元格复制时指定myDataGridView")]
        [DefaultValue(true)]
        public myDataGridView MyDataGridView
        {
            get { return _dgv; }
            set { _dgv = value; }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void CopyCell_Click(object sender, EventArgs e)
        {
            if(_dgv != null)
                _dgv.CopyCellValue();
        }
    }
}
