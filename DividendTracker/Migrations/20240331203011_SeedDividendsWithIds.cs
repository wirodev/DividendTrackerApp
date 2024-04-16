using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DividendTracker.Migrations
{
    /// <inheritdoc />
    public partial class SeedDividendsWithIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dividends",
                columns: new[] { "DividendId", "CurrentStockPrice", "DividendAmount", "PayoutFrequency", "Ticker" },
                values: new object[,]
                {
                    { -26, 239.6m, 7.75m, "Annually", "ESSITY-B" },
                    { -25, 285.3m, 7.5m, "Annually", "BOL" },
                    { -24, 228.1m, 7.5m, "Annually", "SKF-B" },
                    { -23, 428m, 7.5m, "Annually", "ALFA" },
                    { -22, 86.44m, 6.9m, "Annually", "TEL2-B" },
                    { -21, 149.68m, 6.5m, "Annually", "HM-B" },
                    { -20, 241m, 5.5m, "Annually", "SAND" },
                    { -19, 309.4m, 5.4m, "Annually", "ASSA-B" },
                    { -18, 263.8m, 4.8m, "Annually", "INVE-B" },
                    { -17, 206.4m, 4.4m, "Annually", "GETI-B" },
                    { -16, 1369m, 2.9m, "Annually", "AZN" },
                    { -15, 160.75m, 2.8m, "Annually", "ATCO-B" },
                    { -14, 181.7m, 2.8m, "Annually", "ATCO-A" },
                    { -13, 156.55m, 2.75m, "Annually", "SCA-B" },
                    { -12, 57.02m, 2.7m, "Annually", "ERIC-B" },
                    { -11, 1258.5m, 2.66m, "Annually", "ALIV-SDB" },
                    { -10, 1358.6m, 2.65m, "Annually", "EVO" },
                    { -9, 25.69m, 2m, "Annually", "TELIA" },
                    { -8, 306.9m, 18m, "Annually", "VOLV-B" },
                    { -7, 226.5m, 15.15m, "Annually", "SWED-A" },
                    { -6, 122.3m, 13m, "Annually", "SHB-A" },
                    { -5, 144.85m, 11.5m, "Annually", "SEB-A" },
                    { -4, 497.4m, 1.01m, "Annually", "ABB" },
                    { -3, 125.76m, 0.92m, "Annually", "NDA-SE" },
                    { -2, 55.06m, 0.65m, "Annually", "NIBE-B" },
                    { -1, 124.95m, 0.13m, "Annually", "HEXA-B" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -26);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -25);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -24);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -23);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -21);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -20);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -19);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -18);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -17);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -16);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Dividends",
                keyColumn: "DividendId",
                keyValue: -1);
        }
    }
}
