using System;

using StockEmulator.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl_Droid_Donut))]
namespace StockEmulator.Droid
{
    public class BaseUrl_Droid_Donut : StockEmulator.Tabs.MyAccountTab.IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset/";
        }
    }
}