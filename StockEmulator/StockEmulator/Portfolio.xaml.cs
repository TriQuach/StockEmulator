using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator
{
    public partial class Portfolio : ContentPage
    {
        public Portfolio()
        {
            InitializeComponent();

            lstView.ItemsSource = new List<Stock>
            {
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                },
                new Stock
                {
                    Ticker = "AAPL",
                    Price = 118.93,
                    Cost = 118.53,
                    Num = 10,
                    Value = 1189.30,
                    EquityName = "Apple Lnc.",
                    GOverL = 4,
                    DollarCHG = 0.400,
                    PerCentCHG = 0.337
                 
                }
            };
        }
    }
}
