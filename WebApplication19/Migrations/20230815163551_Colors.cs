using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication19.Migrations
{
    public partial class Colors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
