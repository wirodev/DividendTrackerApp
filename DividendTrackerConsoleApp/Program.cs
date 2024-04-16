using DividendTracker.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StockDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        using (var context = new ApplicationDbContext(optionsBuilder.Options))
        {
            var stocksWithDividends = context.Stocks
                .Join(context.Dividends,
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
                .ToList();

            Console.WriteLine("Stock List");
            Console.WriteLine();
            foreach (var item in stocksWithDividends)
            {
                Console.WriteLine($"{item.Ticker}\t\t{item.CompanyName}\t\t{item.Sector}\t\t{item.CurrentStockPrice}\t\t{item.DividendAmount}\t\t{item.PayoutFrequency}");
            }
        }
    }
}
