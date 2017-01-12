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

namespace UniqueDeclaration.Base
{
    public partial class FormMergeRelationMaterialsQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormMergeRelationMaterialsQueryList()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 是否触发行变化事件
        /// </summary>
        private bool bTriggerGridViewHead_SelectionChanged = true;
        /// <summary>
        /// 是否触发行变化事件
        /// </summary>
        private bool bTriggerGridViewDetails_SelectionChanged = true;
        /// <summary>
        /// 查询窗体的传进来的手册编号
        /// </summary>
        public string gstrManualNo = string.Empty;

        private void FormMergeRelationMaterialsQueryList_Load(object sender, EventArgs e)
        {
            base.tool1_Number.Visible = false;
            base.tool1_Import.Visible = false;
            base.tool1_Print.Visible = false;
            base.tool1_PrintView.Visible = true;
            this.myDataGridViewDetails.SelectionChanged += new EventHandler(myDataGridViewDetails_SelectionChanged);
            LoadDataSourceHead();

            InitGridHead();
            InitGridDetails();
            InitGridDetails2();
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
                string strSQL =string.Format( "select * FROM 归并后料件清单 where 电子帐册号={0} ORDER BY 序号",StringTools.SqlQ( gstrManualNo));
                DataTable dtHead = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                bTriggerGridViewHead_SelectionChanged = false;
                DataTableTools.AddEmptyRow(dtHead);
                this.myDataGridViewHead.DataSource = dtHead;
                bTriggerGridViewHead_SelectionChanged = true;
                //if (this.dataGridViewHead.RowCount > 0)
                //{
                //    this.dataGridViewHead.CurrentCell = this.dataGridViewHead.Rows[0].Cells["电子帐册号"];
                //    this.dataGridViewHead.Rows[0].Selected = true;
                //}
                this.myDataGridViewHead_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载数据出错LoadDataSourceHead，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
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
                if (this.myDataGridViewHead.CurrentRowNew != null && this.myDataGridViewHead.CurrentRowNew.Index >= 0)
                {
                    if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["归并后料件id"].Value != DBNull.Value)
                        iOrderID = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["归并后料件id"].Value;
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("exec 商品归并表录入查询 {0}", iOrderID);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();

                DataTableTools.AddEmptyRow(dtDetails);
                bTriggerGridViewDetails_SelectionChanged = false;
                this.myDataGridViewDetails.DataSource = dtDetails;
                bTriggerGridViewDetails_SelectionChanged = true;
                this.myDataGridViewDetails_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载数据出错LoadDataSourceDetails，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
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
        private void LoadDataSourceDetails2()
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
                string 序号id = string.Empty;
                string 项号id = string.Empty;
                string 电子帐册号 = string.Empty;

                if (this.myDataGridViewHead.CurrentRowNew != null && this.myDataGridViewHead.CurrentRowNew.Index >= 0)
                {
                    if (this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["归并后料件id"].Value != DBNull.Value)
                    {
                        序号id = this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["序号"].Value.ToString().Trim();
                        if (序号id.Length == 1) 
                            序号id = string.Format("0{0}",序号id);
                        电子帐册号 = this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["电子帐册号"].Value.ToString().Trim();
                    }
                }
                if (this.myDataGridViewDetails.CurrentRowNew != null && this.myDataGridViewDetails.CurrentRowNew.Index >= 0)
                {
                    if (this.myDataGridViewDetails.Rows[this.myDataGridViewDetails.CurrentRowNew.Index].Cells["归并前料件id"].Value != DBNull.Value)
                    {
                        项号id = this.myDataGridViewDetails.Rows[this.myDataGridViewDetails.CurrentRowNew.Index].Cells["序号"].Value.ToString().Trim();
                        if (项号id.Length == 1)
                            项号id = string.Format("0{0}", 项号id);
                    }
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                string strSQL = string.Format("exec 归并前料件清单明细查询 '{0}','{1}','{2}'", 序号id, 项号id,电子帐册号);
                DataTable dtDetails2 = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();

                DataTableTools.AddEmptyRow(dtDetails2);
                this.myDataGridViewDetails2.DataSource = dtDetails2;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载数据出错LoadDataSourceDetails2，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
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
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["归并后料件id"].Visible = false;
            this.myDataGridViewHead.Columns["序号"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["电子帐册号"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["产品编号"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["商品编码"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["商品名称"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["商品规格"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["产销国"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["单价"].DisplayIndex = 8;
            this.myDataGridViewHead.Columns["币种"].DisplayIndex = 9;
            this.myDataGridViewHead.Columns["计量单位"].DisplayIndex = 10;
            this.myDataGridViewHead.Columns["计量单位"].HeaderText = "申报计量单位";
            this.myDataGridViewHead.Columns["法定单位"].DisplayIndex = 11;
            this.myDataGridViewHead.Columns["换算因子"].DisplayIndex = 12;
            this.myDataGridViewHead.Columns["损耗率"].DisplayIndex = 13;
            this.myDataGridViewHead.Columns["主料"].DisplayIndex = 14;
            this.myDataGridViewHead.Columns["四位大类序号"].DisplayIndex = 15;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewHead.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextHead;
            }
        }
        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["BM"].Visible = false;
            this.myDataGridViewDetails.Columns["归并前料件id"].Visible = false;
            this.myDataGridViewDetails.Columns["序号"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["产品编号"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["商品编码"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["商品名称"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["商品规格"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["单价"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["币种"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["计量单位"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["计量单位"].HeaderText = "申报计量单位";
            this.myDataGridViewDetails.Columns["法定单位"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["换算因子"].DisplayIndex = 9;
            this.myDataGridViewDetails.Columns["对应编号"].DisplayIndex = 10;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "F3";
            dataGridViewCellStyle1.NullValue = null;
            this.myDataGridViewDetails.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewDetails.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextDetails;
            }
        }
        private void InitGridDetails2()
        {
            if (this.myDataGridViewDetails2.DataSource != null)
            {
                foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewDetails2.Columns)
                {
                    textBoxColumn.ContextMenuStrip = this.myContextDetails2;
                }
            }
        }
        #endregion
        
        #region tools事件
        public override void tool1_First_Click(object sender, EventArgs e)
        {
            base.tool1_First_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells["电子帐册号"];
            setTool1Enabled();
        }

        public override void tool1_up_Click(object sender, EventArgs e)
        {
            base.tool1_up_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells["电子帐册号"];
            setTool1Enabled();

        }

        public override void tool1_Down_Click(object sender, EventArgs e)
        {
            base.tool1_Down_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells["电子帐册号"];
            setTool1Enabled();
        }

        public override void tool1_End_Click(object sender, EventArgs e)
        {
            base.tool1_End_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells["电子帐册号"];
            setTool1Enabled();
        }

        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            //base.tool1_Add_Click(sender, e);
            FormMergeRelationMaterialsInput objForm = new FormMergeRelationMaterialsInput();
            objForm.MdiParent = this.MdiParent;
            objForm.giOrderID = 0;
            objForm.Show();
        }

        public override void tool1_Delete_Click(object sender, EventArgs e)
        {
            try
            {
            if (this.myDataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg(string.Format("真的要删除此商品编码【{0}】吗？", this.myDataGridViewHead.CurrentRow.Cells["商品编码"].Value)) == System.Windows.Forms.DialogResult.No) return;
            string strSQL = string.Format("删除指定的归并后料件清单资料 {0}", this.myDataGridViewHead.CurrentRow.Cells["归并后料件id"].Value);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dataAccess.ExecuteNonQuery(strSQL,null);
            dataAccess.Close();
            string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["商品编码"].Value);
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

        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            //base.tool1_Modify_Click(sender, e);
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["归并后料件id"].Value);
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormMergeRelationMaterialsInput")
                {
                    FormMergeRelationMaterialsInput inputForm = (FormMergeRelationMaterialsInput)childFrm;
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
                FormMergeRelationMaterialsInput objForm = new FormMergeRelationMaterialsInput();
                objForm.MdiParent = this.MdiParent;
                objForm.giOrderID = iOrderID;
                objForm.Show();
            }
        }

        public override void tool1_Query_Click(object sender, EventArgs e)
        {
            base.tool1_Query_Click(sender, e);
            FormMergeRelationMaterialsQueryCondition queryConditionForm = new FormMergeRelationMaterialsQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrManualNo = queryConditionForm.cManualNo;
                LoadDataSourceHead();
            }
        }

        public override void tool1_PrintView_Click(object sender, EventArgs e)
        {
            //base.tool1_PrintView_Click(sender, e);
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;

            DataTable dtHead = (DataTable)myDataGridViewHead.DataSource;
            DataTable dtDetails = (DataTable)myDataGridViewDetails.DataSource;
            if (dtHead.Rows.Count > 0)
            {
                long n = 0;
                string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\归并关系表.xls");
                string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\归并关系表{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
                File.Copy(strSourceFile, strDestFile);
                File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
                string fn = strDestFile;
                ExcelTools ea = new ExcelTools();
                ea.SafeOpen(fn);
                ea.ActiveSheet(1); // 激活
                n = 6;
                DataGridViewRow gridViewRowHead = myDataGridViewHead.CurrentRowNew;
                ea.SetValue(string.Format("N{0}", n),DateTime.Now.ToString("yyyy-MM-ddd"));
                ea.SetValue(string.Format("J{0}", n), gridViewRowHead.Cells["序号"].Value.ToString());
                ea.SetValue(string.Format("K{0}", n), gridViewRowHead.Cells["产品编号"].Value.ToString());
                ea.SetValue(string.Format("L{0}", n), gridViewRowHead.Cells["商品编码"].Value.ToString());
                ea.SetValue(string.Format("M{0}", n), gridViewRowHead.Cells["商品名称"].Value.ToString());
                ea.SetValue(string.Format("N{0}", n), gridViewRowHead.Cells["商品规格"].Value.ToString());
                ea.SetValue(string.Format("O{0}", n), gridViewRowHead.Cells["单价"].Value.ToString());
                ea.SetValue(string.Format("P{0}", n), gridViewRowHead.Cells["计量单位"].Value.ToString());
                ea.SetValue(string.Format("Q{0}", n), gridViewRowHead.Cells["法定单位"].Value.ToString());
                ea.SetValue(string.Format("R{0}", n), gridViewRowHead.Cells["换算因子"].Value.ToString());
                foreach (DataRow row in dtDetails.Rows)
                {
                    ea.SetValue(string.Format("A{0}", n), row["序号"].ToString());
                    ea.SetValue(string.Format("B{0}", n), row["产品编号"].ToString());
                    ea.SetValue(string.Format("C{0}", n), row["商品编码"].ToString());
                    ea.SetValue(string.Format("D{0}", n), row["商品名称"].ToString());
                    ea.SetValue(string.Format("E{0}", n), row["商品规格"].ToString());
                    ea.SetValue(string.Format("F{0}", n), row["单价"].ToString());
                    ea.SetValue(string.Format("G{0}", n), row["计量单位"].ToString());
                    ea.SetValue(string.Format("H{0}", n), row["法定单位"].ToString());
                    ea.SetValue(string.Format("I{0}", n), row["换算因子"].ToString());
                    n++;
                }
                ea.Visible = true;
                ea.Dispose();
            }
        }
        
        public override void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            base.tool1_ExportExcel_Click(sender, e);

            if (this.myDataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;

            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridViewHead.DataSource, string.Empty);
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
            if (bTriggerGridViewHead_SelectionChanged)
            {
                LoadDataSourceDetails();
            }
        }
        private void myDataGridViewDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (bTriggerGridViewDetails_SelectionChanged)
            {
                LoadDataSourceDetails2();
            }
        }
        //基本数据导出
        private void btnBaseDataExport_Click(object sender, EventArgs e)
        {
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;
            long n = 0;
            string 计量单位Char, 法定单位Char, 币种Char;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            string strSQL = string.Format("SELECT '1' AS 类型,H.主料,H.四位大类序号,H.序号, H.商品编码, H.商品名称, H.商品规格, H.计量单位, H.币种,H.单价, H.法定单位,  H.换算因子, Q.产品编号,Q.商品规格 AS 归并前商品规格, '1' AS 商品类型,H.法定单位 AS 企业单位, Q.单价 AS 归并前单价 FROM 归并后料件清单 H left outer  JOIN 归并前料件清单 Q ON H.归并后料件id = Q.归并后料件id where H.电子帐册号={0} order by H.序号,Q.序号", StringTools.SqlQ(gstrManualNo));
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count > 0)
            {
                string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\基础数据导入.xls");
                string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\基础数据导入{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
                File.Copy(strSourceFile, strDestFile);
                File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
                string fn = strDestFile;
                ExcelTools ea = new ExcelTools();
                ea.SafeOpen(fn);
                ea.ActiveSheet(1); // 激活
                IDataAccess dataGWT = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_GWT);
                DataTable dtUnit = null;
                DataTable dtCurr = null;
                n = 3;
                foreach (DataRow row in dtData.Rows)
                {
                    #region 计量单位
                    if (row["计量单位"] == DBNull.Value && row["计量单位"].ToString().Trim() == "")
                    {
                        计量单位Char = "";
                    }
                    else
                    {
                        dataGWT.Open();
                        dtUnit = dataGWT.GetTable(string.Format("SELECT * FROM unit where ut_name={0}", StringTools.SqlQ(row["计量单位"].ToString())), null);
                        dataGWT.Close();
                        if (dtUnit.Rows.Count > 0)
                        {
                            计量单位Char = dtUnit.Rows[0]["Unit"].ToString();
                        }
                        else
                        {
                            计量单位Char = row["计量单位"].ToString().Trim();
                        }
                    }
                    #endregion

                    #region 法定单位
                    if (row["法定单位"] == DBNull.Value && row["法定单位"].ToString().Trim() == "")
                    {
                        法定单位Char = "";
                    }
                    else
                    {
                        dataGWT.Open();
                        dtUnit = dataGWT.GetTable(string.Format("SELECT * FROM unit where ut_name={0}", StringTools.SqlQ(row["法定单位"].ToString())), null);
                        dataGWT.Close();
                        if (dtUnit.Rows.Count > 0)
                        {
                            法定单位Char = dtUnit.Rows[0]["Unit"].ToString();
                        }
                        else
                        {
                            法定单位Char = row["法定单位"].ToString().Trim();
                        }
                    }
                    #endregion
                    
                    #region 币种
                    if (row["币种"] == DBNull.Value && row["币种"].ToString().Trim() == "")
                    {
                        币种Char = "";
                    }
                    else
                    {
                        dataGWT.Open();
                        dtCurr = dataGWT.GetTable(string.Format("SELECT * FROM curr where cr_name={0} or cr_ab={0}", StringTools.SqlQ(row["币种"].ToString())), null);
                        dataGWT.Close();
                        if (dtUnit.Rows.Count > 0)
                        {
                            币种Char = dtCurr.Rows[0]["curr"].ToString();
                        }
                        else
                        {
                            币种Char = row["法定单位"].ToString().Trim();
                        }
                    }
                    #endregion

                    #region 设置单元格的值
                    ea.SetValue(string.Format("A{0}", n), row["类型"].ToString());
                    ea.SetValue(string.Format("B{0}", n), row["序号"].ToString());
                    ea.SetValue(string.Format("C{0}", n), row["商品编码"].ToString());
                    ea.SetValue(string.Format("E{0}", n), row["商品名称"].ToString());
                    ea.SetValue(string.Format("F{0}", n), row["商品规格"].ToString());
                    ea.SetValue(string.Format("G{0}", n), 计量单位Char);
                    ea.SetValue(string.Format("H{0}", n), 币种Char);
                    ea.SetValue(string.Format("I{0}", n), row["单价"].ToString());
                    ea.SetValue(string.Format("K{0}", n), 法定单位Char);
                    ea.SetValue(string.Format("Q{0}", n), row["四位大类序号"].ToString());
                    ea.SetValue(string.Format("R{0}", n), row["换算因子"].ToString());
                    ea.SetValue(string.Format("V{0}", n), row["产品编号"].ToString());
                    ea.SetValue(string.Format("W{0}", n), row["商品名称"].ToString());
                    ea.SetValue(string.Format("X{0}", n), row["归并前商品规格"].ToString());
                    ea.SetValue(string.Format("Y{0}", n), row["商品类型"].ToString());
                    ea.SetValue(string.Format("Z{0}", n), 法定单位Char);
                    ea.SetValue(string.Format("AB{0}", n), row["归并前单价"].ToString());
                    ea.SetValue(string.Format("AC{0}", n), 币种Char);
                    ea.SetValue(string.Format("AF{0}", n), row["换算因子"].ToString());
                    ea.SetValue(string.Format("AP{0}", n), row["换算因子"].ToString());
                    ea.SetValue(string.Format("AS{0}", n), row["归并前单价"].ToString());
                    ea.SetValue(string.Format("AT{0}", n), row["主料"].ToString()=="主料" ? "1" : "2");
                    #endregion
                    n++;
                }
                ea.Visible = true;
                ea.Dispose();
            }
        }
    }
}
