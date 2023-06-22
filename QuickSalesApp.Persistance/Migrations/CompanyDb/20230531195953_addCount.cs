using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class addCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ProductUnits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "ProductUnits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ProductkTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "ProductkTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ProductkTransactions");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "ProductkTransactions");
        }
    }
}
