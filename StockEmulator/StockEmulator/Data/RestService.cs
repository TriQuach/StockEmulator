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

       
        public List<Porfolio> PortfolioItems { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Porfolio>> GetListPortfolioDataAsync()
        {
            PortfolioItems = new List<Porfolio>();

            // RestURL = http://lmtri.somee.com/api/portfolio{0}
            var uri = new Uri(string.Format(Constants.RestUrl, "?accountID=1"));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    PortfolioItems = JsonConvert.DeserializeObject<List<Porfolio>>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
            }

            return PortfolioItems;
        }
    }
}
