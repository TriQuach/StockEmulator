using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class HistoryPriceModel
    {
        public DateTime Time { get; set; }
        public decimal Price { get; set; }

        public HistoryPriceModel(DateTime Time, decimal Price)
        {
            this.Time = Time;
            this.Price = Price;
        }
    }
}
