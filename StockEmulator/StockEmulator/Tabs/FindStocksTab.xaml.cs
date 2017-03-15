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
        
        private List<string> source = new List<string>()
        {
            "AAA","AAC","BBC","BBE","CTD"
        };
        public FindStocksTab()
        {
            InitializeComponent();
            listView.ItemsSource = source;
            listView.ItemSelected += (sender, e) =>
                {
                    var item = e.SelectedItem as string;
                    if (item == null) return; // don't do anything if we just de-selected the row

                    ContentPage page = null;    // do something with e.SelectedItem
                    
                        page = new Pages.StockInfoPage(item);
                    
                    page.BindingContext = item;
                    Navigation.PushAsync(page);
                    ((ListView)sender).SelectedItem = null; // de-select the row
                };

        }
        
        private void search_button(object sender, EventArgs e)
        {
            string search_text = searchBar.Text.ToLower();
            IEnumerable<string> result = source.Where(x => x.ToLower().Contains(search_text));
            if (result.Count() > 0)
                listView.ItemsSource = result;
            else
                listView.ItemsSource = new List<string>() { "Not found" };
        }
    }
}
