using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.StockRestService
{
    public class StockRestServiceManager
    {
        IStockRestService stockRestService;

        public StockRestServiceManager(IStockRestService stockRestService)
        {
            this.stockRestService = stockRestService;
        }

        public Task<List<StockModel>> SearchStockByTickerOrEquityNameTaskAsync(string searchData)
        {
            return stockRestService.SearchStockByTickerOrEquityNameAsync(searchData);
        }

        public Task<StockModel> GetStockDataByTickerTaskAsync(string ticker)
        {
            return stockRestService.GetStockDataByTickerAsync(ticker);
        }
    }
}
