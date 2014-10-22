using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DailyPlanner.Models;
using DailyPlanner.Models.Interfaces;
using DailyPlanner.Models.Repositories;

namespace DailyPlanner.Controllers
{
    [Authorize]
    public class ActivityTypeController : Controller
    {
        private readonly IActivityTypeRepository activitytypeRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public ActivityTypeController()
            : this(new ActivityTypeRepository())
        {
        }

        public ActivityTypeController(IActivityTypeRepository activitytypeRepository)
        {
            this.activitytypeRepository = activitytypeRepository;
        }

        //
        // GET: /ActivityType/

        public ViewResult Index()
        {
            return View(activitytypeRepository.All);
        }

        //
        // GET: /ActivityType/Details/5

        public ViewResult Details(int id)
        {
            return View(activitytypeRepository.Find(id));
        }

        //
        // GET: /ActivityType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ActivityType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActivityType activitytype)
        {
            if (ModelState.IsValid)
            {
                activitytypeRepository.InsertOrUpdate(activitytype);
                activitytypeRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /ActivityType/Edit/5

        public ActionResult Edit(int id)
        {
            return View(activitytypeRepository.Find(id));
        }

        //
        // POST: /ActivityType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ActivityType activitytype)
        {
            if (ModelState.IsValid)
            {
                activitytypeRepository.InsertOrUpdate(activitytype);
                activitytypeRepository.Save();
                return RedirectToAction("Index");
            }
            return View();

        }

        //
        // GET: /ActivityType/Delete/5

        public ActionResult Delete(int id)
        {
            return View(activitytypeRepository.Find(id));
        }

        //
        // POST: /ActivityType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            activitytypeRepository.Delete(id);
            activitytypeRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                activitytypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

