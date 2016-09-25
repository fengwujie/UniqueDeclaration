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

namespace UniqueDeclaration
{
    public partial class FormMakeNoticeQueryList : UniqueDeclarationBaseForm.FormBaseQueryList
    {
        public FormMakeNoticeQueryList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否触发行变化事件
        /// </summary>
        private bool bTriggerGridViewHead_SelectionChanged = true;

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
                string strSQL = @"SELECT 报关制造通知单表.*,case when 进口料件出库表.制造通知单号 is null then '' else '已导' end as 导单 FROM 报关制造通知单表 
                                    left outer join 进口料件出库表 on 报关制造通知单表.制造通知单号=进口料件出库表.制造通知单号  " + 
                                    (gstrWhere.Length > 0 ? " where " : "") + gstrWhere + "ORDER BY 录入日期 DESC";
                DataTable dtHead = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                bTriggerGridViewHead_SelectionChanged = false;
                DataTableTools.AddEmptyRow(dtHead);
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
                SysMessage.ErrorMsg(string.Format("加载【制造通知单】数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
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
                string str手册编号=string.Empty;
                if (this.dataGridViewHead.CurrentRowNew.Index >= 0)
                {
                    if (this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRowNew.Index].Cells["制造通知单id"].Value != DBNull.Value)
                    {
                        iOrderID = (int)this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRowNew.Index].Cells["制造通知单id"].Value;
                        str手册编号 = this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRowNew.Index].Cells["手册编号"].Value.ToString();
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                //string strSQL = string.Format("select * from 报关预先订单明细表 where 订单id={0}", iOrderID);
                string strSQL = string.Format("exec 报关制造通知单录入查询 {0}", iOrderID);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtDetails);
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
        /// 加载归并后材料总用量表
        /// </summary>
        private void LoadDataSourceMergeAfterSumCount()
        {
            //bool bShow = false;
            //if (formBaseLoading == null)
            //{
            //    formBaseLoading = new FormBaseLoading();
            //    bShow = true;
            //    formBaseLoading.strLoadText = string.Format("加载【{0}】数据，请稍等。。。。。。", this.tabPage2.Text);
            //    formBaseLoading.Show();
            //    formBaseLoading.Refresh();
            //}
            try
            {
                int iOrderID = 0;
                string strBooksNo = string.Empty;
                if (this.dataGridViewHead.CurrentRowNew.Index >= 0)
                {
                    if (this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRowNew.Index].Cells["制造通知单id"].Value != DBNull.Value)
                    {
                        iOrderID = (int)this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRowNew.Index].Cells["制造通知单id"].Value;
                        strBooksNo = this.dataGridViewHead.CurrentRowNew.Cells["手册编号"].Value.ToString();
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("exec 制造通知单用量明细 {0},{1}", iOrderID, strBooksNo);
                DataTable dtMergeAfterSumCount = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtMergeAfterSumCount);
                this.dataGridViewMergeAfterSumCount.DataSource = dtMergeAfterSumCount;
                //this.dataGridViewMergeAfterSumCount.Columns["单耗"].Visible = false;
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
        /// <summary>
        /// 加载归并前材料总用量表
        /// </summary>
        private void LoadDataSourceMergeBeforeSumCount()
        {
            //bool bShow = false;
            //if (formBaseLoading == null)
            //{
            //    formBaseLoading = new FormBaseLoading();
            //    bShow = true;
            //    formBaseLoading.strLoadText = string.Format("加载【{0}】数据，请稍等。。。。。。", this.tabPage3.Text);
            //    formBaseLoading.Show();
            //    formBaseLoading.Refresh();
            //}
            try
            {
                int iOrderID = 0;
                string strBooksNo = string.Empty;
                if (this.dataGridViewHead.CurrentRowNew.Index >= 0)
                {
                    if (this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRowNew.Index].Cells["制造通知单id"].Value != DBNull.Value)
                    {
                        iOrderID = (int)this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRowNew.Index].Cells["制造通知单id"].Value;
                        strBooksNo = this.dataGridViewHead.CurrentRowNew.Cells["手册编号"].Value.ToString();
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("exec 制造通知单归并前用量明细 {0},{1}", iOrderID, strBooksNo);
                DataTable dtMergeBeforeSumCount = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtMergeBeforeSumCount);
                this.dataGridViewMergeBeforeSumCount.DataSource = dtMergeBeforeSumCount;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【{0}】数据出错，错误信息如下：{1}{2}", this.tabPage3.Text, Environment.NewLine, ex.Message));
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
        private void LoadDataSourceMergeBeforeDetailsSumCount()
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
                if (this.dataGridViewHead.CurrentRowNew.Index >= 0)
                {
                    if (this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRowNew.Index].Cells["制造通知单id"].Value != DBNull.Value)
                    {
                        iOrderID = (int)this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRowNew.Index].Cells["制造通知单id"].Value;
                        strBooksNo = this.dataGridViewHead.CurrentRowNew.Cells["手册编号"].Value.ToString();
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("exec 制造通知单归并前明细用量明细 {0},{1}", iOrderID, strBooksNo);
                DataTable dtMergeBeforeDetailsSumCount = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtMergeBeforeDetailsSumCount);
                this.dataGridViewMergeBeforeDetailsSumCount.DataSource = dtMergeBeforeDetailsSumCount;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【{0}】数据出错，错误信息如下：{1}{2}", this.tabPage4.Text, Environment.NewLine, ex.Message));
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

        #region Form事件及其他控件事件
        private void FormOrderQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_Import.Visible = true;
            this.dataGridViewHead.AutoGenerateColumns = false;
            this.dataGridViewDetails.AutoGenerateColumns = false;
            LoadDataSourceHead();
        }
        //明细页签变化事件
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
                        LoadDataSourceMergeAfterSumCount();
                        break;
                    case 2:
                        LoadDataSourceMergeBeforeSumCount();
                        break;
                    case 3:
                        LoadDataSourceMergeBeforeDetailsSumCount();
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
        #endregion

