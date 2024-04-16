using DividendTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DividendTracker.Controllers
{
	// controller to manage dashboard related actions
	public class DashboardController : Controller
	{
		private readonly ApplicationDbContext _context;

		// constructor to inject ApplicationDbContext
		public DashboardController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Dashboard
		public async Task<IActionResult> Index()
		{
			// fetch UserPortfolio data
			var userPortfolios = await _context.UserPortfolios
				.Include(up => up.Stock) // changed from stock to ticker
				.ThenInclude(stock => stock.Dividend) 
				.ToListAsync();

			// calculate total dividend
			var totalDividend = userPortfolios
				.Where(up => up.Stock != null && up.Stock.Dividend != null) // Check for null
				.Sum(up => up.Stock.Dividend.DividendAmount * up.AmountOfSharesOwned);



			// calculate dividend yield and yield on cost for each stock and average them
			var totalValue = userPortfolios.Sum(up => up.AverageCostPerShare * up.AmountOfSharesOwned); // calculate total value of all stocks
			var totalDividendYield = userPortfolios.Sum(up => up.Stock.Dividend.DividendAmount / up.Stock.Dividend.CurrentStockPrice) / userPortfolios.Count; // calculate average dividend yield for all stocks
			var totalYieldOnCost = userPortfolios.Sum(up => up.Stock.Dividend.DividendAmount / up.AverageCostPerShare) / userPortfolios.Count; // Calculate average yield on cost for all stocks

			// create DashboardModel object
			var dashboardModel = new DashboardModel
			{
				TotalDividend = totalDividend,
				TotalDividendYield = totalDividendYield,
				TotalYieldOnCost = totalYieldOnCost
			};
			// return view with dashboardModel
			return View(dashboardModel);
		}
	}

}
