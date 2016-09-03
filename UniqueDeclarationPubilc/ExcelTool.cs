using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UniqueDeclarationPubilc
{
    public class ExcelTools : IDisposable
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        public const string UID = "Excel.Application";
        object oExcel;
        object WorkBooks, WorkBook, WorkSheets, WorkSheet, Range, Interior;
        object objPt;
        public IntPtr pt { get; set; }

        /// <summary>
        /// 类的构造函数
        /// </summary>
        public ExcelTools()
        {
            start();
        }


        /// <summary>
        /// 带文件类的构造函数
        /// </summary>
        public ExcelTools(string fn1, string fn2)
        {
            if (!start())
            {
                return;
            }
            if (!File.Exists(fn1))
            {
                new Exception("文件不存在!" + fn1);
                return;
            }

            File.Copy(fn1, fn2, true);
            Open(fn2);
        }


        public Boolean start()
        {
            try
            {
                oExcel = Activator.CreateInstance(Type.GetTypeFromProgID(UID));
                objPt = oExcel.GetType().InvokeMember("Hwnd", BindingFlags.GetProperty, null, oExcel, null);
                Object obj = oExcel.GetType().InvokeMember("Application", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Default | BindingFlags.GetField, null, oExcel, null);
                obj.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Default | BindingFlags.GetField, null, obj, new object[] { false });
                pt = new IntPtr((Int32)objPt);
                return true;
            }
            catch (Exception ex)
            {
                new Exception("运行Microsoft Excel程序时出错,请检查是否安装.");
                return false;
            }
        }

        /// <summary>
        /// excel的可视性
        /// </summary>
        public bool Visible
        {
            set
            {
                if (false == value)
                {
                    oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, oExcel, new object[] { false });
                }
                else
                {
                    oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, oExcel, new object[] { true });
                }
            }
        }


        /// <summary>
        /// 打开文档
        /// </summary>
        /// <param name="name">Excel文件名</param>
        public void Open(string name)
        {
            if (File.Exists(name))
            {
                WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
                WorkBook = WorkBooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, WorkBooks, new object[] { name, true });
                WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
                WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
                //Range = WorkSheet.GetType().InvokeMember("Range",BindingFl-ags.GetProperty,null,WorkSheet,new object[1] { "A1" });
            }
            else
            {
                new Exception("文件:" + name + "不存在!");
            }

        }

        /// <summary>
        /// 获取临时文件
        /// </summary>
        /// <param name="fFile"></param>
        /// <returns></returns>
        private string GetTempFile(string fFile)
        {
            string extFn = Path.GetExtension(fFile);
            string fFn = fFile.Substring(0, fFile.Length - extFn.Length);
            string strdate = string.Format("_{0:yyyyMMddHHmmssffff}", System.DateTime.Now);
            string strFile = fFn + strdate + extFn;
            while (File.Exists(strFile))
            {
                fFn = fFile.Substring(0, fFile.Length - extFn.Length);
                strFile = fFn + strdate + extFn;
            }
            return strFile;
        }

        /// <summary>
        /// 安全打开文档
        /// </summary>
        /// <param name="name"></param>
        public void SafeOpen(string name)
        {
            if (File.Exists(name))
            {
                string temp = System.Environment.GetEnvironmentVariable("TEMP");
                string fn = Path.GetFileName(name);
                temp = Path.Combine(temp, fn);
                temp = GetTempFile(temp);
                File.Copy(name, temp, true);
                Open(temp);

            }
            else
            {
                throw new Exception("文件不存在!" + name);
            }
        }

        /// <summary>
        /// 安全打开文档,带出文件名
        /// </summary>
        /// <param name="name"></param>
        public void SafeOpen(string name, ref string strGenFileName)
        {
            if (File.Exists(name))
            {
                string temp = System.Environment.GetEnvironmentVariable("TEMP");
                string fn = Path.GetFileName(name);
                temp = Path.Combine(temp, fn);
                temp = GetTempFile(temp);
                File.Copy(name, temp, true);
                Open(temp);
                strGenFileName = temp;

            }
            else
            {
                throw new Exception("文件不存在!" + name);
            }
        }


        /// <summary>
        /// 创建一个新文件 
        /// </summary>
        public void New()
        {
            WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
            WorkBook = WorkBooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, WorkBooks, null);
            WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1" });
        }

        /// <summary>
        /// 关闭文件
        /// </summary>
        public void Close()
        {
            if (WorkBook != null)
            {
                WorkBook.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, WorkBook, new object[] { true });
            }
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <param name="name">Excel文件名</param>
        public void Save(string name)
        {
            //if (File.Exists(name))
            //{
            //    WorkBook.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, null, WorkBook, null);
            //}
            //else
            //{
            WorkBook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, WorkBook, new object[] { name });
            //}
        }
        public void Save()
        {
            WorkBook.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, null, WorkBook, null);
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <param name="name">Excel文件名</param>
        /// <param name="strType">
        /// 保存类型：
        /// -4143：保存为Excel2003格式
        /// </param>
        public void SaveAS(string name, int strType)
        {
            //WorkBook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, WorkBook, new object[] { name });
            WorkBook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, WorkBook, new object[] { name, strType });
        }
        /// <summary>
        /// 切换Sheet
        /// </summary>
        /// <param name="iSheet"></param>
        public void ActiveSheet(int iSheet)
        {
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { iSheet });
            //WorkSheet = WorkSheets.GetType().InvokeMember("ActiveSheet", BindingFlags.GetProperty, null, WorkSheets, new object[] { iSheet }); 
        }

        /// <summary>
        /// 删除Sheet
        /// </summary>
        /// <param name="iSheet"></param>
        public void DeleteSheet(int iSheet)
        {
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { iSheet });
            WorkSheet.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod | BindingFlags.Default | BindingFlags.GetProperty | BindingFlags.Instance, null, WorkSheet, null);
        }

        /// <summary>
        /// 单元格复制
        /// </summary>
        /// <param name="range"></param>
        public void Copy(string range)
        {
            object[] Parameters = System.Text.RegularExpressions.Regex.Split(range, @"[,]+");
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, Parameters);
            Range.GetType().InvokeMember("Copy", BindingFlags.InvokeMethod, null, Range, null);
        }


        /// <summary>
        /// 单元格复制
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        public void Copy(int row, int col)
        {
            string range = ConvertColumnNum2String(col) + row.ToString();
            Copy(range);
        }

        /// <summary>
        /// 单元格粘贴
        /// </summary>
        /// <param name="range"></param>
        public void Paste(string range)
        {
            try
            {
                Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
                WorkSheet.GetType().InvokeMember("Paste", BindingFlags.InvokeMethod, null, WorkSheet, new object[] { Range });
            }
            catch(Exception ex)
            {
                SysMessage.ErrorMsg(ex.Message);
            }
        }
        /// <summary>
        /// 单元格粘贴
        /// </summary>
        /// <param name="range"></param>
        public void Paste(string range, bool bLink)
        {
            try
            {
                Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
                WorkSheet.GetType().InvokeMember("Paste", BindingFlags.InvokeMethod, null, WorkSheet, new object[] { Range, bLink });
            }
            catch
            {
            }
        }

        /// <summary>
        /// 单元格粘贴:Tab隔开的字符串
        /// </summary>
        /// <param name="range"></param>
        /// <param name="str">Tab隔开的字符串</param>
        public void Paste(string range, string str)
        {
            Clipboard.SetDataObject(str);
            Paste(range);
        }

        /// <summary>
        /// 单元格粘贴:Tab隔开的字符串
        /// </summary>
        /// <param name="range"></param>
        /// <param name="str">Tab隔开的字符串</param>
        public void ThreadPaste(object input)
        {
            System.Collections.ArrayList parm = input as System.Collections.ArrayList;
            WorkSheet = (parm[2] as ExcelTools).WorkSheet;
            Clipboard.SetDataObject(parm[1].ToString());
            Paste(parm[0].ToString());
        }

        /// <summary>
        /// 单元格粘贴
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void Paste(int row, int col)
        {
            string range = ConvertColumnNum2String(col) + row.ToString();
            Paste(range);
        }

        /// <summary>
        /// 单元格粘贴Tab隔开的字符串
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <param name="str">Tab隔开的字符串</param>
        public void Paste(int row, int col, string str)
        {
            Clipboard.SetDataObject(str);
            Paste(row, col);
        }

        /// <summary>
        /// 设置单元格的背景颜色
        /// </summary>
        /// <param name="range"></param>
        /// <param name="r"></param>
        public void SetColor(string range, int r)
        {
            //Range.Interior.ColorIndex
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            Interior = Range.GetType().InvokeMember("Interior", BindingFlags.GetProperty, null, Range, null);
            Range.GetType().InvokeMember("ColorIndex", BindingFlags.SetProperty, null, Interior, new object[] { r });
        }

        /// <summary>
        /// 页面方向
        /// </summary>
        public enum XlPageOrientation
        {
            xlPortrait = 1, //纵向
            xlLandscape = 2 //横向
        }

        public void SetNumberFormat()
        {
            object cols = WorkSheet.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, WorkSheet, null);
            cols.GetType().InvokeMember("NumberFormat", BindingFlags.SetProperty, null, cols, new object[] { "@" });

        }

        /// <summary>
        /// 设置页面方向
        /// </summary>
        /// <param name="Orientation"></param>
        public void SetOrientation(XlPageOrientation Orientation)
        {
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty, null, WorkSheet, null);
            PageSetup.GetType().InvokeMember("Orientation", BindingFlags.SetProperty, null, PageSetup, new object[] { 2 });
        }

        /// <summary>
        /// 设置页边距的大小表
        /// </summary>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <param name="Top"></param>
        /// <param name="Bottom"></param>
        public void SetMargin(double Left, double Right, double Top, double Bottom)
        {
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty, null, WorkSheet, null);
            PageSetup.GetType().InvokeMember("LeftMargin", BindingFlags.SetProperty, null, PageSetup, new object[] { Left }); //Range.PageSetup.LeftMargin
            PageSetup.GetType().InvokeMember("RightMargin", BindingFlags.SetProperty, null, PageSetup, new object[] { Right });//Range.PageSetup.RightMargin
            PageSetup.GetType().InvokeMember("TopMargin", BindingFlags.SetProperty, null, PageSetup, new object[] { Top });  //Range.PageSetup.TopMargin
            PageSetup.GetType().InvokeMember("BottomMargin", BindingFlags.SetProperty, null, PageSetup, new object[] { Bottom });//Range.PageSetup.BottomMargin
        }

        /// <summary>
        /// 页尺寸
        /// </summary>
        public enum xlPaperSize
        {
            xlPaperA4 = 9,
            xlPaperA4Small = 10,
            xlPaperA5 = 11,
            xlPaperLetter = 1,
            xlPaperLetterSmall = 2,
            xlPaper10x14 = 16,
            xlPaper11x17 = 17,
            xlPaperA3 = 9,
            xlPaperB4 = 12,
            xlPaperB5 = 13,
            xlPaperExecutive = 7,
            xlPaperFolio = 14,
            xlPaperLedger = 4,
            xlPaperLegal = 5,
            xlPaperNote = 18,
            xlPaperQuarto = 15,
            xlPaperStatement = 6,
            xlPaperTabloid = 3
        }

        /// <summary>
        /// 设置工作表的大小
        /// </summary>
        /// <param name="Size"></param>
        public void SetPaperSize(xlPaperSize Size)
        {
            //Range.PageSetup.PaperSize(纸张尺寸)
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty, null, WorkSheet, null);
            PageSetup.GetType().InvokeMember("PaperSize", BindingFlags.SetProperty, null, PageSetup, new object[] { Size });
        }

        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="Percent"></param>
        public void SetZoom(int Percent)
        {
            //Range.PageSetup.Zoom(打印的范围)
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty, null, WorkSheet, null);
            PageSetup.GetType().InvokeMember("Zoom", BindingFlags.SetProperty, null, PageSetup, new object[] { Percent });
        }

        /// <summary>
        /// 重命名表
        /// </summary>
        /// <param name="n"></param>
        /// <param name="Name"></param>
        public void ReNamePage(int n, string Name)
        {
            //Range.Interior.ColorIndex
            object Page = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { n });
            Page.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, Page, new object[] { Name });
        }

        /// <summary>
        /// 添加一个工作表
        /// </summary>
        /// <param name="Name">页面标题</param>
        public void AddNewSheet(string Name)
        {
            //Worksheet.Add.Item
            WorkSheet = WorkSheets.GetType().InvokeMember("Add", BindingFlags.GetProperty, null, WorkSheets, null);
            object Page = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
            Page.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, Page, new object[] { Name });
        }

        /// <summary>
        /// 设置单元格的字体
        /// </summary>
        /// <param name="range"></param>
        /// <param name="font"></param>
        public void SetFont(string range, Font font)
        {
            //Range.Font.Name
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            object Font = Range.GetType().InvokeMember("Font", BindingFlags.GetProperty, null, Range, null);
            Range.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, Font, new object[] { font.Name });
            Range.GetType().InvokeMember("Size", BindingFlags.SetProperty, null, Font, new object[] { font.Size });
        }

        /// <summary>
        /// 写在单元格的值
        /// </summary>
        /// <param name="range"></param>
        /// <param name="value"></param>
        public void SetValue(string range, string value)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            Range.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range, new object[] { value });
        }

        /// <summary>
        /// 写在单元格的值
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <param name="value">值</param>
        public void SetValue(int row, int col, string value)
        {
            string range = ConvertColumnNum2String(col) + row.ToString();
            SetValue(range, value);
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="range"></param>
        public void SetMerge(string range)
        {
            object[] Parameters = System.Text.RegularExpressions.Regex.Split(range, @"[,]+");
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, Parameters);
            Range.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, Range, new object[] { true });
        }

        /// <summary>
        /// 设置列宽
        /// </summary>
        /// <param name="range"></param>
        /// <param name="Width"></param>
        public void SetColumnWidth(string range, double Width)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            object[] args = new object[] { Width };
            Range.GetType().InvokeMember("ColumnWidth", BindingFlags.SetProperty, null, Range, args);
        }

        /// <summary>
        /// 设置文字方向
        /// </summary>
        /// <param name="range"></param>
        /// <param name="Orientation"></param>
        public void SetTextOrientation(string range, int Orientation)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            object[] args = new object[] { Orientation };
            Range.GetType().InvokeMember("Orientation", BindingFlags.SetProperty, null, Range, args);
        }

        /// <summary>
        /// 单元格中的文本垂直
        /// </summary>
        /// <param name="range"></param>
        /// <param name="Alignment"></param>
        public void SetVerticalAlignment(string range, int Alignment)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            object[] args = new object[] { Alignment };
            Range.GetType().InvokeMember("VerticalAlignment", BindingFlags.SetProperty, null, Range, args);
        }

        /// <summary>
        /// 单元格中的文本对齐水平
        /// </summary>
        /// <param name="range"></param>
        /// <param name="Alignment"></param>
        public void SetHorisontalAlignment(string range, int Alignment)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            object[] args = new object[] { Alignment };
            Range.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, null, Range, args);
        }

        /// <summary>
        /// 格式化单元格中的指定文本
        /// </summary>
        /// <param name="range"></param>
        /// <param name="Start"></param>
        /// <param name="Length"></param>
        /// <param name="Color"></param>
        /// <param name="FontStyle"></param>
        /// <param name="FontSize"></param>
        public void SelectText(string range, int Start, int Length, int Color, string FontStyle, int FontSize)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            object[] args = new object[] { Start, Length };
            object Characters = Range.GetType().InvokeMember("Characters", BindingFlags.GetProperty, null, Range, args);
            object Font = Characters.GetType().InvokeMember("Font", BindingFlags.GetProperty, null, Characters, null);
            Font.GetType().InvokeMember("ColorIndex", BindingFlags.SetProperty, null, Font, new object[] { Color });
            Font.GetType().InvokeMember("FontStyle", BindingFlags.SetProperty, null, Font, new object[] { FontStyle });
            Font.GetType().InvokeMember("Size", BindingFlags.SetProperty, null, Font, new object[] { FontSize });
        }

        /// <summary>
        /// 文字换行
        /// </summary>
        /// <param name="range"></param>
        /// <param name="Value"></param>
        public void SetWrapText(string range, bool Value)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            object[] args = new object[] { Value };
            Range.GetType().InvokeMember("WrapText", BindingFlags.SetProperty, null, Range, args);
        }

        /// <summary>
        /// 设置行高
        /// </summary>
        /// <param name="range"></param>
        /// <param name="Height"></param>
        public void SetRowHeight(string range, double Height)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            object[] args = new object[] { Height };
            Range.GetType().InvokeMember("RowHeight", BindingFlags.SetProperty, null, Range, args);
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="iRow">行号</param>
        public void DeleteRows(int iRow)
        {
            try
            {
                object range1 = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1" });
                object range = range1.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, range1, null);
                object rows = range.GetType().InvokeMember("Rows", BindingFlags.GetProperty, null, range, new object[1] { iRow });
                rows.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, rows, null);

            }
            catch (Exception e)
            {
                SysMessage.ErrorMsg(e.Message);
            }
        }

        /// <summary>
        /// 插入行
        /// </summary>
        /// <param name="iRow">行号</param>
        public void InsertRows(int iRow)
        {
            try
            {
                object range1 = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1" });
                object range = range1.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, range1, null);
                object rows = range.GetType().InvokeMember("Rows", BindingFlags.GetProperty, null, range, new object[1] { iRow });
                rows.GetType().InvokeMember("Insert", BindingFlags.InvokeMethod, null, rows, null);

            }
            catch (Exception e)
            {
                SysMessage.ErrorMsg(e.Message);
            }
        }
        public void ProtectedWorkSheet(int iSheet)
        {
            //string strPassword = ClassUniTools.GetClassName("OrderConfExcelKey");
            //ActiveSheet(iSheet);
            //WorkSheet.GetType().InvokeMember("Protect", BindingFlags.InvokeMethod, null, WorkSheet, new object[] { 
            //strPassword , true, true,true,true,true,true,true,true,true,true,true,true,true,true,true            
            //});
        }

        /// <summary>
        /// 删除列
        /// </summary>
        /// <param name="iColumn">列号</param>
        public void DeleteColumns(int iColumn)
        {
            try
            {
                object range1 = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1" });
                object range = range1.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, range1, null);
                object rows = range.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, range, new object[1] { iColumn });
                rows.GetType().InvokeMember("Delete", BindingFlags.InvokeMethod, null, rows, null);

            }
            catch (Exception e)
            {
                SysMessage.ErrorMsg(e.Message);
            }
        }

        /// <summary>
        /// 插入列
        /// </summary>
        /// <param name="iColumn"></param>
        public void InsertColumns(int iColumn)
        {
            try
            {
                object range1 = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1" });
                object range = range1.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, range1, null);
                object rows = range.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, range, new object[1] { iColumn });
                rows.GetType().InvokeMember("Insert", BindingFlags.InvokeMethod, null, rows, null);

            }
            catch (Exception e)
            {
                SysMessage.ErrorMsg(e.Message);
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            //Printing the sheet
            try
            {
                WorkSheet.GetType().InvokeMember("PrintOut", System.Reflection.BindingFlags.InvokeMethod,
                null,
                WorkSheet,
                null, null);
            }
            catch (Exception e)
            {
                SysMessage.ErrorMsg(e.Message);
            }
        }

        /// <summary>
        /// 预览
        /// </summary>
        public void Preview()
        {
            //Printing the sheet
            object[] args = new object[] { Missing.Value, Missing.Value, Missing.Value, true };
            try
            {
                WorkSheet.GetType().InvokeMember("PrintOut", System.Reflection.BindingFlags.GetProperty,
                null,
                WorkSheet,
                 args, null);
            }
            catch (Exception e)
            {
                SysMessage.ErrorMsg(e.Message);
            }
        }

        /// <summary>
        /// 设置边界
        /// </summary>
        /// <param name="range"></param>
        /// <param name="Style"></param>
        public void SetBorderStyle(string range, int Style)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            object[] args = new object[] { 1 };
            object[] args1 = new object[] { 1 };
            object Borders = Range.GetType().InvokeMember("Borders", BindingFlags.GetProperty, null, Range, null);
            Borders = Range.GetType().InvokeMember("LineStyle", BindingFlags.SetProperty, null, Borders, args);
        }

        /// <summary>
        /// 将源区域的内容剪贴到目标单元格为起始点的相同大小的区域中
        /// </summary>
        /// <param name="sourceRange">源区域</param>
        /// <param name="targetCell">目标单元格</param>
        public void CutRange(string sourceRange, string targetCell)
        {
            //源区域的Range对象
            object source = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { sourceRange });

            //目标单元格的Range对象
            object target = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { targetCell });

            //执行剪贴(类似的VBA语句：Range("A1:A10").Cut Range("C10"))
            source.GetType().InvokeMember("Cut", BindingFlags.InvokeMethod, null, source, new object[] { target });
        }

        //Ctrl+ * 可以获得当前sheet的最大的行与列
        /// 以A1:C3为基础选择,Selection.CurrentRegion.Select
        /// <summary>
        /// 取得指定工作表的内容的最大行数
        /// </summary>
        /// <param name="sheetName">工作表名</param>
        /// <returns></returns>
        public int? getMaxRows(string sheetName)
        {
            int? rtn = null;
            try
            {
                WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { sheetName });

                object range1 = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1:C3" });
                object range = range1.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, range1, null);

                //object range = WorkSheet.GetType().InvokeMember("UsedRange", BindingFlags.GetProperty, null, WorkSheet, null);
                object rows = range.GetType().InvokeMember("Rows", BindingFlags.GetProperty, null, range, null);
                rtn = (int)rows.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, rows, null);
                return rtn;
            }
            catch (Exception)
            {
                return rtn;
            }
        }

        /// <summary>
        /// 取第一个工作表的内容的最大行数
        /// </summary>
        /// <returns></returns>
        public int? getMaxRows()
        {
            int? rtn = null;
            try
            {
                object range1 = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1:C3" });
                object range = range1.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, range1, null);
                //object range = WorkSheet.GetType().InvokeMember("UsedRange", BindingFlags.GetProperty, null, WorkSheet, null);
                object rows = range.GetType().InvokeMember("Rows", BindingFlags.GetProperty, null, range, null);
                rtn = (int)rows.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, rows, null);
                return rtn;
            }
            catch (Exception)
            {
                return rtn;
            }
        }

        /// <summary>
        /// 取得指定工作表的内容的最大列数
        /// </summary>
        /// <param name="sheetName">工作表名</param>
        /// <returns></returns>
        public int? getMaxColumns(string sheetName)
        {
            int? rtn = null;
            try
            {
                WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { sheetName });

                object range1 = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1:C3" });
                object range = range1.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, range1, null);

                //WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { sheetName });
                //object range = WorkSheet.GetType().InvokeMember("UsedRange", BindingFlags.GetProperty, null, WorkSheet, null);
                object Columns = range.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, range, null);
                rtn = (int)Columns.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, Columns, null);
                return rtn;
            }
            catch (Exception)
            {
                return rtn;
            }
        }

        /// <summary>
        /// 取第一个工作表的内容的最大列数
        /// </summary>
        /// <returns></returns>
        public int? getMaxColumns()
        {
            int? rtn = null;
            try
            {
                object range1 = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1:C3" });
                object range = range1.GetType().InvokeMember("CurrentRegion", BindingFlags.GetProperty, null, range1, null);
                //object range = WorkSheet.GetType().InvokeMember("UsedRange", BindingFlags.GetProperty, null, WorkSheet, null);
                object Columns = range.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, range, null);
                rtn = (int)Columns.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, Columns, null);
                return rtn;
            }
            catch (Exception)
            {
                return rtn;
            }
        }

        /// <summary>
        /// 数字转换为Excel字母数字的列
        /// </summary>
        /// <param name="columnNum">数字</param>
        /// <returns>返回字符串</returns>
        public string ConvertColumnNum2String(int? columnNum)
        {
            if (columnNum > 26)
            {
                //return string.Format("{0}{1}", (char)(((columnNum - 1) / 26) + 64), (char)(((columnNum - 1) % 26) + 65));
                return string.Format("{0}{1}", ConvertColumnNum2String((columnNum - 1) / 26), (char)(((columnNum - 1) % 26) + 65));
            }
            else
            {
                return ((char)(columnNum + 64)).ToString();
            }
        }
        /// <summary>
        /// Excel字母形式的列转换为数字
        /// </summary>
        /// <param name="letters">字符</param>
        /// <returns>返回的int值</returns>
        public int ConvertLetters2ColumnName(string letters)
        {
            int num = 0;
            if (letters.Length == 1)
            {
                num = Convert.ToInt32(letters[0]) - 64;
            }
            else if (letters.Length == 2)
            {
                num = (Convert.ToInt32(letters[0]) - 64) * 26 + Convert.ToInt32(letters[1]) - 64;
            }
            return num;
        }
        /// <summary>
        /// 获取当前Sheet名称
        /// </summary>
        /// <returns></returns>
        public string GetSheetName()
        {
            string sReturn = string.Empty;
            sReturn = WorkSheet.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, WorkSheet, null).ToString();
            return sReturn;
        }

        /// <summary>
        /// 获取指定Excel的Sheet名称
        /// </summary>
        /// <param name="iIndex"></param>
        /// <returns></returns>
        public string GetSheetName(object iIndex)
        {
            string sReturn = string.Empty;
            sReturn = WorkSheet.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { iIndex }), null).ToString();
            return sReturn;
        }

        /// <summary>
        /// 取得指定工作表的内容的区域范围
        /// </summary>
        /// <param name="sheetName">工作表名</param>
        /// <returns></returns>
        public string GetSheetRange(string sheetName)
        {
            int? rows = getMaxRows(sheetName);
            int? cols = getMaxColumns(sheetName);
            object[] Parameters = new Object[2];
            Parameters[0] = "A1";
            Parameters[1] = ConvertColumnNum2String(cols) + rows.ToString();
            return Parameters[0] + ":" + Parameters[1];
        }

        /// <summary>
        /// 取得第一个工作表的内容的区域范围
        /// </summary>
        /// <returns></returns>
        public string GetSheetRange()
        {
            int? rows = getMaxRows();
            int? cols = getMaxColumns();
            object[] Parameters = new Object[2];
            Parameters[0] = "A1";
            Parameters[1] = ConvertColumnNum2String(cols) + rows.ToString();
            return Parameters[0] + ":" + Parameters[1];
        }

        /// <summary>
        /// 把指定工作表的有效区域的数据转换成一个二维数组
        /// </summary>
        /// <param name="sheetName">工作表名</param>
        /// <returns></returns>
        public Object[,] getSheetMaxRangeValues(string sheetName)
        {
            string range = GetSheetRange(sheetName);
            return getValues(sheetName, range);
        }

        /// <summary>
        /// 把第一个工作表的有效区域的数据转换成一个二维数组
        /// </summary>
        /// <returns></returns>
        public Object[,] getSheetMaxRangeValues()
        {
            string range = GetSheetRange();
            return getValues(range);
        }

        /// <summary>
        /// 取当前工作表中指定单元格的值
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public string GetValue(string range)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
            var rtn = Range.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range, null);
            return rtn == null ? "" : rtn.ToString();
        }


        /// <summary>
        /// 取当前工作表中指定单元格的值
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <returns></returns>
        public string GetValue(int row, int col)
        {
            string range = ConvertColumnNum2String(col) + row.ToString();
            return GetValue(range);
        }


        /// <summary>
        /// 读取第一个默认sheet数据到二维数组
        /// </summary>
        /// <param name="range">读取的区域，如"D1:F15"</param>
        /// <returns>一个二维数组(例如：Object[,] val = excel.getValues("D1:D18");)</returns>
        public Object[,] getValues(string range)
        {
            Object[,] rtnValue;
            try
            {
                Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });

                if (range == "A1:A1")
                {
                    //定义一个只包含一个[1,1]元素的二维数组,数组下标从1开始
                    Array array = Array.CreateInstance(typeof(Object), new int[] { 1, 1 }, new int[] { 1, 1 });

                    //把range中的唯一元素赋值给数组
                    array.SetValue(Range.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range, null), 1, 1);
                    rtnValue = (Object[,])array; //把Array类型的二维数组转换成Object类型后赋值rtnValue
                }
                else
                {
                    rtnValue = (Object[,])Range.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range, null);
                }

                return rtnValue;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 取得Excel指定WorkSheet中指定单元格的值
        /// </summary>
        /// <param name="sheetName">WorkSheet的名字</param>
        /// <param name="range">当前工作表中的某个单元格的值</param>
        /// <returns></returns>
        public string GetValue(string sheetName, string range)
        {
            try
            {
                WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { sheetName });
                Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });
                var rtn = Range.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range, null);
                return rtn == null ? "" : rtn.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 读取数据到二维数组
        /// </summary>
        /// <param name="sheetName">WorkSheet名</param>
        /// <param name="range">读取的区域，如"D1:F15"</param>
        /// <returns>一个二维数组</returns>
        /// 例如：Object[,] val = excel.getValues("Sheet1", "D1:D18");
        public Object[,] getValues(string sheetName, string range)
        {
            Object[,] rtnValue;

            try
            {
                WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { sheetName });
                Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { range });

                if (range == "A1:A1")
                {
                    //定义一个只包含一个[1,1]元素的二维数组,数组下标从1开始
                    Array array = Array.CreateInstance(typeof(Object), new int[] { 1, 1 }, new int[] { 1, 1 });

                    //把range中的唯一元素赋值给数组
                    array.SetValue(Range.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range, null), 1, 1);
                    rtnValue = (Object[,])array; //把Array类型的二维数组转换成Object类型后赋值rtnValue
                }
                else
                {
                    rtnValue = (Object[,])Range.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range, null);
                }

                return rtnValue;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 得到Excel文件中指定列的最大行数
        /// </summary>
        /// <param name="columnName">列标号(如A、B、C等)</param>
        /// <returns>返回columnName列的最大行数</returns>
        public int GetMaxRowNumber(string columnName)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { columnName + "65535" });
            Range = Range.GetType().InvokeMember("End", BindingFlags.GetProperty, null, Range, new object[] { -4162 });
            int RowMax = Convert.ToInt32(Range.GetType().InvokeMember("Row", BindingFlags.GetProperty, null, Range, null));
            return RowMax;
        }

        /// <summary>
        /// 得到Excel文件中指定列的最大行数
        /// </summary>
        /// <param name="sheetName">WorkSheet的名字</param>
        /// <param name="columnName">列标号(如A、B、C等)</param>
        /// <returns>返回columnName列的最大行数</returns>
        public int GetMaxRowNumber(string sheetName, string columnName)
        {
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { sheetName });
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[] { columnName + "65535" });
            Range = Range.GetType().InvokeMember("End", BindingFlags.GetProperty, null, Range, new object[] { -4162 });
            int RowMax = Convert.ToInt32(Range.GetType().InvokeMember("Row", BindingFlags.GetProperty, null, Range, null));
            return RowMax;
        }

        //释放EXCEL
        public void Dispose()
        {
            NAR(oExcel);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="o"></param>
        private void NAR(object o)
        {
            try
            {
                WorkBooks = null;
                WorkBook = null;
                WorkSheets = null;
                WorkSheet = null;
                Range = null;
                Interior = null;
                oExcel = null;
                o = null;
                GC.Collect();
                //if (o != null)
                //{
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
                //}
                release(pt);
            }
            catch { }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// 释放资料
        /// </summary>
        /// <param name="pt"></param>
        public static void release(IntPtr pt)
        {
            if (pt != null)
            {
                int pid = 0;
                GetWindowThreadProcessId(pt, out pid);
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(pid);
                p.Kill();
            }
        }


        #region 导入、导出
        /// <summary>
        /// 将Excel文件导出为Datatable
        /// </summary>
        /// <param name="strExcelFilePath"></param>
        /// <param name="bFirstRowIsTitle"></param>
        /// <returns></returns>
        public static System.Data.DataTable ExportToDatatable(string strExcelFilePath, bool bFirstRowIsTitle)
        {
            ExcelTools eApp = new ExcelTools();
            eApp.SafeOpen(strExcelFilePath);
            eApp.ActiveSheet(1);
            return eApp.SheetToDatatable(eApp.GetSheetName(), bFirstRowIsTitle);
        }

        public static System.Data.DataTable ExportToDatatable(string strExcelFilePath, bool bFirstRowIsTitle, int iSheet, string strSheetRange)
        {
            ExcelTools eApp = new ExcelTools();
            eApp.SafeOpen(strExcelFilePath);
            eApp.ActiveSheet(iSheet);
            return eApp.CustomSheetToDatatable(eApp.GetSheetName(), bFirstRowIsTitle, strSheetRange);
        }

        /// <summary>
        /// Excel文件中某个指定Sheet导出为DataTable
        /// </summary>
        /// <param name="strSheetName">strSheetName</param>
        /// <returns></returns>
        public System.Data.DataTable SheetToDatatable(string strSheetName, bool bFirstRowIsTitle)
        {
            System.Data.DataTable dtResult = new System.Data.DataTable();
            object[,] values = getValues(GetSheetRange(strSheetName));
            string sRange = GetSheetRange(strSheetName);
            string[] aRange = sRange.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            //判断是否有数据行
            bool bNoData = aRange.Length < 2
                || aRange[0].Equals(aRange[1], StringComparison.CurrentCultureIgnoreCase)
                || (bFirstRowIsTitle && int.Parse((new System.Text.RegularExpressions.Regex("^[a-zA-Z]+[1-9]+[:][a-zA-Z]+")).Replace(GetSheetRange(strSheetName), "")) <= 1);
            if (aRange.Length >= 2 && !aRange[0].Equals(aRange[1], StringComparison.CurrentCultureIgnoreCase))
            {
                for (int i = 1; i <= values.GetLength(1); i++)
                {
                    System.Data.DataColumn col = new System.Data.DataColumn();
                    if (bFirstRowIsTitle)
                    {
                        if (values[1, i] == null)
                        {
                            throw new Exception(string.Format("Excel第[{0}]列标题不明确，请重新定义！", i));
                        }
                        col.Caption = values[1, i].ToString();
                        col.ColumnName = values[1, i].ToString();
                    }
                    if (bNoData)
                        col.DataType = typeof(object);
                    else
                        col.DataType = values[bFirstRowIsTitle ? 2 : 1, i] == null ? typeof(System.String) : values[bFirstRowIsTitle ? 2 : 1, i].GetType();
                    dtResult.Columns.Add(col);
                }
                for (int iRow = bFirstRowIsTitle ? 2 : 1; iRow <= values.GetLength(0); iRow++)
                {
                    System.Data.DataRow dr = dtResult.NewRow();
                    for (int iCol = 1; iCol <= values.GetLength(1); iCol++)
                    {
                        dr[iCol - 1] = values[iRow, iCol];
                    }
                    dtResult.Rows.Add(dr);
                }
            }
            dtResult.TableName = strSheetName;
            return dtResult;
        }

        public System.Data.DataTable CustomSheetToDatatable(string strSheetName, bool bFirstRowIsTitle, string strSheetRange)
        {
            System.Data.DataTable dtResult = new System.Data.DataTable();
            //object[,] values = getValues(GetSheetRange(strSheetName));
            object[,] values = getValues(strSheetRange);
            for (int i = 1; i <= values.GetLength(1); i++)
            {
                System.Data.DataColumn col = new System.Data.DataColumn();
                if (bFirstRowIsTitle)
                {
                    col.Caption = values[1, i].ToString();
                    col.ColumnName = values[1, i].ToString();
                }
                col.DataType = values[bFirstRowIsTitle ? 2 : 1, i] == null ? typeof(System.String) : values[bFirstRowIsTitle ? 2 : 1, i].GetType();
                dtResult.Columns.Add(col);
            }
            for (int iRow = bFirstRowIsTitle ? 2 : 1; iRow <= values.GetLength(0); iRow++)
            {
                System.Data.DataRow dr = dtResult.NewRow();
                for (int iCol = 1; iCol <= values.GetLength(1); iCol++)
                {
                    dr[iCol - 1] = values[iRow, iCol] == null ? DBNull.Value : values[iRow, iCol];
                }
                dtResult.Rows.Add(dr);
            }
            dtResult.TableName = strSheetName;
            return dtResult;
        }

        #endregion

        //返回数据库连接
        public static OleDbConnection getConnection(string xlsFils)
        {
            if (!File.Exists(xlsFils))
            {
                 MessageBox.Show("文件\"" + xlsFils + "\"不存在", "提示");
                //ExceptionTools.WriteLog("文件\"" + xlsFils + "\"不存在");
                return null;
            }
            //string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + excelFile + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'"
            //string conn = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source =" + xlsFils + ";Extended Properties=Excel 8.0;HDR=NO;";
            string conn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + xlsFils + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'";
            return new OleDbConnection(conn);
        }

        public static OleDbConnection getConnectionForReadAndWrite(string xlsFils)
        {
            if (!File.Exists(xlsFils))
            {
                 MessageBox.Show("文件\"" + xlsFils + "\"不存在", "提示");
                //ExceptionTools.WriteLog("文件\"" + xlsFils + "\"不存在");
                return null;
            }
            //string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + excelFile + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'"
            //string conn = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source =" + xlsFils + ";Extended Properties=Excel 8.0;HDR=NO;";
            //string conn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + xlsFils + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=4'";
            string conn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + xlsFils + ";Extended Properties='Excel 12.0;HDR=NO;'";
            return new OleDbConnection(conn);
        }

    }
}
