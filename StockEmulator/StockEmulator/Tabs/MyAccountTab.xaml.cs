using StockEmulator.Models;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
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

            //var htmlSource = new HtmlWebViewSource();

            //htmlSource.Html = @"
            //    <html>
            //        <head>
            //            <script type='text/javascript' src='jsapi.js'></script>
            //            <script type='text/javascript'>
            //                google.load('visualization', '1', { packages:['corechart']});
            //                google.setOnLoadCallback(drawChart);

            //                function drawChart() {
            //                    var data = google.visualization.arrayToDataTable([
            //                        ['Category', 'Percent'],
            //                        ['Cash',     57.9],
            //                        ['GOOGL',      30.3],
            //                        ['AAPL',  9.0],
            //                        ['Others', 2.8]
            //                    ]);

            //                    var options = {
            //                        title: 'Account Summary',
            //                        pieHole: 0.4,
            //                        chartArea: { width: '100%', 
            //                        height: '100%',
            //                        left: 0,
            //                        top: '15%',
            //                        right: 0,
            //                        bottom: '10%'},
            //                        sliceVisibilityThreshold: 0,
            //                        legend: { position: 'labeled' },
            //                        pieStartAngle: 90
            //                    };

            //                    var chart = new google.visualization.PieChart(document.getElementById('piechart'));

            //                    chart.draw(data, options);
            //                }
            //            </script>
            //        </head>
            //        <body>
            //            <div id='piechart'></div>
            //        </body>
            //    </html>";

            //   htmlSource.Html = @"
            //       <html>
            //           <head>
            //               <script type='text/javascript' src='jsapi.js'></script>
            //               <script type='text/javascript'>
            //                   google.load('visualization', '1', { packages:['corechart']});
            //                   google.setOnLoadCallback(drawChart);
                               
            //                   var data, options, chart;
                               
            //                   // initial value
            //                   var percent1 = 0;
            //                   var percent2 = 0;
            //                   var percent3 = 0;
            //                   var percent4 = 0;
            //                   var percent5 = 0;

            //                   function drawChart() {
            //                   	data = new google.visualization.DataTable();
                               
            //                   	data.addColumn('string', 'Category');
            //                   	data.addColumn('number', 'Percentage');
                               	
            //                   	data.addRows([
            //                           ['Cash', 0.1],
            //                   	    ['AAA', 0],
            //                   	    ['ASM', 0],
            //                   	    ['BBC', 0],
            //                   	    ['CTD', 0]
            //                   	]);
                               	
            //                   	options = {
            //                   	    title: 'Account Summary',
            //                   	    pieHole: 0.4,
            //                   	    chartArea: { 
            //                   	        width: '100%', 
            //                   	        height: '100%',
            //                   	        left: 0,
            //                   	        top: '10%',
            //                   	        right: 0,
            //                   	        bottom: '5%'
            //                           },
            //                   	    sliceVisibilityThreshold: 0.01,
            //                   	    legend: { position: 'labeled' },
            //                   	    pieStartAngle: 90,
		    //							height: 300
            //                   	};
                               	
            //                   	chart = new google.visualization.PieChart(document.getElementById('piechart'));
                               	
            //                   	chart.draw(data, options);
            //                   	animateDrawing();
            //                   }
                               
            //                   function animateDrawing() {
            //                       var handler = setTimeout(function() {
            //                       	// values increment
            //                           if (percent5 < 5) {
            //                               if (5 - percent5 > 1)
            //                                   percent5 += 1;
            //                               else
            //                                   percent5 += 0.1;
		    								
		    							//	percent5 = Math.round(percent5 * 10) / 10;
            //                           }
            //                           else if (percent4 < 10) {
            //                               if (10 - percent4 > 1)
            //                                   percent4 += 1;
            //                               else
            //                                   percent4 += .1;
		    									
		    							//	percent4 = Math.round(percent4 * 10) / 10;
            //                           }
            //                           else if (percent3 < 20) {
            //                               if (20 - percent3 > 1)
            //                                   percent3 += 1;
            //                               else
            //                                   percent3 += .1;
		    									
		    							//	percent3 = Math.round(percent3 * 10) / 10;
            //                           }
            //                           else if (percent2 < 30) {
            //                               if (30 - percent2 > 5)
            //                                   percent2 += 5;
            //                               else if (30 - percent2 > 1)
            //                                   percent2 += 1;
            //                               else
            //                                   percent2 += .1;
		    									
		    							//	percent2 = Math.round(percent2 * 10) / 10;
            //                           }
            //                           else if (percent1 < 35) {
            //                               if (35 - percent1 > 5)
            //                                   percent1 += 5;
            //                               else if (35 - percent1 > 1)
            //                                   percent1 += 1;
            //                               else
            //                                   percent1 += .1;
		    									
		    							//	percent1 = Math.round(percent1 * 10) / 10;
            //                           }
                                       
            //                           // apply new values
            //                           data.setValue(0, 1, percent1);
            //                           data.setValue(1, 1, percent2);
            //                           data.setValue(2, 1, percent3);
            //                           data.setValue(3, 1, percent4);
            //                           data.setValue(4, 1, percent5);
                                   
            //                           // update the pie
            //                           chart.draw(data, options);
                                   
            //                       	// check if we have reached the desired value
            //                           if (percent1 >= 35)
            //                               // stop the loop
            //                           	clearTimeout(handler);
                                       
            //                           if (percent1 < 35)
            //                               animateDrawing();
            //                       }, 10);
            //                   }
            //               </script>
            //           </head>
            //           <body>
            //               <div id='piechart'></div>
            //           </body>
            //       </html>";

            //htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();

            //ChartView.Source = htmlSource;
        }

        protected async override void OnAppearing()
        {
            AccountModel accountData = await App.accountRestServiceManager.GetAccountTabDataByUsernameTaskAsync(Constants.currentUsername);

            accountTitle.Text = accountData.Username + "'s Account Summary";
            startingInvestment.Text = accountData.StartingInvestment.ToString();
            stocksValue.Text = accountData.StocksValue.ToString();
            availableCash.Text = accountData.AvailableCash.ToString();
            if (accountData.Position < 0)
            {
                accountData.Position = Math.Abs(accountData.Position);
                totalValue.TextColor = Color.FromRgb(139, 0, 0);
                position.TextColor = Color.FromRgb(139, 0, 0);
            }
            else if (accountData.Position > 0)
            {
                totalValue.TextColor = Color.FromRgb(0, 100, 0);
                position.TextColor = Color.FromRgb(0, 100, 0);
            }
            else
            {
                totalValue.TextColor = Color.FromRgb(25, 118, 210);
                position.TextColor = Color.FromRgb(25, 118, 210);
            }
            totalValue.Text = accountData.TotalValue.ToString();
            position.Text = accountData.Position.ToString();
            totalTransactions.Text = accountData.TotalTrans.ToString();
            positiveTransactions.Text = accountData.PositiveTrans.ToString();
            negativeTransactions.Text = accountData.NegativeTrans.ToString();

            List<PortfolioModel> Portfolios = await App.portfolioRestServiceManager.GetPortfolioListByUsernameTaskAsync(Constants.currentUsername);

            List<PieChartModel> pieChartData = new List<PieChartModel>();
            foreach (var item in Portfolios)
            {
                pieChartData.Add(new PieChartModel(item.Ticker, item.Value));
            }

            var htmlSource = new HtmlWebViewSource();

            htmlSource.Html = HTMLChartBuilder.BuildHTMLPortfolioPieChartForAccount(pieChartData, accountData.AvailableCash, accountData.TotalValue);

            htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();

            ChartView.Source = htmlSource;
        }
    }
}
