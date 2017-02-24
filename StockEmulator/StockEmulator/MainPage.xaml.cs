using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace StockEmulator
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.listView.ItemSelected += (sender, e) =>
            {
                var item = e.SelectedItem as string;
                if (item == null) return; // don't do anything if we just de-selected the row

                MessagingCenter.Send<MainPage, string>(this, "Switch Tab", item);// do something with e.SelectedItem
                ((ListView)sender).SelectedItem = null; // de-select the row
                this.IsPresented = false;
            };
        }
    }
}
