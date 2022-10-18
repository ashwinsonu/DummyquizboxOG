using DummyQuizBox.Entities;
using DummyQuizBox.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyQuizBox.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PortfolioController : ControllerBase
    {
        private IPortfolioRepo PortfolioObj;

        public PortfolioController(IPortfolioRepo _PortfolioObj)
        {
            PortfolioObj = _PortfolioObj;
        }


        [HttpGet]
        public async Task<ActionResult<Portfolio>> GetAll()
        {

            var result = await PortfolioObj.GetAll();
            if (result == null)
            { return NotFound(); }

            return Ok(result);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Portfolio>> GetPortfolio(Guid id)
        {
            var result = await PortfolioObj.GetPortfolio(id);
            if (result == null)
            { return NotFound(); }
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> AddPortfolio([FromBody] Portfolio portfolio)
        {
            return Ok(await PortfolioObj.AddPortfolio(portfolio));


        }

        [HttpDelete]
        public async Task<ActionResult> DeletePortfolio(Guid id)
        {
            return  Ok(await PortfolioObj.DeletePortfolio(id));
        
        }


        [HttpPut]
        public async Task<ActionResult> UpdatePortfolio(Guid id, [FromBody] Portfolio portfolio)
        {
            return Ok(await PortfolioObj.UpdatePortfolio(id, portfolio));
        
        }


    }


}