using StockEmulator.Models;
using StockEmulator.Pages;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

namespace StockEmulator.Tabs
{
    public partial class PortfolioTab : ContentPage
    {
        StockModel StockInfo = new StockModel();
        List<PortfolioModel> Portfolios = new List<PortfolioModel>();
        
        public PortfolioTab()
        {
            InitializeComponent();
            listPortfolios.ItemSelected += async (sender, e) =>
            {
                var item = e.SelectedItem as PortfolioModel;

                if (item == null) return; // don't do anything if we just de-selected the row

                ((ListView)sender).SelectedItem = null; // de-select the row
                StockInfo = await App.stockRestServiceManager.GetStockDataByTickerTaskAsync(item.Ticker);

                ContentPage page = null;    // do something with e.SelectedItem
                page = new StockInfoPage(StockInfo);

                page.BindingContext = item;
                await Navigation.PushAsync(page);
            };

            listPortfolios.ItemTemplate = new DataTemplate(typeof(CustomPortfolioCell));

            StackLayout1.WidthRequest = App.ScreenWidth / 5;
            StackLayout2.WidthRequest = App.ScreenWidth / 5;
            StackLayout3.WidthRequest = App.ScreenWidth / 5;
            StackLayout4.WidthRequest = App.ScreenWidth / 5;
            StackLayout5.WidthRequest = App.ScreenWidth / 5;

            GetNewData();
        }

        class CustomPortfolioCell : ViewCell
        {
            public CustomPortfolioCell()
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
                    FontSize = 13,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("007FFF")
                };
                var EquityNameLabel = new Label()
                {
                    FontSize = 12,
                    VerticalOptions = LayoutOptions.Center,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    TextColor = Color.FromHex("666666")
                };
                var PriceLabel = new Label()
                {
                    FontSize = 12,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("000000")
                };
                var CostLabel = new Label()
                {
                    FontSize = 12,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("000000")
                };
                var GainLossMoneyLabel = new Label()
                {
                    FontSize = 12,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("000000")
                };
                var NumStocksLabel = new Label()
                {
                    FontSize = 12,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("000000")
                };
                var ChangeMoneyLabel = new Label()
                {
                    FontSize = 12,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = Color.FromHex("000000")
                };
                var ValueLabel = new Label()
                {
                    FontSize = 12,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                    TextColor = Color.FromHex("000000")
                };
                var ChangePercentLabel = new Label()
                {
                    FontSize = 12,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                    TextColor = Color.FromHex("000000")
                };
                
                TickerLabel.SetBinding(Label.TextProperty, new Binding("Ticker"));
                EquityNameLabel.SetBinding(Label.TextProperty, new Binding("EquityName"));
                PriceLabel.SetBinding(Label.TextProperty, new Binding("Price", BindingMode.Default, new PriceTextConverter()));
                CostLabel.SetBinding(Label.TextProperty, new Binding("Cost"));
                GainLossMoneyLabel.SetBinding(Label.TextProperty, new Binding("GainLossMoney", BindingMode.Default, new GainLossMoneyTextConverter()));
                GainLossMoneyLabel.SetBinding(Label.TextColorProperty, new Binding("GainLossMoney", BindingMode.Default, new GainLossMoneyColorConverter()));
                NumStocksLabel.SetBinding(Label.TextProperty, new Binding("NumStocks"));
                ChangeMoneyLabel.SetBinding(Label.TextProperty, new Binding("ChangeMoney", BindingMode.Default, new ChangeMoneyTextConverter()));
                ChangeMoneyLabel.SetBinding(Label.TextColorProperty, new Binding("ChangeMoney", BindingMode.Default, new ChangeMoneyColorConverter()));
                ValueLabel.SetBinding(Label.TextProperty, new Binding("Value", BindingMode.Default, new ValueTextConverter()));
                ValueLabel.SetBinding(Label.TextColorProperty, new Binding("ChangeMoney", BindingMode.Default, new ValueColorConverter()));
                ChangePercentLabel.SetBinding(Label.TextProperty, new Binding("ChangePercent", BindingMode.Default, new ChangePercentTextConverter()));
                ChangePercentLabel.SetBinding(Label.TextColorProperty, new Binding("ChangePercent", BindingMode.Default, new ChangePercentColorConverter()));


                verticaLayout1.Children.Add(TickerLabel);
                verticaLayout1.Children.Add(EquityNameLabel);

                verticaLayout2.Children.Add(PriceLabel);

                verticaLayout3.Children.Add(CostLabel);
                verticaLayout3.Children.Add(GainLossMoneyLabel);

                verticaLayout4.Children.Add(NumStocksLabel);
                verticaLayout4.Children.Add(ChangeMoneyLabel);

                verticaLayout5.Children.Add(ValueLabel);
                verticaLayout5.Children.Add(ChangePercentLabel);
                
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

        class PriceTextConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    return string.Format("${0:0.00}", Math.Abs((decimal)value));
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
                    if ((decimal)value > 0)
                    {
                        return Color.FromRgb(0, 100, 0);
                    }
                    if ((decimal)value == 0)
                    {
                        return Color.FromRgb(0, 0, 0);
                    }
                }
                return Color.Default;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class ChangeMoneyTextConverter : IValueConverter
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

        class ChangeMoneyColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    if ((decimal)value < 0)
                    {
                        return Color.FromRgb(139, 0, 0);
                    }
                    if ((decimal)value > 0)
                    {
                        return Color.FromRgb(0, 100, 0);
                    }
                    if ((decimal)value == 0)
                    {
                        return Color.FromRgb(0, 0, 0);
                    }
                }
                return Color.Default;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class ValueTextConverter : IValueConverter
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

        class ValueColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    if ((decimal)value < 0)
                    {
                        return Color.FromRgb(139, 0, 0);
                    }
                    if ((decimal)value > 0)
                    {
                        return Color.FromRgb(0, 100, 0);
                    }
                    if ((decimal)value == 0)
                    {
                        return Color.FromRgb(0, 0, 0);
                    }
                }
                return Color.Default;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        class ChangePercentTextConverter : IValueConverter
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

        class ChangePercentColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    if ((decimal)value < 0)
                    {
                        return Color.FromRgb(139, 0, 0);
                    }
                    if ((decimal)value > 0)
                    {
                        return Color.FromRgb(0, 100, 0);
                    }
                    if ((decimal)value == 0)
                    {
                        return Color.FromRgb(0, 0, 0);
                    }
                }
                return Color.Default;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        async void GetNewData()
        {
            while (true)
            {
                loadingPortfolio.IsVisible = true;
                loadingPortfolio.IsRunning = true;
                
                Portfolios = await App.portfolioRestServiceManager.GetPortfolioListByUsernameTaskAsync(Constants.currentUsername);
                listPortfolios.ItemsSource = Portfolios;
           
                loadingPortfolio.IsRunning = false;
                loadingPortfolio.IsVisible = false;

                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}
