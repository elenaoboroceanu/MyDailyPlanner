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
    public class ActivityController : Controller
    {
        private readonly IActivityTypeRepository activitytypeRepository;
        private readonly IActivityRepository activityRepository;
        private readonly IToyRepository toyRepository;
        private readonly IFlashcardRepository flashcardRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public ActivityController()
            : this(new ActivityTypeRepository(), new ActivityRepository(), new ToyRepository(), new FlashcardRepository())
        {
        }

        public ActivityController(IActivityTypeRepository activitytypeRepository, IActivityRepository activityRepository,
            IToyRepository toyRepository, IFlashcardRepository flashcardRepository)
        {
            this.activitytypeRepository = activitytypeRepository;
            this.activityRepository = activityRepository;
            this.flashcardRepository = flashcardRepository;
            this.toyRepository = toyRepository;
        }

        //
        // GET: /Activity/

        public ViewResult Index()
        {
            return View(activityRepository.AllIncluding(activity => activity.ActivityType, activity => activity.Toys, activity => activity.Flashcards));
        }

        //
        // GET: /Activity/Details/5

        public ViewResult Details(int id)
        {
            return View(activityRepository.Find(id));
        }

        //
        // GET: /Activity/Create

        public ActionResult Create()
        {
            ChargeViewBagForCreate();
            return View();
        }

        //
        // POST: /Activity/Create

        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                activityRepository.InsertOrUpdate(activity);
                activityRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ChargeViewBagForEdit(activity);
                return View();
            }
        }

        //
        // GET: /Activity/Edit/5

        public ActionResult Edit(int id)
        {
            var activity = activityRepository.Find(id);
            ChargeViewBagForEdit(activity);
            return View(activity);
        }

        //
        // POST: /Activity/Edit/5

        [HttpPost]
        public ActionResult Edit(Activity activity)
        {
            if (ModelState.IsValid)
            {
                activityRepository.InsertOrUpdate(activity);
                activityRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ChargeViewBagForEdit(activity);
                return View(activity);
            }
        }

        //
        // GET: /Activity/Delete/5

        public ActionResult Delete(int id)
        {
            return View(activityRepository.Find(id));
        }

        //
        // POST: /Activity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            activityRepository.Delete(id);
            activityRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                activitytypeRepository.Dispose();
                activityRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ChargeViewBagForEdit(Activity activity)
        {
            ViewBag.PossibleActivityTypes = activitytypeRepository.All.ToList();
            ViewBag.PossibleToys = toyRepository.All.ToList();
            var assignedFlashcards = activity.Flashcards;
            var notAssignedFlashcards = flashcardRepository.All.Where(flashcard => !flashcard.Activities.Any());

            ViewBag.PossibleFlashcards = assignedFlashcards.Union(notAssignedFlashcards).ToList();
        }

        private void ChargeViewBagForCreate()
        {
            ViewBag.PossibleActivityTypes = activitytypeRepository.All.ToList();
            ViewBag.PossibleToys = toyRepository.All.ToList();
            ViewBag.PossibleFlashcards = flashcardRepository.All.Where(flashcard => flashcard.Activities.Count() == 0).ToList();
        }


    }
}

