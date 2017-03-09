using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.PortfolioRestService
{
    public interface IPortfolioRestService
    {
        Task<List<PortfolioModel>> GetPortfolioListByUsernameAsync(string username);
    }
}
