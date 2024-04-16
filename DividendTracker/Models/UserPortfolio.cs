using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DividendTracker.Models
{
    public class UserPortfolio
    {
        [Key]
        public int UserPortfolioId { get; set; }

        [Required]
        //[ForeignKey("Stock")]
        public string Ticker { get; set; }

        public virtual Stock Stock { get; set; } 

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AverageCostPerShare { get; set; }

        public int AmountOfSharesOwned { get; set; }
    }
}
