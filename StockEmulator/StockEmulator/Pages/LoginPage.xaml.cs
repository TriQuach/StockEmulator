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
               Command = new Command(() => Navigation.PushModalAsync(new SignUpPage()))
            });

        }
        async public void PressLogin(object sender, EventArgs arg)
        {
            LoginModel thisUser = new LoginModel()
            {
                Username = username.Text,
                Password = password.Text
            };

            bool valid = await App.accountRestServiceManager.LoginTaskAsync(thisUser);
            if (valid)
            {
                Constants.currentUsername = thisUser.Username;

                //var page = new MainPage();
                //NavigationPage.SetHasNavigationBar(page, false);
                //Navigation.InsertPageBefore(page, this);
                //await Navigation.PopAsync();
                await Navigation.PushModalAsync(new MainPage());
            }        
            else
            {
                await DisplayAlert("Login Failed!", "Wrong USERNAME or PASSWORD!", "OK");
            }
//            Debug.WriteLine(valid);
        }
    }
}
