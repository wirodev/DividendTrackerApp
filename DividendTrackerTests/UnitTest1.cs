using DividendTracker.Controllers;
using DividendTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PortfolioControllerTests
{
    [Fact]
    public async Task AddStockToPortfolio_Adds_New_Stock()
    {
        // arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddStockToPortfolioDB") 
            .Options;
        using var context = new ApplicationDbContext(options);
        var controller = new PortfolioController(context);
        var newStock = new UserPortfolioInputViewModel
        {
            Ticker = "TESTTICKER",
            AmountOfSharesOwned = 100,
            AverageCostPerShare = 10
        };

        // act
        var result = await controller.AddStockToPortfolio(newStock);

        // assert
        var actionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("UserPortfolio", actionResult.ActionName);
        var stockInDb = await context.UserPortfolios.FirstOrDefaultAsync(s => s.Ticker == newStock.Ticker);
        Assert.NotNull(stockInDb);
        Assert.Equal(100, stockInDb.AmountOfSharesOwned);
    }

    [Fact]
    public async Task SellStock_Removes_Shares()
    {
        // arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "SellStockDB")
            .Options;
        using var context = new ApplicationDbContext(options);
        context.UserPortfolios.Add(new UserPortfolio
        {
            UserPortfolioId = 1,
            Ticker = "TESTTICKER",
            AmountOfSharesOwned = 150,
            AverageCostPerShare = 10
        });
        context.SaveChanges();
        var controller = new PortfolioController(context);

        // act
        var result = await controller.SellStock("TESTTICKER", 50);

        // assert
        var actionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("UserPortfolio", actionResult.ActionName);
        var stockInDb = await context.UserPortfolios.FirstOrDefaultAsync(s => s.Ticker == "TESTTICKER");
        Assert.NotNull(stockInDb);
        Assert.Equal(100, stockInDb.AmountOfSharesOwned);
    }
}
