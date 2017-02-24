using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StockEmulator
{
    public partial class TabsWrapperDetailPage : TabbedPage
    {
        public TabsWrapperDetailPage()
        {
            InitializeComponent();

            Children.Add(new Tabs.PortfolioTab());
            Children.Add(new Tabs.WatchListTab());
            Children.Add(new Tabs.FindStocksTab());
            Children.Add(new Tabs.MyAccountTab());
            Children.Add(new Tabs.TransactionsTab());
            Children.Add(new Tabs.InsiderTradesTab());

            MessagingCenter.Subscribe<MainPage, string>(this, "Switch Tab", (sender, arg) =>
            {
                SwitchToTab(arg);
            });
        }

        public void SwitchToTab(string TabName)
        {
            switch (TabName)
            {
                case "Portfolio":
                    CurrentPage = Children[0];
                    break;
                case "Watchlist":
                    CurrentPage = Children[1];
                    break;
                case "Find Stocks":
                    CurrentPage = Children[2];
                    break;
                case "My Account":
                    CurrentPage = Children[3];
                    break;
                case "Transactions":
                    CurrentPage = Children[4];
                    break;
                case "Insider Trades":
                    CurrentPage = Children[5];
                    break;
                default:
                    break;
            }
        }
    }
}
