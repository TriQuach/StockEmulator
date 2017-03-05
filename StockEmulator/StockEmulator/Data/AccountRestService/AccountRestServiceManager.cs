using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.AccountRestService
{
    public class AccountRestServiceManager
    {
        IAccountRestService accountRestService;

        public AccountRestServiceManager(IAccountRestService accountRestService)
        {
            this.accountRestService = accountRestService;
        }

        public Task<bool> SendLoginInfo(LoginModel thisUser)
        {
            return accountRestService.SendLoginInfo(thisUser);
        }

        public Task<AccountModel> GetAccountInfoByUsernameAsync(string username)
        {
            return accountRestService.GetAccountInfoByUsernameAsync(username);
        }
    }
}
