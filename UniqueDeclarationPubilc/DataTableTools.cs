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
        /// <param name="dtData">需要增加空行的DataTable</param>
        public static void AddEmptyRow(DataTable dtData)
        {
            AddEmptyRow(dtData, true);
        }
        /// <summary>
        /// 增加一行空数据（如果DataTable行数为0时）
        /// </summary>
        /// <param name="dtData">需要增加空行的DataTable</param>
        /// <param name="bZeroRowAdd">是否行数为0时才增加</param>
        public static void AddEmptyRow(DataTable dtData,bool bZeroRowAdd)
        {
            if (bZeroRowAdd)
            {
                if (dtData.Rows.Count == 0)
                    dtData.Rows.Add(dtData.NewRow());
            }
            else
            {
                dtData.Rows.Add(dtData.NewRow());
            }
        }
        /// <summary>
        /// 将一个DataTable中的数据添加到另一个DataTable中
        /// </summary>
        /// <param name="dtSource">需要添加的数据源</param>
        /// <param name="dtDest">目标数据源</param>
        public static void DataTableAddToDataTable(DataTable dtSource, DataTable dtDest)
        {
            foreach (DataRow sRow in dtSource.Rows)
            {
                DataRow newRow = dtDest.NewRow();
                foreach (DataColumn col in dtSource.Columns)
                {
                    newRow[col.ColumnName] = sRow[col.ColumnName];
                }
                dtDest.Rows.Add(newRow);
            }
        }

    }
}
