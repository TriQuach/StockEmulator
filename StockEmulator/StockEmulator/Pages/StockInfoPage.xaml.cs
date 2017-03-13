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
        public StockInfoPage(string param)
        {
            InitializeComponent();
            Ticker.Text = param;

            var htmlSource = new HtmlWebViewSource();

            htmlSource.Html = @"<html>
  <head>
    <script type=""text/javascript"" src=""jsapi.js""></script>
    <script type=""text/javascript"">
       google.load(""visualization"", ""1"", { packages:[""corechart""]});
       google.setOnLoadCallback(drawChart);
            function drawChart() {
                var data = google.visualization.arrayToDataTable([
        
                  ['Year', 'Price', 'Previous Close'],
        
                  ['2010', 1000, 600],
        
                  ['2011', 1170, 600],
        
                  ['2012', 660, 600],
        
                  ['2013', 1030, 600]
        ]);

                var options = {
          title: 'GOOGL (Alphabet Inc.)',
          legend: { position: 'bottom' },
            animation: { duration: 1000,
                        easing: 'out'},
            chartArea: { width: '85%', 
                        height: '85%',
                        left: '10%',
                        top: '10%',
                        right: 0,
                        bottom: '15%'},
            series: { 1: { lineDashStyle: [2, 4], lineWidth: 1 } }
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>
  </head>
  <body>
    <div id=""chart_div""></div>
  </body>
</html>";
            htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();

            ChartView.Source = htmlSource;
        }
        async void Show_Buy(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new BuyPage());
        }
        async public void Show_Sell(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new SellPage());
        }
    }
}
