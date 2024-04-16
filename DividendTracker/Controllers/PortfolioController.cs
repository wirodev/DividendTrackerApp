using DividendTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DividendTracker.Controllers
{
	// Controller for the user's portfolio
	public class PortfolioController : Controller
	{
		private readonly ApplicationDbContext _context;

		// initialize  controller with instance of ApplicationDbContext
		public PortfolioController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Portfolio
		public IActionResult Index()
		{
			return View();
		}

		// POST: Portfolio/AddStockToPortfolio
		// adding a stock to the portfolio
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddStockToPortfolio(UserPortfolioInputViewModel userPortfolio)
		{
			if (ModelState.IsValid)
			{
				// check if stock already exists in the portfolio
				var existingPortfolioEntry = await _context.UserPortfolios
					.FirstOrDefaultAsync(p => p.Ticker == userPortfolio.Ticker);

				// if exists, then update
				if (existingPortfolioEntry != null)
				{
					// calculate the new weighted average cost per share
					var totalCostOfExistingShares = existingPortfolioEntry.AverageCostPerShare * existingPortfolioEntry.AmountOfSharesOwned;
					var totalCostOfNewShares = userPortfolio.AverageCostPerShare * userPortfolio.AmountOfSharesOwned;
					var totalShares = existingPortfolioEntry.AmountOfSharesOwned + userPortfolio.AmountOfSharesOwned;

					// update the portfolio entry
					existingPortfolioEntry.AverageCostPerShare = (totalCostOfExistingShares + totalCostOfNewShares) / totalShares;
					existingPortfolioEntry.AmountOfSharesOwned = totalShares;

					_context.Update(existingPortfolioEntry);
				}

				// if does not exist, then add
				else
				{
					existingPortfolioEntry = new UserPortfolio
					{
						AmountOfSharesOwned = userPortfolio.AmountOfSharesOwned,
						AverageCostPerShare = userPortfolio.AverageCostPerShare,
						Ticker = userPortfolio.Ticker
					};

					_context.Add(existingPortfolioEntry);
				}

				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(UserPortfolio));
			}

			// handle invalid model state
			return RedirectToAction("Index", "Stocks");
		}

		// GET: Portfolio/UserPortfolio
		// method for displaying the user's portfolio
		public async Task<IActionResult> UserPortfolio()
		{
			// join the UserPortfolios, Stocks, and Dividends tables to get the necessary data
			var portfolioData = await _context.UserPortfolios
				.Join(_context.Stocks, portfolio => portfolio.Ticker, stock => stock.Ticker,
					(portfolio, stock) => new { portfolio, stock })
				.Join(_context.Dividends, combined => combined.stock.Ticker, dividend => dividend.Ticker,
					(combined, dividend) => new UserPortfolioViewModel
					{
						Ticker = combined.portfolio.Ticker,
						CompanyName = combined.stock.CompanyName,
						AverageCostPerShare = combined.portfolio.AverageCostPerShare,
						AmountOfSharesOwned = combined.portfolio.AmountOfSharesOwned,
						DividendAmount = dividend.DividendAmount,
						CurrentStockPrice = dividend.CurrentStockPrice,
						DividendYield = dividend.CurrentStockPrice > 0 ? dividend.DividendAmount / dividend.CurrentStockPrice : 0,
						YieldOnCost = combined.portfolio.AverageCostPerShare > 0 ? dividend.DividendAmount / combined.portfolio.AverageCostPerShare : 0
					})
				.ToListAsync();

			return View(portfolioData);
		}

		// POST: Portfolio/SellStock
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SellStock(string ticker, int amountOfSharesToSell)
		{
			// get the portfolio entry for the stock
			var userPortfolioEntry = await _context.UserPortfolios
				.FirstOrDefaultAsync(p => p.Ticker == ticker);

			// if the portfolio entry exists and the amount of shares to sell is valid, then update the entry
			if (userPortfolioEntry != null && amountOfSharesToSell > 0 && amountOfSharesToSell <= userPortfolioEntry.AmountOfSharesOwned)
			{
				userPortfolioEntry.AmountOfSharesOwned -= amountOfSharesToSell;

				// if the user sells all of their shares, then remove the portfolio entry
				if (userPortfolioEntry.AmountOfSharesOwned == 0)
				{
					_context.UserPortfolios.Remove(userPortfolioEntry);
				}
				// otherwise, update the portfolio entry
				else
				{
					_context.Update(userPortfolioEntry);
				}
				// save changes
				await _context.SaveChangesAsync();
			}
			// need error handling
			else
			{

			}

			return RedirectToAction(nameof(UserPortfolio));
		}


	}
}
