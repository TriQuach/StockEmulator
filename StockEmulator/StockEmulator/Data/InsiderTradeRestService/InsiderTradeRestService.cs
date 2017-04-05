using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StockEmulator.Models;
using StockEmulator.Utilities;
using Newtonsoft.Json;
using System.Diagnostics;

namespace StockEmulator.Data.InsiderTradeRestService
{
    public class InsiderTradeRestService : IInsiderTradeRestService
    {
        HttpClient client;

        public List<InsiderTradeModel> ListInsiderTrade { get; private set; }

        public InsiderTradeRestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<InsiderTradeModel>> GetAllInsiderTradesAsync()
        {
            // RestUrl_InsiderTrade = "http://lmtri.somee.com/api/insidertrade{0}"
            var uri = new Uri(string.Format(Constants.RestUrl_InsiderTrade, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ListInsiderTrade = JsonConvert.DeserializeObject<List<InsiderTradeModel>>(content);
                }
                return ListInsiderTrade;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
                throw ex;
            }
        }
    }
}
