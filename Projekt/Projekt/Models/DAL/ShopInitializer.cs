using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Projekt.Models.DAL
{
    public class ShopInitializer : DropCreateDatabaseIfModelChanges<ItemsContext>
    {
        protected override void Seed(ItemsContext context)
        {
            SeedShopData(context);
            base.Seed(context);
        }

        private void SeedShopData(ItemsContext context)
        {
            context.SaveChanges();
        }
    }
}