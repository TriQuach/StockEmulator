using StockEmulator.Models;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator.Pages
{
    public partial class StockInfoPage : ContentPage
    {
        public interface IBaseUrl { string Get(); }

        StockModel stockModel;
        List<Pair<Button, bool>> listHistoryOptionButton = new List<Pair<Button, bool>>();
        List<HistoryPriceModel> chartData = new List<HistoryPriceModel>();
        HtmlWebViewSource htmlSource = new HtmlWebViewSource();

        bool history1Day = true;

        public StockInfoPage(StockModel stockModel)
        {
            InitializeComponent();

            this.stockModel = stockModel;
            EquityName.Text = stockModel.EquityName;
            Ticker.Text = stockModel.Ticker;

            Price.Text = stockModel.Price.ToString(CultureInfo.InvariantCulture);
            if (stockModel.Change < 0)
            {
                ChangePrice.TextColor = Color.FromRgb(183, 62, 62);
                ChangePercent.TextColor = Color.FromRgb(183, 62, 62);
            }
            else
            {
                ChangePrice.TextColor = Color.FromRgb(14, 124, 17);
                ChangePercent.TextColor = Color.FromRgb(14, 124, 17);
            }
            ChangePrice.Text = stockModel.Change.ToString(CultureInfo.InvariantCulture);
            ChangePercent.Text = string.Format("{0}%", Math.Round((stockModel.Change / stockModel.PrevClosePrice) * 100, 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture));

            //AfterHoursPrice.Text = stockModel.AfterHoursPrice.ToString(CultureInfo.InvariantCulture);
            //if (stockModel.AfterHoursPrice - stockModel.Price < 0)
            //{
            //    AfterHoursChangePrice.TextColor = Color.FromRgb(183, 62, 62);
            //    AfterHoursChangePercent.TextColor = Color.FromRgb(183, 62, 62);
            //}
            //else
            //{
            //    AfterHoursChangePrice.TextColor = Color.FromRgb(14, 124, 17);
            //    AfterHoursChangePercent.TextColor = Color.FromRgb(14, 124, 17);
            //}
            //AfterHoursChangePrice.Text = (stockModel.AfterHoursPrice - stockModel.Price).ToString(CultureInfo.InvariantCulture);
            //AfterHoursChangePercent.Text = string.Format("({0}%)", Math.Round((stockModel.AfterHoursPrice - stockModel.Price) / stockModel.Price, 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture));

            HighPrice.Text = stockModel.HighPrice.ToString(CultureInfo.InvariantCulture);
            OpenPrice.Text = stockModel.OpenPrice.ToString(CultureInfo.InvariantCulture);
            Change.Text = stockModel.Change.ToString(CultureInfo.InvariantCulture);
            _52_week_High.Text = stockModel._52_week_High.ToString(CultureInfo.InvariantCulture);
            AskPrice.Text = stockModel.AskPrice.ToString(CultureInfo.InvariantCulture);
            AskSize.Text = stockModel.AskSize.ToString(CultureInfo.InvariantCulture);

            LowPrice.Text = stockModel.LowPrice.ToString(CultureInfo.InvariantCulture);
            Volume.Text = stockModel.Volume.ToString(CultureInfo.InvariantCulture);
            MarketCap.Text = stockModel.MarketCap.ToString(CultureInfo.InvariantCulture);
            _52_week_Low.Text = stockModel._52_week_Low.ToString(CultureInfo.InvariantCulture);
            BidPrice.Text = stockModel.BidPrice.ToString(CultureInfo.InvariantCulture);
            BidSize.Text = stockModel.BidSize.ToString(CultureInfo.InvariantCulture);

            listHistoryOptionButton.Add(new Pair<Button, bool>(Button1Day, true));
            listHistoryOptionButton.Add(new Pair<Button, bool>(Button1Week, false));
            listHistoryOptionButton.Add(new Pair<Button, bool>(Button1Month, false));
            listHistoryOptionButton.Add(new Pair<Button, bool>(Button3Months, false));
            listHistoryOptionButton.Add(new Pair<Button, bool>(Button6Months, false));
            listHistoryOptionButton.Add(new Pair<Button, bool>(Button1Year, false));
            listHistoryOptionButton.Add(new Pair<Button, bool>(Button2Years, false));
            listHistoryOptionButton.Add(new Pair<Button, bool>(Button5Years, false));
            listHistoryOptionButton.Add(new Pair<Button, bool>(ButtonMax, false));

            ChangeClickedButtonColor(Button1Day);

            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 11, 6, 20), 463.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 12, 15, 46), 353.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 13, 20, 14), 573.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 13, 49, 33), 393.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 14, 10, 18), 503.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 15, 17, 59), 643.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 16, 33, 28), 613.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 16, 44, 47), 663.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 17, 17, 38), 763.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 18, 28, 33), 633.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 19, 38, 29), 763.37m, 757.8m));
            //chartData.Add(new History1DayModel(new DateTime(2017, 3, 11, 20, 26, 40), 863.37m, 757.8m));

            //htmlSource.Html = @"
            //<html>
            //  <head>
            //    <script type='text/javascript' src='jsapi.js'></script>
            //    <script type='text/javascript'>
            //      google.load('visualization', '1', { packages:['corechart']});
            //      google.setOnLoadCallback(drawChart);

            //      function drawChart() {
            //          var data = new google.visualization.DataTable();

            //          data.addColumn('timeofday', 'Time of Day');
            //          data.addColumn('number', 'Price');
            //          data.addColumn('number', 'Previous Close Price');

            //          data.addRows([
            //              [[8, 30, 45], 5, 6],
            //              [[9, 0, 0], 10, 6],
            //              [[10, 0, 0, 0], 12, 6],
            //              [[10, 45, 0, 0], 13, 6],
            //              [[11, 0, 0, 0], 25, 6],
            //              [[12, 15, 45, 0], 20, 6],
            //              [[13, 0, 0, 0], 22, 6],
            //              [[14, 30, 0, 0], 16, 6],
            //              [[15, 12, 0, 0], 30, 6],
            //              [[16, 45, 0], 32, 6],
            //              [[16, 59, 0], 10, 6]
            //          ]);

            //          var options = {
            //              title: 'GOOGL (Alphabet Inc.)',
            //              legend: { position: 'bottom' },
            //              animation: { duration: 1000,
            //                          easing: 'out'},
            //              chartArea: { width: '85%', 
            //                          height: '85%',
            //                          left: '10%',
            //                          top: '10%',
            //                          right: 0,
            //                          bottom: '15%'},
            //              series: { 1: { lineDashStyle: [2, 4], lineWidth: 1 } }
            //          };

            //          var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            //          chart.draw(data, options);
            //      }
            //    </script>
            //  </head>
            //  <body>
            //    <div id='chart_div'></div>
            //  </body>
            //</html>";

            //htmlSource.Html = @"
            //<html>
            //  <head>
            //    <script type='text/javascript' src='jsapi.js'></script>
            //    <script type='text/javascript'>
            //      google.load('visualization', '1', { packages:['corechart']});
            //      google.setOnLoadCallback(drawChart);
            //          function drawChart() {
            //              var data = new google.visualization.DataTable();

            //              data.addColumn('datetime', 'Date');
            //              data.addColumn('number', 'Price');

            //              data.addRows([
            //                  [new Date(2010, 3, 19, 8, 30, 29), 5],
            //                  [new Date(2011, 3, 20, 9, 0, 30), 10],
            //                  [new Date(2012, 5, 21, 10, 23, 40), 12],
            //                  [new Date(2012, 7, 22, 5, 59, 16), 13],
            //                  [new Date(2014, 12, 22, 16, 27, 54), 25],
            //                  [new Date(2014, 12, 29, 10, 46, 33), 20],
            //                  [new Date(2015, 1, 19, 11, 28, 25), 22],
            //                  [new Date(2016, 5, 20, 10, 18, 55), 16],
            //                  [new Date(2016, 7, 17, 13, 53, 43), 30],
            //                  [new Date(2017, 9, 15, 2, 24, 17), 32],
            //                  [new Date(2017, 12, 8, 17, 36, 38), 10]
            //              ]);

            //              var options = {
            //                  title: 'GOOGL (Alphabet Inc.)',
            //                  legend: { position: 'bottom' },
            //                  animation: { duration: 1000,
            //                              easing: 'out'},
            //                  chartArea: { width: '85%', 
            //                              height: '85%',
            //                              left: '10%',
            //                              top: '10%',
            //                              right: 0,
            //                              bottom: '15%'},
            //                  series: { 1: { lineDashStyle: [2, 4], lineWidth: 1 } }
            //              };

            //              var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            //              chart.draw(data, options);
            //          }
            //    </script>
            //  </head>
            //  <body>
            //    <div id='chart_div'></div>
            //  </body>
            //</html>";

            //htmlSource.Html = @"
            //<html>
            //  <head>
            //    <script type='text/javascript' src='jsapi.js'></script>
            //    <script type='text/javascript'>
            //      google.load('visualization', '1', { packages:['corechart']});
            //      google.setOnLoadCallback(drawChart);

            //      function drawChart() {
            //          var data = google.visualization.arrayToDataTable([

            //              ['Year', 'Price', 'Previous Close'],

            //              ['2010', 1000, 600],

            //              ['2011', 1170, 600],

            //              ['2012', 660, 600],

            //              ['2013', 1030, 600]
            //          ]);

            //          var options = {
            //              title: 'GOOGL (Alphabet Inc.)',
            //              legend: { position: 'bottom' },
            //              animation: { duration: 1000,
            //                          easing: 'out'},
            //              chartArea: { width: '85%', 
            //                          height: '85%',
            //                          left: '10%',
            //                          top: '10%',
            //                          right: 0,
            //                          bottom: '15%'},
            //              series: { 1: { lineDashStyle: [2, 4], lineWidth: 1 } }
            //          };

            //          var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            //          chart.draw(data, options);
            //      }
            //    </script>
            //  </head>
            //  <body>
            //    <div id='chart_div'></div>
            //  </body>
            //</html>";

            htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();

            UpdateChartData();
        }

        public async void UpdateChartData()
        {
            string historyType = "1d";
            while (true)
            {
                if (history1Day)
                {
                    historyType = "1d";
                    chartData = await App.historyRestServiceManager.GetHistoryPriceTaskAsync(stockModel.Ticker, historyType);
                    decimal previousClosePrice = await App.historyRestServiceManager.GetPreviousClosePriceTaskAsync(stockModel.Ticker);

                    if (chartData.Count > 0)
                    {
                        htmlSource.Html = HTMLChartBuilder.BuildHTMLLineChartFor1DayHistoryPrice(stockModel.Ticker, chartData, previousClosePrice);
                    }
                    else
                    {
                        htmlSource.Html = @"<html>
                                                <body>
                                                    <p style='text-align:center;'>No Chart Data!</p>
                                                </body>
                                            </html>";
                    }
                    ChartView.Source = htmlSource;
                }
                else
                {
                    foreach (var item in listHistoryOptionButton)
                    {
                        if (item.Second == true)
                        {
                            historyType = item.First.Text;
                            break;
                        }
                    }

                    chartData = await App.historyRestServiceManager.GetHistoryPriceTaskAsync(stockModel.Ticker, historyType);

                    if (chartData.Count > 0)
                    {
                        htmlSource.Html = HTMLChartBuilder.BuildHTMLLineChartHistoryPrice(stockModel.Ticker, chartData);
                    }
                    else
                    {
                        htmlSource.Html = @"<html>
                                                <body>
                                                    <p style='text-align:center;'>No Chart Data!</p>
                                                </body>
                                            </html>";
                    }
                    ChartView.Source = htmlSource;
                }
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }

        void ChangeClickedButtonColor(Button clickedButton)
        {
            if (clickedButton == Button1Day)
            {
                history1Day = true;
            }
            else
            {
                history1Day = false;
            }
            foreach (var item in listHistoryOptionButton)
            {
                if (item.First == clickedButton)
                {
                    item.First.BackgroundColor = Color.Yellow;
                    item.Second = true;
                }
                else
                {
                    item.First.BackgroundColor = Color.FromHex("#2196F3");
                    item.Second = false;
                }
            }
        }

        async void PressBuy(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new BuyPage(stockModel));
        }

        async public void PressSell(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new SellPage(stockModel));
        }

        async void Show1DayHistoryLineChart(object sender, EventArgs arg)
        {
            ChangeClickedButtonColor(Button1Day);
        }

        async void Show1WeekHistoryLineChart(object sender, EventArgs arg)
        {
            ChangeClickedButtonColor(Button1Week);
        }

        async void Show1MonthHistoryLineChart(object sender, EventArgs arg)
        {
            ChangeClickedButtonColor(Button1Month);
        }

        async void Show3MonthsHistoryLineChart(object sender, EventArgs arg)
        {
            ChangeClickedButtonColor(Button3Months);
        }

        async void Show6MonthsHistoryLineChart(object sender, EventArgs arg)
        {
            ChangeClickedButtonColor(Button6Months);
        }

        async void Show1YearHistoryLineChart(object sender, EventArgs arg)
        {
            ChangeClickedButtonColor(Button1Year);
        }

        async void Show2YearsHistoryLineChart(object sender, EventArgs arg)
        {
            ChangeClickedButtonColor(Button2Years);
        }

        async void Show5YearsHistoryLineChart(object sender, EventArgs arg)
        {
            ChangeClickedButtonColor(Button5Years);
        }

        async void ShowMaxHistoryLineChart(object sender, EventArgs arg)
        {
            ChangeClickedButtonColor(ButtonMax);
        }
    }
}
