using StockEmulator.Models;
using StockEmulator.Utilities;
using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    
    public partial class MyAccountTab : ContentPage
    {
        public interface IBaseUrl { string Get(); }
        public MyAccountTab()
        {
            InitializeComponent();
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

        protected async override void OnAppearing()
        {
            AccountModel accountInfo = await App.accountRestServiceManager.GetAccountInfoByUsernameAsync(Constants.currentUsername);

            startingInvestment.Text = accountInfo.Investment.ToString();
            stocksValue.Text = "Stocks Value?";
            availableCash.Text = accountInfo.AvailableCash.ToString();
            totalValue.Text = "Total Value?";
            position.Text = "Position?";
            totalTransactions.Text = accountInfo.TotalTrans.ToString();
            positiveTransactions.Text = accountInfo.PositiveTrans.ToString();
            negativeTransactions.Text = accountInfo.NegativeTrans.ToString();
        }
    }
}
