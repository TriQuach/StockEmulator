using StockEmulator.Data;
using StockEmulator.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace StockEmulator
{
    public partial class App : Application
    {
        public static StockItemManager StockManager { get; private set; }

        public App()
        {
            InitializeComponent();

           StockManager = new StockItemManager(new RestService());
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
