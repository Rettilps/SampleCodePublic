using SampleTask.API;
using SampleTask.API.WebApi;
using SampleTask.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask
{
    public class Application
    {
        private readonly ILogger<Application> _logger;
        private readonly IHost _host;
        private readonly IFoodsApi _api;
        private readonly IWeekTable _table;

        public Application(ILogger<Application> logger, IHost host,IFoodsApi api, IWeekTable table)
        {
            _logger = logger;
            _host = host;
            _api = api;
            _table = table; 
            GetApiData();
        }

        private async void GetApiData()
        {
            var data = await _api.GetDataFromApi();
            _table.AddProductsDict(data.Products);
            _table.AddAllergenesDict(data.Allergens);
            _table.AddRowList(data.Rows);
            var tableStrings = _table.GetStringOutput();

            Console.Clear();
            foreach (var row in tableStrings)
            {
                Console.WriteLine(row);
            }
            Console.ReadKey();
        }
    }
}
