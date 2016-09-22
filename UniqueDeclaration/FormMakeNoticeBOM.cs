using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;
using UniqueDeclarationBaseForm;
using UniqueDeclarationBaseForm.Controls;

namespace UniqueDeclaration
{
    public partial class FormMakeNoticeBOM : UniqueDeclarationBaseForm.FormBaseBOM
    {
        public FormMakeNoticeBOM()
        {
            InitializeComponent();
        }

        #region 外部传进来的变量
        /// <summary>
        /// 制造通知单id
        /// </summary>
        public long OrderId = 0;
        /// <summary>
        /// 制造通知单明细表ID
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

        public string IdCode = string.Empty;

        public string OrderCode = string.Empty;
        #endregion

        #region 数据全局变量
        /// <summary>
        /// 改样前料件组成
        /// </summary>
        private DataTable dtModifyBefore = null;
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

        #region 初始化GRID

        private void InitModifyBeore()
        {
            this.dgv_ModifyBefore.ReadOnly = true;
            // 
            // 料件id
            // 
            DataGridViewTextBoxColumn 料件id = new DataGridViewTextBoxColumn();
            料件id.DataPropertyName = "料件id";
            料件id.HeaderText = "料件id";
            料件id.Name = "料件id";
            料件id.ReadOnly = true;
            料件id.Visible = false;
            料件id.ContextMenuStrip = this.myContextModifyBefore;
            // 
            // 料件型号
            // 
            DataGridViewTextBoxColumn 料件型号 = new DataGridViewTextBoxColumn();
            料件型号.DataPropertyName = "型号";
            料件型号.HeaderText = "料件型号";
            料件型号.Name = "料件型号";
            料件型号.ReadOnly = true;
            料件型号.Visible = true;
            料件型号.Width = 78;
            料件型号.ContextMenuStrip = this.myContextModifyBefore;
            // 
            // 型号
            // 
            DataGridViewTextBoxColumn 型号 = new DataGridViewTextBoxColumn();
            型号.DataPropertyName = "显示型号";
            型号.HeaderText = "型号";
            型号.Name = "型号";
            型号.ReadOnly = true;
            型号.Visible = true;
            型号.Width = 78;
            型号.ContextMenuStrip = this.myContextModifyBefore;
            // 
            // 料件名
            // 
            DataGridViewTextBoxColumn 料件名 = new DataGridViewTextBoxColumn();
            料件名.DataPropertyName = "品名";
            料件名.HeaderText = "料件名";
            料件名.Name = "料件名";
            料件名.ReadOnly = true;
            料件名.Visible = true;
            料件名.Width = 78;
            料件名.ContextMenuStrip = this.myContextModifyBefore;
            // 
            // 项号
            // 
            DataGridViewTextBoxColumn 项号 = new DataGridViewTextBoxColumn();
            项号.DataPropertyName = "项号";
            项号.HeaderText = "项号";
            项号.Name = "项号";
            项号.ReadOnly = true;
            项号.Visible = true;
            项号.Width = 55;
            项号.ContextMenuStrip = this.myContextModifyBefore;
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
            商品编码.ContextMenuStrip = this.myContextModifyBefore;
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
            商品名称.ContextMenuStrip = this.myContextModifyBefore;
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
            规格型号.ContextMenuStrip = this.myContextModifyBefore;
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
            计量单位.ContextMenuStrip = this.myContextModifyBefore;
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
            数量.ContextMenuStrip = this.myContextModifyBefore;
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
            单位.ContextMenuStrip = this.myContextModifyBefore;
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
            单耗.ContextMenuStrip = this.myContextModifyBefore;
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
            单耗单位.ContextMenuStrip = this.myContextModifyBefore;
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
            单位1.ContextMenuStrip = this.myContextModifyBefore;
            this.dgv_ModifyBefore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{料件id,料件型号,型号,料件名,项号,商品编码,商品名称,
            规格型号,计量单位,数量,单位,单耗,单耗单位,单位1});
        }

