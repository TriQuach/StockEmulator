using System;

using StockEmulator.iOS;
using Xamarin.Forms;
using Foundation;

[assembly: Dependency(typeof(BaseUrl_iOS))]
namespace StockEmulator.iOS
{
    public class BaseUrl_iOS : StockEmulator.Pages.StockInfoPage.IBaseUrl
    {
        public string Get()
        {
            return NSBundle.MainBundle.BundlePath;
        }
    }
}
