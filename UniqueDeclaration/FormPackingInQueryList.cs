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
    public partial class FormPackingInQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormPackingInQueryList()
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
        private void FormPackingQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_Import.Visible = false;
            LoadDataSourceHead();
            InitGridDetails();
            InitGridHead();
        }

        private void InitGridHead()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["Pid"].Visible = false;
            this.myDataGridViewHead.Columns["Pid"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["custid"].Visible = false;
            this.myDataGridViewHead.Columns["custid"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["comid"].Visible = false;
            this.myDataGridViewHead.Columns["comid"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Priceterm"].Visible = false;
            this.myDataGridViewHead.Columns["Priceterm"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["InvoiceNo"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["InvoiceNo"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["ImportDate"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["ImportDate"].HeaderText = "进口日期";
            this.myDataGridViewHead.Columns["ImportDate"].Width = 78;
            this.myDataGridViewHead.Columns["ImportDate"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["报关单号"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["报关单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Messrs"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["Messrs"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Messrs"].Width = 230;
            this.myDataGridViewHead.Columns["cust"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["cust"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["per"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["per"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["sailingabout"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["sailingabout"].HeaderText = "sailing On or about";
            this.myDataGridViewHead.Columns["sailingabout"].Width = 150;
            this.myDataGridViewHead.Columns["sailingabout"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["PackingFrom"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["PackingFrom"].HeaderText = "From";
            this.myDataGridViewHead.Columns["PackingFrom"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["PackingTo"].DisplayIndex = 8;
            this.myDataGridViewHead.Columns["PackingTo"].HeaderText = "To";
            this.myDataGridViewHead.Columns["PackingTo"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["TranshipmentAt"].DisplayIndex = 9;
            this.myDataGridViewHead.Columns["TranshipmentAt"].HeaderText = "With Transhipment At";
            this.myDataGridViewHead.Columns["TranshipmentAt"].Width = 150;
            this.myDataGridViewHead.Columns["TranshipmentAt"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["InputDate"].DisplayIndex = 10;
            this.myDataGridViewHead.Columns["InputDate"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["InputUser"].DisplayIndex = 11;
            this.myDataGridViewHead.Columns["InputUser"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Remark"].DisplayIndex = 12;
            this.myDataGridViewHead.Columns["Remark"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark1"].DisplayIndex = 13;
            this.myDataGridViewHead.Columns["Mark1"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark2"].DisplayIndex = 14;
            this.myDataGridViewHead.Columns["Mark2"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark3"].DisplayIndex = 15;
            this.myDataGridViewHead.Columns["Mark3"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark4"].DisplayIndex = 16;
            this.myDataGridViewHead.Columns["Mark4"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark5"].DisplayIndex = 17;
            this.myDataGridViewHead.Columns["Mark5"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark6"].DisplayIndex = 18;
            this.myDataGridViewHead.Columns["Mark6"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["Mark7"].DisplayIndex = 18;
            this.myDataGridViewHead.Columns["Mark7"].ContextMenuStrip = this.myContextHead;
        }

        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["BM"].Visible = false;
            this.myDataGridViewDetails.Columns["BM"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["id"].Visible = false;
            this.myDataGridViewDetails.Columns["id"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["进口料件id"].Visible = false;
            this.myDataGridViewDetails.Columns["进口料件id"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["Unit1"].Visible = false;
            this.myDataGridViewDetails.Columns["Unit1"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["Unit2"].Visible = false;
            this.myDataGridViewDetails.Columns["Unit2"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["剩余量"].Visible = false;
            this.myDataGridViewDetails.Columns["剩余量"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["PackageNo"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["PackageNo"].HeaderText = "Packing No(箱号)";
            this.myDataGridViewDetails.Columns["PackageNo"].Width = 130;
            this.myDataGridViewDetails.Columns["PackageNo"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["手册编号"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["手册编号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["序号"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["序号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["品名规格型号"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["品名规格型号"].HeaderText = "Deacription of Goods";
            this.myDataGridViewDetails.Columns["品名规格型号"].Width = 150;
            this.myDataGridViewDetails.Columns["品名规格型号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["BoxNum"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["BoxNum"].HeaderText = "箱数";
            this.myDataGridViewDetails.Columns["BoxNum"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["Quantity"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["Quantity"].HeaderText = "Quantity箱";
            this.myDataGridViewDetails.Columns["Quantity"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.myDataGridViewDetails.Columns["Quantity"].DefaultCellStyle = dataGridViewCellStyle1;

            this.myDataGridViewDetails.Columns["Unit"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["Unit"].HeaderText = "单位";
            this.myDataGridViewDetails.Columns["Unit"].ContextMenuStrip = this.myContextDetails;

            this.myDataGridViewDetails.Columns["UnitPrice"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["UnitPrice"].HeaderText = "单价";
            this.myDataGridViewDetails.Columns["UnitPrice"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["TotalNum"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["TotalNum"].HeaderText = "总数量";
            this.myDataGridViewDetails.Columns["TotalNum"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.myDataGridViewDetails.Columns["TotalNum"].DefaultCellStyle = dataGridViewCellStyle2;

            this.myDataGridViewDetails.Columns["TotalPrice"].DisplayIndex = 9;
            this.myDataGridViewDetails.Columns["TotalPrice"].HeaderText = "总金额";
            this.myDataGridViewDetails.Columns["TotalPrice"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["nw"].DisplayIndex = 10;
            this.myDataGridViewDetails.Columns["nw"].HeaderText = "Net Weight";
            this.myDataGridViewDetails.Columns["nw"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["nw"].DefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridViewDetails.Columns["gw"].DisplayIndex = 11;
            this.myDataGridViewDetails.Columns["gw"].HeaderText = "Gross Weight";
            this.myDataGridViewDetails.Columns["gw"].Width = 100;
            this.myDataGridViewDetails.Columns["gw"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["gw"].DefaultCellStyle = dataGridViewCellStyle1;

        }

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
                string strSQL = @"select Packing.*, Company.E_Name AS Messrs, Customer.com_Abbr AS cust 
                                    FROM Company right outer JOIN Packing ON Company.comid = Packing.comid left outer JOIN Customer ON Packing.custid = Customer.custId " + 
                                    (gstrWhere.Length > 0 ? " where " : "") + gstrWhere + " ORDER BY inputdate DESC";
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
                SysMessage.ErrorMsg(string.Format("加载【PACKING LIST】数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
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
                if (this.myDataGridViewHead.CurrentRowNew != null)
                {
                    if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["Pid"].Value != DBNull.Value)
                    {
                        iOrderID = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["Pid"].Value;
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = string.Format("exec 进口装箱单录入查询 {0}", iOrderID);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtDetails);
                this.myDataGridViewDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【PACKING LIST】出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        #endregion

        #region tools事件
        public override void tool1_First_Click(object sender, EventArgs e)
        {
            base.tool1_First_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells["Packageno"];
            setTool1Enabled();
        }

        public override void tool1_up_Click(object sender, EventArgs e)
        {
            base.tool1_up_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells["Packageno"];
            setTool1Enabled();

        }

        public override void tool1_Down_Click(object sender, EventArgs e)
        {
            base.tool1_Down_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells["Packageno"];
            setTool1Enabled();
        }

        public override void tool1_End_Click(object sender, EventArgs e)
        {
            base.tool1_End_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells["Packageno"];
            setTool1Enabled();
        }

        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            base.tool1_Add_Click(sender, e);
            FormPackingInInput objForm = new FormPackingInInput();
            objForm.MdiParent = this.MdiParent;
            objForm.Show();
        }

        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            base.tool1_Modify_Click(sender, e);
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["Pid"].Value);
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormPackingInput")
                {
                    FormPackingInInput inputForm = (FormPackingInInput)childFrm;
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
                FormPackingInInput objForm = new FormPackingInInput();
                objForm.MdiParent = this.MdiParent;
                objForm.giOrderID = iOrderID;
                objForm.Show();
            }
        }

        public override void tool1_Delete_Click(object sender, EventArgs e)
        {
            base.tool1_Delete_Click(sender, e);
            if (this.myDataGridViewHead.CurrentRow == null) return;
            string strText = string.Format("真的要删除单号 【{0}】 吗？", this.myDataGridViewHead.CurrentRow.Cells["InvoiceNo"].Value);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.Cancel) return;
            try
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = string.Format("删除指定的进口装箱单 {0}", this.myDataGridViewHead.CurrentRow.Cells["Pid"].Value);
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["InvoiceNo"].Value);
                this.myDataGridViewHead.Rows.Remove(this.myDataGridViewHead.CurrentRow);
                setTool1Enabled();
                SysMessage.InformationMsg(strSuccess);
            }
            catch (Exception ex)
            {
                string strError = string.Format("{0} 出现错误：错误信息：{1}", tool1_Delete.Text, ex.Message);
                SysMessage.ErrorMsg(strError);
            }

            /*
             bCancel = True
    
    If Not GetRight(rt进口装箱单修改) Then
        Exit Sub
    End If
    If MsgBox("真的要删除单号 " & mRs!InvoiceNo & " 吗？", vbYesNo + vbQuestion, "警告") = vbYes Then
        On Error GoTo HasError
        
        mCnn.Execute "删除指定的进口装箱单 " & mRs!Pid
        mRs.Delete adAffectCurrent
        Exit Sub
HasError:
        MsgBox Err.Description
    End If
             */
        }

        public override void tool1_Query_Click(object sender, EventArgs e)
        {
            base.tool1_Query_Click(sender, e);
            FormPackingInQueryCondition queryConditionForm = new FormPackingInQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrWhere = queryConditionForm.strReturnWhere;
                LoadDataSourceHead();
            }
        }

        public override void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            base.tool1_ExportExcel_Click(sender, e);

            if (this.myDataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;

            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridViewDetails.DataSource, string.Empty);
        }

        public override void tool1_Print_Click(object sender, EventArgs e)
        {
            base.tool1_Print_Click(sender, e);
        }
        //过帐或取消过帐处理
        public override void tool1_Import_Click(object sender, EventArgs e)
        {
            base.tool1_Import_Click(sender, e);
            if (this.myDataGridViewHead.CurrentRow == null) return;
            string strTemp = string.Empty;
            int i过帐标志 = 0;
            if (this.myDataGridViewHead.CurrentRow.Cells["过帐标志"].Value != DBNull.Value && this.myDataGridViewHead.CurrentRow.Cells["过帐标志"].Value != null
                && Convert.ToBoolean(this.myDataGridViewHead.CurrentRow.Cells["过帐标志"].Value) == true)
            {
                strTemp = "取消";
                i过帐标志 = 0;
            }
            else
            {
                i过帐标志 = 1;
            }

            string strText = string.Format("确定要{0}过帐出库单号【{1}】 吗？", strTemp, this.myDataGridViewHead.CurrentRow.Cells["出库单号"].Value);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.Cancel) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            string strSQL = string.Format("UPDATE 进口料件出库表 SET 过帐标志 ={0} WHERE 料件出库表id ={1}", i过帐标志, this.myDataGridViewHead.CurrentRow.Cells["料件出库表id"].Value);
            dataAccess.ExecuteNonQuery(strSQL, null);
            dataAccess.Close();
            this.myDataGridViewHead.CurrentRow.Cells["过帐标志"].Value = i过帐标志;
            //string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["出库单号"].Value);
            //SysMessage.InformationMsg(strSuccess);
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

        public override void myDataGridViewHead_SelectionChanged(object sender, EventArgs e)
        {
            base.myDataGridViewHead_SelectionChanged(sender, e);
            if (bTriggerGridViewHead_SelectionChanged)
            {
                setTool1Enabled();
                LoadDataSourceDetails();
            }
        }
    }
}
