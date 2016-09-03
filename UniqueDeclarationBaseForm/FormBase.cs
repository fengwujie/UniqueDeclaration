using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using UniqueDeclarationBaseForm.Controls;

namespace UniqueDeclarationBaseForm
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();

            //this.skinUI1.SkinFile = "Mac OS X-BLUE.skn";  
        }

        private bool _isScaling = true;
        /// <summary>
        /// 窗体上的控件跟随控件大小变化时，自动按比例缩小大小
        /// </summary>
        [Category("自定义属性")]
        [Description("窗体上的控件跟随控件大小变化时，自动按比例缩小大小")]
        [DefaultValue(true)]
        public bool IsScaling
        {
            get { return _isScaling; }
            set { _isScaling = value; }
        }

        private bool _isShowScrollBar = false;
        /// <summary>
        /// 当IsScaling=True时，控件缩小尺寸小于原始尺寸时，是否出现滚动条。如果为True时，表示控件会保持初始尺寸；如果为False时，控件会继续缩小，有可能会出现控件显示不全的情况
        /// </summary>
        [Category("自定义属性")]
        [Description("当IsScaling=True时，控件缩小尺寸小于原始尺寸时，是否出现滚动条。如果为True时，表示控件会保持初始尺寸；如果为False时，控件会继续缩小，有可能会出现控件显示不全的情况")]
        [DefaultValue(false)]
        public bool IsShowScrollBar
        {
            get { return _isShowScrollBar; }
            set { _isShowScrollBar = value; }
        }

        #region 设定程序中可能要用到的用以存储初始数据的动态数组及相关私有变量
        private ArrayList InitialCrl = new ArrayList();       //用以存储窗体中所有的控件名称
        private ArrayList CrlLocationX = new ArrayList();     //用以存储窗体中所有的控件原始X位置
        private ArrayList CrlLocationY = new ArrayList();     //用以存储窗体中所有的控件原始Y位置
        private ArrayList CrlSizeWidth = new ArrayList();     //用以存储窗体中所有的控件原始的水平尺寸
        private ArrayList CrlSizeHeight = new ArrayList();    //用以存储窗体中所有的控件原始的垂直尺寸
        private int FormSizeWidth;                            //用以存储窗体原始的水平尺寸
        private int FormSizeHeight;                           //用以存储窗体原始的垂直尺寸
        private double FormSizeChangedX;                      //用以存储相关父窗体/容器的水平变化量
        private double FormSizeChangedY;                      //用以存储相关父窗体/容器的垂直变化量
        private int Wcounter = 0;                             //为防止递归遍历控件时产生混乱，专门设定一个全局计数器
        #endregion     

        #region 控件尺码处理相关方法
        /// <summary>
        /// 获得并存储窗体中各控件的初始位置
        /// </summary>
        /// <param name="CrlContainer"></param>
        public void GetAllCrlLocation(Control CrlContainer)
        {
            foreach (Control iCrl in CrlContainer.Controls)
            {

                if (iCrl.Controls.Count > 0)
                    GetAllCrlLocation(iCrl);
                InitialCrl.Add(iCrl);
                CrlLocationX.Add(iCrl.Location.X);
                CrlLocationY.Add(iCrl.Location.Y);
            }
        }
        /// <summary>
        /// 获得并存储窗体中各控件的初始尺寸
        /// </summary>
        /// <param name="CrlContainer"></param>
        public void GetAllCrlSize(Control CrlContainer)
        {
            foreach (Control iCrl in CrlContainer.Controls)
            {
                if (iCrl.Controls.Count > 0)
                    GetAllCrlSize(iCrl);
                CrlSizeWidth.Add(iCrl.Width);
                CrlSizeHeight.Add(iCrl.Height);
            }
        }
        /// <summary>
        /// 获得并存储窗体的初始尺寸
        /// </summary>
        public void GetInitialFormSize()
        {
            FormSizeWidth = this.Size.Width;
            FormSizeHeight = this.Size.Height;
        }
        /// <summary>
        /// 重新设置控件的大小
        /// </summary>
        /// <param name="CrlContainer"></param>
        public void ResetAllCrlState(Control CrlContainer)
        {
            //重新设定窗体中各控件的状态（在与原状态的对比中计算而来）
            FormSizeChangedX = (double)this.Size.Width / (double)FormSizeWidth;
            FormSizeChangedY = (double)this.Size.Height / (double)FormSizeHeight;
            foreach (Control kCrl in CrlContainer.Controls)
            {
                if (!InitialCrl.Contains(kCrl)) continue;
                if (kCrl.Controls.Count > 0)
                {
                    ResetAllCrlState(kCrl);
                }
                Point point = new Point();
                point.X = (int)((int)CrlLocationX[Wcounter] * FormSizeChangedX);
                point.Y = (int)((int)CrlLocationY[Wcounter] * FormSizeChangedY);
                kCrl.Width = (int)((int)CrlSizeWidth[Wcounter] * FormSizeChangedX);
                kCrl.Height = (int)((int)CrlSizeHeight[Wcounter] * FormSizeChangedY);
                kCrl.Bounds = new Rectangle(point, kCrl.Size);
                Wcounter++;
            }
        }
        #endregion

        private void FormBase_Load(object sender, EventArgs e)
        {
            if (this.IsScaling)
            {
                GetInitialFormSize();   //获取窗体的初始大小
                //this.AutoScroll = true;
                //this.SetAutoSizeMode(FormSizeWidth,FormSizeHeight);
                //this.AutoScrollMinSize.Width = FormSizeWidth;
                //this.AutoScrollMinSize.Height = FormSizeHeight;
                GetAllCrlLocation(this);   //获取控件的初始位置
                GetAllCrlSize(this);      //获取控件的初始大小
            }

            //FormTitleCenterShow();
        }

        /*注意点：窗体小在原始大小时，有两种做法，一种是控件大小不变，窗体边缘增加上下或左右的滚动条（IF过程）；
         * 另一种做法为，控件跟着变小，这样有可能异动一些Lable控件变小后，文本显示不全（ELSE过程）      
         * */
        //窗体大小改变事件
        private void FormBase_SizeChanged(object sender, EventArgs e)
        {
            if (this.IsScaling)
            {
                Wcounter = 0;
                if (this.IsShowScrollBar)
                {
                    int counter = 0;
                    if (this.Size.Width < FormSizeWidth || this.Size.Height < FormSizeHeight)
                    {
                        //如果窗体的大小在改变过程中小于窗体尺寸的初始值，则窗体中的各个控件自动重置为初始尺寸，且窗体自动添加滚动条
                        foreach (Control iniCrl in InitialCrl)
                        {
                            iniCrl.Width = (int)CrlSizeWidth[counter];
                            iniCrl.Height = (int)CrlSizeHeight[counter];
                            Point point = new Point();
                            point.X = (int)CrlLocationX[counter];
                            point.Y = (int)CrlLocationY[counter];
                            iniCrl.Bounds = new Rectangle(point, iniCrl.Size);
                            counter++;
                        }
                        this.AutoScroll = true;
                    }
                    else    //否则，重新设定窗体中所有控件的大小（窗体内所有控件的大小随窗体大小的变化而变化）
                    {
                        this.AutoScroll = false;
                        ResetAllCrlState(this);
                    }
                }
                else
                {
                    this.AutoScroll = false;
                    ResetAllCrlState(this);
                }
                //int counter = 0;
                //if (this.Size.Width < FormSizeWidth || this.Size.Height < FormSizeHeight)
                //{ 
                ////如果窗体的大小在改变过程中小于窗体尺寸的初始值，则窗体中的各个控件自动重置为初始尺寸，且窗体自动添加滚动条
                // foreach (Control iniCrl in InitialCrl)
                //    {
                //        iniCrl.Width = (int)CrlSizeWidth[counter];
                //        iniCrl.Height = (int)CrlSizeHeight[counter];
                //        Point point = new Point();
                //        point.X = (int)CrlLocationX[counter];
                //        point.Y = (int)CrlLocationY[counter];
                //        iniCrl.Bounds = new Rectangle(point, iniCrl.Size);
                //        counter++;
                //    }
                //    this.AutoScroll = true;
                //}
                //else    //否则，重新设定窗体中所有控件的大小（窗体内所有控件的大小随窗体大小的变化而变化）
                //{
                //this.AutoScroll = false;
                //ResetAllCrlState(this);
                //}
            }
        }

        /// <summary>
        /// 标题文本居中显示
        /// </summary>
        public void FormTitleCenterShow()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            Double ws = g.MeasureString("*", this.Font).Width;
            String tmp = " ";
            Double tw = 0;
            while ((tw + ws) < startingPoint)
            {
                tmp += "*";
                tw += ws;
            }
            this.Text = tmp.Replace("*", " ") + this.Text.Trim();
        }

    }
}
