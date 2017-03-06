using StockEmulator.Models;
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
            lstView.ItemSelected += (sender, e) =>
            {

                var item = e.SelectedItem as PortfolioListViewModel;

                if (item == null) return; // don't do anything if we just de-selected the row

                ContentPage page = null;    // do something with e.SelectedItem

                page = new Pages.StockInfoPage(item.Ticker);

                page.BindingContext = item;
                Navigation.PushAsync(page);


                ((ListView)sender).SelectedItem = null; // de-select the row


            };
        }

        protected async override void OnAppearing()
        {
            List<PorfolioModel> items = await App.portfolioRestServiceManager.GetPortfolioListByUsernameTaskAsync(Constants.currentUsername);

            List<PortfolioListViewModel> portfolioList = new List<PortfolioListViewModel>();
            foreach (var item in items)
            {
                portfolioList.Add(new PortfolioListViewModel
                {
                    Ticker = item.Ticker,
                    Price = item.Price,
                    Cost = item.Cost,
                    Num = item.NumStocks,
                    Value = item.Value,
                    EquityName = item.Name,
                    GainLossMoney = item.GainLossMoney,
                    DollarCHG = item.ChangeMoney,
                    PerCentCHG = item.ChangePercent
                });
            }

            lstView.ItemsSource = portfolioList;
           
           
            
        }

       
    }
}
