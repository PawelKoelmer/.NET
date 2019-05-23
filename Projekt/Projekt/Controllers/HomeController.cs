using Projekt.Models;
using Projekt.Models.DAL;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult defaultPages(string nazwa)
        {
            return View(nazwa);
        }
    }
}