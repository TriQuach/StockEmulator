﻿using StockEmulator.Models;
using StockEmulator.Pages;
using StockEmulator.Utilities;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    public partial class PortfolioTab : ContentPage
    {
        public PortfolioTab()
        {
            InitializeComponent();
            listView.ItemSelected += (sender, e) =>
            {

                var item = e.SelectedItem as PortfolioModel;

                if (item == null) return; // don't do anything if we just de-selected the row

                ContentPage page = null;    // do something with e.SelectedItem

                page = new StockInfoPage(item.Ticker);

                page.BindingContext = item;
                Navigation.PushAsync(page);


                ((ListView)sender).SelectedItem = null; // de-select the row
            };
            loadingPortfolio.IsVisible = true;
            loadingPortfolio.IsRunning = true;
        }

        protected async override void OnAppearing()
        {
            List<PortfolioModel> items = await App.portfolioRestServiceManager.GetPortfolioListByUsernameTaskAsync(Constants.currentUsername);

            //List<PortfolioListViewModel> portfolioList = new List<PortfolioListViewModel>();
            //foreach (var item in items)
            //{
            //    portfolioList.Add(new PortfolioListViewModel
            //    {
            //        Ticker = item.Ticker,
            //        Price = item.Price,
            //        Cost = item.Cost,
            //        Num = item.NumStocks,
            //        Value = item.Value,
            //        EquityName = item.Name,
            //        GainLossMoney = item.GainLossMoney,
            //        DollarCHG = item.ChangeMoney,
            //        PerCentCHG = item.ChangePercent
            //    });
            //}

            listView.ItemsSource = items;

            loadingPortfolio.IsRunning = false;
            loadingPortfolio.IsVisible = false;
        }

       
    }
}
