using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class StockItem
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Cost { get; set; }
        public float GainLossMoney { get; set; }
        public int NumStock { get; set; }
        public float ChangeMoney { get; set; }
        public float ChangePercent { get; set; }
        public float Value { get; set; }
    }
}
