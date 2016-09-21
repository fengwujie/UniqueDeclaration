using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration
{
    public partial class FormMaterialsInInput : UniqueDeclarationBaseForm.FormBaseInput
    {
        public FormMaterialsInInput()
        {
            InitializeComponent();
        }


        #region 自定义变量
        /// <summary>
        /// 电子帐册号
        /// </summary>
        public string strBooksNo = string.Empty;
        /// <summary>
        /// 是否触发值变化事件
        /// </summary>
        private bool bcbox_电子帐册号_SelectedIndexChanged = true;
        /// <summary>
        /// 是否已经导入过数据
        /// </summary>
        private bool Importid = false;
        #endregion

        #region 窗体事件
        public override void FormBaseInput_Load(object sender, EventArgs e)
        {
            //base.FormBaseInput_Load(sender, e);
            InitControlData();
            LoadDataSource();
            InitGrid();
        }
        #endregion

        #region 表头控件事件
        private void txt_入库单号1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !check入库单号();
        }
        private void txt_入库单号1_Validated(object sender, EventArgs e)
        {
            string str入库单号 = txt_入库单号1.Text.Trim() + txt_入库单号2.Text.Trim();
            if (rowHead["入库单号"].ToString() != str入库单号)
            {
                rowHead["入库单号"] = str入库单号;
            }
        }
        private void txt_入库单号2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !check入库单号();
        }
        private void txt_入库单号2_Validated(object sender, EventArgs e)
        {
            string str入库单号 = txt_入库单号1.Text.Trim() + txt_入库单号2.Text.Trim();
            if (rowHead["入库单号"].ToString() != str入库单号)
            {
                rowHead["入库单号"] = str入库单号;
            }
        }
        /// <summary>
        /// 检查入库单号的合法性
        /// </summary>
        /// <returns>返回检查结果</returns>
        private bool check入库单号()
        {
            bool bReturn = true;
            string str入库单号 = string.Format("{0}{1}", txt_入库单号1.Text.Trim(), txt_入库单号2.Text.Trim());
            bool isCheck = false;
            if (rowHead.RowState == DataRowState.Added)
            {
                isCheck = true;
            }
            else if (rowHead.RowState == DataRowState.Modified)
            {
                if (rowHead["入库单号", DataRowVersion.Original].ToString() != str入库单号)
                {
                    isCheck = true;
                }
            }
            if (isCheck)
            {
                string strSQL = string.Format("SELECT 料件入库表id FROM 进口料件入库表 WHERE 入库单号 = ={0}", StringTools.SqlQ(str入库单号));
                IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
                dataAccess.Open();
                DataTable dtData = dataAccess.GetTable(strSQL, null);
                dataAccess.Close();
                if (dtData.Rows.Count == 0)
                {
                    bReturn = true;
                }
                else
                {
                    SysMessage.InformationMsg("此出库单已存在！");
                    bReturn = false;
                }
            }
            return bReturn;
        }

        private void date_入库时间_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(rowHead["入库时间"]) != date_入库时间.Value)
            {
                rowHead["入库时间"] = date_入库时间.Value;
            }
        }

        private void txt_录入员_Validated(object sender, EventArgs e)
        {
            if (rowHead["录入员"].ToString() != txt_录入员.Text)
            {
                rowHead["录入员"] = txt_录入员.Text;
            }
        }

        private void cbox_电子帐册号_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bcbox_电子帐册号_SelectedIndexChanged && rowHead["手册编号"].ToString() != cbox_电子帐册号.SelectedValue.ToString())
                rowHead["手册编号"] = cbox_电子帐册号.SelectedValue;
        }

        private void txt_报关单号_Validated(object sender, EventArgs e)
        {
            if (rowHead["报关单号"].ToString() != txt_报关单号.Text)
            {
                rowHead["报关单号"] = txt_报关单号.Text;
            }
        }

        private void txt_清单编号_Validated(object sender, EventArgs e)
        {
            if (rowHead["清单编号"].ToString() != txt_清单编号.Text)
            {
                rowHead["清单编号"] = txt_清单编号.Text;
            }
        }

        private void txt_发票号_Validated(object sender, EventArgs e)
        {
            if (rowHead["发票号"].ToString() != txt_发票号.Text)
            {
                rowHead["发票号"] = txt_发票号.Text;
            }
        }

        private void txt_摘要_Validated(object sender, EventArgs e)
        {
            if (rowHead["摘要"].ToString() != txt_摘要.Text)
            {
                rowHead["摘要"] = txt_摘要.Text;
            }
        }

        private void txt_用途_Validated(object sender, EventArgs e)
        {
            if (rowHead["用途"].ToString() != txt_用途.Text)
            {
                rowHead["用途"] = txt_用途.Text;
            }
        }

        private void txt_征免方式_Validated(object sender, EventArgs e)
        {
            if (rowHead["征免方式"].ToString() != txt_征免方式.Text)
            {
                rowHead["征免方式"] = txt_征免方式.Text;
            }
        }

        private void txt_产销国_Validated(object sender, EventArgs e)
        {
            if (rowHead["产销国"].ToString() != txt_产销国.Text)
            {
                rowHead["产销国"] = txt_产销国.Text;
            }
        }

        private void txt_币制_Validated(object sender, EventArgs e)
        {
            if (rowHead["币制"].ToString() != txt_币制.Text)
            {
                rowHead["币制"] = txt_币制.Text;
            }
        }

        private void txt_申报地海关代码_Validated(object sender, EventArgs e)
        {
            if (rowHead["申报地海关代码"].ToString() != txt_申报地海关代码.Text)
            {
                rowHead["申报地海关代码"] = txt_申报地海关代码.Text;
            }
        }

        private void txt_进口岸代码_Validated(object sender, EventArgs e)
        {
            if (rowHead["进口岸代码"].ToString() != txt_进口岸代码.Text)
            {
                rowHead["进口岸代码"] = txt_进口岸代码.Text;
            }
        }

        private void txt_代理单位代码_Validated(object sender, EventArgs e)
        {
            if (rowHead["代理单位代码"].ToString() != txt_代理单位代码.Text)
            {
                rowHead["代理单位代码"] = txt_代理单位代码.Text;
            }
        }
        #endregion

        private void txt_清单编号_Validating(object sender, CancelEventArgs e)
        {
            if (txt_清单编号.Text.Trim() == "") return;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            DataTable rs = dataAccess.GetTable(string.Format( "SELECT * FROM 料件入库表 WHERE 清单编号 ={0}",StringTools.SqlQ(txt_清单编号.Text.Trim())),null);
            dataAccess.Close();
            if (rs.Rows.Count > 0)
            {

            }
            else
            {
                SysMessage.InformationMsg("此清单编号不存在");
            }
            /*
            Dim rs As ADODB.Recordset
            If Trim(txt清单编号) = "" Then Exit Sub
            Set rs = deManufacture.cnnPublic.Execute("SELECT * FROM 料件入库表 WHERE 清单编号 ='" & Trim(txt清单编号) & "'")
            If rs.RecordCount > 0 Then
                txt清单编号 = rs!清单编号
                DataEx.MainRS!清单编号 = rs!清单编号 & ""
            Else
                MsgBox "此清单编号不存在"
                txt清单编号 = ""
            End If
             */
        }

        private void txt_发票号_Validating(object sender, CancelEventArgs e)
        {
            /*
             Dim rs As ADODB.Recordset
            If Trim(txt发票号) = "" Then Exit Sub
            Set rs = deManufacture.cnnPublic.Execute("SELECT * FROM 料件入库表 WHERE 发票号 ='" & Trim(txt发票号) & "'")
            If rs.RecordCount > 0 Then
                txt发票号 = rs!发票号
                DataEx.MainRS!发票号 = rs!发票号 & ""
            Else
                MsgBox "此发票号不存在"
                txt发票号 = ""
            End If
             */
        }

        private void txt_报关单号_Validating(object sender, CancelEventArgs e)
        {
            /*
             Dim rs As ADODB.Recordset
            If Trim(txt报关单号) = "" Then Exit Sub
            Set rs = deManufacture.cnnPublic.Execute("SELECT * FROM 料件入库表 WHERE 报关单号 ='" & Trim(txt报关单号) & "'")
            If rs.RecordCount > 0 Then
                txt报关单号 = rs!报关单号
                DataEx.MainRS!报关单号 = rs!报关单号 & ""
            Else
                MsgBox "此报关单号不存在"
                txt报关单号 = ""
            End If
             */
        }
    }
}
