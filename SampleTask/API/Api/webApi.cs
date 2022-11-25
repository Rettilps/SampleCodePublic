using SampleTask.API.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SampleTask.API.WebApi
{
    public class webApi : IFoodsApi
    {
        public string apiUrl = @"https://sampleUrl";

        private readonly ILogger<webApi> _logger;

        private ApiResponse apiResponse;

        public webApi(ILogger<webApi> logger)
        {
            _logger = logger;
        }

        public async Task<ApiResponse?> GetDataFromApi()
        {
            return apiResponse = await ProcessRepositories(apiUrl);
        }

        private async Task<ApiResponse?> ProcessRepositories(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //var jsonString = await client.GetStringAsync(url);
                    var jsonString = mockRespornse.res;

                    var repositories = JsonSerializer.Deserialize<ApiResponse>(jsonString);

                    if (repositories != null)
                    {
                        return repositories;
                    }
                    else
                    {
                        _logger.LogInformation("Got no data from API");
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                _logger.LogError("Failed to get API response");
                return null;
            }
            

        }
    }
}
