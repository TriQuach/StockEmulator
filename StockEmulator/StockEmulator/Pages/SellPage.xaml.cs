using StockEmulator.Models;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator.Pages
{
    public partial class SellPage : ContentPage
    {
        StockModel stockModel = new StockModel();
        long sharesAvailable = 0;

        public SellPage(StockModel stockModel)
        {
            InitializeComponent();

            this.stockModel = stockModel;

            EquityName.Text = stockModel.EquityName;
            Ticker.Text = stockModel.Ticker;
            Price.Text = stockModel.Price.ToString();

            StackLayoutEquityName.WidthRequest = App.ScreenWidth / 2;
            StackLayoutTickerPrice.WidthRequest = App.ScreenWidth / 2;
            Ticker.WidthRequest = App.ScreenWidth / 4;
            Price.WidthRequest = App.ScreenWidth / 4;

            SellQuantityLabel.WidthRequest = App.ScreenWidth / 2;
            SellQuantity.WidthRequest = App.ScreenWidth / 2;

            AvailableFundsLabel.WidthRequest = App.ScreenWidth / 2;
            AvailableFunds.WidthRequest = App.ScreenWidth / 2;

            SharesAvailableLabel.WidthRequest = App.ScreenWidth / 2;
            SharesAvailable.WidthRequest = App.ScreenWidth / 2;

            TotalProceedsLabel.WidthRequest = App.ScreenWidth / 2;
            TotalProceeds.WidthRequest = App.ScreenWidth / 2;
        }

        protected async override void OnAppearing()
        {
            AccountModel accountData = await App.accountRestServiceManager.GetAccountTabDataByUsernameTaskAsync(Constants.currentUsername);
            PortfolioModel portfolio = await App.portfolioRestServiceManager.GetPortfolioByUsernameAndTickerTaskAsync(Constants.currentUsername, stockModel.Ticker);
            AvailableFunds.Text = accountData.AvailableCash.ToString();

            sharesAvailable = portfolio.NumStocks;
            SharesAvailable.Text = sharesAvailable.ToString();
        }

        void SellQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                TotalProceeds.Text = (Math.Floor(decimal.Parse(e.NewTextValue)) * stockModel.Price).ToString();
            }
            else
            {
                TotalProceeds.Text = "0";
            }
        }

        async void PressCancel(object sender, EventArgs arg)
        {
            await Navigation.PopAsync();
        }
        async void PressSell(object sender, EventArgs arg)
        {
            //TODO with ticker;
            if (SellQuantity.Text != "")
            {
                long sellQuantity = long.Parse(SellQuantity.Text);
                if (sellQuantity <= sharesAvailable)
                {
                    BuySellStockModel buySellInfo = new BuySellStockModel { Username = Constants.currentUsername, Ticker = stockModel.Ticker, NumStocks = sellQuantity, TransactionType = Constants.SELL };
                    bool success = await App.transactionRestServiceManager.BuySellStockByUsernameTickerNumStocksTaskAsync(buySellInfo);

                    if (success)
                    {
                        await Navigation.PopAsync();
                    }
                }
                else
                {
                    await DisplayAlert("Error - Sell Stock", "You do not own enough shares to sell this stock. Please reduce the quantity and retry.", "DISMISS");
                }
            }
        }
    }
}
