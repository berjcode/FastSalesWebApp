using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class editedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductPrices_ProductUnitId",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "ProductUnits");

            migrationBuilder.AddColumn<bool>(
                name: "IsVat",
                table: "ProductUnits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductUnits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductUnits_ProductId",
                table: "ProductUnits",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductUnitId",
                table: "ProductPrices",
                column: "ProductUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnits_Products_ProductId",
                table: "ProductUnits",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnits_Products_ProductId",
                table: "ProductUnits");

            migrationBuilder.DropIndex(
                name: "IX_ProductUnits_ProductId",
                table: "ProductUnits");

            migrationBuilder.DropIndex(
                name: "IX_ProductPrices_ProductUnitId",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "IsVat",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductUnits");

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "ProductUnits",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductUnitId",
                table: "ProductPrices",
                column: "ProductUnitId",
                unique: true);
        }
    }
}
