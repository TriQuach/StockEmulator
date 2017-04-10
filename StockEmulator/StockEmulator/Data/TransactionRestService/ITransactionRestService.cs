using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.TransactionRestService
{
    public interface ITransactionRestService
    {
        Task<List<TransactionModel>> GetTransactionListByUsernameAsync(string username);
        Task<bool> BuySellStockByUsernameTickerNumStocksAsync(BuySellStockModel buySellInfo);
    }
}
