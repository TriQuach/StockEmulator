using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.AccountRestService
{
    public interface IAccountRestService
    {
        Task<bool> SendLoginInfo(LoginModel thisUser);
        Task<AccountModel> GetAccountInfoByUsernameAsync(string username);
    }
}
