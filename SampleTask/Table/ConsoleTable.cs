using SampleTask.API.Data;
using SampleTask.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Table
{
    public class ConsoleTable : IWeekTable
    {
        private Dictionary<string, Allergens> _allergenes;
        private Dictionary<string, Products> _products;
        private List<Row> _rows;
        private int _padding = 5;
        public void AddAllergenesDict(Dictionary<string, Allergens> allergenes)
        {
            this._allergenes = allergenes;
        }

        public void AddProductsDict(Dictionary<string, Products> products)
        {
            this._products = products;
        }

        public void AddRowList(List<Row> rows)
        {
            this._rows = rows;
        }

        public Table GetOutputTable()
        {
            var table = new Table();
            //Create Header
            table.Rows.Add(CreateHeader());

            foreach (var row in _rows)
            {
                var tRow = new TableRow();

                // Name Cell
                var tCell = new TableCell();
                tCell.Cotent.Add(row.Name);
                tRow.Cells.Add(tCell);

                foreach (var day in row.Days)
                {
                    var tDayCell = new TableCell();

                    foreach (var prodId in day.ProductIds)
                    {
                        if (_products.ContainsKey(prodId.ProductId.ToString()))
                        {
                            var product = _products[prodId.ProductId.ToString()];
                            
                            tDayCell.Cotent.Add(product.Name);

                            var allergeneString = string.Empty;
                            
                            foreach (var allergene in product.AllergenIds)
                            {
                                if (_allergenes.ContainsKey(allergene))
                                {
                                    var allerg = _allergenes[allergene];

                                    if(allergene.Equals(product.AllergenIds.Last()))
                                    {
                                        allergeneString += allerg.Label;
                                    }
                                    else
                                    {
                                        allergeneString += allerg.Label + ", ";
                                    }                                    
                                }
                            }
                            tDayCell.Cotent.Add(allergeneString);
                            tDayCell.Cotent.Add(product.Price.Betrag.ToString() + " EUR");
                        }
                        
                    }                    
                    tRow.Cells.Add(tDayCell);
                }

                table.Rows.Add(tRow);
            }

            return table;
            
        }

        public List<string> GetStringOutput()
        {
            var output = new List<string>();
            var table = GetOutputTable();
            
            foreach (var row in table.Rows)
            {                
                for (int i = 0; i < row.MaxStringPerCell; i++)
                {
                    var rowString = "|";
                    foreach (var cell in row.Cells)
                    {
                        if(cell.Cotent.Count > i)
                        {
                            var colWidth = table.GetColumnWidth(row.Cells.IndexOf(cell));                            
                            rowString += cell.Cotent[i];
                            rowString += new string(' ', colWidth - cell.Cotent[i].Length);
                            rowString += "|";
                        }
                        else
                        {
                            rowString += new string(' ', table.GetColumnWidth(row.Cells.IndexOf(cell)));
                            rowString += "|";
                        }
                    }
                    output.Add(rowString);
                    rowString = string.Empty;
                }
                if (output.Count > 0)
                {
                    output.Add(new string('-', output[0].Length));
                    
                }
            }

            return output;
        }

        private TableRow CreateHeader()
        {
            var curWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            // Add Header Row
            var row = new TableRow();
            row.Cells.Add(new TableCell() { Cotent = new List<string>() { String.Format("KW {0}", curWeek) } });
            row.Cells.Add(new TableCell() { Cotent = new List<string>() { "Montag" } });
            row.Cells.Add(new TableCell() { Cotent = new List<string>() { "Dienstag" } });
            row.Cells.Add(new TableCell() { Cotent = new List<string>() { "Mittwoch" } });
            row.Cells.Add(new TableCell() { Cotent = new List<string>() { "Donnerstag" } });
            row.Cells.Add(new TableCell() { Cotent = new List<string>() { "Freitag" } });
            return row;
        }
    }
}
