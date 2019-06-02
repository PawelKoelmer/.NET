using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Projekt.App_Start;
using Projekt.Infrastructure;
using Projekt.Models;
using Projekt.Models.DAL;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public int GetQuantityOfItems()
        {
            return manager.getShopCartStock();
        }
        public ActionResult AddToCart(int id)
        {
            manager.addToShopCart(id);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> pay()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var order = new Order
                {
                    buyerName = user.UserData.Name,
                    buyerLastName = user.UserData.LastName,
                    city = user.UserData.City,
                    street = user.UserData.Street,
                    zipCode = user.UserData.ZipCode,
                    telNumber = user.UserData.TelNumber,
                    buyerEmail = user.UserData.Email,

                };
                return View(order);
            }
            else
                return RedirectToAction("Login", "Account", new {returnurl = Url.Action("pay","ShopCart")});
        }

        [HttpPost]
        public async Task<ActionResult> pay(Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                // pobieramy id uzytkownika aktualnie zalogowanego
                var userId = User.Identity.GetUserId();

                // utworzenie obiektu zamowienia na podstawie tego co mamy w koszyku
                var newOrder = manager.CreateOrder(orderDetails, userId);

                // szczegóły użytkownika - aktualizacja danych 
                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);

                // opróżnimy nasz koszyk zakupów
                manager.emptyCart();

               // maileService.WyslaniePotwierdzenieZamowieniaEmail(newOrder);

                return RedirectToAction("OrderConfirm");
            }
            else
                return View(orderDetails);
        }
        public ActionResult OrderConfirm()
        {
           
            return View();
        }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult removeFromCart(int ItemId)
        {
            int positionsQuantity = manager.deleteFromShopCart(ItemId);
            int shopCartPositionsQuantity = manager.getShopCartStock();
            decimal shopCartPrice = manager.getShopCartPrice();

            var result = new DeleteFromShopCartViewModel
            {
                DeletePositionId = ItemId,
                shopCartDeletingPositionQuantity = positionsQuantity,
                shopCartPrice = shopCartPrice,
                shopCartPositionsQuantity = shopCartPositionsQuantity,
            };
            return Json(result);
        }
    }
}