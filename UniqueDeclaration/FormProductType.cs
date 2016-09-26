using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration
{
    public partial class FormProductType : UniqueDeclarationBaseForm.FormBase
    {
        public FormProductType()
        {
            InitializeComponent();
        }
        DataTable dtType = null;
        /// <summary>
        /// 判断当前窗体是否有进行数据异动，返回主窗体时刷新数据
        /// </summary>
        public bool bModify = false;
        private void FormProductType_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void LoadDataSource()
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dtType = dataAccess.GetTable("select * from 产品类别表", null);
            dataAccess.Close();
            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add("0","报关类别");
            DataRow[] mainRow = dtType.Select("产品类别 is null");
            foreach (DataRow row in mainRow)
            {
                TreeNode node = new TreeNode();
                node.Name = row["产品类别ID"].ToString();
                node.Text = row["产品类别描述"].ToString();
                //this.treeView1.Nodes[0].Nodes.Add(row["产品类别ID"].ToString(),row["产品类别描述"].ToString());
                DataRow[] subRow = dtType.Select( string.Format("产品类别={0}", row["产品类别ID"]));
                foreach (DataRow row2 in subRow)
                {
                    node.Nodes.Add(row2["产品类别ID"].ToString(), row2["产品类别描述"].ToString());
                }
                this.treeView1.Nodes[0].Nodes.Add(node);
            }
            this.treeView1.Nodes[0].Expand();
        }

        private void btnMainType_Click(object sender, EventArgs e)
        {
            FormProductType_Edit objForm = new FormProductType_Edit();
            objForm.strLable = "请输入主类产品类别：";
            if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bModify = true;
                LoadDataSource();
            }
        }

        private void btnSubType_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode == null || this.treeView1.SelectedNode.Name == "0" || this.treeView1.SelectedNode.Parent.Name != "0")
            {
                SysMessage.InformationMsg("请选择主类产品！");
                return;
            }
            FormProductType_Edit objForm = new FormProductType_Edit();
            objForm.strLable = "请输入子类产品类别：";
            objForm.iParentTypeID =Convert.ToInt32( this.treeView1.SelectedNode.Name);
            if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bModify = true;
                LoadDataSource();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode == null || this.treeView1.SelectedNode.Name == "0")
            {
                SysMessage.InformationMsg("请选择产品类别！");
                return;
            }
            FormProductType_Edit objForm = new FormProductType_Edit();
            objForm.strLable = "请输入产品类别：";
            objForm.itypeID = Convert.ToInt32(this.treeView1.SelectedNode.Name);
            objForm.strTypeText = this.treeView1.SelectedNode.Text;
            if (objForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bModify = true;
                LoadDataSource();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode == null || this.treeView1.SelectedNode.Name == "0")
            {
                SysMessage.InformationMsg("请选择产品类别！");
                return;
            }
            if (this.treeView1.SelectedNode.Nodes.Count > 0)
            {
                SysMessage.InformationMsg("此产品包含子类产品，不能删除，可先删除子类产品再删除！");
                return;
            }
            if (SysMessage.OKCancelMsg(string.Format("确定要删除产品类别【{0}】吗？", this.treeView1.SelectedNode.Text)) == System.Windows.Forms.DialogResult.Cancel) return;
            string strSQL = string.Format("DELETE [产品类别表] WHERE 产品类别={0} DELETE [产品类别表] WHERE 产品类别ID={0}", this.treeView1.SelectedNode.Name);
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            dataAccess.ExecuteNonQuery(strSQL, null);
            dataAccess.Close();
            bModify = true;
            LoadDataSource();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
