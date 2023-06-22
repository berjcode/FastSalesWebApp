using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class deletetentantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "VatTypes");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Units");

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
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
