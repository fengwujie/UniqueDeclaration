using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;
using System.IO;
using UniqueDeclarationBaseForm;
using System.Configuration;

namespace UniqueDeclaration
{
    public partial class FormFinishedProductOutQueryList : UniqueDeclarationBaseForm.FormBase
    {
        public FormFinishedProductOutQueryList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否触发行变化事件
        /// </summary>
        private bool bTriggerGridViewHead_SelectionChanged = true;
        /// <summary>
        /// 查询窗体的返回来的条件
        /// </summary>
        public string gstrWhere = string.Empty;
        /// <summary>
        /// 判断是否已经加载过用量汇总
        /// </summary>
        private bool bInitGridSumCount = false;

        private void FormFinishedProductOutQueryList_Load(object sender, EventArgs e)
        {
            LoadDataSourceHead();

            InitGridHead();
            InitGridDetail();
            InitGridDetailsSumCount();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bTriggerGridViewHead_SelectionChanged)
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        LoadDataSourceDetails();
                        break;
                    case 1:
                        LoadDataSourceDetailsSumCount();
                        break;
                }
            }
        }
        private void dataGridViewHead_SelectionChanged(object sender, EventArgs e)
        {
            if (bTriggerGridViewHead_SelectionChanged)
            {
                this.tabControl1_SelectedIndexChanged(null, null);
                setTool1Enabled();
            }
        }

        #region 加载数据
        /// <summary>
        /// 加载表头数据
        /// </summary>
        private void LoadDataSourceHead()
        {
            //bool bShow = false;
            //if (formBaseLoading == null)
            //{
            //    formBaseLoading = new FormBaseLoading();
            //    bShow = true;
            //    formBaseLoading.strLoadText = "加载【预先订单录入】数据，请稍等。。。。。。";
            //    formBaseLoading.Show();
            //    formBaseLoading.Refresh();
            //}
            try
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = "SELECT * FROM 报关订单表 " + (gstrWhere.Length > 0 ? " where " : "") + gstrWhere + "ORDER BY 录入日期 DESC";
                DataTable dtHead = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                bTriggerGridViewHead_SelectionChanged = false;
                this.dataGridViewHead.DataSource = dtHead;
                bTriggerGridViewHead_SelectionChanged = true;
                //if (this.dataGridViewHead.RowCount > 0)
                //{
                //    this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[0].Cells["订单号码"];
                //    this.dataGridViewHead.Rows[0].Selected = true;
                //}
                this.dataGridViewHead_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【预先订单录入】数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
            //finally
            //{
            //    if (bShow && formBaseLoading != null)
            //    {
            //        formBaseLoading.Close();
            //        formBaseLoading.Dispose();
            //        formBaseLoading = null;
            //    }
            //}
        }
        /// <summary>
        /// 加载订单内容数据
        /// </summary>
        private void LoadDataSourceDetails()
        {
            //bool bShow = false;
            //if (formBaseLoading == null)
            //{
            //    formBaseLoading = new FormBaseLoading();
            //    bShow = true;
            //    formBaseLoading.strLoadText =string.Format("加载【{0}】数据，请稍等。。。。。。", this.tabPage1.Text);
            //    formBaseLoading.Show();
            //    formBaseLoading.Refresh();
            //}
            try
            {
                int iOrderID = 0;
                if (this.dataGridViewHead.CurrentRow != null && this.dataGridViewHead.CurrentRow.Index >= 0)
                {
                    iOrderID = (int)this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRow.Index].Cells["订单id"].Value;
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("exec 报关订单录入查询 {0}", iOrderID);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();

                this.dataGridViewDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【{0}】数据出错，错误信息如下：{1}{2}", this.tabPage1.Text, Environment.NewLine, ex.Message));
            }
            //finally
            //{
            //    if (bShow && formBaseLoading != null)
            //    {
            //        formBaseLoading.Close();
            //        formBaseLoading.Dispose();
            //        formBaseLoading = null;
            //    }
            //}
        }
        /// <summary>
        /// 加载归并前材料明细用量表
        /// </summary>
        private void LoadDataSourceDetailsSumCount()
        {
            //bool bShow = false;
            //if (formBaseLoading == null)
            //{
            //    formBaseLoading = new FormBaseLoading();
            //    bShow = true;
            //    formBaseLoading.strLoadText = string.Format("加载【{0}】数据，请稍等。。。。。。", this.tabPage4.Text);
            //    formBaseLoading.Show();
            //    formBaseLoading.Refresh();
            //}
            try
            {
                int iOrderID = 0;
                string strBooksNo = string.Empty;
                if (this.dataGridViewHead.CurrentRow != null && this.dataGridViewHead.CurrentRow.Index >= 0)
                {
                    iOrderID = (int)this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRow.Index].Cells["订单id"].Value;
                    strBooksNo = this.dataGridViewHead.CurrentRow.Cells["手册编号"].Value.ToString();
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("exec 订单用量明细 {0},'{1}'", iOrderID, strBooksNo);
                DataTable dtMergeBeforeDetailsSumCount = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();

                this.dataGridViewDetailsSumCount.DataSource = dtMergeBeforeDetailsSumCount;

                InitGridDetailsSumCount();
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【{0}】数据出错，错误信息如下：{1}{2}", this.tabPage2.Text, Environment.NewLine, ex.Message));
            }
            //finally
            //{
            //    if (bShow && formBaseLoading != null)
            //    {
            //        formBaseLoading.Close();
            //        formBaseLoading.Dispose();
            //        formBaseLoading = null;
            //    }
            //}
        }
        #endregion

        #region 初始化GRID
        private void InitGridHead()
        {
            this.dataGridViewHead.AutoGenerateColumns = false;
            this.dataGridViewHead.Columns["订单id"].Visible = false;

            this.dataGridViewHead.Columns["订单号码"].DisplayIndex = 0;
            this.dataGridViewHead.Columns["手册编号"].DisplayIndex = 1;
            this.dataGridViewHead.Columns["客户代码"].DisplayIndex = 2;
            this.dataGridViewHead.Columns["客户代码"].Width = 78;
            this.dataGridViewHead.Columns["客户名称"].DisplayIndex = 3;
            this.dataGridViewHead.Columns["出货日期"].DisplayIndex = 4;
            this.dataGridViewHead.Columns["出货日期"].Width = 78;
            this.dataGridViewHead.Columns["录入日期"].DisplayIndex = 5;
            this.dataGridViewHead.Columns["录入日期"].Width = 78;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dataGridViewHead.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextHead;
            }
        }
        private void InitGridDetail()
        {
            this.dataGridViewDetails.AutoGenerateColumns = false;
            this.dataGridViewDetails.Columns["BM"].Visible = false;
            this.dataGridViewDetails.Columns["订单明细表id"].Visible = false;
            //this.dataGridViewDetails.Columns["订单id"].Visible = false;
            this.dataGridViewDetails.Columns["制造通知单id"].Visible = false;
            this.dataGridViewDetails.Columns["产品id"].Visible = false;
            this.dataGridViewDetails.Columns["配件id"].Visible = false;

            this.dataGridViewDetails.Columns["制造通知单号"].DisplayIndex = 0;
            this.dataGridViewDetails.Columns["制造通知单号"].Width = 100;
            this.dataGridViewDetails.Columns["客人型号"].DisplayIndex = 1;
            this.dataGridViewDetails.Columns["客人型号"].Width = 78;
            this.dataGridViewDetails.Columns["优丽型号"].DisplayIndex = 2;
            this.dataGridViewDetails.Columns["优丽型号"].Width = 78;
            this.dataGridViewDetails.Columns["颜色"].DisplayIndex = 3;
            this.dataGridViewDetails.Columns["颜色"].Width = 55;
            this.dataGridViewDetails.Columns["订单数量"].DisplayIndex = 4;
            this.dataGridViewDetails.Columns["订单数量"].Width = 78;
            this.dataGridViewDetails.Columns["单位"].DisplayIndex = 5;
            this.dataGridViewDetails.Columns["单位"].Width = 55;
            this.dataGridViewDetails.Columns["箱数"].DisplayIndex = 6;
            this.dataGridViewDetails.Columns["箱数"].Width = 55;
            this.dataGridViewDetails.Columns["型号"].DisplayIndex = 7;
            //this.dataGridViewDetails.Columns["型号"].Width = 78;
            this.dataGridViewDetails.Columns["型号"].HeaderText = "生产型号";
            this.dataGridViewDetails.Columns["生产数量"].DisplayIndex = 8;
            this.dataGridViewDetails.Columns["生产数量"].Width = 78;
            this.dataGridViewDetails.Columns["实际总重"].DisplayIndex = 9;
            this.dataGridViewDetails.Columns["实际总重"].Width = 78;
            this.dataGridViewDetails.Columns["总重"].DisplayIndex = 10;
            this.dataGridViewDetails.Columns["总重"].Width = 55;
            this.dataGridViewDetails.Columns["版本号"].DisplayIndex = 11;
            this.dataGridViewDetails.Columns["版本号"].Width = 90;
            this.dataGridViewDetails.Columns["版本号"].HeaderText = "企业版本号";
            this.dataGridViewDetails.Columns["内部版本号"].DisplayIndex = 12;
            this.dataGridViewDetails.Columns["内部版本号"].Width = 90;
            this.dataGridViewDetails.Columns["成品项号"].DisplayIndex = 13;
            this.dataGridViewDetails.Columns["成品项号"].Width = 78;
            this.dataGridViewDetails.Columns["成品名称及商编"].DisplayIndex = 14;
            this.dataGridViewDetails.Columns["成品名称及商编"].Width = 130;
            this.dataGridViewDetails.Columns["成品规格型号"].DisplayIndex = 15;
            this.dataGridViewDetails.Columns["成品规格型号"].Width = 110;
            this.dataGridViewDetails.Columns["申报单位"].DisplayIndex = 16;
            this.dataGridViewDetails.Columns["申报单位"].Width = 78;
            this.dataGridViewDetails.Columns["法定单位"].DisplayIndex = 17;
            this.dataGridViewDetails.Columns["法定单位"].Width = 78;
            this.dataGridViewDetails.Columns["变更规格型号"].DisplayIndex = 18;
            this.dataGridViewDetails.Columns["变更规格型号"].Width = 100;
            this.dataGridViewDetails.Columns["订单备注"].DisplayIndex = 19;
            this.dataGridViewDetails.Columns["订单备注"].Width = 78;

            foreach (DataGridViewTextBoxColumn textBoxColumn in this.dataGridViewDetails.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextDetails;
            }
        }
        private void InitGridDetailsSumCount()
        {
            if (this.dataGridViewDetailsSumCount.DataSource != null && !bInitGridSumCount)
            {
                this.dataGridViewDetailsSumCount.Columns["序号"].DisplayIndex = 0;
                this.dataGridViewDetailsSumCount.Columns["序号"].Width = 55;
                this.dataGridViewDetailsSumCount.Columns["商品编码"].DisplayIndex = 1;
                this.dataGridViewDetailsSumCount.Columns["商品编码"].Width = 78;
                this.dataGridViewDetailsSumCount.Columns["商品名称"].DisplayIndex = 2;
                this.dataGridViewDetailsSumCount.Columns["商品名称"].Width = 78;
                this.dataGridViewDetailsSumCount.Columns["规格型号"].DisplayIndex = 3;
                this.dataGridViewDetailsSumCount.Columns["规格型号"].Width = 150;
                this.dataGridViewDetailsSumCount.Columns["计量单位"].DisplayIndex = 4;
                this.dataGridViewDetailsSumCount.Columns["计量单位"].Width = 78;
                this.dataGridViewDetailsSumCount.Columns["损耗率"].DisplayIndex = 5;
                this.dataGridViewDetailsSumCount.Columns["损耗率"].Width = 70;
                this.dataGridViewDetailsSumCount.Columns["总用量"].DisplayIndex = 6;
                this.dataGridViewDetailsSumCount.Columns["总用量"].Width = 70;
                this.dataGridViewDetailsSumCount.Columns["单耗"].Visible = false;
                foreach (DataGridViewTextBoxColumn textBoxColumn in this.dataGridViewDetailsSumCount.Columns)
                {
                    textBoxColumn.ContextMenuStrip = this.myContextDetailsSumCount;
                }
                bInitGridSumCount = true;
            }
        }
        #endregion

        #region tool事件
        private void tool1_First_Click(object sender, EventArgs e)
        {
            this.dataGridViewHead.ClearSelection();
            this.dataGridViewHead.Rows[0].Selected = true;
            this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[0].Cells["订单号码"];
            setTool1Enabled();
        }

        private void tool1_up_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.dataGridViewHead.CurrentRow.Index;
            this.dataGridViewHead.ClearSelection();
            this.dataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[iSelectRow - 1].Cells["订单号码"];
            setTool1Enabled();
        }

        private void tool1_Down_Click(object sender, EventArgs e)
        {
            int iSelectRow = this.dataGridViewHead.CurrentRow.Index;
            this.dataGridViewHead.ClearSelection();
            this.dataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[iSelectRow + 1].Cells["订单号码"];
            setTool1Enabled();
        }

        private void tool1_End_Click(object sender, EventArgs e)
        {
            this.dataGridViewHead.ClearSelection();
            this.dataGridViewHead.Rows[this.dataGridViewHead.RowCount - 1].Selected = true;
            this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[this.dataGridViewHead.RowCount - 1].Cells["订单号码"];
            setTool1Enabled();
        }

        private void tool1_Import_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.CurrentRow == null) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            try
            {
                DataTable dtDetails = (DataTable)this.dataGridViewDetails.DataSource;
                long Pid, Fid, OrderID, OrderListID;
                StringBuilder strBuilder = new StringBuilder();
                DataTable dtTemp = null;
                OrderID = this.dataGridViewHead.CurrentRow.Cells["订单id"].Value == DBNull.Value ? 0 : Convert.ToInt64(this.dataGridViewHead.CurrentRow.Cells["订单id"].Value);
                foreach (DataRow rowD in dtDetails.Rows)
                {
                    strBuilder.Clear();
                    Pid = rowD["产品id"] == DBNull.Value ? 0 : Convert.ToInt64(rowD["产品id"]);
                    Fid = rowD["配件id"] == DBNull.Value ? 0 : Convert.ToInt64(rowD["配件id"]);
                    OrderListID = rowD["订单明细表id"] == DBNull.Value ? 0 : Convert.ToInt64(rowD["订单明细表id"]);
                    if (Fid == 0)
                    {
                        strBuilder.AppendLine(string.Format("delete from 产品配件改样报关材料明细表  where 订单id ={0} and 订单明细表id ={1} and 产品id = {2}", OrderID, OrderListID, Pid));
                        strBuilder.AppendLine(string.Format("delete from 产品配件改样报关材料表 where 订单id ={0} and 订单明细表id ={1} and 产品id = {2}", OrderID, OrderListID, Pid));
                    }
                    else
                    {
                        strBuilder.AppendLine(string.Format("delete from 产品配件改样报关材料明细表  where 订单id ={0} and 订单明细表id ={1} and 配件id = {2}", OrderID, OrderListID, Fid));
                        strBuilder.AppendLine(string.Format("delete from 产品配件改样报关材料表 where 订单id ={0} and 订单明细表id ={1} and 配件id = {2}", OrderID, OrderListID, Fid));
                    }
                    dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                    if (rowD["制造通知单id"] != DBNull.Value)
                    {
                        strBuilder.Clear();
                        if (Pid != 0)
                        {
                            strBuilder.AppendLine(string.Format("select 制造通知单id,制造通知单明细表id,产品id from 报关制造通知单明细表 WHERE 制造通知单id={0} and 产品id={1}", rowD["制造通知单id"], Pid));
                            dtTemp = dataAccess.GetTable(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            if (dtTemp.Rows.Count > 0)
                            {
                                strBuilder.AppendLine(string.Format(@"INSERT INTO 产品配件改样报关材料明细表(订单id,订单明细表id,产品id,配件id,料件id,型号,显示型号,品名,项号,编号,商品编码,商品名称,
                                                                            规格型号,计量单位,数量,单位,单耗,单耗单位,损耗率,换算率) 
                                                                    SELECT {0},{1},产品id,配件id,料件id,型号,显示型号,品名,项号,编号,商品编码,商品名称,规格型号,计量单位,数量,单位,单耗,单耗单位,
                                                                            损耗率,换算率 From 产品配件改样报关前材料明细表 WHERE 制造通知单id={2} and 制造通知单明细表id={3} and 产品id={4}",
                                                                    OrderID, OrderListID, dtTemp.Rows[0]["制造通知单id"], dtTemp.Rows[0]["制造通知单id"], dtTemp.Rows[0]["产品id"]));
                                strBuilder.AppendLine(string.Format(@"INSERT INTO 产品配件改样报关材料表(订单id,订单明细表id,产品id,配件id,料件id,序号,编号,商品编码,商品名称,规格型号,计量单位,数量,
                                                                                单位,备注,损耗率,区域) 
                                                                    SELECT {0},{1},产品id,配件id,料件id,序号,编号,商品编码,商品名称,规格型号,计量单位,数量,单位,备注,损耗率,区域 
                                                                            From 产品配件改样报关前材料表 WHERE 制造通知单id={2} and 制造通知单明细表id={3} and 产品id={4}",
                                                                    OrderID, OrderListID, dtTemp.Rows[0]["制造通知单id"], dtTemp.Rows[0]["制造通知单id"], dtTemp.Rows[0]["产品id"]));
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                            }
                        }
                        else
                        {
                            strBuilder.AppendLine(string.Format("select 制造通知单id,制造通知单明细表id,配件id from 报关制造通知单明细表 WHERE 制造通知单id={0} and 配件id={1}", rowD["制造通知单id"], Fid));
                            dtTemp = dataAccess.GetTable(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            if (dtTemp.Rows.Count > 0)
                            {
                                strBuilder.AppendLine(string.Format(@"INSERT INTO 产品配件改样报关材料明细表(订单id,订单明细表id,产品id,配件id,料件id,型号,显示型号,品名,项号,编号,商品编码,商品名称,
                                                                            规格型号,计量单位,数量,单位,单耗,单耗单位,损耗率,换算率) 
                                                                    SELECT {0},{1},产品id,配件id,料件id,型号,显示型号,品名,项号,编号,商品编码,商品名称,规格型号,计量单位,数量,单位,单耗,单耗单位,
                                                                            损耗率,换算率 From 产品配件改样报关前材料明细表 WHERE 制造通知单id={2} and 制造通知单明细表id={3} and 配件id={4}",
                                                                    OrderID, OrderListID, dtTemp.Rows[0]["制造通知单id"], dtTemp.Rows[0]["制造通知单id"], dtTemp.Rows[0]["配件id"]));
                                strBuilder.AppendLine(string.Format(@"INSERT INTO 产品配件改样报关材料表(订单id,订单明细表id,产品id,配件id,料件id,序号,编号,商品编码,商品名称,规格型号,计量单位,数量,
                                                                            单位,备注,损耗率,区域) 
                                                                    SELECT {0},{1},产品id,配件id,料件id,序号,编号,商品编码,商品名称,规格型号,计量单位,数量,单位,备注,损耗率,区域 
                                                                            From 产品配件改样报关前材料表 WHERE 制造通知单id={2} and 制造通知单明细表id={3} and 配件id={4}",
                                                                    OrderID, OrderListID, dtTemp.Rows[0]["制造通知单id"], dtTemp.Rows[0]["制造通知单id"], dtTemp.Rows[0]["配件id"]));
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                            }
                        }
                    }
                }
                dataAccess.Close();
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(ex.Message);
                dataAccess.Close();
            }
        }

        private void tool1_Modify_Click(object sender, EventArgs e)
        {
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.dataGridViewHead.CurrentRow.Cells["订单id"].Value);
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormFinishedProductOutInput")
                {
                    FormFinishedProductOutInput inputForm = (FormFinishedProductOutInput)childFrm;
                    if (inputForm.giOrderID != 0 && inputForm.giOrderID == iOrderID)
                    {
                        bHave = true;
                        childFrm.Activate();
                        break;
                    }
                }
            }
            if (!bHave)
            {
                FormFinishedProductOutInput objForm = new FormFinishedProductOutInput();
                objForm.MdiParent = this.MdiParent;
                objForm.giOrderID = iOrderID;
                objForm.Show();
            }
        }

        private void tool1_Delete_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewHead.CurrentRow == null) return;
            int iOrderID = Convert.ToInt32(this.dataGridViewHead.CurrentRow.Cells["订单id"].Value);
            IDataAccess data = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            data.Open();
            DataTable dtList = data.GetTable(string.Format("select * from 产品配件改样报关材料明细表 where 订单id ={0}", iOrderID), null);
            data.Close();
            if (dtList.Rows.Count > 0)
            {
                SysMessage.InformationMsg("已存在材料明细，此订单不能删除！");
                return;
            }
            data.Open();
            dtList = data.GetTable(string.Format("select * from 产品配件改样报关材料表 where 订单id ={0}", iOrderID), null);
            data.Close();
            if (dtList.Rows.Count > 0)
            {
                SysMessage.InformationMsg("已存在材料明细，此订单不能删除！");
                return;
            }
            if (SysMessage.YesNoMsg(string.Format("真的要删除订单【{0}】吗？", this.dataGridViewHead.CurrentRow.Cells["订单号码"].Value)) == System.Windows.Forms.DialogResult.No) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dataAccess.BeginTran();
            try
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine(string.Format("delete from 产品配件改样报关材料明细表  where 订单id ={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 产品配件改样报关材料表 where 订单id ={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 报关订单明细表 where 订单id={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 报关订单表 where 订单id={0}", iOrderID));
                dataAccess.CommitTran();
                dataAccess.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.dataGridViewHead.CurrentRow.Cells["订单号码"].Value);
                this.dataGridViewHead.Rows.Remove(this.dataGridViewHead.CurrentRow);
                setTool1Enabled();
                SysMessage.InformationMsg(strSuccess);
            }
            catch (Exception ex)
            {
                dataAccess.RollbackTran();
                dataAccess.Close();
                string strError = string.Format("{0} 出现错误：错误信息：{1}", tool1_Delete.Text, ex.Message);
                SysMessage.ErrorMsg(strError);
            }
        }

        private void tool1_BOM_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewDetails.RowCount == 0) return;
            if (this.dataGridViewHead.CurrentRow.Cells["手册编号"].Value.ToString() == "")
            {
                SysMessage.InformationMsg("请输入电子帐册号！");
                return;
            }
            #region 判断是否已经有打开的BOM窗体
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormOrderBOM")
                {
                    FormOrderBOM orderBomForm = (FormOrderBOM)childFrm;
                    if (orderBomForm.OrderId == Convert.ToInt32(this.dataGridViewHead.CurrentRow.Cells["订单id"].Value)
                        && orderBomForm.OrderListId == Convert.ToInt32(this.dataGridViewDetails.CurrentRow.Cells["订单明细表id"].Value))
                    {
                        childFrm.Activate();
                        return;
                    }
                }
            }
            #endregion

            #region 删除当前订单明细ID对应的非当前配件ID或产品ID的数据
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            int iOrderID = Convert.ToInt32(this.dataGridViewHead.CurrentRow.Cells["订单id"].Value);
            string strSQL = string.Format("delete from 产品配件改样报关订单材料明细表  where 订单id ={0} and 订单明细表id not in (select 订单明细表id from 报关预先订单明细表 where 订单id ={0})", iOrderID);
            dataAccess.ExecuteNonQuery(strSQL, null);
            strSQL = string.Format("delete from 产品配件改样报关订单材料表 where 订单id ={0} and 订单明细表id not in (select 订单明细表id from 报关预先订单明细表 where 订单id ={0})", iOrderID);
            dataAccess.ExecuteNonQuery(strSQL, null);
            dataAccess.Close();
            int iOrderDetailID = Convert.ToInt32(this.dataGridViewDetails.CurrentRow.Cells["订单明细表id"].Value);
            if (this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value == DBNull.Value || Convert.ToInt32(this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value) == 0)
            {
                dataAccess.Open();
                strSQL = string.Format("delete from 产品配件改样报关订单材料明细表 where 配件id is not null and 订单id ={0} and 订单明细表id ={1} and 配件id<> {2}", iOrderID, iOrderDetailID, StringTools.intParse(this.dataGridViewDetails.CurrentRow.Cells["配件id"].Value.ToString()));
                dataAccess.ExecuteNonQuery(strSQL, null);
                strSQL = string.Format("delete from 产品配件改样报关订单材料表 where 配件id is not null and 订单id ={0} and 订单明细表id ={1} and 配件id<>{2}", iOrderID, iOrderDetailID, StringTools.intParse(this.dataGridViewDetails.CurrentRow.Cells["配件id"].Value.ToString()));
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
            }
            else
            {
                dataAccess.Open();
                strSQL = string.Format("delete from 产品配件改样报关订单材料明细表 where 产品id is not null and 订单id ={0} and 订单明细表id ={1} and 产品id<> {2}", iOrderID, iOrderDetailID, StringTools.intParse(this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value.ToString()));
                dataAccess.ExecuteNonQuery(strSQL, null);
                strSQL = string.Format("delete from 产品配件改样报关订单材料表 where 产品id is not null and 订单id ={0} and 订单明细表id ={1} and 产品id<>{2}", iOrderID, iOrderDetailID, StringTools.intParse(this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value.ToString()));
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
            }
            #endregion

            FormOrderBOM formBOM = new FormOrderBOM();
            formBOM.Pid = this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value == DBNull.Value ? 0 : Convert.ToInt32(this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value);
            formBOM.Fid = this.dataGridViewDetails.CurrentRow.Cells["配件id"].Value == DBNull.Value ? 0 : Convert.ToInt32(this.dataGridViewDetails.CurrentRow.Cells["配件id"].Value);
            formBOM.OrderId = iOrderID;
            formBOM.OrderListId = iOrderDetailID;
            formBOM.ManualCode = this.dataGridViewHead.CurrentRow.Cells["手册编号"].Value.ToString();
            formBOM.mstrName = this.dataGridViewDetails.CurrentRow.Cells["型号"].Value.ToString();
            formBOM.ProductCode = this.dataGridViewDetails.CurrentRow.Cells["成品项号"].Value.ToString();
            formBOM.AllWeight = (this.dataGridViewDetails.CurrentRow.Cells["实际总重"].Value == null || this.dataGridViewDetails.CurrentRow.Cells["实际总重"].Value == DBNull.Value) ? 0 : float.Parse(this.dataGridViewDetails.CurrentRow.Cells["实际总重"].Value.ToString());
            formBOM.FactWeight = this.dataGridViewDetails.CurrentRow.Cells["总重"].Value == DBNull.Value ? 0 : float.Parse(this.dataGridViewDetails.CurrentRow.Cells["总重"].Value.ToString());
            formBOM.Unitname = this.dataGridViewDetails.CurrentRow.Cells["成品项号"].Value.ToString();
            formBOM.modename = this.dataGridViewDetails.CurrentRow.Cells["成品规格型号"].Value.ToString();
            if (this.dataGridViewDetails.CurrentRow.Cells["成品名称及商编"].Value != DBNull.Value)
            {
                string 成品名称及商编 = this.dataGridViewDetails.CurrentRow.Cells["成品名称及商编"].Value.ToString();
                formBOM.NameCode1 = 成品名称及商编.Substring(0, 成品名称及商编.LastIndexOf('/'));
                formBOM.NameCode2 = 成品名称及商编.Substring(成品名称及商编.LastIndexOf('/') + 1);
            }
            else
            {
                formBOM.NameCode1 = "";
                formBOM.NameCode2 = "";
            }
            formBOM.MdiParent = this.MdiParent;
            formBOM.Show();
        }

        private void tool1_Query_Click(object sender, EventArgs e)
        {
            FormFinishedProductOutQueryCondition queryConditionForm = new FormFinishedProductOutQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrWhere = queryConditionForm.strReturnWhere;
                LoadDataSourceHead();
            }
        }

        private void tool1_Print_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 设置tools的按钮是否可用
        /// </summary>
        private void setTool1Enabled()
        {
            this.tool1_Query.Enabled = true;
            DataTable dtTable = (DataTable)dataGridViewHead.DataSource;
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
                    if (this.dataGridViewHead.CurrentRow == null) return;
                    if (this.dataGridViewHead.CurrentRow.Index == 0)
                    {
                        this.tool1_First.Enabled = false;
                        this.tool1_up.Enabled = false;
                        this.tool1_Down.Enabled = true;
                        this.tool1_End.Enabled = true;
                    }
                    else if (this.dataGridViewHead.CurrentRow.Index == this.dataGridViewHead.RowCount - 1)  //如果行索引为最后一行
                    {
                        this.tool1_First.Enabled = true;
                        this.tool1_up.Enabled = true;
                        this.tool1_Down.Enabled = true;
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
                this.tool1_BOM.Enabled = true;
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
                this.tool1_BOM.Enabled = false;
                this.tool1_ExportExcel.Enabled = false;
                this.tool1_Print.Enabled = false;
            }
        }
        #endregion

        #region 按钮事件
        //材料对照表
        private void btnMaterialComparison_Click(object sender, EventArgs e)
        {

        }
        //导出到EXCEL
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;
            bool isExportDetail = false;
            if (SysMessage.YesNoMsg("是否导出单耗明细") == System.Windows.Forms.DialogResult.Yes)
                isExportDetail = true;
            string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\出口成品料件单.xls");
            string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\出口成品料件单{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
            File.Copy(strSourceFile, strDestFile);
            File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
            string fn = strDestFile;
            ExcelTools ea = new ExcelTools();
            ea.SafeOpen(fn);
            ea.ActiveSheet(1); // 激活
            ea.SetValue("A2", "订单号码:" + dataGridViewHead.CurrentRow.Cells["订单号码"].Value.ToString());
            ea.SetValue("C2", "客户代码：" + dataGridViewHead.CurrentRow.Cells["客户代码"].Value.ToString());
            ea.SetValue("E2", "客户名称：" + dataGridViewHead.CurrentRow.Cells["客户名称"].Value.ToString());
            ea.SetValue("A3", "出货日期：" + Convert.ToDateTime(dataGridViewHead.CurrentRow.Cells["出货日期"].Value).ToString("yyyy-MM-dd"));
            ea.SetValue("C3", "录入日期：" + Convert.ToDateTime(dataGridViewHead.CurrentRow.Cells["录入日期"].Value).ToString("yyyy-MM-dd"));

            #region 循环订单明细
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtDetailsSub = dataAccess.GetTable(string.Format("报关订单料件明细查询 {0}", dataGridViewHead.CurrentRow.Cells["订单id"].Value), null);
            dataAccess.Close();
            decimal intSortWeight = 0;
            decimal intTotalWeight = 0;
            long n = 5;   //记录EXCEL所在索引行
            DataTable dtDetails = (DataTable)this.dataGridViewDetails.DataSource;
            foreach (DataRow row in dtDetails.Rows)
            {
                ea.SetValue(string.Format( "A{0}",n), row["客人型号"] == DBNull.Value ? "" : row["客人型号"].ToString());
                ea.SetValue(string.Format( "B{0}",n), row["优丽型号"] == DBNull.Value ? "" : row["优丽型号"].ToString());
                ea.SetValue(string.Format( "D{0}",n), row["订单数量"] == DBNull.Value ? "" : row["订单数量"].ToString());
                ea.SetValue(string.Format( "F{0}",n), row["单位"] == DBNull.Value ? "" : row["单位"].ToString());
                ea.SetValue(string.Format("G{0}", n), row["箱数"] == DBNull.Value ? "" : row["箱数"].ToString());
                n++;

                intSortWeight = 0;
                #region 循环材料明细
                if (isExportDetail)
                {
                    DataRow[] subRows = null;
                    if (row["产品id"] != DBNull.Value)
                    {
                        subRows = dtDetailsSub.Select(string.Format("产品id={0}",StringTools.intParse(row["产品id"].ToString())));
                    }
                    else if (row["配件id"] != DBNull.Value)
                    {
                        subRows = dtDetailsSub.Select(string.Format("产品配件id={0}", StringTools.intParse(row["配件id"].ToString())));
                    }
                    else
                    {
                        subRows = dtDetailsSub.Select("产品配件id=0");
                    }
                    ea.SetValue(string.Format( "A{0}",n), "  材料明细：");
                    foreach (DataRow subRow in subRows)
                    {
                        ea.SetValue(string.Format("B{0}", n), subRow["报关类别"] == DBNull.Value ? "" : subRow["报关类别"].ToString());
                        if (subRow["总用量"] == DBNull.Value || subRow["总用量"].ToString() == "" || row["订单数量"] == DBNull.Value || StringTools.decimalParse(row["订单数量"].ToString()) == 0)
                        {
                            ea.SetValue(string.Format("E{0}",n), "");
                        }
                        else
                        {
                            ea.SetValue(string.Format("E{0}", n), (StringTools.decimalParse(subRow["总用量"].ToString()) / StringTools.decimalParse(row["订单数量"].ToString())).ToString("N5"));
                        }
                        ea.SetValue(string.Format("F{0}", n), subRow["单位"] == DBNull.Value ? "" : subRow["单位"].ToString());
                        ea.SetValue(string.Format("H{0}", n), subRow["总用量"] == DBNull.Value ? "" : StringTools.decimalParse(subRow["总用量"].ToString()).ToString("N3"));
                        intSortWeight += subRow["总用量"] == DBNull.Value ? 0 : StringTools.decimalParse(subRow["总用量"].ToString());
                        n++;
                    }
                    ea.SetValue(string.Format("B{0}", n), "    合计：");
                    ea.SetFont(string.Format("B{0}", n),new Font("楷体", 14, FontStyle.Bold));
                    if (this.myCheckBox1.Checked)
                    {
                        ea.SetValue(string.Format("C{0}", n), row["实际总重"] == DBNull.Value ? "" : row["实际总重"].ToString());
                        if (row["实际总重"] == DBNull.Value || row["订单数量"] == DBNull.Value)
                        {
                            ea.SetValue(string.Format("C{0}", n), "");
                        }
                        else
                        {
                            ea.SetValue(string.Format("D{0}", n), 
                                (StringTools.decimalParse(row["订单数量"].ToString()) * StringTools.decimalParse(row["实际总重"].ToString())).ToString("N3"));
                        }

                    }
                    if (intSortWeight == 0 || row["订单数量"] == DBNull.Value || StringTools.decimalParse(row["订单数量"].ToString()) == 0)
                    {
                        ea.SetValue(string.Format("E{0}", n), "");
                    }
                    else
                    {
                        ea.SetValue(string.Format("E{0}", n), (intSortWeight / StringTools.decimalParse(row["订单数量"].ToString())).ToString("N5"));
                    }
                    ea.SetValue(string.Format("F{0}", n), "KGS");
                    ea.SetValue(string.Format("H{0}", n), intSortWeight.ToString());
                    n++;
                }
                #endregion

            }
            #endregion

            #region 总单查询标题行
            ea.SetValue(string.Format("A{0}", n), "材料合计：");
            ea.SetFont(string.Format("A{0}", n), new Font("楷体", 14, FontStyle.Bold));
            ea.SetHorisontalAlignment(string.Format("A{0}", n), 4);
            ea.SetValue(string.Format("B{0}", n), "材料名称");
            ea.SetFont(string.Format("B{0}", n), new Font("楷体", 12, FontStyle.Bold));
            ea.SetValue(string.Format("D{0}", n), "总用量");
            ea.SetFont(string.Format("D{0}", n), new Font("楷体", 12, FontStyle.Bold));
            ea.SetHorisontalAlignment(string.Format("D{0}", n), 4);
            ea.SetValue(string.Format("E{0}", n), "单位");
            ea.SetFont(string.Format("E{0}", n), new Font("楷体", 12, FontStyle.Bold));
            n++;
            #endregion

            #region 总单查询明细循环
            dataAccess.Open();
            DataTable dt总单查询 = dataAccess.GetTable(string.Format("报关订单料件总单查询 {0}", dataGridViewHead.CurrentRow.Cells["订单id"].Value), null);
            dataAccess.Close();
            foreach (DataRow sumRow in dt总单查询.Rows)
            {
                ea.SetValue(string.Format("B{0}", n), sumRow["报关类别"] == DBNull.Value ? "" : sumRow["报关类别"].ToString());
                ea.SetValue(string.Format("D{0}", n), sumRow["总用量"] == DBNull.Value ? "" : StringTools.decimalParse(sumRow["总用量"].ToString()).ToString("N3"));
                ea.SetHorisontalAlignment(string.Format("D{0}", n), 4);
                ea.SetValue(string.Format("E{0}", n), sumRow["单位"] == DBNull.Value ? "" : sumRow["单位"].ToString());
                intTotalWeight += sumRow["总用量"] == DBNull.Value ? 0 : StringTools.decimalParse(sumRow["总用量"].ToString());
                n++;
            }
            #endregion

            ea.SetValue(string.Format("B{0}", n), "总计：");
            ea.SetFont(string.Format("B{0}", n), new Font("楷体", 12, FontStyle.Bold));
            ea.SetHorisontalAlignment(string.Format("B{0}", n), 4);
            ea.SetValue(string.Format("D{0}", n), intTotalWeight.ToString("N3"));
            ea.SetValue(string.Format("E{0}", n), "KGS");

            ea.Visible = true;
            ea.Dispose();
        }
        //打印订单
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("是否确定导出到Excel") == System.Windows.Forms.DialogResult.No) return;
            #region 打开EXCEL
            string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\Order.xls");
            string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\Order{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
            File.Copy(strSourceFile, strDestFile);
            File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
            string fn = strDestFile;
            ExcelTools ea = new ExcelTools();
            ea.SafeOpen(fn);
            ea.ActiveSheet(1); // 激活
            #endregion

            #region 赋值公司信息
            string locateValue = ConfigurationManager.AppSettings["LocateValue"].ToString();
            string strCompany = string.Format("SELECT KeyField, SecondField, Addr1, Addr2, Addr3, Addr4, Country, Tel1, Tel2, Tel3, Fax,email, Signing FROM tabCompany where KeyField='{0}'",locateValue);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtCompany = dataAccess.GetTable(strCompany, null);
            dataAccess.Close();
            DataRow rowCompany = dtCompany.Rows[0];
            ea.SetValue("Company", rowCompany["secondfield"] == DBNull.Value ? "" : rowCompany["secondfield"].ToString());
            //如果ADDR1为DBNULL.VALUE或“”，则“”，否则ADDR1，+（如果ADDR2为DBNULL.VALUE或者为“”，则“”，否则为“，+ADDR2”）
            string strAddr1 =  (rowCompany["Addr1"] == DBNull.Value || rowCompany["Addr1"].ToString() == "") ? "" : rowCompany["Addr1"].ToString();
            string strAddr2 = (rowCompany["Addr2"] == DBNull.Value || rowCompany["Addr2"].ToString() == "") ? "" : rowCompany["Addr2"].ToString();
            string strAddress1 =strAddr1.Length > 0 ? (strAddr1 + (strAddr2 == "" ? "" : ",") + strAddr2) : strAddr2;
            ea.SetValue("Address1", strAddress1);
            //如果ADDR3为DBNULL.VALUE或“”，则“”，否则ADDR3，+（如果ADDR4为DBNULL.VALUE或者为“”，则“”，否则为“，+ADDR4”）
            string strAddr3 = (rowCompany["Addr3"] == DBNull.Value || rowCompany["Addr3"].ToString() == "") ? "" : rowCompany["Addr3"].ToString();
            string strAddr4 = (rowCompany["Addr4"] == DBNull.Value || rowCompany["Addr4"].ToString() == "") ? "" : rowCompany["Addr4"].ToString();
            string strAddress2 = strAddr3.Length > 0 ? (strAddr3 + (strAddr4 == "" ? "" : ",") + strAddr4) : strAddr4;
            ea.SetValue("Address2", strAddress2);
            ea.SetValue("FAX", rowCompany["FAX"] == DBNull.Value ? "" : rowCompany["FAX"].ToString());
            ea.SetValue("TEL", rowCompany["TEL1"] == DBNull.Value ? "" : rowCompany["TEL1"].ToString());

            ea.SetValue("date", "Date:" + Convert.ToDateTime(dataGridViewHead.CurrentRow.Cells["出货日期"].Value).ToString("yyyy-MM-dd"));
            ea.SetValue("orderno", "OrderNo:" + (dataGridViewHead.CurrentRow.Cells["订单号码"].Value == DBNull.Value ? "" : dataGridViewHead.CurrentRow.Cells["订单号码"].Value));
            ea.SetValue("customer", "Customer:(" + (dataGridViewHead.CurrentRow.Cells["客户代码"].Value == DBNull.Value ? "" : dataGridViewHead.CurrentRow.Cells["客户代码"].Value) +
                (dataGridViewHead.CurrentRow.Cells["客户名称"].Value == DBNull.Value ? "" : dataGridViewHead.CurrentRow.Cells["客户名称"].Value) + ")");
            ea.SetValue("label45", Convert.ToDateTime(dataGridViewHead.CurrentRow.Cells["出货日期"].Value).ToString("yyyy-MM-dd"));
            #endregion

            #region 赋值明细
            int n = 24;
            DataTable dtDetails = (DataTable)this.dataGridViewDetails.DataSource;
            foreach(DataRow rowD in dtDetails.Rows)
            {
                ea.SetValue(string.Format("A{0}", n), rowD["客人型号"] == DBNull.Value ? "" : rowD["客人型号"].ToString());
                ea.SetValue(string.Format("C{0}", n), rowD["优丽型号"] == DBNull.Value ? "" : rowD["优丽型号"].ToString());
                ea.SetValue(string.Format("F{0}", n), rowD["颜色"] == DBNull.Value ? "" : rowD["颜色"].ToString());
                ea.SetValue(string.Format("G{0}", n), rowD["订单数量"] == DBNull.Value ? "" : StringTools.decimalParse(rowD["订单数量"].ToString()).ToString());
                ea.SetValue(string.Format("H{0}", n), rowD["单位"] == DBNull.Value ? "" : rowD["单位"].ToString());
                ea.SetBorderStyle(string.Format("A{0}:K{0}",n),1);
                n++;
            }

            string strSQL = string.Format("SELECT 单位 as packUnit, SUM(订单数量) AS UnitQuantity FROM 报关订单明细表 where 订单id = {0} GROUP BY 单位 ", dataGridViewHead.CurrentRow.Cells["订单id"].Value);
            dataAccess.Open();
            DataTable dtSUM = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            for(int iSum=0; iSum<dtSUM.Rows.Count;iSum++)
            {
                DataRow rowSUM = dtSUM.Rows[iSum];
                if(iSum == 0)
                {
                    ea.SetValue(string.Format("G{0}", n), "Total:" + StringTools.decimalParse(rowSUM["UnitQuantity"].ToString()).ToString("N2") + " " + rowSUM["packUnit"]);
                }
                else
                {
                    ea.SetValue(string.Format("G{0}", n), StringTools.decimalParse(rowSUM["UnitQuantity"].ToString()).ToString("N2") + " " + rowSUM["packUnit"]);
                }
                ea.SetMerge(string.Format("G{0}:H{0}",n));
                ea.SetHorisontalAlignment(string.Format("G{0}:H{0}", n),4);
                n++;
            }
            n++;
            n++;
            n++;

            ea.SetValue(string.Format("A{0}", n), "Accept&Confirmed");
            ea.SetValue(string.Format("F{0}", n), dtCompany.Rows[0]["secondfield"].ToString());

            n++;
            ea.SetValue(string.Format("A{0}", n), "________________");
            ea.SetValue(string.Format("F{0}", n), "________________");
            #endregion
            ea.Visible = true;
            ea.Dispose();
        }
        //删除订单
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg(string.Format("真的要删除订单【{0}】吗？", this.dataGridViewHead.CurrentRow.Cells["订单号码"].Value)) == System.Windows.Forms.DialogResult.No) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dataAccess.BeginTran();
            try
            {
                object id =this.dataGridViewHead.CurrentRow.Cells["订单id"].Value.ToString();
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine(string.Format("delete from 产品配件改样报关材料明细表  where 订单id ={0}", id));
                strBuilder.AppendLine(string.Format("delete from 产品配件改样报关材料表 where 订单id ={0}", id));
                strBuilder.AppendLine(string.Format("delete from 报关订单明细表 where 订单id={0}", id));
                strBuilder.AppendLine(string.Format("delete from 报关订单表 where 订单id={0}", id));
                dataAccess.CommitTran();
                dataAccess.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", btnDelete.Text, this.dataGridViewHead.CurrentRow.Cells["订单号码"].Value);
                this.dataGridViewHead.Rows.Remove(this.dataGridViewHead.CurrentRow);
                setTool1Enabled();
                SysMessage.InformationMsg(strSuccess);
            }
            catch (Exception ex)
            {
                dataAccess.RollbackTran();
                dataAccess.Close();
                string strError = string.Format("{0} 出现错误：错误信息：{1}", btnDelete.Text, ex.Message);
                SysMessage.ErrorMsg(strError);
            }
        }
        //数据检查
        private void btnCheckData_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewHead.CurrentRow == null) return;
            string strSQL = string.Format("SELECT 报关订单明细表.客人型号,报关订单明细表.优丽型号,报关订单明细表.颜色,产品配件改样报关材料明细表.料件id,产品配件改样报关材料明细表.商品编码,产品配件改样报关材料明细表.商品名称 from 产品配件改样报关材料明细表 RIGHT OUTER JOIN 报关订单明细表 ON ISNULL(产品配件改样报关材料明细表.配件id, 0) = ISNULL(报关订单明细表.配件id, 0) AND ISNULL(产品配件改样报关材料明细表.产品id, 0) = ISNULL(报关订单明细表.产品id, 0) AND 产品配件改样报关材料明细表.订单明细表id = 报关订单明细表.订单明细表id AND 产品配件改样报关材料明细表.订单id = 报关订单明细表.订单id where NOT (产品配件改样报关材料明细表.产品id IS NULL and 产品配件改样报关材料明细表.料件id IS NULL) and 产品配件改样报关材料明细表.料件id is null and 报关订单明细表.订单id={0}",this.dataGridViewHead.CurrentRow.Cells["订单id"].Value);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtTemp = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtTemp.Rows.Count > 0)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "数据异常";
                formSelect.dtData = dtTemp;
                formSelect.ShowDialog();
            }
            else
            {
                SysMessage.InformationMsg("数据完整");
            }
        }
        #endregion
    }
}
