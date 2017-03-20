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
        Task<bool> SignUp(SignUpModel signUpInfo);
        Task<bool> Login(LoginModel thisUser);
        Task<AccountModel> GetAccountInfoByUsernameAsync(string username);
    }
}
