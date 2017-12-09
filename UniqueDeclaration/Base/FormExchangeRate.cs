using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration.Base
{
    public partial class FormExchangeRate : UniqueDeclarationBaseForm.FormBase
    {
        public FormExchangeRate()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormExchangeRate_Edit objForm = new Base.FormExchangeRate_Edit();
            objForm.iModel = 1;
            if (objForm.ShowDialog() == DialogResult.OK)
                LoadDataSource();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.myDataGridView1.CurrentRowNew != null)
            {
                if (this.myDataGridView1.Rows[this.myDataGridView1.CurrentRowNew.Index].Cells["年"].Value != DBNull.Value)
                {
                    int year = (int)this.myDataGridView1.Rows[this.myDataGridView1.CurrentRowNew.Index].Cells["年"].Value;
                    int month = (int)this.myDataGridView1.Rows[this.myDataGridView1.CurrentRowNew.Index].Cells["月"].Value;
                    decimal rate = (decimal)this.myDataGridView1.Rows[this.myDataGridView1.CurrentRowNew.Index].Cells["汇率"].Value;
                    FormExchangeRate_Edit objForm = new Base.FormExchangeRate_Edit();
                    objForm.iModel = 2;
                    objForm.iYear = year;
                    objForm.iMonth = month;
                    objForm.rate = rate;
                    if (objForm.ShowDialog() == DialogResult.OK)
                        LoadDataSource();
                }
            }
                
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgv = null;
            int year = 0;
            int month = 0;
            if (this.myDataGridView1.CurrentRowNew != null)
            {
                if (this.myDataGridView1.Rows[this.myDataGridView1.CurrentRowNew.Index].Cells["年"].Value != DBNull.Value)
                {
                    year = (int)this.myDataGridView1.Rows[this.myDataGridView1.CurrentRowNew.Index].Cells["年"].Value;
                    month = (int)this.myDataGridView1.Rows[this.myDataGridView1.CurrentRowNew.Index].Cells["月"].Value;
                    if(SysMessage.OKCancelMsg(string.Format("确定要删除【{0}年{1}月】的汇率吗？",year,month)) == DialogResult.OK)
                    {
                        IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
                        dataAccess.Open();
                        dataAccess.ExecuteNonQuery(string.Format("delete exchangerate where iyear={0} and imonth={1}", year, month));
                        dataAccess.Close();
                        LoadDataSource();
                    }
                }
                else
                    return;
            }
            else
                return;

        }

        private void FormExchangeRate_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void LoadDataSource()
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dtExchangeRate = dataAccess.GetTable("select iyear as 年,imonth as 月,rate as 汇率 from exchangerate order by iyear desc,imonth desc");
            dataAccess.Close();
            this.myDataGridView1.DataSource = dtExchangeRate;
        }
    }
}
