using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class updatecompanyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "TransactionTypes",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "StockTransactions",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "SafeTransactions",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "Safes",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "Personals",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "CustomerTransactions",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "Customers",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "BankTransactions",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "Banks",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "BankBankAccounts",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "TentantId",
                table: "BankAccounts",
                newName: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "TransactionTypes",
                newName: "TentantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "StockTransactions",
                newName: "TentantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "SafeTransactions",
                newName: "TentantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Safes",
                newName: "TentantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Personals",
                newName: "TentantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "CustomerTransactions",
                newName: "TentantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Customers",
                newName: "TentantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "BankTransactions",
                newName: "TentantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Banks",
                newName: "TentantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "BankBankAccounts",
                newName: "TentantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "BankAccounts",
                newName: "TentantId");
        }
    }
}
