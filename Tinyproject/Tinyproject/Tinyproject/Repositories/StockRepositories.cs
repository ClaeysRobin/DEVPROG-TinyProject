using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Ex01.Models;
using Newtonsoft.Json;
using Tinyproject.Models;

namespace Tinyproject.Repositories
{
    public static class StockRepositories
    {
        private const string _APIKEY = "pk_7b3376184a694659bb2a89ee7781d00e";
        private const string _BASEURL = " https://cloud.iexapis.com/stable/stock";

        // trello 
        private const string _TRELLOAPIKEY = "da34b98e6298f9b0bd478f0e748710c7";
        private const string _TRELLOUSERTOKEN = "b13ae0159738318c933c031516ad5bb3a6e94d5d302ed6f5eb0ba35da4b67f6d";
        private const string _TRELLOBASEURL = "https://api.trello.com/1";

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

        public static async Task<List<TrelloBoard>> GetTrelloBoardsAsync()
        {
            string url = $"{_TRELLOBASEURL}/members/me/boards?key={_TRELLOAPIKEY}&token={_TRELLOUSERTOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    List<TrelloBoard> list = JsonConvert.DeserializeObject<List<TrelloBoard>>(json);
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex; //altijd breakpoint bij een catch --> xamarin stopt niet altijd bij een fout melding
                }
            }
        }

        public static async Task<List<TrelloList>> GetTrelloListAsync(string boardId)
        {
            string url = $"{_TRELLOBASEURL}/boards/{boardId}/lists?key={_TRELLOAPIKEY}&token={_TRELLOUSERTOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    List<TrelloList> list = JsonConvert.DeserializeObject<List<TrelloList>>(json);
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex; //altijd breakpoint bij een catch --> xamarin stopt niet altijd bij een fout melding
                }
            }
        }

        public static async Task<List<TrelloCard>> GetTrelloCardAsync(string ListId)
        {
            string url = $"{_TRELLOBASEURL}/list/{ListId}/cards?key={_TRELLOAPIKEY}&token={_TRELLOUSERTOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    List<TrelloCard> list = JsonConvert.DeserializeObject<List<TrelloCard>>(json);
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex; //altijd breakpoint bij een catch --> xamarin stopt niet altijd bij een fout melding
                }
            }
        }

        public static async Task AddCardAsync(string listId, TrelloCard card)
        {
            string url = $"{_TRELLOBASEURL}/cards?idList={listId}&key={_TRELLOAPIKEY}&token={_TRELLOUSERTOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    //creer een json object van de card
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesful POST to url: {url}, object: {json}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; //altijd breakpoint bij een catch --> xamarin stopt niet altijd bij een fout melding
                }
            }
        }

        public static async Task DeleteCardAsync(TrelloCard card)
        {
            string url = $"{_TRELLOBASEURL}/cards/{card.CardId}?key={_TRELLOAPIKEY}&token={_TRELLOUSERTOKEN}";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    //creer een json object van de card
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesful PUT to url: {url}, object: {json}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex; //altijd breakpoint bij een catch --> xamarin stopt niet altijd bij een fout melding
                }
            }
        }

    }
}
