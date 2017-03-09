using StockEmulator.Models;
using StockEmulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    public partial class TransactionsTab : ContentPage
    {
        //public ObservableCollection<TransactionListViewModel> TransListView { get; set; }
        public TransactionsTab()
        {
            InitializeComponent();

            //TransListView = new ObservableCollection<TransactionListViewModel>();

            //TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 0f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            //TransListView.Add(new TransactionListViewModel { Ticker = "AAA", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            //TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            //TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            //TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            //TransListView.Add(new TransactionListViewModel { Ticker = "BBC", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            //TransListView.Add(new TransactionListViewModel { Ticker = "AAPL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            //TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });

            //listTransaction.ItemsSource = TransListView;
            listTransaction.ItemSelected += (sender, e) =>
            {
                var item = e.SelectedItem as TransactionModel;
                if (item == null) return; // don't do anything if we just de-selected the row

                ContentPage page = null;    // do something with e.SelectedItem
                
                    page = new Pages.StockInfoPage(item.Ticker);
                
                page.BindingContext = item;
                Navigation.PushAsync(page);
                ((ListView)sender).SelectedItem = null; // de-select the row
            };

            loadingTransaction.IsVisible = true;
            loadingTransaction.IsRunning = true;
        }

        protected async override void OnAppearing()
        {
            List<TransactionModel> items = await App.transactionRestServiceManager.GetTransactionListByUsernameTaskAsync(Constants.currentUsername);

            foreach (var item in items)
            {
                item.Total = item.Price * item.NumStocks;
            }

            listTransaction.ItemsSource = items;

            loadingTransaction.IsRunning = false;
            loadingTransaction.IsVisible = false;
        }
    }
}
