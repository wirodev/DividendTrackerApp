using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DividendTracker.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

class Program
{
    static async Task Main(string[] args)
    {
        
        Console.WriteLine("Fetching stock list from API...");

        // Call the API
        using (var client = new HttpClient())
        {
            // api url
            string apiUrl = "https://dividendtrackeread.azurewebsites.net/api/StocksApi";
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            // check if response is successful
            if (response.IsSuccessStatusCode)
            {
                // read the response and deserialize it
                string content = await response.Content.ReadAsStringAsync();
                var stocks = JsonConvert.DeserializeObject<List<Stock>>(content);

                Console.WriteLine("Stock List");
                Console.WriteLine();

                // print the stock list
                foreach (var stock in stocks)
                {
                    Console.WriteLine($"Ticker: {stock.Ticker}, Company Name: {stock.CompanyName}, Sector: {stock.Sector}");
                }
            }
            else
            {
                Console.WriteLine("Could not get stock list from API");
            }
        }
    }
}
