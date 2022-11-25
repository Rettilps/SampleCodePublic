using SampleTask.API;
using SampleTask.API.WebApi;
using SampleTask.Table;

namespace SampleTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<Application>();
                    services.AddSingleton<IFoodsApi,webApi>();
                    services.AddSingleton<IWeekTable,ConsoleTable>();
                })
                .Build();

            var app = host.Services.GetRequiredService<Application>(); 
            host.Run();
        }
    }
}