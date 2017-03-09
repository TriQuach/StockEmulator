﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class TransactionModel
    {
        public string Ticker { get; set; }
        public string EquityName { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public long NumStocks { get; set; }
        public double Price { get; set; }
        public double AvgBuyPrice { get; set; }
        public double? GainLossMoney { get; set; } = 0;
        public double? GainLossPercent { get; set; } = 0;
        public double Total { get; set; } = 0;
    }
}
