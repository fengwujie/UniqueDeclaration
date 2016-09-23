using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;
using UniqueDeclarationBaseForm.Controls;
using UniqueDeclarationBaseForm;

namespace UniqueDeclaration
{
    public partial class FormFinishedProductOutBOM : UniqueDeclarationBaseForm.FormBaseBOM
    {
        public FormFinishedProductOutBOM()
        {
            InitializeComponent();
        }

        #region 外部传进来的变量
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderId = 0;
        /// <summary>
        /// 订单号码
        /// </summary>
        public string OrderCode = string.Empty;
        /// <summary>
        /// 订单明细表ID
        /// </summary>
        public long OrderListId = 0;
        /// <summary>
        /// 产品ID
        /// </summary>
        public long Pid = 0;
        /// <summary>
        /// 配件id
        /// </summary>
        public long Fid = 0;
        /// <summary>
        /// 手册编号
        /// </summary>
        public string ManualCode = string.Empty;
        /// <summary>
        /// 型号
        /// </summary>
        public string mstrName = string.Empty;
        /// <summary>
        /// 实际总重
        /// </summary>
        public float AllWeight = 0;
        /// <summary>
        /// 总重
        /// </summary>
        public float FactWeight = 0;
        /// <summary>
        /// 成品项号
        /// </summary>
        public string ProductCode = string.Empty;

        public string NameCode1 = string.Empty;

        public string NameCode2 = string.Empty;
        /// <summary>
        /// 申报单位
        /// </summary>
        public string Unitname = string.Empty;
        /// <summary>
        /// 成品规格型号
        /// </summary>
        public string modename = string.Empty;

        /// <summary>
        /// 订单数量
        /// </summary>
        public decimal Amount = 0;
        #endregion

        #region 数据全局变量
        /// <summary>
        /// 改样前料件组成
        /// </summary>
        private DataTable dtModifyBefore = null;
        /// <summary>
        /// 改样前报关料件明细
        /// </summary>
        private DataTable dtModifyBeforeDetail = null;
        /// <summary>
        /// 改样后料件组成
        /// </summary>
        private DataTable dtModifyAfterHead = null;
        /// <summary>
        /// 改样后报关料件明细
        /// </summary>
        private DataTable dtModifyAfterDetail = null;
        /// <summary>
        /// 归并后料件组成
        /// </summary>
        private DataTable dtMergeAfterHead = null;
        /// <summary>
        /// 归并后料件明细
        /// </summary>
        private DataTable dtMergeAfterDetail = null;
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
        #endregion

