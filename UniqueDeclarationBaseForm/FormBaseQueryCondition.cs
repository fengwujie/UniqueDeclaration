using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationBaseForm.Controls;
using UniqueDeclarationPubilc;
namespace UniqueDeclarationBaseForm
{
    public partial class FormBaseQueryCondition : UniqueDeclarationBaseForm.FormBase
    {
        public FormBaseQueryCondition()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 返回的查询语句串
        /// </summary>
        public string strReturnWhere = string.Empty;

        public virtual void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public virtual void btnOK_Click(object sender, EventArgs e)
        {
            LoopControls(this);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 循环遍历控件
        /// </summary>
        /// <param name="parentControl"></param>
        public void LoopControls(Control control)
        {
            if (control.Controls.Count > 0)
            {
                foreach (Control childControl in control.Controls)
                {
                    LoopControls(childControl);
                }
            }
            else
            {
                MakeQueryWhere(control);
            }
        }
        /// <summary>
        /// 根据控件生成查询条件串
        /// </summary>
        /// <param name="control"></param>
        public void MakeQueryWhere(Control control)
        {
            string strControlName = control.Name;  //控件名称
            string strFieldName = string.Empty;  //控件对应的字段名
            if (strControlName.StartsWith("txt_"))  //textbox控件
            {
                myTextBox tb = (myTextBox)control;
                if (tb.Text.Trim().Length > 0)
                {
                    strFieldName = tb.Tag.ToString();
                    if (this.myCheckBox1.Checked)  //模糊查询
                    {
                        strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("{0} like '%{1}%'", strFieldName,StringTools.SqlLikeQ( tb.Text.Trim()));
                    }
                    else  //精确查询
                    {
                        strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("{0}={1}", strFieldName,StringTools.SqlQ( tb.Text.Trim()));
                    }
                }
            }
            else if (strControlName.StartsWith("cbox_"))  //下拉控件
            {
                myComboBox cbox = (myComboBox)control;
                if (cbox.SelectedValue.ToString().Length > 0)
                {
                    string tag = cbox.Tag.ToString();
                    string dataType = tag.Split(',')[0];
                    strFieldName = tag.Split(',')[1];
                    if (dataType == "string")
                    {
                        strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("{0}={1}", strFieldName, StringTools.SqlQ(cbox.SelectedValue.ToString()));
                    }
                    else if (dataType == "int")
                    {
                        strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("{0}={1}", strFieldName, cbox.SelectedValue);
                    }
                }
            }
            else if (strControlName.StartsWith("date_"))  //日期控件
            {
                myDateTimePicker dtp = (myDateTimePicker)control;
                if (dtp.Checked)
                {
                    string tag = dtp.Tag.ToString();
                    string index = tag.Split(',')[0];
                    strFieldName = tag.Split(',')[1];
                    if (index == "0")    //表示是指定日期
                    {
                        strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("{0}={1}", strFieldName, dtp.Value.ToShortDateString());
                    }
                    else if (index == "1")  //表示起始日期
                    {
                        strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("{0}>='{1} 00:00:01'", strFieldName, dtp.Value.ToShortDateString());
                    }
                    else if (index == "2")  //表示截止日期
                    {
                        strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("{0}<'{1} 23:59:59'", strFieldName, dtp.Value.ToShortDateString());
                    }
                }
            }
            else if (strControlName.StartsWith("datetime_"))  //日期(包含时间)控件
            {
                myDateTimePicker dtp = (myDateTimePicker)control;
                if (dtp.Checked)
                {
                    string tag = dtp.Tag.ToString();
                    string index = tag.Split(',')[0];
                    strFieldName = tag.Split(',')[1];
                    if (index == "1")  //表示起始时间
                    {
                        strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("{0}>='{1}'", strFieldName, dtp.Value);
                    }
                    else if (index == "2")  //表示截止时间
                    {
                        strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("{0}<'{1}'", strFieldName, dtp.Value);
                    }
                }
            }
        }
    }
}
