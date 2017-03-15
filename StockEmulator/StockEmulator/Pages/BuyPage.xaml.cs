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
        string ticker_name;
        public BuyPage(string param)
        {
            InitializeComponent();
            ticker_name = param;
            AvailableFunds.Text = "1234";
            Ticker.Text = param;
            
        }
        async void Show_Cancle(object sender, EventArgs arg)
        {
            //TODO with ticker_name;
            await Navigation.PushAsync(new StockInfoPage(null));
        }
        async void Show_Buy(object sender, EventArgs arg)
        {
            //TODO with ticker_name;
            await Navigation.PushAsync(new StockInfoPage(null));
        }
       
    }
}
