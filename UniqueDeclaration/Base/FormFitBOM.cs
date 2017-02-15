﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;
using UniqueDeclarationBaseForm.Controls;
using UniqueDeclarationBaseForm;

namespace UniqueDeclaration.Base
{
    public partial class FormFitBOM : UniqueDeclarationBaseForm.FormBase
    {
        public FormFitBOM()
        {
            InitializeComponent();
        }

        #region 外部调用传进来的变量值
        public int mnFId = 0;
        public bool mbShow = false;
        public string mstrName =string.Empty;
        public string mstrGroup= string.Empty;
        #endregion

        #region 自定义变量
        /// <summary>
        /// 料件组成数据集
        /// </summary>
        private DataTable dtMaterials = null;
        /// <summary>
        /// 配件组成数据集
        /// </summary>
        private DataTable dtFit = null;
        /// <summary>
        /// 料件明细数据集
        /// </summary>
        private DataTable dtMaterialsDetails = null;
        /// <summary>
        /// 报送材料明细数据集
        /// </summary>
        private DataTable dtDeclarationMaterialsDetails = null;
        /// <summary>
        /// 控制是否触发单元格回车事件，如果是回车事件后，指定到某个单元格，这种情况下就不再触发回车事件
        /// </summary>
        private bool bCellKeyPress = true;
        /// <summary>
        /// 是否触发单元格结束编辑事件
        /// </summary>
        private bool bCellEndEdit = true;
        #endregion

