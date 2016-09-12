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
    public partial class FormMaterialSheet : UniqueDeclarationBaseForm.FormBase
    {
        public FormMaterialSheet()
        {
            InitializeComponent();
        }
        public string idvalue = string.Empty;
        private void FormMaterialSheet_Load(object sender, EventArgs e)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine( string.Format(@"select ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) as 项号,left(ltrim(料号),3) as 料号,
                                                    max(商品编码) as 商品编码, max(商品名称) as 商品名称, max(商品规格) as 商品规格, 单位, rtrim(str(sum(数量),10,5)) as 数量 
                                            FROM 装箱单料件明细表 where left(ltrim(料号),1)='A' and idv='{0}' 
                                            group by ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) , left(ltrim(料号),3), 单位 ORDER BY 项号",idvalue));
            strBuilder.AppendLine(string.Format(@"select ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) as 项号, left(ltrim(料号),5) as 料号,
                                                    max(商品编码) as 商品编码, max(商品名称) as 商品名称, max(商品规格) as 商品规格, 单位, rtrim(str(sum(数量),10,5)) as 数量 
                                                FROM 装箱单料件明细表 where left(ltrim(料号),1)='A' and idv='{0}' 
                                                group by ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) , left(ltrim(料号),5),单位 ORDER BY 项号",idvalue));
            strBuilder.AppendLine(string.Format(@"select ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) as 项号, 料件编号, 料号, 料件名, 
                                                    max(商品编码) as 商品编码, max(商品名称) as 商品名称, max(商品规格) as 商品规格, 单位, rtrim(str(sum(数量),10,5)) as 数量 
                                                FROM 装箱单料件明细表 where left(ltrim(料号),1)='A' and idv='{0}' 
                                                group by ltrim(case when PATINDEX('%-%',项号)=0 then 项号 else SUBSTRING(项号,1,PATINDEX('%-%',项号)-1) end) , 料件编号, 料号, 料件名, 单位 ORDER BY 项号",idvalue));
            strBuilder.AppendLine(string.Format("DELETE FROM 装箱单料件明细表 where idv='{0}'",idvalue));
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataSet ds = dataAccess.GetDataSet(strBuilder.ToString(), null);
            dataAccess.Close();
            DataTable dt1 = ds.Tables[0];
            DataTableTools.AddEmptyRow(dt1);
            DataTable dt2 = ds.Tables[1];
            DataTableTools.AddEmptyRow(dt2);
            DataTable dt3 = ds.Tables[2];
            DataTableTools.AddEmptyRow(dt3);
            this.myDataGridView1.DataSource = dt1;
            this.myDataGridView2.DataSource = dt2;
            this.myDataGridView3.DataSource = dt3;

            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridView1.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMenuStripCell1;
            }
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridView2.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMenuStripCell2;
            }
            foreach (DataGridViewTextBoxColumn textBoxColumn in this.myDataGridView3.Columns)
            {
                textBoxColumn.ContextMenuStrip = this.myContextMenuStripCell3;
            }
        }

        private void btnExportMaterialSheet_Click(object sender, EventArgs e)
        {
            if (SysMessage.YesNoMsg("数据是否导入EXCEL文件？") == System.Windows.Forms.DialogResult.No) return;
            if (this.myDataGridView1.CurrentRow == null) return;

            string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\归并关系表.xls");
            string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\归并关系表{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")));
            File.Copy(strSourceFile, strDestFile);
            File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
            string fn = strDestFile;
            ExcelTools ea = new ExcelTools();
            ea.SafeOpen(fn);
            ea.ActiveSheet(1); // 激活
            int n = 6;  //起始索引行
            ea.SetValue("N2", DateTime.Now.ToString("yyyy-MM-dd"));
            //注释的列是不存在的
            //ea.SetValue("J6",this.myDataGridView1.CurrentRow.Cells["序号"].Value==DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["序号"].Value.ToString());
            //ea.SetValue("K6",this.myDataGridView1.CurrentRow.Cells["产品编号"].Value==DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["产品编号"].Value.ToString());
            ea.SetValue("L6",this.myDataGridView1.CurrentRow.Cells["商品编码"].Value==DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["商品编码"].Value.ToString());
            ea.SetValue("M6",this.myDataGridView1.CurrentRow.Cells["商品名称"].Value==DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["商品名称"].Value.ToString());
            ea.SetValue("N6",this.myDataGridView1.CurrentRow.Cells["商品规格"].Value==DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["商品规格"].Value.ToString());
           // ea.SetValue("O6",this.myDataGridView1.CurrentRow.Cells["单价"].Value==DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["单价"].Value.ToString());
            //ea.SetValue("P6",this.myDataGridView1.CurrentRow.Cells["计量单位"].Value==DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["计量单位"].Value.ToString());
            //ea.SetValue("Q6",this.myDataGridView1.CurrentRow.Cells["法定单位"].Value==DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["法定单位"].Value.ToString());
            //ea.SetValue("R6",this.myDataGridView1.CurrentRow.Cells["换算因子"].Value==DBNull.Value ? "" : this.myDataGridView1.CurrentRow.Cells["换算因子"].Value.ToString());

            DataTable dt2 = (DataTable)this.myDataGridView2.DataSource;
            foreach(DataRow row in dt2.Rows)
            {
                //ea.SetValue(string.Format("A{0}", n), row["序号"] == DBNull.Value ? "" : row["序号"].ToString());
                //ea.SetValue(string.Format("B{0}",n), row["产品编号"] == DBNull.Value ? "" :row["产品编号"].ToString());
                ea.SetValue(string.Format("C{0}",n), row["商品编码"] == DBNull.Value ? "" : row["商品编码"].ToString());
                ea.SetValue(string.Format("D{0}",n), row["商品名称"] == DBNull.Value ? "" : row["商品名称"].ToString());
                ea.SetValue(string.Format("E{0}",n), row["商品规格"] == DBNull.Value ? "" : row["商品规格"].ToString());
                //ea.SetValue("F{0}", row["单价"] == DBNull.Value ? "" : row["单价"].ToString());
                //ea.SetValue("G{0}", row["计量单位"] == DBNull.Value ? "" : row["计量单位"].ToString());
                //ea.SetValue("H{0}", row["法定单位"] == DBNull.Value ? "" : row["法定单位"].ToString());
                //ea.SetValue("I{0}", row["换算因子"] == DBNull.Value ? "" : row["换算因子"].ToString());
                n++;
            }
            //ea.Save(saveFileDialog.FileName);

            ea.Visible = true;
            ea.Dispose();
        }

        private void tool1_ExportExcel_Click(object sender, EventArgs e)
        {
            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridView1.DataSource,"归并后料件清单");
            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridView2.DataSource,"归并前料件清单");
            ExcelCommonMethod.ExportIntoExcel((DataTable)this.myDataGridView3.DataSource,"归并前料件明细清单");
        }
    }
}
