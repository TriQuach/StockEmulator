using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.HistoryRestService
{
    public class HistoryRestServiceManager
    {
        IHistoryRestService historyRestService;

        public HistoryRestServiceManager(IHistoryRestService historyRestService)
        {
            this.historyRestService = historyRestService;
        }

        public Task<decimal> GetPreviousClosePriceTaskAsync(string ticker)
        {
            return historyRestService.GetPreviousClosePriceAsync(ticker);
        }

        public Task<List<HistoryPriceModel>> GetHistoryPriceTaskAsync(string ticker, string historyType)
        {
            return historyRestService.GetHistoryPriceAsync(ticker, historyType);
        }
    }
}
