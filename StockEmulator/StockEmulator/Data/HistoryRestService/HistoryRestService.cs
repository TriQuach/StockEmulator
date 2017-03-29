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

namespace StockEmulator.Data.HistoryRestService
{
    public class HistoryRestService : IHistoryRestService
    {
        HttpClient client;

        public List<HistoryPriceModel> ListHistoryPrice { get; private set; }

        public HistoryRestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<decimal> GetPreviousClosePriceAsync(string ticker)
        {
            // RestUrl_History = "http://lmtri.somee.com/api/history{0}"
            // GetPreviousClosePriceRequest = "?ticker={0}"
            string GetPreviousClosePriceRequest = string.Format(Constants.GetPreviousClosePriceRequest, ticker);
            var uri = new Uri(string.Format(Constants.RestUrl_History, GetPreviousClosePriceRequest));

            decimal previousClosePrice = 0;
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    previousClosePrice = JsonConvert.DeserializeObject<decimal>(content);
                }
                return previousClosePrice;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
                throw ex;
            }
        }

        public async Task<List<HistoryPriceModel>> GetHistoryPriceAsync(string ticker, string historyType)
        {
            // RestUrl_History = "http://lmtri.somee.com/api/history{0}"
            // GetHistoryPriceRequest = "?ticker={0}&historyType={1}"
            string GetHistoryPriceRequest = string.Format(Constants.GetHistoryPriceRequest, ticker, historyType);
            var uri = new Uri(string.Format(Constants.RestUrl_History, GetHistoryPriceRequest));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ListHistoryPrice = JsonConvert.DeserializeObject<List<HistoryPriceModel>>(content);
                }
                return ListHistoryPrice;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
                throw ex;
            }
        }
    }
}
