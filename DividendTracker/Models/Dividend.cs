using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DividendTracker.Models
{
    public class Dividend
    {
        [Key]
        public int DividendId { get; set; }
        [ForeignKey("Stock")]
        public string Ticker { get; set; }
        public decimal CurrentStockPrice { get; set; }
        public decimal DividendAmount { get; set; }
        public string PayoutFrequency { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
