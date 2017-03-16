using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class BuyStockModel
    {
        public string Username { get; set; }
        public string Ticker { get; set; }
        public long NumStocks { get; set; }
    }
}