        #region tools事件
        public override void tool1_First_Click(object sender, EventArgs e)
        {
            base.tool1_First_Click(sender, e);
            this.dataGridViewHead.ClearSelection();
            this.dataGridViewHead.Rows[0].Selected = true;
            this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[0].Cells["导单"];
            setTool1Enabled();
        }

        public override void tool1_up_Click(object sender, EventArgs e)
        {
            base.tool1_up_Click(sender, e);
            int iSelectRow = this.dataGridViewHead.CurrentRow.Index;
            this.dataGridViewHead.ClearSelection();
            this.dataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[iSelectRow - 1].Cells["导单"];
            setTool1Enabled();

        }

        public override void tool1_Down_Click(object sender, EventArgs e)
        {
            base.tool1_Down_Click(sender, e);
            int iSelectRow = this.dataGridViewHead.CurrentRow.Index;
            this.dataGridViewHead.ClearSelection();
            this.dataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[iSelectRow + 1].Cells["导单"];
            setTool1Enabled();
        }

        public override void tool1_End_Click(object sender, EventArgs e)
        {
            base.tool1_End_Click(sender, e);
            this.dataGridViewHead.ClearSelection();
            this.dataGridViewHead.Rows[this.dataGridViewHead.RowCount - 1].Selected = true;
            this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[this.dataGridViewHead.RowCount - 1].Cells["导单"];
            setTool1Enabled();
        }

