using DividendTracker.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DividendTracker.Data
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasData(
                new Stock { Ticker = "HEXA-B", CompanyName = "Hexagon", Sector = "Utilities" },
                new Stock { Ticker = "NIBE-B", CompanyName = "NIBE Industrier", Sector = "Utilities" },
                new Stock { Ticker = "NDA-SE", CompanyName = "Nordea Bank", Sector = "Finance" },
                new Stock { Ticker = "ABB", CompanyName = "ABB", Sector = "Industrial" },
                new Stock { Ticker = "SEB-A", CompanyName = "SEB A", Sector = "Finance" },
                new Stock { Ticker = "SHB-A", CompanyName = "Handelsbanken A", Sector = "Finance" },
                new Stock { Ticker = "SWED-A", CompanyName = "Swedbank", Sector = "Finance" },
                new Stock { Ticker = "VOLV-B", CompanyName = "Volvo B", Sector = "Industrial" },
                new Stock { Ticker = "TELIA", CompanyName = "Telia Company", Sector = "Communication" },
                new Stock { Ticker = "EVO", CompanyName = "Evolution", Sector = "Consumer goods" },
                new Stock { Ticker = "ALIV-SDB", CompanyName = "Autoliv", Sector = "Industrial" },
                new Stock { Ticker = "ERIC-B", CompanyName = "Ericsson B", Sector = "Communication" },
                new Stock { Ticker = "SCA-B", CompanyName = "SCA B", Sector = "Raw Material" },
                new Stock { Ticker = "ATCO-A", CompanyName = "Atlas Copco A", Sector = "Industrial" },
                new Stock { Ticker = "ATCO-B", CompanyName = "Atlas Copco B", Sector = "Industrial" },
                new Stock { Ticker = "AZN", CompanyName = "AstraZeneca", Sector = "Pharma" },
                new Stock { Ticker = "GETI-B", CompanyName = "Getinge", Sector = "Pharma" },
                new Stock { Ticker = "INVE-B", CompanyName = "Investor B", Sector = "Investment company" },
                new Stock { Ticker = "ASSA-B", CompanyName = "Assa Abloy", Sector = "Real Estate" },
                new Stock { Ticker = "SAND", CompanyName = "Sandvik", Sector = "Industrial" },
                new Stock { Ticker = "HM-B", CompanyName = "Hennes & Mauritz", Sector = "Consumer goods" },
                new Stock { Ticker = "TEL2-B", CompanyName = "Tele2 B", Sector = "Communication" },
                new Stock { Ticker = "ALFA", CompanyName = "Alfa Laval", Sector = "Industrial" },
                new Stock { Ticker = "SKF-B", CompanyName = "SKF B", Sector = "Industrial" },
                new Stock { Ticker = "BOL", CompanyName = "Boliden", Sector = "Raw Material" },
                new Stock { Ticker = "ESSITY-B", CompanyName = "Essity B", Sector = "Consumer goods" }
            );
        }
    }
}
