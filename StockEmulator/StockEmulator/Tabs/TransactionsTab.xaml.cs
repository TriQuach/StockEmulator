using StockEmulator.Models;
using StockEmulator.Pages;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    public partial class TransactionsTab : ContentPage
    {
        StockModel StockInfo = new StockModel();

        //public ObservableCollection<TransactionListViewModel> TransListView { get; set; }
        public TransactionsTab()
        {
            InitializeComponent();

            listTransaction.ItemSelected += async (sender, e) =>
            {
                var item = e.SelectedItem as TransactionModel;
                if (item == null) return; // don't do anything if we just de-selected the row

                ((ListView)sender).SelectedItem = null; // de-select the row
                StockInfo = await App.stockRestServiceManager.GetStockDataByTickerTaskAsync(item.Ticker);

                ContentPage page = null;    // do something with e.SelectedItem
                page = new StockInfoPage(StockInfo);
                
                page.BindingContext = item;
                await Navigation.PushAsync(page);
                ((ListView)sender).SelectedItem = null; // de-select the row
            };

            loadingTransaction.IsVisible = true;
            loadingTransaction.IsRunning = true;
            listTransaction.ItemTemplate = new DataTemplate(typeof(CustomVeggieCell));
            StackLayout1.WidthRequest = App.ScreenWidth / 5;
            StackLayout2.WidthRequest = App.ScreenWidth / 5;
            StackLayout3.WidthRequest = App.ScreenWidth / 5;
            StackLayout4.WidthRequest = App.ScreenWidth / 5;
            StackLayout5.WidthRequest = App.ScreenWidth / 5;
        }
        public class CustomVeggieCell : ViewCell
        {
            public CustomVeggieCell()
            {

                var verticaLayout1 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Spacing = 0,
                    Margin = new Thickness(5, 0, 0, 0),
                    WidthRequest = App.ScreenWidth / 5
                };

                var verticaLayout2 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Spacing = 0,
                    WidthRequest = App.ScreenWidth / 5

                };
                var verticaLayout3 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Spacing = 0,
                    WidthRequest = App.ScreenWidth / 5

                };
                var verticaLayout4 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Spacing = 0,
                    WidthRequest = App.ScreenWidth / 5

                };
                var verticaLayout5 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Spacing = 0,
                    Margin = new Thickness(0, 0, 5, 0),
                    WidthRequest = App.ScreenWidth / 5

                };

                var TickerLabel = new Label()
                {
                    FontSize = 11,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("007FFF")
                }
                    ;

                var EquityNameLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    FontSize = 11,
                    TextColor = Color.FromHex("666666")
                }
                    ;
                var DateLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Font = Font.SystemFontOfSize(10, FontAttributes.Bold),
                    FormattedText = "{0:dd-MM-yyyy}"
                }
                    ;
                var GainLossMoneyLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 11,
                   
                }
                    ;
                var TypeLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 11,
                }
                    ;
                var NumStocksLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 11,
                }
                    ;
                var GainLossPercentLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 11,
                }
                    ;
                var PriceLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                    FontSize = 11,
                }
                    ;
                var TotalLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                    FontSize = 11,
                    LineBreakMode = LineBreakMode.TailTruncation
                }
                    ;



                TickerLabel.SetBinding(Label.TextProperty, new Binding("Ticker"));
                EquityNameLabel.SetBinding(Label.TextProperty, new Binding("EquityName"));
                PriceLabel.SetBinding(Label.TextProperty, new Binding("Price"));
                DateLabel.SetBinding(Label.TextProperty, new Binding("Date"));
                GainLossMoneyLabel.SetBinding(Label.TextProperty, new Binding("GainLossMoney"));
                NumStocksLabel.SetBinding(Label.TextProperty, new Binding("NumStocks"));
                TotalLabel.SetBinding(Label.TextProperty, new Binding("Total"));
                GainLossPercentLabel.SetBinding(Label.TextProperty, new Binding("GainLossPercent"));
                TypeLabel.SetBinding(Label.TextProperty, new Binding("Type"));


                verticaLayout1.Children.Add(TickerLabel);
                verticaLayout1.Children.Add(EquityNameLabel);

                verticaLayout2.Children.Add(DateLabel);
                verticaLayout2.Children.Add(GainLossMoneyLabel);

                verticaLayout3.Children.Add(TypeLabel);

                verticaLayout4.Children.Add(NumStocksLabel);
                verticaLayout4.Children.Add(GainLossPercentLabel);

                verticaLayout5.Children.Add(PriceLabel);
                verticaLayout5.Children.Add(TotalLabel);



                var horizontalLayout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Horizontal,
                };
                horizontalLayout.Children.Add(verticaLayout1);
                horizontalLayout.Children.Add(verticaLayout2);
                horizontalLayout.Children.Add(verticaLayout3);
                horizontalLayout.Children.Add(verticaLayout4);
                horizontalLayout.Children.Add(verticaLayout5);

                View = horizontalLayout;
            }
        }
        protected async override void OnAppearing()
        {
            List<TransactionModel> items = await App.transactionRestServiceManager.GetTransactionListByUsernameTaskAsync(Constants.currentUsername);

            //List<TransactionModel> items = new List<TransactionModel>();
            //items.Add(new TransactionModel { Ticker = "GOOGL", EquityName = "Alphabet Inc.", Date = new DateTime(2017, 2, 14), Type = "Sell", NumStocks = 3, GainLossPercent = 0.323f, Price = 837.32f, Total = 2501.96f });
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
