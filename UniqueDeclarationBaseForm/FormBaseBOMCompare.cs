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

        #region 外面传进来的变量
        /// <summary>
        /// 型号
        /// </summary>
        public string mstrName = string.Empty;
        /// <summary>
        /// 改样后组成表头数据
        /// </summary>
        public DataTable dtModifyHeadTemp = null;
        /// <summary>
        /// 改样后组成明细数据
        /// </summary>
        public DataTable dtModifyDetailTemp = null;
        /// <summary>
        /// 历史改样后组成表头数据
        /// </summary>
        public DataTable dtModifyHeadHistoryTemp = null;
        /// <summary>
        /// 历史改样后组成明细数据
        /// </summary>
        public DataTable dtModifyDetailHistoryTemp = null;

        /// <summary>
        /// 改样后组成表头显示列名
        /// </summary>
        public List<string> listVisibleFieldModifyHead = new List<string>();
        /// <summary>
        /// 改样后组成明细显示列名
        /// </summary>
        public List<string> listVisibleFieldModifyDetail = new List<string>();
        /// <summary>
        /// 历史改样后组成表头显示列名
        /// </summary>
        public List<string> listVisibleFieldHistoryModifyHead = new List<string>();
        /// <summary>
        /// 历史改样后组成表头显示列名
        /// </summary>
        public List<string> listVisibleFieldHistoryModifyDetail = new List<string>();
        #endregion

        public DataTable dtReturnHead = null;
        public DataTable dtReturnDetail = null;
        private void FormBaseBOMCompare_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("【{0}】历史改样数据对比",mstrName);
            InitModifyHead();
            InitModifyDetail();
            InitHistoryModifyHead();
            InitHistoryModifyDetail();
            CompareDataTable(dtModifyHeadTemp, dtModifyHeadHistoryTemp);
            CompareDataTable(dtModifyDetailTemp, dtModifyDetailHistoryTemp);
            this.dgv_ModifyHead.DataSource = dtModifyHeadTemp;
            this.dgv_ModifyDetail.DataSource = dtModifyDetailTemp;
            this.dgv_HistoryModifyHead.DataSource = dtModifyHeadHistoryTemp;
            this.dgv_HistoryModifyDetail.DataSource = dtModifyDetailHistoryTemp;
        }


        private void InitModifyHead()
        {
            this.dgv_ModifyHead.AutoGenerateColumns = false;
            // 
            // 产品配件改样报关订单材料明细表id
            // 
            DataGridViewTextBoxColumn 产品配件改样报关订单材料明细表id = new DataGridViewTextBoxColumn();
            产品配件改样报关订单材料明细表id.DataPropertyName = "产品配件改样报关订单材料明细表id";
            产品配件改样报关订单材料明细表id.HeaderText = "产品配件改样报关订单材料明细表id";
            产品配件改样报关订单材料明细表id.Name = "产品配件改样报关订单材料明细表id";
            产品配件改样报关订单材料明细表id.ReadOnly = true;
            产品配件改样报关订单材料明细表id.Visible = false;
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
            // 单位1
            // 
            DataGridViewTextBoxColumn 单位1 = new DataGridViewTextBoxColumn();
            单位1.DataPropertyName = "单位1";
            单位1.HeaderText = "单位1";
            单位1.Name = "单位1";
            单位1.ReadOnly = true;
            单位1.Visible = false;
            单位1.Width = 78;

            // 
            // CompareResult
            // 
            DataGridViewTextBoxColumn CompareResult = new DataGridViewTextBoxColumn();
            CompareResult.DataPropertyName = "CompareResult";
            CompareResult.HeaderText = "CompareResult";
            CompareResult.Name = "CompareResult";
            CompareResult.ReadOnly = true;
            CompareResult.Visible = false;
            CompareResult.Width = 78;

            this.dgv_ModifyHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{产品配件改样报关订单材料明细表id,订单id,
            订单明细表id,产品id,配件id,料件型号,型号,料件id,料件名,项号,编号,商品编码,商品名称,
            规格型号,计量单位,数量,单位,换算率,单耗,单耗单位,损耗率,单位1,CompareResult});
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_ModifyHead.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextModifyHead;
            }
        }

        private void InitModifyDetail()
        {
            this.dgv_ModifyDetail.AutoGenerateColumns = false;
            // 
            // 产品配件改样报关订单材料表id
            // 
            DataGridViewTextBoxColumn 产品配件改样报关订单材料表id = new DataGridViewTextBoxColumn();
            产品配件改样报关订单材料表id.DataPropertyName = "产品配件改样报关订单材料表id";
            产品配件改样报关订单材料表id.HeaderText = "产品配件改样报关订单材料表id";
            产品配件改样报关订单材料表id.Name = "产品配件改样报关订单材料表id";
            产品配件改样报关订单材料表id.ReadOnly = true;
            产品配件改样报关订单材料表id.Visible = false;
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
            // 备注
            // 
            DataGridViewTextBoxColumn 备注 = new DataGridViewTextBoxColumn();
            备注.DataPropertyName = "备注";
            备注.HeaderText = "备注";
            备注.Name = "备注";
            备注.ReadOnly = true;
            备注.Visible = false;
            备注.Width = 78;
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
            // CompareResult
            // 
            DataGridViewTextBoxColumn CompareResult = new DataGridViewTextBoxColumn();
            CompareResult.DataPropertyName = "CompareResult";
            CompareResult.HeaderText = "CompareResult";
            CompareResult.Name = "CompareResult";
            CompareResult.ReadOnly = true;
            CompareResult.Visible = false;
            CompareResult.Width = 78;
            this.dgv_ModifyDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{产品配件改样报关订单材料表id,订单id ,订单明细表id ,产品id ,
                配件id ,料件id ,料件型号,编号 ,料件名 ,序号,区域,商品编码 ,商品名称 ,规格型号 ,计量单位,数量 ,单位,备注 ,损耗率,CompareResult});
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_ModifyDetail.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextModifyDetail;
            }
        }
        private void InitHistoryModifyHead()
        {
            this.dgv_HistoryModifyHead.AutoGenerateColumns = false;
            // 
            // 产品配件改样报关订单材料明细表id
            // 
            DataGridViewTextBoxColumn 产品配件改样报关订单材料明细表id = new DataGridViewTextBoxColumn();
            产品配件改样报关订单材料明细表id.DataPropertyName = "产品配件改样报关订单材料明细表id";
            产品配件改样报关订单材料明细表id.HeaderText = "产品配件改样报关订单材料明细表id";
            产品配件改样报关订单材料明细表id.Name = "产品配件改样报关订单材料明细表id";
            产品配件改样报关订单材料明细表id.ReadOnly = true;
            产品配件改样报关订单材料明细表id.Visible = false;
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
            // 单位1
            // 
            DataGridViewTextBoxColumn 单位1 = new DataGridViewTextBoxColumn();
            单位1.DataPropertyName = "单位1";
            单位1.HeaderText = "单位1";
            单位1.Name = "单位1";
            单位1.ReadOnly = true;
            单位1.Visible = false;
            单位1.Width = 78;
            // 
            // CompareResult
            // 
            DataGridViewTextBoxColumn CompareResult = new DataGridViewTextBoxColumn();
            CompareResult.DataPropertyName = "CompareResult";
            CompareResult.HeaderText = "CompareResult";
            CompareResult.Name = "CompareResult";
            CompareResult.ReadOnly = true;
            CompareResult.Visible = false;
            CompareResult.Width = 78;
            this.dgv_HistoryModifyHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{产品配件改样报关订单材料明细表id,订单id,
            订单明细表id,产品id,配件id,料件型号,型号,料件id,料件名,项号,编号,商品编码,商品名称,
            规格型号,计量单位,数量,单位,换算率,单耗,单耗单位,损耗率,单位1,CompareResult});
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_HistoryModifyHead.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextHistoryModifyHead;
            }
        }

        private void InitHistoryModifyDetail()
        {
            this.dgv_HistoryModifyDetail.AutoGenerateColumns = false;
            // 
            // 产品配件改样报关订单材料表id
            // 
            DataGridViewTextBoxColumn 产品配件改样报关订单材料表id = new DataGridViewTextBoxColumn();
            产品配件改样报关订单材料表id.DataPropertyName = "产品配件改样报关订单材料表id";
            产品配件改样报关订单材料表id.HeaderText = "产品配件改样报关订单材料表id";
            产品配件改样报关订单材料表id.Name = "产品配件改样报关订单材料表id";
            产品配件改样报关订单材料表id.ReadOnly = true;
            产品配件改样报关订单材料表id.Visible = false;
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
            // 备注
            // 
            DataGridViewTextBoxColumn 备注 = new DataGridViewTextBoxColumn();
            备注.DataPropertyName = "备注";
            备注.HeaderText = "备注";
            备注.Name = "备注";
            备注.ReadOnly = true;
            备注.Visible = false;
            备注.Width = 78;
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
            // CompareResult
            // 
            DataGridViewTextBoxColumn CompareResult = new DataGridViewTextBoxColumn();
            CompareResult.DataPropertyName = "CompareResult";
            CompareResult.HeaderText = "CompareResult";
            CompareResult.Name = "CompareResult";
            CompareResult.ReadOnly = true;
            CompareResult.Visible = false;
            CompareResult.Width = 78;

            this.dgv_HistoryModifyDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{产品配件改样报关订单材料表id,订单id ,订单明细表id ,产品id ,
                配件id ,料件id ,料件型号,编号 ,料件名 ,序号,区域,商品编码 ,商品名称 ,规格型号 ,计量单位,数量 ,单位,备注 ,损耗率,CompareResult});
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_HistoryModifyDetail.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextHistoryModifyDetail;
            }
        }

        //应用改样明细
        private void btnApplyModifyDetail_Click(object sender, EventArgs e)
        {
            dtModifyHeadTemp.Columns.Remove("CompareResult");
            dtModifyDetailTemp.Columns.Remove("CompareResult");
            dtReturnHead = dtModifyHeadTemp;
            dtReturnDetail = dtModifyDetailTemp;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        //应用历史改样明细
        private void btnAppHistoryModifyDetail_Click(object sender, EventArgs e)
        {
            dtModifyHeadHistoryTemp.Columns.Remove("CompareResult");
            dtModifyDetailHistoryTemp.Columns.Remove("CompareResult");
            dtReturnHead = dtModifyHeadHistoryTemp;
            dtReturnDetail = dtModifyDetailHistoryTemp;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 比较两个DataTable的差异
        /// </summary>
        /// <param name="dtLeft">左边数据源</param>
        /// <param name="dtRight">右边数据源</param>
        private void CompareDataTable(DataTable dtLeft, DataTable dtRight)
        {
            DataColumn colLeft = new DataColumn();
            colLeft.ColumnName = "CompareResult";
            colLeft.DataType = typeof(string);
            dtLeft.Columns.Add(colLeft);
            DataColumn colRight = new DataColumn();
            colRight.ColumnName = "CompareResult";
            colRight.DataType = typeof(string);
            dtRight.Columns.Add(colRight);
            //CompareResult的值说明：Add,Modify,Delete,None
            //拿左边DATATABLE为基准跟右边比较
            foreach (DataRow leftRow in dtLeft.Rows)
            {
                DataRow[] rows = dtRight.Select(string.Format( "料件id={0}",leftRow["料件id"]),"");
                if (rows.Length == 0)  //表示右边不存在，则左边标识为删除
                {
                    leftRow["CompareResult"] = "Delete";
                }
                else
                {
                    CompareDataRow(leftRow, rows[0]);
                }
            }
            //左边比较完后，查看右边没有比较结果的数据，这部分数据为右边新增的数据
            foreach (DataRow rightRow in dtRight.Rows)
            {
                if (rightRow["CompareResult"] == DBNull.Value || rightRow["CompareResult"].ToString() == "")
                {
                    rightRow["CompareResult"] = "Add";
                }
            }
        }
        /// <summary>
        /// 比较两个DATAROW的数据是否一样
        /// </summary>
        /// <param name="leftRow"></param>
        /// <param name="rightRow"></param>
        private void CompareDataRow(DataRow leftRow, DataRow rightRow)
        {
            bool isSame = true;
            foreach (DataColumn colLeft in leftRow.Table.Columns)
            {
                if (leftRow[colLeft.ColumnName] == DBNull.Value && rightRow[colLeft.ColumnName] == DBNull.Value)
                {
                    continue;
                }
                else if (leftRow[colLeft.ColumnName]==DBNull.Value && rightRow[colLeft.ColumnName] !=DBNull.Value)
                {
                    isSame = false;
                    break;
                }
                else if (leftRow[colLeft.ColumnName] != DBNull.Value && rightRow[colLeft.ColumnName] == DBNull.Value)
                {
                    isSame = false;
                    break;
                }
                else if (leftRow[colLeft.ColumnName].ToString().TrimEnd() == rightRow[colLeft.ColumnName].ToString().Trim())
                {
                    continue;
                }
                else
                {
                    isSame = false;
                    break;
                }

            }
            if (isSame)
            {
                leftRow["CompareResult"] = "None";
                rightRow["CompareResult"] = "None";
            }
            else
            {
                leftRow["CompareResult"] = "Modify";
                rightRow["CompareResult"] = "Modify";
            }
        }

        private void dgv_ModifyHead_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow dgr = dgv_ModifyHead.Rows[e.RowIndex];
            try
            {
                //if (e.ColumnIndex == 3)//定位到第3列，如不定位到具体的哪列，则整行的颜色改变  
                //{
                    if (dgr.Cells["CompareResult"].Value.ToString() == "Modify")
                    {
                        e.CellStyle.ForeColor = Color.Green;//将前景色设置为红色，即字体颜色设置为红色  
                        //e.CellStyle.BackColor = Color.Green;//将背景色设置为绿色，即列的颜色设置为红色  
                    }
                    else if (dgr.Cells["CompareResult"].Value.ToString() == "Delete")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Black;
                    }
                //}
            }
            catch
            {
                
            }  
        }

        private void dgv_ModifyDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow dgr = dgv_ModifyDetail.Rows[e.RowIndex];
            try
            {
                //if (e.ColumnIndex == 3)//定位到第3列，如不定位到具体的哪列，则整行的颜色改变  
                //{
                if (dgr.Cells["CompareResult"].Value.ToString() == "Modify")
                {
                    e.CellStyle.ForeColor = Color.Green;//将前景色设置为红色，即字体颜色设置为红色  
                    //e.CellStyle.BackColor = Color.Green;//将背景色设置为绿色，即列的颜色设置为红色  
                }
                else if (dgr.Cells["CompareResult"].Value.ToString() == "Delete")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
                //}
            }
            catch
            {

            }  
        }

        private void dgv_HistoryModifyHead_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow dgr = dgv_HistoryModifyHead.Rows[e.RowIndex];
            try
            {
                //if (e.ColumnIndex == 3)//定位到第3列，如不定位到具体的哪列，则整行的颜色改变  
                //{
                if (dgr.Cells["CompareResult"].Value.ToString() == "Modify")
                {
                    e.CellStyle.ForeColor = Color.Green;//将前景色设置为红色，即字体颜色设置为红色  
                    //e.CellStyle.BackColor = Color.Green;//将背景色设置为绿色，即列的颜色设置为红色  
                }
                else if (dgr.Cells["CompareResult"].Value.ToString() == "Add")
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
                //}
            }
            catch
            {

            }  
        }

        private void dgv_HistoryModifyDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow dgr = dgv_HistoryModifyDetail.Rows[e.RowIndex];
            try
            {
                //if (e.ColumnIndex == 3)//定位到第3列，如不定位到具体的哪列，则整行的颜色改变  
                //{
                if (dgr.Cells["CompareResult"].Value.ToString() == "Modify")
                {
                    e.CellStyle.ForeColor = Color.Green;//将前景色设置为红色，即字体颜色设置为红色  
                    //e.CellStyle.BackColor = Color.Green;//将背景色设置为绿色，即列的颜色设置为红色  
                }
                else if (dgr.Cells["CompareResult"].Value.ToString() == "Add")
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
                //}
            }
            catch
            {

            }  
        }
    }
}
