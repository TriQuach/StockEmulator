using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace StockEmulator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void Show_Buy(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new Buy());
        }
        async public void Show_Sell(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new Sell());
        }
        

    }
}
