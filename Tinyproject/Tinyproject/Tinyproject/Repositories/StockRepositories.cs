using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tinyproject.Models;

namespace Tinyproject.Repositories
{
    public static class StockRepositories
    {
        private const string _APIKEY = "pk_7b3376184a694659bb2a89ee7781d00e";
        private const string _BASEURL = " https://cloud.iexapis.com/stable/stock";

        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
        }

        public static async Task<List<StockPrice>> GetCompanyStockPrice(string company)
        {
            string url = $"{_BASEURL}/{company}/quote?token={_APIKEY}&filter=symbol,companyName,primaryExchange,latestTime,latestPrice,previousClose,isUSMarketOpen";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    string js = "[" + json + "]";
                    
                    if (js != null)
                    {
                        return JsonConvert.DeserializeObject<List<StockPrice>>(js);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; //altijd breakpoint bij een catch --> xamarin stopt niet altijd bij een fout melding
                }
                return new List<StockPrice>();
            }
        }

        public static async Task<List<StockSalesOnDate>> GetStockSalesOnDate(string company, DateTime date)
        {
            string date2 = date.ToString("yyyyMMdd");
            string url = $"{_BASEURL}/{company}/chart/date/{date2}?token=pk_7b3376184a694659bb2a89ee7781d00e&filter=date,label,high,low,average,volume,numberOfTrades,open,close";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    string js = json.Replace("null", "0");
                  
                    if (js != null)
                    {
                        return JsonConvert.DeserializeObject<List<StockSalesOnDate>>(js);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; //altijd breakpoint bij een catch --> xamarin stopt niet altijd bij een fout melding
                }
                return new List<StockSalesOnDate>();
            }
        }

        public static async Task<List<CompanyInfo>> GetCompanyInfo(string company)
        {
            string url = $"{_BASEURL}/{company}/company?token={_APIKEY}&filter=symbol,companyName,exchange,industry,website,description,CEO,employees";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    string js = "[" + json + "]";

                    if (js != null)
                    {
                        return JsonConvert.DeserializeObject<List<CompanyInfo>>(js);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; //altijd breakpoint bij een catch --> xamarin stopt niet altijd bij een fout melding
                }
                return new List<CompanyInfo>();
            }
        }

    }
}
