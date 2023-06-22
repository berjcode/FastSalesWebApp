using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class tentanId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "VatTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "TransactionTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "StockTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "SafeTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Safes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "ProductUnits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "ProductType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "ProductPrices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "ProductBarcode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "CustomerTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "BankTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Banks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "BankBankAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "VatTypes");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "SafeTransactions");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Safes");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "ProductBarcode");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "CustomerTransactions");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "BankTransactions");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "BankBankAccounts");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "BankAccounts");
        }
    }
}
