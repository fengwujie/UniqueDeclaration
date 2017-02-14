using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;

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
        #endregion

        #region 窗体事件
        private void FormFitBOM_Load(object sender, EventArgs e)
        {
            LoadDataSource();
            initGrid();
        }

        private void FormFitBOM_FormClosing(object sender, FormClosingEventArgs e)
        {

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
            //PZ.配件组成表id, PZ.料件组成id, L.料件型号, L.料件名, PZ.数量,PZ.损耗率,L.料件单位,PZ.备注
            this.myDataGridViewMaterials.AutoGenerateColumns = false;
            this.myDataGridViewMaterials.Columns["配件组成表id"].Visible = false;
            this.myDataGridViewMaterials.Columns["料件组成id"].Visible = false;

            this.myDataGridViewMaterials.Columns["料件型号"].HeaderText = "型号";
            this.myDataGridViewMaterials.Columns["料件单位"].HeaderText = "单位";
        }
        /// <summary>
        /// 配件组成GRID
        /// </summary>
        private void initGridFit()
        {
            //PZ.配件组成表id, PZ.配件组成id, P.配件型号, P.配件名, P.配件组别,PZ.数量, PZ.客户代码, PZ.备注, PZ.类别, PL.配件类别描述
            this.myDataGridViewFit.AutoGenerateColumns = false;
            this.myDataGridViewFit.Columns["配件组成表id"].Visible = false;
            this.myDataGridViewFit.Columns["配件组成id"].Visible = false;

            this.myDataGridViewFit.Columns["配件型号"].HeaderText = "型号";
            this.myDataGridViewFit.Columns["配件组别"].HeaderText = "组别";
            this.myDataGridViewFit.Columns["配件类别描述"].HeaderText = "类别描述";
        }
        /// <summary>
        /// 料件明细GRID（单独处理）
        /// </summary>
        private void initGridMaterialsDetails()
        {

        }
        /// <summary>
        /// 报关材料明细GRID
        /// </summary>
        private void initGridDeclarationMaterialsDetails()
        {
            //产品配件报关材料表id, 配件id,序号,报关类别, 数量, 单位, 备注
            this.myDataGridViewDeclarationMaterialsDetails.AutoGenerateColumns = false;
            this.myDataGridViewDeclarationMaterialsDetails.Columns["产品配件报关材料表id"].Visible = false;
            this.myDataGridViewDeclarationMaterialsDetails.Columns["配件id"].Visible = false;
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
        }
        /// <summary>
        /// 加载料件组成
        /// </summary>
        private void LoadDataSourceMaterials()
        {
            //string strSQL = string.Format("SELECT * FROM 配件组成表 WHERE 配件组成表.配件id = {0}",mnFId);
//            string strSQL = string.Format(@"SELECT PZ.配件组成表id, PZ.料件组成id AS 组成id, L.料件型号 AS 型号, L.料件名 AS 品名, PZ.数量,PZ.损耗率,L.料件单位 as 单位,PZ.备注
//                                            FROM 配件组成表 PZ INNER JOIN 料件资料表 L ON L.料件id = PZ.料件组成id WHERE PZ.配件id ={0}", mnFId);
            string strSQL = string.Format(@"SELECT PZ.配件组成表id, PZ.料件组成id, L.料件型号, L.料件名, PZ.数量,PZ.损耗率,L.料件单位,PZ.备注
                                            FROM 配件组成表 PZ INNER JOIN 料件资料表 L ON L.料件id = PZ.料件组成id WHERE PZ.配件id ={0}", mnFId);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtMaterials = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            this.myDataGridViewMaterials.DataSource = dtMaterials;
        }
        /// <summary>
        /// 加载配件组成
        /// </summary>
        private void LoadDataSourceFit()
        {
            string strSQL = string.Format(@"SELECT PZ.配件组成表id, PZ.配件组成id, P.配件型号, P.配件名, P.配件组别,PZ.数量, PZ.客户代码, PZ.备注, PZ.类别, PL.配件类别描述
                                            FROM (配件组成表 PZ LEFT OUTER JOIN 配件类别表 PL ON PL.配件类别 = PZ.类别)
                                                INNER JOIN 配件资料表 P ON P.配件id = PZ.配件组成id 
                                                WHERE PZ.配件id = {0}", mnFId);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtFit = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            this.myDataGridViewFit.DataSource = dtFit;
        }
        /// <summary>
        /// 加载料件明细（单独处理，切换TAB时才加载）
        /// </summary>
        private void LoadDataSourceMaterialsDetails()
        {
            int i, j, k, l, m, n, o, p;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtMaterialsDetails = dataAccess.GetTable("select * from 料件组成打印虚表 where 代号<1", null);
            dataAccess.Close();
            string strSQL = string.Empty;
            foreach (DataRow fitRow in dtFit.Rows)
            {
                if (fitRow.RowState == DataRowState.Deleted) continue;
                DataRow newRow = dtMaterialsDetails.NewRow();
                newRow["型号"] = string.Format("配件:{0}  X{1}", fitRow["型号"], fitRow["数量"]);
                newRow["品名"] = string.Format("组别:{0}", fitRow["配件组别"]);
                dtMaterialsDetails.Rows.Add(newRow);
                strSQL = string.Format(@"SELECT  料件资料表.料件型号, 料件资料表.料件名, 配件组成表.数量,配件组成表.损耗率,
                    料件资料表.料件单位,配件组成表.备注, 配件组成表.配件组成id, 配件组成表.配件组成表id, 配件资料表.配件型号,配件资料表.配件组别 FROM 配件组成表 
                    LEFT OUTER JOIN 配件资料表 ON 配件组成表.配件组成id = 配件资料表.配件id LEFT OUTER JOIN 料件资料表 ON 
                    配件组成表.料件组成id = 料件资料表.料件id WHERE 配件组成表.配件id ={0} order by 配件组成id,配件组成表id", fitRow["组成id"]);
                DataTable rs0 = dataAccess.GetTable(strSQL, null);
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
                        newRow0["损耗率"] = rs0Row["损耗率"];
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

                    }
                }
            }
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
            this.myDataGridViewDeclarationMaterialsDetails.DataSource = dtDeclarationMaterialsDetails;
        }
        #endregion
    }
}
