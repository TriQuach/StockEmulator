using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class TransactionModel
    {
        public string Ticker { get; set; }
        public string EquityName { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public long NumStocks { get; set; }
        public double Price { get; set; }
        public double AvgBuyPrice { get; set; }

        double? default1 = 0;
        public double? GainLossMoney {
            get
            {
                return default1;
            }
            set
            {
                default1 = value;
            }
        }
        public double? GainLossPercent {
            get
            {
                return default1;
            }
            set
            {
                default1 = value;
            }
        }

        double default2 = 0;
        public double Total {
            get
            {
                return default2;
            }
            set
            {
                default2 = value;
            }
        }
    }
}
