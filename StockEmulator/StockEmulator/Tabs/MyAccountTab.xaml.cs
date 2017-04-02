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
            //startingInvestment.Text = "1234";
            //stocksValue.Text = "Stocks Value?";
            //availableCash.Text = "1234";
            //totalValue.Text = "Total Value?";
            //position.Text = "Position?";
            //totalTransactions.Text = "1234";
            //positiveTransactions.Text = "1234";
            //negativeTransactions.Text = "1234";

            var htmlSource = new HtmlWebViewSource();

            htmlSource.Html = @"
                <html>
                    <head>
                        <script type=""text/javascript"" src=""jsapi.js""></script>
                        <script type=""text/javascript"">
                            google.load(""visualization"", ""1"", { packages:[""corechart""]});
                            google.setOnLoadCallback(drawChart);
                            
                            function drawChart() {
                                var data = google.visualization.arrayToDataTable([
                                    ['Category', 'Percent'],
                                    ['Cash',     57.9],
                                    ['GOOGL',      30.3],
                                    ['AAPL',  9.0],
                                    ['Others', 2.8]
                                ]);

                                var options = {
                                    title: 'Account Summary',
                                    pieHole: 0.4,
                                    chartArea: { width: '100%', 
                                    height: '100%',
                                    left: 0,
                                    top: '15%',
                                    right: 0,
                                    bottom: '10%'},
                                    sliceVisibilityThreshold: 0,
                                    legend: { position: 'labeled' },
                                    pieStartAngle: 90
                                };

                                var chart = new google.visualization.PieChart(document.getElementById('piechart'));

                                chart.draw(data, options);
                            }
                        </script>
                    </head>
                    <body>
                        <div id=""piechart""></div>
                    </body>
                </html>";
            htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();

            ChartView.Source = htmlSource;
        }

        protected async override void OnAppearing()
        {
            AccountModel accountData = await App.accountRestServiceManager.GetAccountTabDataByUsernameTaskAsync(Constants.currentUsername);

            accountTitle.Text = accountData.Username + "'s Account Summary";
            startingInvestment.Text = accountData.StartingInvestment.ToString();
            stocksValue.Text = accountData.StocksValue.ToString();
            availableCash.Text = accountData.AvailableCash.ToString();
            totalValue.Text = accountData.TotalValue.ToString();
            position.Text = accountData.Position.ToString();
            totalTransactions.Text = accountData.TotalTrans.ToString();
            positiveTransactions.Text = accountData.PositiveTrans.ToString();
            negativeTransactions.Text = accountData.NegativeTrans.ToString();
        }
    }
}
