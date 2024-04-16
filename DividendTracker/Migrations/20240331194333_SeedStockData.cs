using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DividendTracker.Migrations
{
    /// <inheritdoc />
    public partial class SeedStockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Ticker", "CompanyName", "Sector" },
                values: new object[,]
                {
                    { "ABB", "ABB", "Industrial" },
                    { "ALFA", "Alfa Laval", "Industrial" },
                    { "ALIV-SDB", "Autoliv", "Industrial" },
                    { "ASSA-B", "Assa Abloy", "Real Estate" },
                    { "ATCO-A", "Atlas Copco A", "Industrial" },
                    { "ATCO-B", "Atlas Copco B", "Industrial" },
                    { "AZN", "AstraZeneca", "Pharma" },
                    { "BOL", "Boliden", "Raw Material" },
                    { "ERIC-B", "Ericsson B", "Communication" },
                    { "ESSITY-B", "Essity B", "Consumer goods" },
                    { "EVO", "Evolution", "Consumer goods" },
                    { "GETI-B", "Getinge", "Pharma" },
                    { "HEXA-B", "Hexagon", "Utilities" },
                    { "HM-B", "Hennes & Mauritz", "Consumer goods" },
                    { "INVE-B", "Investor B", "Investment company" },
                    { "NDA-SE", "Nordea Bank", "Finance" },
                    { "NIBE-B", "NIBE Industrier", "Utilities" },
                    { "SAND", "Sandvik", "Industrial" },
                    { "SCA-B", "SCA B", "Raw Material" },
                    { "SEB-A", "SEB A", "Finance" },
                    { "SHB-A", "Handelsbanken A", "Finance" },
                    { "SKF-B", "SKF B", "Industrial" },
                    { "SWED-A", "Swedbank", "Finance" },
                    { "TEL2-B", "Tele2 B", "Communication" },
                    { "TELIA", "Telia Company", "Communication" },
                    { "VOLV-B", "Volvo B", "Industrial" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "ABB");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "ALFA");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "ALIV-SDB");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "ASSA-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "ATCO-A");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "ATCO-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "AZN");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "BOL");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "ERIC-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "ESSITY-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "EVO");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "GETI-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "HEXA-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "HM-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "INVE-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "NDA-SE");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "NIBE-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "SAND");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "SCA-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "SEB-A");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "SHB-A");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "SKF-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "SWED-A");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "TEL2-B");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "TELIA");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Ticker",
                keyValue: "VOLV-B");
        }
    }
}
