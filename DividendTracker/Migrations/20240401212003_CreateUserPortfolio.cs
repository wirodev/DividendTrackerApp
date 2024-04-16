using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DividendTracker.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserPortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPortfolios",
                columns: table => new
                {
                    UserPortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AverageCostPerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountOfSharesOwned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPortfolios", x => x.UserPortfolioId);
                    table.ForeignKey(
                        name: "FK_UserPortfolios_Stocks_Ticker",
                        column: x => x.Ticker,
                        principalTable: "Stocks",
                        principalColumn: "Ticker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPortfolios_Ticker",
                table: "UserPortfolios",
                column: "Ticker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPortfolios");
        }
    }
}
