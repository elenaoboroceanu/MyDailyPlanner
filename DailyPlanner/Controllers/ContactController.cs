using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DailyPlanner.Controllers
{
    public class ContactController : Controller
    {
        private static List<string> _comments = new List<string>();

        public ActionResult PrivacyPolicy()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddComment(string comment)
        {
            _comments.Add(comment);
            if (Request.IsAjaxRequest())
            {
                  return  Json(comment);             
            }
            ViewBag.Comment = comment; 
            return null;
        }

     
    }
}
