using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class newtablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_CustomerTypes_CurrencyId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankTransactions_LineTypes_ProcessTypeId",
                table: "BankTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ClTypes_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerTransactions_LineTypes_ProcessTypeId",
                table: "CustomerTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Safes_CustomerTypes_CurrencyType",
                table: "Safes");

            migrationBuilder.DropForeignKey(
                name: "FK_SafeTransactions_LineTypes_ProcessTypeId",
                table: "SafeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_LineTypes_ProcessTypeId",
                table: "StockTransactions");

            migrationBuilder.DropTable(
                name: "ClTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineTypes",
                table: "LineTypes");

            migrationBuilder.RenameTable(
                name: "LineTypes",
                newName: "TransactionTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Currencies_CurrencyId",
                table: "BankAccounts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransactions_TransactionTypes_ProcessTypeId",
                table: "BankTransactions",
                column: "ProcessTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerTransactions_TransactionTypes_ProcessTypeId",
                table: "CustomerTransactions",
                column: "ProcessTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Safes_Currencies_CurrencyType",
                table: "Safes",
                column: "CurrencyType",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SafeTransactions_TransactionTypes_ProcessTypeId",
                table: "SafeTransactions",
                column: "ProcessTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_TransactionTypes_ProcessTypeId",
                table: "StockTransactions",
                column: "ProcessTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Currencies_CurrencyId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankTransactions_TransactionTypes_ProcessTypeId",
                table: "BankTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerTransactions_TransactionTypes_ProcessTypeId",
                table: "CustomerTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Safes_Currencies_CurrencyType",
                table: "Safes");

            migrationBuilder.DropForeignKey(
                name: "FK_SafeTransactions_TransactionTypes_ProcessTypeId",
                table: "SafeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_TransactionTypes_ProcessTypeId",
                table: "StockTransactions");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                newName: "LineTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineTypes",
                table: "LineTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_CustomerTypes_CurrencyId",
                table: "BankAccounts",
                column: "CurrencyId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransactions_LineTypes_ProcessTypeId",
                table: "BankTransactions",
                column: "ProcessTypeId",
                principalTable: "LineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ClTypes_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId",
                principalTable: "ClTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerTransactions_LineTypes_ProcessTypeId",
                table: "CustomerTransactions",
                column: "ProcessTypeId",
                principalTable: "LineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Safes_CustomerTypes_CurrencyType",
                table: "Safes",
                column: "CurrencyType",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SafeTransactions_LineTypes_ProcessTypeId",
                table: "SafeTransactions",
                column: "ProcessTypeId",
                principalTable: "LineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_LineTypes_ProcessTypeId",
                table: "StockTransactions",
                column: "ProcessTypeId",
                principalTable: "LineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
