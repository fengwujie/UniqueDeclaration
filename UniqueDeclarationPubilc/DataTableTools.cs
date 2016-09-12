using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UniqueDeclarationPubilc
{
    public class DataTableTools
    {
        /// <summary>
        /// 增加一行空数据（如果DataTable行数为0时）
        /// </summary>
        /// <param name="dtData"></param>
        public static void AddEmptyRow(DataTable dtData)
        {
            if (dtData.Rows.Count == 0)
                dtData.Rows.Add(dtData.NewRow());
        }
    }
}
