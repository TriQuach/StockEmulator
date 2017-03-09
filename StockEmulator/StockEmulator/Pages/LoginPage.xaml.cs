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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        async public void Show_Login(object sender, EventArgs arg)
        {
            LoginModel thisUser = new LoginModel()
            {
                Username = username.Text,
                Password = password.Text
            };
            Constants.currentUsername = thisUser.Username;

            bool valid = await App.accountRestServiceManager.SendLoginInfo(thisUser);
            if (valid)
            {
              await Navigation.PushModalAsync(new MainPage());
              
            }        
            else
            {
                DisplayAlert("Login Failed !", "Wrong USERNAME or PASSWORD !!", "OK");
            }
//            Debug.WriteLine(valid);
        }
    }
}
