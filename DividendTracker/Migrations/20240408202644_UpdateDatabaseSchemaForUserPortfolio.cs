using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DividendTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchemaForUserPortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dividends_Ticker",
                table: "Dividends");

            migrationBuilder.AlterColumn<string>(
                name: "Ticker",
                table: "UserPortfolios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserPortfolios_Ticker",
                table: "UserPortfolios",
                column: "Ticker");

            migrationBuilder.CreateIndex(
                name: "IX_Dividends_Ticker",
                table: "Dividends",
                column: "Ticker",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPortfolios_Stocks_Ticker",
                table: "UserPortfolios",
                column: "Ticker",
                principalTable: "Stocks",
                principalColumn: "Ticker",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPortfolios_Stocks_Ticker",
                table: "UserPortfolios");

            migrationBuilder.DropIndex(
                name: "IX_UserPortfolios_Ticker",
                table: "UserPortfolios");

            migrationBuilder.DropIndex(
                name: "IX_Dividends_Ticker",
                table: "Dividends");

            migrationBuilder.AlterColumn<string>(
                name: "Ticker",
                table: "UserPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Dividends_Ticker",
                table: "Dividends",
                column: "Ticker");
        }
    }
}
