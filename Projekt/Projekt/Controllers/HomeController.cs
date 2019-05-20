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
        private ItemsContext db = new ItemsContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}