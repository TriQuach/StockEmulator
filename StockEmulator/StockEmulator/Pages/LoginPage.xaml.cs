using StockEmulator.Models;
using StockEmulator.Utilities;
using System;
using Xamarin.Forms;

namespace StockEmulator.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            SignUp.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>Navigation.PushModalAsync(new SignUpPage()))
            });

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
