namespace Projekt.Migrations
{
    using Projekt.Models.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Projekt.Models.DAL.ShopContext";
        }

        protected override void Seed(Projekt.Models.DAL.ShopContext context)
        {
            ShopInitializer.SeedItemsCategories(context);
            ShopInitializer.SeedRolesData(context);
            ShopInitializer.SeedItemsData(context);
        }
    }
}
