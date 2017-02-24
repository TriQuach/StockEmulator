using StockEmulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    public partial class PortfolioTab : ContentPage
    {
        public PortfolioTab()
        {
            InitializeComponent();

            lstView.ItemsSource = new List<PortfolioListViewModel>
            {
                new PortfolioListViewModel
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
                new PortfolioListViewModel
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
                new PortfolioListViewModel
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
                new PortfolioListViewModel
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
                new PortfolioListViewModel
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
                new PortfolioListViewModel
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
                new PortfolioListViewModel
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
                new PortfolioListViewModel
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
                new PortfolioListViewModel
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
                new PortfolioListViewModel
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
                new PortfolioListViewModel
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

            lstView.ItemSelected += (sender, e) =>
            {
                var item = e.SelectedItem as PortfolioListViewModel;
                if (item == null) return; // don't do anything if we just de-selected the row
                                            // do something with e.SelectedItem
                ((ListView)sender).SelectedItem = null; // de-select the row
            };
        }
    }
}
