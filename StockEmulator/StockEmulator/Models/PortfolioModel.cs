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
        public double Price { get; set; }
        public double Cost { get; set; }
        public double GainLossMoney { get; set; }
        public long NumStocks { get; set; }
        public double ChangeMoney { get; set; }
        public double Value { get; set; }
        public double ChangePercent { get; set; }
    }
}
