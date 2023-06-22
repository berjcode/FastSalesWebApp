using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class tentantIddelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "UserAndCompanyRelationships");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "MainRoles");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "MainRoleAndUserRelationships");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "MainCompany");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "MainAndRoleRelationShips");

            migrationBuilder.DropColumn(
                name: "TentantId",
                table: "Companies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "UserAndCompanyRelationships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "MainRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "MainRoleAndUserRelationships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "MainCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "MainAndRoleRelationShips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TentantId",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
