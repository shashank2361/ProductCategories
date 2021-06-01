using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProductCategories.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Product and Categories!");
            Console.WriteLine("Enter the following numbers for the Categories");
            Console.WriteLine("1 : Home");
            Console.WriteLine("2 : Garden");
            Console.WriteLine("3 : Electronics");
            Console.WriteLine("4 : Fitness");
            Console.WriteLine("5 : Toys");

                RunAsync().GetAwaiter().GetResult();

            //var services = ConfigureServices();
            //var serviceProvider = services.BuildServiceProvider();
            //serviceProvider.GetService<ProductConsole>().RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            AuthConfig config = AuthConfig.ReadFromJsonFile("appsettings.json");
 
            var httpClient = new HttpClient();
            var defaultRequestHeaders = httpClient.DefaultRequestHeaders;

            int i = 0;

            do
            {
            
                i++;

                var category = Console.ReadLine();


                var baseAddress = String.Format(" {0}{1}", config.BaseAddress, category.ToString());

                if (defaultRequestHeaders.Accept == null ||
                       !defaultRequestHeaders.Accept.Any(m => m.MediaType == "application/json"))
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new
                      MediaTypeWithQualityHeaderValue("application/json"));
                }

                //defaultRequestHeaders.Authorization = 
                //     new AuthenticationHeaderValue("bearer", result.AccessToken);

                HttpResponseMessage response = await httpClient.GetAsync(baseAddress);


                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    string json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                }

                else if (response.StatusCode ==  System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"No record Found: {response.StatusCode}");
                   
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Failed to call the Web Api: {response.StatusCode}");
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Content: {content}");
                }

 

            } while (i < 10);


            
            Console.WriteLine("//================Finish=========================================");





        }




         


    }
}
