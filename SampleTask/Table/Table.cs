using SampleTask.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Table
{
    public class Table
    {
        public List<TableRow> Rows = new();

        public int GetColumnWidth(int columnIndex)
        {
            var width = 0;
            foreach (var row in Rows)
            {
                var cell = row.Cells.ElementAtOrDefault(columnIndex);
                if (cell != null)
                {
                    foreach (var item in cell.Cotent)
                    {
                        if (item != null && item.Length > width)
                        {
                            width = item.Length;
                        }
                    }
                }               
            }
            return width;
        }

        public int CellsPerRow
        {
            get
            {
                var count = 0;
                foreach (var row in Rows)
                {
                    if (row.Cells.Count > count)
                    {
                        count = row.Cells.Count;    
                    }
                }
                return count;
            }
        }
    }

    public class TableRow
    {
        public int MaxStringPerCell
        {
            get
            {
                var count = 0;
                foreach (var cell in Cells)
                {
                    if (cell.Cotent.Count > count)
                    {
                        count = cell.Cotent.Count;
                    }
                }
                return count;
            }
        }
        public List<TableCell> Cells = new();
    }
    public class TableCell
    {
        public List<string> Cotent = new ();
    }
}
