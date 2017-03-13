using StockEmulator.Models;
using StockEmulator.Utilities;
using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    public partial class MyAccountTab : ContentPage
    {
        public MyAccountTab()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            AccountModel accountInfo = await App.accountRestServiceManager.GetAccountInfoByUsernameAsync(Constants.currentUsername);

            startingInvestment.Text = accountInfo.Investment.ToString();
            stocksValue.Text = "Stocks Value?";
            availableCash.Text = accountInfo.AvailableCash.ToString();
            totalValue.Text = "Total Value?";
            position.Text = "Position?";
            totalTransactions.Text = accountInfo.TotalTrans.ToString();
            positiveTransactions.Text = accountInfo.PositiveTrans.ToString();
            negativeTransactions.Text = accountInfo.NegativeTrans.ToString();
        }
    }
}
