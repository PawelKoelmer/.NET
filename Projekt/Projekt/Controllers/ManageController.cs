using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Projekt.App_Start;
using Projekt.Models;
using Projekt.Models.DAL;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class ManageController : Controller
    {
        private ShopContext db = new ShopContext();
  
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
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

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            var name = User.Identity.Name;
            

            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            if (User.IsInRole("Admin"))
                ViewBag.UserIsAdmin = true;
            else
                ViewBag.UserIsAdmin = false;

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }

            var model = new ManageCredentialViewModel
            {
                Message = message,
                UserData = user.UserData
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "UserData")]UserData UserData)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserData = UserData;
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("password-error", error);
            }
        }
        public ActionResult OrderList()
        {
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = isAdmin;

            IEnumerable<Order> userOrders;

            // Dla administratora zwracamy wszystkie zamowienia
            if (isAdmin)
            {
                userOrders = db.Orders.Include("OrderPosition").OrderByDescending(o => o.addTime).ToArray();
            }
            else
            {
                var userId = User.Identity.GetUserId();
                userOrders = db.Orders.Where(o => o.UserId == userId).Include("OrderPosition").OrderByDescending(o => o.addTime).ToArray();
            }
            return View(userOrders);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ShipmentStatus ChangeOrderStatus(Order order)
        {
            Order orderToChange = db.Orders.Find(order.OrderId);
            orderToChange.shipmentStatus = order.shipmentStatus;
            db.SaveChanges();

            //if (zamowienieDoModyfikacji.shipmentStatus == shipmentStatus.Realized)
            //{
            //    this.mailService.WyslanieZamowienieZrealizowaneEmail(zamowienieDoModyfikacji);
            //}

            return order.shipmentStatus;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AddItem(int? itemId, bool? potwierdzenie)
        {
            Item item;
            if (itemId.HasValue)
            {
                ViewBag.EditMode = true;
                item = db.Items.Find(itemId);
            }
            else
            {
                ViewBag.EditMode = false;
                item = new Item();
            }

            var result = new EditItemViewModel();
            result.categories = db.ItemCategories.ToList();
            result.Item = item;
            result.Potwierdzenie = potwierdzenie;

            return View(result);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddItem(EditItemViewModel model)
        {
            if (model.Item.ItemId > 0)
            {
                // modyfikacja kursu
                db.Entry(model.Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddItem", new { potwierdzenie = true });
            }
            else
            {
                // Sprawdzenie, czy użytkownik wybrał plik
               
                    if (ModelState.IsValid)
                    {
                        model.Item.addTime = DateTime.Now;

                        db.Entry(model.Item).State = EntityState.Added;
                        db.SaveChanges();
                        return RedirectToAction("AddItem", new { potwierdzenie = true });
                    }
                    else
                    {
                        var kategorie = db.ItemCategories.ToList();
                        model.categories = kategorie;
                        return View(model);
                    }
            }

        }
    }
}