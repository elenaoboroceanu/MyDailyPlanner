using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyPlanner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "My daily planner";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Do not hesitate to contact us!";

            return View();
        }
    }
}