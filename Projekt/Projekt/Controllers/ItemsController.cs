using Projekt.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class ItemsController : Controller
    {
        private ShopContext db = new ShopContext();

        
        public ActionResult List(string categoryName)
        {
            var category = db.itemCategories.Include("Items").Where(k => k.ItemCategoryName.ToUpper() == categoryName.ToUpper()).Single();
            var itemsList = category.Items.ToList();
            return View(itemsList);
        }

        [ChildActionOnly]
        public ActionResult categoryMenu()
        {
            var categories = db.itemCategories.ToList();
            return PartialView("_categoryMenu",categories);
        }
    }
}