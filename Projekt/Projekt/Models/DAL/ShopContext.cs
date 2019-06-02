using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static Projekt.Models.IdentityModels;

namespace Projekt.Models.DAL
{
    public class ShopContext : IdentityDbContext<ApplicationUser>
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
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order>  Orders { get; set; }
        public DbSet<OrderPostition> OrderPositions { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}