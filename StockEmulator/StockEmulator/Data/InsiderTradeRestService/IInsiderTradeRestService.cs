using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.InsiderTradeRestService
{
    public interface IInsiderTradeRestService
    {
        Task<List<InsiderTradeModel>> GetAllInsiderTradesAsync();
    }
}
