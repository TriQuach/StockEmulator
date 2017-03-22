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

        public Task<bool> SignUpTaskAsync(SignUpModel signUpInfo)
        {
            return accountRestService.SignUp(signUpInfo);
        }

        public Task<bool> LoginTaskAsync(LoginModel thisUser)
        {
            return accountRestService.Login(thisUser);
        }

        public Task<AccountModel> GetAccountInfoByUsernameAsync(string username)
        {
            return accountRestService.GetAccountInfoByUsernameAsync(username);
        }
    }
}
