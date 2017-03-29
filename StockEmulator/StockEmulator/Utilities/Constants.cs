using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Utilities
{
    public class Constants
    {
        //Current User Info
        public static string currentUsername;
        //URL of Stock REST service
        public static string RestUrl_Stock = "http://lmtri.somee.com/api/stock{0}";
        public static string SearchStockDataByTickerOrEquityNameRequest = "?searchData={0}";
        public static string GetStockDataByTickerRequest = "?ticker={0}";

        //URL of History REST service
        public static string RestUrl_History = "http://lmtri.somee.com/api/history{0}";
        public static string GetPreviousClosePriceRequest = "?ticker={0}";
        public static string GetHistoryPriceRequest = "?ticker={0}&historyType={1}";

        //URL of Account REST service
        public static string RestUrl_Account = "http://lmtri.somee.com/api/account{0}";
        public static string LoginRequest = "?username={0}&password={1}";
        public static string GetAccountInfoByUsernameRequest = "?username={0}";

        //URL of Portfolio REST service
        public static string RestUrl_Portfolio = "http://lmtri.somee.com/api/portfolio{0}";
        public static string GetPortfolioListByUsernameRequest = "?username={0}";
        public static string GetPortfolioByUsernameAndTickerRequest = "?username={0}&ticker={1}";
        public static string InsertNewPortfolioRequest = "?username={0}&ticker={1}&cost={2}&num={3}";
        public static string DeletePortfolioByUsernameRequest = "?username={0}";
        public static string DeletePortfolioByUsernameAndTicker = "?username={0}&ticker={1}";

        //URL of Transaction REST service
        public static string RestUrl_Transaction = "http://lmtri.somee.com/api/transaction{0}";
        public static string GetTransactionListByUsernameRequest = "?username={0}";
        public static string BuyStockByUsernameTickerNumStocksRequest = "?username={0}&ticker={1}&numstocks={2}";
    }
}
