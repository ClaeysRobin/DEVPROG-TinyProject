using System;
using System.Collections.Generic;
using System.Text;

namespace Tinyproject.Models
{
    public class StockSalesOnDate
    {
        public string date { get; set; }
        public string label { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double average { get; set; }
        public int volume { get; set; }
        public int numberOfTrades { get; set; }
        public double open { get; set; }
        public double close { get; set; }
    }
}
