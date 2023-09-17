using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication19.Migrations
{
    public partial class editRefreshToken2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshToken_CreatedOn",
                table: "clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshToken_ExpiresOn",
                table: "clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshToken_RevokedOn",
                table: "clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken_Token",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefreshToken_userId",
                table: "clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "clients_RefreshTokens",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients_RefreshTokens", x => new { x.ClientId, x.Id });
                    table.ForeignKey(
                        name: "FK_clients_RefreshTokens_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients_RefreshTokens");

            migrationBuilder.DropColumn(
                name: "RefreshToken_CreatedOn",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "RefreshToken_ExpiresOn",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "RefreshToken_RevokedOn",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "RefreshToken_Token",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "RefreshToken_userId",
                table: "clients");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => new { x.ClientId, x.Id });
                    table.ForeignKey(
                        name: "FK_RefreshToken_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
