using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class ChartDataModel
    {
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public double PreviousClosePrice { get; set; }

        public ChartDataModel(DateTime Time, double Price, double PreviousClosePrice)
        {
            this.Time = Time;
            this.Price = Price;
            this.PreviousClosePrice = PreviousClosePrice;
        }
    }
}
