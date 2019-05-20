using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekt.Models.DAL
{
    public class ItemsContext : DbContext
    {
        public ItemsContext() : base("Baza")
        {

        }
        static ItemsContext()
        {
            Database.SetInitializer<ItemsContext>(new ShopInitializer());
        }
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