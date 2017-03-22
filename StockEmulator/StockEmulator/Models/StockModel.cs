using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class StockModel
    {
        public string Ticker { get; set; }
        public string EquityName { get; set; }
        public decimal Price { get; set; }
        public decimal PrevClosePrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal OpenPrice { get; set; }
        public long Volume { get; set; }
        public decimal Change { get; set; }
        public long MarketCap { get; set; }
        public decimal _52_week_High { get; set; }
        public decimal _52_week_Low { get; set; }
        public decimal AskPrice { get; set; }
        public decimal BidPrice { get; set; }
        public long AskSize { get; set; }
        public long BidSize { get; set; }
        public int UpdateChecker { get; set; }
    }
}
