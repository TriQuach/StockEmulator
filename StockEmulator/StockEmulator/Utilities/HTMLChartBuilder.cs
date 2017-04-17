using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                            google.load('visualization', '1', { packages:['corechart'], 'language': 'en'});
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
                        <div id='chart_div'></div>
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
                            google.load('visualization', '1', { packages:['corechart'], 'language': 'en'});
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
                        <div id='chart_div'></div>
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
        /// Create an HTML string to draw Google Pie Chart of Portfolio in Account Tab in WebView.
        /// </summary>
        /// <param name="chartData">List of Tickers and Values in Portfolio of <typeparamref name="PieChartModel"/></param>
        /// <param name="availableCash">Available Cash of Current Account</param>
        /// <param name="totalValue">Total Value of Current Account</param>
        /// <returns></returns>
        public static string BuildHTMLPortfolioPieChartForAccount(List<PieChartModel> chartData, decimal availableCash, decimal totalValue)
        {
            string htmlPart1 = @"
                <html>
                    <head>
                        <script type='text/javascript' src='jsapi.js'></script>
                        <script type='text/javascript'>
                            google.load('visualization', '1', { packages:['corechart'], 'language': 'en'});
                            google.setOnLoadCallback(drawChart);
                            
                            var data, options, chart;

            ";
            
            string htmlPart2InitialAnimationValue = PieChartAnimationValueJavascriptBuilder(chartData.Count + 1);

            string htmlPart3 = @"

                            function drawChart() {
                            	data = new google.visualization.DataTable();
                            
                            	data.addColumn('string', 'Category');
                            	data.addColumn('number', 'Percentage');
                            	
                            	data.addRows([
            ";

            string htmlPart4ChartData = PieChartDataToJavascriptAdapter(chartData);

            string htmlPart5 = @"
                            	]);
                            	
                            	options = {
                            	    title: 'Account Summary',
                            	    pieHole: 0.4,
                            	    chartArea: { 
                            	        width: '100%', 
                            	        height: '100%',
                            	        left: 0,
                            	        top: '10%',
                            	        right: 0,
                            	        bottom: '5%'
                                    },
                            	    sliceVisibilityThreshold: 0.01,
                            	    legend: { position: 'labeled' },
                            	    pieStartAngle: 90
                            	};
                            	
                            	chart = new google.visualization.PieChart(document.getElementById('piechart'));
                            	
                            	chart.draw(data, options);
                            	animateDrawing();
                            }
                            
                            function animateDrawing() {
                                var handler = setTimeout(function() {
            ";

            string htmlPart6AnimationScript = PieChartAminationJavascriptBuilder(chartData, availableCash, totalValue);

            string htmlPart7 = @"
                        </script>
                    </head>
                    <body>
                        <div id='piechart'></div>
                    </body>
                </html>";

            StringBuilder sb = new StringBuilder();
            sb.Append(htmlPart1);
            sb.Append(htmlPart2InitialAnimationValue);
            sb.Append(htmlPart3);
            sb.Append(htmlPart4ChartData);
            sb.Append(htmlPart5);
            sb.Append(htmlPart6AnimationScript);
            sb.Append(htmlPart7);

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
                sb.Append("[[" + cdt.Hours + "," + cdt.Minutes + "," + cdt.Seconds + "],");

                foreach (PropertyInfo properties in typeof(HistoryPriceModel).GetRuntimeProperties().ToList())
                {
                    if (properties.Name == "Time")
                    {
                        continue;
                    }
                    if (properties.PropertyType == typeof(decimal))
                    {
                        sb.Append(((decimal)properties.GetValue(item)).ToString(CultureInfo.InvariantCulture) + "," + previousClosePrice + ",");
                    }
                    else if (properties.PropertyType == typeof(float))
                    {
                        sb.Append(((float)properties.GetValue(item)).ToString(CultureInfo.InvariantCulture) + "," + previousClosePrice + ",");
                    }
                    else if (properties.PropertyType == typeof(double))
                    {
                        sb.Append(((double)properties.GetValue(item)).ToString(CultureInfo.InvariantCulture) + "," + previousClosePrice + ",");
                    }
                    else
                    {
                        sb.Append(properties.GetValue(item) + "," + previousClosePrice + ",");
                    }
                }
                --sb.Length;
                sb.Append("],\n");
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
                sb.Append("[new Date(" + cdt.Year + "," + cdt.Month + "," + cdt.Day + "," + cdt.Hours + "," + cdt.Minutes + "," + cdt.Seconds + "),");

                foreach (PropertyInfo properties in typeof(HistoryPriceModel).GetRuntimeProperties().ToList())
                {
                    if (properties.Name == "Time")
                    {
                        continue;
                    }
                    if (properties.PropertyType == typeof(decimal))
                    {
                        sb.Append(((decimal)properties.GetValue(item)).ToString(CultureInfo.InvariantCulture) + ",");
                    }
                    else if (properties.PropertyType == typeof(float))
                    {
                        sb.Append(((float)properties.GetValue(item)).ToString(CultureInfo.InvariantCulture) + ",");
                    }
                    else if (properties.PropertyType == typeof(double))
                    {
                        sb.Append(((double)properties.GetValue(item)).ToString(CultureInfo.InvariantCulture) + ",");
                    }
                    else
                    {
                        sb.Append(properties.GetValue(item) + ",");
                    }
                }
                --sb.Length;
                sb.Append("],\n");
            }
            --sb.Length;
            return sb.ToString();
        }

        static string PieChartAnimationValueJavascriptBuilder(int numChartData)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= numChartData; ++i)
            {
                sb.Append("var percent" + i + " = 0;\n");
            }
            return sb.ToString();
        }

        static string PieChartDataToJavascriptAdapter(List<PieChartModel> chartData)
        {
            chartData.Sort();

            StringBuilder sb = new StringBuilder();

            sb.Append("['Cash', 0.1],\n");

            foreach (var item in chartData)
            {
                sb.Append("['" + item.Ticker + "'," + "0],\n");
            }
            sb.Length -= 2;

            return sb.ToString();
        }

        static string PieChartAminationJavascriptBuilder(List<PieChartModel> chartData, decimal availableCash, decimal totalValue)
        {
            List<PieChartModel> percentage = new List<PieChartModel>();

            percentage.Add(new PieChartModel("Cash", Math.Round((availableCash / totalValue) * 100, 1, MidpointRounding.AwayFromZero)));
            foreach (var item in chartData)
            {
                percentage.Add(new PieChartModel(item.Ticker, Math.Round((item.Value / totalValue) * 100, 1, MidpointRounding.AwayFromZero)));
            }

            StringBuilder sb = new StringBuilder();
            
            for (int i = percentage.Count; i > 0; --i)
            {
                if (i == percentage.Count)
                {
                    sb.Append("if (percent" + i + " < " + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + ") {\n");
                }
                else
                {
                    sb.Append("else if (percent" + i + " < " + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + ") {\n");
                }

                if (percentage[i - 1].Value <= 10)
                {
                    sb.Append("if (" + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + " - percent" + i + " > 1)\n");
                    sb.Append("percent" + i + " += 1;\n");
                }
                else if (percentage[i - 1].Value <= 20)
                {
                    sb.Append("if (" + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + " - percent" + i + " > 2)\n");
                    sb.Append("percent" + i + " += 2;\n");
                }
                else if (percentage[i - 1].Value <= 30)
                {
                    sb.Append("if (" + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + " - percent" + i + " > 3)\n");
                    sb.Append("percent" + i + " += 3;\n");
                }
                else if (percentage[i - 1].Value <= 40)
                {
                    sb.Append("if (" + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + " - percent" + i + " > 4)\n");
                    sb.Append("percent" + i + " += 4;\n");
                }
                else if (percentage[i - 1].Value <= 50)
                {
                    sb.Append("if (" + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + " - percent" + i + " > 5)\n");
                    sb.Append("percent" + i + " += 5;\n");
                }
                else if (percentage[i - 1].Value <= 60)
                {
                    sb.Append("if (" + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + " - percent" + i + " > 6)\n");
                    sb.Append("percent" + i + " += 6;\n");
                }
                else if (percentage[i - 1].Value <= 70)
                {
                    sb.Append("if (" + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + " - percent" + i + " > 7)\n");
                    sb.Append("percent" + i + " += 7;\n");
                }
                else if (percentage[i - 1].Value <= 80)
                {
                    sb.Append("if (" + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + " - percent" + i + " > 8)\n");
                    sb.Append("percent" + i + " += 8;\n");
                }
                else if (percentage[i - 1].Value <= 90)
                {
                    sb.Append("if (" + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + " - percent" + i + " > 9)\n");
                    sb.Append("percent" + i + " += 9;\n");
                }
                else if (percentage[i - 1].Value <= 100)
                {
                    sb.Append("if (" + percentage[i - 1].Value.ToString(CultureInfo.InvariantCulture) + " - percent" + i + " > 10)\n");
                    sb.Append("percent" + i + " += 10;\n");
                }
                sb.Append("else\n");
                sb.Append("percent" + i + " += 0.1;\n\n");
                sb.Append("percent" + i + " = Math.round(percent" + i + " * 10) / 10;\n");
                sb.Append("}\n");
            }

            for (int i = 0; i < percentage.Count; ++i)
            {
                sb.Append("data.setValue(" + i + ", 1, percent" + (i + 1) + ");\n");
            }

            sb.Append("chart.draw(data, options);\n");

            sb.Append("if (percent1 >= " + percentage[0].Value.ToString(CultureInfo.InvariantCulture) + ")\n");
            sb.Append("clearTimeout(handler);\n");

            sb.Append("if (percent1 < " + percentage[0].Value.ToString(CultureInfo.InvariantCulture) + ")\n");
            sb.Append("animateDrawing();\n");
            sb.Append("}, 5);\n");
            sb.Append("}");

            return sb.ToString();
        }
    }
}
