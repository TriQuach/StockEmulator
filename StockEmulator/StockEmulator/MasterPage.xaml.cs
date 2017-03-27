using StockEmulator.Pages;
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
            logOut.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked()));


        }

        private async void OnLabelClicked()
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
