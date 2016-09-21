using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclarationBaseForm.Controls
{
    public partial class myProgressBar : UserControl
    {
        public myProgressBar()
        {
            InitializeComponent();
        }

        private int _Minimum = 0;
        [Category("自定义属性")]
        [Description("进度条最小值")]
        [DefaultValue(0)]
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                _Minimum = value;
                this.progressBar1.Minimum = value;
            }
        }
        private int _Maximum = 0;
        [Category("自定义属性")]
        [Description("进度条最大值")]
        [DefaultValue(100)]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                _Maximum = value;
                this.progressBar1.Maximum = value;
                if (value < 10)
                {
                    this.myLable1.Width = 30;
                }
                else
                {
                    this.myLable1.Width = 30 + (value.ToString().Length -1) * 15;
                }
            }
        }
        private int _Value = 0;
        [Category("自定义属性")]
        [Description("进度条当前值")]
        [DefaultValue(0)]
        public int Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                this.progressBar1.Value = _Value;
                if (TextType == LableTextType.LableTextType_Percent)
                {
                    this.myLable1.Text = string.Format("{0}%", value * 100 / Maximum);
                }
                else if (TextType == LableTextType.LableTextType_Number)
                {
                    this.myLable1.Text = string.Format("{0}/{1}", value, Maximum);
                }
            }
        }
        private int _Step = 0;
        /// <summary>
        /// 每次更新进度条的数量
        /// </summary>
        [Category("自定义属性")]
        [Description("每次更新进度条的数量")]
        [DefaultValue(1)]
        public int Step
        {
            get { return _Step; }
            set
            {
                _Step = value;
                this.progressBar1.Step = value;
            }
        }
        private ProgressBarStyle _Style = ProgressBarStyle.Blocks;
        [Category("自定义属性")]
        [Description("进度条的样式")]
        [DefaultValue(ProgressBarStyle.Blocks)]
        public ProgressBarStyle Style
        {
            get { return _Style; }
            set
            {
                _Style = value;
                this.progressBar1.Style = value;
            }
        }

        public enum LableTextType
        {
            /// <summary>
            /// 显示条数（Value/Maximum）
            /// </summary>
            LableTextType_Number,
            /// <summary>
            /// 显示百分比（Value/Maximum + %）
            /// </summary>
            LableTextType_Percent
        }
        private LableTextType _TextType = LableTextType.LableTextType_Percent;
        /// <summary>
        /// 进度条显示文本类型
        /// </summary>
        [Category("自定义属性")]
        [Description("进度条显示文本类型")]
        [DefaultValue(LableTextType.LableTextType_Percent)] 
        public LableTextType TextType
        {
            get { return _TextType; }
            set { _TextType = value; }
        }

    }
}
