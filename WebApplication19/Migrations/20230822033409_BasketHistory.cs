using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication19.Migrations
{
    public partial class BasketHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "products");

            migrationBuilder.CreateTable(
                name: "ShoppingBasketHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OperationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBasketHistories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingBasketHistories");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
