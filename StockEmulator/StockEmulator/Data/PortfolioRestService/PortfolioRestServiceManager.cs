using StockEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Data.PortfolioRestService
{
    public class PortfolioRestServiceManager
    {
        IPortfolioRestService portfolioRestService;

        public PortfolioRestServiceManager(IPortfolioRestService portfolioRestService)
        {
            this.portfolioRestService = portfolioRestService;
        }

        public Task<List<PorfolioModel>> GetPortfolioListByUsernameTaskAsync(string username)
        {
            return portfolioRestService.GetPortfolioListByUsernameAsync(username);
        }
    }
}
