using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.ViewModels
{
    public class PortfolioListViewModel
    {
        public string Ticker { get;set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public long Num { get; set;}
        public double Value { get; set; }
        public string EquityName { get; set; }
        public double GainLossMoney { get; set; }
        public double DollarCHG { get; set; }
        public double PerCentCHG { get; set; }

    }
}
