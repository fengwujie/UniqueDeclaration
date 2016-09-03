using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclaration
{
    public partial class FormOrderManager_Input : UniqueDeclarationBaseForm.FormBase
    {
        public FormOrderManager_Input()
        {
            InitializeComponent();
        }

        private void FormOrderManager_Input_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void myTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)     // 判断 按键的事件, 13 表示按下了 回车键   
            //{
            //    //SendKeys.Send("{tab}");
            //    // 模拟键盘再按一下 tab 键,  此方法 要先设定 TableIndex          // textBox2.focus();              // 或者直接让下一个文本框获取焦点, 这样比较方便.  
               // myTextBox1.Focus();
            //}
        }

        private void myTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //myTextBox1.Focus();
        }

    }
}