        #region 窗体事件
        private void FormFitBOM_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} 结构组成", mstrName);
            LoadDataSource();
            initGrid();
        }

        private void FormFitBOM_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }
        #endregion
        
        #region 初始化GRID方法
        /// <summary>
        /// 初始化GRID
        /// </summary>
        private void initGrid()
        {
            initGridMaterials();
            initGridFit();
            initGridDeclarationMaterialsDetails();
        }
        /// <summary>
        /// 料件组成GRID
        /// </summary>
        private void initGridMaterials()
        {
            //SELECT PZ.配件组成表id, PZ.料件组成id AS 组成id, L.料件型号 AS 型号, L.料件名 AS 品名, PZ.数量,PZ.损耗率,L.料件单位 as 单位,PZ.备注
            this.myDataGridViewMaterials.AutoGenerateColumns = false;
            this.myDataGridViewMaterials.Columns["配件组成表id"].Visible = false;
            this.myDataGridViewMaterials.Columns["组成id"].Visible = false;

            this.myDataGridViewMaterials.Columns["品名"].ReadOnly = true;
            this.myDataGridViewMaterials.Columns["单位"].ReadOnly = true;
            this.myDataGridViewMaterials.Columns["品名"].HeaderText = "料件名";
        }
        /// <summary>
        /// 配件组成GRID
        /// </summary>
        private void initGridFit()
        {
            //PZ.配件组成表id, PZ.配件组成id, P.配件型号, P.配件名, P.配件组别,PZ.数量, PZ.客户代码, PZ.备注, PZ.类别, PL.配件类别描述
            //SELECT PZ.配件组成表id, PZ.配件组成id AS 组成id, P.配件型号 AS 型号, P.配件名 AS 品名, P.配件组别,PZ.数量, PZ.客户代码, PZ.备注, PZ.类别, PL.配件类别描述 AS 类别描述
            this.myDataGridViewFit.AutoGenerateColumns = false;
            this.myDataGridViewFit.Columns["配件组成表id"].Visible = false;
            this.myDataGridViewFit.Columns["组成id"].Visible = false;
            this.myDataGridViewFit.Columns["类别"].Visible = false;
            this.myDataGridViewFit.AutoGenerateColumns = false;

            this.myDataGridViewFit.Columns["型号"].DisplayIndex = 0;
            this.myDataGridViewFit.Columns["品名"].DisplayIndex = 1;
            this.myDataGridViewFit.Columns["配件组别"].DisplayIndex = 2;
            this.myDataGridViewFit.Columns["数量"].DisplayIndex = 3;
            this.myDataGridViewFit.Columns["备注"].DisplayIndex = 4;
            this.myDataGridViewFit.Columns["客户代码"].DisplayIndex = 5;
            this.myDataGridViewFit.Columns["类别描述"].DisplayIndex = 6;

            this.myDataGridViewFit.Columns["品名"].HeaderText = "料件名";
            this.myDataGridViewFit.Columns["配件组别"].HeaderText = "组别";

            this.myDataGridViewFit.Columns["品名"].ReadOnly = true;
            this.myDataGridViewFit.Columns["配件组别"].ReadOnly = true;
        }
        /// <summary>
        /// 料件明细GRID（单独处理）
        /// </summary>
        private void initGridMaterialsDetails()
        {
            //[代号] ,[型号] ,[品名],[单位],[备注],[数量]
            this.myDataGridViewMaterialsDetails.AutoGenerateColumns = false;
            this.myDataGridViewMaterialsDetails.Columns["代号"].DisplayIndex = 0;
            this.myDataGridViewMaterialsDetails.Columns["型号"].DisplayIndex = 1;
            this.myDataGridViewMaterialsDetails.Columns["品名"].DisplayIndex = 2;
            this.myDataGridViewMaterialsDetails.Columns["数量"].DisplayIndex = 3;
            this.myDataGridViewMaterialsDetails.Columns["单位"].DisplayIndex = 4;
            this.myDataGridViewMaterialsDetails.Columns["备注"].DisplayIndex = 5;

            this.myDataGridViewMaterialsDetails.Columns["品名"].HeaderText = "料件名";
        }
        /// <summary>
        /// 报关材料明细GRID
        /// </summary>
        private void initGridDeclarationMaterialsDetails()
        {
            //SELECT 产品配件报关材料表id, 配件id,序号,报关类别, 数量, 单位, 备注
            this.myDataGridViewDeclarationMaterialsDetails.AutoGenerateColumns = false;
            this.myDataGridViewDeclarationMaterialsDetails.Columns["产品配件报关材料表id"].Visible = false;
            this.myDataGridViewDeclarationMaterialsDetails.Columns["配件id"].Visible = false;
            this.myDataGridViewDeclarationMaterialsDetails.Columns["报关类别"].ReadOnly = true;
            this.myDataGridViewDeclarationMaterialsDetails.Columns["单位"].ReadOnly = true;
        }
        #endregion

        #region 加载数据方法
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadDataSource()
        {
            LoadDataSourceMaterials();
            LoadDataSourceFit();
            LoadDataSourceDeclarationMaterialsDetails();
            string strSQL = string.Format("select 明细备注,实际总重 from 配件资料表 where 配件id={0}",mnFId);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count > 0)
            {
                txt_明细备注.Text = dtData.Rows[0]["明细备注"].ToString();
                txt_实际总重.Text = dtData.Rows[0]["实际总重"].ToString();
            }
        }
        /// <summary>
        /// 加载料件组成
        /// </summary>
        private void LoadDataSourceMaterials()
        {
            //string strSQL = string.Format("SELECT * FROM 配件组成表 WHERE 配件组成表.配件id = {0}",mnFId);
            string strSQL = string.Format(@"SELECT PZ.配件组成表id, PZ.料件组成id AS 组成id, L.料件型号 AS 型号, L.料件名 AS 品名, PZ.数量,PZ.损耗率,L.料件单位 as 单位,PZ.备注
                                            FROM 配件组成表 PZ INNER JOIN 料件资料表 L ON L.料件id = PZ.料件组成id WHERE PZ.配件id ={0}", mnFId);
//            string strSQL = string.Format(@"SELECT PZ.配件组成表id, PZ.料件组成id, L.料件型号, L.料件名, PZ.数量,PZ.损耗率,L.料件单位,PZ.备注
//                                            FROM 配件组成表 PZ INNER JOIN 料件资料表 L ON L.料件id = PZ.料件组成id WHERE PZ.配件id ={0}", mnFId);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtMaterials = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtMaterials.Rows.Count == 0)
                DataTableTools.AddEmptyRow(dtMaterials);
            this.myDataGridViewMaterials.DataSource = dtMaterials;
        }
        /// <summary>
        /// 加载配件组成
        /// </summary>
        private void LoadDataSourceFit()
        {
            string strSQL = string.Format(@"SELECT PZ.配件组成表id, PZ.配件组成id AS 组成id, P.配件型号 AS 型号, P.配件名 AS 品名, P.配件组别,PZ.数量, PZ.客户代码, PZ.备注, PZ.类别, PL.配件类别描述 AS 类别描述
                                            FROM (配件组成表 PZ LEFT OUTER JOIN 配件类别表 PL ON PL.配件类别 = PZ.类别)
                                                INNER JOIN 配件资料表 P ON P.配件id = PZ.配件组成id 
                                                WHERE PZ.配件id = {0}", mnFId);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtFit = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtFit.Rows.Count == 0)
                DataTableTools.AddEmptyRow(dtFit);
            this.myDataGridViewFit.DataSource = dtFit;
        }
        /// <summary>
        /// 加载料件明细（单独处理，切换TAB时才加载）
        /// </summary>
        private void LoadDataSourceMaterialsDetails()
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtMaterialsDetails = dataAccess.GetTable("select * from 料件组成打印虚表 where 代号<1", null);
            dataAccess.Close();
            string strSQL = string.Empty;
            long n = 0;
            foreach (DataRow fitRow in dtFit.Rows)
            {
                if (fitRow.RowState == DataRowState.Deleted) continue;
                if (fitRow["组成id"] == DBNull.Value) continue;
                DataRow newRow = dtMaterialsDetails.NewRow();
                newRow["型号"] = string.Format("配件:{0}  X{1}", fitRow["型号"], fitRow["数量"]);
                newRow["品名"] = string.Format("组别:{0}", fitRow["配件组别"]);
                dtMaterialsDetails.Rows.Add(newRow);
                strSQL = string.Format(@"SELECT  料件资料表.料件型号, 料件资料表.料件名, 配件组成表.数量,配件组成表.损耗率,
                    料件资料表.料件单位,配件组成表.备注, 配件组成表.配件组成id, 配件组成表.配件组成表id, 配件资料表.配件型号,配件资料表.配件组别 FROM 配件组成表 
                    LEFT OUTER JOIN 配件资料表 ON 配件组成表.配件组成id = 配件资料表.配件id LEFT OUTER JOIN 料件资料表 ON 
                    配件组成表.料件组成id = 料件资料表.料件id WHERE 配件组成表.配件id ={0} order by 配件组成id,配件组成表id", fitRow["组成id"]);
                dataAccess.Open();
                DataTable rs0 = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                foreach (DataRow rs0Row in rs0.Rows)
                {
                    if (rs0Row["料件型号"] == DBNull.Value || rs0Row["料件型号"].ToString() == "")
                    {
                        DataRow newRow0 = dtMaterialsDetails.NewRow();
                        n++;
                        newRow0["代号"] = n;
                        newRow0["型号"] = string.Format("  {0}", rs0Row["料件型号"]);
                        newRow0["品名"] = rs0Row["料件名"];
                        newRow0["数量"] = rs0Row["数量"];
                        //newRow0["损耗率"] = rs0Row["损耗率"];
                        newRow0["单位"] = rs0Row["料件单位"];
                        newRow0["备注"] = rs0Row["备注"];
                        dtMaterialsDetails.Rows.Add(newRow0);
                    }
                    else
                    {
                        DataRow newRow0 = dtMaterialsDetails.NewRow();
                        newRow0["型号"] = string.Format("  配件:{0}  X{1}", rs0Row["配件型号"], rs0Row["数量"]);
                        newRow0["品名"] = string.Format("组别:{0}", rs0Row["配件组别"]);
                        dtMaterialsDetails.Rows.Add(newRow0);
                        strSQL = string.Format(@"SELECT  料件资料表.料件型号, 料件资料表.料件名, 配件组成表.数量,配件组成表.损耗率,
                        料件资料表.料件单位,配件组成表.备注, 配件组成表.配件组成id, 配件组成表.配件组成表id, 配件资料表.配件型号,配件资料表.配件组别 FROM 配件组成表
                        LEFT OUTER JOIN 配件资料表 ON 配件组成表.配件组成id = 配件资料表.配件id LEFT OUTER JOIN 料件资料表 ON 
                        配件组成表.料件组成id = 料件资料表.料件id WHERE 配件组成表.配件id ={0} order by 配件组成id,配件组成表id",rs0Row["配件组成id"]);
                        dataAccess.Open();
                        DataTable rs1 = dataAccess.GetTable(strSQL, null);
                        dataAccess.Close();
                        foreach (DataRow rs1Row in rs1.Rows)
                        {
                            if (rs1Row["料件型号"] == DBNull.Value || rs1Row["料件型号"].ToString() == "")
                            {
                                DataRow newRow1 = dtMaterialsDetails.NewRow();
                                n++;
                                newRow1["代号"] = n;
                                newRow1["型号"] = string.Format("    {0}", rs1Row["料件型号"]);
                                newRow1["品名"] = rs1Row["料件名"];
                                newRow1["数量"] = rs1Row["数量"];
                                //newRow1["损耗率"] = rs1Row["损耗率"];
                                newRow1["单位"] = rs1Row["料件单位"];
                                newRow1["备注"] = rs1Row["备注"];
                                dtMaterialsDetails.Rows.Add(newRow1);
                            }
                            else
                            {
                                DataRow newRow1 = dtMaterialsDetails.NewRow();
                                newRow1["型号"] = string.Format("    配件:{0}  X{1}", rs1Row["配件型号"], rs1Row["数量"]);
                                newRow1["品名"] = string.Format("组别:{0}", rs1Row["配件组别"]);
                                dtMaterialsDetails.Rows.Add(newRow1);
                                strSQL = string.Format(@"SELECT  料件资料表.料件型号, 料件资料表.料件名, 配件组成表.数量,配件组成表.损耗率,
                                    料件资料表.料件单位,配件组成表.备注, 配件组成表.配件组成id, 配件组成表.配件组成表id, 配件资料表.配件型号,配件资料表.配件组别 FROM 配件组成表 
                                    LEFT OUTER JOIN 配件资料表 ON 配件组成表.配件组成id = 配件资料表.配件id LEFT OUTER JOIN 料件资料表 ON 
                                    配件组成表.料件组成id = 料件资料表.料件id WHERE 配件组成表.配件id ={0} order by 配件组成id,配件组成表id", rs1Row["配件组成id"]);
                                dataAccess.Open();
                                DataTable rs2 = dataAccess.GetTable(strSQL, null);
                                dataAccess.Close();
                                foreach (DataRow rs2Row in rs2.Rows)
                                {
                                    if (rs2Row["料件型号"] == DBNull.Value || rs2Row["料件型号"].ToString() == "")
                                    {
                                        DataRow newRow2 = dtMaterialsDetails.NewRow();
                                        n++;
                                        newRow2["代号"] = n;
                                        newRow2["型号"] = string.Format("      {0}", rs2Row["料件型号"]);
                                        newRow2["品名"] = rs2Row["料件名"];
                                        newRow2["数量"] = rs2Row["数量"];
                                       //newRow2["损耗率"] = rs2Row["损耗率"];
                                        newRow2["单位"] = rs2Row["料件单位"];
                                        newRow2["备注"] = rs2Row["备注"];
                                        dtMaterialsDetails.Rows.Add(newRow2);
                                    }
                                    else
                                    {
                                        DataRow newRow2 = dtMaterialsDetails.NewRow();
                                        newRow2["型号"] = string.Format("    配件:{0}  X{1}", rs2Row["配件型号"], rs2Row["数量"]);
                                        newRow2["品名"] = string.Format("组别:{0}", rs2Row["配件组别"]);
                                        dtMaterialsDetails.Rows.Add(newRow2);
                                        strSQL = string.Format(@"SELECT  料件资料表.料件型号, 料件资料表.料件名, 配件组成表.数量,配件组成表.损耗率,
                                            料件资料表.料件单位,配件组成表.备注, 配件组成表.配件组成id, 配件组成表.配件组成表id, 配件资料表.配件型号,配件资料表.配件组别 FROM 配件组成表 
                                            LEFT OUTER JOIN 配件资料表 ON 配件组成表.配件组成id = 配件资料表.配件id LEFT OUTER JOIN 料件资料表 ON 
                                            配件组成表.料件组成id = 料件资料表.料件id WHERE 配件组成表.配件id = {0} order by 配件组成id,配件组成表id", rs2Row["配件组成id"]);
                                        dataAccess.Open();
                                        DataTable rs3 = dataAccess.GetTable(strSQL, null);
                                        dataAccess.Close();
                                        foreach (DataRow rs3Row in rs3.Rows)
                                        {
                                            if (rs3Row["料件型号"] == DBNull.Value || rs3Row["料件型号"].ToString() == "")
                                            {
                                                DataRow newRow3 = dtMaterialsDetails.NewRow();
                                                n++;
                                                newRow3["代号"] = n;
                                                newRow3["型号"] = string.Format("        {0}", rs3Row["料件型号"]);
                                                newRow3["品名"] = rs3Row["料件名"];
                                                newRow3["数量"] = rs3Row["数量"];
                                                //newRow3["损耗率"] = rs3Row["损耗率"];
                                                newRow3["单位"] = rs3Row["料件单位"];
                                                newRow3["备注"] = rs3Row["备注"];
                                                dtMaterialsDetails.Rows.Add(newRow3);
                                            }
                                            else
                                            {
                                                DataRow newRow3 = dtMaterialsDetails.NewRow();
                                                newRow3["型号"] = string.Format("      配件:{0}  X{1}", rs3Row["配件型号"], rs3Row["数量"]);
                                                newRow3["品名"] = string.Format("组别:{0}", rs3Row["配件组别"]);
                                                dtMaterialsDetails.Rows.Add(newRow3);
                                                strSQL = string.Format(@"SELECT  料件资料表.料件型号, 料件资料表.料件名, 配件组成表.数量,配件组成表.损耗率,
                                                    料件资料表.料件单位,配件组成表.备注, 配件组成表.配件组成id, 配件组成表.配件组成表id, 配件资料表.配件型号,配件资料表.配件组别 FROM 配件组成表 
                                                    LEFT OUTER JOIN 配件资料表 ON 配件组成表.配件组成id = 配件资料表.配件id LEFT OUTER JOIN 料件资料表 ON 
                                                    配件组成表.料件组成id = 料件资料表.料件id WHERE 配件组成表.配件id ={0} order by 配件组成id,配件组成表id", rs3Row["配件组成id"]);
                                                dataAccess.Open();
                                                DataTable rs4 = dataAccess.GetTable(strSQL, null);
                                                dataAccess.Close();
                                                foreach (DataRow rs4Row in rs4.Rows)
                                                {
                                                    if (rs4Row["料件型号"] == DBNull.Value || rs4Row["料件型号"].ToString() == "")
                                                    {
                                                        DataRow newRow4 = dtMaterialsDetails.NewRow();
                                                        n++;
                                                        newRow4["代号"] = n;
                                                        newRow4["型号"] = string.Format("          {0}", rs4Row["料件型号"]);
                                                        newRow4["品名"] = rs4Row["料件名"];
                                                        newRow4["数量"] = rs4Row["数量"];
                                                        //newRow4["损耗率"] = rs4Row["损耗率"];
                                                        newRow4["单位"] = rs4Row["料件单位"];
                                                        newRow4["备注"] = rs4Row["备注"];
                                                        dtMaterialsDetails.Rows.Add(newRow4);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (dtMaterials.Rows.Count > 0)
            {
                DataRow newRow = dtMaterialsDetails.NewRow();
                newRow["型号"] = "料件：";
                dtMaterialsDetails.Rows.Add(newRow);
                foreach (DataRow row in dtMaterials.Rows)
                {
                    DataRow newRow0 = dtMaterialsDetails.NewRow();
                    n++;
                    newRow0["代号"] = n;
                    newRow0["型号"] = row["型号"];
                    newRow0["品名"] = row["品名"];
                    newRow0["数量"] = row["数量"];
                    //newRow0损耗率"] = row["损耗率"];
                    newRow0["单位"] = row["单位"];
                    newRow0["备注"] = row["备注"];
                    dtMaterialsDetails.Rows.Add(newRow0);
                }

            }
            if (dtMaterialsDetails.Rows.Count == 0)
                DataTableTools.AddEmptyRow(dtMaterialsDetails);
            this.myDataGridViewMaterialsDetails.DataSource = dtMaterialsDetails;
            initGridMaterialsDetails();
        }
        /// <summary>
        /// 加载报关材料明细
        /// </summary>
        private void LoadDataSourceDeclarationMaterialsDetails()
        {
            string strSQL = string.Format(@"SELECT 产品配件报关材料表id, 配件id,序号,报关类别, 数量, 单位, 备注 FROM 产品配件报关材料表 where 配件id= {0}", mnFId);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtDeclarationMaterialsDetails = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtDeclarationMaterialsDetails.Rows.Count == 0)
                dtDeclarationMaterialsDetailsAddRow();
            this.myDataGridViewDeclarationMaterialsDetails.DataSource = dtDeclarationMaterialsDetails;
        }
        #endregion

        #region 保存数据方法

        private void Save()
        {
            SaveMaterials();
            SaveFit();
            SaveDeclarationMaterialsDetails();
            SaveFitFiled();
        }
        /// <summary>
        /// 料件组成
        /// </summary>
        private void SaveMaterials()
        {

        }
        /// <summary>
        /// 配件组成
        /// </summary>
        private void SaveFit()
        {

        }
        /// <summary>
        /// 报关材料明细
        /// </summary>
        private void SaveDeclarationMaterialsDetails()
        {

        }
        /// <summary>
        /// 保存明细备注，实际总重
        /// </summary>
        private void SaveFitFiled()
        {

        }
        #endregion

        #region myDataGridViewMaterials

        private void myDataGridViewMaterials_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridViewMaterialsKeyEnter(dgv, cell, false);
        }

        private void myDataGridViewMaterials_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == SystemConst.GridKeysEnter)
            {
                myDataGridView dgv = sender as myDataGridView;
                DataGridViewCell cell = dgv.CurrentCell;

                GridViewMaterialsKeyEnter(dgv, cell, true);
            }  
        }

        private void myDataGridViewMaterials_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            myDataGridView dgv = (myDataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "数量" || colName == "耗损率")
                e.Cancel = false;
        }
        
        /// <summary>
        /// GRID的回车事件
        /// </summary>
        /// <param name="dgv">Grid对象</param>
        /// <param name="cell">焦点CELL</param>
        /// <param name="bKeyEnter">是否按回车触发的事件</param>
        private void GridViewMaterialsKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
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
                        else if (validate型号Materials(dgv, cell))
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
                            validate型号Materials(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "数量":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (StringTools.decimalParse(dgv.CurrentRow.Cells["数量"].Value.ToString()) == StringTools.decimalParse(cell.EditedFormattedValue.ToString()))
                        {
                            dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                        }
                        else
                        {
                            validate数量Materials(dgv, cell);
                            //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                            bCellEndEdit = true;
                            //SaveModifyAfterHead();
                        }
                    }
                    else
                    {
                        if (StringTools.decimalParse(dgv.CurrentRow.Cells["数量"].Value.ToString()) != StringTools.decimalParse(cell.EditedFormattedValue.ToString()))
                        {
                            validate数量Materials(dgv, cell);
                            //SaveModifyAfterHead();
                        }
                    }
                    #endregion
                    break;
                case "损耗率":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (StringTools.decimalParse(dgv.CurrentRow.Cells["损耗率"].Value.ToString()) == StringTools.decimalParse(cell.EditedFormattedValue.ToString()))
                        {
                            dgv.CurrentCell = dgv["损耗率", cell.RowIndex];
                        }
                        else
                        {
                            validate损耗率Materials(dgv, cell);
                            //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                            bCellEndEdit = true;
                            //SaveModifyAfterHead();
                        }
                    }
                    else
                    {
                        if (StringTools.decimalParse(dgv.CurrentRow.Cells["损耗率"].Value.ToString()) != StringTools.decimalParse(cell.EditedFormattedValue.ToString()))
                        {
                            validate损耗率Materials(dgv, cell);
                            //SaveModifyAfterHead();
                        }
                    }
                    #endregion
                    break;
                case "备注":
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
                                DataTableTools.AddEmptyRow(dtMaterials,false);
                                dgv.CurrentCell = dgv["型号", cell.RowIndex + 1];
                            }
                            else
                            {
                                dgv.CurrentCell = dgv["型号", cell.RowIndex + 1];
                            }
                        }
                    }
                    #endregion
                    break;
            }
        }
        /// <summary>
        /// 验证型号
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        private bool validate型号Materials(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Format("帮助录入查询 {0},3 , 0, 0, 0, '',''", StringTools.SqlQ(cell.EditedFormattedValue.ToString()));
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count == 1)
            {
                DataRow row = dtData.Rows[0];
                dgv.Rows[cell.RowIndex].Cells["组成id"].Value = row["料件id"];
                dgv.Rows[cell.RowIndex].Cells["型号"].Value = row["料件型号"];
                dgv.Rows[cell.RowIndex].Cells["品名"].Value = row["料件名"];
                dgv.Rows[cell.RowIndex].Cells["单位"].Value = row["料件单位"];
            }
            else if (dtData.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择料件";
                formSelect.dtData = dtData;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dgv.Rows[cell.RowIndex].Cells["组成id"].Value = formSelect.returnRow["料件id"];
                    dgv.Rows[cell.RowIndex].Cells["型号"].Value = formSelect.returnRow["料件型号"];
                    dgv.Rows[cell.RowIndex].Cells["品名"].Value = formSelect.returnRow["料件名"];
                    dgv.Rows[cell.RowIndex].Cells["单位"].Value = formSelect.returnRow["料件单位"];
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
                dgv.CurrentCell = dgv[cell.ColumnIndex, cell.RowIndex];  // cell;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 验证数量
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private void validate数量Materials(myDataGridView dgv, DataGridViewCell cell)
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
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = 0;
                }
            }
        }
        /// <summary>
        /// 验证损耗率
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private void validate损耗率Materials(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = 0;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = 0;
                }
            }
        }

        #endregion

        #region myDataGridViewFit

        private void myDataGridViewFit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridViewFitKeyEnter(dgv, cell, false);
        }

        private void myDataGridViewFit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == SystemConst.GridKeysEnter)
            {
                myDataGridView dgv = sender as myDataGridView;
                DataGridViewCell cell = dgv.CurrentCell;

                GridViewFitKeyEnter(dgv, cell, true);
            }
        }

        private void myDataGridViewFit_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            myDataGridView dgv = (myDataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "数量")
                e.Cancel = false;
        }

        /// <summary>
        /// GRID的回车事件
        /// </summary>
        /// <param name="dgv">Grid对象</param>
        /// <param name="cell">焦点CELL</param>
        /// <param name="bKeyEnter">是否按回车触发的事件</param>
        private void GridViewFitKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
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
                        else if (validate型号Fit(dgv, cell))
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
                            validate型号Fit(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "数量":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (StringTools.decimalParse(dgv.CurrentRow.Cells["数量"].Value.ToString()) == StringTools.decimalParse(cell.EditedFormattedValue.ToString()))
                        {
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                        }
                        else
                        {
                            validate数量Fit(dgv, cell);
                            //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                            bCellEndEdit = true;
                            //SaveModifyAfterHead();
                        }
                    }
                    else
                    {
                        if (StringTools.decimalParse(dgv.CurrentRow.Cells["数量"].Value.ToString()) != StringTools.decimalParse(cell.EditedFormattedValue.ToString()))
                        {
                            validate数量Fit(dgv, cell);
                            //SaveModifyAfterHead();
                        }
                    }
                    #endregion
                    break;
                case "备注":
                    #region CELL回车跳转
                    dgv.CurrentCell = dgv["客户代码", cell.RowIndex];
                    #endregion
                    break;
                case "客户代码":
                    #region CELL回车跳转
                    dgv.CurrentCell = dgv["类别描述", cell.RowIndex];
                    #endregion
                    break;
                case "类别描述":
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
                                DataTableTools.AddEmptyRow(dtFit, false);
                                dgv.CurrentCell = dgv["型号", cell.RowIndex + 1];
                            }
                            else
                            {
                                dgv.CurrentCell = dgv["型号", cell.RowIndex + 1];
                            }
                        }
                    }
                    #endregion
                    break;
            }
        }
        /// <summary>
        /// 验证型号
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        private bool validate型号Fit(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Format("帮助录入查询 {0},2 , 0, 0, 0, '',''", StringTools.SqlQ(cell.EditedFormattedValue.ToString()));
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count == 1)
            {
                DataRow row = dtData.Rows[0];
                dgv.Rows[cell.RowIndex].Cells["组成id"].Value = row["配件id"];
                dgv.Rows[cell.RowIndex].Cells["型号"].Value = row["配件型号"];
                dgv.Rows[cell.RowIndex].Cells["品名"].Value = row["配件名"];
                dgv.Rows[cell.RowIndex].Cells["配件组别"].Value = row["配件组别"];
            }
            else if (dtData.Rows.Count > 1)
            {
                FormBaseSingleSelect formSelect = new FormBaseSingleSelect();
                formSelect.strFormText = "选择配件";
                formSelect.dtData = dtData;
                if (formSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dgv.Rows[cell.RowIndex].Cells["组成id"].Value = formSelect.returnRow["配件id"];
                    dgv.Rows[cell.RowIndex].Cells["型号"].Value = formSelect.returnRow["配件型号"];
                    dgv.Rows[cell.RowIndex].Cells["品名"].Value = formSelect.returnRow["配件名"];
                    dgv.Rows[cell.RowIndex].Cells["配件组别"].Value = formSelect.returnRow["配件组别"];
                }
                else
                {
                    dgv.CurrentCell = cell;
                    return false;
                }
            }
            else
            {
                SysMessage.InformationMsg("此配件不存在！");
                dgv.CurrentCell = dgv[cell.ColumnIndex, cell.RowIndex];  // cell;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 验证数量
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private void validate数量Fit(myDataGridView dgv, DataGridViewCell cell)
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
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = 0;
                }
            }
        }
        /// <summary>
        /// 验证损耗率
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private void validate损耗率Fit(myDataGridView dgv, DataGridViewCell cell)
        {
            if (cell.EditedFormattedValue.ToString() == "")
            {
                dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = 0;
            }
            else
            {
                try
                {
                    decimal.Parse(cell.EditedFormattedValue.ToString());
                    dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["损耗率"].Value = 0;
                }
            }
        }

        #endregion

        #region myDataGridViewDeclarationMaterialsDetails

        private void myDataGridViewDeclarationMaterialsDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!bCellEndEdit) return;
            myDataGridView dgv = sender as myDataGridView;
            DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
            GridViewDeclarationMaterialsDetailsKeyEnter(dgv, cell, false);
        }

        private void myDataGridViewDeclarationMaterialsDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == SystemConst.GridKeysEnter)
            {
                myDataGridView dgv = sender as myDataGridView;
                DataGridViewCell cell = dgv.CurrentCell;

                GridViewDeclarationMaterialsDetailsKeyEnter(dgv, cell, true);
            }
        }

        private void myDataGridViewDeclarationMaterialsDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            myDataGridView dgv = (myDataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "数量" || colName == "耗损率")
                e.Cancel = false;
        }

        /// <summary>
        /// GRID的回车事件
        /// </summary>
        /// <param name="dgv">Grid对象</param>
        /// <param name="cell">焦点CELL</param>
        /// <param name="bKeyEnter">是否按回车触发的事件</param>
        private void GridViewDeclarationMaterialsDetailsKeyEnter(myDataGridView dgv, DataGridViewCell cell, bool bKeyEnter)
        {
            if (!bCellKeyPress) return;
            string colName = dgv.Columns[cell.ColumnIndex].Name;
            switch (colName)
            {
                case "序号": 
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (dgv.CurrentRow.Cells["序号"].Value.ToString() == cell.EditedFormattedValue.ToString())
                        {
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["数量", cell.RowIndex];
                            bCellEndEdit = true;
                        }
                        else if (validate序号DeclarationMaterialsDetails(dgv, cell))
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
                        if (dgv.CurrentRow.Cells["序号"].Value.ToString() != cell.EditedFormattedValue.ToString())
                        {
                            validate序号DeclarationMaterialsDetails(dgv, cell);
                        }
                    }
                    #endregion
                    break;
                case "数量":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        if (StringTools.decimalParse(dgv.CurrentRow.Cells["数量"].Value.ToString()) == StringTools.decimalParse(cell.EditedFormattedValue.ToString()))
                        {
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                        }
                        else
                        {
                            validate数量DeclarationMaterialsDetails(dgv, cell);
                            //dtModifyAfterHead.Rows[cell.RowIndex].EndEdit();
                            (dgv.CurrentRow.DataBoundItem as DataRowView).Row.EndEdit();
                            bCellEndEdit = false;
                            dgv.CurrentCell = dgv["备注", cell.RowIndex];
                            bCellEndEdit = true;
                            //SaveModifyAfterHead();
                        }
                    }
                    else
                    {
                        if (StringTools.decimalParse(dgv.CurrentRow.Cells["数量"].Value.ToString()) != StringTools.decimalParse(cell.EditedFormattedValue.ToString()))
                        {
                            validate数量DeclarationMaterialsDetails(dgv, cell);
                            //SaveModifyAfterHead();
                        }
                    }
                    #endregion
                    break;
                case "备注":
                    #region CELL回车跳转
                    if (bKeyEnter)
                    {
                        //如果当前行的客人型号为空，则跳转到当前行的客人型号
                        if (dgv.Rows[cell.RowIndex].Cells["序号"].Value == DBNull.Value
                            || dgv.Rows[cell.RowIndex].Cells["序号"].Value.ToString().Trim() == "")
                        {
                            dgv.CurrentCell = dgv["序号", cell.RowIndex];
                        }
                        else
                        {
                            //否则跳转到下一行的客人型号，如果是最后一行，则新增一行
                            if (cell.RowIndex == dgv.Rows.Count - 1)
                            {
                                dtDeclarationMaterialsDetailsAddRow();
                                dgv.CurrentCell = dgv["序号", cell.RowIndex + 1];
                            }
                            else
                            {
                                dgv.CurrentCell = dgv["序号", cell.RowIndex + 1];
                            }
                        }
                    }
                    #endregion
                    break;
            }
        }
        /// <summary>
        /// 验证型号
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        private bool validate序号DeclarationMaterialsDetails(myDataGridView dgv, DataGridViewCell cell)
        {
            string strSQL = string.Format("SELECT 序号, 商品编码, 商品名称, 商品规格,计量单位 From 归并后料件清单 where 序号={0}", StringTools.SqlQ(cell.EditedFormattedValue.ToString()));
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            if (dtData.Rows.Count > 1)
            {
                dgv.Rows[cell.RowIndex].Cells["序号"].Value = dtData.Rows[0]["序号"];
                dgv.Rows[cell.RowIndex].Cells["报关类别"].Value = dtData.Rows[0]["商品名称"];
            }
            else
            {
                SysMessage.InformationMsg("此序号不存在！");
                dgv.CurrentCell = dgv[cell.ColumnIndex, cell.RowIndex];  // cell;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 验证数量
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private void validate数量DeclarationMaterialsDetails(myDataGridView dgv, DataGridViewCell cell)
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
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = Convert.ToDecimal(cell.EditedFormattedValue);
                }
                catch
                {
                    dgv.Rows[cell.RowIndex].Cells["数量"].Value = 0;
                }
            }
        }

        /// <summary>
        /// 改样后表头GRID增加一条新行
        /// </summary>
        private void dtDeclarationMaterialsDetailsAddRow()
        {
            DataRow newRow = dtDeclarationMaterialsDetails.NewRow();
            newRow["单位"] = "KGS";
            newRow["配件id"] = mnFId;
            dtDeclarationMaterialsDetails.Rows.Add(newRow);
        }
        #endregion

        #region 控件事件
        private void myTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myTabControl1.SelectedIndex == 1)
            {
                LoadDataSourceMaterialsDetails();
            }
        }
        //删除TAB0的料件组成
        private void btnDeleteMaterials_Click(object sender, EventArgs e)
        {
            if(myDataGridViewMaterials.CurrentRow!=null)
                this.myDataGridViewMaterials.Rows.Remove(this.myDataGridViewMaterials.CurrentRow);
        }
        //删除TAB0的配件组成
        private void btnDeleteFit_Click(object sender, EventArgs e)
        {
            if (myDataGridViewFit.CurrentRow != null)
                this.myDataGridViewFit.Rows.Remove(this.myDataGridViewFit.CurrentRow);
        }
        //删除TAB2的报关料件明细
        private void btnDeleteDeclarationMaterialsDetails_Click(object sender, EventArgs e)
        {
            if (myDataGridViewDeclarationMaterialsDetails.CurrentRow != null)
                this.myDataGridViewDeclarationMaterialsDetails.Rows.Remove(this.myDataGridViewDeclarationMaterialsDetails.CurrentRow);
        }
        #endregion

    }
}
