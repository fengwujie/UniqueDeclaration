using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration.Base
{
    public partial class FormCheckOutQueryList : UniqueDeclarationBaseForm.FormBaseQueryList2
    {
        public FormCheckOutQueryList()
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

        private void FormCheckOutQueryList_Load(object sender, EventArgs e)
        {
            this.tool1_Number.Visible = false;
            this.tool1_BOM.Visible = false;
            this.tool1_Print.Visible = true;
            this.tool1_PrintView.Visible = true;
            this.tool1_ExportExcel.Visible = false;

            LoadDataSourceHead();
            InitGridHead();
            InitGridDetails();
        }

        private void InitGridHead()
        {
            this.myDataGridViewHead.AutoGenerateColumns = false;
            this.myDataGridViewHead.Columns["手册id"].Visible = false;
            this.myDataGridViewHead.Columns["报关产品表id"].Visible = false;

            this.myDataGridViewHead.Columns["报关订单号"].DisplayIndex = 0;
            this.myDataGridViewHead.Columns["手册编号"].DisplayIndex = 1;
            this.myDataGridViewHead.Columns["客人型号"].DisplayIndex = 2;
            this.myDataGridViewHead.Columns["优丽型号"].DisplayIndex = 3;
            this.myDataGridViewHead.Columns["成品项号"].DisplayIndex = 4;
            this.myDataGridViewHead.Columns["成品项号"].Width = 80;
            this.myDataGridViewHead.Columns["成品名称及商编"].DisplayIndex = 5;
            this.myDataGridViewHead.Columns["成品名称及商编"].Width = 400;
            this.myDataGridViewHead.Columns["成品规格型号"].DisplayIndex = 6;
            this.myDataGridViewHead.Columns["成品规格型号"].Width = 120;
            this.myDataGridViewHead.Columns["产品表申报单位"].DisplayIndex = 7;
            this.myDataGridViewHead.Columns["产品表申报单位"].HeaderText = "申报单位";
            this.myDataGridViewHead.Columns["产品表法定单位"].DisplayIndex = 8;
            this.myDataGridViewHead.Columns["产品表法定单位"].HeaderText = "法定单位";
            this.myDataGridViewHead.Columns["变更规格型号"].DisplayIndex = 9;
            this.myDataGridViewHead.Columns["变更规格型号"].Width = 120;
            this.myDataGridViewHead.Columns["归并前成品序号"].DisplayIndex = 10;
            this.myDataGridViewHead.Columns["归并前成品序号"].Width = 120;
            this.myDataGridViewHead.Columns["录入日期"].DisplayIndex = 11;

            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewHead.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMenuHead;
            }
        }

        private void InitGridDetails()
        {
            this.myDataGridViewDetails.AutoGenerateColumns = false;
            this.myDataGridViewDetails.Columns["报关产品组成明细表id"].Visible = false;
            this.myDataGridViewDetails.Columns["料件id"].Visible = false;
            this.myDataGridViewDetails.Columns["报关产品表id"].Visible = false;

            this.myDataGridViewDetails.Columns["料件项号"].DisplayIndex = 0;
            this.myDataGridViewDetails.Columns["料件项号"].Width = 80;
            this.myDataGridViewDetails.Columns["料件名称及商编"].DisplayIndex = 1;
            this.myDataGridViewDetails.Columns["料件名称及商编"].Width = 150;
            this.myDataGridViewDetails.Columns["料件规格型号"].DisplayIndex = 2;
            this.myDataGridViewDetails.Columns["料件规格型号"].Width = 200;
            this.myDataGridViewDetails.Columns["明细表申报单位"].DisplayIndex = 3;
            this.myDataGridViewDetails.Columns["明细表申报单位"].HeaderText = "申报单位";
            this.myDataGridViewDetails.Columns["明细表申报单位"].Width = 80;
            this.myDataGridViewDetails.Columns["明细表法定单位"].DisplayIndex = 4;
            this.myDataGridViewDetails.Columns["明细表法定单位"].HeaderText = "法定单位";
            this.myDataGridViewDetails.Columns["明细表法定单位"].Width = 80;
            this.myDataGridViewDetails.Columns["备案净耗单位"].DisplayIndex = 5;
            this.myDataGridViewDetails.Columns["备案净耗单位"].Width = 120;
            this.myDataGridViewDetails.Columns["备案损耗"].DisplayIndex = 6;
            this.myDataGridViewDetails.Columns["备案损耗"].Width = 80;
            this.myDataGridViewDetails.Columns["变更净耗单位"].DisplayIndex = 7;
            this.myDataGridViewDetails.Columns["变更净耗单位"].Width = 120;
            this.myDataGridViewDetails.Columns["变更损耗"].DisplayIndex = 8;
            this.myDataGridViewDetails.Columns["变更损耗"].Width = 80;
            this.myDataGridViewDetails.Columns["归并前料件序号"].DisplayIndex = 9;
            this.myDataGridViewDetails.Columns["归并前料件序号"].Width = 120;
            this.myDataGridViewDetails.Columns["归并前净耗单位"].DisplayIndex = 10;
            this.myDataGridViewDetails.Columns["归并前净耗单位"].Width = 120;
            this.myDataGridViewDetails.Columns["归并前损耗"].DisplayIndex = 11;
            this.myDataGridViewDetails.Columns["归并前损耗"].Width = 100;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dataGridViewCellStyle1.Format = "F3";
            //dataGridViewCellStyle1.NullValue = null;
            //this.myDataGridViewDetails.Columns["数量"].DefaultCellStyle = dataGridViewCellStyle1;
            //this.myDataGridViewDetails.Columns["单价"].DefaultCellStyle = dataGridViewCellStyle1;
            //this.myDataGridViewDetails.Columns["总价"].DefaultCellStyle = dataGridViewCellStyle1;
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridViewDetails.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMenuDetails;
            }
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
                string strSQL = string.Format("select 手册资料表.手册编号, 报关产品表.* FROM 报关产品表 left join 手册资料表 on  报关产品表.手册id=手册资料表.手册id {0} {1} order by 手册资料表.手册编号,报关产品表.录入日期", gstrWhere.Length > 0 ? " where " : "", gstrWhere);
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
                SysMessage.ErrorMsg(string.Format("加载数据出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        /// <summary>
        /// 加载订单内容数据
        /// </summary>
        private void LoadDataSourceDetails()
        {
            try
            {
                int 报关产品表id = 0;
                if (this.myDataGridViewHead.CurrentRowNew != null)
                {
                    报关产品表id = (int)this.myDataGridViewHead.Rows[this.myDataGridViewHead.CurrentRowNew.Index].Cells["报关产品表id"].Value;
                }
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                dataAccess.Open();
                string strSQL = string.Format("SELECT * from 报关产品组成明细表 where 报关产品表id={0} ORDER BY 料件项号", 报关产品表id);
                DataTable dtDetails = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                DataTableTools.AddEmptyRow(dtDetails);
                this.myDataGridViewDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("加载出错，错误信息如下：{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        #endregion

        #region tools事件
        public override void tool1_First_Click(object sender, EventArgs e)
        {
            base.tool1_First_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[0].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[0].Cells["手册编号"];
            setTool1Enabled();
        }

        public override void tool1_up_Click(object sender, EventArgs e)
        {
            base.tool1_up_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow - 1].Cells["手册编号"];
            setTool1Enabled();

        }

        public override void tool1_Down_Click(object sender, EventArgs e)
        {
            base.tool1_Down_Click(sender, e);
            int iSelectRow = this.myDataGridViewHead.CurrentRow.Index;
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[iSelectRow + 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[iSelectRow + 1].Cells["手册编号"];
            setTool1Enabled();
        }

        public override void tool1_End_Click(object sender, EventArgs e)
        {
            base.tool1_End_Click(sender, e);
            this.myDataGridViewHead.ClearSelection();
            this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Selected = true;
            this.myDataGridViewHead.CurrentCell = this.myDataGridViewHead.Rows[this.myDataGridViewHead.RowCount - 1].Cells["手册编号"];
            setTool1Enabled();
        }

        public override void tool1_Query_Click(object sender, EventArgs e)
        {
            base.tool1_Query_Click(sender, e);
            FormCheckOutQueryCondition queryConditionForm = new FormCheckOutQueryCondition();
            if (queryConditionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gstrWhere = queryConditionForm.strReturnWhere;
                LoadDataSourceHead();
            }
        }

        public override void tool1_Import_Click(object sender, EventArgs e)
        {
            //base.tool1_Import_Click(sender, e);
            try
            {
                FormCheckOutImportSet objForm = new FormCheckOutImportSet();
                if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string date1 = objForm.date1;
                    string date2 = objForm.date2;
                    string 手册编号 = objForm.手册编号;
                    int 手册id = objForm.手册id;
                    IDataAccess dataAccessUniquegrade = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                    dataAccessUniquegrade.Open();
                    string strSQL = @"select top 0 * from 报关产品表
                                    select top 0 * from 报关产品组成明细表";
                    DataSet ds = dataAccessUniquegrade.GetDataSet(strSQL, null);
                    DataTable rs1 = ds.Tables[0];
                    DataTable rs2 = ds.Tables[1];
                    strSQL = string.Format(@"SELECT ZX.报关单号, S.手册id, ZXMX.客人型号, ZXMX.优丽型号, ZXMX.成品项号,ZXMX.成品名称及商编, ZXMX.成品规格型号, 
                                            ZXMX.单位 AS 产品表申报单位,'千克' AS 产品表法定单位, ZX.出货日期 AS 录入日期, ZXMX.归并前成品序号,ZXMX.订单号码,ZXMX.手册编号 
                                        FROM dbo.手册资料表 S RIGHT OUTER JOIN dbo.装箱单明细表 ZXMX ON S.手册编号 = ZXMX.手册编号 
                                        RIGHT OUTER JOIN dbo.装箱单表 ZX ON ZXMX.订单id = ZX.订单id 
                                        where S.手册id={0} and ZX.出货日期 >='{1}' ORDER BY ZX.出货日期", 手册id, date1);
                    DataTable mRsTemp = dataAccessUniquegrade.GetTable(strSQL, null);
                    dataAccessUniquegrade.Close();
                    if (mRsTemp.Rows.Count == 0) return;
                    int nn = 1;
                    int iCount = mRsTemp.Rows.Count;
                    string temp1, temp2;
                    //lab_ImportScale.Visible = true;
                    this.panel2.Visible = true;
                    this.progressBar1.Minimum = 0;
                    this.progressBar1.Maximum = iCount;
                    IDataAccess dataAccessManufacture = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                    foreach (DataRow mRsTempRow in mRsTemp.Rows)
                    {
                        temp1 = mRsTempRow["客人型号"].ToString();
                        temp2 = mRsTempRow["优丽型号"].ToString();
                        dataAccessManufacture.Open();
                        strSQL = string.Format(@"SELECT 报关订单表.手册编号,报关订单明细表.客人型号,报关订单明细表.优丽型号, 报关订单明细表.成品项号,报关订单明细表.版本号,
                                                报关订单表.订单号码 FROM 报关订单明细表 RIGHT OUTER JOIN 报关订单表 ON 报关订单明细表.订单id = 报关订单表.订单id 
                                            where 报关订单表.订单号码='{0}' and 报关订单表.手册编号='{1}' 
                                                    and 报关订单明细表.客人型号='{2}'and 报关订单明细表.优丽型号='{3}' and 
                                                    报关订单明细表.成品项号={4} and 报关订单明细表.版本号={5}",
                                                                                         mRsTempRow["订单号码"], 手册编号, temp1, temp2, 
                                                                                         mRsTempRow["成品项号"] == DBNull.Value ? 0 : mRsTempRow["成品项号"], mRsTempRow["归并前成品序号"]);
                        DataTable mRsTemp1 = dataAccessManufacture.GetTable(strSQL, null);
                        dataAccessManufacture.Close();
                        if (mRsTemp1.Rows.Count > 0)
                        {
                            foreach (DataRow mRsTempRow1 in mRsTemp1.Rows)
                            {
                                string filter = string.Format(@"手册id={0} and 客人型号='{1}'and 优丽型号='{2}' and 成品项号={3} and 归并前成品序号={4}",
                                                                手册id, temp1, temp2, mRsTempRow["成品项号"], mRsTempRow["归并前成品序号"]);
                                DataRow[] mRsTempRows = rs1.Select(filter);
                                if (mRsTempRows.Length == 0)
                                {
//                                    strSQL = string.Format(@"SELECT * FROM 报关产品表 where 手册id={0} and 客人型号={1}'and 优丽型号='{2}' 
//                                                            and 成品项号={3} and 归并前成品序号={4}",
//                                                            手册id, temp1, temp2, mRsTempRow["成品项号"], mRsTempRow["归并前成品序号"]);
                                    dataAccessUniquegrade.Open();
                                    strSQL = string.Format(@"SELECT * FROM 报关产品表 where 手册id={0} and 客人型号='{1}'and 优丽型号='{2}' 
                                                            and 成品项号={3} and 归并前成品序号={4}",
                                                            手册id, temp1, temp2, mRsTempRow["成品项号"], mRsTempRow["归并前成品序号"]);
                                    DataTable mRsTemp5 = dataAccessUniquegrade.GetTable(strSQL, null);
                                    if (mRsTemp5.Rows.Count > 0)
                                    {
                                        strSQL = string.Format(@"delete from 报关产品组成明细表 where 报关产品表id={0}
                                                                delete from 报关产品表 where 报关产品表id={0}", mRsTemp5.Rows[0]["报关产品表id"]);
                                    }
                                    dataAccessUniquegrade.ExecuteNonQuery(strSQL, null);
                                    //dataAccessUniquegrade.Close();
                                    /*
                                    DataRow rs1NewRow = rs1.NewRow();
                                    rs1NewRow["手册id"] = cManualCode;
                                    rs1NewRow["客人型号"] = mRsTempRow["客人型号"];
                                    rs1NewRow["优丽型号"] = mRsTempRow["优丽型号"];
                                    rs1NewRow["成品规格型号"] = mRsTempRow["成品规格型号"];
                                    rs1NewRow["产品表申报单位"] = mRsTempRow["产品表申报单位"];
                                    rs1NewRow["产品表法定单位"] = mRsTempRow["产品表法定单位"];
                                    rs1NewRow["录入日期"] = mRsTempRow["录入日期"];
                                    rs1NewRow["报关订单号"] = mRsTempRow["报关单号"];
                                    rs1NewRow["成品项号"] = mRsTempRow["成品项号"];
                                    rs1NewRow["成品名称及商编"] = mRsTempRow["成品名称及商编"];
                                    rs1NewRow["归并前成品序号"] = mRsTempRow["归并前成品序号"];
                                    rs1.update()
                                    */
                                    strSQL = string.Format(@"INSERT INTO [报关产品表]([手册id],[客人型号],[优丽型号],[成品项号],[成品名称及商编],[成品规格型号],[产品表申报单位],
                                                            [产品表法定单位],[归并前成品序号],[录入日期],[报关订单号])
                                                        VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})
                                                        select @@IDENTITY",
                                                             手册id, mRsTempRow["客人型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(mRsTempRow["客人型号"].ToString()),
                                                             mRsTempRow["优丽型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(mRsTempRow["优丽型号"].ToString()),
                                                             mRsTempRow["成品项号"] == DBNull.Value ? "NULL" : mRsTempRow["成品项号"],
                                                             mRsTempRow["成品名称及商编"] == DBNull.Value ? "NULL" : StringTools.SqlQ(mRsTempRow["成品名称及商编"].ToString()),
                                                             mRsTempRow["成品规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(mRsTempRow["成品规格型号"].ToString()),
                                                             mRsTempRow["产品表申报单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(mRsTempRow["产品表申报单位"].ToString()),
                                                             mRsTempRow["产品表法定单位"] == DBNull.Value ? "NULL" : StringTools.SqlQ(mRsTempRow["产品表法定单位"].ToString()),
                                                             mRsTempRow["归并前成品序号"] == DBNull.Value ? "NULL" : mRsTempRow["归并前成品序号"],
                                                             mRsTempRow["录入日期"] == DBNull.Value ? "NULL" : StringTools.SqlQ(mRsTempRow["录入日期"].ToString()),
                                                             mRsTempRow["报关单号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(mRsTempRow["报关单号"].ToString()));
                                    DataTable dtTemp1 = dataAccessUniquegrade.GetTable(strSQL, null);
                                    int i报关产品表ID = Convert.ToInt32(dtTemp1.Rows[0][0]);
                                    dataAccessUniquegrade.Close();

                                    dataAccessManufacture.Open();
                                    strSQL = string.Format(@"SELECT dbo.报关订单明细表.订单明细表id, dbo.报关订单明细表.订单id,dbo.报关订单明细表.产品id, dbo.报关订单明细表.配件id,
                                                            dbo.报关订单明细表.版本号, dbo.报关订单明细表.成品项号,dbo.报关订单表.订单号码,dbo.报关订单表.手册编号 
                                                        FROM dbo.报关订单明细表 RIGHT OUTER JOIN dbo.报关订单表 ON dbo.报关订单明细表.订单id = dbo.报关订单表.订单id 
                                                        where 报关订单表.订单号码='{0}' and dbo.报关订单明细表.版本号='{1}' and dbo.报关订单明细表.成品项号='{2}'",
                                                                mRsTempRow["订单号码"], mRsTempRow["归并前成品序号"], mRsTempRow["成品项号"]);
                                    DataTable mRsTemp4 = dataAccessManufacture.GetTable(strSQL, null);
                                    dataAccessManufacture.Close();
                                    if (mRsTemp4.Rows.Count > 0)
                                    {
                                        foreach (DataRow mRsTemp4Row in mRsTemp4.Rows)
                                        {
                                            strSQL = string.Format(@"归并后料件汇总明细 {0},{1},{2},{3},'{4}'",
                                            mRsTemp4Row["产品id"] == DBNull.Value ? "0" : mRsTemp4Row["产品id"], mRsTemp4Row["配件id"] == DBNull.Value ? "0" : mRsTemp4Row["配件id"],
                                            mRsTemp4Row["订单id"], mRsTemp4Row["订单明细表id"], mRsTemp4Row["手册编号"]);
                                            dataAccessManufacture.Open();
                                            DataTable mRsTemp2 = dataAccessManufacture.GetTable(strSQL, null);
                                            dataAccessManufacture.Close();
                                            if (mRsTemp2.Rows.Count > 0)
                                            {
                                                foreach (DataRow mRsTemp2Row in mRsTemp2.Rows)
                                                {
                                                    string c料件名称及商编 = string.Format("{0}/{1}", mRsTemp2Row["商品名称"].ToString(), mRsTemp2Row["商品编码"].ToString());
                                                    strSQL = string.Format(@"INSERT INTO [报关产品组成明细表]([报关产品表id],[料件项号],[料件名称及商编],[料件规格型号],
                                                                                [明细表申报单位],[明细表法定单位],[备案净耗单位],[备案损耗])
                                                                         VALUES({0},{1},{2},{3},{4},{5},{6},{7})",
                                                                                    i报关产品表ID, mRsTemp2Row["项号"] == DBNull.Value ? "NULL" : mRsTemp2Row["项号"],
                                                                                    StringTools.SqlQ( c料件名称及商编), 
                                                                                    mRsTemp2Row["规格型号"] == DBNull.Value ? "NULL" : StringTools.SqlQ(mRsTemp2Row["规格型号"].ToString()),
                                                                                    mRsTemp2Row["计量单位"] == DBNull.Value ? "NULL" :StringTools.SqlQ( mRsTemp2Row["计量单位"].ToString()), "'千克'",
                                                                                    (mRsTemp2Row["备案净耗单位"] == DBNull.Value ? 0 : Convert.ToDecimal(mRsTemp2Row["备案净耗单位"])).ToString("f5"),
                                                                                     mRsTemp2Row["损耗率"] == DBNull.Value ? "NULL" : mRsTemp2Row["损耗率"]);
                                                    dataAccessUniquegrade.Open();
                                                    dataAccessUniquegrade.ExecuteNonQuery(strSQL, null);
                                                    dataAccessUniquegrade.Close();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //提示正在处理数据的进度
                        lab_ImportScale.Text = string.Format("数据正在处理，请耐心等待，现已完成 {0}/{1}", nn, iCount);
                        this.progressBar1.Value = nn;

                        Application.DoEvents();
                        nn++;
                    }
                }
                LoadDataSourceHead();
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(ex.Message);
            }
            finally
            {
                //lab_ImportScale.Visible = false;
                this.panel2.Visible = false;
            }
        }

        public override void tool1_Add_Click(object sender, EventArgs e)
        {
            //base.tool1_Add_Click(sender, e);
            FormCheckOutInput objForm = new FormCheckOutInput();
            objForm.MdiParent = this.MdiParent;
            objForm.giOrderID = 0;
            objForm.Show();
        }

        public override void tool1_Modify_Click(object sender, EventArgs e)
        {
            bool bHave = false;
            int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["报关产品表id"].Value);
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormCheckOutInput")
                {
                    FormCheckOutInput inputForm = (FormCheckOutInput)childFrm;
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
                FormCheckOutInput objForm = new FormCheckOutInput();
                objForm.MdiParent = this.MdiParent;
                objForm.giOrderID = iOrderID;
                objForm.Show();
            }
        }

        public override void tool1_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.myDataGridViewHead.CurrentRow == null) return;
                int iOrderID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["报关产品表id"].Value);
                if (SysMessage.OKCancelMsg(string.Format("真的要删除 报关产品表id {0} 吗？", this.myDataGridViewHead.CurrentRow.Cells["报关产品表id"].Value)) == System.Windows.Forms.DialogResult.Cancel) return;

                IDataAccess data = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                data.Open();
                string strSQL = string.Format(@"delete from 报关产品表 where 报关产品表.报关产品表id={0}
                                                delete from 报关产品组成明细表 where 报关产品组成明细表.报关产品表id={0}",
                                                                                                  this.myDataGridViewHead.CurrentRow.Cells["报关产品表id"].Value);
                data.ExecuteNonQuery(strSQL,null);     
                data.Close();
                string strSuccess = string.Format("{0}[{1}]成功！", tool1_Delete.Text, this.myDataGridViewHead.CurrentRow.Cells["报关产品表id"].Value);
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

        public override void tool1_BOM_Click(object sender, EventArgs e)
        {
            base.tool1_BOM_Click(sender, e);
            /*
            #region 判断手册编号是否存在
            if (this.myDataGridViewDetails.RowCount == 0) return;
            #endregion

            #region 判断是否已经有打开的BOM窗体
            foreach (Form childFrm in this.MdiParent.MdiChildren)
            {
                if (childFrm.Name == "FormManualBOM")
                {
                    FormManualBOM orderBomForm = (FormManualBOM)childFrm;
                    if (orderBomForm.mIntID == Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["报关产品表"].Value)
                        && orderBomForm.mnPId == Convert.ToInt32(this.myDataGridViewDetails.CurrentRow.Cells["出口成品id"].Value))
                    {
                        childFrm.Activate();
                        return;
                    }
                }
            }
            #endregion

            #region 打开BOM窗体
            FormManualBOM formBOM = new FormManualBOM();
            formBOM.mIntID = Convert.ToInt32(this.myDataGridViewHead.CurrentRow.Cells["手册id"].Value);
            formBOM.mstrNo = this.myDataGridViewHead.CurrentRow.Cells["手册id"].Value.ToString();
            formBOM.mnPId = Convert.ToInt32(this.myDataGridViewDetails.CurrentRow.Cells["出口成品id"].Value);
            formBOM.mstrName = this.myDataGridViewDetails.CurrentRow.Cells["品名规格型号"].Value.ToString();
            formBOM.MdiParent = this.MdiParent;
            formBOM.Show();
            #endregion
             */
        }

        public override void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            base.tool1_ExportExcel_Click(sender, e);

            if (this.myDataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;
            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridViewDetails.DataSource, string.Empty);

        }

        public override void tool1_PrintView_Click(object sender, EventArgs e)
        {
            base.tool1_PrintView_Click(sender, e);
            if (this.myDataGridViewHead.CurrentRow == null) return;
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;
            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridViewDetails.DataSource, string.Empty);
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
            base.myDataGridViewHead_SelectionChanged(sender, e);
            if (bTriggerGridViewHead_SelectionChanged)
            {
                setTool1Enabled();
                LoadDataSourceDetails();
            }
        }
    }
}
