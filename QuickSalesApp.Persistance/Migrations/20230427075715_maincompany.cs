using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSalesApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class maincompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainCompanyId",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MainCompany",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCompany", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_MainCompanyId",
                table: "Companies",
                column: "MainCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_MainCompany_MainCompanyId",
                table: "Companies",
                column: "MainCompanyId",
                principalTable: "MainCompany",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_MainCompany_MainCompanyId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "MainCompany");

            migrationBuilder.DropIndex(
                name: "IX_Companies_MainCompanyId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MainCompanyId",
                table: "Companies");
        }
    }
}
