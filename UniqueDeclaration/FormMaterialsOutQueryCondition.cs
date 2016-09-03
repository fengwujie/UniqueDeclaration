using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration
{
    public partial class FormMaterialsOutQueryCondition : UniqueDeclarationBaseForm.FormBase
    {
        public FormMaterialsOutQueryCondition()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 返回的查询语句串
        /// </summary>
        public string strReturnWhere = string.Empty;

        private void btnOK_Click(object sender, EventArgs e)
        {
            /*
             If Trim(txt出库单号) <> "" Then
        mstrFilterString = "出库单号 " & IIf(b模糊查询, " like '%" & txt出库单号 & "%", " ='" & txt出库单号) & "'"
    End If
    If Trim(txt订单号码) <> "" Then
        If mstrFilterString <> "" Then mstrFilterString = mstrFilterString & " and "
        mstrFilterString = "制造通知单号 " & IIf(b模糊查询, " like '%" & txt订单号码 & "%", " ='" & txt订单号码) & "'"
    End If
    If Trim(txt电子帐册号) <> "" Then
        If mstrFilterString <> "" Then mstrFilterString = mstrFilterString & " and "
        mstrFilterString = mstrFilterString & "电子帐册号 " & IIf(b模糊查询, " like '%" & txt电子帐册号 & "%", " ='" & txt电子帐册号) & "'"
    End If
    
    If Not IsNull(dtp时间1) Then
        If mstrFilterString <> "" Then mstrFilterString = mstrFilterString & " and "
        mstrFilterString = mstrFilterString & "出库时间 between '" & Format(dtp时间1, "yyyymmdd hh:mm:ss") & "' and '" & Format(dtp时间2, "yyyymmdd hh:mm:ss") & "'"
    End If
    If Trim(txt录入员) <> "" Then
        If mstrFilterString <> "" Then mstrFilterString = mstrFilterString & " and "
        mstrFilterString = mstrFilterString & "录入员  " & IIf(b模糊查询, " like '%" & txt录入员 & "%", " ='" & txt录入员) & "'"
    End If
             */

            if (txt_出库单号.Text.Trim().Length > 0)
            {
                if (this.myCheckBox1.Checked)  //模糊查询
                {
                    strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("出库单号 like '%{0}%'", StringTools.SqlLikeQ(txt_出库单号.Text.Trim()));
                }
                else  //精确查询
                {
                    strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("出库单号={0}", StringTools.SqlQ(txt_出库单号.Text.Trim()));
                }
            }
            if (txt_订单号码.Text.Trim().Length > 0)
            {
                if (this.myCheckBox1.Checked)  //模糊查询
                {
                    strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("制造通知单号 like '%{0}%'", StringTools.SqlLikeQ(txt_订单号码.Text.Trim()));
                }
                else  //精确查询
                {
                    strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("制造通知单号={0}", StringTools.SqlQ(txt_订单号码.Text.Trim()));
                }
            }
            if (txt_录入员.Text.Trim().Length > 0)
            {
                if (this.myCheckBox1.Checked)  //模糊查询
                {
                    strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("录入员 like '%{0}%'", StringTools.SqlLikeQ(txt_录入员.Text.Trim()));
                }
                else  //精确查询
                {
                    strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("录入员={0}", StringTools.SqlQ(txt_录入员.Text.Trim()));
                }
            }
            if (cbox_电子帐册号.SelectedIndex >= 0)
            {
                //if (this.myCheckBox1.Checked)  //模糊查询
                //{
                //    strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("电子帐册号 like '%{0}%'", StringTools.SqlLikeQ(cbox_电子帐册号.SelectedValue.ToString()));
                //}
                //else  //精确查询
                //{
                    strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("电子帐册号={0}", StringTools.SqlQ(cbox_电子帐册号.SelectedValue.ToString()));
                //}
            }

            if (date_出库时间1.Checked)
            {
                strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("出库时间 > '{0}'", date_出库时间1.Text);
            }
            if (date_出库时间2.Checked)
            {
                strReturnWhere += (strReturnWhere.Length > 0 ? " and " : "") + string.Format("出库时间 < '{0}'", date_出库时间2.Text);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void FormMaterialsOutQueryCondition_Load(object sender, EventArgs e)
        {
            this.cbox_电子帐册号.InitialData(DataAccess.DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade,
                "SELECT 手册编号 FROM 手册资料表 ORDER BY 有效期限 DESC", "手册编号", "手册编号");
        }
    }
}
