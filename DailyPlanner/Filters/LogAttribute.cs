using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DailyPlanner.Models;
using DailyPlanner.Models.DbContexts;

using Microsoft.AspNet.Identity;

namespace DailyPlanner.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public ApplicationDbContext Context { get; set; }

        public string Description { get; set; }

        public LogAttribute(string description)
        {
            Description = description;            
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var userId = filterContext.HttpContext.User.Identity.GetUserId();
            var user = Context.Users.Find(userId);

            Context.Logs.Add(new LogAction(
                user,
                filterContext.ActionDescriptor.ActionName,
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Description
            ));

            Context.SaveChanges();


            base.OnActionExecuted(filterContext);
        }
    }
}