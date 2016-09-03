using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;
using UniqueDeclarationBaseForm.Controls;

namespace UniqueDeclarationBaseForm
{
    /*必须重写的方法
     *  InitGrid()
     *  InitControlData()
     *  LoadDataSourceHead()
     *  LoadDataSourceDetails()  
     *  CheckModify()
     *  Save(bool bShowSuccessMsg)
     *  dtDetailsAddRow()
     *  GridKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
     */
    public partial class FormBaseInput : UniqueDeclarationBaseForm.FormBase
    {
        public FormBaseInput()
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
        /// 明细表的第一个字段
        /// </summary>
        public string gstrDetailFirstField = string.Empty;
        ///// <summary>
        ///// 是否触发值变化事件
        ///// </summary>
        //private bool bcbox_电子帐册号_SelectedIndexChanged = true;
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
        public virtual void FormBaseInput_Load(object sender, EventArgs e)
        {
            InitGrid();
            InitControlData();
            LoadDataSource();
        }

        public virtual void FormBaseInput_FormClosing(object sender, FormClosingEventArgs e)
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
        public virtual void InitGrid()
        {
        }
        /// <summary>
        /// 初始化界面上某些控件的初始值
        /// </summary>
        public virtual void InitControlData()
        {

        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public virtual void LoadDataSource()
        {
            LoadDataSourceHead();
            LoadDataSourceDetails();
        }
        /// <summary>
        /// 加载表头数据
        /// </summary>
        public virtual void LoadDataSourceHead()
        {
        }
        /// <summary>
        /// 加载表身数据
        /// </summary>
        public virtual void LoadDataSourceDetails()
        {
        }
        /// <summary>
        /// 检查数据是否有修改，并返回对应的操作选项
        /// Yes：保存资料，并继续;；No：不保存资料，并继续；Cancel：取消操作，返回界面
        /// </summary>
        /// <returns>Yes：保存资料，并继续;；No：不保存资料，并继续；Cancel：取消操作，返回界面</returns>
        public virtual DialogResult CheckModify()
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

        #region 表头toolStrip事件
        //新增表头
        public virtual void tool1_Add_Click(object sender, EventArgs e)
        {
            DialogResult result = CheckModify();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.Yes:
                    if (Save(false))
                        LoadDataSource();
                    break;
                case System.Windows.Forms.DialogResult.No:
                    {
                        giOrderID = 0;
                        LoadDataSource();
                    }
                    break;
                case System.Windows.Forms.DialogResult.Cancel:

                    break;
            }
        }
        //保存数据
        public virtual void tool1_Save_Click(object sender, EventArgs e)
        {
            Save(true);
        }
        //关闭窗体
        public virtual void tool1_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 表身toolStrip事件
        //首笔
        public virtual void tool2_First_Click(object sender, EventArgs e)
        {
            this.dataGridViewDetail.ClearSelection();
            this.dataGridViewDetail.Rows[0].Selected = true;
            this.dataGridViewDetail.CurrentCell = this.dataGridViewDetail.Rows[0].Cells[gstrDetailFirstField];
            setTool1Enabled();
        }
        //上笔
        public virtual void tool2_up_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.dataGridViewDetail.CurrentRow.Index;
            this.dataGridViewDetail.ClearSelection();
            this.dataGridViewDetail.Rows[iSelectRow - 1].Selected = true;
            this.dataGridViewDetail.CurrentCell = this.dataGridViewDetail.Rows[iSelectRow - 1].Cells[gstrDetailFirstField];
            setTool1Enabled();
        }
        //下笔
        public virtual void tool2_Down_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.dataGridViewDetail.CurrentRow.Index;
            this.dataGridViewDetail.ClearSelection();
            this.dataGridViewDetail.Rows[iSelectRow + 1].Selected = true;
            this.dataGridViewDetail.CurrentCell = this.dataGridViewDetail.Rows[iSelectRow + 1].Cells[gstrDetailFirstField];
            setTool1Enabled();
        }
        //末笔
        public virtual void tool2_End_Click(object sender, EventArgs e)
        {
            this.dataGridViewDetail.ClearSelection();
            this.dataGridViewDetail.Rows[this.dataGridViewDetail.RowCount - 1].Selected = true;
            this.dataGridViewDetail.CurrentCell = this.dataGridViewDetail.Rows[this.dataGridViewDetail.RowCount - 1].Cells[gstrDetailFirstField];
            setTool1Enabled();
        }
        //导入数据
        public virtual void tool2_Import_Click(object sender, EventArgs e)
        {

        }
        //新增明细
        public virtual void tool2_Add_Click(object sender, EventArgs e)
        {
            dtDetailsAddRow();
        }
        //删除明细
        public virtual void tool2_Delete_Click(object sender, EventArgs e)
        {
            this.dataGridViewDetail.Rows.RemoveAt(this.dataGridViewDetail.CurrentRow.Index);
            setTool1Enabled();
        }
        
        /// <summary>
        /// 设置tools的按钮是否可用
        /// </summary>
        public virtual void setTool1Enabled()
        {
            if (dtDetails != null && dtDetails.Rows.Count > 0)
            {
                //如果总行数为1时，则笔数移动按钮都为不可编辑
                if (dtDetails.Rows.Count == 1)
                {
                    this.tool2_First.Enabled = false;
                    this.tool2_up.Enabled = false;
                    this.tool2_Down.Enabled = false;
                    this.tool2_End.Enabled = false;
                }
                else
                {
                    //如果当前行索引为0
                    if (this.dataGridViewDetail.CurrentRow == null) return;
                    if (this.dataGridViewDetail.CurrentRow.Index == 0)
                    {
                        this.tool2_First.Enabled = false;
                        this.tool2_up.Enabled = true;
                        this.tool2_Down.Enabled = true;
                        this.tool2_End.Enabled = true;
                    }
                    else if (this.dataGridViewDetail.CurrentRow.Index == this.dataGridViewDetail.RowCount - 1)  //如果行索引为最后一行
                    {
                        this.tool2_First.Enabled = true;
                        this.tool2_up.Enabled = true;
                        this.tool2_Down.Enabled = true;
                        this.tool2_End.Enabled = false;
                    }
                    else
                    {
                        this.tool2_First.Enabled = true;
                        this.tool2_up.Enabled = true;
                        this.tool2_Down.Enabled = true;
                        this.tool2_End.Enabled = true;
                    }
                }

                this.tool2_Delete.Enabled = true;
            }
            else
            {
                this.tool2_First.Enabled = false;
                this.tool2_up.Enabled = false;
                this.tool2_Down.Enabled = false;
                this.tool2_End.Enabled = false;

                this.tool2_Delete.Enabled = false;
            }
        }

        #endregion

        #region Grid事件
        public virtual void dataGridViewDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == SystemConst.GridKeysEnter)
            {
                myDataGridView dgv = sender as myDataGridView;
                DataGridViewCell cell = dgv.CurrentCell;
                GridKeyEnter(dgv, cell, true);
            }
        }

        public virtual void dataGridViewDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridKeyEnter(dgv, cell, false);
        }

        public virtual void GridKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
        {

        }

        public virtual void dataGridViewDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        public virtual void dataGridViewDetail_SelectionChanged(object sender, EventArgs e)
        {
            setTool1Enabled();
        }
        /// <summary>
        /// 明细增加一条记录
        /// </summary>
        public virtual void dtDetailsAddRow()
        {
        }
        #endregion

    }
}
