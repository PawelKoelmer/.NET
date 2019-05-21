using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;

namespace Projekt.Models.DAL
{
    public class ShopInitializer : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            SeedRolesData(context);
            SeedItemsData(context);
            base.Seed(context);
        }
        private void SeedRolesData(ShopContext context)
        {
            var Roles = new List<Role>
            {
                new Role() { roleName="Admin"},
                new Role() { roleName="moderator"},
                new Role() { roleName="default"},
                new Role() { roleName="premium"}
            };
            Roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();
        }
        private void SeedItemsData(ShopContext context)
        {
            var items = new List<Item>
            {
                new Item() { productName="Czekolada",inStock=50, avaiablity=true,productDescription="Najlepsza czekolada na rynku",productPrice=10,productScore=2,},
                
            };
            items.ForEach(i => context.Items.Add(i));
            context.SaveChanges();
        }
    }
}  