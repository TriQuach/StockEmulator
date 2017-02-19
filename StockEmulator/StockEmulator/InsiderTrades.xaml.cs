using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator
{
    public partial class InsiderTrades : ContentPage
    {
        public InsiderTrades()
        {
            InitializeComponent();
            lstView.ItemsSource = new List<InsiderTrade_Class>
            {
                new InsiderTrade_Class
                {
                    Tick = "OPK",
                    CompanyName = "Exegenics Lcn (OPK)",
                    Type = "B",
                    Quant = 1800,
                    Price = 8.46,
                    InsiderName = "Coleman Craig E.",
                    Total = 15228,
                    Time = "06:25:35 2017-02-19"
                 
                },
                new InsiderTrade_Class
                {
                    Tick = "OPK",
                    CompanyName = "Exegenics Lcn (OPK)",
                    Type = "B",
                    Quant = 1800,
                    Price = 8.46,
                    InsiderName = "Coleman Craig E.",
                    Total = 15228,
                    Time = "06:25:35 2017-02-19"
                 
                }
            };
        }
    }
}
