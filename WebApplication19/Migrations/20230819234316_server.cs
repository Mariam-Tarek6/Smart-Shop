using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication19.Migrations
{
    public partial class server : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_colors_ColorId",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_products_ProductId",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_sizes_Sizeid",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_products_ProductId",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_sizes_SizeId",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor");

            migrationBuilder.RenameTable(
                name: "ProductSize",
                newName: "productsSize");

            migrationBuilder.RenameTable(
                name: "ProductColor",
                newName: "productsColor");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_SizeId",
                table: "productsSize",
                newName: "IX_productsSize_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_ProductId",
                table: "productsSize",
                newName: "IX_productsSize_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_Sizeid",
                table: "productsColor",
                newName: "IX_productsColor_Sizeid");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_ProductId",
                table: "productsColor",
                newName: "IX_productsColor_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_ColorId",
                table: "productsColor",
                newName: "IX_productsColor_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productsSize",
                table: "productsSize",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productsColor",
                table: "productsColor",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_productsColor_colors_ColorId",
                table: "productsColor",
                column: "ColorId",
                principalTable: "colors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productsColor_products_ProductId",
                table: "productsColor",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productsColor_sizes_Sizeid",
                table: "productsColor",
                column: "Sizeid",
                principalTable: "sizes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productsSize_products_ProductId",
                table: "productsSize",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productsSize_sizes_SizeId",
                table: "productsSize",
                column: "SizeId",
                principalTable: "sizes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productsColor_colors_ColorId",
                table: "productsColor");

            migrationBuilder.DropForeignKey(
                name: "FK_productsColor_products_ProductId",
                table: "productsColor");

            migrationBuilder.DropForeignKey(
                name: "FK_productsColor_sizes_Sizeid",
                table: "productsColor");

            migrationBuilder.DropForeignKey(
                name: "FK_productsSize_products_ProductId",
                table: "productsSize");

            migrationBuilder.DropForeignKey(
                name: "FK_productsSize_sizes_SizeId",
                table: "productsSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productsSize",
                table: "productsSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productsColor",
                table: "productsColor");

            migrationBuilder.RenameTable(
                name: "productsSize",
                newName: "ProductSize");

            migrationBuilder.RenameTable(
                name: "productsColor",
                newName: "ProductColor");

            migrationBuilder.RenameIndex(
                name: "IX_productsSize_SizeId",
                table: "ProductSize",
                newName: "IX_ProductSize_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_productsSize_ProductId",
                table: "ProductSize",
                newName: "IX_ProductSize_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productsColor_Sizeid",
                table: "ProductColor",
                newName: "IX_ProductColor_Sizeid");

            migrationBuilder.RenameIndex(
                name: "IX_productsColor_ProductId",
                table: "ProductColor",
                newName: "IX_ProductColor_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productsColor_ColorId",
                table: "ProductColor",
                newName: "IX_ProductColor_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_colors_ColorId",
                table: "ProductColor",
                column: "ColorId",
                principalTable: "colors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_products_ProductId",
                table: "ProductColor",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_sizes_Sizeid",
                table: "ProductColor",
                column: "Sizeid",
                principalTable: "sizes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_products_ProductId",
                table: "ProductSize",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_sizes_SizeId",
                table: "ProductSize",
                column: "SizeId",
                principalTable: "sizes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
