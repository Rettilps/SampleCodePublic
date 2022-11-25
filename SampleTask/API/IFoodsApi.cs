using SampleTask.API.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.API
{
    public interface IFoodsApi
    {
        public Task<ApiResponse?> GetDataFromApi();
    }
}
