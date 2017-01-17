using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace URLRedirect.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Basic CRUD .NET MVC Application";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This application manages data for three different tables, hosted in mySQL: City, Car, Fruit";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}
