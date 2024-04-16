using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DividendTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddDividendTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dividends",
                columns: table => new
                {
                    DividendId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentStockPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DividendAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayoutFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividends", x => x.DividendId);
                    table.ForeignKey(
                        name: "FK_Dividends_Stocks_Ticker",
                        column: x => x.Ticker,
                        principalTable: "Stocks",
                        principalColumn: "Ticker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dividends_Ticker",
                table: "Dividends",
                column: "Ticker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dividends");
        }
    }
}
