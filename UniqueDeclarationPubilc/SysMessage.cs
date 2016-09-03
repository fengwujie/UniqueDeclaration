using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UniqueDeclarationPubilc
{
    public class SysMessage
    {
        /// <summary>
        /// Information对话框
        /// </summary>
        /// <param name="text">要在消息框中显示的文本</param>
        public static void InformationMsg(string text)
        {
            MessageBox.Show(text, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Error对话框
        /// </summary>
        /// <param name="text">文本</param>
        public static void ErrorMsg(string text)
        {

            MessageBox.Show(text, " 错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        /// <summary>
        /// WarningMsg对话框
        /// </summary>
        /// <param name="text">文本</param>
        public static void WarningMsg(string text)
        {

            MessageBox.Show(text, " 警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        /// <summary>
        /// ExclamationMsg对话框
        /// </summary>
        /// <param name="text">文本</param>
        public static void ExclamationMsg(string text)
        {
            MessageBox.Show(text, " 警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        /// <summary>
        /// YesNoMsg对话框
        /// </summary>
        /// <param name="txt">要在消息框中显示的文本</param>
        public static DialogResult YesNoMsg(string text)
        {
            return YesNoMsg(text, "询问");

        }
        /// <summary>
        /// YesNo对话框
        /// </summary>
        /// <param name="text">要在消息框中显示的文本。</param>
        /// <param name="caption">要在消息框的标题栏中显示的文本。</param>
        /// <returns>返回结果: System.Windows.Forms.DialogResult 值之一。YES,NO</returns>
        public static DialogResult YesNoMsg(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        /// <summary>
        /// OKCancel对话框
        /// </summary>
        /// <param name="text">要在消息框中显示的文本。</param>
        /// <returns></returns>
        public static DialogResult OKCancelMsg(string text)
        {
            return OKCancelMsg(text, "确认请求");

        }
        /// <summary>
        /// OKCancel对话框
        /// </summary>
        /// <param name="text">要在消息框中显示的文本。</param>
        /// <param name="caption">要在消息框的标题栏中显示的文本。</param>
        /// <returns>返回结果: System.Windows.Forms.DialogResult 值之一。OK,Cancel</returns>
        public static DialogResult OKCancelMsg(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        /// <summary>
        /// YesNoCancel对话框
        /// </summary>
        /// <param name="txt">返回结果: System.Windows.Forms.DialogResult 值之一。YES,NO,Cancel</param>
        public static DialogResult YesNoCancelMsg(string text)
        {
            return YesNoCancelMsg(text, "请选择操作");

        }
        /// <summary>
        /// YesNoCancel对话框
        /// </summary>
        /// <param name="text">要在消息框中显示的文本。</param>
        /// <param name="caption">要在消息框的标题栏中显示的文本。</param>
        /// <returns>返回结果: System.Windows.Forms.DialogResult 值之一。YES,NO,Cancel</returns>
        public static DialogResult YesNoCancelMsg(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}