        public override void tool1_Import_Click(object sender, EventArgs e)
        {
            base.tool1_Import_Click(sender, e);
            if (this.dataGridViewDetails.CurrentRow == null) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            try
            {
                DataTable dtDetails = (DataTable)this.dataGridViewDetails.DataSource;
                long Pid, Fid, OrderID, OrderListID;
                StringBuilder strBuilder = new StringBuilder();
                DataTable dtTemp = null;
                OrderID = this.dataGridViewHead.CurrentRow.Cells["制造通知单id"].Value == DBNull.Value ? 0 : Convert.ToInt64(this.dataGridViewHead.CurrentRow.Cells["制造通知单id"].Value);
                foreach (DataRow rowD in dtDetails.Rows)
                {
                    strBuilder.Clear();
                    Pid = rowD["产品id"] == DBNull.Value ? 0 : Convert.ToInt64(rowD["产品id"]);
                    Fid = rowD["配件id"] == DBNull.Value ? 0 : Convert.ToInt64(rowD["配件id"]);
                    OrderListID = rowD["制造通知单明细表id"] == DBNull.Value ? 0 : Convert.ToInt64(rowD["制造通知单明细表id"]);
                    if (Fid == 0)
                    {
                        strBuilder.AppendLine(string.Format("delete from 产品配件改样报关前材料明细表  where 制造通知单id ={0} and 制造通知单明细表id ={1} and 产品id ={2}", OrderID, OrderListID, Pid));
                        strBuilder.AppendLine(string.Format("delete from 产品配件改样报关前材料表 where 制造通知单id ={0} and 制造通知单明细表id ={1} and 产品id ={2}", OrderID, OrderListID, Pid));
                    }
                    else
                    {
                        strBuilder.AppendLine(string.Format("delete from 产品配件改样报关前材料明细表  where 制造通知单id ={0} and 制造通知单明细表id ={1} and 配件id ={2}", OrderID, OrderListID, Fid));
                        strBuilder.AppendLine(string.Format("delete from 产品配件改样报关前材料表 where 制造通知单id ={0} and 制造通知单明细表id ={1} and 配件id ={2}", OrderID, OrderListID, Fid));
                    }
                    dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                    if (rowD["订单id"] != DBNull.Value)
                    {
                        strBuilder.Clear();
                        if (Pid != 0)
                        {
                            strBuilder.AppendLine(string.Format("select 订单id,订单明细表id,产品id from 报关预先订单明细表 WHERE 订单id={0} and 产品id={1}", rowD["订单id"], Pid));
                            dtTemp = dataAccess.GetTable(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            if (dtTemp.Rows.Count > 0)
                            {
                                strBuilder.AppendLine(string.Format(@"INSERT INTO 产品配件改样报关前材料明细表(制造通知单id,制造通知单明细表id,产品id,配件id,料件id,型号,显示型号,品名,
                                                                                项号,编号,商品编码,商品名称,规格型号,计量单位,数量,单位,单耗,单耗单位,损耗率,换算率) 
                                                                        SELECT {0},{1},产品id,配件id,料件id,型号,显示型号,品名,项号,编号,商品编码,商品名称,规格型号,
                                                                                计量单位,数量,单位,单耗,单耗单位,损耗率,换算率 From 产品配件改样报关订单材料明细表 
                                                                            WHERE 订单id={2} and 订单明细表id={3} and 产品id={4}",
                                                                    OrderID, OrderListID, dtTemp.Rows[0]["订单id"], dtTemp.Rows[0]["订单明细表id"], dtTemp.Rows[0]["产品id"]));
                                strBuilder.AppendLine(string.Format(@"INSERT INTO 产品配件改样报关前材料表(制造通知单id,制造通知单明细表id,产品id,配件id,料件id,序号,编号,商品编码,
                                                                                商品名称,规格型号,计量单位,数量,单位,备注,损耗率,区域) 
                                                                        SELECT {0},{1},产品id,配件id,料件id,序号,编号,商品编码,商品名称,规格型号,计量单位,数量,单位,备注,损耗率,区域 
                                                                                From 产品配件改样报关订单材料表 WHERE 订单id={2} and 订单明细表id={3} and 产品id={4}",
                                                                    OrderID, OrderListID, dtTemp.Rows[0]["订单id"], dtTemp.Rows[0]["订单明细表id"], dtTemp.Rows[0]["产品id"]));
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                            }
                        }
                        else
                        {
                            strBuilder.AppendLine(string.Format("select 订单id,订单明细表id,配件id from 报关预先订单明细表 WHERE 订单id={0} and 配件id={1}", rowD["订单id"], Fid));
                            dtTemp = dataAccess.GetTable(strBuilder.ToString(), null);
                            strBuilder.Clear();
                            if (dtTemp.Rows.Count > 0)
                            {
                                strBuilder.AppendLine(string.Format(@"INSERT INTO 产品配件改样报关前材料明细表(制造通知单id,制造通知单明细表id,产品id,配件id,料件id,型号,显示型号,
                                                                                品名,项号,编号,商品编码,商品名称,规格型号,计量单位,数量,单位,单耗,单耗单位,损耗率,换算率) 
                                                                        SELECT {0},{1},产品id,配件id,料件id,型号,显示型号,品名,项号,编号,商品编码,商品名称,规格型号,计量单位,
                                                                                    数量,单位,单耗,单耗单位,损耗率,换算率 From 产品配件改样报关订单材料明细表 
                                                                                WHERE 订单id={2} and 订单明细表id={3} and 配件id={4}",
                                                                    OrderID, OrderListID, dtTemp.Rows[0]["订单id"], dtTemp.Rows[0]["订单明细表id"], dtTemp.Rows[0]["配件id"]));
                                strBuilder.AppendLine(string.Format(@"INSERT INTO 产品配件改样报关前材料表(制造通知单id,制造通知单明细表id,产品id,配件id,料件id,序号,编号,商品编码,
                                                                                商品名称,规格型号,计量单位,数量,单位,备注,损耗率,区域) 
                                                                        SELECT {0},{1},产品id,配件id,料件id,序号,编号,商品编码,商品名称,规格型号,计量单位,数量,单位,备注,损耗率,区域 
                                                                                From 产品配件改样报关订单材料表 WHERE 订单id={2} and 订单明细表id={3} and 配件id={4}",
                                                                    OrderID, OrderListID, dtTemp.Rows[0]["订单id"], dtTemp.Rows[0]["订单明细表id"], dtTemp.Rows[0]["配件id"]));
                                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                            }
                        }
                    }
                }
                dataAccess.Close();
                dataGridViewHead_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(ex.Message);
                dataAccess.Close();
            }
        }

        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            base.tool1_Modify_Click(sender, e);
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.dataGridViewHead.CurrentRow.Cells["制造通知单id"].Value);
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormMakeNoticeInput")
                {
                    FormMakeNoticeInput inputForm = (FormMakeNoticeInput)childFrm;
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
                FormMakeNoticeInput objForm = new FormMakeNoticeInput();
                objForm.MdiParent = this.MdiParent;
                objForm.giOrderID = iOrderID;
                objForm.Show();
            }
        }

        public override void tool1_Delete_Click(object sender, EventArgs e)
        {
            base.tool1_Delete_Click(sender, e);
            if (this.dataGridViewHead.CurrentRow == null) return;
            int iOrderID = Convert.ToInt32(this.dataGridViewHead.CurrentRow.Cells["制造通知单id"].Value);
            IDataAccess data = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            data.Open();
            DataTable dtList = data.GetTable(string.Format("select * from 产品配件改样报关前材料明细表 where 制造通知单id ={0}", iOrderID), null);
            data.Close();
            if (dtList.Rows.Count > 0)
            {
                SysMessage.InformationMsg("已存在材料明细，此制造通知单不能删除！");
                return;
            }
            data.Open();
            dtList = data.GetTable(string.Format("select * from 产品配件改样报关前材料表 where 制造通知单id  ={0}", iOrderID), null);
            data.Close();
            if (dtList.Rows.Count > 0)
            {
                SysMessage.InformationMsg("已存在材料明细，此制造通知单不能删除！");
                return;
            }
            string strMakeNoticeNo = this.dataGridViewHead.CurrentRow.Cells["制造通知单号"].Value.ToString();
            string strText = string.Format("真的要删除制造通知单 【{0}】 吗？", strMakeNoticeNo);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.No) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            try
            {
                dataAccess.Open();
                dataAccess.BeginTran();
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine(string.Format("delete from 产品配件改样报关前材料明细表  where 制造通知单id ={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 产品配件改样报关前材料表 where 制造通知单id ={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 报关制造通知单明细表 where 制造通知单id={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 报关制造通知单表 where 制造通知单id={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 报关订单明细表 where 制造通知单id={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 进口料件出库明细表 where 料件出库表id in (select distinct 料件出库表id from 进口料件出库表 where 制造通知单号={0})", StringTools.SqlQ(strMakeNoticeNo)));
                strBuilder.AppendLine(string.Format("delete from 进口料件出库表 where 制造通知单号={0}", StringTools.SqlQ(strMakeNoticeNo)));
                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                dataAccess.CommitTran();
                dataAccess.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.dataGridViewHead.CurrentRow.Cells["制造通知单号"].Value);
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

        public override void tool1_BOM_Click(object sender, EventArgs e)
        {
            base.tool1_BOM_Click(sender, e);
            if (this.dataGridViewDetails.RowCount == 0) return;
            if (this.dataGridViewHead.CurrentRow.Cells["手册编号"].Value.ToString() == "")
            {
                SysMessage.InformationMsg("请输入电子帐册号！");
                return;
            }
            #region 判断是否已经有打开的BOM窗体
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormMakeNoticeBOM")
                {
                    FormMakeNoticeBOM orderBomForm = (FormMakeNoticeBOM)childFrm;
                    if (orderBomForm.OrderId == Convert.ToInt32(this.dataGridViewHead.CurrentRow.Cells["制造通知单id"].Value)
                        && orderBomForm.OrderListId == Convert.ToInt32(this.dataGridViewDetails.CurrentRow.Cells["制造通知单明细表id"].Value))
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
            int iMakeNoticeID = Convert.ToInt32(this.dataGridViewHead.CurrentRow.Cells["制造通知单id"].Value);
            string strSQL = string.Format("delete from 产品配件改样报关前材料明细表  where 制造通知单id ={0} and 制造通知单明细表id not in (select 制造通知单明细表id from 报关制造通知单明细表 where 制造通知单id ={0})", iMakeNoticeID);
            dataAccess.ExecuteNonQuery(strSQL, null);
            strSQL = string.Format("delete from 产品配件改样报关前材料表 where 制造通知单id ={0} and 制造通知单明细表id not in (select 制造通知单明细表id from 报关制造通知单明细表 where 制造通知单id ={0})", iMakeNoticeID);
            dataAccess.ExecuteNonQuery(strSQL, null);
            dataAccess.Close();
            int iMakeNoticeDetailID = Convert.ToInt32(this.dataGridViewDetails.CurrentRow.Cells["制造通知单明细表id"].Value);
            if (this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value == DBNull.Value || Convert.ToInt32(this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value) == 0)
            {
                dataAccess.Open();
                strSQL = string.Format("delete from 产品配件改样报关前材料明细表 where 配件id is not null and 制造通知单id ={0} and 制造通知单明细表id ={1} and 配件id<> {2}", iMakeNoticeID, iMakeNoticeDetailID, this.dataGridViewDetails.CurrentRow.Cells["配件id"].Value);
                dataAccess.ExecuteNonQuery(strSQL, null);
                strSQL = string.Format("delete from 产品配件改样报关前材料表 where 配件id is not null and 制造通知单id ={0} and 制造通知单明细表id ={1} and 配件id<>{2}", iMakeNoticeID, iMakeNoticeDetailID, this.dataGridViewDetails.CurrentRow.Cells["配件id"].Value);
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
            }
            else
            {
                dataAccess.Open();
                strSQL = string.Format("delete from 产品配件改样报关前材料明细表 where 配件id is not null and 制造通知单id ={0} and 制造通知单明细表id ={1} and 产品id<> {2}", iMakeNoticeID, iMakeNoticeDetailID, this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value);
                dataAccess.ExecuteNonQuery(strSQL, null);
                strSQL = string.Format("delete from 产品配件改样报关前材料表 where 配件id is not null and 制造通知单id ={0} and 制造通知单明细表id ={1} and 产品id<>{2}", iMakeNoticeID, iMakeNoticeDetailID, this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value);
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
            }
            #endregion

            FormMakeNoticeBOM formBOM = new FormMakeNoticeBOM();
            formBOM.Pid = this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value == DBNull.Value ? 0 : Convert.ToInt32(this.dataGridViewDetails.CurrentRow.Cells["产品id"].Value);
            formBOM.Fid = this.dataGridViewDetails.CurrentRow.Cells["配件id"].Value == DBNull.Value ? 0 : Convert.ToInt32(this.dataGridViewDetails.CurrentRow.Cells["配件id"].Value);
            formBOM.OrderId = iMakeNoticeID;
            formBOM.OrderListId = iMakeNoticeDetailID;
            formBOM.ManualCode = this.dataGridViewHead.CurrentRow.Cells["手册编号"].Value.ToString();
            formBOM.mstrName = this.dataGridViewDetails.CurrentRow.Cells["型号"].Value.ToString();
            formBOM.ProductCode = this.dataGridViewDetails.CurrentRow.Cells["成品项号"].Value.ToString();
            formBOM.AllWeight = (this.dataGridViewDetails.CurrentRow.Cells["实际总重"].Value == null || this.dataGridViewDetails.CurrentRow.Cells["实际总重"].Value == DBNull.Value) ? 0 : float.Parse(this.dataGridViewDetails.CurrentRow.Cells["实际总重"].Value.ToString());
            formBOM.FactWeight = this.dataGridViewDetails.CurrentRow.Cells["总重"].Value == DBNull.Value ? 0 : float.Parse(this.dataGridViewDetails.CurrentRow.Cells["总重"].Value.ToString());
            formBOM.Unitname = this.dataGridViewDetails.CurrentRow.Cells["申报单位"].Value.ToString();
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

        public override void tool1_Query_Click(object sender, EventArgs e)
        {
            base.tool1_Query_Click(sender, e);
            FormMakeNoticeQueryCondition queryConditionForm = new FormMakeNoticeQueryCondition();
            //queryConditionForm.MdiParent = this;
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrWhere = queryConditionForm.strReturnWhere;
                LoadDataSourceHead();
            }
        }

        public override void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            base.tool1_ExportExcel_Click(sender, e);

            //// 保存对话框
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            //saveFileDialog.FilterIndex = 0;
            //saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.CreatePrompt = false;
            //saveFileDialog.Title = "保存为Excel文件";
            ////导出的文件名默认为：“订单明细” +客户编码+ [“_” +订单号]（只有多订单的订货类别使用）
            ////    + “[”+日期(年月日时分秒,如：20141021163144)+“]”，
            //// 例如成都人为备量仓导出的Excel文件应为：订单明细201099[20141021163144].xls
            //saveFileDialog.FileName = string.Format("制造通知单【{0}】", dataGridViewHead.CurrentRow.Cells["制造通知单号"].Value.ToString());
            //if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\制造单清单明细表.xls");
            string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\制造单清单明细表{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
            File.Copy(strSourceFile, strDestFile);
            File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
            string fn = strDestFile;

            //string fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\制造单清单明细表.xls");
            ExcelTools ea = new ExcelTools();
            ea.SafeOpen(fn);
            ea.ActiveSheet(1); // 激活
            ea.SetValue("A8", "制造通知单号:" + dataGridViewHead.CurrentRow.Cells["制造通知单号"].Value.ToString());
            ea.SetValue("D8", "CustNo：" + dataGridViewHead.CurrentRow.Cells["客户代码"].Value.ToString());
            ea.SetValue("F8", "DATE：" + Convert.ToDateTime(dataGridViewHead.CurrentRow.Cells["出货日期"].Value).ToString("yyyy-MM-dd"));

            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtExcel = dataAccess.GetTable(string.Format("select * from 报关制造通知单明细表 where 制造通知单id={0}", dataGridViewHead.CurrentRow.Cells["制造通知单id"].Value), null);
            dataAccess.Close();
            int iExcelModelBeginIndex = 10;
            int iExcelModelEndIndex = 30;
            string 成品名称及商编 = string.Empty;
            int iIndex = 0;
            for (int iRow = 0; iRow < dtExcel.Rows.Count; iRow++)
            {
                DataRow row = dtExcel.Rows[iRow];
                iIndex = iExcelModelBeginIndex + iRow;
                if (iIndex > iExcelModelEndIndex - 1)
                    ea.InsertRows(iIndex);
                ea.SetValue(string.Format("A{0}", iIndex), row["客人型号"] == DBNull.Value ? "" : row["客人型号"].ToString());
                ea.SetValue(string.Format("B{0}", iIndex), row["优丽型号"] == DBNull.Value ? "" : row["优丽型号"].ToString());
                ea.SetValue(string.Format("C{0}", iIndex), row["成品项号"] == DBNull.Value ? "" : row["成品项号"].ToString());
                成品名称及商编 = row["成品名称及商编"] == DBNull.Value ? "" : row["成品名称及商编"].ToString().Trim();
                if (成品名称及商编.Length > 0)
                {
                    string[] arr = 成品名称及商编.Split('/');
                    if (arr.Length > 0)
                        成品名称及商编 = arr[0];
                }
                ea.SetValue(string.Format("D{0}", iIndex), 成品名称及商编);
                ea.SetValue(string.Format("E{0}", iIndex), row["成品规格型号"] == DBNull.Value ? "" : row["成品规格型号"].ToString());
                ea.SetValue(string.Format("F{0}", iIndex), row["订单数量"] == DBNull.Value ? "" : row["订单数量"].ToString());
                ea.SetValue(string.Format("G{0}", iIndex), row["单位"] == DBNull.Value ? "" : row["单位"].ToString());
            }
            //ea.Save(saveFileDialog.FileName);

            ea.Visible = true;
            ea.Dispose();

        }

        public override void tool1_Print_Click(object sender, EventArgs e)
        {
            base.tool1_Print_Click(sender, e);
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


        #region Button事件
        public override void btnDelete_Click(object sender, EventArgs e)
        {
            base.btnDelete_Click(sender, e);
            if (this.dataGridViewHead.CurrentRow == null) return;
            string strText = string.Format("真的要删除此制造通知单，此删除将不可恢复，将删除所有与此单关联的所有数据 【{0}】 吗？", this.dataGridViewHead.CurrentRow.Cells["制造通知单号"].Value);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.Cancel) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            try
            {
                dataAccess.Open();
                dataAccess.BeginTran();
                StringBuilder strBuilder = new StringBuilder();
                int iOrderID = Convert.ToInt32(this.dataGridViewHead.CurrentRow.Cells["制造通知单id"].Value);
                string strMakeNoticeNo = this.dataGridViewHead.CurrentRow.Cells["制造通知单号"].Value.ToString();
                strBuilder.AppendLine(string.Format("delete from 产品配件改样报关前材料明细表  where 制造通知单id ={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 产品配件改样报关前材料表 where 制造通知单id ={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 报关制造通知单明细表 where 制造通知单id={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 报关制造通知单表 where 制造通知单id={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 报关订单明细表 where 制造通知单id={0}", iOrderID));
                strBuilder.AppendLine(string.Format("delete from 进口料件出库明细表 where 料件出库表id in (select distinct 料件出库表id from 进口料件出库表 where 制造通知单号={0})", StringTools.SqlQ(strMakeNoticeNo)));
                strBuilder.AppendLine(string.Format("delete from 进口料件出库表 where 制造通知单号={0}", StringTools.SqlQ(strMakeNoticeNo)));
                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                dataAccess.CommitTran();
                dataAccess.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", btnExportDetails.Text, this.dataGridViewHead.CurrentRow.Cells["制造通知单号"].Value);
                this.dataGridViewHead.Rows.Remove(this.dataGridViewHead.CurrentRow);
                setTool1Enabled();
                SysMessage.InformationMsg(strSuccess);
            }
            catch (Exception ex)
            {
                dataAccess.RollbackTran();
                dataAccess.Close();
                string strError = string.Format("{0} 出现错误：错误信息：{1}", btnExportDetails.Text, ex.Message);
                SysMessage.ErrorMsg(strError);
            }
        }

        public override void btnExportExcel_Click(object sender, EventArgs e)
        {
            base.btnExportExcel_Click(sender, e);

            if (this.dataGridViewHead.CurrentRow == null) return;

            //// 保存对话框
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            //saveFileDialog.FilterIndex = 0;
            //saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.CreatePrompt = false;
            //saveFileDialog.Title = "保存为Excel文件";
            ////导出的文件名默认为：“订单明细” +客户编码+ [“_” +订单号]（只有多订单的订货类别使用）
            ////    + “[”+日期(年月日时分秒,如：20141021163144)+“]”，
            //// 例如成都人为备量仓导出的Excel文件应为：订单明细201099[20141021163144].xls
            //saveFileDialog.FileName = "报关材料明细表";
            //if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\报关材料明细表.xls");
            string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\报关材料明细表{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
            File.Copy(strSourceFile, strDestFile);
            File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
            string fn = strDestFile;

            bool isExportDetails = false;
            if (SysMessage.YesNoMsg("是否导出单耗明细") == System.Windows.Forms.DialogResult.Yes)
            {
                isExportDetails = true;
            }
            //string fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\报关材料明细表.xls");
            ExcelTools ea = new ExcelTools();
            ea.SafeOpen(fn);
            ea.ActiveSheet(1); // 激活
            ea.SetValue("A2", "制造通知单号:" + dataGridViewHead.CurrentRow.Cells["制造通知单号"].Value.ToString());
            ea.SetValue("C2", "客户代码：" + dataGridViewHead.CurrentRow.Cells["客户代码"].Value.ToString());
            ea.SetValue("F2", "客户名称：" + dataGridViewHead.CurrentRow.Cells["客户名称"].Value.ToString());
            ea.SetValue("A3", "出货日期：" + Convert.ToDateTime(dataGridViewHead.CurrentRow.Cells["出货日期"].Value).ToString("yyyy-MM-dd"));
            ea.SetValue("C3", "录入日期：" + Convert.ToDateTime(dataGridViewHead.CurrentRow.Cells["录入日期"].Value).ToString("yyyy-MM-dd"));

            //int iExcelModelBeginIndex = 5;
            //int iExcelModelEndIndex = 30;
            string 成品名称及商编 = string.Empty;
            int iIndex = 5;
            DataTable dtExcel = (DataTable)dataGridViewDetails.DataSource;
            foreach (DataRow row in dtExcel.Rows)
            {
                //iIndex = iExcelModelBeginIndex + iRow;
                //if (iIndex > iExcelModelEndIndex - 1)
                //    ea.InsertRows(iIndex);
                ea.SetValue(string.Format("A{0}", iIndex), row["客人型号"] == DBNull.Value ? "" : row["客人型号"].ToString());
                ea.SetValue(string.Format("B{0}", iIndex), row["优丽型号"] == DBNull.Value ? "" : row["优丽型号"].ToString());
                ea.SetValue(string.Format("G{0}", iIndex), row["订单数量"] == DBNull.Value ? "" : (row["订单数量"].ToString() + " "));
                ea.SetValue(string.Format("H{0}", iIndex), row["单位"] == DBNull.Value ? "" : row["单位"].ToString());
                iIndex++;

                if (isExportDetails)
                {
                    IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    dataAccess.Open();
                    DataTable dtExcelDetails = dataAccess.GetTable(string.Format("报关制造通知单单耗 @制造通知单id={0},@制造通知单明细表id={1}", 
                        dataGridViewHead.CurrentRow.Cells["制造通知单id"].Value, row["制造通知单明细表id"]), null);
                    dataAccess.Close();
                    ea.SetValue(string.Format("A{0}", iIndex), "材料明细：");
                    iIndex++;
                    foreach (DataRow rowD in dtExcelDetails.Rows)
                    {
                        ea.SetValue(string.Format("A{0}", iIndex), rowD["料号"] == DBNull.Value ? "" : rowD["料号"].ToString());
                        ea.SetValue(string.Format("B{0}", iIndex), rowD["料件名"] == DBNull.Value ? "" : rowD["料件名"].ToString());
                        ea.SetValue(string.Format("C{0}", iIndex), rowD["商品名称"] == DBNull.Value ? "" : rowD["商品名称"].ToString());
                        decimal d用量 = StringTools.decimalParse(rowD["用量"] == DBNull.Value ? "" : rowD["用量"].ToString());
                        string str用量 = d用量.ToString("F5");
                        string str用量单位 = rowD["用量单位"] == DBNull.Value ? "" : rowD["用量单位"].ToString();
                        ea.SetValue(string.Format("D{0}", iIndex), str用量 + str用量单位);
                        decimal d订单数量 = StringTools.decimalParse(row["订单数量"] == DBNull.Value ? "" : row["订单数量"].ToString());
                        ea.SetValue(string.Format("E{0}", iIndex), (d用量 * d订单数量).ToString("F5") + str用量单位);
                        decimal d单耗 = StringTools.decimalParse(rowD["单耗"] == DBNull.Value ? "" : Convert.ToDecimal(rowD["单耗"]).ToString("F5"));
                        ea.SetValue(string.Format("F{0}", iIndex), d单耗.ToString());
                        ea.SetValue(string.Format("G{0}", iIndex), (d单耗 * d订单数量).ToString("F5"));
                        ea.SetValue(string.Format("H{0}", iIndex), rowD["单位"] == DBNull.Value ? "" : rowD["单位"].ToString());

                        iIndex++;
                    }
                }

                //单元格底部增加一条粗线




                if (isExportDetails) iIndex++;
            }
            //ea.Save(saveFileDialog.FileName);

            ea.Visible = true;
            ea.Dispose();
        }

        public override void btnExportDetails_Click(object sender, EventArgs e)
        {
            base.btnExportDetails_Click(sender, e);
            if (this.dataGridViewHead.CurrentRow == null) return;
            if (this.tabControl1.SelectedIndex == 0) return;
            try
            {
                string strSQL = string.Empty;
                string strExcelTitle = string.Empty;
                int iOrderID = (int)this.dataGridViewHead.Rows[this.dataGridViewHead.CurrentRow.Index].Cells["制造通知单id"].Value;
                string strBooksNo = this.dataGridViewHead.CurrentRow.Cells["手册编号"].Value.ToString();
                switch (this.tabControl1.SelectedIndex)
                {
                    case 1:
                        strSQL = string.Format("exec 制造通知单用量明细 {0},{1}", iOrderID, strBooksNo);
                        strExcelTitle = "归并后材料总单";
                        break;
                    case 2:
                        strSQL = string.Format("exec 制造通知单归并前用量明细 {0},{1}", iOrderID, strBooksNo);
                        strExcelTitle = "归并前材料总单";
                        break;
                    case 3:
                        strSQL = string.Format("exec 制造通知单归并前明细用量明细 {0},{1}", iOrderID, strBooksNo);
                        strExcelTitle = "归并前材料明细总单";
                        break;
                }

                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                DataTable dtExcel = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                ExcelCommonMethod.ExportIntoExcel(dtExcel, strExcelTitle);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("【{0}】出错，错误信息如下：{1}{2}", btnExportDetails.Text, Environment.NewLine, ex.Message));
            }
        }
        #endregion
    }
}
