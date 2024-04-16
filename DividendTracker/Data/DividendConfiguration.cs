using DividendTracker.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DividendTracker.Data
{
    public class DividendConfiguration : IEntityTypeConfiguration<Dividend>
    {
        public void Configure(EntityTypeBuilder<Dividend> builder)
        {
            builder.HasData(
                new Dividend { DividendId = -1, Ticker = "HEXA-B", CurrentStockPrice = 124.95m, DividendAmount = 0.13m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -2, Ticker = "NIBE-B", CurrentStockPrice = 55.06m, DividendAmount = 0.65m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -3, Ticker = "NDA-SE", CurrentStockPrice = 125.76m, DividendAmount = 0.92m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -4, Ticker = "ABB", CurrentStockPrice = 497.4m, DividendAmount = 1.01m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -5, Ticker = "SEB-A", CurrentStockPrice = 144.85m, DividendAmount = 11.5m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -6, Ticker = "SHB-A", CurrentStockPrice = 122.3m, DividendAmount = 13m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -7, Ticker = "SWED-A", CurrentStockPrice = 226.5m, DividendAmount = 15.15m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -8, Ticker = "VOLV-B", CurrentStockPrice = 306.9m, DividendAmount = 18m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -9, Ticker = "TELIA", CurrentStockPrice = 25.69m, DividendAmount = 2m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -10, Ticker = "EVO", CurrentStockPrice = 1358.6m, DividendAmount = 2.65m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -11, Ticker = "ALIV-SDB", CurrentStockPrice = 1258.5m, DividendAmount = 2.66m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -12, Ticker = "ERIC-B", CurrentStockPrice = 57.02m, DividendAmount = 2.7m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -13, Ticker = "SCA-B", CurrentStockPrice = 156.55m, DividendAmount = 2.75m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -14, Ticker = "ATCO-A", CurrentStockPrice = 181.7m, DividendAmount = 2.8m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -15, Ticker = "ATCO-B", CurrentStockPrice = 160.75m, DividendAmount = 2.8m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -16, Ticker = "AZN", CurrentStockPrice = 1369m, DividendAmount = 2.9m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -17, Ticker = "GETI-B", CurrentStockPrice = 206.4m, DividendAmount = 4.4m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -18, Ticker = "INVE-B", CurrentStockPrice = 263.8m, DividendAmount = 4.8m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -19, Ticker = "ASSA-B", CurrentStockPrice = 309.4m, DividendAmount = 5.4m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -20, Ticker = "SAND", CurrentStockPrice = 241m, DividendAmount = 5.5m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -21, Ticker = "HM-B", CurrentStockPrice = 149.68m, DividendAmount = 6.5m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -22, Ticker = "TEL2-B", CurrentStockPrice = 86.44m, DividendAmount = 6.9m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -23, Ticker = "ALFA", CurrentStockPrice = 428m, DividendAmount = 7.5m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -24, Ticker = "SKF-B", CurrentStockPrice = 228.1m, DividendAmount = 7.5m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -25, Ticker = "BOL", CurrentStockPrice = 285.3m, DividendAmount = 7.5m, PayoutFrequency = "Annually" },
                new Dividend { DividendId = -26, Ticker = "ESSITY-B", CurrentStockPrice = 239.6m, DividendAmount = 7.75m, PayoutFrequency = "Annually" }
            );
        }
    }
}
