using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication19.Migrations
{
    public partial class intial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_products_ProductId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_products_ProductId1",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_SubCategory_SubCategoryId1",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingBasketItems_products_ProductId1",
                table: "shoppingBasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingBaskets_clients_ClientId",
                table: "shoppingBaskets");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_categories_CategoryId1",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_CategoryId1",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_shoppingBaskets_ClientId",
                table: "shoppingBaskets");

            migrationBuilder.DropIndex(
                name: "IX_shoppingBasketItems_ProductId1",
                table: "shoppingBasketItems");

            migrationBuilder.DropIndex(
                name: "IX_products_SubCategoryId1",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_comments_ProductId1",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_categories_ProductId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "shoppingBasketItems");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "shoppingBasketItems");

            migrationBuilder.DropColumn(
                name: "SubCategoryId1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "categories");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "shoppingBaskets",
                newName: "totalPrice");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "shoppingBaskets",
                newName: "clientId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "shoppingBaskets",
                newName: "qty");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "shoppingBaskets",
                newName: "id");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPriceAfterDiscount",
                table: "shoppingBaskets",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "totalPrice",
                table: "shoppingBaskets",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "clientId",
                table: "shoppingBaskets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingBasketid",
                table: "clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBaskets_clientId",
                table: "shoppingBaskets",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_ShoppingBasketid",
                table: "clients",
                column: "ShoppingBasketid");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_shoppingBaskets_ShoppingBasketid",
                table: "clients",
                column: "ShoppingBasketid",
                principalTable: "shoppingBaskets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingBaskets_clients_clientId",
                table: "shoppingBaskets",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_shoppingBaskets_ShoppingBasketid",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingBaskets_clients_clientId",
                table: "shoppingBaskets");

            migrationBuilder.DropIndex(
                name: "IX_shoppingBaskets_clientId",
                table: "shoppingBaskets");

            migrationBuilder.DropIndex(
                name: "IX_clients_ShoppingBasketid",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "color",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ShoppingBasketid",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "shoppingBaskets",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "shoppingBaskets",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "qty",
                table: "shoppingBaskets",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "shoppingBaskets",
                newName: "BasketId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "SubCategory",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "shoppingBaskets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "shoppingBaskets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPriceAfterDiscount",
                table: "shoppingBaskets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "shoppingBasketItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "shoppingBasketItems",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId1",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId1",
                table: "SubCategory",
                column: "CategoryId1",
                unique: true,
                filter: "[CategoryId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBaskets_ClientId",
                table: "shoppingBaskets",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBasketItems_ProductId1",
                table: "shoppingBasketItems",
                column: "ProductId1",
                unique: true,
                filter: "[ProductId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_products_SubCategoryId1",
                table: "products",
                column: "SubCategoryId1",
                unique: true,
                filter: "[SubCategoryId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ProductId1",
                table: "comments",
                column: "ProductId1",
                unique: true,
                filter: "[ProductId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_categories_ProductId",
                table: "categories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_products_ProductId",
                table: "categories",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_products_ProductId1",
                table: "comments",
                column: "ProductId1",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_SubCategory_SubCategoryId1",
                table: "products",
                column: "SubCategoryId1",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingBasketItems_products_ProductId1",
                table: "shoppingBasketItems",
                column: "ProductId1",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingBaskets_clients_ClientId",
                table: "shoppingBaskets",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_categories_CategoryId1",
                table: "SubCategory",
                column: "CategoryId1",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
