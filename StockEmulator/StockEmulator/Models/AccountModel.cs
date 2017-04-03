using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class AccountModel
    {
        public string Username { get; set; }
        public double StartingInvestment { get; set; }
        public decimal StocksValue { get; set; }
        public double AvailableCash { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Position { get; set; }
        public long TotalTrans { get; set; }
        public long PositiveTrans { get; set; }
        public long NegativeTrans { get; set; }
    }
}
