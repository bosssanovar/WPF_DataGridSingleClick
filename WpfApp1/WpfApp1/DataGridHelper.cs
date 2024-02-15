using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
    internal static class DataGridHelper
    {
        public static int GetSelectedColumnIndex(DataGrid grid)
        {
            return grid.CurrentCell.Column.DisplayIndex;
        }

        public static int GetSelectedRowIndex(DataGrid grid)
        {
            return grid.Items.IndexOf(grid.CurrentItem);
        }
    }
}
