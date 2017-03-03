using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data
{
    public class StockItemManager
    {
        IRestService restService;

        public StockItemManager(IRestService service)
        {
            restService = service;
        }

        

        public Task<List<Porfolio>> GetTaskAsyncPorfolio()
        {
            return restService.GetListPortfolioDataAsync();
        }
    }
}
