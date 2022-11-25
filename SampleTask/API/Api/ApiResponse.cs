using SampleTask.API.Data;
using SampleTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.API.WebApi
{
    public class ApiResponse
    {
        public Dictionary<string,Allergens> Allergens { get; set; }
        public Dictionary<string,Products> Products { get; set; }
        public List<Row> Rows { get; set; }
    }
}
