using System;

using StockEmulator.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl_Droid))]
namespace StockEmulator.Droid
{
    public class BaseUrl_Droid : StockEmulator.Pages.StockInfoPage.IBaseUrl, StockEmulator.Tabs.MyAccountTab.IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset/";
        }
    }
}