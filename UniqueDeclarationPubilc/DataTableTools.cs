using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UniqueDeclarationPubilc
{
    public class DataTableTools
    {
        public static void AddEmptyRow(DataTable dtData)
        {
            if (dtData.Rows.Count == 0)
                dtData.Rows.Add(dtData.NewRow());
        }
    }
}
