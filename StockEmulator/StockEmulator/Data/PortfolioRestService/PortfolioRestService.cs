using Newtonsoft.Json;
using StockEmulator.Models;
using StockEmulator.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.PortfolioRestService
{
    public class PortfolioRestService : IPortfolioRestService
    {
        HttpClient client;

        public List<PortfolioModel> PortfolioItems { get; private set; }

        public PortfolioRestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<PortfolioModel>> GetPortfolioListByUsernameAsync(string username)
        {
            PortfolioItems = new List<PortfolioModel>();

            // RestURL_Portfolio = "http://lmtri.somee.com/api/portfolio{0}"
            // GetPortfolioListByUsernameRequest = "?username={0}"
            string GetPortfolioListByUsernameRequest = string.Format(Constants.GetPortfolioListByUsernameRequest, username);
            var uri = new Uri(string.Format(Constants.RestUrl_Portfolio, GetPortfolioListByUsernameRequest));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    PortfolioItems = JsonConvert.DeserializeObject<List<PortfolioModel>>(content);
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
