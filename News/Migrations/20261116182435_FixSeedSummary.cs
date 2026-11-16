using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Summary",
                value: "ASP.NET Core 9.0 güncellemesinde performans iyileştirmeleri");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Summary",
                value: "<p>ASP.NET Core 9.0 güncellemesinde performans iyileştirmeleri");
        }
    }
}
