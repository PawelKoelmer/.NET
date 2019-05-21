using Projekt.Models;
using Projekt.Models.DAL;
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
            var ctx = new ShopContext();
            ctx.Database.Initialize(true);
            return View();
        }
    }
}