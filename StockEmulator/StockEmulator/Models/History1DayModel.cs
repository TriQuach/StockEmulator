using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class History1DayModel
    {
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
        public decimal PreviousClosePrice { get; set; }

        public History1DayModel(DateTime Time, decimal Price, decimal PreviousClosePrice)
        {
            this.Time = Time;
            this.Price = Price;
            this.PreviousClosePrice = PreviousClosePrice;
        }
    }
}
