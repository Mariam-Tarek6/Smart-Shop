using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication19.Migrations
{
    public partial class DeleteSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_subCategories_SubCategoryId",
                table: "products");

            migrationBuilder.DropTable(
                name: "subCategories");

            migrationBuilder.DropIndex(
                name: "IX_products_SubCategoryId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "subCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subCategories_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_SubCategoryId",
                table: "products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_subCategories_CategoryId",
                table: "subCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_subCategories_SubCategoryId",
                table: "products",
                column: "SubCategoryId",
                principalTable: "subCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
