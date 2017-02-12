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
