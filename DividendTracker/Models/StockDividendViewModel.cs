using System.ComponentModel;

namespace DividendTracker.Models
{
    public class StockDividendViewModel
    {
        public string Ticker { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        public string Sector { get; set; }
        [DisplayName("Current Stock Price")]
        public decimal CurrentStockPrice { get; set; }
        [DisplayName("Dividend Amount")]
        public decimal DividendAmount { get; set; }
        [DisplayName("Payout Frequency")]
        public string PayoutFrequency { get; set; }
    }
}
