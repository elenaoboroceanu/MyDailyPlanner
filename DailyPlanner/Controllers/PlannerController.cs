using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyPlanner.Controllers
{
    public class PlannerController : Controller
    {
        // GET: Planner
        public ActionResult Plan()
        {
            return View();
        }
    }
}