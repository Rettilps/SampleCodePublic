using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.API.Data
{
    public class Products
    {
        public List<string> AllergenIds { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
    }
    public class Price
    {
        public double Betrag { get; set; }
    }

}
