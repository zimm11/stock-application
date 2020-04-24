using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockApplication.Services
{
    public class StockApi
    {   
        private static readonly HttpClient Client = new HttpClient();

        public static async Task<StockApiData> GetStockData(string stockSymbol)
        {
            string requestURI = "https://cloud.iexapis.com/stable/stock/"
                + stockSymbol
                + "/quote/?token="
                + PrivateKeys.IexKey;

            try
            {
                string response = await Client.GetStringAsync(requestURI);
                StockApiData stockData = JsonConvert.DeserializeObject<StockApiData>(response);
                return stockData;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nRequest Error");
                Console.WriteLine($"Message: {e.Message}");
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Error - Please Retry");
                return null;
            }
        }

        public static async Task<Decimal> GetStockPrice(string stockSymbol)
        {
            string requestURI = "https://cloud.iexapis.com/stable/stock/"
                + stockSymbol
                + "/quote/?token="
                + PrivateKeys.IexKey;

            try
            {
                string response = await Client.GetStringAsync(requestURI);
                StockApiData stockData = JsonConvert.DeserializeObject<StockApiData>(response);
                decimal currentPrice =  stockData.IexRealtimePrice;
                return currentPrice;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nRequest Error");
                Console.WriteLine($"Message: {e.Message}");
                return 0;
            }
            catch (Exception)
            {
                Console.WriteLine("Error - Please Retry");
                return 0;
            }
        }
    }

    public class StockApiData
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal IexRealtimePrice { get; set; }

    }
}

