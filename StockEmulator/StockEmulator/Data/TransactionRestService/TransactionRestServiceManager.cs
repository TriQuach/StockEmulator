using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.TransactionRestService
{
    public class TransactionRestServiceManager
    {
        ITransactionRestService transactionRestService;

        public TransactionRestServiceManager(ITransactionRestService transactionRestService)
        {
            this.transactionRestService = transactionRestService;
        }

        public Task<List<TransactionModel>> GetTransactionListByUsernameTaskAsync(string username)
        {
            return transactionRestService.GetTransactionListByUsernameAsync(username);
        }

        public Task<bool> BuySellStockByUsernameTickerNumStocksTaskAsync(BuySellStockModel buySellInfo)
        {
            return transactionRestService.BuySellStockByUsernameTickerNumStocksAsync(buySellInfo);
        }
    }
}
