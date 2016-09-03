using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;

namespace UniqueDeclarationBaseForm.Controls
{
    public partial class myDataGridView : DataGridView
    {
        SolidBrush solidBrush;
        public myDataGridView()
        {
            InitializeComponent();
            solidBrush = new SolidBrush(this.RowHeadersDefaultCellStyle.ForeColor);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //return base.ProcessCmdKey(ref msg, keyData);
            if (keyData == Keys.Enter)
            {
                this.OnKeyPress(new KeyPressEventArgs(SystemConst.GridKeysEnter));
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, solidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);
            base.OnRowPostPaint(e);
            base.OnRowPostPaint(e);
        }

        /// <summary>
        /// 复制单元格的值到剪贴板
        /// </summary>
        public void CopyCellValue()
        {
            if (this.CurrentCell.Value != DBNull.Value && this.CurrentCell.Value != null)
            {
                string strText = string.Empty;
                strText = this.CurrentCell.Value.ToString();
                Clipboard.SetText(strText);
            }
            else
            {
                Clipboard.Clear();
            }
        }
    }
}
