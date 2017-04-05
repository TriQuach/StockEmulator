using StockEmulator.Models;
using StockEmulator.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    public partial class InsiderTradesTab : ContentPage
    {
        StockModel StockInfo = new StockModel();
        List<InsiderTradeModel> InsiderTrades = new List<InsiderTradeModel>();

        public InsiderTradesTab()
        {
            InitializeComponent();
            //listInsiderTrades.ItemsSource = new List<InsiderTradeModel>
            //{
            //    new InsiderTradeModel
            //    {
            //        Ticker = "OPK",
            //        CompanyName = "Exegenics Lcn (OPK)",
            //        Type = "B",
            //        Quantity = 1800,
            //        Price = 8.46,
            //        InsiderNameAndDetails = "Coleman Craig E.",
            //        Total = 15228,
            //        Time = "06:25:35 2017-02-19"
                 
            //    },
            //    new InsiderTradeModel
            //    {
            //        Ticker = "OPK",
            //        CompanyName = "Exegenics Lcn (OPK)",
            //        Type = "B",
            //        Quantity = 1800,
            //        Price = 8.46,
            //        InsiderNameAndDetails = "Coleman Craig E.",
            //        Total = 15228,
            //        Time = "06:25:35 2017-02-19"
                 
            //    }
            //};

            listInsiderTrades.ItemSelected += async (sender, e) =>
            {
                var item = e.SelectedItem as InsiderTradeModel;
                if (item == null) return; // don't do anything if we just de-selected the row

                ((ListView)sender).SelectedItem = null; // de-select the row
                StockInfo = await App.stockRestServiceManager.GetStockDataByTickerTaskAsync(item.Ticker);

                ContentPage page = null;    // do something with e.SelectedItem
                page = new StockInfoPage(StockInfo);

                page.BindingContext = item;
                await Navigation.PushAsync(page);
            };

            GetNewData();
        }

        async void GetNewData()
        {
            while (true)
            {
                loadingInsiderTrade.IsVisible = true;
                loadingInsiderTrade.IsRunning = true;

                InsiderTrades = await App.insiderTradeRestServiceManager.GetAllInsiderTradesTaskAsync();
                listInsiderTrades.ItemsSource = InsiderTrades;

                loadingInsiderTrade.IsRunning = false;
                loadingInsiderTrade.IsVisible = false;

                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}
