using StockEmulator.Pages;
using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StockEmulator.Tabs
{
    public partial class FindStocksTab : ContentPage
    {

        //private List<string> source = new List<string>()
        //{
        //    "AAA","AAC","BBC","BBE","CTD"
        //};
        List<string> source = new List<string>();
        StockModel stock = new StockModel();

        public FindStocksTab()
        {
            InitializeComponent();
            //listView.ItemsSource = source;
            listView.ItemSelected += (sender, e) =>
                {
                    var item = e.SelectedItem as string;
                    if (item == null) return; // don't do anything if we just de-selected the row

                    ContentPage page = null;    // do something with e.SelectedItem
                    
                    page = new StockInfoPage(item);
                    
                    page.BindingContext = item;
                    Navigation.PushAsync(page);
                    ((ListView)sender).SelectedItem = null; // de-select the row
                };

        }
        
        async void search_button(object sender, EventArgs e)
        {
            string searchText = searchBar.Text.ToUpper();
            //IEnumerable<string> result = source.Where(x => x.ToLower().Contains(search_text));
            //if (result.Count() > 0)
            //    listView.ItemsSource = result;
            //else
            //    listView.ItemsSource = new List<string>() { "Not found" };

            stock = await App.stockRestServiceManager.GetStockTaskAsync(searchText);
            if (stock != null)
            {
                listView.ItemsSource = new List<string>() { stock.Ticker };
            }
            else
            {
                await DisplayAlert("Search", string.Format("NOT FOUND {0}!", searchText), "OK");
            }
        }
    }
}
