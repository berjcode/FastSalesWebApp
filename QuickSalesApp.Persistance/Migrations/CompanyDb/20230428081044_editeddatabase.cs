using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class editeddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "VatTypes",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "VatTypes",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "Units",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "Units",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "TransactionTypes",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "TransactionTypes",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "StockTransactions",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "StockTransactions",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "SafeTransactions",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "SafeTransactions",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "Safes",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "Safes",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "ProductUnits",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "ProductUnits",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "ProductType",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "ProductType",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "Products",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "Products",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "ProductPrices",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "ProductPrices",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "ProductBarcode",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "ProductBarcode",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "Personals",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "Personals",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "Departments",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "Departments",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "CustomerTypes",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "CustomerTypes",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "CustomerTransactions",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "CustomerTransactions",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "Customers",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "Customers",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "Currencies",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "Currencies",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "Categories",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "Categories",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "BankTransactions",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "BankTransactions",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "Banks",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "Banks",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "BankBankAccounts",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "BankBankAccounts",
                newName: "DeleterName");

            migrationBuilder.RenameColumn(
                name: "UpdatedByName",
                table: "BankAccounts",
                newName: "UpdaterName");

            migrationBuilder.RenameColumn(
                name: "DeletedByName",
                table: "BankAccounts",
                newName: "DeleterName");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "VatTypes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Units",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TransactionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "StockTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "SafeTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Safes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductUnits",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductType",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductBarcode",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Personals",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "CustomerTypes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "CustomerTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Currencies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BankTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Banks",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BankBankAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BankAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "VatTypes",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "VatTypes",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "Units",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "Units",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "TransactionTypes",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "TransactionTypes",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "StockTransactions",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "StockTransactions",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "SafeTransactions",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "SafeTransactions",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "Safes",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "Safes",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "ProductUnits",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "ProductUnits",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "ProductType",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "ProductType",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "Products",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "Products",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "ProductPrices",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "ProductPrices",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "ProductBarcode",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "ProductBarcode",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "Personals",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "Personals",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "Departments",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "Departments",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "CustomerTypes",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "CustomerTypes",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "CustomerTransactions",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "CustomerTransactions",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "Customers",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "Customers",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "Currencies",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "Currencies",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "Categories",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "Categories",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "BankTransactions",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "BankTransactions",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "Banks",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "Banks",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "BankBankAccounts",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "BankBankAccounts",
                newName: "DeletedByName");

            migrationBuilder.RenameColumn(
                name: "UpdaterName",
                table: "BankAccounts",
                newName: "UpdatedByName");

            migrationBuilder.RenameColumn(
                name: "DeleterName",
                table: "BankAccounts",
                newName: "DeletedByName");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "VatTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Units",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TransactionTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "StockTransactions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "SafeTransactions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Safes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductUnits",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductType",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductBarcode",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Personals",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Departments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "CustomerTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "CustomerTransactions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Currencies",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BankTransactions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Banks",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BankBankAccounts",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BankAccounts",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
