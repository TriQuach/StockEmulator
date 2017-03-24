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

        public List<StockModel> ListStockInfo { get; private set; }
        public StockModel StockInfo { get; private set; }

        public StockRestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<StockModel>> SearchStockByTickerOrEquityNameAsync(string searchData)
        {
            // RestUrl_Stock = "http://lmtri.somee.com/api/stock{0}"
            // SearchStockDataByTickerOrEquityNameRequest = "?searchData={0}"
            string GetStockByTickerOrEquityNameRequest = string.Format(Constants.SearchStockDataByTickerOrEquityNameRequest, searchData);
            var uri = new Uri(string.Format(Constants.RestUrl_Stock, GetStockByTickerOrEquityNameRequest));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ListStockInfo = JsonConvert.DeserializeObject<List<StockModel>>(content);
                }
                return ListStockInfo;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
                throw ex;
            }
        }

        public async Task<StockModel> GetStockDataByTickerAsync(string ticker)
        {
            // RestUrl_Stock = "http://lmtri.somee.com/api/stock{0}"
            // GetStockDataByTickerRequest = "?ticker={0}"
            string GetStockDataByTickerRequest = string.Format(Constants.GetStockDataByTickerRequest, ticker);
            var uri = new Uri(string.Format(Constants.RestUrl_Stock, GetStockDataByTickerRequest));

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
