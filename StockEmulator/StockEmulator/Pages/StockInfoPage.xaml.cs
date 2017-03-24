using StockEmulator.Models;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator.Pages
{
    public partial class StockInfoPage : ContentPage
    {
        public interface IBaseUrl { string Get(); }

        string ticker;
        List<Button> listHistoryOptionButton = new List<Button>();

        public StockInfoPage(StockModel stockModel)
        {
            InitializeComponent();
            ticker = stockModel.Ticker;
            Ticker.Text = stockModel.Ticker;

            listHistoryOptionButton.Add(Button1Day);
            listHistoryOptionButton.Add(Button1Week);
            listHistoryOptionButton.Add(Button1Month);
            listHistoryOptionButton.Add(Button3Months);
            listHistoryOptionButton.Add(Button6Months);
            listHistoryOptionButton.Add(Button1Year);
            listHistoryOptionButton.Add(Button2Years);
            listHistoryOptionButton.Add(Button5Years);
            listHistoryOptionButton.Add(ButtonMax);

            ChangeClickedButtonColor(Button1Day);

            var htmlSource = new HtmlWebViewSource();

            List<ChartDataModel> chartData = new List<ChartDataModel>();
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 11, 3, 17), 463.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 12, 3, 17), 353.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 13, 3, 17), 573.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 14, 3, 17), 393.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 15, 3, 17), 503.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 16, 3, 17), 643.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 17, 3, 17), 613.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 18, 3, 17), 663.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 19, 3, 17), 763.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 20, 3, 17), 633.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 21, 3, 17), 763.37, 757.8));
            chartData.Add(new ChartDataModel(new DateTime(2017, 3, 11, 22, 3, 17), 863.37, 757.8));

            string html = HTMLChartBuilder.BuildHTMLLineChartFor1DayHistory("GOOGL (Alphabet Inc.)", chartData);
            htmlSource.Html = html;

//            htmlSource.Html = @"<html>
//  <head>
//    <script type=""text/javascript"" src=""jsapi.js""></script>
//    <script type=""text/javascript"">
//       google.load(""visualization"", ""1"", { packages:[""corechart""]});
//       google.setOnLoadCallback(drawChart);
//            function drawChart() {
//                var data = google.visualization.arrayToDataTable([
        
//                  ['Year', 'Price', 'Previous Close'],
        
//                  ['2010', 1000, 600],
        
//                  ['2011', 1170, 600],
        
//                  ['2012', 660, 600],
        
//                  ['2013', 1030, 600]
//        ]);

//                var options = {
//          title: 'GOOGL (Alphabet Inc.)',
//          legend: { position: 'bottom' },
//            animation: { duration: 1000,
//                        easing: 'out'},
//            chartArea: { width: '85%', 
//                        height: '85%',
//                        left: '10%',
//                        top: '10%',
//                        right: 0,
//                        bottom: '15%'},
//            series: { 1: { lineDashStyle: [2, 4], lineWidth: 1 } }
//            };

//            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
//            chart.draw(data, options);
//        }
//    </script>
//  </head>
//  <body>
//    <div id=""chart_div""></div>
//  </body>
//</html>";
            htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();

            ChartView.Source = htmlSource;
        }

        void ChangeClickedButtonColor(Button clickedButton)
        {
            foreach (var button in listHistoryOptionButton)
            {
                if (button == clickedButton)
                {
                    button.BackgroundColor = Color.Yellow;
                }
                else
                {
                    button.BackgroundColor = Color.FromHex("#2196F3");
                }
            }
        }

        async void PressBuy(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new BuyPage(ticker));
        }

        async public void PressSell(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new SellPage());
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
