using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockEmulator.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using StockEmulator.Utilities;
using System.Text;

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

            // RestUrl_Transactions = "http://lmtri.somee.com/api/transaction{0}"
            // GetTransactionListByUsernameRequest = "?username={0}"
            string GetTransactionListByUsernameRequest = string.Format(Constants.GetTransactionListByUsernameRequest, username);
            var uri = new Uri(string.Format(Constants.RestUrl_Transaction, GetTransactionListByUsernameRequest));

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

        public async Task<bool> BuyStockByUsernameTickerNumStocksAsync(BuyStockModel buyingInfo)
        {
            // RestUrl_Transactions = "http://lmtri.somee.com/api/transaction{0}"
            // BuyStockByUsernameTickerNumStocksRequest = "?username={0}&ticker={1}&numstocks={2}"
            string BuyStockByUsernameTickerNumStocksRequest = string.Format(Constants.BuyStockByUsernameTickerNumStocksRequest, buyingInfo.Username, buyingInfo.Ticker, buyingInfo.NumStocks);
            var uri = new Uri(string.Format(Constants.RestUrl_Transaction, BuyStockByUsernameTickerNumStocksRequest));

            bool success = false;
            try
            {
                var json = JsonConvert.SerializeObject(buyingInfo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    success = JsonConvert.DeserializeObject<bool>(responseContent);
                }
                return success;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
                return success;
            }
        }
    }
}
