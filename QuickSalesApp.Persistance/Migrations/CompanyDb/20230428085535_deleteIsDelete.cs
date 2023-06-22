using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class deleteIsDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VatTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SafeTransactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Safes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductBarcode");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerTransactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BankTransactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BankBankAccounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BankAccounts");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "VatTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Units",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "TransactionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "StockTransactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "SafeTransactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Safes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "ProductUnits",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "ProductPrices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "ProductBarcode",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Personals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "CustomerTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "CustomerTransactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Currencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "BankTransactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Banks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "BankBankAccounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "BankAccounts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "VatTypes");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "SafeTransactions");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Safes");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "ProductBarcode");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "CustomerTransactions");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "BankTransactions");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "BankBankAccounts");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "BankAccounts");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VatTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Units",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TransactionTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StockTransactions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SafeTransactions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Safes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductUnits",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductType",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductPrices",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductBarcode",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Personals",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerTransactions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Currencies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BankTransactions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Banks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BankBankAccounts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BankAccounts",
                type: "bit",
                nullable: true);
        }
    }
}
