using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclarationBaseForm.Controls
{
    public partial class myDateTimePicker : DateTimePicker
    {
        public myDateTimePicker()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private bool _isEnterToTab = true;
        /// <summary>
        /// 是否按回车执行TAB事件，即回车跳转到下一个控件
        /// </summary>
        [Category("自定义属性")]
        [Description("是否按回车执行TAB事件，即回车跳转到下一个控件")]
        [DefaultValue(true)]
        public bool IsEnterToTab
        {
            get { return _isEnterToTab; }
            set { _isEnterToTab = value; }
        }

        private void myDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.IsEnterToTab)
            {
                SendKeys.Send("{tab}");
            }
            /*
            If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Down Then   '按Enter或↓ 
      SendKeys.Send("{Tab}")   '下移一个焦点   
    ElseIf e.KeyCode = Keys.Up Then     '按↑   
      SendKeys.Send("+{Tab}")   '上移一个焦点   
    End If
             * */
        }
    }
}
