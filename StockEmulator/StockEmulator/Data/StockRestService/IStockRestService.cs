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
        Task<StockModel> GetStockByTickerAsync(string ticker);
    }
}
