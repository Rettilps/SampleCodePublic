using SampleTask.API.Data;
using SampleTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Table
{
    public interface IWeekTable
    {
        public void AddAllergenesDict(Dictionary<string, Allergens> allergenes);
        public void AddProductsDict(Dictionary<string, Products> products);
        public void AddRowList(List<Row> rows);
        public Table GetOutputTable();
        public List<string> GetStringOutput();

    }
}
