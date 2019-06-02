using NLog;
using Projekt.Models.DAL;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Projekt.Controllers
{
    public class ItemsController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ShopContext db;
        ShopItemsModel vm;
     

        public ItemsController()
        {
            this.db = new ShopContext();
            this.vm  = new ShopItemsModel();
        }
        //GET: Items
        public ActionResult Index()
        {
            logger.Info("Strona Sklepu");
            var categories = db.ItemCategories.ToList();
            var items = db.Items.ToList();
            vm.ItemList = items;
            vm.ItemsCategories = categories;
           
            return View(vm);
        }

        public ActionResult List(string categoryName, string searchQuery=null)
        {
            
            var category = db.ItemCategories.Include("Items").Where(c => c.ItemCategoryName.ToUpper() == categoryName.ToUpper()).Single();

            var items = category.Items.Where(a => (searchQuery == null ||
                                            a.productName.ToLower().Contains(searchQuery.ToLower())));

            vm.ItemList = items;
            return View(vm);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult categoryMenu()
        {
            var categories = db.ItemCategories.ToList();
            vm.ItemsCategories = categories;
            return PartialView("_categoryList", vm);
        }
        public ActionResult ItemSuggestions(string term)
        {
            var kursy = db.Items.Where(a =>  a.productName.ToLower().Contains(term.ToLower()))
                        .Take(5).Select(a => new { label = a.productName });

            return Json(kursy, JsonRequestBehavior.AllowGet);
        }
    }
}