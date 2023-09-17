using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication19.Model;

namespace WebApplication19.Controller
{
    public class SmartShopContext: DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Coupon> coupons { get; set; }
        public DbSet<ShoppingBasket> shoppingBaskets { get; set; }
        public DbSet<ShoppingBasketItem> shoppingBasketItems { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Size> sizes { get; set; }
        public DbSet<ProductColor> productsColor { get; set; }
        public DbSet<ProductSize> productsSize { get; set; }    
        public DbSet<ShoppingBasketHistory> ShoppingBasketHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            

            modelBuilder.Entity<ShoppingBasketItem>()
                .HasOne(item => item.Product)
                .WithMany(product => product.ShoppingBasketItems)
                .HasForeignKey(item => item.ProductId);

            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.Product)
                .WithMany(product => product.Comments)
                .HasForeignKey(comment => comment.ProductId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Comments)
                .WithOne(comment => comment.Client)
                .HasForeignKey(comment => comment.ClientId);

           
           
            modelBuilder.Entity<ShoppingBasket>()
                .HasMany(basket => basket.shoppingBasketItems)
                .WithOne(item => item.ShoppingBasket)
                .HasForeignKey(item => item.ShoppingBasketId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL8005.site4now.net;Initial Catalog=db_a9dcfa_smartshop;User Id=db_a9dcfa_smartshop_admin;Password=MT6102002");
            //"Data Source=SQL8005.site4now.net;Initial Catalog=db_a9dcfa_smartshop;User Id=db_a9dcfa_smartshop_admin;Password=YOUR_DB_PASSWORD

            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-9VU2GN9;Database=SmartShopDB;trusted_connection=true;");
        }

    }
}
