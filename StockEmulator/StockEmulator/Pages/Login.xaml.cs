using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StockEmulator.Pages
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        async public void Show_Login(object sender, EventArgs arg)
        {
            Account myAccount = new Account()
            {
                Username = username.Text,
                Password = password.Text
            };

            bool valid = await App.StockManager.Login(myAccount);
            if (valid)
            {
                await Navigation.PushAsync(new MainPage());
            }        
//            Debug.WriteLine(valid);
        }
    }
}
