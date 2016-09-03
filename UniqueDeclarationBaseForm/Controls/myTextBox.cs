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
    public partial class myTextBox : TextBox
    {
        public myTextBox()
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

        private int _decimalCount;
        [Category("自定义属性")]
        [Description("当数据类型为小数点时，控制小数点的位数，默认为0，为0时表示不控制位数")]
        [DefaultValue(0)]
        public int DecimalCount
        {
            get { return _decimalCount; }
            set { _decimalCount = value; }
        }


        private DataTypeEnum _DataTypeEnum = DataTypeEnum.DataTypeString;
        [Category("自定义属性")]
        [Description("数据类型枚举。DataTypeString=字符串类型；DataTypeInteger=数值类型，整型（正负数都可以）；DataTypeIntegerPositive=数值类型，只能输入正整数；DataTypeIntegerNegative=数值类型，只能输入负正数；DataTypeDecimal=带小数数值类型，可以输入小数点，可以输入负数；DataTypeDecimalPositive=带小数数值类型（只能输入正数，包含0）；DataTypeDecimalNegative=带小数数值类型（只能输入负数）")]
        public DataTypeEnum DataType
        {
            get
            {
                return _DataTypeEnum;
            }
            set
            {
                this._DataTypeEnum = value;
                this.Invalidate();
            }
        }
        public enum DataTypeEnum
        {
            /// <summary>
            /// 字符串类型
            /// </summary>
            [Description("字符串类型")]
            DataTypeString = 1,
            /// <summary>
            /// 数值类型，整型（正负数都可以）
            /// </summary>
            [Description("数值类型，整型（正负数都可以）")]
            DataTypeInteger = 2,
            /// <summary>
            /// 数值类型，只能输入正整数
            /// </summary>
            [Description("数值类型，只能输入正整数")]
            DataTypeIntegerPositive = 3,
            /// <summary>
            /// 数值类型，只能输入负正数
            /// </summary>
            [Description("数值类型，只能输入负正数")]
            DataTypeIntegerNegative = 4,
            /// <summary>
            /// 带小数数值类型，可以输入小数点，可以输入负数
            /// </summary>
            [Description("带小数数值类型，可以输入小数点，可以输入负数")]
            DataTypeDecimal = 5,
            /// <summary>
            /// 带小数数值类型（只能输入正数，包含0）
            /// </summary>
            [Description("带小数数值类型（只能输入正数，包含0）")]
            DataTypeDecimalPositive = 6,
            /// <summary>
            /// 带小数数值类型（只能输入负数）
            /// </summary>
            [Description("带小数数值类型（只能输入负数）")]
            DataTypeDecimalNegative = 7
        }


        private void myTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////处理回车事件
            //if (this.IsEnterToTab && e.KeyChar == 13)
            //{
            //    SendKeys.Send("{tab}");   
            //}
            /*
            '判断是否是数字   
      Dim inputkey As Integer
      inputkey = Asc(e.KeyChar)

      Select Case inputkey
        Case 48 To 57   '数字

        Case 8        ' 删除键(backspace)

        Case 127      ' DEL

        Case 46      ' 小数点.
          If IsDecimal = True Then  '可以输入小数点

          Else
            inputkey = 0 '不可以输入小数点
          End If
        Case 45      '负数符号-
          If IsNegative = True Then '可以输入负数

          Else    '不可以输入负数
            inputkey = 0
          End If
        Case Else
          inputkey = 0
      End Select
            */
            ASCIIEncoding AE1 = new ASCIIEncoding();
                byte[] ByteArray1 = AE1.GetBytes(e.KeyChar.ToString());
                int inputkey = ByteArray1[0];
           
            /*
            //如果不是字符串的话
            if (this.DataType != DataTypeEnum.DataTypeString)
            {
                //数字、删除键(backspace)、DEL
                if ((inputkey >= 48 && inputkey <= 57) || inputkey == 8 || inputkey == 127)
                {
                    e.Handled = false;
                }
                else if(inputkey == 46)  //小数点
                {
                    //如果是小数点的话，再判断小数点的位置及出现的次数
                    if (this.DataType == DataTypeEnum.DataTypeDecimal || this.DataType == DataTypeEnum.DataTypeDecimalNegative || this.DataType == DataTypeEnum.DataTypeDecimalPositive)
                    {
                        //e.Handled = false;
                    }
                    else  //如果不是带小数点的数值，则不允许接收事件
                    {
                        e.Handled = true;
                    }
                }
            }
            switch (this.DataType)
            {
                case DataTypeEnum.DataTypeDecimal:

                    break;
                case DataTypeEnum.DataTypeDecimalNegative:

                    break;
                case DataTypeEnum.DataTypeDecimalPositive:

                    break;
                case DataTypeEnum.DataTypeInteger:

                    break;
                case DataTypeEnum.DataTypeIntegerNegative:

                    break;
                case DataTypeEnum.DataTypeIntegerPositive:

                    break;
                default :

                    break;
            }
            */


            /*
            bool bInput = false;
                 if(this.DataType != DataTypeEnum.DataTypeString//如果是数值型
                 {
                     if(inputkey >= 48 && inputkey <=57)
      '判断是否是数字   
      Select Case inputkey
        Case 48 To 57   '数字

        Case 8        ' 删除键(backspace)

        Case 127      ' DEL

        Case 46      ' 小数点.
          If IsDecimal = True Then  '可以输入小数点

          Else
            inputkey = 0 '不可以输入小数点
          End If
        Case 45      '负数符号-
          If IsNegative = True Then '可以输入负数

          Else    '不可以输入负数
            inputkey = 0
          End If
        Case Else
          inputkey = 0
      End Select

      If inputkey = 0 Then          '忽略
        e.Handled = True
      Else                  '响应
        'e.Handled = False
        If MaxLenth = 0 Then      '表示没有设置长度（再对负数和小数点进行判断）
          If inputkey = 45 Then '如果是负数符号
            If Len(Me.Text) = 0 Then   '如果是第一个字符，就响应
              e.Handled = False
            Else
              e.Handled = True
            End If
          End If
          If inputkey = 46 Then    '如果是小数点符号
            If Len(Me.Text) = 0 Then   '如果是第一个字符，则不响应，小数点不能为第一个字符
              e.Handled = True
            Else    '否则，根据小数点的个数来判断，如果有存在，则不响应
              If InStr(Me.Text, ".") = 0 Then    '如果在控件字符串中找不到.的所在位置，则响应
                e.Handled = False
              Else    '如果能找到，说明已经有.存在，就不能输入第二个小数点符号
                e.Handled = True
              End If
            End If
          End If
          If inputkey <> 46 And inputkey <> 45 And inputkey <> 8 Then '如果输入的值不是小数点和负数、删除号，再进行小数点后面位数判断
            If Count > 0 Then      '小数点位数判断
              If InStr(Me.Text, ".") = 0 Then   '如果不存在小数点，直接响应
                e.Handled = False
              Else    '存在小数点，对小数点位数进行判断
                If InStr(Mid(StrReverse(Me.Text), 1, Count), ".") = 0 Then  '对字符串进行反向，然后对反向后的字符串读取从第一个字符串的值到设置的个数，如果里面包含“.”，说明已经达到设置的小数点位数，则不响应，否则，表示未达到设置位数，响应
                  e.Handled = True
                Else
                  e.Handled = False
                End If
              End If
            Else
              e.Handled = False
            End If
            'Else
            '    e.Handled = False
          End If

          'e.Handled = False
        Else          '表示有设置字符串长度限制
          If Len(Me.Text) >= MaxLenth Then     '如果输入的字符串数长于等于设置长度，则不响应事件(但Backspace键要响应，删除)
            If inputkey = 8 Then       '如果是Backspace就响应，删除
              e.Handled = False
            Else
              e.Handled = True
            End If
          Else       '如果输入的字符串数小于设置长度，就响应事件
            If inputkey = 45 Then '如果是负数符号
              If Len(Me.Text) = 0 Then   '如果是第一个字符，就响应
                e.Handled = False
              Else
                e.Handled = True
              End If
            End If
            If inputkey = 46 Then    '如果是小数点符号
              If Len(Me.Text) = 0 Then   '如果是第一个字符，则不响应，小数点不能为第一个字符
                e.Handled = True
              Else    '否则，根据小数点的个数来判断，如果有存在，则不响应
                If InStr(Me.Text, ".") = 0 Then    '如果在控件字符串中找不到.的所在位置，则响应
                  e.Handled = False
                Else    '如果能找到，说明已经有.存在，就不能输入第二个小数点符号
                  e.Handled = True
                End If
              End If
            End If

            If inputkey <> 46 And inputkey <> 45 And inputkey <> 8 Then '如果输入的值不是小数点和负数、删除号，再进行小数点后面位数判断
              If Count > 0 Then      '小数点位数判断
                If InStr(Me.Text, ".") = 0 Then   '如果不存在小数点，直接响应
                  e.Handled = False
                Else    '存在小数点，对小数点位数进行判断
                  If InStr(Mid(StrReverse(Me.Text), 1, Count), ".") = 0 Then  '对字符串进行反向，然后对反向后的字符串读取从第一个字符串的值到设置的个数，如果里面包含“.”，说明已经达到设置的小数点位数，则不响应，否则，表示未达到设置位数，响应
                    e.Handled = True
                  Else
                    e.Handled = False
                  End If
                End If
              Else
                e.Handled = False
              End If
              'Else
              '    e.Handled = False
            End If
            'e.Handled = False
          End If
        End If
      End If
    Else          '如果不是数值型，只需要判断数值字符串大小即可
      If MaxLenth = 0 Then           '没有长度限制
        e.Handled = False
      Else
        If Len(Me.Text) >= MaxLenth Then     '如果输入的字符串数长于等于设置长度，则不响应事件(但Backspace键要响应，删除)
          If Asc(e.KeyChar) = 8 Then
            e.Handled = False
          Else
            e.Handled = True
          End If
        Else
          e.Handled = False
        End If
      End If

    End If
             * */
             
        }

        private void myTextBox_Validating(object sender, CancelEventArgs e)
        {
            //如果是数值类型的话，空字符串时，就默认赋值0
            if(this.DataType != DataTypeEnum.DataTypeString)
            {
                if(string.IsNullOrEmpty( this.Text.Trim()))
                {
                    this.Text = "0";
                }
            }
        }

        private void myTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.IsEnterToTab)
            {
                SendKeys.Send("{tab}"); 
            }
            //        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Down Then   '按Enter或↓ 
            //  SendKeys.Send("{Tab}")   '下移一个焦点   
            //ElseIf e.KeyCode = Keys.Up Then     '按↑   
            //  SendKeys.Send("+{Tab}")   '上移一个焦点   
            //End If
        }

    }
}
