using Newtonsoft.Json;
using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<StockItem> StockItems { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<StockItem>> GetListStockDataAsync()
        {
            StockItems = new List<StockItem>();

            // RestURL = http://lmtri.somee.com/api/stock{0}
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    StockItems = JsonConvert.DeserializeObject<List<StockItem>>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
            }

            return StockItems;
        }
    }
}
