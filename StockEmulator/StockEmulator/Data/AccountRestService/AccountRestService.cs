using System;
using System.Threading.Tasks;
using StockEmulator.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using StockEmulator.Utilities;

namespace StockEmulator.Data.AccountRestService
{
    public class AccountRestService : IAccountRestService
    {
        HttpClient client;

        public AccountModel AccountInfo { get; private set; }

        public AccountRestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<bool> SendLoginInfo(LoginModel thisUser)
        {
            // RestURL_Account = "http://lmtri.somee.com/api/account{0}"
            // LoginRequest = "?username={0}&password={1}"
            string LoginRequest = string.Format(Constants.LoginRequest, thisUser.Username, thisUser.Password);
            var uri = new Uri(string.Format(Constants.RestUrl_Account, LoginRequest));
            bool valid = false;
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    valid = JsonConvert.DeserializeObject<bool>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
            }

            return valid;
        }

        public async Task<AccountModel> GetAccountInfoByUsernameAsync(string username)
        {
            AccountInfo = new AccountModel();

            // RestURL_Account = http://lmtri.somee.com/api/account{0}
            // GetAccountInfoByUsernameRequest = "?username={0}"
            string GetAccountInfoByUsernameRequest = string.Format(Constants.GetAccountInfoByUsernameRequest, username);
            var uri = new Uri(string.Format(Constants.RestUrl_Account, GetAccountInfoByUsernameRequest));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    AccountInfo = JsonConvert.DeserializeObject<AccountModel>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"              ERROR {0}", ex.Message);
            }

            return AccountInfo;
        }
    }
}
