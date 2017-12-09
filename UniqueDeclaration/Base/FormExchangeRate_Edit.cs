using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniqueDeclarationPubilc;

namespace UniqueDeclaration.Base
{
    public partial class FormExchangeRate_Edit : Form
    {
        public FormExchangeRate_Edit()
        {
            InitializeComponent();
        }

        public int iYear = 0;
        public int iMonth = 0;
        public decimal rate = 0;
        /// <summary>
        /// 编辑模式,1=新增；2=修改
        /// </summary>
        public int iModel = 0;

        private void FormExchangeRate_Edit_Load(object sender, EventArgs e)
        {
            if(iModel == 2)
            {
                txt_Year.Text = iYear.ToString();
                txt_Month.Text = iMonth.ToString();
                txt_Rate.Text = rate.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txt_Year.Text.Trim().Length == 0)
            {
                SysMessage.InformationMsg(string.Format("【{0}】不能为空！", lab_Year.Text));
                txt_Year.Focus();
                return;
            }
            if (txt_Month.Text.Trim().Length == 0)
            {
                SysMessage.InformationMsg(string.Format("【{0}】不能为空！", lab_Month.Text));
                txt_Month.Focus();
                return;
            }
            if (txt_Rate.Text.Trim().Length == 0)
            {
                SysMessage.InformationMsg(string.Format("【{0}】不能为空！", lab_Rate.Text));
                txt_Rate.Focus();
                return;
            }
            int year = 0;
            try
            {
                year = int.Parse(txt_Year.Text.Trim());
                if (year < 2000 || year > 9999)
                    throw new Exception("数值错误");
            }
            catch
            {
                SysMessage.ErrorMsg(string.Format("【{0}】数值错误，请重新输入！", lab_Year.Text));
                txt_Year.Focus();
                return;
            }
            int month = 0;
            try
            {
                month = int.Parse(txt_Month.Text.Trim());
                if (month < 1 || month > 12)
                    throw new Exception("数值错误");
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("【{0}】数值错误，请重新输入！", lab_Month.Text));
                txt_Month.Focus();
                return;
            }
            decimal rateT = 0;
            try
            {
                rateT = decimal.Parse(txt_Rate.Text.Trim());
            }
            catch (Exception ex)
            {
                SysMessage.ErrorMsg(string.Format("【{0}】数值错误，请重新输入！", lab_Rate.Text));
                txt_Rate.Focus();
                return;
            }
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Uniquegrade);
            dataAccess.Open();
            DataTable dtExchangeRate = dataAccess.GetTable(string.Format("select * from exchangerate where iyear={0} and imonth={1}", iYear, iMonth));
            if (dtExchangeRate.Rows.Count > 0)
            {
                dataAccess.ExecuteNonQuery(string.Format("update exchangerate set rate={0} where iyear={1} and imonth={2}", rateT, year, month));
            }
            else
            {
                dataAccess.ExecuteNonQuery(string.Format("insert into exchangerate (iyear,imonth,rate) values ({0},{1},{2})", year, month, rateT));
            }
            dataAccess.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
