using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using stockValues_backend.Models;

namespace stockValues_backend.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StockController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //GET api/stocks/{name}
        [HttpGet("{name}")]
        public ActionResult<Stock> GetStockByName(string name)
        {
            var stockUrl = "https://www.alphavantage.co/query";
            var apiKey = "K58H2XM9D1W1AIOS";

            var stock = $"{stockUrl}?function=SYMBOL_SEARCH&keywords={name}&apikey={apiKey}";

            if (stock != null)
            {
                return Ok(stock);
            }
            return NotFound();
        }
    }
}
