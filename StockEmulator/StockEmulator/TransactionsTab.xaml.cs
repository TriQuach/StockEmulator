using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator
{
    public partial class TransactionsTab : ContentPage
    {
        public ObservableCollection<TransactionListViewModel> TransListView { get; set; }
        public TransactionsTab()
        {
            InitializeComponent();

            TransListView = new ObservableCollection<TransactionListViewModel>();

            TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 0f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });
            TransListView.Add(new TransactionListViewModel { Ticker = "GOOGL", EnquityName = "Alphabet Inc.", TransactionDate = (new DateTime(2017, 2, 14)).ToString("dd-MM-yyyy"), GainsLossesMoney = 8.13f, TransactionType = "Sell", NumOfStocks = 3, GainsLossesPercent = 0.323f.ToString("0.000") + "%", UnitPrice = "$" + 837.32f.ToString("0.000"), TotalPrice = "$" + 2501.96f.ToString("0.000") });

            listTransaction.ItemsSource = TransListView;
            listTransaction.ItemSelected += (sender, e) =>
            {
                var item = e.SelectedItem as TransactionListViewModel;
                if (item == null) return; // don't do anything if we just de-selected the row

                ContentPage page = null;    // do something with e.SelectedItem
                if (object.Equals(item.Ticker, "GOOGL"))
                {
                    page = new StockInfoPage();
                }
                page.BindingContext = item;
                Navigation.PushAsync(page);
                ((ListView)sender).SelectedItem = null; // de-select the row
            };
        }
    }
}
