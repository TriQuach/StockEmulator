using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator
{
    public class TransactionListViewModel
    {
        public string Ticker { get; set; }
        public string EnquityName { get; set; }
        public string TransactionDate { get; set; }
        public float GainsLossesMoney { get; set; }
        public string TransactionType { get; set; }
        public int NumOfStocks { get; set; }
        public string GainsLossesPercent { get; set; }
        public string UnitPrice { get; set; }
        public string TotalPrice { get; set; }
    }
}
