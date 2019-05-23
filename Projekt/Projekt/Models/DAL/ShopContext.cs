using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekt.Models.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("Shop")
        {

        }
 
        static ShopContext()
        {
            Database.SetInitializer<ShopContext>(new ShopInitializer());
        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }
        public DbSet<ItemCategory> itemCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order>  Orders { get; set; }
        public DbSet<OrderPostition> OrderPositions { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}