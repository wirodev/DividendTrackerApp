namespace DividendTracker.Models
{
    public class UserPortfolioInputViewModel
    {
        public string Ticker { get; set; }
        public decimal AverageCostPerShare { get; set; }
        public int AmountOfSharesOwned { get; set; }

    }
    public class UserPortfolioViewModel : UserPortfolioInputViewModel
    {
        public string CompanyName { get; set; }
        public decimal DividendAmount { get; set; }
        public decimal CurrentStockPrice { get; set; }
        public decimal DividendYield { get; set; }
        public decimal YieldOnCost { get; set; }
        public decimal TotalDividend => DividendAmount * AmountOfSharesOwned; // new property for Total Dividend
    }
}