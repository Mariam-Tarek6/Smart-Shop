﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication19.Controller;

namespace WebApplication19.Migrations
{
    [DbContext(typeof(SmartShopContext))]
    [Migration("20230814221411_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication19.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("WebApplication19.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("WebApplication19.Model.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("CommentDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CommentRate")
                        .HasColumnType("int");

                    b.Property<string>("CommentTitle")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId1")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductId1")
                        .IsUnique()
                        .HasFilter("[ProductId1] IS NOT NULL");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("WebApplication19.Model.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("coupons");
                });

            modelBuilder.Entity("WebApplication19.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double?>("PriceAfterDiscount")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("SubCategoryId1")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("SubCategoryId1")
                        .IsUnique()
                        .HasFilter("[SubCategoryId1] IS NOT NULL");

                    b.ToTable("products");
                });

            modelBuilder.Entity("WebApplication19.Model.ShoppingBasket", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPriceAfterDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BasketId");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("shoppingBaskets");
                });

            modelBuilder.Entity("WebApplication19.Model.ShoppingBasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId1")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingBasketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductId1")
                        .IsUnique()
                        .HasFilter("[ProductId1] IS NOT NULL");

                    b.HasIndex("ShoppingBasketId");

                    b.ToTable("shoppingBasketItems");
                });

            modelBuilder.Entity("WebApplication19.Model.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CategoryId1")
                        .IsUnique()
                        .HasFilter("[CategoryId1] IS NOT NULL");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("WebApplication19.Model.Category", b =>
                {
                    b.HasOne("WebApplication19.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApplication19.Model.Comment", b =>
                {
                    b.HasOne("WebApplication19.Model.Client", "Client")
                        .WithMany("Comments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication19.Model.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication19.Model.Product", null)
                        .WithOne("Comment")
                        .HasForeignKey("WebApplication19.Model.Comment", "ProductId1");

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApplication19.Model.Product", b =>
                {
                    b.HasOne("WebApplication19.Model.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("WebApplication19.Model.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication19.Model.SubCategory", null)
                        .WithOne("Product")
                        .HasForeignKey("WebApplication19.Model.Product", "SubCategoryId1");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("WebApplication19.Model.ShoppingBasket", b =>
                {
                    b.HasOne("WebApplication19.Model.Client", null)
                        .WithOne("ShoppingBasketDetail")
                        .HasForeignKey("WebApplication19.Model.ShoppingBasket", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication19.Model.ShoppingBasketItem", b =>
                {
                    b.HasOne("WebApplication19.Model.Product", "ProductDetail")
                        .WithMany("ShoppingBasketItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication19.Model.Product", null)
                        .WithOne("ShoppingBasket")
                        .HasForeignKey("WebApplication19.Model.ShoppingBasketItem", "ProductId1");

                    b.HasOne("WebApplication19.Model.ShoppingBasket", "ShoppingBasketDetail")
                        .WithMany("ShoppingBasketItems")
                        .HasForeignKey("ShoppingBasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDetail");

                    b.Navigation("ShoppingBasketDetail");
                });

            modelBuilder.Entity("WebApplication19.Model.SubCategory", b =>
                {
                    b.HasOne("WebApplication19.Model.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication19.Model.Category", null)
                        .WithOne("SubCategory")
                        .HasForeignKey("WebApplication19.Model.SubCategory", "CategoryId1");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApplication19.Model.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("WebApplication19.Model.Client", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ShoppingBasketDetail");
                });

            modelBuilder.Entity("WebApplication19.Model.Product", b =>
                {
                    b.Navigation("Comment");

                    b.Navigation("Comments");

                    b.Navigation("ShoppingBasket");

                    b.Navigation("ShoppingBasketItems");
                });

            modelBuilder.Entity("WebApplication19.Model.ShoppingBasket", b =>
                {
                    b.Navigation("ShoppingBasketItems");
                });

            modelBuilder.Entity("WebApplication19.Model.SubCategory", b =>
                {
                    b.Navigation("Product");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