        private void InitModifyAfterHead()
        {
            this.dgv_ModifyAfterHead.AutoGenerateColumns = false;
            // 
            // 产品配件改样报关订单前材料明细表id
            // 
            DataGridViewTextBoxColumn 产品配件改样报关前订单材料明细表id = new DataGridViewTextBoxColumn();
            产品配件改样报关前订单材料明细表id.DataPropertyName = "产品配件改样报关订单前材料明细表id";
            产品配件改样报关前订单材料明细表id.HeaderText = "产品配件改样报关订单前材料明细表id";
            产品配件改样报关前订单材料明细表id.Name = "产品配件改样报关订单前材料明细表id";
            产品配件改样报关前订单材料明细表id.ReadOnly = true;
            产品配件改样报关前订单材料明细表id.Visible = false;
            产品配件改样报关前订单材料明细表id.ContextMenuStrip = this.myContextModifyAfterHead;
            // 
            // 制造通知单id
            // 
            DataGridViewTextBoxColumn 制造通知单id = new DataGridViewTextBoxColumn();
            制造通知单id.DataPropertyName = "制造通知单id";
            制造通知单id.HeaderText = "制造通知单id";
            制造通知单id.Name = "制造通知单id";
            制造通知单id.ReadOnly = true;
            制造通知单id.Visible = false;
            制造通知单id.ContextMenuStrip = this.myContextModifyAfterHead;
            // 
            // 制造通知单明细表id
            // 
            DataGridViewTextBoxColumn 制造通知单明细表id = new DataGridViewTextBoxColumn();
            制造通知单明细表id.DataPropertyName = "制造通知单明细表id";
            制造通知单明细表id.HeaderText = "制造通知单明细表id";
            制造通知单明细表id.Name = "制造通知单明细表id";
            制造通知单明细表id.ReadOnly = true;
            制造通知单明细表id.Visible = false;
            制造通知单明细表id.ContextMenuStrip = this.myContextModifyAfterHead;
            // 
            // 产品id
            // 
            DataGridViewTextBoxColumn 产品id = new DataGridViewTextBoxColumn();
            产品id.DataPropertyName = "产品id";
            产品id.HeaderText = "产品id";
            产品id.Name = "产品id";
            产品id.ReadOnly = true;
            产品id.Visible = false;
            产品id.ContextMenuStrip = this.myContextModifyAfterHead;
            // 
            // 配件id
            // 
            DataGridViewTextBoxColumn 配件id = new DataGridViewTextBoxColumn();
            配件id.DataPropertyName = "配件id";
            配件id.HeaderText = "配件id";
            配件id.Name = "配件id";
            配件id.ReadOnly = true;
            配件id.Visible = false;
            配件id.ContextMenuStrip = this.myContextModifyAfterHead;
            // 
            // 料件型号
            // 
            DataGridViewTextBoxColumn 料件型号 = new DataGridViewTextBoxColumn();
            料件型号.DataPropertyName = "型号";
            料件型号.HeaderText = "料件型号";
            料件型号.Name = "型号";
            料件型号.ReadOnly = true;
            料件型号.Visible = true;
            料件型号.Width = 78;
            料件型号.ContextMenuStrip = this.myContextModifyAfterHead;
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
            型号.ContextMenuStrip = this.myContextModifyAfterHead;
            // 
            // 料件id
            // 
            DataGridViewTextBoxColumn 料件id = new DataGridViewTextBoxColumn();
            料件id.DataPropertyName = "料件id";
            料件id.HeaderText = "料件id";
            料件id.Name = "料件id";
            料件id.ReadOnly = true;
            料件id.Visible = true;
            料件id.Width = 65;
            料件id.ContextMenuStrip = this.myContextModifyAfterHead;
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
            料件名.ContextMenuStrip = this.myContextModifyAfterHead;
            // 
            // 项号
            // 
            DataGridViewTextBoxColumn 项号 = new DataGridViewTextBoxColumn();
            项号.DataPropertyName = "项号";
            项号.HeaderText = "项号";
            项号.Name = "项号";
            项号.ReadOnly = true;
            项号.Visible = true;
            项号.Width = 55;
            项号.ContextMenuStrip = this.myContextModifyAfterHead;
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
            编号.ContextMenuStrip = this.myContextModifyAfterHead;
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
            商品编码.ContextMenuStrip = this.myContextModifyAfterHead;
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
            商品名称.ContextMenuStrip = this.myContextModifyAfterHead;
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
            规格型号.ContextMenuStrip = this.myContextModifyAfterHead;
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
            计量单位.ContextMenuStrip = this.myContextModifyAfterHead;
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
            数量.ContextMenuStrip = this.myContextModifyAfterHead;
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
            单位.ContextMenuStrip = this.myContextModifyAfterHead;
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
            换算率.Width = 70;
            换算率.ContextMenuStrip = this.myContextModifyAfterHead;
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
            单耗.ContextMenuStrip = this.myContextModifyAfterHead;
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
            单耗单位.ContextMenuStrip = this.myContextModifyAfterHead;
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
            损耗率.Width = 70;
            损耗率.ContextMenuStrip = this.myContextModifyAfterHead;
            // 
            // 剩余库存量
            // 
            DataGridViewTextBoxColumn 剩余库存量 = new DataGridViewTextBoxColumn();
            剩余库存量.DataPropertyName = "剩余库存量";
            剩余库存量.HeaderText = "剩余库存量";
            剩余库存量.Name = "剩余库存量";
            剩余库存量.ReadOnly = true;
            剩余库存量.Visible = true;
            剩余库存量.Width = 100;
            剩余库存量.ContextMenuStrip = this.myContextModifyAfterHead;
            this.dgv_ModifyAfterHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{产品配件改样报关前订单材料明细表id,制造通知单id,
            制造通知单明细表id,产品id,配件id,料件型号,型号,料件id,料件名,项号,编号,商品编码,商品名称,
            规格型号,计量单位,数量,单位,换算率,单耗,单耗单位,损耗率,剩余库存量});
        }

        private void InitModifyAfterDetail()
        {
            // 
            // 产品配件改样报关前材料表id
            // 
            DataGridViewTextBoxColumn 产品配件改样报关前材料表id = new DataGridViewTextBoxColumn();
            产品配件改样报关前材料表id.DataPropertyName = "产品配件改样报关前材料表id";
            产品配件改样报关前材料表id.HeaderText = "产品配件改样报关前材料表id";
            产品配件改样报关前材料表id.Name = "产品配件改样报关前材料表id";
            产品配件改样报关前材料表id.ReadOnly = true;
            产品配件改样报关前材料表id.Visible = false;
            // 
            // 制造通知单id
            // 
            DataGridViewTextBoxColumn 制造通知单id = new DataGridViewTextBoxColumn();
            制造通知单id.DataPropertyName = "制造通知单id";
            制造通知单id.HeaderText = "制造通知单id";
            制造通知单id.Name = "制造通知单id";
            制造通知单id.ReadOnly = true;
            制造通知单id.Visible = false;
            // 
            // 制造通知单明细表id
            // 
            DataGridViewTextBoxColumn 制造通知单明细表id = new DataGridViewTextBoxColumn();
            制造通知单明细表id.DataPropertyName = "制造通知单明细表id";
            制造通知单明细表id.HeaderText = "制造通知单明细表id";
            制造通知单明细表id.Name = "制造通知单明细表id";
            制造通知单明细表id.ReadOnly = true;
            制造通知单明细表id.Visible = false;
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
            料件id.Width = 65;
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
            // 编号
            // 
            DataGridViewTextBoxColumn 编号 = new DataGridViewTextBoxColumn();
            编号.DataPropertyName = "编号";
            编号.HeaderText = "编号";
            编号.Name = "编号";
            编号.ReadOnly = true;
            编号.Visible = false;
            编号.Width = 70;
            // 
            // 料件名
            // 
            DataGridViewTextBoxColumn 料件名 = new DataGridViewTextBoxColumn();
            料件名.DataPropertyName = "品名";
            料件名.HeaderText = "料件名";
            料件名.Name = "料件名";
            料件名.ReadOnly = true;
            料件名.Visible = true;
            料件名.Width = 70;
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
            数量.ReadOnly = true;
            数量.Visible = false;
            数量.Width = 60;
            // 
            // 单位
            // 
            DataGridViewTextBoxColumn 单位 = new DataGridViewTextBoxColumn();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            单位.DefaultCellStyle = dataGridViewCellStyle1;
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
            损耗率.ReadOnly = true;
            损耗率.Visible = true;
            损耗率.Width = 70;
            // 
            // 区域
            // 
            DataGridViewTextBoxColumn 区域 = new DataGridViewTextBoxColumn();
            区域.DataPropertyName = "区域";
            区域.HeaderText = "区域";
            区域.Name = "区域";
            区域.ReadOnly = true;
            区域.Visible = true;
            区域.Width = 60;
            // 
            // 剩余库存量
            // 
            DataGridViewTextBoxColumn 剩余库存量 = new DataGridViewTextBoxColumn();
            剩余库存量.DataPropertyName = "剩余库存量";
            剩余库存量.HeaderText = "剩余库存量";
            剩余库存量.Name = "剩余库存量";
            剩余库存量.ReadOnly = true;
            剩余库存量.Visible = true;
            剩余库存量.Width = 100;

            this.dgv_ModifyAfterDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{产品配件改样报关前材料表id,制造通知单id ,制造通知单明细表id ,产品id ,
                配件id ,料件id ,料件型号,序号,编号 ,料件名 ,商品编码 ,商品名称 ,规格型号 ,计量单位,数量 ,单位,备注 ,损耗率,区域,剩余库存量});

            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dgv_ModifyAfterDetail.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextModifyAfterDetail;
            }
        }

        private void InitMergeAfterHead()
        {
            // 
            // 制造通知单id
            // 
            DataGridViewTextBoxColumn 制造通知单id = new DataGridViewTextBoxColumn();
            制造通知单id.DataPropertyName = "制造通知单id";
            制造通知单id.HeaderText = "制造通知单id";
            制造通知单id.Name = "制造通知单id";
            制造通知单id.ReadOnly = true;
            制造通知单id.Visible = false;
            // 
            // 订单明细表id
            // 
            DataGridViewTextBoxColumn 制造通知单明细表id = new DataGridViewTextBoxColumn();
            制造通知单明细表id.DataPropertyName = "制造通知单明细表id";
            制造通知单明细表id.HeaderText = "制造通知单明细表id";
            制造通知单明细表id.Name = "制造通知单明细表id";
            制造通知单明细表id.ReadOnly = true;
            制造通知单明细表id.Visible = false;
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
            // 非保科料件比率
            // 
            DataGridViewTextBoxColumn 非保科料件比率 = new DataGridViewTextBoxColumn();
            非保科料件比率.DataPropertyName = "非保科料件比率";
            非保科料件比率.HeaderText = "非保科料件比率";
            非保科料件比率.Name = "非保科料件比率";
            非保科料件比率.ReadOnly = true;
            非保科料件比率.Visible = true;
            非保科料件比率.Width = 120;


            this.dgv_MergerAfterHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]{制造通知单id ,制造通知单明细表id ,产品id ,
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
            单耗.Width = 150;
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

        #region Form事件及其他控件事件
        private void FormMakeNoticeBOM_Load(object sender, EventArgs e)
        {
            InitModifyBeore();
            InitModifyAfterHead();
            InitModifyAfterDetail();
            InitMergeAfterHead();
            InitMergeAfterDetail();

            LoadDataSource();
            this.myTabControl1.SelectedIndex = 1;
        }
        private void FormMakeNoticeBOM_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveModifyAfterHead();
            SaveModifyAfterDetail();
            /*
            DialogResult result = CheckModify();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.Yes:
                    try
                    {
                        SaveModifyAfterHead();
                        SaveModifyAfterDetail();
                        e.Cancel = false;
                    }
                    catch (Exception ex)
                    {
                        SysMessage.ErrorMsg(ex.Message);
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
             */
        }
        public override void myTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                strSQL = string.Format("exec 产品料件报关组成 {0},{1}", Pid, StringTools.SqlQ(ManualCode));
            }
            else
            {
                strSQL = string.Format("exec 配件料件报关组成 {0},{1}", Pid, StringTools.SqlQ(ManualCode));
            }
            dtModifyBefore = dataAccess.GetTable(strSQL, null);
            if (dtModifyBefore.Rows.Count == 0)
                dtModifyBefore.Rows.Add(dtModifyBefore.NewRow());
            this.dgv_ModifyBefore.DataSource = dtModifyBefore;
            #endregion

            #region 改样后料件组成
            if (Fid == 0)
            {
                strSQL = string.Format(@"SELECT * FROM 产品配件改样报关前材料明细表 WHERE 制造通知单id={0} and 制造通知单明细表id={1} and 产品id={2} 
                                            order by str(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end),
                                            str(case when PATINDEX('%-%',项号)=0 then '' else SUBSTRING(项号,PATINDEX('%-%',项号)+1,len(项号)-PATINDEX('%-%',项号)) end)",
                                            OrderId,OrderListId,Pid);
            }
            else
            {
                strSQL = string.Format(@"SELECT * FROM 产品配件改样报关前材料明细表 WHERE 制造通知单id={0} and 制造通知单明细表id={1} and 配件id={2} 
                                            order by str(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end),
                                            str(case when PATINDEX('%-%',项号)=0 then '' else SUBSTRING(项号,PATINDEX('%-%',项号)+1,len(项号)-PATINDEX('%-%',项号)) end)",
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
                strSQL = string.Format("SELECT * FROM 产品配件改样报关前材料表 WHERE 制造通知单id={0} and 制造通知单明细表id={1} and 产品id={2} order by 编号", OrderId, OrderListId, Pid);
            }
            else
            {
                strSQL = string.Format("SELECT * FROM 产品配件改样报关前材料表 WHERE 制造通知单id={0} and 制造通知单明细表id={1} and 配件id={2} order by 编号", OrderId, OrderListId, Fid);
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
            /*
             DataEx(1).Update
            DataEx(2).Update
             */
            string strSQL = string.Empty;
            if (Fid == 0)
            {
                strSQL = string.Format(@"SELECT L.制造通知单id, L.制造通知单明细表id, isnull(L.产品id,0) as 产品id, isnull(L.配件id,0) as 配件id,
                                        str(case when PATINDEX('%-%',L.项号)=0 then L.项号 else SUBSTRING(L.项号,1,PATINDEX('%-%',L.项号)-1) end)  AS 号, 
                                        str(case when PATINDEX('%-%',L.项号)=0 then '' else SUBSTRING(L.项号,PATINDEX('%-%',L.项号)+1,len(L.项号)-PATINDEX('%-%',L.项号)) end)  AS 项,
                                        L.项号, L.商品编码, L.商品名称,H.商品规格 AS 规格型号,L.计量单位, str(sum(L.单耗*(1-case when L.损耗率 is null then 0 else 0 end)), 10, 5) AS 单耗,L.损耗率 
                                        From dbo.产品配件改样报关前材料明细表 L left outer join 归并后料件清单 H on H.产品编号=substring(L.编号,1,3) 
                                        where left(ltrim(L.显示型号),1)='A' and  H.电子帐册号={0} AND L.制造通知单id ={1} and L.制造通知单明细表id ={2} and L.产品id = {3}
                                        group by L.制造通知单id, L.制造通知单明细表id, isnull(L.产品id,0), isnull(L.配件id,0),
                                            str(case when PATINDEX('%-%',L.项号)=0 then L.项号 else SUBSTRING(L.项号,1,PATINDEX('%-%',L.项号)-1) end), 
                                            str(case when PATINDEX('%-%',L.项号)=0 then '' else SUBSTRING(L.项号,PATINDEX('%-%',L.项号)+1,len(L.项号)-PATINDEX('%-%',L.项号)) end),
                                            L.项号, L.商品编码, L.商品名称,H.商品规格,L.计量单位,L.损耗率
                                        Union All 
                                        SELECT 制造通知单id, 制造通知单明细表id, 产品id, 配件id,str(序号),str(''), LTRIM(STR(序号)),商品编码,商品名称,规格型号,计量单位, 
                                            str(数量*(1-case when 损耗率 is null then 0 else 0 end), 10, 5),损耗率 
                                        From dbo.产品配件改样报关前材料表 where 区域='A' AND 制造通知单id ={1} and 制造通知单明细表id ={2} and 产品id = {3} order by 号,项",
                                               StringTools.SqlQ(ManualCode), OrderId, OrderListId, Pid);
            }
            else
            {
                strSQL = string.Format(@"SELECT L.制造通知单id, L.制造通知单明细表id, isnull(L.产品id,0) as 产品id, isnull(L.配件id,0) as 配件id,
                                        str(case when PATINDEX('%-%',L.项号)=0 then L.项号 else SUBSTRING(L.项号,1,PATINDEX('%-%',L.项号)-1) end)  AS 号, 
                                        str(case when PATINDEX('%-%',L.项号)=0 then '' else SUBSTRING(L.项号,PATINDEX('%-%',L.项号)+1,len(L.项号)-PATINDEX('%-%',L.项号)) end)  AS 项,
                                        L.项号, L.商品编码, L.商品名称,H.商品规格 AS 规格型号,L.计量单位, str(sum(L.单耗*(1-case when L.损耗率 is null then 0 else 0 end)),10, 5) AS 单耗,L.损耗率 
                                        From dbo.产品配件改样报关前材料明细表 L left outer join 归并后料件清单 H on H.产品编号=substring(L.编号,1,3) 
                                        where left(ltrim(L.显示型号),1)='A' and  H.电子帐册号={0} AND L.制造通知单id ={1} and L.制造通知单明细表id ={2} and L.配件id = {3}
                                        group by L.制造通知单id, L.制造通知单明细表id, isnull(L.产品id,0), isnull(L.配件id,0),
                                            str(case when PATINDEX('%-%',L.项号)=0 then L.项号 else SUBSTRING(L.项号,1,PATINDEX('%-%',L.项号)-1) end), 
                                            str(case when PATINDEX('%-%',L.项号)=0 then '' else SUBSTRING(L.项号,PATINDEX('%-%',L.项号)+1,len(L.项号)-PATINDEX('%-%',L.项号)) end),
                                            L.项号, L.商品编码, L.商品名称,H.商品规格,L.计量单位,L.损耗率
                                        Union All 
                                        SELECT 制造通知单id, 制造通知单明细表id, 产品id, 配件id,str(序号),str(''),LTRIM(STR(序号)),商品编码,商品名称,规格型号,计量单位,
                                            str(数量*(1-case when 损耗率 is null then 0 else 0 end), 10, 5),损耗率 
                                        From dbo.产品配件改样报关前材料表 where  区域='A' AND 制造通知单id ={1} and 制造通知单明细表id ={2} and 配件id ={3} order by  号,项",
                                               StringTools.SqlQ(ManualCode), OrderId, OrderListId, Fid);
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtMergeAfterHead = dataAccess.GetTable(strSQL, null);  //归并后订单料件汇总明细
            if (dtMergeAfterHead.Rows.Count == 0)
                dtMergeAfterHead.Rows.Add(dtMergeAfterHead.NewRow());
            strSQL = string.Format("exec 归并后制造通知单料件汇总明细 {0},{1},{2},{3},{4}", Pid, Fid, OrderId, OrderListId, StringTools.SqlQ(ManualCode));
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
                    strSQL += string.Format(@"INSERT INTO [Manufacture].[dbo].[产品配件改样报关前材料表]
                                               ([制造通知单id],[制造通知单明细表id],[产品id],[配件id],[料件id],[料件型号],[序号],[编号]
                                               ,[品名],[商品编码],[商品名称],[规格型号],[计量单位],[数量],[单位],[备注] ,[损耗率] ,[区域],[剩余库存量])
                                         VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18})" + Environment.NewLine,
                                         row["制造通知单id"] == DBNull.Value ? "NULL" : row["制造通知单id"],
                                         row["制造通知单明细表id"] == DBNull.Value ? "NULL" : row["制造通知单明细表id"],
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
                    if (row["产品配件改样报关前材料表id", DataRowVersion.Original] == DBNull.Value) continue;
                    strSQL += string.Format("DELETE FROM [dbo].[产品配件改样报关前材料表] WHERE [产品配件改样报关前材料表id]={0}" + Environment.NewLine, row["产品配件改样报关前材料表id", DataRowVersion.Original]);
                }
                #endregion

                #region 修改行
                else if (row.RowState == DataRowState.Modified)
                {
                    if (row["产品配件改样报关前材料表id"] == DBNull.Value) continue;
                    strSQL += string.Format(@"UPDATE [Manufacture].[dbo].[产品配件改样报关前材料表]
                                                   SET [制造通知单id] = {0},[制造通知单明细表id] ={1},[产品id] = {2} ,[配件id] = {3},[料件id] = {4}
                                                      ,[料件型号] = {5},[序号] = {6},[编号] = {7},[品名] ={8} ,[商品编码] ={9} ,[商品名称] = {10}
                                                      ,[规格型号] = {11},[计量单位] = {12},[数量] = {13} ,[单位] = {14} ,[备注] = {15}
                                                      ,[损耗率] = {16},[区域] = {17},[剩余库存量]={18}
                                                 WHERE 产品配件改样报关前材料表id={18}",
                                         row["制造通知单id"] == DBNull.Value ? "NULL" : row["制造通知单id"],
                                         row["制造通知单明细表id"] == DBNull.Value ? "NULL" : row["制造通知单明细表id"],
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
                                         row["产品配件改样报关前材料表id"] == DBNull.Value ? "NULL" : row["产品配件改样报关前材料表id"]);
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
                    strSQL += string.Format(@"INSERT INTO [dbo].[产品配件改样报关前材料明细表]
                                           ([制造通知单id],[制造通知单明细表id],[产品id],[配件id],[料件id],[型号],[显示型号],[品名],[项号],[编号]
                                           ,[商品编码],[商品名称],[规格型号],[计量单位],[数量],[单位],[单耗],[单耗单位],[损耗率],[换算率],[剩余库存量])
                                     VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20})" + Environment.NewLine,
                                    row["制造通知单id"] == DBNull.Value ? "NULL" : row["制造通知单id"],
                                    row["制造通知单明细表id"] == DBNull.Value ? "NULL" : row["制造通知单明细表id"],
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
                    if (row["产品配件改样报关前材料明细表id", DataRowVersion.Original] == DBNull.Value) continue;
                    strSQL += string.Format("DELETE FROM [dbo].[产品配件改样报关前材料明细表] WHERE [产品配件改样报关前材料明细表id]={0}" + Environment.NewLine, row["产品配件改样报关前材料明细表id", DataRowVersion.Original]);
                }
                #endregion

                #region 修改行
                else if (row.RowState == DataRowState.Modified)
                {
                    if (row["产品配件改样报关前材料明细表id"] == DBNull.Value) continue;
                    strSQL += string.Format(@"UPDATE [dbo].[产品配件改样报关前材料明细表] SET [制造通知单id] = {0},[制造通知单明细表id] ={1},[产品id] = {2},[配件id] = {3},[料件id] = {4}
                                          ,[型号] ={5},[显示型号] ={6},[品名] = {7},[项号] = {8},[编号] = {9},[商品编码] = {10},[商品名称] = {11},[规格型号] = {12},[计量单位] = {13},[数量] = {14}
                                          ,[单位] = {15},[单耗] = {16},[单耗单位] = {17},[损耗率] = {18},[换算率] = {19},[剩余库存量]={20} WHERE [产品配件改样报关前材料明细表id]={21}" + Environment.NewLine,
                                    row["制造通知单id"] == DBNull.Value ? "NULL" : row["制造通知单id"],
                                    row["制造通知单明细表id"] == DBNull.Value ? "NULL" : row["制造通知单明细表id"],
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
                                    row["产品配件改样报关前材料明细表id"] == DBNull.Value ? "NULL" : row["产品配件改样报关前材料明细表id"]);
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

        private void Sum总重()
        {
            FactWeight = 0;
            foreach (DataRow row in dtModifyAfterHead.Rows)
            {
                FactWeight += row["单耗"] == DBNull.Value ? 0 : float.Parse(row["单耗"].ToString());
            }
            foreach (DataRow row in dtModifyAfterDetail.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue ;
                FactWeight += float.Parse(row["数量"].ToString());
            }
            if (FactWeight != 0)
            {
                FactWeight = FactWeight * 1000;
                txt_总重.Text = FactWeight.ToString();
            }
            /*
             *FactWeight = 0
    If DataEx(1).EditRS.RecordCount > 0 Then
        DataEx(1).EditRS.MoveFirst
        Do While Not DataEx(1).EditRS.EOF
            FactWeight = FactWeight + Val(DataEx(1).EditRS!单耗 & "")
            DataEx(1).EditRS.MoveNext
        Loop
        DataEx(1).EditRS.MoveFirst
    End If
    If DataEx(2).EditRS.RecordCount > 0 Then
        DataEx(2).EditRS.MoveFirst
        Do While Not DataEx(2).EditRS.EOF
            FactWeight = FactWeight + Val(DataEx(2).EditRS!数量 & "")
            DataEx(2).EditRS.MoveNext
        Loop
        DataEx(2).EditRS.MoveFirst
    End If
    If FactWeight <> 0 Then Text2.text = FactWeight * 1000
             */
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
                            if (row["产品配件改样报关前材料明细表id", DataRowVersion.Original] != DBNull.Value)
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
                            if (row["产品配件改样报关前材料表id", DataRowVersion.Original] != DBNull.Value)
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
            newRow["制造通知单id"] = OrderId;
            newRow["制造通知单明细表id"] = OrderListId;
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
            newRow["数量"] = "0.0";
            dtModifyAfterHead.Rows.Add(newRow);
        }

        /// <summary>
        /// 改样后明细GRID增加一条新行
        /// </summary>
        private void dtModifyAfterDetailAddRow()
        {
            DataRow newRow = dtModifyAfterDetail.NewRow();
            newRow["制造通知单id"] = OrderId;
            newRow["制造通知单明细表id"] = OrderListId;
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
                        if (StringTools.decimalParse( dgv.CurrentRow.Cells["数量"].Value.ToString()) !=StringTools.decimalParse( cell.EditedFormattedValue.ToString()))
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
                strSQL = string.Format("出口帮助录入查询 {0},15 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else if (ManualCode == "B37168420019")
            {
                strSQL = string.Format("出口帮助录入查询 {0},17 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else
            {
                strSQL = string.Format("出口帮助录入查询 {0},16 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
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
                    return false ;
                }
            }
            else
            {
                SysMessage.InformationMsg("此料件不存在！");
                dgv.CurrentCell = cell;
                return false ;
            }

            if (dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString() != "")
            {
                strSQL = string.Format(@"SELECT H.序号,H.商品编码, H.商品名称, Q.商品规格, H.计量单位,H.计量单位,H.损耗率 FROM dbo.归并后料件清单 H 
                                                    LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id 
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
                strSQL = string.Format("出口帮助录入查询 {0},18 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else if (ManualCode == "B37168420019")
            {
                strSQL = string.Format("出口帮助录入查询 {0},20 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else
            {
                strSQL = string.Format("出口帮助录入查询 {0},19 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
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
                    return false ;
                }
            }
            else
            {
                SysMessage.InformationMsg("此料件不存在！");
                dgv.CurrentCell = cell;
                return false ;
            }

            if (dgv.Rows[cell.RowIndex].Cells["显示型号"].Value.ToString() != "")
            {
                strSQL = string.Format(@"SELECT H.序号,H.商品编码, H.商品名称, Q.商品规格, H.计量单位,H.计量单位,H.损耗率 FROM dbo.归并后料件清单 H 
                                                    LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id 
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
                    //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                    (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
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
                    dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
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
        private void check库存量(myDataGridView dgv,DataGridViewCell cell)
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            string strSQL = string.Format("制造通知单单耗库存查询 {0},{1}", dgv.Rows[cell.RowIndex].Cells["料件id"].Value, StringTools.SqlQ(ManualCode));
            DataTable dtTemp = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtTemp.Rows.Count > 0)
            {
                dgv.Rows[cell.RowIndex].Cells["剩余库存量"].Value = dtTemp.Rows[0]["库存量"];
                if (dgv.Rows[cell.RowIndex].Cells["剩余库存量"].Value == DBNull.Value || Convert.ToDecimal(dgv.Rows[cell.RowIndex].Cells["剩余库存量"].Value) < 0)
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
                        if (StringTools.decimalParse( dgv.CurrentRow.Cells["损耗率"].Value.ToString()) !=StringTools.decimalParse( cell.EditedFormattedValue.ToString()))
                        {
                            validate损耗率2(dgv, cell);
                        }
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
                strSQL = string.Format("出口帮助录入查询 {0},18 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else if (ManualCode == "B37168420019")
            {
                strSQL = string.Format("出口帮助录入查询 {0},20 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
            }
            else
            {
                strSQL = string.Format("出口帮助录入查询 {0},19 , 0, 0, 0, '','{1}'", StringTools.SqlQ(cell.EditedFormattedValue.ToString()), ManualCode);
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
                    dgv.Rows[cell.RowIndex].Cells["型号"].Value = formSelect.returnRow["料件型号"];
                    dgv.Rows[cell.RowIndex].Cells["显示型号"].Value = formSelect.returnRow["显示型号"];
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
                                        FROM dbo.归并后料件清单 H LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id where Q.产品编号='{0}' AND H.电子帐册号='{1}'",
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
            Sum总重();
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

        #region tool事件
        public override void tool_Save_Click(object sender, EventArgs e)
        {
            base.tool_Save_Click(sender, e);
            SaveModifyAfterHead();
            SaveModifyAfterDetail();
            LoadDataSource();
            //dtModifyAfterDetail.AcceptChanges();
            //dtModifyAfterHead.AcceptChanges();
        }

        public override void tool_Import_Click(object sender, EventArgs e)
        {
            base.tool_Import_Click(sender, e);
            string strSQL = string.Empty;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            DataTable dtData = null;

            #region 如果明细已经导入，先询问是否删除
            if (dtModifyAfterHead.Rows.Count > 0)
            {
                strSQL = string.Format(@"SELECT 报关订单明细表.订单id FROM 报关订单表 LEFT OUTER JOIN 报关订单明细表 ON 报关订单表.订单id =报关订单明细表.订单id  
                                        where 成品项号 = {0} and 版本号={1} and 手册编号='{2}' and 订单号码='{3}'",
                                       ProductCode == string.Empty ? 0 : Convert.ToInt32(ProductCode), IdCode == string.Empty ? 0 : Convert.ToInt32(IdCode), ManualCode, OrderCode);
                dataAccess.Open();
                dtData = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtData.Rows.Count > 0)
                {
                    if (SysMessage.YesNoMsg("此订单中此产品已出货，建议不要修改，是否退出") == System.Windows.Forms.DialogResult.Yes) return;
                }
                if (SysMessage.YesNoMsg("此产品改样明细已经导入，是否重新导入，导入后原有的数据将会被清除 ") == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                else
                {
                    dataAccess.Open();
                    if (Fid == 0)
                    {
                        strSQL = string.Format("delete from 产品配件改样报关订单材料明细表  where 订单id ={0} and 订单明细表id ={1} and 产品id ={2}", OrderId, OrderListId, Pid);
                        dataAccess.ExecuteNonQuery(strSQL, null);
                        strSQL = string.Format("delete from 产品配件改样报关订单材料表 where 订单id ={0} and 订单明细表id ={1} and 产品id ={2} ", OrderId, OrderListId, Pid);
                        dataAccess.ExecuteNonQuery(strSQL, null);
                    }
                    else
                    {
                        strSQL = string.Format("delete from 产品配件改样报关订单材料明细表  where 订单id ={0} and 订单明细表id ={1} and 配件id ={2}", OrderId, OrderListId, Fid);
                        dataAccess.ExecuteNonQuery(strSQL, null);
                        strSQL = string.Format("delete from 产品配件改样报关订单材料表 where 订单id ={0} and 订单明细表id ={1} and 配件id ={2} ", OrderId, OrderListId, Fid);
                        dataAccess.ExecuteNonQuery(strSQL, null);
                    }
                    dataAccess.Close();
                }
            }
            #endregion

            #region 判断产品id或配件id是否存在历史数据，如果存在的话，则进行相关处理
            if (Fid == 0)
            {
                strSQL = string.Format("select max(产品配件改样报关订单材料明细表id) as id from 产品配件改样报关订单材料明细表  where 产品id = {0}", Pid);
            }
            else
            {
                strSQL = string.Format("select max(产品配件改样报关订单材料明细表id) as id from 产品配件改样报关订单材料明细表  where 配件id = {0}", Fid);
            }
            dataAccess.Open();
            dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count > 0 && dtData.Rows[0]["id"] != DBNull.Value)
            {
                if (SysMessage.YesNoMsg("历史数据已存在此产品的改样明细，是否应用？") == System.Windows.Forms.DialogResult.Yes)
                {
                    strSQL = string.Format("select 产品id,配件id,订单id,订单明细表id from 产品配件改样报关订单材料明细表  where 产品配件改样报关订单材料明细表id = {0}", dtData.Rows[0]["id"]);
                    dataAccess.Open();
                    dtData = dataAccess.GetTable(strSQL, null);
                    dataAccess.Close();
                    #region 获取“产品配件改样报关订单材料表”“产品配件改样报关订单材料明细表”
                    DataTable dt产品配件改样报关订单材料明细表 = null;
                    DataTable dt产品配件改样报关订单材料表 = null;
                    if (dtData.Rows.Count > 0)
                    {
                        DataRow row = dtData.Rows[0];
                        dataAccess.Open();
                        if (row["配件id"] == DBNull.Value || Convert.ToInt32(row["配件id"]) == 0)
                        {
                            strSQL = string.Format("select * from 产品配件改样报关订单材料明细表  where 订单id ={0} and 订单明细表id ={1} and 产品id = {2}",
                                row["订单id"], row["订单明细表id"], row["产品id"]);
                            dt产品配件改样报关订单材料明细表 = dataAccess.GetTable(strSQL, null);
                            strSQL = string.Format("select * from 产品配件改样报关订单材料表  where 订单id ={0} and 订单明细表id ={1} and 产品id = {2}",
                                row["订单id"], row["订单明细表id"], row["产品id"]);
                            dt产品配件改样报关订单材料表 = dataAccess.GetTable(strSQL, null);
                        }
                        else
                        {
                            strSQL = string.Format("select * from 产品配件改样报关订单材料明细表  where 订单id ={0} and 订单明细表id ={1} and 配件id = {2}",
                                row["订单id"], row["订单明细表id"], row["配件id"]);
                            dt产品配件改样报关订单材料明细表 = dataAccess.GetTable(strSQL, null);
                            strSQL = string.Format("select * from 产品配件改样报关订单材料表  where 订单id ={0} and 订单明细表id ={1} and 配件id = {2}",
                                row["订单id"], row["订单明细表id"], row["配件id"]);
                            dt产品配件改样报关订单材料表 = dataAccess.GetTable(strSQL, null);
                        }
                        dataAccess.Close();
                    }
                    #endregion

                    #region 添加改样后页签上面GRID值
                    if (dt产品配件改样报关订单材料明细表 != null && dt产品配件改样报关订单材料明细表.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt产品配件改样报关订单材料明细表.Rows)
                        {
                            DataRow newRow = dtModifyAfterHead.NewRow();
                            newRow["订单id"] = OrderId;
                            newRow["订单明细表id"] = OrderListId;
                            newRow["产品id"] = Pid;
                            newRow["配件id"] = Fid;
                            newRow["料件id"] = row["料件id"];
                            newRow["型号"] = row["型号"];
                            newRow["显示型号"] = row["显示型号"];
                            newRow["品名"] = row["品名"];
                            newRow["项号"] = row["项号"];
                            newRow["编号"] = row["编号"];
                            newRow["商品编码"] = row["商品编码"];
                            newRow["商品名称"] = row["商品名称"];
                            newRow["规格型号"] = row["规格型号"];
                            newRow["计量单位"] = row["计量单位"];
                            newRow["数量"] = row["数量"];
                            newRow["单位"] = row["单位"];
                            newRow["换算率"] = row["换算率"];
                            newRow["单耗"] = row["单耗"];
                            newRow["单耗单位"] = row["单耗单位"];
                            newRow["损耗率"] = row["损耗率"];
                            dtModifyAfterHead.Rows.Add(newRow);
                        }
                    }
                    #endregion

                    #region 添加改样后页签下面GRID值
                    if (dt产品配件改样报关订单材料表 != null && dt产品配件改样报关订单材料表.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt产品配件改样报关订单材料表.Rows)
                        {
                            DataRow newRow = dtModifyAfterDetail.NewRow();
                            newRow["订单id"] = OrderId;
                            newRow["订单明细表id"] = OrderListId;
                            newRow["产品id"] = Pid;
                            newRow["配件id"] = Fid;
                            newRow["料件id"] = row["料件id"];
                            newRow["序号"] = row["序号"];
                            newRow["编号"] = row["编号"];
                            newRow["料件型号"] = row["料件型号"];
                            if (dtModifyAfterHead.Rows.Count > 0)
                                dtModifyAfterHead.Rows[dtModifyAfterHead.Rows.Count - 1]["品名"] = row["品名"];
                            newRow["商品编码"] = row["商品编码"];
                            newRow["商品名称"] = row["商品名称"];
                            newRow["规格型号"] = row["规格型号"];
                            newRow["计量单位"] = row["计量单位"];
                            newRow["损耗率"] = row["损耗率"];
                            newRow["数量"] = row["数量"];
                            newRow["单位"] = row["单位"];
                            newRow["备注"] = row["备注"];
                            newRow["区域"] = row["区域"];
                            dtModifyAfterDetail.Rows.Add(newRow);
                        }
                    }
                    #endregion

                    #region 保存数据
                    SaveModifyAfterHead();
                    SaveModifyAfterDetail();

                    LoadDataSource();
                    Sum总重();
                    #endregion

                    return;
                }
            }
            #endregion

            #region 根据改样明细，处理改样后数据
            if (dtModifyBefore.Rows.Count > 0)
            {
                string three显示型号 = string.Empty;
                DataTable dtTemp = null;
                dataAccess.Open();
                foreach (DataRow row in dtModifyBefore.Rows)
                {
                    if (row["数量"] == DBNull.Value || Convert.ToInt32(row["数量"]) == 0) continue;
                    bool b显示型号 = true;
                    if (row["显示型号"] != DBNull.Value && row["显示型号"].ToString() != "")
                    {
                        three显示型号 = row["显示型号"].ToString().Substring(0, 3);
                        if (!(three显示型号 == "A16" || three显示型号 == "A18" || three显示型号 == "A18" || three显示型号 == "A20" || three显示型号 == "A21"
                        || three显示型号 == "A22" || three显示型号 == "A23" || three显示型号 == "A24"))
                        {
                            b显示型号 = false;
                        }
                    }
                    if (!b显示型号)
                    {
                        DataRow newRow = dtModifyAfterHead.NewRow();
                        newRow["制造通知单id"] = OrderId;
                        newRow["制造通知单明细表id"] = OrderListId;
                        newRow["产品id"] = Pid;
                        newRow["配件id"] = Fid;
                        newRow["料件id"] = row["料件id"];
                        newRow["型号"] = row["型号"] == DBNull.Value ? "" : row["型号"];
                        newRow["显示型号"] = row["显示型号"];
                        if (row["显示型号"].ToString().StartsWith("A") || row["显示型号"].ToString().StartsWith("B"))
                        {
                            newRow["编号"] = row["显示型号"].ToString().Substring(0, 8);
                        }
                        newRow["品名"] = row["品名"];
                        newRow["项号"] = row["项号"];
                        newRow["商品编码"] = row["商品编码"];
                        newRow["商品名称"] = row["商品名称"];
                        newRow["规格型号"] = row["规格型号"];
                        newRow["计量单位"] = row["计量单位"];
                        newRow["数量"] = row["数量"];
                        newRow["单位"] = row["单位"];
                        if (row["数量"] != DBNull.Value && Convert.ToInt32(row["数量"]) != 0)
                        {
                            newRow["换算率"] = (Convert.ToDecimal(row["单耗"]) / Convert.ToInt32(row["数量"])).ToString("N5");
                        }
                        newRow["单耗"] = Convert.ToDecimal(row["单耗"]).ToString("N5");
                        newRow["单耗单位"] = row["单耗单位"];
                        #region 根据项号获得序号，获取损耗率
                        if (row["项号"] != DBNull.Value && row["项号"].ToString() != "")
                        {
                            string str项号 = row["项号"].ToString();
                            int i序号;
                            if (!str项号.Contains("-"))  //如果不包含“-”的话，则直接将项号转成数字值
                            {
                                try
                                {
                                    i序号 = int.Parse(str项号);
                                }
                                catch
                                {
                                    i序号 = 0;
                                }
                            }
                            else
                            {
                                try
                                {
                                    i序号 = int.Parse(str项号.Substring(0, str项号.IndexOf('-')));
                                }
                                catch
                                {
                                    i序号 = 0;
                                }
                            }
                            strSQL = string.Format("SELECT 损耗率 From 归并后料件清单 where 序号={0}", i序号);
                            dtTemp = dataAccess.GetTable(strSQL, null);
                            if (dtTemp.Rows.Count > 0) newRow["损耗率"] = dtTemp.Rows[0]["损耗率"];
                        }
                        #endregion
                        dtModifyAfterHead.Rows.Add(newRow);
                    }
                    else
                    {
                        DataRow newRow = dtModifyAfterDetail.NewRow();
                        newRow["数量"] = 0;
                        newRow["单位"] = "KGS";
                        newRow["区域"] = "A";
                        newRow["制造通知单id"] = OrderId;
                        newRow["制造通知单明细表id"] = OrderListId;
                        newRow["产品id"] = Pid;
                        newRow["配件id"] = Fid;
                        newRow["料件id"] = row["料件id"];
                        newRow["序号"] = row["显示型号"] == DBNull.Value ? 0 : int.Parse(row["显示型号"].ToString().Substring(1, 2));
                        newRow["编号"] = row["显示型号"] == DBNull.Value ? "" : row["显示型号"];
                        newRow["料件型号"] = row["型号"] == DBNull.Value ? "" : row["型号"];
                        newRow["品名"] = row["品名"];
                        strSQL = string.Format(@"SELECT Q.产品编号,H.序号,H.损耗率, H.商品编码, H.商品名称, Q.商品规格, H.计量单位 FROM dbo.归并后料件清单 H 
                                    LEFT OUTER JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id where H.序号={0} AND H.电子帐册号='{1}'", newRow["序号"], ManualCode);
                        dtTemp = dataAccess.GetTable(strSQL, null);
                        if (dtTemp.Rows.Count > 0)
                        {
                            DataRow rowTemp = dtTemp.Rows[0];
                            newRow["序号"] = rowTemp["序号"];
                            newRow["商品编码"] = rowTemp["商品编码"];
                            newRow["商品名称"] = rowTemp["商品名称"];
                            newRow["计量单位"] = rowTemp["计量单位"];
                            newRow["损耗率"] = rowTemp["损耗率"];
                            newRow["规格型号"] = rowTemp["规格型号"];
                            newRow["数量"] = rowTemp["单耗"] == DBNull.Value ? rowTemp["单耗"] : Convert.ToInt32(rowTemp["单耗"]).ToString("N5");
                            newRow["单位"] = rowTemp["单耗单位"];
                            newRow["区域"] = "A";
                        }
                        dtModifyAfterDetail.Rows.Add(newRow);
                    }
                    dataAccess.Close();
                }
                SaveModifyAfterHead();
                SaveModifyAfterDetail();
                LoadDataSource();
                Sum总重();
            }
            #endregion
        }

        public override void tool_Close_Click(object sender, EventArgs e)
        {
            base.tool_Close_Click(sender, e);
            this.Close();
        }
        #endregion

    }
}
