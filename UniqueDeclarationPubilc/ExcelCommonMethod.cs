using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace UniqueDeclarationPubilc
{
    public static class ExcelCommonMethod
    {
        /// <summary>
        /// 使用空白模版导出EXCEL
        /// </summary>
        /// <param name="dtExcel">需要导出的数据集</param>
        /// <param name="strTitle">EXCEL的主标题</param>
        public static void ExportIntoExcel(DataTable dtExcel,string strTitle)
        {
            //// 保存对话框
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            //saveFileDialog.FilterIndex = 0;
            //saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.CreatePrompt = false;
            //saveFileDialog.Title = "保存为Excel文件";
            ////导出的文件名默认为：“订单明细” +客户编码+ [“_” +订单号]（只有多订单的订货类别使用）
            ////    + “[”+日期(年月日时分秒,如：20141021163144)+“]”，
            //// 例如成都人为备量仓导出的Excel文件应为：订单明细201099[20141021163144].xls
            //saveFileDialog.FileName = strTitle;
            //if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string strSourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\空白模版.xls");
            string strDestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"ExcelTemp\{0}{1}.xls", strTitle, DateTime.Now.ToString("yyyyMMddHHmmss")));
            File.Copy(strSourceFile, strDestFile);
            File.SetAttributes(strDestFile, File.GetAttributes(strDestFile) | FileAttributes.ReadOnly);
            string fn = strDestFile;

            //string fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\空白模版.xls");
            ExcelTools ea = new ExcelTools();
            ea.SafeOpen(fn);
            ea.ActiveSheet(1); // 激活
            int iColCount = dtExcel.Columns.Count;

            int iIndex = 1;
            #region 设置EXCEL标题行
            if (strTitle.Length > 0)
            {
                string strMaxLetter = getColLetter(iColCount);   //计算最大列的字母
                string range = string.Format("A{0}:{1}{0}", iIndex, strMaxLetter);
                ea.SetValue(range, strTitle);
                //水平居中
                ea.SetHorisontalAlignment(range, 3);
                ea.SetVerticalAlignment(range, 3);
                Font font = new Font("楷体", 20, FontStyle.Bold);
                ea.SetFont(range, font);
                //合并首行
                ea.SetMerge(range);
                iIndex++;
            }
            #endregion

            #region 循环处理数据集
            Dictionary<string, long> dicColMaxValue = new Dictionary<string, long>();  //存放列值的最大字符串长度
            string strColLetter = string.Empty;  //列对应的字母
            string strCellText = string.Empty;  //单元格对应的文本内容
            long lCellLenght;  //单元格文本的长度
            #region 处理列标题
            for (int iCol = 0; iCol < iColCount; iCol++)
            {
                strColLetter = getColLetter(iCol + 1);
                strCellText = dtExcel.Columns[iCol].Caption;
                lCellLenght = StringTools.TextLenght(strCellText);
                //ea.SetValue(iIndex, iCol + 1,strCellText); //这里的列是从1开始的，所以iCol + 1
                ea.SetValue(string.Format("{0}{1}", strColLetter, iIndex), strCellText);
                if (dicColMaxValue.ContainsKey(strColLetter))  //如果字典中已经包含该列的数据，则跟当前文本判断长度，存储较大的长度值
                {
                    if (dicColMaxValue[strColLetter] < lCellLenght)
                        dicColMaxValue[strColLetter] = lCellLenght;
                }
                else
                {
                    dicColMaxValue.Add(strColLetter, lCellLenght);
                }
            }
            iIndex++;
            #endregion

            //foreach (DataRow row in dtExcel.Rows)
            DataRow row = null;
            for (int iRow = 0; iRow < dtExcel.Rows.Count;iRow++ )
            {
                row = dtExcel.Rows[iRow];
                if (row.RowState == DataRowState.Deleted) continue;
                for (int iCol = 0; iCol < iColCount; iCol++)
                {
                    strColLetter = getColLetter(iCol + 1);
                    strCellText = row[iCol].ToString();
                    lCellLenght = StringTools.TextLenght(strCellText);
                    //ea.SetValue(iIndex, iCol + 1,strCellText); //这里的列是从1开始的，所以iCol + 1
                    ea.SetValue(string.Format("{0}{1}", strColLetter, iIndex), row[iCol].ToString());
                    if (dicColMaxValue.ContainsKey(strColLetter))  //如果字典中已经包含该列的数据，则跟当前文本判断，存储字符长度较长的文本
                    {
                        if (dicColMaxValue[strColLetter] < lCellLenght)
                            dicColMaxValue[strColLetter] = lCellLenght;
                    }
                    else
                    {
                        dicColMaxValue.Add(strColLetter, lCellLenght);
                    }
                }
                iIndex++;
            }

            //设置每个列的宽度
            foreach (KeyValuePair<string,long> item in dicColMaxValue)
            {
                ea.SetColumnWidth(string.Format("{0}2",item.Key), item.Value + 2);  //最大字符串长度+2，多出点空隙
            } 
            #endregion
            //ea.Save(saveFileDialog.FileName);

            ea.Visible = true;
            ea.Dispose();
        }
        /// <summary>
        /// 根据列索引，获取到对应的列字母值，此处的索引是从1开始的。
        /// </summary>
        /// <param name="iCol">列索引，从1开始</param>
        /// <returns>返回列对应的字母</returns>
        private static string getColLetter(int iCol)
        {
            string strReturnLetter = string.Empty;
            string strLetter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (iCol <= 26)
            {
                strReturnLetter = strLetter.Substring(iCol - 1, 1);
            }
            else
            {
                int iMultiple = iCol / 26;   //取iCol除于26的整数倍
                int iMore = iCol % 26;   //取iCol除于26的余数
                strReturnLetter = string.Format("{0}{1}", strLetter.Substring(iMultiple - 1, 1), strLetter.Substring(iMore - 1, 1));
            }
            return strReturnLetter;
        }

        public static void proba(Form form)
        {
            ProgressBar proBar = new ProgressBar();
            //proBar.Location = new System.Drawing.Point(547, 407);
            proBar.Name = "progressBar1";
            proBar.Size = new System.Drawing.Size(315, 19);
            proBar.Location = new Point((form.Width - proBar.Width)/2,form.Height / 2);            
            //proBar.TabIndex = 9;
            form.Controls.Add(proBar);
            proBar.BringToFront();

            proBar.Minimum = 1;
            proBar.Maximum = 1000000;
            proBar.Step = 1;
            proBar.Style = ProgressBarStyle.Blocks;
            proBar.Visible = true;
            for (int i = 1; i < 1000000; i++)
            {
                proBar.Value = i;
            }
            proBar.Visible = false;
            form.Controls.Remove(proBar);
        }
    }
}
