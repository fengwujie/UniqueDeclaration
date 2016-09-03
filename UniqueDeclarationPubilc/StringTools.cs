using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniqueDeclarationPubilc
{
    public class StringTools
    {

        /// <summary>
        /// 去除字符串的单引号
        /// </summary>
        /// <param name="text">需要处理的字符串</param>
        public static string DeleteSingleQuote(string text)
        {
            text = text.Substring(1);
            text = text.Substring(0, text.Length - 1);
            return text;
        }

        /// <summary>
        /// 处理SQL语句中的单引号， 将一个单引号 ' 变成 '' 并将字符串的前后加上单引号
        /// 用于组装SQL语句
        /// 例如： SqlQ("aaaa'bbb") --> 'aaaa''bbb' 
        /// </summary>
        /// <param name="strTmp"></param>
        /// <returns></returns>
        public static string SqlQ(string strTmp)
        {
            string strT = strTmp;
            strT = strT.Replace("'", "''");
            strT = "'" + strT + "'";
            return strT;
        }

        /// <summary>
        /// 处理SQL语句中的单引号， 将一个单引号 ' 变成 '' 
        /// 例如： SqlQ("aaaa'bbb") --> aaaa''bbb
        /// </summary>
        /// <param name="strTmp"></param>
        /// <returns></returns>
        public static string SqlLikeQ(string strTmp)
        {
            string strT = strTmp;
            strT = strT.Replace("'", "''");
            //strT = "'" + strT + "'";
            return strT;
        }
        /// <summary>
        /// 计算文本的长度，中文算两个长度，英文算一个
        /// </summary>
        /// <param name="strText"></param>
        /// <returns>返回文本长度</returns>
        public static long TextLenght(string strText)
        {
            long len = 0;
            for (int i = 0; i < strText.Length; i++)
            {
                byte[] byte_len = Encoding.Default.GetBytes(strText.Substring(i, 1));
                if (byte_len.Length > 1)
                    len += 2;  //如果长度大于1，是中文，占两个字节，+2
                else
                    len += 1;  //如果长度等于1，是英文，占一个字节，+1
            }
            return len;
        }

        #region 字符串转数值
        /// <summary>
        /// 将string转换成int类型，如果转换失败，则返回0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int intParse(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 将string转换成int类型，如果转换失败，则返回DBNull.Value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object intParseDBNull(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch
            {
                return DBNull.Value;
            }
        }

        /// <summary>
        /// 将string转换成decimal类型，如果转换失败，则返回0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal decimalParse(string value)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 将string转换成decimal类型，如果转换失败，则返回0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object decimalParseDBNull(string value)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch
            {
                return DBNull.Value;
            }
        }

        #endregion
    }
}
