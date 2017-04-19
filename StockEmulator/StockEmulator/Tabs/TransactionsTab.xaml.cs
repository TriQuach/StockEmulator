using StockEmulator.Models;
using StockEmulator.Pages;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Globalization;

namespace StockEmulator.Tabs
{
    public partial class TransactionsTab : ContentPage
    {
        StockModel StockInfo = new StockModel();

        //public ObservableCollection<TransactionListViewModel> TransListView { get; set; }
        public TransactionsTab()
        {
            InitializeComponent();

            listTransactions.ItemSelected += async (sender, e) =>
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

            listTransactions.ItemTemplate = new DataTemplate(typeof(CustomTransactionCell));

            StackLayout1.WidthRequest = App.ScreenWidth / 5;
            StackLayout2.WidthRequest = App.ScreenWidth / 5;
            StackLayout3.WidthRequest = App.ScreenWidth / 5;
            StackLayout4.WidthRequest = App.ScreenWidth / 5;
            StackLayout5.WidthRequest = App.ScreenWidth / 5;
        }

        public class CustomTransactionCell : ViewCell
        {
            TransactionModel transactionModel;

            StackLayout verticaLayout1 = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
                Margin = new Thickness(5, 0, 0, 0),
                WidthRequest = App.ScreenWidth / 5
            };

            StackLayout verticaLayout2 = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
                WidthRequest = App.ScreenWidth / 5
            };
            StackLayout verticaLayout3 = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
                WidthRequest = App.ScreenWidth / 5
            };
            StackLayout verticaLayout4 = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
                WidthRequest = App.ScreenWidth / 5
            };

            Label TickerLabel = new Label()
            {
                FontSize = 13,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("007FFF")
            };
            Label EquityNameLabel = new Label()
            {
                FontSize = 12,
                VerticalOptions = LayoutOptions.Center,
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.FromHex("666666")
            };
            Label DateLabel = new Label()
            {
                FontSize = 11,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("000000")
            };
            Label GainLossMoneyLabel = new Label()
            {
                FontSize = 12,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("000000")
            };
            Label TypeLabel = new Label()
            {
                FontSize = 12,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("000000")
            };
            Label NumStocksLabel = new Label()
            {
                FontSize = 12,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("000000")
            };
            Label GainLossPercentLabel = new Label()
            {
                FontSize = 12,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("000000")
            };
            Label PriceLabel = new Label()
            {
                FontSize = 12,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                TextColor = Color.FromHex("000000")
            };
            Label TotalLabel = new Label()
            {
                FontSize = 12,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                TextColor = Color.FromHex("000000")
            };

            public CustomTransactionCell()
            {
                TickerLabel.SetBinding(Label.TextProperty, new Binding("Ticker"));
                EquityNameLabel.SetBinding(Label.TextProperty, new Binding("EquityName"));
                DateLabel.SetBinding(Label.TextProperty, new Binding("Date", BindingMode.Default, new DateConverter()));
                GainLossMoneyLabel.SetBinding(Label.TextProperty, new Binding("GainLossMoney", BindingMode.Default, new GainLossMoneyTextConverter()));
                GainLossMoneyLabel.SetBinding(Label.TextColorProperty, new Binding("GainLossMoney", BindingMode.Default, new GainLossMoneyColorConverter()));
                TypeLabel.SetBinding(Label.TextProperty, new Binding("Type"));
                NumStocksLabel.SetBinding(Label.TextProperty, new Binding("NumStocks"));
                GainLossPercentLabel.SetBinding(Label.TextProperty, new Binding("GainLossPercent", BindingMode.Default, new GainLossPercentTextConverter()));
                GainLossPercentLabel.SetBinding(Label.TextColorProperty, new Binding("GainLossPercent", BindingMode.Default, new GainLossPercentColorConverter()));
                PriceLabel.SetBinding(Label.TextProperty, new Binding("Price", BindingMode.Default, new PriceTextConverter()));
                TotalLabel.SetBinding(Label.TextProperty, new Binding("Total", BindingMode.Default, new TotalTextConverter()));

                verticaLayout1.Children.Add(TickerLabel);
                verticaLayout1.Children.Add(EquityNameLabel);

                verticaLayout2.Children.Add(DateLabel);
                verticaLayout2.Children.Add(GainLossMoneyLabel);

                verticaLayout3.Children.Add(TypeLabel);

                verticaLayout4.Children.Add(NumStocksLabel);
                verticaLayout4.Children.Add(GainLossPercentLabel);
            }

            protected override void OnBindingContextChanged()
            {
                base.OnBindingContextChanged();

                if (BindingContext == null)
                {
                    return;
                }

                transactionModel = (TransactionModel)BindingContext;

                var verticaLayout5 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Spacing = 0,
                    Margin = new Thickness(0, 0, 5, 0),
                    WidthRequest = App.ScreenWidth / 5
                };

                var horizontalLayout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Horizontal
                };

                if (transactionModel.Type == Constants.BUY)
                {
                    PriceLabel.TextColor = Color.FromRgb(0, 0, 0);
                    TotalLabel.TextColor = Color.FromRgb(0, 0, 0);
                }
                else if (transactionModel.GainLossMoney < 0)
                {
                    PriceLabel.TextColor = Color.FromRgb(139, 0, 0);
                    TotalLabel.TextColor = Color.FromRgb(139, 0, 0);
                }
                else
                {
                    PriceLabel.TextColor = Color.FromRgb(0, 100, 0);
                    TotalLabel.TextColor = Color.FromRgb(0, 100, 0);
                }

                verticaLayout5.Children.Add(PriceLabel);
                verticaLayout5.Children.Add(TotalLabel);

                horizontalLayout.Children.Add(verticaLayout1);
                horizontalLayout.Children.Add(verticaLayout2);
                horizontalLayout.Children.Add(verticaLayout3);
                horizontalLayout.Children.Add(verticaLayout4);
                horizontalLayout.Children.Add(verticaLayout5);

                View = horizontalLayout;
            }
        }

        class DateConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    return string.Format("{0:dd-MM-yyyy}", value);
                }
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class GainLossMoneyTextConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    return string.Format("${0:0.000}", Math.Abs((decimal)value));
                }
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class GainLossMoneyColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    if ((decimal)value < 0)
                    {
                        return Color.FromRgb(139, 0, 0);
                    }
                    if ((decimal)value >= 0)
                    {
                        return Color.FromRgb(0, 100, 0);
                    }
                }
                return Color.Default;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class GainLossPercentTextConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    return string.Format("{0:0.000}%", Math.Abs((decimal)value));
                }
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class GainLossPercentColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    if ((decimal)value < 0)
                    {
                        return Color.FromRgb(139, 0, 0);
                    }
                    if ((decimal)value >= 0)
                    {
                        return Color.FromRgb(0, 100, 0);
                    }
                }
                return Color.Default;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class PriceTextConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    return string.Format("${0:0.000}", Math.Abs((decimal)value));
                }
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class TotalTextConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    return string.Format("${0:0.000}", Math.Abs((decimal)value));
                }
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        protected async override void OnAppearing()
        {
            loadingTransactions.IsVisible = true;
            loadingTransactions.IsRunning = true;

            List<TransactionModel> items = await App.transactionRestServiceManager.GetTransactionListByUsernameTaskAsync(Constants.currentUsername);
            
            foreach (var item in items)
            {
                item.Total = item.Price * item.NumStocks;
            }

            listTransactions.ItemsSource = items;

            loadingTransactions.IsRunning = false;
            loadingTransactions.IsVisible = false;
        }
    }
}
