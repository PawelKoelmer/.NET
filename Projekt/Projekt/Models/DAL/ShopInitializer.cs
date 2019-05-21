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
    }
}  