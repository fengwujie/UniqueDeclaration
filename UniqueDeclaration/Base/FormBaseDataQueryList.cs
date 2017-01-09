using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration.Base
{
    public partial class FormBaseDataQueryList : UniqueDeclarationBaseForm.FormBase
    {
        public FormBaseDataQueryList()
        {
            InitializeComponent();
        }

        #region 自定义变量
        /// <summary>
        /// GRID列表的第一个字段
        /// </summary>
        public string gstrDetailFirstField = "序号";
        /// <summary>
        /// 数据源的查询语句
        /// </summary>
        public string gstrSQL = string.Empty;
        /// <summary>
        /// 数据集
        /// </summary>
        public DataTable dtHead = null;
        /// <summary>
        /// 条件值
        /// </summary>
        public string gstrWhere = string.Empty;
        /// <summary>
        /// 数据源连接类型
        /// </summary>
        public DataAccess.DataAccessEnum.DataAccessName dataAccessName = DataAccessEnum.DataAccessName.DataAccessName_Manufacture;
        #endregion

        public virtual void FormBaseDataQueryList_Load(object sender, EventArgs e)
        {
            LoadDataSource();
            initGrid();
        }

        #region 方法
        /// <summary>
        /// 加载资料
        /// </summary>
        public virtual void LoadDataSource()
        {
            if (!this.DesignMode)
            {
                try
                {
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(dataAccessName);
                    dataAccess.Open();
                    dtHead = dataAccess.GetTable(string.Format(gstrSQL,(gstrWhere.Length>0 ? " where " : "") + gstrWhere), null);
                    dataAccess.Close();
                    DataTableTools.AddEmptyRow(dtHead);
                    this.myDataGridViewHead.DataSource = dtHead;
                    setTool1Enabled();
                }
                catch (Exception ex)
                {
                    SysMessage.ErrorMsg(string.Format("加载数据出错LoadDataSource，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
                }
            }
            setToolStripStatusLabel2();
        }
        /// <summary>
        /// 初始化GRID
        /// </summary>
        public virtual void initGrid()
        {

        }
        /// <summary>
        /// 设置状态栏的数量值
        /// </summary>
        public virtual void setToolStripStatusLabel2()
        {
            this.toolStripStatusLabel2.Text = (dtHead == null ? 0 : dtHead.Rows.Count).ToString();
        }
        #endregion

        #region tool1事件
        public virtual void tool1_First_Click(object sender, EventArgs e)
        {
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells[gstrDetailFirstField];
            setTool1Enabled();
        }

        public virtual void tool1_up_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells[gstrDetailFirstField];
            setTool1Enabled();
        }

        public virtual void tool1_Down_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells[gstrDetailFirstField];
            setTool1Enabled();
        }

        public virtual void tool1_End_Click(object sender, EventArgs e)
        {
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells[gstrDetailFirstField];
            setTool1Enabled();
        }

        public virtual void tool1_Import_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool1_Add_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool1_Modify_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool1_Save_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool1_Delete_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool1_BOM_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool1_Query_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool1_Print_Click(object sender, EventArgs e)
        {

        }

        public virtual void tool1_ExportExcel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 设置tools的按钮是否可用
        /// </summary>
        public void setTool1Enabled()
        {
            this.tool1_Query.Enabled = true;
            this.tool1_Add.Enabled = true;
            DataTable dtTable = (DataTable)myDataGridViewHead.DataSource;
            if (dtTable.Rows.Count > 0)
            {
                //如果总行数为1时，则笔数移动按钮都为不可编辑
                if (dtTable.Rows.Count == 1)
                {
                    this.tool1_First.Enabled = false;
                    this.tool1_up.Enabled = false;
                    this.tool1_Down.Enabled = false;
                    this.tool1_End.Enabled = false;
                }
                else
                {
                    //如果当前行索引为0
                    if (this.myDataGridViewHead.CurrentRow == null) return;
                    if (this.myDataGridViewHead.CurrentRow.Index == 0)
                    {
                        this.tool1_First.Enabled = false;
                        this.tool1_up.Enabled = false;
                        this.tool1_Down.Enabled = true;
                        this.tool1_End.Enabled = true;
                    }
                    else if (this.myDataGridViewHead.CurrentRow.Index == this.myDataGridViewHead.RowCount - 1)  //如果行索引为最后一行
                    {
                        this.tool1_First.Enabled = true;
                        this.tool1_up.Enabled = true;
                        this.tool1_Down.Enabled = false;
                        this.tool1_End.Enabled = false;
                    }
                    else
                    {
                        this.tool1_First.Enabled = true;
                        this.tool1_up.Enabled = true;
                        this.tool1_Down.Enabled = true;
                        this.tool1_End.Enabled = true;
                    }
                }

                this.tool1_Modify.Enabled = true;
                this.tool1_Delete.Enabled = true;
                this.tool1_ExportExcel.Enabled = true;
                this.tool1_Print.Enabled = true;
            }
            else
            {
                this.tool1_First.Enabled = false;
                this.tool1_up.Enabled = false;
                this.tool1_Down.Enabled = false;
                this.tool1_End.Enabled = false;

                this.tool1_Modify.Enabled = false;
                this.tool1_Delete.Enabled = false;
                this.tool1_ExportExcel.Enabled = false;
                this.tool1_Print.Enabled = false;
            }
        }
        #endregion

    }
}
