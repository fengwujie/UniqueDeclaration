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
    public partial class FormMaterialsOutQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormMaterialsOutQueryList()
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

        private void FormMaterialsOutQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_ExportExcel.Visible = false;
            this.tool1_Print.Visible = true;
            LoadDataSourceHead();
            InitGridDetails();
            InitGridHead();
        }

        private void InitGridHead()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["料件出库表id"].Visible = false;
            this.myDataGridViewHead.Columns["料件出库表id"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["出库单号"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["出库单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["制造通知单号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["制造通知单号"].HeaderText = "单号";
            this.myDataGridViewHead.Columns["制造通知单号"].Width = 120;
            this.myDataGridViewHead.Columns["制造通知单号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["电子帐册号"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["电子帐册号"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["出库时间"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["出库时间"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["录入员"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["录入员"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["摘要"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["摘要"].Width = 120;
            this.myDataGridViewHead.Columns["摘要"].ContextMenuStrip = this.myContextHead;
            this.myDataGridViewHead.Columns["过帐标志"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["过帐标志"].ContextMenuStrip = this.myContextHead;
        }

        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["BM"].Visible = false;
            this.myDataGridViewDetails.Columns["BM"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["料件出库明细表id"].Visible = false;
            this.myDataGridViewDetails.Columns["料件出库明细表id"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["料件id"].Visible = false;
            this.myDataGridViewDetails.Columns["料件id"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["料件编号"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["料件编号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["料号"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["料号"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["料件名"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["料件名"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["商品编码"].DisplayIndex =3;
            this.myDataGridViewDetails.Columns["商品编码"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["商品名称"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["商品名称"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["商品规格"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["商品规格"].ContextMenuStrip = this.myContextDetails;

            this.myDataGridViewDetails.Columns["出库数量"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["出库数量"].ContextMenuStrip = this.myContextDetails;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            this.myDataGridViewDetails.Columns["出库数量"].DefaultCellStyle = dataGridViewCellStyle1;

            this.myDataGridViewDetails.Columns["单位"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["单位"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["备注"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["备注"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["库存数"].Visible = false;
            this.myDataGridViewDetails.Columns["库存数"].ContextMenuStrip = this.myContextDetails;
            this.myDataGridViewDetails.Columns["出库后库存数"].Visible = false;
            this.myDataGridViewDetails.Columns["出库后库存数"].ContextMenuStrip = this.myContextDetails;

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
                string strSQL = "SELECT * from 进口料件出库表 " + (gstrWhere.Length > 0 ? " where " : "") + gstrWhere + " ORDER BY 出库时间 DESC";
                DataTable dtHead = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                bTriggerGridViewHead_SelectionChanged = false;
                this.myDataGridViewHead.DataSource = dtHead;
                bTriggerGridViewHead_SelectionChanged = true;
                this.myDataGridViewHead_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【料件出库单】数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
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
                if (this.myDataGridViewHead.CurrentRow !=null)
                {
                    iOrderID = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRow.Index].Cells["料件出库表id"].Value;
                    strBooksNo = this.myDataGridViewHead.CurrentRow.Cells["电子帐册号"].Value.ToString();
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                //string strSQL = string.Format("select * from 报关预先订单明细表 where 订单id={0}", iOrderID);
                string strSQL = string.Format("exec 进口料件出库修改查询 {0},{1}", iOrderID,StringTools.SqlQ( strBooksNo));
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();

                this.myDataGridViewDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载【出库单明细】出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        #endregion

        #region tools事件
        public override void tool1_First_Click(object sender, EventArgs e)
        {
            base.tool1_First_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells["出库单号"];
            setTool1Enabled();
        }

        public override void tool1_up_Click(object sender, EventArgs e)
        {
            base.tool1_up_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells["出库单号"];
            setTool1Enabled();

        }

        public override void tool1_Down_Click(object sender, EventArgs e)
        {
            base.tool1_Down_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells["出库单号"];
            setTool1Enabled();
        }

        public override void tool1_End_Click(object sender, EventArgs e)
        {
            base.tool1_End_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells["出库单号"];
            setTool1Enabled();
        }

        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            base.tool1_Add_Click(sender, e);
            FormMaterialsOutInput objForm = new FormMaterialsOutInput();
            objForm.MdiParent = this.MdiParent;
            objForm.Show();
        }

        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            base.tool1_Modify_Click(sender, e);
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["料件出库表id"].Value);
            string strBooksNo =this.myDataGridViewHead.CurrentRow.Cells["电子帐册号"].Value.ToString();
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormMaterialsOutInput")
                {
                    FormMaterialsOutInput inputForm = (FormMaterialsOutInput)childFrm;
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
                FormMaterialsOutInput objForm = new FormMaterialsOutInput();
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
            string strText = string.Format("真的要删除出库单号 【{0}】 吗？", this.myDataGridViewHead.CurrentRow.Cells["出库单号"].Value);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.Cancel) return;
            try
            {
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("删除指定的进口料件出库资料 {0}", this.myDataGridViewHead.CurrentRow.Cells["料件出库表id"].Value);
                dataAccess.ExecuteNonQuery(strSQL, null);
                dataAccess.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["出库单号"].Value);
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
            FormMaterialsOutQueryCondition queryConditionForm = new FormMaterialsOutQueryCondition();
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

            //if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;
            if (this.myDataGridViewHead.CurrentRow == null) return;

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
            //saveFileDialog.FileName =string.Format("预先订单【{0}】",myDataGridViewHead.CurrentRow.Cells["出库单号"].Value.ToString()) ;
            //if (saveFileDialog.ShowDialog() != DialogResult.OK)  return; 

            string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\制造单清单明细表.xls");
            string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\制造单清单明细表{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
            File.Copy(strSourceFile, strDestFile);
            File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
            string fn = strDestFile;
            //string fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\制造单清单明细表.xls");
            ExcelTools ea = new ExcelTools();
            ea.SafeOpen(fn);
            ea.ActiveSheet(1); // 激活
            ea.SetValue("A8", "出库单号:" + myDataGridViewHead.CurrentRow.Cells["出库单号"].Value.ToString());
            ea.SetValue("D8", "CustNo：" + myDataGridViewHead.CurrentRow.Cells["客户代码"].Value.ToString());
            ea.SetValue("F8", "DATE：" + Convert.ToDateTime(myDataGridViewHead.CurrentRow.Cells["出货日期"].Value).ToString("yyyy-MM-dd"));

            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtExcel = dataAccess.GetTable(string.Format("select * from 报关预先订单明细表 where 订单id={0}", myDataGridViewHead.CurrentRow.Cells["订单id"].Value), null);
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

            string strText = string.Format("确定要{0}过帐出库单号【{1}】 吗？",strTemp, this.myDataGridViewHead.CurrentRow.Cells["出库单号"].Value);
            if (SysMessage.OKCancelMsg(strText) == System.Windows.Forms.DialogResult.Cancel) return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            string strSQL = string.Format("UPDATE 进口料件出库表 SET 过帐标志 ={0} WHERE 料件出库表id ={1}",i过帐标志, this.myDataGridViewHead.CurrentRow.Cells["料件出库表id"].Value);
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

        public override void myDataGridViewHead_SelectionChanged(object sender, EventArgs e)
        {
            base.myDataGridViewHead_SelectionChanged(sender, e);
            if (bTriggerGridViewHead_SelectionChanged)
            {
                setTool1Enabled();
                LoadDataSourceDetails();
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (this.myDataGridViewHead.CurrentRow == null) return;
            FormMaterialsOutQuertList_CheckCondition objForm = new FormMaterialsOutQuertList_CheckCondition();
            if( objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FormMaterialsOutQueryList_CheckQueryList checkQueryList = new FormMaterialsOutQueryList_CheckQueryList();
                checkQueryList.ManualCode = objForm.ManualCode;
                checkQueryList.InId =StringTools.intParse( this.myDataGridViewHead.CurrentRow.Cells["料件出库表id"].Value.ToString());
                checkQueryList.InOutvalue = 2;
                checkQueryList.passvalue = objForm.passvalue;
                checkQueryList.MdiParent = this.MdiParent;
                checkQueryList.Show();
            }
        }
    }
}
