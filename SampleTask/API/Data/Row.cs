using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.API.Data
{
    public class Row
    {
        public string Name { get; set; }
        public List<Day> Days { get; set; }
    }

    public class Day
    {
        public int Weekday { get; set; }
        public List<Productid> ProductIds { get; set; }
    }

    public class Productid
    {
        public int ProductId { get; set; }
    }
}
