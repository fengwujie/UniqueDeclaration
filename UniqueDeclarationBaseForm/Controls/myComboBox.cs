using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace UniqueDeclarationBaseForm.Controls
{
    public partial class myComboBox : ComboBox
    {
        public myComboBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="dataAccessName">访问数据库</param>
        /// <param name="strSQL">获取数据的SQL语句</param>
        /// <param name="valueMember">绑定的内码值</param>
        /// <param name="displayMember">绑定的显示值</param>
        public void InitialData(DataAccessEnum.DataAccessName dataAccessName,string strSQL, string valueMember, string displayMember)
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(dataAccessName);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            InitialData(dtData, valueMember, displayMember);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="dataAccessName">访问数据库</param>
        /// <param name="strSQL">获取数据的SQL语句</param>
        /// <param name="valueMember">绑定的内码值</param>
        /// <param name="displayMember">绑定的显示值</param>
        /// <param name="selectedIndex">默认选中索引行</param>
        public void InitialData(DataAccessEnum.DataAccessName dataAccessName, string strSQL, string valueMember, string displayMember,
            int selectedIndex)
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(dataAccessName);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            InitialData(dtData, valueMember, displayMember,selectedIndex);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="dataAccessName">访问数据库</param>
        /// <param name="strSQL">获取数据的SQL语句</param>
        /// <param name="valueMember">绑定的内码值</param>
        /// <param name="displayMember">绑定的显示值</param>
        /// <param name="selectedValue">默认选中值</param>
        public void InitialData(DataAccessEnum.DataAccessName dataAccessName, string strSQL, string valueMember, string displayMember,
            object selectedValue)
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(dataAccessName);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            InitialData(dtData, valueMember, displayMember, selectedValue);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="dataAccessName">访问数据库</param>
        /// <param name="strSQL">获取数据的SQL语句</param>
        /// <param name="valueMember">绑定的内码值</param>
        /// <param name="displayMember">绑定的显示值</param>
        /// <param name="selectedText">默认选中显示内容</param>
        public void InitialData(DataAccessEnum.DataAccessName dataAccessName, string strSQL, string valueMember, string displayMember,
            string selectedText)
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(dataAccessName);
            dataAccess.Open();
            DataTable dtData = dataAccess.GetTable(strSQL, null);
            dataAccess.Close();
            InitialData(dtData, valueMember, displayMember, selectedText);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="dtData">数据源DataTable</param>
        /// <param name="valueMember">绑定的内码值</param>
        /// <param name="displayMember">绑定的显示值</param>
        public void InitialData(DataTable dtData, string valueMember, string displayMember)
        {
            this.DataSource = dtData;
            this.ValueMember = valueMember;
            this.DisplayMember = displayMember;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="dtData">数据源DataTable</param>
        /// <param name="valueMember">绑定的内码值</param>
        /// <param name="displayMember">绑定的显示值</param>
        /// <param name="selectIndex">默认选中索引行</param>
        public void InitialData(DataTable dtData, string valueMember, string displayMember,int selectIndex)
        {
            this.DataSource = dtData;
            this.ValueMember = valueMember;
            this.DisplayMember = displayMember;
            this.SelectedIndex = selectIndex;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="dtData">数据源DataTable</param>
        /// <param name="valueMember">绑定的内码值</param>
        /// <param name="displayMember">绑定的显示值</param>
        /// <param name="selectedValue">默认选中值</param>
        public void InitialData(DataTable dtData, string valueMember, string displayMember, object selectedValue)
        {
            this.DataSource = dtData;
            this.ValueMember = valueMember;
            this.DisplayMember = displayMember;
            this.SelectedValue = selectedValue;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="dtData">数据源DataTable</param>
        /// <param name="valueMember">绑定的内码值</param>
        /// <param name="displayMember">绑定的显示值</param>
        /// <param name="selectedText">默认选中显示内容</param>
        public void InitialData(DataTable dtData, string valueMember, string displayMember, string selectedText)
        {
            this.DataSource = dtData;
            this.ValueMember = valueMember;
            this.DisplayMember = displayMember;
            this.SelectedText = selectedText;
        }
    }
}
