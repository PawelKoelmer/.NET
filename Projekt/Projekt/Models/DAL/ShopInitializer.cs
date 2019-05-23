using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;
using Projekt.Migrations;
using System.Data.Entity.Migrations;

namespace Projekt.Models.DAL
{
    public class ShopInitializer : MigrateDatabaseToLatestVersion<ShopContext, Configuration>
    {
       

        public static void SeedRolesData(ShopContext context)
        {
            var Roles = new List<Role>
            {
                new Role() { roleName="Admin"},
                new Role() { roleName="moderator"},
                new Role() { roleName="default"},
                new Role() { roleName="premium"}
            };
            Roles.ForEach(r => context.Roles.AddOrUpdate(r));
            context.SaveChanges();
        }
        public static void SeedItemsData(ShopContext context)
        {
            var items = new List<Item>
            {
                new Item() { productName="Czekolada",inStock=50, avaiablity=true,productDescription="Najlepsza czekolada na rynku",productPrice=10,productScore=2,},
                
            };
            items.ForEach(i => context.Items.AddOrUpdate(i));
            context.SaveChanges();
        }
        public static void SeedItemsCategories(ShopContext context)
        {
            var Categories = new List<ItemCategory>
            {
            new ItemCategory() { ItemCategoryName="Słodycze", ItemCategoryDescription="Najlepsze słodycze na rynku" },
            new ItemCategory() { ItemCategoryName = "Kawy świata", ItemCategoryDescription = "Najlepsze kawy na rynku"},
            new ItemCategory() { ItemCategoryName = "Herbaty świata", ItemCategoryDescription = "Najlepsze herbaty na rynku" },
            new ItemCategory() { ItemCategoryName = "Przyprawy", ItemCategoryDescription = "Najlepsze przyprawy na rynku" }
            };
            Categories.ForEach(c => context.itemCategories.AddOrUpdate(c));
            context.SaveChanges();
        }
    }
}  