using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DividendTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStockNavigationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPortfolios_Stocks_Ticker",
                table: "UserPortfolios");

            migrationBuilder.DropIndex(
                name: "IX_UserPortfolios_Ticker",
                table: "UserPortfolios");

            migrationBuilder.AlterColumn<string>(
                name: "Ticker",
                table: "UserPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_UserPortfolios_Stocks_Ticker",
                table: "UserPortfolios",
                column: "Ticker",
                principalTable: "Stocks",
                principalColumn: "Ticker",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
