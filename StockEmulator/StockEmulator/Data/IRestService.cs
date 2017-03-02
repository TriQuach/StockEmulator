using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data
{
    public interface IRestService
    {
        Task<List<StockItem>> GetListStockDataAsync();
    }
}
