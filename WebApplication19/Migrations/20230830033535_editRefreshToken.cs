using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication19.Migrations
{
    public partial class editRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResetToken",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpiration",
                table: "clients",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetToken",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpiration",
                table: "clients");
        }
    }
}
