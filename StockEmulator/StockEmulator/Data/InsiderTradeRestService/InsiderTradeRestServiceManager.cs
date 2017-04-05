using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.InsiderTradeRestService
{
    public class InsiderTradeRestServiceManager
    {
        IInsiderTradeRestService insiderTradeRestService;

        public InsiderTradeRestServiceManager(IInsiderTradeRestService insiderTradeRestService)
        {
            this.insiderTradeRestService = insiderTradeRestService;
        }

        public Task<List<InsiderTradeModel>> GetAllInsiderTradesTaskAsync()
        {
            return insiderTradeRestService.GetAllInsiderTradesAsync();
        }
    }
}
