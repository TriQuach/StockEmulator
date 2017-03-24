using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.StockRestService
{
    public interface IStockRestService
    {
        Task<List<StockModel>> SearchStockByTickerOrEquityNameAsync(string searchData);
        Task<StockModel> GetStockDataByTickerAsync(string ticker);
    }
}
