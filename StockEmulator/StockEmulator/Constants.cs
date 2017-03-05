using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator
{
    public class Constants
    {
        //Current User Info
        public static string currentUsername;
        //URL of REST service
        public static string RestUrl_Account = "http://lmtri.somee.com/api/account{0}";
        public static string LoginRequest = "?username={0}&password={1}";
        public static string GetAccountInfoByUsernameRequest = "?username={0}";

        public static string RestUrl_Portfolio = "http://lmtri.somee.com/api/portfolio{0}";
        public static string GetPortfolioListByUsernameRequest = "?username={0}";
        public static string GetPortfolioByUsernameAndTickerRequest = "?username={0}&ticker={1}";
        public static string InsertNewPortfolioRequest = "?username={0}&ticker={1}&cost={2}&num={3}";
        public static string DeletePortfolioByUsernameRequest = "?username={0}";
        public static string DeletePortfolioByUsernameAndTicker = "?username={0}&ticker={1}";
    }
}
