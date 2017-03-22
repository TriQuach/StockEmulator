using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockEmulator.Models;
using System.Net.Http;
using StockEmulator.Utilities;
using Newtonsoft.Json;
using System.Diagnostics;

namespace StockEmulator.Data.StockRestService
{
    public class StockRestService : IStockRestService
    {
        HttpClient client;

        public StockModel StockInfo { get; private set; }

        public StockRestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<StockModel> GetStockByTickerAsync(string ticker)
        {

            // RestUrl_Stock = "http://lmtri.somee.com/api/stock{0}"
            // GetStockByTickerRequest = "?ticker={0}"
            string GetStockByTickerRequest = string.Format(Constants.GetStockByTickerRequest, ticker);
            var uri = new Uri(string.Format(Constants.RestUrl_Stock, GetStockByTickerRequest));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    StockInfo = JsonConvert.DeserializeObject<StockModel>(content);
                }
                return StockInfo;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
                throw ex;
            }
        }
    }
}
