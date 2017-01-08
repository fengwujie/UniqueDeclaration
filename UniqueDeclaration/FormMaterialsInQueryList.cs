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
    public partial class FormMaterialsInQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormMaterialsInQueryList()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 查询窗体的返回来的条件
        /// </summary>
        public string gstrWhere = string.Empty;
        /// <summary>
        /// 是否触发行变化事件
        /// </summary>
        private bool bTriggerGridViewHead_SelectionChanged = true;

        private void FormMaterialsInQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_ExportExcel.Visible = false;
            this.tool1_Print.Visible = true;
            LoadDataSourceHead();
            InitGridDetails();
            InitGridHead();
        }
        
        #region 加载数据
        /// <summary>
        /// 加载表头数据
        /// </summary>
        private void LoadDataSourceHead()
        {
            try
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = "SELECT * from 进口料件入库表 " + (gstrWhere.Length > 0 ? " where " : "") + gstrWhere + " ORDER BY 入库时间 DESC";
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
                SysMessage.ErrorMsg(string.Format("加载【料件入库单】数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
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
                    if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRow.Index].Cells["料件入库表id"].Value != DBNull.Value)
                    {
                        iOrderID = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRow.Index].Cells["料件入库表id"].Value;
                        strBooksNo = this.myDataGridViewHead.CurrentRow.Cells["电子帐册号"].Value.ToString();
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                //string strSQL = string.Format("select * from 报关预先订单明细表 where 订单id={0}", iOrderID);
                string strSQL = string.Format("exec 进口料件入库录入查询 {0},{1}", iOrderID, StringTools.SqlQ(strBooksNo));
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtDetails);
                this.myDataGridViewDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【入库单明细】出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
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
        #endregion


        private void InitGridHead()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["料件入库表id"].Visible = false;
            this.myDataGridViewHead.Columns["料件入库表id"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["用途"].Visible = false;
            this.myDataGridViewHead.Columns["用途"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["征免方式"].Visible = false;
            this.myDataGridViewHead.Columns["征免方式"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["产销国"].Visible = false;
            this.myDataGridViewHead.Columns["产销国"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["币制"].Visible = false;
            this.myDataGridViewHead.Columns["币制"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["申报地海关代码"].Visible = false;
            this.myDataGridViewHead.Columns["申报地海关代码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["进口岸代码"].Visible = false;
            this.myDataGridViewHead.Columns["进口岸代码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["代理单位代码"].Visible = false;
            this.myDataGridViewHead.Columns["代理单位代码"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["入库单号"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["入库单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["清单编号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["清单编号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["报关单号"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["报关单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["发票号"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["发票号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["电子帐册号"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["电子帐册号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["入库时间"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["入库时间"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["录入员"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["录入员"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["摘要"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["摘要"].Width = 120;
            this.myDataGridViewHead.Columns["摘要"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["过帐标志"].DisplayIndex = 8;
            this.myDataGridViewHead.Columns["过帐标志"].ContextMenuStrip = this.myContextHead;
        }

        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["BM"].Visible = false;
            this.myDataGridViewDetails.Columns["BM"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["料件入库明细表id"].Visible = false;
            this.myDataGridViewDetails.Columns["料件入库明细表id"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["料件id"].Visible = false;
            this.myDataGridViewDetails.Columns["料件id"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["料件编号"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["料件编号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["料号"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["料号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["料件名"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["料件名"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["商品编码"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["商品编码"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["商品名称"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["商品名称"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["商品规格"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["商品规格"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["单价"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["单价"].Width = 60;
            this.myDataGridViewDetails.Columns["单价"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.myDataGridViewDetails.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle2;

            this.myDataGridViewDetails.Columns["入库数量"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["入库数量"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            this.myDataGridViewDetails.Columns["入库数量"].DefaultCellStyle = dataGridViewCellStyle1;

            this.myDataGridViewDetails.Columns["单位"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["单位"].Width = 60;
            this.myDataGridViewDetails.Columns["单位"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["备注"].DisplayIndex = 9;
            this.myDataGridViewDetails.Columns["备注"].Width = 130;
            this.myDataGridViewDetails.Columns["备注"].ContextMenuStrip = this.myContextDetails;

        }

        #region tools事件
        public override void tool1_First_Click(object sender, EventArgs e)
        {
            base.tool1_First_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells["入库单号"];
            setTool1Enabled();
        }

        public override void tool1_up_Click(object sender, EventArgs e)
        {
            base.tool1_up_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells["入库单号"];
            setTool1Enabled();

        }

        public override void tool1_Down_Click(object sender, EventArgs e)
        {
            base.tool1_Down_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells["入库单号"];
            setTool1Enabled();
        }

        public override void tool1_End_Click(object sender, EventArgs e)
        {
            base.tool1_End_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells["入库单号"];
            setTool1Enabled();
        }

        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            base.tool1_Add_Click(sender, e);
            FormMaterialsInInput objForm = new FormMaterialsInInput();
            objForm.MdiParent = this.MdiParent;
            objForm.Show();
        }

        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            base.tool1_Modify_Click(sender, e);
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["料件入库表id"].Value);
            string strBooksNo = this.myDataGridViewHead.CurrentRow.Cells["电子帐册号"].Value.ToString();
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormMaterialsInInput")
                {
                    FormMaterialsInInput inputForm = (FormMaterialsInInput)childFrm;
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
                FormMaterialsInInput objForm = new FormMaterialsInInput();
                objForm.MdiParent = this.MdiParent;
                objForm.giOrderID = iOrderID;
                objForm.strBooksNo = strBooksNo;
                objForm.Show();
            }
        }

        public override void tool1_Delete_Click(object sender, EventArgs e)
        {
            base.tool1_Delete_Click(sender, e);
            if (this.myDataGridViewHead.CurrentRow == null) return;
            string strText = string.Format("真的要删除入库单号 【{0}】 吗？", this.myDataGridViewHead.CurrentRow.Cells["入库单号"].Value);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.Cancel) return;
            try
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("删除指定的进口料件入库资料 {0}", this.myDataGridViewHead.CurrentRow.Cells["料件入库表id"].Value);
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["入库单号"].Value);
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
            FormMaterialsInQueryCondition queryConditionForm = new FormMaterialsInQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrWhere = queryConditionForm.strReturnWhere;
                LoadDataSourceHead();
            }
        }

        public override void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            base.tool1_ExportExcel_Click(sender, e);
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

            string strText = string.Format("确定要{0}过帐入库单号【{1}】 吗？", strTemp, this.myDataGridViewHead.CurrentRow.Cells["入库单号"].Value);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.Cancel) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            string strSQL = string.Format("UPDATE 进口料件入库表 SET 过帐标志 ={0} WHERE 料件入库表id ={1}", i过帐标志, this.myDataGridViewHead.CurrentRow.Cells["料件入库表id"].Value);
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

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (this.myDataGridViewHead.CurrentRow == null) return;
            FormMaterialsOutQuertList_CheckCondition objForm = new FormMaterialsOutQuertList_CheckCondition();
            if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FormMaterialsOutQueryList_CheckQueryList checkQueryList = new FormMaterialsOutQueryList_CheckQueryList();
                checkQueryList.ManualCode = objForm.ManualCode;
                checkQueryList.InId = StringTools.intParse(this.myDataGridViewHead.CurrentRow.Cells["料件入库表id"].Value.ToString());
                checkQueryList.InOutvalue = 1;
                checkQueryList.passvalue = objForm.passvalue;
                checkQueryList.MdiParent = this.MdiParent;
                checkQueryList.Show();
            }
        }

        private void btnDataImport_Click(object sender, EventArgs e)
        {
            if (this.myDataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("数据是否导出？") == System.Windows.Forms.DialogResult.No) return;
            DataRow mRs = (myDataGridViewHead.CurrentRow.DataBoundItem as DataRowView).Row;
            IDataAccess dataManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            IDataAccess dataGWT = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_GWT);
            dataManufacture.Open();
            DataTable rs = dataManufacture.GetTable(string.Format("报关进口料件数量转换统计 @id={0},@电子帐册号='{1}',@类别=1",
                mRs["料件入库表id"],mRs["电子帐册号"]),null);
            dataManufacture.Close();
            if (rs.Rows.Count > 0)
            {
                decimal PriceValue;
                int n = 1;
                dataManufacture.Open();
                dataGWT.Open();
                foreach (DataRow rsRow in rs.Rows)
                {
                    DataTable crs = dataManufacture.GetTable(string.Format(@"SELECT H.单价 FROM 归并前料件清单 Q RIGHT OUTER JOIN 归并后料件清单 H ON Q.归并后料件id = H.归并后料件id 
                                    WHERE H.电子帐册号='{0}' and Q.产品编号='{1}'", mRs["电子帐册号"], rsRow["料号"]), null);
                    if (crs.Rows.Count > 0 && crs.Rows[0]["单价"] != DBNull.Value)
                        PriceValue = Convert.ToDecimal(Convert.ToDecimal(crs.Rows[0]["单价"]).ToString("N2"));
                    else
                        PriceValue = Convert.ToDecimal(Convert.ToDecimal(0).ToString("N2"));
                    dataGWT.ExecuteNonQuery(string.Format(@"INSERT INTO GWT_EMS_CL(Ems_No,owner_code, Cop_List_No, I_E_Mark, G_Mark,List_Declare_Date,List_G_No,Cop_G_No,Qty,Factor_1,Unit,Unit_1,
                                                                Dec_Price,Use_Type,Duty_Mode,Country_Code,Curr) VALUES({0},'3502948415',{1},'I','3','{2}',{3},{4},{5},{6},'035','035',
                                                                {7},{8},{9},{10},{11})",
                                           mRs["电子帐册号"] == DBNull.Value ? "NULL" :StringTools.SqlQ( mRs["电子帐册号"].ToString()), 
                                           mRs["清单编号"] == DBNull.Value ? "NULL" : StringTools.SqlQ( mRs["清单编号"].ToString()),
                                           DateTime.Now.ToString("yyyy-MM-dd"), n, rsRow["料号"] == DBNull.Value ? "NULL" : StringTools.SqlQ( rsRow["料号"].ToString()),
                                           rsRow["入库数量"] == DBNull.Value ? "NULL" : rsRow["入库数量"], rsRow["入库数量"] == DBNull.Value ? "NULL" : rsRow["入库数量"], PriceValue,
                                           mRs["用途"] == DBNull.Value ? "NULL" : StringTools.SqlQ( mRs["用途"].ToString()), 
                                           mRs["征免方式"] == DBNull.Value ? "NULL" : mRs["征免方式"],
                                           mRs["产销国"] == DBNull.Value ? "NULL" : StringTools.SqlQ( mRs["产销国"].ToString()), 
                                           mRs["币制"] == DBNull.Value ? "NULL" : mRs["币制"]), null);
                    n++;
                }
                dataGWT.ExecuteNonQuery("sp_get_gwt_ems_cl", null);
                dataManufacture.Close();
                dataGWT.Close();
            }
        }

    }
}
