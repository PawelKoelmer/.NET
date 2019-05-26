using Projekt.Infrastructure;
using Projekt.Models.DAL;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class ShopCartController : Controller
    {
        private ISessionMenager sessionMenager { get; set; }
        private ShopContext db;
        private ShopCartManager manager;

        public ShopCartController()
        {
            this.sessionMenager = new SessionMenager();
            this.db = new ShopContext();
            this.manager = new ShopCartManager(sessionMenager,db);
            
        }

        // GET: ShopCart
        public ActionResult Index()
        {
            var shopCartPosition = manager.GetShopCart();
            var price = manager.getShopCartPrice();
            ShopCartViewModel cartVM = new ShopCartViewModel()
            {
                shopCartPosition = shopCartPosition,
                priceOfProducts = price,
            };
            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            manager.addToShopCart(id);
            return RedirectToAction("Index");
        }

        public ActionResult removeFromCart()
        {
            return View();
        }
    }
}