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
    
    public partial class BuyPage : ContentPage
    {
        string ticker;
        public BuyPage(string param)
        {
            InitializeComponent();
            ticker = param;
            AvailableFunds.Text = "1234";
            EquityName.Text = "Apple Inc.";
            Ticker.Text = param;

        }
        async void PressCancel(object sender, EventArgs arg)
        {
            await Navigation.PopAsync();
        }
        async void PressBuy(object sender, EventArgs arg)
        {
            //TODO with ticker;
            long buyQuantity = long.Parse(BuyQuantity.Text);
            BuyStockModel buyingInfo = new BuyStockModel { Username = Constants.currentUsername, Ticker = ticker, NumStocks = buyQuantity };
            bool success = await App.transactionRestServiceManager.BuyStockByUsernameTickerNumStocksTaskAsync(buyingInfo);

            if (success)
            {
                await Navigation.PopAsync();
            }
        }
       
    }
}
