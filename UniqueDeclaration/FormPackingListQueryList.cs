﻿using System;
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
    public partial class FormPackingListQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormPackingListQueryList()
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
        private void FormPackingListQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_Import.Visible = false;
            LoadDataSourceHead();
            InitGridDetails();
            InitGridHead();

        }

        public override void myDataGridViewHead_SelectionChanged(object sender, EventArgs e)
        {
            base.myDataGridViewHead_SelectionChanged(sender, e);
            if (bTriggerGridViewHead_SelectionChanged)
            {
                setTool1Enabled();
                LoadDataSourceDetails();
            }
        }

        #region 初始化GRID
        private void InitGridHead()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["订单id"].Visible = false;
            this.myDataGridViewHead.Columns["订单id"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["出口状态"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["出口状态"].Width = 78;
            this.myDataGridViewHead.Columns["出口状态"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["装箱单号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["装箱单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["订单号码"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["订单号码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["报关单号"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["报关单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["客户代码"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["客户代码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["客户名称"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["客户名称"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["出货日期"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["出货日期"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["录入日期"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["录入日期"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["备案号"].Visible=false;
            this.myDataGridViewHead.Columns["备案号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["用途"].Visible=false;
            this.myDataGridViewHead.Columns["用途"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["征免方式"].Visible=false;
            this.myDataGridViewHead.Columns["征免方式"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["产销国"].Visible=false;
            this.myDataGridViewHead.Columns["产销国"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["币制"].Visible=false;
            this.myDataGridViewHead.Columns["币制"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["申报地海关代码"].Visible=false;
            this.myDataGridViewHead.Columns["申报地海关代码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["进口岸代码"].Visible=false;
            this.myDataGridViewHead.Columns["进口岸代码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["代理单位代码"].Visible=false;
            this.myDataGridViewHead.Columns["代理单位代码"].ContextMenuStrip = this.myContextHead;
        }

        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["BM"].Visible = false;
            this.myDataGridViewDetails.Columns["BM"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["订单明细表id"].Visible = false;
            this.myDataGridViewDetails.Columns["订单明细表id"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["单价"].Visible = false;
            this.myDataGridViewDetails.Columns["单价"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["箱号"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["箱号"].Width = 55;
            this.myDataGridViewDetails.Columns["箱号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["客人型号"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["客人型号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["优丽型号"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["优丽型号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["订单号码"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["订单号码"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["手册编号"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["手册编号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["归并前成品序号"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["归并前成品序号"].Width = 120;
            this.myDataGridViewDetails.Columns["归并前成品序号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["内部版本号"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["内部版本号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["成品项号"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["成品项号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["成品名称及商编"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["成品名称及商编"].Width = 120;
            this.myDataGridViewDetails.Columns["成品名称及商编"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["成品规格型号"].DisplayIndex = 9;
            this.myDataGridViewDetails.Columns["成品规格型号"].Width = 120;
            this.myDataGridViewDetails.Columns["成品规格型号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["数量"].DisplayIndex = 10;
            this.myDataGridViewDetails.Columns["数量"].Width = 55;
            this.myDataGridViewDetails.Columns["数量"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["单位"].DisplayIndex = 11;
            this.myDataGridViewDetails.Columns["单位"].Width = 55;
            this.myDataGridViewDetails.Columns["单位"].ContextMenuStrip = this.myContextDetails;

        }
        #endregion

        #region 加载数据
        /// <summary>
        /// 加载表头数据
        /// </summary>
        private void LoadDataSourceHead()
        {
            try
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = "SELECT * from 装箱单表 " + (gstrWhere.Length > 0 ? " where " : "") + gstrWhere + " ORDER BY 录入日期 DESC";
                DataTable dtHead = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                bTriggerGridViewHead_SelectionChanged = false;
                this.myDataGridViewHead.DataSource = dtHead;
                DataTableTools.AddEmptyRow(dtHead);
                bTriggerGridViewHead_SelectionChanged = true;
                this.myDataGridViewHead_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【装箱单】数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        /// <summary>
        /// 加载订单内容数据
        /// </summary>
        private void LoadDataSourceDetails()
        {
            try
            {
                int iOrderID = 0;
                string strBooksNo = string.Empty;
                if (this.myDataGridViewHead.CurrentRow != null)
                {
                    if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRow.Index].Cells["订单id"].Value != DBNull.Value)
                    {
                        iOrderID = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRow.Index].Cells["订单id"].Value;
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = string.Format("exec 装箱单明细表录入查询 {0}", iOrderID);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtDetails);
                this.myDataGridViewDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【装箱单明细】出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        #endregion
        
        #region tools事件
        public override void tool1_First_Click(object sender, EventArgs e)
        {
            base.tool1_First_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells["装箱单号"];
            setTool1Enabled();
        }

        public override void tool1_up_Click(object sender, EventArgs e)
        {
            base.tool1_up_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells["装箱单号"];
            setTool1Enabled();

        }

        public override void tool1_Down_Click(object sender, EventArgs e)
        {
            base.tool1_Down_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells["装箱单号"];
            setTool1Enabled();
        }

        public override void tool1_End_Click(object sender, EventArgs e)
        {
            base.tool1_End_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells["装箱单号"];
            setTool1Enabled();
        }

        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            base.tool1_Add_Click(sender, e);
            //FormMaterialsOutInput objForm = new FormMaterialsOutInput();
            //objForm.MdiParent = this.MdiParent;
            //objForm.Show();
        }

        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            base.tool1_Modify_Click(sender, e);
            //bool bHave = false;
            //int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["料件出库表id"].Value);
            //string strBooksNo = this.myDataGridViewHead.CurrentRow.Cells["电子帐册号"].Value.ToString();
            //foreach (Form childFrm in this.MdiParent.MdiChildren)
            //{
            //    if (childFrm.Name == "FormMaterialsOutInput")
            //    {
            //        FormMaterialsOutInput inputForm = (FormMaterialsOutInput)childFrm;
            //        if (inputForm.giOrderID != 0 && inputForm.giOrderID == iOrderID)
            //        {
            //            bHave = true;
            //            childFrm.Activate();
            //            break;
            //        }
            //    }
            //}
            //if (!bHave)
            //{
            //    FormMaterialsOutInput objForm = new FormMaterialsOutInput();
            //    objForm.MdiParent = this.MdiParent;
            //    objForm.giOrderID = iOrderID;
            //    objForm.strBooksNo = strBooksNo;
            //    objForm.Show();
            //}
        }

        public override void tool1_Delete_Click(object sender, EventArgs e)
        {
            base.tool1_Delete_Click(sender, e);
            if (this.myDataGridViewHead.CurrentRow == null) return;
            string strText = string.Format("真的要删除订单 【{0}】 吗？", this.myDataGridViewHead.CurrentRow.Cells["订单号码"].Value);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.Cancel) return;
            try
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine(string.Format("delete from 装箱单明细表 where 订单id=", this.myDataGridViewHead.CurrentRow.Cells["订单id"].Value));
                strBuilder.AppendLine(string.Format("delete from 装箱单表 where 订单id=", this.myDataGridViewHead.CurrentRow.Cells["订单id"].Value));
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                dataAccess.ExecuteNonQuery(strBuilder.ToString(), null);
                dataAccess.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["订单号码"].Value);
                this.myDataGridViewHead.Rows.Remove(this.myDataGridViewHead.CurrentRow);
                setTool1Enabled();
                SysMessage.InformationMsg(strSuccess);
            }
            catch (Exception ex)
            {
                string strError = string.Format("{0} 出现错误：错误信息：{1}", tool1_Delete.Text, ex.Message);
                SysMessage.ErrorMsg(strError);
            }
        }

        public override void tool1_Query_Click(object sender, EventArgs e)
        {
            base.tool1_Query_Click(sender, e);
            FormPackingListQueryCondition queryConditionForm = new FormPackingListQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrWhere = queryConditionForm.strReturnWhere;
                LoadDataSourceHead();
            }
        }

        public override void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            base.tool1_ExportExcel_Click(sender, e);

            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;
            if (this.myDataGridViewHead.CurrentRow == null) return;

            string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\清单明细表.xls");
            string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\清单明细表{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
            File.Copy(strSourceFile, strDestFile);
            File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
            string fn = strDestFile;
            ExcelTools ea = new ExcelTools();
            ea.SafeOpen(fn);
            ea.ActiveSheet(1); // 激活
            ea.SetValue("A8", "INVOICE NO.:" + myDataGridViewHead.CurrentRow.Cells["装箱单号"].Value.ToString());
            ea.SetValue("C8", "CustNo：" + myDataGridViewHead.CurrentRow.Cells["客户代码"].Value.ToString());
            ea.SetValue("F8", "DATE：" + Convert.ToDateTime(myDataGridViewHead.CurrentRow.Cells["出货日期"].Value).ToString("yyyy-MM-dd"));

            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dtExcel = dataAccess.GetTable(string.Format("select * from 装箱单明细表 where 订单id={0}", myDataGridViewHead.CurrentRow.Cells["订单id"].Value), null);
            dataAccess.Close();
            ea.SetValue("E8", dtExcel.Rows.Count>0 ? dtExcel.Rows[0]["手册编号"].ToString() : "");
            int iExcelModelBeginIndex = 10;
            int iExcelModelEndIndex = 48;
            string 成品名称及商编 = string.Empty;
            int iIndex = 0;
            for (int iRow = 0; iRow < dtExcel.Rows.Count; iRow++)
            {
                DataRow row = dtExcel.Rows[iRow];
                iIndex = iExcelModelBeginIndex + iRow;
                if (iIndex > iExcelModelEndIndex - 1)
                    ea.InsertRows(iIndex);
                ea.SetValue(string.Format("A{0}", iIndex), row["箱号"] == DBNull.Value ? "" : row["箱号"].ToString());
                ea.SetValue(string.Format("B{0}", iIndex), row["客人型号"] == DBNull.Value ? "" : row["客人型号"].ToString());
                ea.SetValue(string.Format("C{0}", iIndex), row["归并前成品序号"] == DBNull.Value ? "" : row["归并前成品序号"].ToString());
                ea.SetValue(string.Format("D{0}", iIndex), row["成品项号"] == DBNull.Value ? "" : row["成品项号"].ToString());
                成品名称及商编 = row["成品名称及商编"] == DBNull.Value ? "" : row["成品名称及商编"].ToString().Trim();
                if (成品名称及商编.Length > 0)
                {
                    string[] arr = 成品名称及商编.Split('/');
                    if (arr.Length > 0)
                        成品名称及商编 = arr[0];
                }
                ea.SetValue(string.Format("E{0}", iIndex), 成品名称及商编);
                ea.SetValue(string.Format("F{0}", iIndex), row["成品规格型号"] == DBNull.Value ? "" : row["成品规格型号"].ToString());
                ea.SetValue(string.Format("G{0}", iIndex), row["数量"] == DBNull.Value ? "" : row["数量"].ToString());
                ea.SetValue(string.Format("H{0}", iIndex), row["单位"] == DBNull.Value ? "" : row["单位"].ToString());
            }
            //ea.Save(saveFileDialog.FileName);

            ea.Visible = true;
            ea.Dispose();

        }

        /// <summary>
        /// 设置tools的按钮是否可用
        /// </summary>
        private void setTool1Enabled()
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

        //出口料件统计
        private void btnOuterMaterialTotal_Click(object sender, EventArgs e)
        {
            FormOuterMaterialTotal objForm = new FormOuterMaterialTotal();
            objForm.mstrFilterString = string.Format(string.Format("@订单号码={0}{1}", this.myDataGridViewHead.CurrentRow.Cells["订单号码"].Value,(myCheckBox1.Checked == true ? ",@类别=1" : "")));
            objForm.Show();
        }
        //用料明细表
        private void btnMaterialDetails_Click(object sender, EventArgs e)
        {
            //10980702
            string idvalue = DateTime.Now.ToString("yyyyMMddhhmmss");
            DataTable dtDetails = (DataTable)this.myDataGridViewDetails.DataSource;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            string str订单号码=this.myDataGridViewHead.CurrentRow.Cells["订单号码"].Value.ToString();
            foreach (DataRow row in dtDetails.Rows)
            {
                if (row["订单明细表id"] == DBNull.Value) continue;
                dataAccess.ExecuteNonQuery(string.Format("装箱单料件明细 '{0}',{1},{2},{3},'{4}'", str订单号码, row["归并前成品序号"], row["成品项号"], row["数量"], idvalue), null);
            }
            dataAccess.Close();
            FormMaterialSheet objForm = new FormMaterialSheet();
            objForm.idvalue = idvalue;
            objForm.Show();
        }
    }
}
