using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockEmulator.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using StockEmulator.Utilities;

namespace StockEmulator.Data.TransactionRestService
{
    public class TransactionRestService : ITransactionRestService
    {
        HttpClient client;

        public List<TransactionModel> TransactionItems { get; private set; }

        public TransactionRestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<TransactionModel>> GetTransactionListByUsernameAsync(string username)
        {
            TransactionItems = new List<TransactionModel>();

            // RestURL_Portfolio = "http://lmtri.somee.com/api/portfolio{0}"
            // GetTransactionListByUsernameRequest = "?username={0}"
            string GetTransactionListByUsernameRequest = string.Format(Constants.GetTransactionListByUsernameRequest, username);
            var uri = new Uri(string.Format(Constants.RestUrl_Transactions, GetTransactionListByUsernameRequest));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    TransactionItems = JsonConvert.DeserializeObject<List<TransactionModel>>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
            }

            return TransactionItems;
        }
    }
}
