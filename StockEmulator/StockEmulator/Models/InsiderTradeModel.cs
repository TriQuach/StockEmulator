using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class InsiderTradeModel
    {
        public string Ticker { get; set; }
        public string InsiderNameAndDetails { get; set; }
        public string CompanyName { get; set; }
        public string Type { get; set; }
        public int Total { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Time { get; set; }
    }
}
