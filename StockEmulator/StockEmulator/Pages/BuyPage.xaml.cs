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
        public BuyPage()
        {
            InitializeComponent();
            AvailableFunds.Text = "1234";
        }
        async void Show_Cancle(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new StockInfoPage());
        }
        async void Show_Buy(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new StockInfoPage());
        }
       
    }
}
