using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;
using Projekt.Migrations;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using static Projekt.Models.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Projekt.Models.DAL
{
    public class ShopInitializer : MigrateDatabaseToLatestVersion<ShopContext, Configuration>
    {
        public static void SeedItemsData(ShopContext context)
        {
            var Categories = new List<ItemCategory>
            {
            new ItemCategory() {ItemCategoryId=1, ItemCategoryName=  "Słodycze", ItemCategoryDescription="Najlepsze słodycze na rynku" },
            new ItemCategory() {ItemCategoryId=2, ItemCategoryName = "Kawy świata", ItemCategoryDescription = "Najlepsze kawy na rynku"},
            new ItemCategory() {ItemCategoryId=3, ItemCategoryName = "Herbaty świata", ItemCategoryDescription = "Najlepsze herbaty na rynku" },
            new ItemCategory() {ItemCategoryId=4, ItemCategoryName = "Przyprawy", ItemCategoryDescription = "Najlepsze przyprawy na rynku" }
            };

            Categories.ForEach(c => context.ItemCategories.AddOrUpdate(c));
            context.SaveChanges();

            var items = new List<Item>
            {
                new Item() {ItemId=1, productName="Czekolada",avaiablity=true,productDescription="Najlepsza czekolada na rynku",productPrice=10, ItemCategoryId=1,addTime = DateTime.Now },
                new Item() {ItemId=2, productName="Krówki", avaiablity=true,productDescription="Najlepsze krówki na rynku",productPrice=5, ItemCategoryId=1,addTime = DateTime.Now },
                new Item() {ItemId=3, productName="Landrynki", avaiablity=false,productDescription="Najlepsze landrynki na rynku",productPrice=7, ItemCategoryId=1, addTime = DateTime.Now},
                new Item() {ItemId=4, productName="Jacobs", avaiablity=false,productDescription="Kawa Jacobs",productPrice=37, ItemCategoryId=2, addTime = DateTime.Now},
                new Item() {ItemId=5, productName="Tchibo", avaiablity=false,productDescription="Kawa Tchibo",productPrice=25, ItemCategoryId=2, addTime = DateTime.Now},
                new Item() {ItemId=6, productName="Nescafe", avaiablity=false,productDescription="Kawa Nescafe",productPrice=29, ItemCategoryId=2, addTime = DateTime.Now},

            };
            items.ForEach(i => context.Items.AddOrUpdate(i));
            context.SaveChanges();
        }
        public static void SeedUsers(ShopContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string name = "s15988@pjatk.pl";
            const string password = "password";
            const string roleName = "Admin";

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, UserData = new UserData() };
                var result = userManager.Create(user, password);
            }

            // utworzenie roli Admin jeśli nie istnieje 
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            // dodanie uzytkownika do roli Admin jesli juz nie jest w roli
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }

    }
}  