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
        async public void PressLogin(object sender, EventArgs arg)
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
                var page = new MainPage();
                NavigationPage.SetHasNavigationBar(page, false);
                Navigation.InsertPageBefore(page, this);
                await Navigation.PopAsync();

            }        
            else
            {
                DisplayAlert("Login Failed !", "Wrong USERNAME or PASSWORD !!", "OK");
            }
//            Debug.WriteLine(valid);
        }
    }
}