        #region 窗体事件及其他控件事件
        private void FormFinishedProductOutBOM_Load(object sender, EventArgs e)
        {
            this.tool_Import.Visible = false;
            InitModifyBeore();
            InitModifyBeforeDetail();
            InitModifyAfterHead();
            InitModifyAfterDetail();
            InitMergeAfterHead();
            InitMergeAfterDetail();
            LoadDataSource();
            this.myTabControl1.SelectedIndex = 1;
        }
        private void FormFinishedProductOutBOM_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveModifyAfterHead();
            SaveModifyAfterDetail();
        }
        public override void myTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oldTabPage == tabPage1)
            {
                SaveModifyBeforeDetail();
            }
            if (oldTabPage == tabPage2)
            {
                SaveModifyAfterHead();
                SaveModifyAfterDetail();
                LoadDataSource();
            }
            if (this.myTabControl1.SelectedIndex == 2)
            {
                LoadSourceMergeAfter();
            }
            base.myTabControl1_SelectedIndexChanged(sender, e);
        }

        public override void btnModifyHeadDelete_Click(object sender, EventArgs e)
        {
            base.btnModifyHeadDelete_Click(sender, e);
            //if (dtModifyAfterHead.Rows.Count > 0)
            //{
            //    dtModifyAfterHead.Rows[this.dgv_ModifyAfterHead.CurrentRow.Index].Delete();
            //}
            if (this.dgv_ModifyAfterHead.CurrentRow != null)
            {
                this.dgv_ModifyAfterHead.Rows.RemoveAt(this.dgv_ModifyAfterHead.CurrentRow.Index);
            }
            if (this.dgv_ModifyAfterHead.CurrentRow == null)
            {
                dtModifyAfterHeadAddRow();
            }
        }

        public override void btnModifyDetailDelete_Click(object sender, EventArgs e)
        {
            base.btnModifyDetailDelete_Click(sender, e);
            //if (dtModifyAfterDetail.Rows.Count > 0)
            //{
            //    dtModifyAfterDetail.Rows[this.dgv_ModifyAfterDetail.CurrentRow.Index].Delete();
            //}
            if (this.dgv_ModifyAfterDetail.CurrentRow != null)
            {
                this.dgv_ModifyAfterDetail.Rows.RemoveAt(this.dgv_ModifyAfterDetail.CurrentRow.Index);
            }
            if (this.dgv_ModifyAfterDetail.CurrentRow == null)
            {
                dtModifyAfterDetailAddRow();
            }
        }
        //删除 改样前报关料件明细材料
        private void btnModifyBeforeDetailDelete_Click(object sender, EventArgs e)
        {
            if (this.dgv_ModifyBeforeDetail.CurrentRow != null)
            {
                this.dgv_ModifyBeforeDetail.Rows.RemoveAt(this.dgv_ModifyBeforeDetail.CurrentRow.Index);
            }
            if (this.dgv_ModifyBeforeDetail.CurrentRow == null)
            {
                DataTableTools.AddEmptyRow(dtModifyBeforeDetail);
            }
        }
        #endregion
        
        #region 初始化GRID

        private void InitModifyBeore()
        {
            this.dgv_ModifyBefore.ReadOnly = true;
            this.dgv_ModifyBefore.AutoGenerateColumns = false;
            // 
            // 序号
            // 
            DataGridViewTextBoxColumn 序号 = new DataGridViewTextBoxColumn();
            序号.DataPropertyName = "序号";
            序号.HeaderText = "序号";
            序号.Name = "序号";
            序号.ReadOnly = true;
            序号.Visible = false;
            // 
            // 料件id
            // 
            DataGridViewTextBoxColumn 料件id = new DataGridViewTextBoxColumn();
            料件id.DataPropertyName = "料件id";
            料件id.HeaderText = "料件id";
            料件id.Name = "料件id";
            料件id.ReadOnly = true;
            料件id.Visible = false;
            // 
            // 料件型号
            // 
            DataGridViewTextBoxColumn 料件型号 = new DataGridViewTextBoxColumn();
            料件型号.DataPropertyName = "型号";
            料件型号.HeaderText = "料件型号";
            料件型号.Name = "料件型号";
            料件型号.ReadOnly = true;
            料件型号.Visible = true;
            // 
            // 型号
            // 
            DataGridViewTextBoxColumn 型号 = new DataGridViewTextBoxColumn();
            型号.DataPropertyName = "显示型号";
            型号.HeaderText = "型号";
            型号.Name = "型号";
            型号.ReadOnly = true;
            型号.Visible = true;
            型号.Width = 100;
            // 
            // 料件名
            // 
            DataGridViewTextBoxColumn 料件名 = new DataGridViewTextBoxColumn();
            料件名.DataPropertyName = "品名";
            料件名.HeaderText = "料件名";
            料件名.Name = "料件名";
            料件名.ReadOnly = true;
            料件名.Visible = true;
            料件名.Width = 150;
            // 
            // 项号
            // 
            DataGridViewTextBoxColumn 项号 = new DataGridViewTextBoxColumn();
            项号.DataPropertyName = "项号";
            项号.HeaderText = "项号";
            项号.Name = "项号";
            项号.ReadOnly = true;
            项号.Visible = true;
            项号.Width = 60;
            // 
            // 商品编码
            // 
            DataGridViewTextBoxColumn 商品编码 = new DataGridViewTextBoxColumn();
            商品编码.DataPropertyName = "商品编码";
            商品编码.HeaderText = "商品编码";
            商品编码.Name = "商品编码";
            商品编码.ReadOnly = true;
            商品编码.Visible = true;
            商品编码.Width = 80;
            // 
            // 商品名称
            // 
            DataGridViewTextBoxColumn 商品名称 = new DataGridViewTextBoxColumn();
            商品名称.DataPropertyName = "商品名称";
            商品名称.HeaderText = "商品名称";
            商品名称.Name = "商品名称";
            商品名称.ReadOnly = true;
            商品名称.Visible = true;
            商品名称.Width = 80;
            // 
            // 规格型号
            // 
            DataGridViewTextBoxColumn 规格型号 = new DataGridViewTextBoxColumn();
            规格型号.DataPropertyName = "规格型号";
            规格型号.HeaderText = "规格型号";
            规格型号.Name = "规格型号";
            规格型号.ReadOnly = true;
            规格型号.Visible = true;
            // 
            // 计量单位
            // 
            DataGridViewTextBoxColumn 计量单位 = new DataGridViewTextBoxColumn();
            计量单位.DataPropertyName = "计量单位";
            计量单位.HeaderText = "计量单位";
            计量单位.Name = "计量单位";
            计量单位.ReadOnly = true;
            计量单位.Visible = true;
            // 
            // 数量
            // 
            DataGridViewTextBoxColumn 数量 = new DataGridViewTextBoxColumn();
            数量.DataPropertyName = "数量";
            数量.HeaderText = "数量";
            数量.Name = "数量";
            数量.ReadOnly = true;
            数量.Visible = true;
            数量.Width = 60;
            // 
            // 单位
            // 
            DataGridViewTextBoxColumn 单位 = new DataGridViewTextBoxColumn();
            单位.DataPropertyName = "单位";
            单位.HeaderText = "单位";
            单位.Name = "单位";
            单位.ReadOnly = true;
            单位.Visible = true;
            单位.Width = 60;
            // 
            // 单耗
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewTextBoxColumn 单耗 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            单耗.DefaultCellStyle = dataGridViewCellStyle1;
            单耗.DataPropertyName = "单耗";
            单耗.HeaderText = "单耗";
            单耗.Name = "单耗";
            单耗.ReadOnly = true;
            单耗.Visible = true;
            单耗.Width = 60;
            // 
            // 单耗单位
            // 
            DataGridViewTextBoxColumn 单耗单位 = new DataGridViewTextBoxColumn();
            单耗单位.DataPropertyName = "单耗单位";
            单耗单位.HeaderText = "单位";
            单耗单位.Name = "单耗单位";
            单耗单位.ReadOnly = true;
            单耗单位.Visible = true;
            单耗单位.Width = 78;
            this.dgv_ModifyBefore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{料件id,料件型号,型号,料件名,项号,商品编码,商品名称,
            规格型号,计量单位,数量,单位,单耗,单耗单位});

            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_ModifyBefore.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextModifyBefore;
            }
        }

        private void InitModifyBeforeDetail()
        {
            this.dgv_ModifyBeforeDetail.AutoGenerateColumns = false;
            // 
            // 产品配件报关材料表id
            // 
            DataGridViewTextBoxColumn 产品配件报关材料表id = new DataGridViewTextBoxColumn();
            产品配件报关材料表id.DataPropertyName = "产品配件报关材料表id";
            产品配件报关材料表id.HeaderText = "产品配件报关材料表id";
            产品配件报关材料表id.Name = "产品配件报关材料表id";
            产品配件报关材料表id.ReadOnly = true;
            产品配件报关材料表id.Visible = false;
            // 
            // 产品id
            // 
            DataGridViewTextBoxColumn 产品id = new DataGridViewTextBoxColumn();
            产品id.DataPropertyName = "产品id";
            产品id.HeaderText = "产品id";
            产品id.Name = "产品id";
            产品id.ReadOnly = true;
            产品id.Visible = false;
            // 
            // 配件id
            // 
            DataGridViewTextBoxColumn 配件id = new DataGridViewTextBoxColumn();
            配件id.DataPropertyName = "配件id";
            配件id.HeaderText = "配件id";
            配件id.Name = "配件id";
            配件id.ReadOnly = true;
            配件id.Visible = false;
            // 
            // 料件id
            // 
            DataGridViewTextBoxColumn 料件id = new DataGridViewTextBoxColumn();
            料件id.DataPropertyName = "料件id";
            料件id.HeaderText = "料件id";
            料件id.Name = "料件id";
            料件id.ReadOnly = true;
            料件id.Visible = false;
            // 
            // 序号
            // 
            DataGridViewTextBoxColumn 序号 = new DataGridViewTextBoxColumn();
            序号.DataPropertyName = "序号";
            序号.HeaderText = "序号";
            序号.Name = "序号";
            序号.ReadOnly = true;
            序号.Visible = true;
            // 
            // 报关类别
            // 
            DataGridViewTextBoxColumn 报关类别 = new DataGridViewTextBoxColumn();
            报关类别.DataPropertyName = "报关类别";
            报关类别.HeaderText = "报关类别";
            报关类别.Name = "报关类别";
            报关类别.ReadOnly = true;
            报关类别.Visible = true;
            // 
            // 数量
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewTextBoxColumn 数量 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            数量.DefaultCellStyle = dataGridViewCellStyle1;
            数量.DataPropertyName = "数量";
            数量.HeaderText = "数量";
            数量.Name = "数量";
            数量.ReadOnly = false;
            数量.Visible = true;
            数量.Width = 60;
            // 
            // 单位
            // 
            DataGridViewTextBoxColumn 单位 = new DataGridViewTextBoxColumn();
            单位.DataPropertyName = "单位";
            单位.HeaderText = "单位";
            单位.Name = "单位";
            单位.ReadOnly = true;
            单位.Visible = true;
            单位.Width = 60;
            // 
            // 单重
            // 
            DataGridViewTextBoxColumn 单重 = new DataGridViewTextBoxColumn();
            单重.DataPropertyName = "单重";
            单重.HeaderText = "单重";
            单重.Name = "单重";
            单重.ReadOnly = true;
            单重.Visible = false;
            // 
            // 单重单位
            // 
            DataGridViewTextBoxColumn 单重单位 = new DataGridViewTextBoxColumn();
            单重单位.DataPropertyName = "单重单位";
            单重单位.HeaderText = "单重单位";
            单重单位.Name = "单重单位";
            单重单位.ReadOnly = true;
            单重单位.Visible = false;
            // 
            // 备注
            // 
            DataGridViewTextBoxColumn 备注 = new DataGridViewTextBoxColumn();
            备注.DataPropertyName = "备注";
            备注.HeaderText = "备注";
            备注.Name = "备注";
            备注.ReadOnly = false;
            备注.Visible = true;
            this.dgv_ModifyBeforeDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { 产品配件报关材料表id ,产品id,配件id
                                 ,料件id ,序号,报关类别,数量 ,单位,单重,单重单位,备注});

            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_ModifyBeforeDetail.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextModifyBefore;
            }
        }

        private void InitModifyAfterHead()
        {
            this.dgv_ModifyAfterHead.AutoGenerateColumns = false;
            // 
            // 产品配件改样报关材料明细表id
            // 
            DataGridViewTextBoxColumn 产品配件改样报关材料明细表id = new DataGridViewTextBoxColumn();
            产品配件改样报关材料明细表id.DataPropertyName = "产品配件改样报关材料明细表id";
            产品配件改样报关材料明细表id.HeaderText = "产品配件改样报关材料明细表id";
            产品配件改样报关材料明细表id.Name = "产品配件改样报关材料明细表id";
            产品配件改样报关材料明细表id.ReadOnly = true;
            产品配件改样报关材料明细表id.Visible = false;
            // 
            // 订单id
            // 
            DataGridViewTextBoxColumn 订单id = new DataGridViewTextBoxColumn();
            订单id.DataPropertyName = "订单id";
            订单id.HeaderText = "订单id";
            订单id.Name = "订单id";
            订单id.ReadOnly = true;
            订单id.Visible = false;
            // 
            // 订单明细表id
            // 
            DataGridViewTextBoxColumn 订单明细表id = new DataGridViewTextBoxColumn();
            订单明细表id.DataPropertyName = "订单明细表id";
            订单明细表id.HeaderText = "订单明细表id";
            订单明细表id.Name = "订单明细表id";
            订单明细表id.ReadOnly = true;
            订单明细表id.Visible = false;
            // 
            // 产品id
            // 
            DataGridViewTextBoxColumn 产品id = new DataGridViewTextBoxColumn();
            产品id.DataPropertyName = "产品id";
            产品id.HeaderText = "产品id";
            产品id.Name = "产品id";
            产品id.ReadOnly = true;
            产品id.Visible = false;
            // 
            // 配件id
            // 
            DataGridViewTextBoxColumn 配件id = new DataGridViewTextBoxColumn();
            配件id.DataPropertyName = "配件id";
            配件id.HeaderText = "配件id";
            配件id.Name = "配件id";
            配件id.ReadOnly = true;
            配件id.Visible = false;
            // 
            // 料件型号
            // 
            DataGridViewTextBoxColumn 料件型号 = new DataGridViewTextBoxColumn();
            料件型号.DataPropertyName = "型号";
            料件型号.HeaderText = "料件型号";
            料件型号.Name = "型号";
            料件型号.ReadOnly = false;
            料件型号.Visible = true;
            料件型号.Width = 78;
            // 
            // 型号
            // 
            DataGridViewTextBoxColumn 型号 = new DataGridViewTextBoxColumn();
            型号.DataPropertyName = "显示型号";
            型号.HeaderText = "型号";
            型号.Name = "显示型号";
            型号.ReadOnly = false;
            型号.Visible = true;
            型号.Width = 78;
            // 
            // 料件id
            // 
            DataGridViewTextBoxColumn 料件id = new DataGridViewTextBoxColumn();
            料件id.DataPropertyName = "料件id";
            料件id.HeaderText = "料件id";
            料件id.Name = "料件id";
            料件id.ReadOnly = true;
            料件id.Visible = true;
            料件id.Width = 70;
            // 
            // 料件名
            // 
            DataGridViewTextBoxColumn 料件名 = new DataGridViewTextBoxColumn();
            料件名.DataPropertyName = "品名";
            料件名.HeaderText = "料件名";
            料件名.Name = "品名";
            料件名.ReadOnly = true;
            料件名.Visible = true;
            料件名.Width = 78;
            // 
            // 项号
            // 
            DataGridViewTextBoxColumn 项号 = new DataGridViewTextBoxColumn();
            项号.DataPropertyName = "项号";
            项号.HeaderText = "项号";
            项号.Name = "项号";
            项号.ReadOnly = true;
            项号.Visible = true;
            项号.Width = 60;
            // 
            // 编号
            // 
            DataGridViewTextBoxColumn 编号 = new DataGridViewTextBoxColumn();
            编号.DataPropertyName = "编号";
            编号.HeaderText = "编号";
            编号.Name = "编号";
            编号.ReadOnly = true;
            编号.Visible = false;
            编号.Width = 60;
            // 
            // 商品编码
            // 
            DataGridViewTextBoxColumn 商品编码 = new DataGridViewTextBoxColumn();
            商品编码.DataPropertyName = "商品编码";
            商品编码.HeaderText = "商品编码";
            商品编码.Name = "商品编码";
            商品编码.ReadOnly = true;
            商品编码.Visible = true;
            商品编码.Width = 78;
            // 
            // 商品名称
            // 
            DataGridViewTextBoxColumn 商品名称 = new DataGridViewTextBoxColumn();
            商品名称.DataPropertyName = "商品名称";
            商品名称.HeaderText = "商品名称";
            商品名称.Name = "商品名称";
            商品名称.ReadOnly = true;
            商品名称.Visible = true;
            商品名称.Width = 78;
            // 
            // 规格型号
            // 
            DataGridViewTextBoxColumn 规格型号 = new DataGridViewTextBoxColumn();
            规格型号.DataPropertyName = "规格型号";
            规格型号.HeaderText = "规格型号";
            规格型号.Name = "规格型号";
            规格型号.ReadOnly = true;
            规格型号.Visible = true;
            规格型号.Width = 78;
            // 
            // 计量单位
            // 
            DataGridViewTextBoxColumn 计量单位 = new DataGridViewTextBoxColumn();
            计量单位.DataPropertyName = "计量单位";
            计量单位.HeaderText = "计量单位";
            计量单位.Name = "计量单位";
            计量单位.ReadOnly = true;
            计量单位.Visible = true;
            计量单位.Width = 78;
            // 
            // 数量
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewTextBoxColumn 数量 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle1.Format = "N1";
            dataGridViewCellStyle1.NullValue = null;
            数量.DefaultCellStyle = dataGridViewCellStyle1;
            数量.DataPropertyName = "数量";
            数量.HeaderText = "数量";
            数量.Name = "数量";
            数量.ReadOnly = false;
            数量.Visible = true;
            数量.Width = 60;
            // 
            // 单位
            // 
            DataGridViewTextBoxColumn 单位 = new DataGridViewTextBoxColumn();
            单位.DataPropertyName = "单位";
            单位.HeaderText = "单位";
            单位.Name = "单位";
            单位.ReadOnly = true;
            单位.Visible = true;
            单位.Width = 60;
            // 
            // 换算率
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewTextBoxColumn 换算率 = new DataGridViewTextBoxColumn();
            换算率.DataPropertyName = "换算率";
            dataGridViewCellStyle2.Format = "N5";
            dataGridViewCellStyle2.NullValue = null;
            换算率.DefaultCellStyle = dataGridViewCellStyle2;
            换算率.HeaderText = "换算率";
            换算率.Name = "换算率";
            换算率.ReadOnly = false;
            换算率.Visible = true;
            换算率.Width = 78;
            // 
            // 单耗
            // 
            DataGridViewTextBoxColumn 单耗 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle2.Format = "N5";
            dataGridViewCellStyle2.NullValue = null;
            单耗.DefaultCellStyle = dataGridViewCellStyle2;
            单耗.DataPropertyName = "单耗";
            单耗.HeaderText = "单耗";
            单耗.Name = "单耗";
            单耗.ReadOnly = true;
            单耗.Visible = true;
            单耗.Width = 60;
            // 
            // 单耗单位
            // 
            DataGridViewTextBoxColumn 单耗单位 = new DataGridViewTextBoxColumn();
            单耗单位.DataPropertyName = "单耗单位";
            单耗单位.HeaderText = "单耗单位";
            单耗单位.Name = "单耗单位";
            单耗单位.ReadOnly = true;
            单耗单位.Visible = true;
            单耗单位.Width = 78;
            // 
            // 损耗率
            // 
            DataGridViewTextBoxColumn 损耗率 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle2.Format = "N5";
            dataGridViewCellStyle2.NullValue = null;
            损耗率.DefaultCellStyle = dataGridViewCellStyle2;
            损耗率.DataPropertyName = "损耗率";
            损耗率.HeaderText = "损耗率";
            损耗率.Name = "损耗率";
            损耗率.ReadOnly = true;
            损耗率.Visible = true;
            损耗率.Width = 78;
            // 
            // 剩余库存量
            // 
            DataGridViewTextBoxColumn 剩余库存量 = new DataGridViewTextBoxColumn();
            剩余库存量.DataPropertyName = "剩余库存量";
            剩余库存量.HeaderText = "剩余库存量";
            剩余库存量.Name = "剩余库存量";
            剩余库存量.ReadOnly = true;
            剩余库存量.Visible = true;
            this.dgv_ModifyAfterHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{产品配件改样报关材料明细表id,订单id,
            订单明细表id,产品id,配件id,料件型号,型号,料件id,料件名,项号,编号,商品编码,商品名称,
            规格型号,计量单位,数量,单位,换算率,单耗,单耗单位,损耗率,剩余库存量});
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_ModifyAfterHead.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextModifyAfterHead;
            }
        }

        private void InitModifyAfterDetail()
        {
            this.dgv_ModifyAfterDetail.AutoGenerateColumns = false;
            // 
            // 产品配件改样报关材料表id
            // 
            DataGridViewTextBoxColumn 产品配件改样报关材料表id = new DataGridViewTextBoxColumn();
            产品配件改样报关材料表id.DataPropertyName = "产品配件改样报关材料表id";
            产品配件改样报关材料表id.HeaderText = "产品配件改样报关材料表id";
            产品配件改样报关材料表id.Name = "产品配件改样报关材料表id";
            产品配件改样报关材料表id.ReadOnly = true;
            产品配件改样报关材料表id.Visible = false;
            // 
            // 订单id
            // 
            DataGridViewTextBoxColumn 订单id = new DataGridViewTextBoxColumn();
            订单id.DataPropertyName = "订单id";
            订单id.HeaderText = "订单id";
            订单id.Name = "订单id";
            订单id.ReadOnly = true;
            订单id.Visible = false;
            // 
            // 订单明细表id
            // 
            DataGridViewTextBoxColumn 订单明细表id = new DataGridViewTextBoxColumn();
            订单明细表id.DataPropertyName = "订单明细表id";
            订单明细表id.HeaderText = "订单明细表id";
            订单明细表id.Name = "订单明细表id";
            订单明细表id.ReadOnly = true;
            订单明细表id.Visible = false;
            // 
            // 产品id
            // 
            DataGridViewTextBoxColumn 产品id = new DataGridViewTextBoxColumn();
            产品id.DataPropertyName = "产品id";
            产品id.HeaderText = "产品id";
            产品id.Name = "产品id";
            产品id.ReadOnly = true;
            产品id.Visible = false;
            // 
            // 配件id
            // 
            DataGridViewTextBoxColumn 配件id = new DataGridViewTextBoxColumn();
            配件id.DataPropertyName = "配件id";
            配件id.HeaderText = "配件id";
            配件id.Name = "配件id";
            配件id.ReadOnly = true;
            配件id.Visible = false;
            // 
            // 料件id
            // 
            DataGridViewTextBoxColumn 料件id = new DataGridViewTextBoxColumn();
            料件id.DataPropertyName = "料件id";
            料件id.HeaderText = "料件id";
            料件id.Name = "料件id";
            料件id.ReadOnly = true;
            料件id.Visible = true;
            料件id.Width = 70;
            // 
            // 料件型号
            // 
            DataGridViewTextBoxColumn 料件型号 = new DataGridViewTextBoxColumn();
            料件型号.DataPropertyName = "料件型号";
            料件型号.HeaderText = "料件型号";
            料件型号.Name = "料件型号";
            料件型号.ReadOnly = true;
            料件型号.Visible = true;
            料件型号.Width = 78;
            // 
            // 编号
            // 
            DataGridViewTextBoxColumn 编号 = new DataGridViewTextBoxColumn();
            编号.DataPropertyName = "编号";
            编号.HeaderText = "型号";
            编号.Name = "编号";
            编号.ReadOnly = false;
            编号.Visible = true;
            编号.Width = 78;
            // 
            // 料件名
            // 
            DataGridViewTextBoxColumn 料件名 = new DataGridViewTextBoxColumn();
            料件名.DataPropertyName = "品名";
            料件名.HeaderText = "料件名";
            料件名.Name = "品名";
            料件名.ReadOnly = true;
            料件名.Visible = true;
            料件名.Width = 78;
            // 
            // 序号
            // 
            DataGridViewTextBoxColumn 序号 = new DataGridViewTextBoxColumn();
            序号.DataPropertyName = "序号";
            序号.HeaderText = "序号";
            序号.Name = "序号";
            序号.ReadOnly = true;
            序号.Visible = true;
            序号.Width = 55;
            // 
            // 区域
            // 
            DataGridViewTextBoxColumn 区域 = new DataGridViewTextBoxColumn();
            区域.DataPropertyName = "区域";
            区域.HeaderText = "区域";
            区域.Name = "区域";
            区域.ReadOnly = true;
            区域.Visible = true;
            区域.Width = 55;
            // 
            // 商品编码
            // 
            DataGridViewTextBoxColumn 商品编码 = new DataGridViewTextBoxColumn();
            商品编码.DataPropertyName = "商品编码";
            商品编码.HeaderText = "商品编码";
            商品编码.Name = "商品编码";
            商品编码.ReadOnly = true;
            商品编码.Visible = true;
            商品编码.Width = 78;
            // 
            // 商品名称
            // 
            DataGridViewTextBoxColumn 商品名称 = new DataGridViewTextBoxColumn();
            商品名称.DataPropertyName = "商品名称";
            商品名称.HeaderText = "商品名称";
            商品名称.Name = "商品名称";
            商品名称.ReadOnly = true;
            商品名称.Visible = true;
            商品名称.Width = 78;
            // 
            // 规格型号
            // 
            DataGridViewTextBoxColumn 规格型号 = new DataGridViewTextBoxColumn();
            规格型号.DataPropertyName = "规格型号";
            规格型号.HeaderText = "规格型号";
            规格型号.Name = "规格型号";
            规格型号.ReadOnly = true;
            规格型号.Visible = true;
            规格型号.Width = 78;
            // 
            // 计量单位
            // 
            DataGridViewTextBoxColumn 计量单位 = new DataGridViewTextBoxColumn();
            计量单位.DataPropertyName = "计量单位";
            计量单位.HeaderText = "计量单位";
            计量单位.Name = "计量单位";
            计量单位.ReadOnly = true;
            计量单位.Visible = true;
            计量单位.Width = 78;
            // 
            // 数量
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewTextBoxColumn 数量 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            数量.DefaultCellStyle = dataGridViewCellStyle1;
            数量.DataPropertyName = "数量";
            数量.HeaderText = "单耗";
            数量.Name = "数量";
            数量.ReadOnly = false;
            数量.Visible = true;
            数量.Width = 60;
            // 
            // 单位
            // 
            DataGridViewTextBoxColumn 单位 = new DataGridViewTextBoxColumn();
            单位.DataPropertyName = "单位";
            单位.HeaderText = "单位";
            单位.Name = "单位";
            单位.ReadOnly = true;
            单位.Visible = true;
            单位.Width = 60;
            // 
            // 损耗率
            // 
            DataGridViewTextBoxColumn 损耗率 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            损耗率.DefaultCellStyle = dataGridViewCellStyle1;
            损耗率.DataPropertyName = "损耗率";
            损耗率.HeaderText = "损耗率";
            损耗率.Name = "损耗率";
            损耗率.ReadOnly = false;
            损耗率.Visible = true;
            损耗率.Width = 70;
            // 
            // 备注
            // 
            DataGridViewTextBoxColumn 备注 = new DataGridViewTextBoxColumn();
            备注.DataPropertyName = "备注";
            备注.HeaderText = "备注";
            备注.Name = "备注";
            备注.ReadOnly = false;
            备注.Visible = true;
            // 
            // 剩余库存量
            // 
            DataGridViewTextBoxColumn 剩余库存量 = new DataGridViewTextBoxColumn();
            剩余库存量.DataPropertyName = "剩余库存量";
            剩余库存量.HeaderText = "剩余库存量";
            剩余库存量.Name = "剩余库存量";
            剩余库存量.ReadOnly = true;
            剩余库存量.Visible = true;

            this.dgv_ModifyAfterDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{产品配件改样报关材料表id,订单id ,订单明细表id ,产品id ,
                配件id ,料件id ,料件型号,编号 ,料件名 ,序号,区域,商品编码 ,商品名称 ,规格型号 ,计量单位,数量 ,单位,损耗率,备注 ,剩余库存量});
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_ModifyAfterDetail.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextModifyAfterDetail;
            }

            //料件型号.DisplayIndex = 0;
            //编号.DisplayIndex = 1;
            //料件名.DisplayIndex = 2;
            //序号.DisplayIndex = 3;
            //区域.DisplayIndex = 4;
            //商品编码.DisplayIndex = 5;
            //商品名称.DisplayIndex = 6;
            //规格型号.DisplayIndex = 7;
            //计量单位.DisplayIndex = 8;
            //数量.DisplayIndex = 9;
            //单位.DisplayIndex = 10;
            //损耗率.DisplayIndex = 11;
            //备注.DisplayIndex = 12;
            //剩余库存量.DisplayIndex = 13;
        }

        private void InitMergeAfterHead()
        {
            // 
            // 订单id
            // 
            DataGridViewTextBoxColumn 订单id = new DataGridViewTextBoxColumn();
            订单id.DataPropertyName = "订单id";
            订单id.HeaderText = "订单id";
            订单id.Name = "订单id";
            订单id.ReadOnly = true;
            订单id.Visible = false;
            // 
            // 订单明细表id
            // 
            DataGridViewTextBoxColumn 订单明细表id = new DataGridViewTextBoxColumn();
            订单明细表id.DataPropertyName = "订单明细表id";
            订单明细表id.HeaderText = "订单明细表id";
            订单明细表id.Name = "订单明细表id";
            订单明细表id.ReadOnly = true;
            订单明细表id.Visible = false;
            // 
            // 产品id
            // 
            DataGridViewTextBoxColumn 产品id = new DataGridViewTextBoxColumn();
            产品id.DataPropertyName = "产品id";
            产品id.HeaderText = "产品id";
            产品id.Name = "产品id";
            产品id.ReadOnly = true;
            产品id.Visible = false;
            // 
            // 配件id
            // 
            DataGridViewTextBoxColumn 配件id = new DataGridViewTextBoxColumn();
            配件id.DataPropertyName = "配件id";
            配件id.HeaderText = "配件id";
            配件id.Name = "配件id";
            配件id.ReadOnly = true;
            配件id.Visible = false;
            // 
            // 号
            // 
            DataGridViewTextBoxColumn 号 = new DataGridViewTextBoxColumn();
            号.DataPropertyName = "号";
            号.HeaderText = "号";
            号.Name = "号";
            号.ReadOnly = true;
            号.Visible = false;
            // 
            // 项
            // 
            DataGridViewTextBoxColumn 项 = new DataGridViewTextBoxColumn();
            项.DataPropertyName = "项";
            项.HeaderText = "项";
            项.Name = "项";
            项.ReadOnly = true;
            项.Visible = false;
            // 
            // 项号
            // 
            DataGridViewTextBoxColumn 项号 = new DataGridViewTextBoxColumn();
            项号.DataPropertyName = "项号";
            项号.HeaderText = "项号";
            项号.Name = "项号";
            项号.ReadOnly = true;
            项号.Visible = true;
            项号.Width = 70;
            // 
            // 商品编码
            // 
            DataGridViewTextBoxColumn 商品编码 = new DataGridViewTextBoxColumn();
            商品编码.DataPropertyName = "商品编码";
            商品编码.HeaderText = "商品编码";
            商品编码.Name = "商品编码";
            商品编码.ReadOnly = true;
            商品编码.Visible = true;
            // 
            // 商品名称
            // 
            DataGridViewTextBoxColumn 商品名称 = new DataGridViewTextBoxColumn();
            商品名称.DataPropertyName = "商品名称";
            商品名称.HeaderText = "商品名称";
            商品名称.Name = "商品名称";
            商品名称.ReadOnly = true;
            商品名称.Visible = true;
            // 
            // 规格型号
            // 
            DataGridViewTextBoxColumn 规格型号 = new DataGridViewTextBoxColumn();
            规格型号.DataPropertyName = "规格型号";
            规格型号.HeaderText = "规格型号";
            规格型号.Name = "规格型号";
            规格型号.ReadOnly = true;
            规格型号.Visible = true;
            规格型号.Width = 150;
            // 
            // 计量单位
            // 
            DataGridViewTextBoxColumn 计量单位 = new DataGridViewTextBoxColumn();
            计量单位.DataPropertyName = "计量单位";
            计量单位.HeaderText = "计量单位";
            计量单位.Name = "计量单位";
            计量单位.ReadOnly = true;
            计量单位.Visible = true;
            计量单位.Width = 78;
            // 
            // 单耗
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewTextBoxColumn 单耗 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            单耗.DefaultCellStyle = dataGridViewCellStyle1;
            单耗.DataPropertyName = "单耗";
            单耗.HeaderText = "单耗/净耗";
            单耗.Name = "单耗";
            单耗.ReadOnly = true;
            单耗.Visible = true;
            // 
            // 损耗率
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewTextBoxColumn 损耗率 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            损耗率.DefaultCellStyle = dataGridViewCellStyle2;
            损耗率.DataPropertyName = "损耗率";
            损耗率.HeaderText = "损耗率";
            损耗率.Name = "损耗率";
            损耗率.ReadOnly = true;
            损耗率.Visible = true;
            损耗率.Width = 70;
            // 
            // 非保科料件比率
            // 
            DataGridViewTextBoxColumn 非保科料件比率 = new DataGridViewTextBoxColumn();
            非保科料件比率.DataPropertyName = "非保科料件比率";
            非保科料件比率.HeaderText = "非保科料件比率";
            非保科料件比率.Name = "非保科料件比率";
            非保科料件比率.ReadOnly = true;
            非保科料件比率.Visible = true;
            非保科料件比率.Width = 120;


            this.dgv_MergerAfterHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{订单id ,订单明细表id ,产品id ,
                配件id ,号 ,项,项号,商品编码 ,商品名称 ,规格型号 ,计量单位,单耗 ,损耗率,非保科料件比率});
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_MergerAfterHead.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMergerAfterHead;
            }
        }

        private void InitMergeAfterDetail()
        {
            // 
            // 项号
            // 
            DataGridViewTextBoxColumn 项号 = new DataGridViewTextBoxColumn();
            项号.DataPropertyName = "项号";
            项号.HeaderText = "项号";
            项号.Name = "项号";
            项号.ReadOnly = true;
            项号.Visible = true;
            项号.Width = 70;
            // 
            // 商品编码
            // 
            DataGridViewTextBoxColumn 商品编码 = new DataGridViewTextBoxColumn();
            商品编码.DataPropertyName = "商品编码";
            商品编码.HeaderText = "商品编码";
            商品编码.Name = "商品编码";
            商品编码.ReadOnly = true;
            商品编码.Visible = true;
            // 
            // 商品名称
            // 
            DataGridViewTextBoxColumn 商品名称 = new DataGridViewTextBoxColumn();
            商品名称.DataPropertyName = "商品名称";
            商品名称.HeaderText = "商品名称";
            商品名称.Name = "商品名称";
            商品名称.ReadOnly = true;
            商品名称.Visible = true;
            // 
            // 规格型号
            // 
            DataGridViewTextBoxColumn 规格型号 = new DataGridViewTextBoxColumn();
            规格型号.DataPropertyName = "规格型号";
            规格型号.HeaderText = "规格型号";
            规格型号.Name = "规格型号";
            规格型号.ReadOnly = true;
            规格型号.Visible = true;
            规格型号.Width = 150;
            // 
            // 计量单位
            // 
            DataGridViewTextBoxColumn 计量单位 = new DataGridViewTextBoxColumn();
            计量单位.DataPropertyName = "计量单位";
            计量单位.HeaderText = "计量单位";
            计量单位.Name = "计量单位";
            计量单位.ReadOnly = true;
            计量单位.Visible = true;
            计量单位.Width = 78;
            // 
            // 单耗
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewTextBoxColumn 单耗 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            单耗.DefaultCellStyle = dataGridViewCellStyle1;
            单耗.DataPropertyName = "单耗";
            单耗.HeaderText = "单耗/净耗";
            单耗.Name = "单耗";
            单耗.ReadOnly = true;
            单耗.Visible = true;
            // 
            // 损耗率
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewTextBoxColumn 损耗率 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            损耗率.DefaultCellStyle = dataGridViewCellStyle2;
            损耗率.DataPropertyName = "损耗率";
            损耗率.HeaderText = "损耗率";
            损耗率.Name = "损耗率";
            损耗率.ReadOnly = true;
            损耗率.Visible = true;
            损耗率.Width = 70;
            // 
            // 料件项号
            // 
            DataGridViewTextBoxColumn 料件项号 = new DataGridViewTextBoxColumn();
            料件项号.DataPropertyName = "料件项号";
            料件项号.HeaderText = "料件项号";
            料件项号.Name = "料件项号";
            料件项号.ReadOnly = true;
            料件项号.Visible = false;
            // 
            // 备案净耗单位
            // 
            DataGridViewTextBoxColumn 备案净耗单位 = new DataGridViewTextBoxColumn();
            备案净耗单位.DataPropertyName = "备案净耗单位";
            备案净耗单位.HeaderText = "备案净耗单位";
            备案净耗单位.Name = "备案净耗单位";
            备案净耗单位.ReadOnly = true;
            备案净耗单位.Visible = false;
            // 
            // 明细表申报单位
            // 
            DataGridViewTextBoxColumn 明细表申报单位 = new DataGridViewTextBoxColumn();
            明细表申报单位.DataPropertyName = "明细表申报单位";
            明细表申报单位.HeaderText = "明细表申报单位";
            明细表申报单位.Name = "明细表申报单位";
            明细表申报单位.ReadOnly = true;
            明细表申报单位.Visible = false;
            // 
            // 非保科料件比率
            // 
            DataGridViewTextBoxColumn 非保科料件比率 = new DataGridViewTextBoxColumn();
            非保科料件比率.DataPropertyName = "非保科料件比率";
            非保科料件比率.HeaderText = "非保科料件比率";
            非保科料件比率.Name = "非保科料件比率";
            非保科料件比率.ReadOnly = true;
            非保科料件比率.Visible = true;
            非保科料件比率.Width = 120;

            this.dgv_MergerAfterDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{项号,商品编码 ,商品名称 ,规格型号 ,计量单位,单耗 ,损耗率,
                料件项号,备案净耗单位,明细表申报单位,非保科料件比率});
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_MergerAfterDetail.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMergerAfterDetail;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadDataSource()
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            string strSQL = string.Empty;
            #region 改样前料件组成
            if (Fid == 0)
            {
                strSQL = string.Format("产品报关料件组成 '{0}','{1}'",mstrName,ManualCode);
            }
            else
            {
                strSQL = string.Format("配件报关料件组成 '{0}','{1}'", mstrName, ManualCode);
            }
            dtModifyBefore = dataAccess.GetTable(strSQL, null);
            if (dtModifyBefore.Rows.Count == 0)
                dtModifyBefore.Rows.Add(dtModifyBefore.NewRow());
            this.dgv_ModifyBefore.DataSource = dtModifyBefore;
            #endregion

            #region 改样前报关料件明细材料
            if (Fid == 0)
            {
                strSQL = string.Format("SELECT * FROM 产品配件报关材料表 WHERE 产品id={0} order by 序号", Pid);
            }
            else
            {
                strSQL = string.Format("SELECT * FROM 产品配件报关材料表 WHERE 配件id={0} order by 序号", Pid);
            }
            dtModifyBeforeDetail = dataAccess.GetTable(strSQL, null);
            if (dtModifyBeforeDetail.Rows.Count == 0)
                dtModifyBeforeDetail.Rows.Add(dtModifyBeforeDetail.NewRow());
            this.dgv_ModifyBeforeDetail.DataSource = dtModifyBeforeDetail;
            #endregion

            #region 改样后料件组成
            if (Fid == 0)
            {
                strSQL = string.Format(@"SELECT * FROM 产品配件改样报关材料明细表 WHERE 订单id={0} and 订单明细表id={1} and 产品id={2} order by str(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end),str(case when PATINDEX('%-%',项号)=0 then '' else SUBSTRING(项号,PATINDEX('%-%',项号)+1,len(项号)-PATINDEX('%-%',项号)) end)",
                                            OrderId, OrderListId, Pid);
            }
            else
            {
                strSQL = string.Format(@"SELECT * FROM 产品配件改样报关材料明细表 WHERE 订单id={0} and 订单明细表id={1} and 配件id={2} order by str(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end),str(case when PATINDEX('%-%',项号)=0 then '' else SUBSTRING(项号,PATINDEX('%-%',项号)+1,len(项号)-PATINDEX('%-%',项号)) end)",
                                            OrderId, OrderListId, Fid);
            }
            dtModifyAfterHead = dataAccess.GetTable(strSQL, null);
            if (dtModifyAfterHead.Rows.Count == 0)
                dtModifyAfterHeadAddRow();
            this.dgv_ModifyAfterHead.DataSource = dtModifyAfterHead;
            #endregion

            #region 改样后报关料件明细材料
            if (Fid == 0)
            {
                strSQL = string.Format("SELECT * FROM 产品配件改样报关材料表 WHERE 订单id={0} and 订单明细表id={1} and 产品id={2} order by 编号", OrderId, OrderListId, Pid);
            }
            else
            {
                strSQL = string.Format("SELECT * FROM 产品配件改样报关材料表 WHERE 订单id={0} and 订单明细表id={1} and 配件id={2} order by 编号", OrderId, OrderListId, Fid);
            }
            dtModifyAfterDetail = dataAccess.GetTable(strSQL, null);
            if (dtModifyAfterDetail.Rows.Count == 0)
                dtModifyAfterDetailAddRow();
            this.dgv_ModifyAfterDetail.DataSource = dtModifyAfterDetail;
            dataAccess.Close();
            #endregion

            txt_总重.Text = FactWeight.ToString();
            txt_实际总重.Text = AllWeight.ToString();
            this.Text = string.Format("{0} 结构组成", mstrName);
        }
        /// <summary>
        /// 加载归并后料件数据
        /// </summary>
        private void LoadSourceMergeAfter()
        {
            string strSQL = string.Empty;
            if (Fid == 0)
            {
                strSQL = string.Format(@"SELECT L.订单id, L.订单明细表id, isnull(L.产品id,0) as 产品id, isnull(L.配件id,0) as 配件id,
                                                str(case when PATINDEX('%-%',L.项号)=0 then L.项号 else SUBSTRING(L.项号,1,PATINDEX('%-%',L.项号)-1) end)  AS 号, 
                                                str(case when PATINDEX('%-%',L.项号)=0 then '' else SUBSTRING(L.项号,PATINDEX('%-%',L.项号)+1,len(L.项号)-PATINDEX('%-%',L.项号)) end)  AS 项,
                                                L.项号, L.商品编码, L.商品名称,H.商品规格 AS 规格型号,L.计量单位, str(sum(L.单耗*(1-case when L.损耗率 is null then 0 else 0 end)), 10, 5) AS 单耗, L.损耗率 
                                         From dbo.产品配件改样报关材料明细表 L left outer join 归并后料件清单 H on H.产品编号=substring(L.编号,1,3) 
                                                where left(ltrim(L.显示型号),1)='A' and  H.电子帐册号={0} AND L.订单id ={1} and L.订单明细表id ={2} and L.产品id = {3}
                                                group by L.订单id, L.订单明细表id, isnull(L.产品id,0), isnull(L.配件id,0),
                                                        str(case when PATINDEX('%-%',L.项号)=0 then L.项号 else SUBSTRING(L.项号,1,PATINDEX('%-%',L.项号)-1) end), 
                                                        str(case when PATINDEX('%-%',L.项号)=0 then '' else SUBSTRING(L.项号,PATINDEX('%-%',L.项号)+1,len(L.项号)-PATINDEX('%-%',L.项号)) end),
                                                        L.项号, L.商品编码, L.商品名称,H.商品规格,L.计量单位,L.损耗率
                                        Union All SELECT 订单id, 订单明细表id, 产品id, 配件id,str(序号),str(''), LTRIM(STR(序号)),商品编码,商品名称,规格型号,计量单位, 
                                                str(数量*(1-case when 损耗率 is null then 0 else 0 end), 10, 5),损耗率 
                                        From dbo.产品配件改样报关材料表 where 区域='A' AND 订单id ={1} and 订单明细表id ={2} and 产品id ={3} order by 号,项",
                                               StringTools.SqlQ(ManualCode), OrderId, OrderListId, Pid);
            }
            else
            {
                strSQL = string.Format(@"SELECT L.订单id, L.订单明细表id, isnull(L.产品id,0) as 产品id, isnull(L.配件id,0) as 配件id,
                                                str(case when PATINDEX('%-%',L.项号)=0 then L.项号 else SUBSTRING(L.项号,1,PATINDEX('%-%',L.项号)-1) end)  AS 号, 
                                                str(case when PATINDEX('%-%',L.项号)=0 then '' else SUBSTRING(L.项号,PATINDEX('%-%',L.项号)+1,len(L.项号)-PATINDEX('%-%',L.项号)) end)  AS 项,
                                                L.项号, L.商品编码, L.商品名称,H.商品规格 AS 规格型号,L.计量单位, str(sum(L.单耗*(1-case when L.损耗率 is null then 0 else 0 end)),10, 5) AS 单耗,L.损耗率 
                                        From dbo.产品配件改样报关材料明细表 L left outer join 归并后料件清单 H on H.产品编号=substring(L.编号,1,3) 
                                            where left(ltrim(L.显示型号),1)='A' and  H.电子帐册号{0} AND L.订单id ={1} and L.订单明细表id ={2} and L.配件id ={3}
                                                    group by L.订单id, L.订单明细表id, isnull(L.产品id,0), isnull(L.配件id,0),
                                                    str(case when PATINDEX('%-%',L.项号)=0 then L.项号 else SUBSTRING(L.项号,1,PATINDEX('%-%',L.项号)-1) end), 
                                                    str(case when PATINDEX('%-%',L.项号)=0 then '' else SUBSTRING(L.项号,PATINDEX('%-%',L.项号)+1,len(L.项号)-PATINDEX('%-%',L.项号)) end),
                                                    L.项号, L.商品编码, L.商品名称,H.商品规格,L.计量单位,L.损耗率
                                        Union All SELECT 订单id, 订单明细表id, 产品id, 配件id,str(序号),str(''),LTRIM(STR(序号)),商品编码,商品名称,规格型号,计量单位,
                                                str(数量*(1-case when 损耗率 is null then 0 else 0 end), 10, 5),损耗率 
                                        From dbo.产品配件改样报关材料表 where  区域='A' AND 订单id ={1} and 订单明细表id ={2} and 配件id ={3} order by  号,项",
                                               StringTools.SqlQ(ManualCode), OrderId, OrderListId, Fid);
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtMergeAfterHead = dataAccess.GetTable(strSQL, null);  //归并后订单料件汇总明细
            if (dtMergeAfterHead.Rows.Count == 0)
                dtMergeAfterHead.Rows.Add(dtMergeAfterHead.NewRow());
            strSQL = string.Format("exec 归并后料件汇总明细 {0},{1},{2},{3},{4}", Pid, Fid, OrderId, OrderListId, StringTools.SqlQ(ManualCode));
            dtMergeAfterDetail = dataAccess.GetTable(strSQL, null);
            if (dtMergeAfterDetail.Rows.Count == 0)
                dtMergeAfterDetail.Rows.Add(dtMergeAfterDetail.NewRow());
            dataAccess.Close();
            dgv_MergerAfterHead.DataSource = dtMergeAfterHead;
            dgv_MergerAfterDetail.DataSource = dtMergeAfterDetail;
        }

        private void SaveModifyAfterDetail()
        {
            string strSQL = string.Empty;
            foreach (DataRow row in dtModifyAfterDetail.Rows)
            {
                #region 新增行
                if (row.RowState == DataRowState.Added)
                {
                    if (row["料件id"] == DBNull.Value) continue;
                    strSQL += string.Format(@"INSERT INTO [产品配件改样报关材料表]
                                               ([订单id],[订单明细表id],[产品id],[配件id],[料件id],[料件型号],[序号],[编号]
                                               ,[品名],[商品编码],[商品名称],[规格型号],[计量单位],[数量],[单位],[备注] ,[损耗率] ,[区域],[剩余库存量])
                                         VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18})" + Environment.NewLine,
                                         row["订单id"] == DBNull.Value ? "NULL" : row["订单id"],
                                         row["订单明细表id"] == DBNull.Value ? "NULL" : row["订单明细表id"],
                                         row["产品id"] == DBNull.Value ? "NULL" : row["产品id"],
                                         row["配件id"] == DBNull.Value ? "NULL" : row["配件id"],
                                         row["料件id"] == DBNull.Value ? "NULL" : row["料件id"],
                                         row["料件型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["料件型号"].ToString()),
                                         row["序号"] == DBNull.Value ? "NULL" : row["序号"],
                                         row["编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["编号"].ToString()),
                                         row["品名"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["品名"].ToString()),
                                         row["商品编码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品编码"].ToString()),
                                         row["商品名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品名称"].ToString()),
                                         row["规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["规格型号"].ToString()),
                                         row["计量单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["计量单位"].ToString()),
                                         row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                         row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                         row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()),
                                         row["损耗率"] == DBNull.Value ? "NULL" : row["损耗率"],
                                         row["区域"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["区域"].ToString()),
                                         row["剩余库存量"] == DBNull.Value ? "NULL" : row["剩余库存量"]);
                }
                #endregion

                #region 删除行
                else if (row.RowState == DataRowState.Deleted)
                {
                    if (row["产品配件改样报关材料表id", DataRowVersion.Original] == DBNull.Value) continue;
                    strSQL += string.Format("DELETE FROM [dbo].[产品配件改样报关材料表] WHERE [产品配件改样报关材料表id]={0}" + Environment.NewLine, row["产品配件改样报关材料表id", DataRowVersion.Original]);
                }
                #endregion

                #region 修改行
                else if (row.RowState == DataRowState.Modified)
                {
                    if (row["产品配件改样报关订单材料表id"] == DBNull.Value) continue;
                    strSQL += string.Format(@"UPDATE [Manufacture].[dbo].[产品配件改样报关材料表]
                                                   SET [订单id] = {0},[订单明细表id] ={1},[产品id] = {2} ,[配件id] = {3},[料件id] = {4}
                                                      ,[料件型号] = {5},[序号] = {6},[编号] = {7},[品名] ={8} ,[商品编码] ={9} ,[商品名称] = {10}
                                                      ,[规格型号] = {11},[计量单位] = {12},[数量] = {13} ,[单位] = {14} ,[备注] = {15}
                                                      ,[损耗率] = {16},[区域] = {17},[剩余库存量]={18}
                                                 WHERE 产品配件改样报关材料表id={19}",
                                         row["订单id"] == DBNull.Value ? "NULL" : row["订单id"],
                                         row["订单明细表id"] == DBNull.Value ? "NULL" : row["订单明细表id"],
                                         row["产品id"] == DBNull.Value ? "NULL" : row["产品id"],
                                         row["配件id"] == DBNull.Value ? "NULL" : row["配件id"],
                                         row["料件id"] == DBNull.Value ? "NULL" : row["料件id"],
                                         row["料件型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["料件型号"].ToString()),
                                         row["序号"] == DBNull.Value ? "NULL" : row["序号"],
                                         row["编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["编号"].ToString()),
                                         row["品名"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["品名"].ToString()),
                                         row["商品编码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品编码"].ToString()),
                                         row["商品名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品名称"].ToString()),
                                         row["规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["规格型号"].ToString()),
                                         row["计量单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["计量单位"].ToString()),
                                         row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                         row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                         row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()),
                                         row["损耗率"] == DBNull.Value ? "NULL" : row["损耗率"],
                                         row["区域"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["区域"].ToString()),
                                         row["剩余库存量"] == DBNull.Value ? "NULL" : row["剩余库存量"],
                                         row["产品配件改样报关材料表id"] == DBNull.Value ? "NULL" : row["产品配件改样报关材料表id"]);
                }
                #endregion
            }
            if (strSQL.Length > 0)
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
                dtModifyAfterDetail.AcceptChanges();
            }
            Sum总重();
        }
        private void SaveModifyAfterHead()
        {
            string strSQL = string.Empty;
            foreach (DataRow row in dtModifyAfterHead.Rows)
            {
                #region 新增行
                if (row.RowState == DataRowState.Added)
                {
                    if (row["料件id"] == DBNull.Value) continue;
                    strSQL += string.Format(@"INSERT INTO [dbo].[产品配件改样报关材料明细表]
                                           ([订单id],[订单明细表id],[产品id],[配件id],[料件id],[型号],[显示型号],[品名],[项号],[编号]
                                           ,[商品编码],[商品名称],[规格型号],[计量单位],[数量],[单位],[单耗],[单耗单位],[损耗率],[换算率],[剩余库存量])
                                     VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20})" + Environment.NewLine,
                                    row["订单id"] == DBNull.Value ? "NULL" : row["订单id"],
                                    row["订单明细表id"] == DBNull.Value ? "NULL" : row["订单明细表id"],
                                    row["产品id"] == DBNull.Value ? "NULL" : row["产品id"],
                                    row["配件id"] == DBNull.Value ? "NULL" : row["配件id"],
                                    row["料件id"] == DBNull.Value ? "NULL" : row["料件id"],
                                    row["型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["型号"].ToString()),
                                    row["显示型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["显示型号"].ToString()),
                                    row["品名"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["品名"].ToString()),
                                    row["项号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["项号"].ToString()),
                                    row["编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["编号"].ToString()),
                                    row["商品编码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品编码"].ToString()),
                                    row["商品名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品名称"].ToString()),
                                    row["规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["规格型号"].ToString()),
                                    row["计量单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["计量单位"].ToString()),
                                    row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                    row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                    row["单耗"] == DBNull.Value ? "NULL" : row["单耗"],
                                    row["单耗单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单耗单位"].ToString()),
                                    row["损耗率"] == DBNull.Value ? "NULL" : row["损耗率"],
                                    row["换算率"] == DBNull.Value ? "NULL" : row["换算率"],
                                    row["剩余库存量"] == DBNull.Value ? "NULL" : row["剩余库存量"]);
                }
                #endregion

                #region 删除行
                else if (row.RowState == DataRowState.Deleted)
                {
                    if (row["产品配件改样报关材料明细表id", DataRowVersion.Original] == DBNull.Value) continue;
                    strSQL += string.Format("DELETE FROM [dbo].[产品配件改样报关材料明细表] WHERE [产品配件改样报关材料明细表id]={0}" + Environment.NewLine, row["产品配件改样报关材料明细表id", DataRowVersion.Original]);
                }
                #endregion

                #region 修改行
                else if (row.RowState == DataRowState.Modified)
                {
                    if (row["产品配件改样报关材料明细表id"] == DBNull.Value) continue;
                    strSQL += string.Format(@"UPDATE [dbo].[产品配件改样报关材料明细表] SET [订单id] = {0},[订单明细表id] ={1},[产品id] = {2},[配件id] = {3},[料件id] = {4}
                                          ,[型号] ={5},[显示型号] ={6},[品名] = {7},[项号] = {8},[编号] = {9},[商品编码] = {10},[商品名称] = {11},[规格型号] = {12},[计量单位] = {13},[数量] = {14}
                                          ,[单位] = {15},[单耗] = {16},[单耗单位] = {17},[损耗率] = {18},[换算率] = {19},剩余库存量={20} WHERE [产品配件改样报关材料明细表id]={21}" + Environment.NewLine,
                                    row["订单id"] == DBNull.Value ? "NULL" : row["订单id"],
                                    row["订单明细表id"] == DBNull.Value ? "NULL" : row["订单明细表id"],
                                    row["产品id"] == DBNull.Value ? "NULL" : row["产品id"],
                                    row["配件id"] == DBNull.Value ? "NULL" : row["配件id"],
                                    row["料件id"] == DBNull.Value ? "NULL" : row["料件id"],
                                    row["型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["型号"].ToString()),
                                    row["显示型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["显示型号"].ToString()),
                                    row["品名"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["品名"].ToString()),
                                    row["项号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["项号"].ToString()),
                                    row["编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["编号"].ToString()),
                                    row["商品编码"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品编码"].ToString()),
                                    row["商品名称"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["商品名称"].ToString()),
                                    row["规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["规格型号"].ToString()),
                                    row["计量单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["计量单位"].ToString()),
                                    row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                    row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                    row["单耗"] == DBNull.Value ? "NULL" : row["单耗"],
                                    row["单耗单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单耗单位"].ToString()),
                                    row["损耗率"] == DBNull.Value ? "NULL" : row["损耗率"],
                                    row["换算率"] == DBNull.Value ? "NULL" : row["换算率"],
                                    row["剩余库存量"] == DBNull.Value ? "NULL" : row["剩余库存量"],
                                    row["产品配件改样报关材料明细表id"] == DBNull.Value ? "NULL" : row["产品配件改样报关材料明细表id"]);
                }
                #endregion
            }
            if (strSQL.Length > 0)
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
                dtModifyAfterHead.AcceptChanges();
            }
            Sum总重();
        }
        private void SaveModifyBeforeDetail()
        {
            string strSQL = string.Empty;
            foreach (DataRow row in dtModifyBeforeDetail.Rows)
            {
                #region 新增行
                if (row.RowState == DataRowState.Added)
                {
                    if (row["料件id"] == DBNull.Value) continue;
                    strSQL += string.Format(@"INSERT INTO [产品配件报关材料表]([产品id],[配件id],[料件id],[序号],[报关类别],[数量],[单位],[单重],[单重单位],[备注])
                                         VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9})" + Environment.NewLine,
                                         row["产品id"] == DBNull.Value ? "NULL" : row["产品id"],
                                         row["配件id"] == DBNull.Value ? "NULL" : row["配件id"],
                                         row["料件id"] == DBNull.Value ? "NULL" : row["料件id"],
                                         row["序号"] == DBNull.Value ? "NULL" : row["序号"],
                                         row["报关类别"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["报关类别"].ToString()),
                                         row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                         row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
                                         row["单重"] == DBNull.Value ? "NULL" : row["单重"],
                                         row["单重单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ( row["单重单位"].ToString()),
                                         row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()));
                }
                #endregion

                #region 删除行
                else if (row.RowState == DataRowState.Deleted)
                {
                    if (row["产品配件报关材料表id", DataRowVersion.Original] == DBNull.Value) continue;
                    strSQL += string.Format("DELETE FROM [dbo].[产品配件报关材料表] WHERE [产品配件报关材料表id]={0}" + Environment.NewLine, row["产品配件报关材料表id", DataRowVersion.Original]);
                }
                #endregion

                #region 修改行
                else if (row.RowState == DataRowState.Modified)
                {
                    if (row["产品配件报关材料表id"] == DBNull.Value) continue;
//                    strSQL += string.Format(@"UPDATE [产品配件报关材料表] SET [产品id] = {0},[配件id] = {1},[料件id] ={2},[序号] = {3},[报关类别] ={4},[数量] = {5},
//                                                [单位] = {6} ,[单重] = {7},[单重单位] = {8},[备注] = {9} WHERE 产品配件报关材料表id={10}",
//                                        row["产品id"] == DBNull.Value ? "NULL" : row["产品id"],
//                                         row["配件id"] == DBNull.Value ? "NULL" : row["配件id"],
//                                         row["料件id"] == DBNull.Value ? "NULL" : row["料件id"],
//                                         row["序号"] == DBNull.Value ? "NULL" : row["序号"],
//                                         row["报关类别"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["报关类别"].ToString()),
//                                         row["数量"] == DBNull.Value ? "NULL" : row["数量"],
//                                         row["单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单位"].ToString()),
//                                         row["单重"] == DBNull.Value ? "NULL" : row["单重"],
//                                         row["单重单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["单重单位"].ToString()),
//                                         row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()),
//                                         row["产品配件报关材料表id"] == DBNull.Value ? "NULL" : row["产品配件报关材料表id"]);
                    strSQL += string.Format(@"UPDATE [产品配件报关材料表] SET [数量] = {0},[备注] = {1} WHERE 产品配件报关材料表id={2}",
                                         row["数量"] == DBNull.Value ? "NULL" : row["数量"],
                                         row["备注"] == DBNull.Value ? "NULL" : StringTools.SqlQ(row["备注"].ToString()),
                                         row["产品配件报关材料表id"] == DBNull.Value ? "NULL" : row["产品配件报关材料表id"]);
                }
                #endregion
            }
            if (strSQL.Length > 0)
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
                dtModifyBeforeDetail.AcceptChanges();
            }
        }

        private void Sum总重()
        {
            FactWeight = 0;
            foreach (DataRow row in dtModifyAfterHead.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                FactWeight += row["单耗"] == DBNull.Value ? 0 : float.Parse(row["单耗"].ToString());
            }
            foreach (DataRow row in dtModifyAfterDetail.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                FactWeight += float.Parse(row["数量"].ToString());
            }
            if (FactWeight != 0)
            {
                FactWeight = FactWeight * 1000;
                txt_总重.Text = FactWeight.ToString();
            }
        }
        /// <summary>
        /// 检查数据是否有修改，并返回对应的操作选项
        /// Yes：保存资料，并继续;；No：不保存资料，并继续；Cancel：取消操作，返回界面
        /// </summary>
        /// <returns>Yes：保存资料，并继续;；No：不保存资料，并继续；Cancel：取消操作，返回界面</returns>
        private DialogResult CheckModify()
        {
            bool bModify = false;
            if (!bModify)
            {
                for (int iRow = 0; iRow < dtModifyAfterHead.Rows.Count; iRow++)
                {
                    DataRow row = dtModifyAfterHead.Rows[iRow];
                    if (iRow == 0)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            bModify = true;
                            break;
                        }
                        else if (row.RowState == DataRowState.Added)  //如果是新增状态，则判断客人型号、优丽型号是否为空
                        {
                            if (row["料件id"] != DBNull.Value || row["料件id"].ToString().Trim().Length > 0)
                            {
                                bModify = true;
                                break;
                            }
                        }
                        else if (row.RowState == DataRowState.Deleted)
                        {
                            if (row["产品配件改样报关订单材料明细表id", DataRowVersion.Original] != DBNull.Value)
                            {
                                bModify = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (row.RowState != DataRowState.Unchanged)
                        {
                            bModify = true;
                            break;
                        }
                    }
                }
            }
            //如果表头没异动，再判断表身是否有异动
            if (!bModify)
            {
                for (int iRow = 0; iRow < dtModifyAfterDetail.Rows.Count; iRow++)
                {
                    DataRow row = dtModifyAfterDetail.Rows[iRow];
                    if (iRow == 0)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            bModify = true;
                            break;
                        }
                        else if (row.RowState == DataRowState.Added)  //如果是新增状态，则判断客人型号、优丽型号是否为空
                        {
                            if (row["料件id"] != DBNull.Value || row["料件id"].ToString().Trim().Length > 0)
                            {
                                bModify = true;
                                break;
                            }
                        }
                        else if (row.RowState == DataRowState.Deleted)
                        {
                            if (row["产品配件改样报关订单材料表id", DataRowVersion.Original] != DBNull.Value)
                            {
                                bModify = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (row.RowState != DataRowState.Unchanged)
                        {
                            bModify = true;
                            break;
                        }
                    }
                }
            }

            if (bModify)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine("当前资料未保存，请选择是否保存！");
                strBuilder.AppendLine("是：保存资料，并继续");
                strBuilder.AppendLine("否：不保存资料，并继续");
                strBuilder.AppendLine("取消：取消操作，返回界面");
                return SysMessage.YesNoCancelMsg(strBuilder.ToString());
            }
            return DialogResult.No;
        }

        /// <summary>
        /// 改样后表头GRID增加一条新行
        /// </summary>
        private void dtModifyAfterHeadAddRow()
        {
            DataRow newRow = dtModifyAfterHead.NewRow();
            newRow["数量"] = "0.0";
            newRow["订单id"] = OrderId;
            newRow["订单明细表id"] = OrderListId;
            if (Pid == 0)
            {
                newRow["产品id"] = DBNull.Value;
            }
            else
            {
                newRow["产品id"] = Pid;
            }
            if (Fid == 0)
            {
                newRow["配件id"] = DBNull.Value;
            }
            else
            {
                newRow["配件id"] = Fid;
            }
            dtModifyAfterHead.Rows.Add(newRow);
        }

        /// <summary>
        /// 改样后明细GRID增加一条新行
        /// </summary>
        private void dtModifyAfterDetailAddRow()
        {
            DataRow newRow = dtModifyAfterDetail.NewRow();
            newRow["订单id"] = OrderId;
            newRow["订单明细表id"] = OrderListId;
            if (Pid == 0)
            {
                newRow["产品id"] = DBNull.Value;
            }
            else
            {
                newRow["产品id"] = Pid;
            }
            if (Fid == 0)
            {
                newRow["配件id"] = DBNull.Value;
            }
            else
            {
                newRow["配件id"] = Fid;
            }
            newRow["单位"] = "KGS";
            newRow["区域"] = "A";
            newRow["数量"] = "0.00000";
            dtModifyAfterDetail.Rows.Add(newRow);
        }
        #endregion

        #region tool事件
        public override void tool_Save_Click(object sender, EventArgs e)
        {
            base.tool_Save_Click(sender, e);
            SaveModifyAfterHead();
            SaveModifyAfterDetail();
            SaveModifyBeforeDetail();
            LoadDataSource();
        }
        
        public override void tool_Close_Click(object sender, EventArgs e)
        {
            base.tool_Close_Click(sender, e);
            this.Close();
        }
        #endregion

        #region dgv_ModifyAfterHead事件
        public override void dgv_ModifyAfterHead_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            base.dgv_ModifyAfterHead_DataError(sender, e);
            myDataGridView dgv = (myDataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "数量" || colName == "换算率" || colName == "单耗" || colName == "耗损率")
                e.Cancel = false;
        }
        public override void dgv_ModifyAfterHead_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.dgv_ModifyAfterHead_KeyPress(sender, e);
            if (e.KeyChar == SystemConst.GridKeysEnter)
            {
                myDataGridView dgv = sender as myDataGridView;
                DataGridViewCell cell = dgv.CurrentCell;
                GridModifyAfterHeadKeyEnter(dgv, cell, true);
            }
        }

        public override void dgv_ModifyAfterHead_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            base.dgv_ModifyAfterHead_CellEndEdit(sender, e);
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridModifyAfterHeadKeyEnter(dgv, cell, false);
        }

        /// <summary>
        /// GRID的回车事件
        /// </summary>
        /// <param name="dgv">Grid对象</param>
        /// <param name="cell">焦点CELL</param>
        /// <param name="bKeyEnter">是否按回车触发的事件</param>
        private void GridModifyAfterHeadKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
        {
            if (!bCellKeyPress) return;
            string colName = dgv.Columns[cell.ColumnIndex].Name;
            switch (colName)
            {
                case "型号":  //料件型号
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["型号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate型号(dgv, cell))
                        {
                            //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["型号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate型号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "显示型号":  //型号
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["显示型号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate显示型号(dgv, cell))
                        {
                            //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["显示型号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate显示型号(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "料件id":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["料件名", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "品名"://料件名
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["项号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "项号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品编码", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品编码":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品名称", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品名称":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["规格型号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "规格型号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["计量单位", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "计量单位":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["数量", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "数量":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (StringTools.decimalParse( dgv.CurrentRow.Cells["数量"].Value.ToString()) ==StringTools.decimalParse( cell.EditedFormattedValue.ToString()))
                        {
                            dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                        }
                        else
                        {
                            validate数量(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["数量"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate数量(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "换算率":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["换算率"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            dgv.CurrentCell = dgv["单耗", cell.RowIndex];
                        }
                        else
                        {
                            validate换算率(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["单耗", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["换算率"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate换算率(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "单耗":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["单耗单位", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "单耗单位":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "损耗率":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        //如果当前行的客人型号为空，则跳转到当前行的客人型号
                        if (dgv.Rows[cell.RowIndex].Cells["型号"].Value == DBNull.Value
                            || dgv.Rows[cell.RowIndex].Cells["型号"].Value.ToString().Trim() == "")
                        {
                            dgv.CurrentCell = dgv["型号", cell.RowIndex];
                        }
                        else
                        {
                            //否则跳转到下一行的客人型号，如果是最后一行，则新增一行
                            if (cell.RowIndex == dgv.Rows.Count - 1)
                            {
                                //int iRow = dgv.Rows.Add();
                                //dgv.CurrentCell = dgv["客人型号", iRow];
                                dtModifyAfterHeadAddRow();
                                dgv.CurrentCell = dgv["型号", cell.RowIndex + 1];
                            }
                            else
                            {
                                dgv.CurrentCell = dgv["型号", cell.RowIndex + 1];
                            }
                        }
                        //dgv.CurrentCell = dgv["型号", cell.RowIndex];
                    }
                    #endregion
                    break;
            }
        }
        /// <summary>
        /// 验证型号合法性
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool validate型号(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Empty;
            if (ManualCode == "B37167420012")
            {
                strSQL = string.Format("帮助录入查询 {0},15 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else if (ManualCode == "B37168420019")
            {
                strSQL = string.Format("帮助录入查询 {0},17 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else
            {
                strSQL = string.Format("帮助录入查询 {0},16 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count == 1)
            {
                DataRow row = dtData.Rows[0];
                dgv.Rows[cell.RowIndex].Cells["料件id"].Value = row["料件id"];
                dgv.Rows[cell.RowIndex].Cells["型号"].Value = row["料件型号"];
                dgv.Rows[cell.RowIndex].Cells["显示型号"].Value = row["显示型号"];
                dgv.Rows[cell.RowIndex].Cells["品名"].Value = row["料件名"];
                dgv.Rows[cell.RowIndex].Cells["单位"].Value = row["料件单位"];
                check库存量(dgv, cell);
            }
            else if (dtData.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择资料";
                formSelect.dtData = dtData;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dgv.Rows[cell.RowIndex].Cells["料件id"].Value = formSelect.returnRow["料件id"];
                    dgv.Rows[cell.RowIndex].Cells["型号"].Value = formSelect.returnRow["料件型号"];
                    dgv.Rows[cell.RowIndex].Cells["显示型号"].Value = formSelect.returnRow["显示型号"];
                    dgv.Rows[cell.RowIndex].Cells["品名"].Value = formSelect.returnRow["料件名"];
                    dgv.Rows[cell.RowIndex].Cells["单位"].Value = formSelect.returnRow["料件单位"];
                    check库存量(dgv, cell);
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            else
            {
                SysMessage.InformationMsg("此料件不存在！");
                dgv.CurrentCell = cell;
                return false;
            }

            if (dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString() != "")
            {
                strSQL = string.Format(@"SELECT H.序号,H.商品编码, H.商品名称, Q.商品规格, H.计量单位,H.计量单位,H.损耗率 
                                                FROM dbo.归并后料件清单 H LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id 
                                            where H.序号={0} AND H.电子帐册号='{1}'",
                                               StringTools.intParse( dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(1, 2)), ManualCode);
                dataAccess.Open();
                dtData = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtData.Rows.Count > 0)
                {
                    DataRow row = dtData.Rows[0];
                    dgv.Rows[cell.RowIndex].Cells["项号"].Value =StringTools.intParse( dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(1, 2)) + "-"
                        + StringTools.intParse( dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(3, 2));
                    dgv.Rows[cell.RowIndex].Cells["商品编码"].Value = row["商品编码"];
                    if (dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(0, 1) == "A" ||
                        dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(0, 1) == "B")
                    {
                        dgv.Rows[cell.RowIndex].Cells["编号"].Value = dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(0, 8);
                    }
                    dgv.Rows[cell.RowIndex].Cells["商品编码"].Value = row["商品编码"];
                    dgv.Rows[cell.RowIndex].Cells["商品名称"].Value = row["商品名称"];
                    dgv.Rows[cell.RowIndex].Cells["规格型号"].Value = row["商品规格"];
                    dgv.Rows[cell.RowIndex].Cells["计量单位"].Value = row["计量单位"];
                    dgv.Rows[cell.RowIndex].Cells["单耗单位"].Value = "KGS";
                    dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = row["损耗率"];
                }
            }
            return true;
        }
        /// <summary>
        /// 验证显示型号合法性
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool validate显示型号(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Empty;
            if (ManualCode == "B37167420012")
            {
                strSQL = string.Format("帮助录入查询 {0},18 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else if (ManualCode == "B37168420019")
            {
                strSQL = string.Format("帮助录入查询 {0},20 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else
            {
                strSQL = string.Format("帮助录入查询 {0},19 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count == 1)
            {
                DataRow row = dtData.Rows[0];
                dgv.Rows[cell.RowIndex].Cells["料件id"].Value = row["料件id"];
                dgv.Rows[cell.RowIndex].Cells["型号"].Value = row["料件型号"];
                dgv.Rows[cell.RowIndex].Cells["显示型号"].Value = row["显示型号"];
                dgv.Rows[cell.RowIndex].Cells["品名"].Value = row["料件名"];
                dgv.Rows[cell.RowIndex].Cells["单位"].Value = row["料件单位"];
                check库存量(dgv, cell);
            }
            else if (dtData.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择资料";
                formSelect.dtData = dtData;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dgv.Rows[cell.RowIndex].Cells["料件id"].Value = formSelect.returnRow["料件id"];
                    dgv.Rows[cell.RowIndex].Cells["型号"].Value = formSelect.returnRow["料件型号"];
                    dgv.Rows[cell.RowIndex].Cells["显示型号"].Value = formSelect.returnRow["显示型号"];
                    dgv.Rows[cell.RowIndex].Cells["品名"].Value = formSelect.returnRow["料件名"];
                    dgv.Rows[cell.RowIndex].Cells["单位"].Value = formSelect.returnRow["料件单位"];
                    check库存量(dgv, cell);
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            else
            {
                SysMessage.InformationMsg("此料件不存在！");
                dgv.CurrentCell = cell;
                return false;
            }

            if (dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString() != "")
            {
                strSQL = string.Format(@"SELECT H.序号,H.商品编码, H.商品名称, Q.商品规格, H.计量单位,H.计量单位,H.损耗率 
                                                    FROM dbo.归并后料件清单 H LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id 
                                            where H.序号={0} AND H.电子帐册号='{1}'",
                                              StringTools.intParse(dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(1, 2)), ManualCode);
                dataAccess.Open();
                dtData = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtData.Rows.Count > 0)
                {
                    DataRow row = dtData.Rows[0];
                    dgv.Rows[cell.RowIndex].Cells["项号"].Value =StringTools.intParse( dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(1, 2)) + "-"
                        + StringTools.intParse( dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(3, 2));
                    dgv.Rows[cell.RowIndex].Cells["商品编码"].Value = row["商品编码"];
                    if (dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(0, 1) == "A" ||
                        dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(0, 1) == "B")
                    {
                        dgv.Rows[cell.RowIndex].Cells["编号"].Value = dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString().Substring(0, 8);
                    }
                    dgv.Rows[cell.RowIndex].Cells["商品编码"].Value = row["商品编码"];
                    dgv.Rows[cell.RowIndex].Cells["商品名称"].Value = row["商品名称"];
                    dgv.Rows[cell.RowIndex].Cells["规格型号"].Value = row["商品规格"];
                    dgv.Rows[cell.RowIndex].Cells["计量单位"].Value = row["计量单位"];
                    dgv.Rows[cell.RowIndex].Cells["单耗单位"].Value = "KGS";
                    dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = row["损耗率"];
                }
            }
            return true;
        }
        /// <summary>
        /// 验证数量合法性
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private void validate数量(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["数量"].Value = 0;
                //数量*换算率=单耗
                dgv.Rows[cell.RowIndex].Cells["单耗"].Value = 0;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                    if (dgv.Rows[cell.RowIndex].Cells["换算率"].Value != DBNull.Value)
                    {
                        dgv.Rows[cell.RowIndex].Cells["单耗"].Value = Convert.ToDecimal(cell.EditedFormattedValue) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["换算率"].Value);
                    }
                    (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                    //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                    //SaveModifyAfterHead();
                    check库存量(dgv, cell);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = 0;
                    //数量*换算率=单耗
                    dgv.Rows[cell.RowIndex].Cells["单耗"].Value = 0;
                }
            }
            Sum总重();
        }
        /// <summary>
        /// 验证换算率合法性
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private void validate换算率(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                //数量*换算率=单耗
                dgv.Rows[cell.RowIndex].Cells["换算率"].Value = 0;
                //数量*换算率=单耗
                dgv.Rows[cell.RowIndex].Cells["单耗"].Value = 0;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    decimal value = Convert.ToDecimal(cell.EditedFormattedValue);
                    dgv.Rows[cell.RowIndex].Cells["换算率"].Value = Math.Round(value, 5, MidpointRounding.AwayFromZero);
                    if (dgv.Rows[cell.RowIndex].Cells["数量"].Value != DBNull.Value)
                    {
                        //数量*换算率=单耗
                        dgv.Rows[cell.RowIndex].Cells["单耗"].Value = Convert.ToDecimal(cell.EditedFormattedValue) * Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["数量"].Value);
                    }
                    (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                    //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                    //SaveModifyAfterHead();
                    check库存量(dgv, cell);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["换算率"].Value = 0;
                    //数量*换算率=单耗
                    dgv.Rows[cell.RowIndex].Cells["单耗"].Value = 0;
                }
            }
            Sum总重();
        }
        /// <summary>
        /// 检查库存量
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        private void check库存量(myDataGridView dgv, DataGridViewCell cell)
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            //select sum(数量) as 库存量 from 单耗库存查询表  where 料件id =" & rs!料件id & " and 电子帐册号='" & ManualCode & "'
            string strSQL = string.Format("select sum(数量) as 库存量 from 单耗库存查询表  where 料件id ={0} and 电子帐册号={1}", dgv.Rows[cell.RowIndex].Cells["料件id"].Value, StringTools.SqlQ(ManualCode));
            DataTable dtTemp = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtTemp.Rows.Count > 0)
            {
                dgv.Rows[cell.RowIndex].Cells["剩余库存量"].Value = dtTemp.Rows[0]["库存量"];
                if (dgv.Rows[cell.RowIndex].Cells["剩余库存量"].Value ==DBNull.Value || Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["剩余库存量"].Value) < 0)
                {
                    SysMessage.InformationMsg("库存量不足，请更换");
                }
            }
        }
        #endregion
        
        #region dgv_ModifyAfterDetail事件
        public override void dgv_ModifyAfterDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            base.dgv_ModifyAfterDetail_CellEndEdit(sender, e);
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridModifyAfterDetailKeyEnter(dgv, cell, false);
        }

        public override void dgv_ModifyAfterDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.dgv_ModifyAfterDetail_KeyPress(sender, e);
            if (e.KeyChar == SystemConst.GridKeysEnter)
            {
                myDataGridView dgv = sender as myDataGridView;
                DataGridViewCell cell = dgv.CurrentCell;

                GridModifyAfterDetailKeyEnter(dgv, cell, true);
            }
        }

        public override void dgv_ModifyAfterDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            base.dgv_ModifyAfterDetail_DataError(sender, e);
            myDataGridView dgv = (myDataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "数量" || colName == "损耗率")
                e.Cancel = false;
        }

        /// <summary>
        /// GRID的回车事件
        /// </summary>
        /// <param name="dgv">Grid对象</param>
        /// <param name="cell">焦点CELL</param>
        /// <param name="bKeyEnter">是否按回车触发的事件</param>
        private void GridModifyAfterDetailKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
        {
            if (!bCellKeyPress) return;
            string colName = dgv.Columns[cell.ColumnIndex].Name;
            switch (colName)
            {
                case "编号":  //料件型号
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["编号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate编号2(dgv, cell))
                        {
                            //dtModifyAfterDetail.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (dgv.CurrentRow.Cells["编号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate编号2(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "料件型号":  //型号
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["编号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "料件id":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["料件型号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "序号"://耗损率
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "区域":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["序号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品编码":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["商品名称", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "商品名称":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["规格型号", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "规格型号":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["计量单位", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "计量单位":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["单位", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "单位":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "数量":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (StringTools.decimalParse( dgv.CurrentRow.Cells["数量"].Value.ToString()) ==StringTools.decimalParse( cell.EditedFormattedValue.ToString()))
                        {
                            dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                        }
                        else
                        {
                            validate数量2(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (StringTools.decimalParse( dgv.CurrentRow.Cells["数量"].Value.ToString()) !=StringTools.decimalParse( cell.EditedFormattedValue.ToString()))
                        {
                            validate数量2(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "备注":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                    }
                    #endregion
                    break;
                case "损耗率":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (StringTools.decimalParse( dgv.CurrentRow.Cells["损耗率"].Value.ToString()) ==StringTools.decimalParse( cell.EditedFormattedValue.ToString()))
                        {
                            bCellEndEdit = false;
                            //dgv.CurrentCell = dgv["料件id", cell.RowIndex];
                            //如果当前行的客人型号为空，则跳转到当前行的客人型号
                            if (dgv.Rows[cell.RowIndex].Cells["料件id"].Value == DBNull.Value
                                || dgv.Rows[cell.RowIndex].Cells["料件id"].Value.ToString().Trim() == "")
                            {
                                dgv.CurrentCell = dgv["料件id", cell.RowIndex];
                            }
                            else
                            {
                                //否则跳转到下一行的客人型号，如果是最后一行，则新增一行
                                if (cell.RowIndex == dgv.Rows.Count - 1)
                                {
                                    dtModifyAfterDetailAddRow();
                                    dgv.CurrentCell = dgv["料件id", cell.RowIndex + 1];
                                }
                                else
                                {
                                    dgv.CurrentCell = dgv["料件id", cell.RowIndex + 1];
                                }
                            }
                            bCellEndEdit = true;
                        }
                        else
                        {
                            validate损耗率2(dgv, cell);
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            //dgv.CurrentCell = dgv["料件id", cell.RowIndex];
                            //如果当前行的客人型号为空，则跳转到当前行的客人型号
                            if (dgv.Rows[cell.RowIndex].Cells["料件id"].Value == DBNull.Value
                                || dgv.Rows[cell.RowIndex].Cells["料件id"].Value.ToString().Trim() == "")
                            {
                                dgv.CurrentCell = dgv["料件id", cell.RowIndex];
                            }
                            else
                            {
                                //否则跳转到下一行的客人型号，如果是最后一行，则新增一行
                                if (cell.RowIndex == dgv.Rows.Count - 1)
                                {
                                    dtModifyAfterDetailAddRow();
                                    dgv.CurrentCell = dgv["料件id", cell.RowIndex + 1];
                                }
                                else
                                {
                                    dgv.CurrentCell = dgv["料件id", cell.RowIndex + 1];
                                }
                            }
                            bCellEndEdit = true;
                        }
                    }
                    else
                    {
                        if (StringTools.decimalParse( dgv.CurrentRow.Cells["损耗率"].Value.ToString()) != StringTools.decimalParse( cell.EditedFormattedValue.ToString()))
                        {
                            validate损耗率2(dgv, cell);
                        }
                    }
                    #endregion
                    break;
            }
        }

        /// <summary>
        /// 验证编号
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool validate编号2(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Empty;
            if (ManualCode == "B37167420012")
            {
                strSQL = string.Format("帮助录入查询 {0},18 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else if (ManualCode == "B37168420019")
            {
                strSQL = string.Format("帮助录入查询 {0},20 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else
            {
                strSQL = string.Format("帮助录入查询 {0},19 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            object 编号 = string.Empty;
            if (dtData.Rows.Count == 1)
            {
                DataRow row = dtData.Rows[0];
                dgv.Rows[cell.RowIndex].Cells["料件id"].Value = row["料件id"];
                dgv.Rows[cell.RowIndex].Cells["料件型号"].Value = row["料件型号"];
                dgv.Rows[cell.RowIndex].Cells["编号"].Value = row["显示型号"];
                编号 = row["显示型号"];
                dgv.Rows[cell.RowIndex].Cells["品名"].Value = row["料件名"];
                if (row["显示型号"] == DBNull.Value || row["显示型号"].ToString().Trim() == "")
                {
                    dgv.Rows[cell.RowIndex].Cells["区域"].Value = "A";
                }
                else if (row["显示型号"].ToString().Substring(0, 1) == "A" || row["显示型号"].ToString().Substring(0, 1) == "B")
                {
                    dgv.Rows[cell.RowIndex].Cells["区域"].Value = row["显示型号"].ToString().Substring(0, 1);
                }
                else
                {
                    dgv.Rows[cell.RowIndex].Cells["区域"].Value = "A";
                }
                check库存量(dgv, cell);
            }
            else if (dtData.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择资料";
                formSelect.dtData = dtData;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dgv.Rows[cell.RowIndex].Cells["料件id"].Value = formSelect.returnRow["料件id"];
                    dgv.Rows[cell.RowIndex].Cells["料件型号"].Value = formSelect.returnRow["料件型号"];
                    dgv.Rows[cell.RowIndex].Cells["编号"].Value = formSelect.returnRow["显示型号"];
                    编号 = formSelect.returnRow["显示型号"];
                    dgv.Rows[cell.RowIndex].Cells["品名"].Value = formSelect.returnRow["料件名"];
                    if (formSelect.returnRow["显示型号"] == DBNull.Value || formSelect.returnRow["显示型号"].ToString().Trim() == "")
                    {
                        dgv.Rows[cell.RowIndex].Cells["区域"].Value = "A";
                    }
                    else if (formSelect.returnRow["显示型号"].ToString().Substring(0, 1) == "A" || formSelect.returnRow["显示型号"].ToString().Substring(0, 1) == "B")
                    {
                        dgv.Rows[cell.RowIndex].Cells["区域"].Value = formSelect.returnRow["显示型号"].ToString().Substring(0, 1);
                    }
                    else
                    {
                        dgv.Rows[cell.RowIndex].Cells["区域"].Value = "A";
                    }
                    check库存量(dgv, cell);
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            else
            {
                SysMessage.InformationMsg("此料件不存在！");
                dgv.CurrentCell = cell;
                return false;
            }
            if (dgv.Rows[cell.RowIndex].Cells["编号"].Value.ToString().Trim() != "")
            {
                strSQL = string.Format(@"SELECT Q.产品编号,H.序号,H.商品编码, H.商品名称, H.商品规格, H.计量单位,H.计量单位,H.损耗率 
                                                FROM dbo.归并后料件清单 H LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id 
                                                where Q.产品编号='{0}' AND H.电子帐册号='{1}'",
                                                                         dgv.Rows[cell.RowIndex].Cells["编号"].Value.ToString().Substring(0, 5), ManualCode);
                dataAccess.Open();
                dtData = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtData.Rows.Count > 0)
                {
                    DataRow row = dtData.Rows[0];
                    dgv.Rows[cell.RowIndex].Cells["序号"].Value = row["序号"];
                    dgv.Rows[cell.RowIndex].Cells["商品编码"].Value = row["商品编码"];
                    dgv.Rows[cell.RowIndex].Cells["商品名称"].Value = row["商品名称"];
                    dgv.Rows[cell.RowIndex].Cells["规格型号"].Value = row["商品规格"];
                    dgv.Rows[cell.RowIndex].Cells["计量单位"].Value = row["计量单位"];
                    dgv.Rows[cell.RowIndex].Cells["单位"].Value = "KGS";
                    dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = row["损耗率"];
                    dgv.Rows[cell.RowIndex].Cells["编号"].Value = 编号;
                }
            }
            return true;
        }

        /// <summary>
        /// 验证改样后明细数量
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private void validate数量2(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["数量"].Value = 0;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = cell.EditedFormattedValue;
                    //dtModifyAfterDetail.Rows[cell.RowIndex].EndEdit();
                    (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                    //SaveModifyAfterDetail();
                    check库存量(dgv, cell);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = 0;
                }
            }
        }
        /// <summary>
        /// 验证改样后明细损耗率
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private void validate损耗率2(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = DBNull.Value;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = cell.EditedFormattedValue;
                    //dtModifyAfterDetail.Rows[cell.RowIndex].EndEdit();
                    (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                    //SaveModifyAfterDetail();
                    check库存量(dgv, cell);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = 0;
                }
            }
        }
        #endregion

        #region dgv_ModifyBeforeDetail事件
        private void dgv_ModifyBeforeDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridModifyBeforeDetailKeyEnter(dgv, cell, false);
        }

        private void dgv_ModifyBeforeDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            myDataGridView dgv = (myDataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "数量")
                e.Cancel = false;
        }

        private void dgv_ModifyBeforeDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == SystemConst.GridKeysEnter)
            {
                myDataGridView dgv = sender as myDataGridView;
                DataGridViewCell cell = dgv.CurrentCell;

                GridModifyBeforeDetailKeyEnter(dgv, cell, true);
            }
        }
        /// <summary>
        /// GRID的回车事件
        /// </summary>
        /// <param name="dgv">Grid对象</param>
        /// <param name="cell">焦点CELL</param>
        /// <param name="bKeyEnter">是否按回车触发的事件</param>
        private void GridModifyBeforeDetailKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
        {
            if (!bCellKeyPress) return;
            string colName = dgv.Columns[cell.ColumnIndex].Name;
            switch (colName)
            {
                case "序号":  //数量
                    dgv.CurrentCell = dgv["数量", cell.RowIndex];
                    break;
                case "报关类别":  //数量
                    dgv.CurrentCell = dgv["数量", cell.RowIndex];
                    break;
                case "单位":  //备注
                    dgv.CurrentCell = dgv["备注", cell.RowIndex];
                    break;
                case "数量": //单位
                    if (cell.EditedFormattedValue.ToString() == "")
                    {
                        dgv.Rows[cell.RowIndex].Cells["数量"].Value = 0;
                    }
                    else
                    {
                        try
                        {
                            decimal.Parse(cell.EditedFormattedValue.ToString());
                            dgv.Rows[cell.RowIndex].Cells["数量"].Value = cell.EditedFormattedValue;
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                        }
                        catch
                        {
                            dgv.Rows[cell.RowIndex].Cells["数量"].Value = 0;
                        }
                    }
                    dgv.CurrentCell = dgv["单位", cell.RowIndex];
                    break;
                case "备注":
                    #region CELL回车跳转
                    dgv.Rows[cell.RowIndex].Cells["备注"].Value = cell.EditedFormattedValue;
                    //否则跳转到下一行的客人型号，如果是最后一行，则新增一行
                    if (cell.RowIndex == dgv.Rows.Count - 1)
                    {
                        dgv.CurrentCell = dgv["序号", cell.RowIndex];
                    }
                    else
                    {
                        dgv.CurrentCell = dgv["序号", cell.RowIndex + 1];
                    }
                    #endregion
                    break;
            }
        }
        #endregion
    }
}
