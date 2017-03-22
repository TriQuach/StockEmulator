using StockEmulator.Models;
using StockEmulator.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    public partial class InsiderTradesTab : ContentPage
    {
        public InsiderTradesTab()
        {
            InitializeComponent();
            lstView.ItemsSource = new List<InsiderTradeModel>
            {
                new InsiderTradeModel
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
                new InsiderTradeModel
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

            lstView.ItemSelected += (sender, e) =>
            {
                var item = e.SelectedItem as InsiderTradeModel;
                if (item == null) return; // don't do anything if we just de-selected the row

                ContentPage page = null;    // do something with e.SelectedItem

                page = new StockInfoPage(item.Tick);

                page.BindingContext = item;
                Navigation.PushAsync(page);
                ((ListView)sender).SelectedItem = null; // de-select the row
            };
        }
    }
}
