using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DividendTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DividendTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StocksApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StocksApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            return await _context.Stocks.ToListAsync();
        }
    }
}
