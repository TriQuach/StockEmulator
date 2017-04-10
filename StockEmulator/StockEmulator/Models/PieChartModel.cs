using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class PieChartModel : IComparable<PieChartModel>
    {
        public string Ticker { get; set; }
        public decimal Value { get; set; }

        public PieChartModel(string Ticker, decimal Value)
        {
            this.Ticker = Ticker;
            this.Value = Value;
        }

        public int CompareTo(PieChartModel other)
        {
            if (this.Value == other.Value)
            {
                return string.Compare(this.Ticker, other.Ticker, StringComparison.Ordinal);
            }
            return other.Value.CompareTo(this.Value);
        }
    }
}
