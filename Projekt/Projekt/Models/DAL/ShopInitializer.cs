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
                new Role() { RoleId=1, roleName="Admin"},
                new Role() { RoleId=2,roleName="moderator"},
                new Role() { RoleId=3,roleName="default"},
                new Role() { RoleId=4,roleName="premium"}
            };
            Roles.ForEach(r => context.Roles.AddOrUpdate(r));
            context.SaveChanges();
        }
        public static void SeedItemsData(ShopContext context)
        {
            var items = new List<Item>
            {
                new Item() {ItemId=1, productName="Czekolada",inStock=50, avaiablity=true,productDescription="Najlepsza czekolada na rynku",productPrice=10,productScore=2, CategoryId=1 },
                
            };
            items.ForEach(i => context.Items.AddOrUpdate(i));
            context.SaveChanges();
        }
        public static void SeedItemsCategories(ShopContext context)
        {
            var Categories = new List<ItemCategory>
            {
            new ItemCategory() {ItemCategoryId=1, ItemCategoryName=  "Słodycze", ItemCategoryDescription="Najlepsze słodycze na rynku" },
            new ItemCategory() {ItemCategoryId=2, ItemCategoryName = "Kawy świata", ItemCategoryDescription = "Najlepsze kawy na rynku"},
            new ItemCategory() {ItemCategoryId=3, ItemCategoryName = "Herbaty świata", ItemCategoryDescription = "Najlepsze herbaty na rynku" },
            new ItemCategory() {ItemCategoryId=4, ItemCategoryName = "Przyprawy", ItemCategoryDescription = "Najlepsze przyprawy na rynku" }
            };
            Categories.ForEach(c => context.itemCategories.AddOrUpdate(c));
            context.SaveChanges();
        }
    }
}  