using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class PortfolioModel
    {
        public string Ticker { get; set; }
        public string EquityName { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal GainLossMoney { get; set; }
        public long NumStocks { get; set; }
        public decimal ChangeMoney { get; set; }
        public decimal Value { get; set; }
        public decimal ChangePercent { get; set; }
    }
}
