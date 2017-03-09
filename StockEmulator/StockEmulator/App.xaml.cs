using StockEmulator.Data;
using StockEmulator.Data.AccountRestService;
using StockEmulator.Data.PortfolioRestService;
using StockEmulator.Data.TransactionRestService;
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
        public static PortfolioRestServiceManager portfolioRestServiceManager { get; private set; }
        public static AccountRestServiceManager accountRestServiceManager { get; private set; }
        public static TransactionRestServiceManager transactionRestServiceManager { get; private set; }

        public App()
        {
            InitializeComponent();

            accountRestServiceManager = new AccountRestServiceManager(new AccountRestService());
            portfolioRestServiceManager = new PortfolioRestServiceManager(new PortfolioRestService());
            transactionRestServiceManager = new TransactionRestServiceManager(new TransactionRestService());
            var page = new LoginPage();
            NavigationPage.SetHasNavigationBar(page, false);
            MainPage = new NavigationPage(page);
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
