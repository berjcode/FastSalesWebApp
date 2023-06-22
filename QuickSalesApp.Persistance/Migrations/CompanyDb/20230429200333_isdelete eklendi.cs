using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class isdeleteeklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_TransactionTypes_ProcessTypeId",
                table: "StockTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTransactions",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "StockTransactions");

            migrationBuilder.RenameTable(
                name: "StockTransactions",
                newName: "ProductkTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransactions_ProcessTypeId",
                table: "ProductkTransactions",
                newName: "IX_ProductkTransactions_ProcessTypeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "VatTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Units",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SafeTransactions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Safes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ProductUnits",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ProductType",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ProductPrices",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ProductBarcode",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Personals",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Departments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CustomerTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CustomerTransactions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Currencies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Categories",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "BankTransactions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Banks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "BankBankAccounts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "BankAccounts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ProductkTransactions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductkTransactions",
                table: "ProductkTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductkTransactions_TransactionTypes_ProcessTypeId",
                table: "ProductkTransactions",
                column: "ProcessTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductkTransactions_TransactionTypes_ProcessTypeId",
                table: "ProductkTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductkTransactions",
                table: "ProductkTransactions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "VatTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SafeTransactions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Safes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ProductBarcode");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CustomerTransactions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "BankTransactions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "BankBankAccounts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ProductkTransactions");

            migrationBuilder.RenameTable(
                name: "ProductkTransactions",
                newName: "StockTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_ProductkTransactions_ProcessTypeId",
                table: "StockTransactions",
                newName: "IX_StockTransactions_ProcessTypeId");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "StockTransactions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTransactions",
                table: "StockTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_TransactionTypes_ProcessTypeId",
                table: "StockTransactions",
                column: "ProcessTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
