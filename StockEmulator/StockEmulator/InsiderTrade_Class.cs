using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator
{
    public class InsiderTrade_Class
    {
        public string Tick { get; set; }
        public string CompanyName { get; set; }
        public string Type { get; set; }
        public int Quant { get; set; }
        public double Price { get; set; }
        public string InsiderName { get; set; }
        public int Total { get; set; }
        public string Time { get; set; }
    }
}
