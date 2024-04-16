using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DividendTracker.Models;

namespace DividendTracker.Controllers
{
	public class StocksController : Controller
	{
		private readonly ApplicationDbContext _context;

		// Constructor
		public StocksController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Stocks
		// modified to join the Stock and Dividend table into 1 view.
		public async Task<IActionResult> Index()
		{
			var viewModel = await _context.Stocks
				.Join(_context.Dividends,
					  stock => stock.Ticker,
					  dividend => dividend.Ticker,
					  (stock, dividend) => new StockDividendViewModel
					  {
						  Ticker = stock.Ticker,
						  CompanyName = stock.CompanyName,
						  Sector = stock.Sector,
						  CurrentStockPrice = dividend.CurrentStockPrice,
						  DividendAmount = dividend.DividendAmount,
						  PayoutFrequency = dividend.PayoutFrequency
					  })
				.ToListAsync();

			return View(viewModel);
		}

		// GET: Stocks/Details/5
		public async Task<IActionResult> Details(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var stock = await _context.Stocks
				.FirstOrDefaultAsync(m => m.Ticker == id);
			if (stock == null)
			{
				return NotFound();
			}

			return View(stock);
		}

		// GET: Stocks/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Stocks/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Ticker,CompanyName,Sector")] Stock stock)
		{
			if (ModelState.IsValid)
			{
				_context.Add(stock);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(stock);
		}

		// GET: Stocks/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var stock = await _context.Stocks.FindAsync(id);
			if (stock == null)
			{
				return NotFound();
			}
			return View(stock);
		}

		// POST: Stocks/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("Ticker,CompanyName,Sector")] Stock stock)
		{
			if (id != stock.Ticker)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(stock);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!StockExists(stock.Ticker))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(stock);
		}

		// GET: Stocks/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var stock = await _context.Stocks
				.FirstOrDefaultAsync(m => m.Ticker == id);
			if (stock == null)
			{
				return NotFound();
			}

			return View(stock);
		}

		// POST: Stocks/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			var stock = await _context.Stocks.FindAsync(id);
			if (stock != null)
			{
				_context.Stocks.Remove(stock);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool StockExists(string id)
		{
			return _context.Stocks.Any(e => e.Ticker == id);
		}
	}
}
