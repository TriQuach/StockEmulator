using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Utilities
{
    public class HTMLChartBuilder
    {
        /// <summary>
        /// Create an HTML string to draw Google Line Chart for 1 Day History Price in WebView.
        /// </summary>
        /// <param name="chartName">Name of chart to show.</param>
        /// <param name="chartData">List of History Prices of <typeparamref name="HistoryPriceModel"/>.</param>
        /// <param name="previousClosePrice">Previous Close Price of Current Stock Symbol.</param>
        /// <returns>An HTML string.</returns>
        public static string BuildHTMLLineChartFor1DayHistoryPrice(string chartName, List<HistoryPriceModel> chartData, decimal previousClosePrice)
        {
            //  string htmlPart1 = @"
            //      <html>
            //          <head>
            //              <script type=""text/javascript"" src=""jsapi.js""></script>
            //              <script type=""text/javascript"">
            //                  google.load(""visualization"", ""1"", { packages:[""corechart""]});
            //                  google.setOnLoadCallback(drawChart);

            //                  function drawChart() {
            //                      var data = google.visualization.arrayToDataTable([

            //                          ['Time', 'Price', 'Previous Close'],

            //  ";
            //  string htmlPart2ChartData = @"

            //                          ['2010', 1000, 600],

            //                          ['2011', 1170, 600],

            //                          ['2012', 660, 600],

            //                          ['2013', 1030, 600]";

            string htmlPart1 = @"
                <html>
                    <head>
                        <script type='text/javascript' src='jsapi.js'></script>
                        <script type='text/javascript'>
                            google.load('visualization', '1', { packages:['corechart']});
                            google.setOnLoadCallback(drawChart);

                            function drawChart() {
                                var data = new google.visualization.DataTable();
                                
                                data.addColumn('timeofday', 'Time of Day');
                                data.addColumn('number', 'Price');
                                data.addColumn('number', 'Previous Close Price');
                                
                                data.addRows([
            ";

            string htmlPart2ChartData = LineChart1DayHistoryPriceDataToJavascriptAdapter(chartData, previousClosePrice);

            string htmlPart3 = @"]);

                                var options = {
                                    title: '";

            string htmlPart4ChartName = chartName;

            string htmlPart5 = @"',
                                    legend: { position: 'bottom' },
                                    animation: { duration: 1000,
                                                easing: 'out'},
                                    chartArea: { width: '85%', 
                                                height: '75%',
                                                left: '10%',
                                                top: '10%',
                                                right: 0,
                                                bottom: '25%'},
                                    series: { 1: { lineDashStyle: [2, 4], lineWidth: 2 } }
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

            StringBuilder sb = new StringBuilder();
            sb.Append(htmlPart1);
            sb.Append(htmlPart2ChartData);
            sb.Append(htmlPart3);
            sb.Append(htmlPart4ChartName);
            sb.Append(htmlPart5);

            return sb.ToString();
        }

        /// <summary>
        /// Create an HTML string to draw Google Line Chart of History Price earlier than 1 day in WebView.
        /// </summary>
        /// <param name="chartName">Name of chart to show.</param>
        /// <param name="chartData">List of History Prices of <typeparamref name="HistoryPriceModel"/>.</param>
        /// <returns>An HTML string.</returns>
        public static string BuildHTMLLineChartHistoryPrice(string chartName, List<HistoryPriceModel> chartData)
        {
            //  string htmlPart1 = @"
            //      <html>
            //          <head>
            //              <script type=""text/javascript"" src=""jsapi.js""></script>
            //              <script type=""text/javascript"">
            //                  google.load(""visualization"", ""1"", { packages:[""corechart""]});
            //                  google.setOnLoadCallback(drawChart);

            //                  function drawChart() {
            //                      var data = google.visualization.arrayToDataTable([

            //                          ['Time', 'Price', 'Previous Close'],

            //  ";
            //string htmlPart2ChartData = @"
            //                          ['2010', 1000, 600],

            //                          ['2011', 1170, 600],

            //                          ['2012', 660, 600],

            //                          ['2013', 1030, 600]";

            string htmlPart1 = @"
                <html>
                    <head>
                        <script type='text/javascript' src='jsapi.js'></script>
                        <script type='text/javascript'>
                            google.load('visualization', '1', { packages:['corechart']});
                            google.setOnLoadCallback(drawChart);

                            function drawChart() {
                                var data = new google.visualization.DataTable();
                                
                                data.addColumn('datetime', 'Date');
                                data.addColumn('number', 'Price');
                
                                data.addRows([
            ";

            string htmlPart2ChartData = LineChartHistoryPriceDataToJavascriptAdapter(chartData);

            string htmlPart3 = @"]);

                                var options = {
                                    title: '";

            string htmlPart4ChartName = chartName;

            string htmlPart5 = @"',
                                    legend: { position: 'bottom' },
                                    animation: { duration: 1000,
                                                easing: 'out'},
                                    chartArea: { width: '85%', 
                                                height: '75%',
                                                left: '10%',
                                                top: '10%',
                                                right: 0,
                                                bottom: '25%'},
                                    series: { 1: { lineDashStyle: [2, 4], lineWidth: 2 } }
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

            StringBuilder sb = new StringBuilder();
            sb.Append(htmlPart1);
            sb.Append(htmlPart2ChartData);
            sb.Append(htmlPart3);
            sb.Append(htmlPart4ChartName);
            sb.Append(htmlPart5);

            return sb.ToString();
        }

        static string LineChart1DayHistoryPriceDataToJavascriptAdapter(List<HistoryPriceModel> chartData, decimal previousClosePrice)
        {
            StringBuilder sb = new StringBuilder();
            CustomDateTime cdt;
            foreach (var item in chartData)
            {
                PropertyInfo prop = typeof(HistoryPriceModel).GetRuntimeProperty("Time");

                cdt = new CustomDateTime((DateTime)prop.GetValue(item));
                sb.Append("[[");
                sb.Append(cdt.Hours);
                sb.Append(",");
                sb.Append(cdt.Minutes);
                sb.Append(",");
                sb.Append(cdt.Seconds);
                sb.Append("],");

                foreach (PropertyInfo properties in typeof(HistoryPriceModel).GetRuntimeProperties().ToList())
                {
                    if (properties.Name == "Time")
                    {
                        continue;
                    }
                    sb.Append(properties.GetValue(item) + ",");
                    sb.Append(previousClosePrice + ",");
                }
                --sb.Length;
                sb.Append("],");
            }
            --sb.Length;
            return sb.ToString();
        }



        static string LineChartHistoryPriceDataToJavascriptAdapter(List<HistoryPriceModel> chartData)
        {
            StringBuilder sb = new StringBuilder();
            CustomDateTime cdt;
            foreach (var item in chartData)
            {
                PropertyInfo prop = typeof(HistoryPriceModel).GetRuntimeProperty("Time");

                cdt = new CustomDateTime((DateTime)prop.GetValue(item));
                sb.Append("[new Date(");
                sb.Append(cdt.Year);
                sb.Append(",");
                sb.Append(cdt.Month);
                sb.Append(",");
                sb.Append(cdt.Day);
                sb.Append(",");
                sb.Append(cdt.Hours);
                sb.Append(",");
                sb.Append(cdt.Minutes);
                sb.Append(",");
                sb.Append(cdt.Seconds);
                sb.Append("),");

                foreach (PropertyInfo properties in typeof(HistoryPriceModel).GetRuntimeProperties().ToList())
                {
                    if (properties.Name == "Time")
                    {
                        continue;
                    }
                    sb.Append(properties.GetValue(item) + ",");
                }
                --sb.Length;
                sb.Append("],");
            }
            --sb.Length;
            return sb.ToString();
        }
    }
}
