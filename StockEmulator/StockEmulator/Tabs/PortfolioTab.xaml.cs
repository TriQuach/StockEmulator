﻿using StockEmulator.Models;
using StockEmulator.Pages;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            //loadingPortfolio.IsVisible = true;
            //loadingPortfolio.IsRunning = true;
            listPortfolios.ItemTemplate = new DataTemplate(typeof(CustomVeggieCell));
            GetNewData();
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
               
                var verticaLayout1 = new StackLayout() {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Spacing = 0,
                    Margin = new Thickness(5,0,0,0),
                    WidthRequest = App.ScreenWidth / 5
            };

                var verticaLayout2 = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Spacing = 0,
                    WidthRequest = App.ScreenWidth /5

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

                var EquityLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    FontSize = 11,
                    TextColor = Color.FromHex("666666")
                }
                    ;
                var PriceLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Font = Font.SystemFontOfSize(11,FontAttributes.Bold)
                }
                    ;
                var CostLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 11
                }
                    ;
                var GainLossMoneyLabel = new Label()
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
                var ChangeMoneyLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 11,
                }
                    ;
                var ValueLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                    FontSize = 11,
                }
                    ;
                var ChangePercentLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                    FontSize = 11,
                    LineBreakMode = LineBreakMode.TailTruncation
                }
                    ;



                TickerLabel.SetBinding(Label.TextProperty, new Binding("Ticker"));
                EquityLabel.SetBinding(Label.TextProperty, new Binding("EquityName"));
                PriceLabel.SetBinding(Label.TextProperty, new Binding("Price"));
                CostLabel.SetBinding(Label.TextProperty, new Binding("Cost"));
                GainLossMoneyLabel.SetBinding(Label.TextProperty, new Binding("GainLossMoney"));
                NumStocksLabel.SetBinding(Label.TextProperty, new Binding("NumStocks"));
                ChangeMoneyLabel.SetBinding(Label.TextProperty, new Binding("ChangeMoney"));
                ValueLabel.SetBinding(Label.TextProperty, new Binding("Value"));
                ChangePercentLabel.SetBinding(Label.TextProperty, new Binding("ChangePercent"));


                verticaLayout1.Children.Add(TickerLabel);
                verticaLayout1.Children.Add(EquityLabel);

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

        public async void GetNewData()
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
