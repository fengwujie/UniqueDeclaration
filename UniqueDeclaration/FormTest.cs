using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            DataTable dtData = dataAccess.GetTable("select top 100 订单号码,客户代码,客户名称 from 报关预先订单表");
            this.myDataGridView1.DataSource = dtData;
            DataTable dtData2 = dataAccess.GetTable("select top 100 订单号码,客户代码,客户名称 from 报关预先订单表");
            this.myDataGridView2.DataSource = dtData2;

            //this.myDataGridView1.Columns[0].ReadOnly = true;
            this.myDataGridView1.Columns[1].ReadOnly = true;
            this.myDataGridView1.Columns[2].ReadOnly = true;


            this.myDataGridView2.Columns[0].ReadOnly = true;
            this.myDataGridView2.Columns[1].ReadOnly = true;
        }

        private void CopyCell_Click(object sender, EventArgs e)
        {
            string strText = string.Empty;
            Control activeControl = this.ActiveControl;
            if (activeControl.GetType().Name == "DataGridView")
            {
                if (((DataGridView)activeControl).CurrentCell.Value != DBNull.Value || ((DataGridView)activeControl).CurrentCell.Value != null)
                    strText = ((DataGridView)activeControl).CurrentCell.Value.ToString();
                Clipboard.SetText(strText);
            }
            else
            {
                if (activeControl.Controls.Count > 0)
                {
                    foreach (Control control in activeControl.Controls)
                    {
                        if (control.GetType().Name == "DataGridView")
                        {
                            if (((DataGridView)control).CurrentCell.Value != DBNull.Value || ((DataGridView)control).CurrentCell.Value != null)
                                strText = ((DataGridView)control).CurrentCell.Value.ToString();
                            Clipboard.SetText(strText);
                        }
                    }
                }
            }

            //DataGridViewTextBoxColumn textBoxColumn = this.contextMenuStrip1.SourceControl;
        }

        private void myButton3_Click(object sender, EventArgs e)
        {
            ExcelCommonMethod.proba(this);
        }

        private void myButton4_Click(object sender, EventArgs e)
        {
            this.myProgressBar1.Minimum = 1;
            myProgressBar1.Maximum =Convert.ToInt32( this.myTextBox1.Text);
            myProgressBar1.Step = 1;
            myProgressBar1.Style = ProgressBarStyle.Blocks;
            myProgressBar1.TextType = UniqueDeclarationBaseForm.Controls.myProgressBar.LableTextType.LableTextType_Number;
            myProgressBar1.Refresh();
            for (int i = 1; i <= myProgressBar1.Maximum; i++)
            {
                myProgressBar1.Value = i;
                //Application.DoEvents();
                myProgressBar1.Refresh();
            }
        }

        
    }
}
