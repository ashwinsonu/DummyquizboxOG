using DummyQuizBox.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DummyQuizBox.Interfaces
{
    public interface IPortfolioRepo
    {
        Task<IEnumerable<Portfolio>> GetAll();
        Task<Portfolio> GetPortfolio(Guid ID);
        Task<bool> AddPortfolio(Portfolio portfolio);
        Task<bool> DeletePortfolio( Guid portfolioID);
        Task<bool> UpdatePortfolio(Guid ID, Portfolio portfolio);



    }
}
