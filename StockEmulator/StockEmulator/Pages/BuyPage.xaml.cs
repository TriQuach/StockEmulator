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
        StockModel stockModel = new StockModel();

        public BuyPage(StockModel stockModel)
        {
            InitializeComponent();

            this.stockModel = stockModel;

            EquityName.Text = stockModel.EquityName;
            Ticker.Text = stockModel.Ticker;
            Price.Text = stockModel.Price.ToString();
        }

        protected async override void OnAppearing()
        {
            AccountModel accountData = await App.accountRestServiceManager.GetAccountTabDataByUsernameTaskAsync(Constants.currentUsername);

            AvailableFunds.Text = accountData.AvailableCash.ToString();

            int buyingCapacity = Convert.ToInt32(Math.Floor(accountData.AvailableCash / stockModel.Price));
            BuyingCapacity.Text = buyingCapacity.ToString();
        }

        async void PressCancel(object sender, EventArgs arg)
        {
            await Navigation.PopAsync();
        }
        async void PressBuy(object sender, EventArgs arg)
        {
            //TODO with ticker;
            if (BuyQuantity.Text != null)
            {
                long buyQuantity = long.Parse(BuyQuantity.Text);
                BuyStockModel buyingInfo = new BuyStockModel { Username = Constants.currentUsername, Ticker = stockModel.Ticker, NumStocks = buyQuantity };
                bool success = await App.transactionRestServiceManager.BuyStockByUsernameTickerNumStocksTaskAsync(buyingInfo);

                if (success)
                {
                    await Navigation.PopAsync();
                }
            }
        }
       
    }
}
