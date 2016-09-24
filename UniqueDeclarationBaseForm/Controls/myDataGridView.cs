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

        //private bool isRowSelected = false;
        ///// <summary>
        ///// 是否按回车执行TAB事件，即回车跳转到下一个控件
        ///// </summary>
        //[Category("自定义属性")]
        //[Description("获取dataGridView的行索引时，是否获取Selected的行索引，默认为False时，是获取Current.Index做索引，如果有用到上一笔或下一笔功能的话，就必须设置为True")]
        //[DefaultValue(false)]
        //public bool IsRowSelected
        //{
        //    get { return isRowSelected; }
        //    set { isRowSelected = value; }
        //}

        //public virtual void myDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if(this.IsRowSelected)
        //        this.Rows[this.CurrentCell.RowIndex].Selected = true;
        //}

        //public virtual void myDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (this.IsRowSelected)
        //        this.Rows[this.CurrentCell.RowIndex].Selected = true;
        //}
        /// <summary>
        /// 获取dataGridView的选中行索引，必须是单选时才有用
        /// </summary>
        /// <returns></returns>
        public int GetSelectedRowIndex()
        {
            int index = -1;
            //if (this.IsRowSelected)
            //{
            //    foreach (DataGridViewRow row in this.Rows)
            //    {
            //        if (row.Selected)
            //        {
            //            index = row.Index;
            //        }
            //    }
            //}
            //else
            //{
            //    if(this.CurrentRow !=null)
            //        index = this.CurrentRow.Index;
            //}
            if (this.SelectedRows.Count > 0)
                index = this.SelectedRows[0].Index;
            else if (this.CurrentRow != null)
                index = this.CurrentRow.Index;
            return index;
        }

        //private DataGridViewRow currentRowNew = null;
        /// <summary>
        /// 是否按回车执行TAB事件，即回车跳转到下一个控件
        /// </summary>
        [Category("自定义属性")]
        [Description("获取dataGridView的当前行，处理过CurrentRow和SelectedRows，目前只适用于MultiSelect=False，因为上笔下笔操作时，Selected设置的行和CurrentRow是不一样的")]
        [DefaultValue(null)]
        public DataGridViewRow CurrentRowNew
        {
            get {
                int index = GetSelectedRowIndex();
                if (index >= 0)
                    return this.Rows[index];
                else
                    return null;
                //return currentRowNew; 
            }
            //set { currentRowNew = value; }
        }
    }
}
