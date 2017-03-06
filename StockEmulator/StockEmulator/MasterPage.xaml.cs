using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator
{
    public partial class MasterPage : ContentPage
    {
        public ListView listView { get { return listMenu; } }

        public MasterPage()
        {
            InitializeComponent();

            listMenu.ItemsSource = new string[]
            {
                "Portfolio",
                "Find Stocks",               
                "My Account",
                "Transactions",               
                "Insider Trades",
            };
        }
    }
}
