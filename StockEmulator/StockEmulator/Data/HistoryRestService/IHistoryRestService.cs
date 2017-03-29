using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.HistoryRestService
{
    public interface IHistoryRestService
    {
        Task<decimal> GetPreviousClosePriceAsync(string ticker);
        Task<List<HistoryPriceModel>> GetHistoryPriceAsync(string ticker, string historyType);
    }
}
