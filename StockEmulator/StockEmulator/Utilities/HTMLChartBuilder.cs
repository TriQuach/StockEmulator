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
        public static string BuildHTMLLineChartFor1DayHistory(string ChartName, List<History1DayModel> chartData)
        {
            //          string htmlPart1 = @"<html>
            //<head>
            //  <script type=""text/javascript"" src=""jsapi.js""></script>
            //  <script type=""text/javascript"">
            //     google.load(""visualization"", ""1"", { packages:[""corechart""]});
            //     google.setOnLoadCallback(drawChart);
            //          function drawChart() {
            //              var data = google.visualization.arrayToDataTable([

            //                ['Time', 'Price', 'Previous Close'],

            //                ";
            //string htmlPart2ChartData = @"['2010', 1000, 600],

            //      ['2011', 1170, 600],

            //      ['2012', 660, 600],

            //      ['2013', 1030, 600]";

            string htmlPart1 = @"<html>
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

            string htmlPart2ChartData = LineChartDataToJavascriptAdapter(chartData);

            string htmlPart3 = @"]);

                var options = {
          title: '";

            string htmlPart4ChartName = ChartName;

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

        static string LineChartDataToJavascriptAdapter(List<History1DayModel> chartData)
        {
            StringBuilder sb = new StringBuilder();
            CustomDateTime cdt;
            foreach (var item in chartData)
            {
                PropertyInfo prop = typeof(History1DayModel).GetRuntimeProperty("Time");

                cdt = new CustomDateTime((DateTime)prop.GetValue(item));
                sb.Append("[[");
                sb.Append(cdt.Hours);
                sb.Append(",");
                sb.Append(cdt.Minutes);
                sb.Append(",");
                sb.Append(cdt.Seconds);
                sb.Append("],");

                foreach (PropertyInfo properties in typeof(History1DayModel).GetRuntimeProperties().ToList())
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
