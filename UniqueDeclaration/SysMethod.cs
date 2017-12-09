using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UniqueDeclaration
{
    public static class SysMethod
    {
        /// <summary>
        /// 更新料件成本
        /// </summary>
        /// <param name="row">行数据</param>
        /// <param name="bPost">是否过账，如果是的话算成本；如果否的话，撤销成本</param>
        public static string updateCost(DataRow row,bool bPost)
        {
            string strError = string.Empty;
            IDataAccess dataAccess = DataAccessFactory.CreateDataAccess(DataAccessEnum.DataAccessName.DataAccessName_Manufacture);
            dataAccess.Open();
            try
            {
                if (bPost)  //（原来的入库总金额+这次的入库总金额）/（原来的数量+这次的数量）算出成本价
                {
                    int 旧料件id = Convert.ToInt32(row["料件id"]);
                    DataTable dt旧料件库存 = dataAccess.GetTable(string.Format("select * from 单耗库存查询表 where 料件id={0}", 旧料件id));
                    decimal 旧料件库存数量 = Convert.ToDecimal(dt旧料件库存.Rows[0]["数量"]);
                    decimal 旧料件成本 = Convert.ToDecimal(dataAccess.ExecScalar(string.Format("select 成本价 from 料件资料表 where 料件id={0}", 旧料件id)));
                    decimal 旧料件总金额 = 旧料件库存数量 * 旧料件成本;

                    decimal 旧料件成本更新 = (旧料件总金额 + Convert.ToDecimal(row["总金额"])) / (旧料件库存数量 + Convert.ToDecimal(row["入库数量"]));
                    dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价={0} where 料件id={1}", 旧料件成本更新, 旧料件id));
                
                }
                else  //重算库存成本，，（现有的总金额-现在的总金额）/（原来的总数量-这次的数量）
                {
                    //1、撤消修改前的库存金额和数量，算出成本
                    int 旧料件id = Convert.ToInt32(row["料件id"]);
                    DataTable dt旧料件库存 = dataAccess.GetTable(string.Format("select * from 单耗库存查询表 where 料件id={0}", 旧料件id));
                    decimal 旧料件库存数量 = Convert.ToDecimal(dt旧料件库存.Rows[0]["数量"]);
                    decimal 旧料件成本 = Convert.ToDecimal(dataAccess.ExecScalar(string.Format("select 成本价 from 料件资料表 where 料件id={0}", 旧料件id)));
                    decimal 旧料件总金额 = 旧料件库存数量 * 旧料件成本;

                    decimal 旧料件成本更新 = (旧料件总金额 - Convert.ToDecimal(row["总金额"])) / (旧料件库存数量 - Convert.ToDecimal(row["入库数量"]));
                    dataAccess.ExecuteNonQuery(string.Format("update 料件资料表 set 成本价={0} where 料件id={1}", 旧料件成本更新, 旧料件id));
                }
            }
            catch (Exception ex)
            {
                strError =string.Format("更新料件【{0}】库存成本出错：{1}", row["料件id"], ex.Message);
            }
            return strError;
        }

        /// <summary> 
        /// 转换人民币大小金额 
        /// </summary> 
        /// <param name="num">金额</param> 
        /// <returns>返回大写形式</returns> 
        public static string CmycurD(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字 
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
            string str3 = "";    //从原num值中取出的值 
            string str4 = "";    //数字的字符串形式 
            string str5 = "";  //人民币大写金额形式 
            int i;    //循环变量 
            int j;    //num的值乘以100的字符串长度 
            string ch1 = "";    //数字的汉语读法 
            string ch2 = "";    //数字位的汉字读法 
            int nzero = 0;  //用来计算连续的零值是几个 
            int temp;            //从原num值中取出的值 

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数 
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式 
            j = str4.Length;      //找出最高位 
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分 

            //循环取出每一位需要转换的值 
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值 
                temp = Convert.ToInt32(str3);      //转换为数字 
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时 
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位 
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上 
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整” 
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

    }
}
