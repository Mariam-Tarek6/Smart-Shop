using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication19.Migrations
{
    public partial class subCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_SubCategory_SubCategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_categories_CategoryId",
                table: "SubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory");

            migrationBuilder.RenameTable(
                name: "SubCategory",
                newName: "subCategories");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategory_CategoryId",
                table: "subCategories",
                newName: "IX_subCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subCategories",
                table: "subCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_subCategories_SubCategoryId",
                table: "products",
                column: "SubCategoryId",
                principalTable: "subCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subCategories_categories_CategoryId",
                table: "subCategories",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_subCategories_SubCategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_subCategories_categories_CategoryId",
                table: "subCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subCategories",
                table: "subCategories");

            migrationBuilder.RenameTable(
                name: "subCategories",
                newName: "SubCategory");

            migrationBuilder.RenameIndex(
                name: "IX_subCategories_CategoryId",
                table: "SubCategory",
                newName: "IX_SubCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_SubCategory_SubCategoryId",
                table: "products",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_categories_CategoryId",
                table: "SubCategory",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
