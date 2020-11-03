using System;
using System.Collections.Generic;
using System.Text;

namespace Tinyproject.Models
{
    public class StockPrice
    {
        public string symbol { get; set; }
        public string companyName { get; set; }
        public string primaryExchange { get; set; }
        public string latestTime { get; set; }
        public double latestPrice { get; set; }
        public double previousClose { get; set; }
        public bool isUSMarketOpen { get; set; }
    }
}
