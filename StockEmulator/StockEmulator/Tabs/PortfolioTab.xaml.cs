using StockEmulator.Models;
using StockEmulator.Pages;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    public partial class PortfolioTab : ContentPage
    {
        StockModel StockInfo = new StockModel();
        List<PortfolioModel> Portfolios = new List<PortfolioModel>();

        public PortfolioTab()
        {
            InitializeComponent();
            listPortfolios.ItemSelected += async (sender, e) =>
            {
                var item = e.SelectedItem as PortfolioModel;

                if (item == null) return; // don't do anything if we just de-selected the row

                ((ListView)sender).SelectedItem = null; // de-select the row
                StockInfo = await App.stockRestServiceManager.GetStockDataByTickerTaskAsync(item.Ticker);

                ContentPage page = null;    // do something with e.SelectedItem
                page = new StockInfoPage(StockInfo);

                page.BindingContext = item;
                await Navigation.PushAsync(page);
            };
            //loadingPortfolio.IsVisible = true;
            //loadingPortfolio.IsRunning = true;
            GetNewData();
        }

        public async void GetNewData()
        {
            while (true)
            {
                loadingPortfolio.IsVisible = true;
                loadingPortfolio.IsRunning = true;
                
                Portfolios = await App.portfolioRestServiceManager.GetPortfolioListByUsernameTaskAsync(Constants.currentUsername);
                listPortfolios.ItemsSource = Portfolios;
           
                loadingPortfolio.IsRunning = false;
                loadingPortfolio.IsVisible = false;

                await Task.Delay(TimeSpan.FromSeconds(10));
            }

        }

        //protected async override void OnAppearing()
        //{
        //    List<PortfolioModel> items = await App.portfolioRestServiceManager.GetPortfolioListByUsernameTaskAsync(Constants.currentUsername);

        //    //List<PortfolioListViewModel> portfolioList = new List<PortfolioListViewModel>();
        //    //foreach (var item in items)
        //    //{
        //    //    portfolioList.Add(new PortfolioListViewModel
        //    //    {
        //    //        Ticker = item.Ticker,
        //    //        Price = item.Price,
        //    //        Cost = item.Cost,
        //    //        Num = item.NumStocks,
        //    //        Value = item.Value,
        //    //        EquityName = item.Name,
        //    //        GainLossMoney = item.GainLossMoney,
        //    //        DollarCHG = item.ChangeMoney,
        //    //        PerCentCHG = item.ChangePercent
        //    //    });
        //    //}

        //    listPortfolios.ItemsSource = items;

        //    loadingPortfolio.IsRunning = false;
        //    loadingPortfolio.IsVisible = false;
        //}

       
    }
}
