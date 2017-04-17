using StockEmulator.Pages;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator
{
    public partial class MasterPage : ContentPage
    {
        public ListView listView { get { return listMenu; } }

        public MasterPage()
        {
            InitializeComponent();

            Username.Text = Constants.currentUsername;

            Logout.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnLogoutClicked())
            });

            listMenu.ItemsSource = new string[]
            {
                "Portfolio",
                "Find Stocks",               
                "My Account",
                "Transactions",               
                "Insider Trades",
            };
            listMore.ItemsSource = new string[]
            {
                "Privacy Policy and Discaimer",
                "About us"
            };
        }

        async void OnLogoutClicked()
        {
            var accepted = await DisplayAlert("Warning!", "Do you want to Logout?", "Yes", "No");
            if (accepted)
            {

                // await Navigation.PopAsync();
                await Navigation.PushModalAsync(new LoginPage());
                

                //  await Navigation.PopAsync();
                //var existingPages = Navigation.NavigationStack.ToList();
                //foreach (var page in existingPages)
                //{
                //    Navigation.RemovePage(page);
                //}
                //await Navigation.PushModalAsync(new LoginPage());
                // Navigation.NavigationStack[0];


            }
        }
    }
}
