using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

using DailyPlanner.DomainClasses;
using DailyPlanner.Repository.Interfaces;

namespace DailyPlanner.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private readonly IActivityTypeRepository _activitytypeRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IToyRepository _toyRepository;
        private readonly IFlashcardRepository _flashcardRepository;

        public ActivityController(IActivityTypeRepository activitytypeRepository, IActivityRepository activityRepository,
            IToyRepository toyRepository, IFlashcardRepository flashcardRepository)
        {
            this._activitytypeRepository = activitytypeRepository;
            this._activityRepository = activityRepository;
            this._flashcardRepository = flashcardRepository;
            this._toyRepository = toyRepository;
        }

        //
        // GET: /Activity/

        public ViewResult Index()
        {
            return View(_activityRepository.AllActivitiesIncludingToysAndFlashcards());
        }



        //
        // GET: /Activity/Details/5

        public ViewResult Details(int id)
        {
            return View(_activityRepository.Find(id));
        }

        //
        // GET: /Activity/Create

        public ActionResult Create()
        {
            FillViewBagForCreate();
            return View();
        }

        //
        // POST: /Activity/Create

        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                _activityRepository.InsertOrUpdate(activity);
                _activityRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                FillViewBagForEdit(activity);
                return View();
            }
        }

        //
        // GET: /Activity/Edit/5

        public ActionResult Edit(int id)
        {
            var activity =
                _activityRepository.AllIncluding(p => p.Toys)
                    .Include(p => p.Flashcards).First(p => p.Id == id);
            FillViewBagForEdit(activity);
            return View(activity);
        }

        //
        // POST: /Activity/Edit/5

        [HttpPost]
        public ActionResult Edit(Activity modifiedActivity, string[] selectedToys, string[] selectedFlashcards)
        {
            if (ModelState.IsValid)
            {
                Activity dbActivity = _activityRepository.AllIncluding(p => p.Toys)
                        .Include(p => p.Flashcards)
                        .FirstOrDefault(p => p.Id == modifiedActivity.Id);
                modifiedActivity.ActivityType = _activitytypeRepository.Find(modifiedActivity.ActivityTypeId);

                if (dbActivity == null)
                {
                    dbActivity = new Activity();
                }
                // Update the dbActivity to include the changes from the UI
                dbActivity.Name = modifiedActivity.Name;
                dbActivity.Description = modifiedActivity.Description;
                dbActivity.ActivityTypeId = modifiedActivity.ActivityTypeId;
                dbActivity.ActivityType = modifiedActivity.ActivityType;

                UpdateActivityToysAndFlashcards(dbActivity, selectedToys, selectedFlashcards);
                _activityRepository.InsertOrUpdate(dbActivity);
                _activityRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                FillViewBagForEdit(modifiedActivity);
                return View(modifiedActivity);
            }
        }

        private void UpdateActivityToysAndFlashcards(Activity activity, string[] selectedToys, string[] selectedFlashcards)
        {
            if (selectedToys == null)
            {
                selectedToys = new string[] { };
            }
            if (selectedFlashcards == null)
            {
                selectedFlashcards = new string[] { };
            }
            //activity.Toys = new List<Toy>();
            //activity.Flashcards = new List<Flashcard>();
            AddToysToActivity(activity, selectedToys);
            AddFlashcardsToActivity(activity, selectedFlashcards);
        }

        private void AddToysToActivity(Activity activity, string[] selectedToys)
        {
            var selectedToysHs = new HashSet<string>(selectedToys);
            var activityToys = new HashSet<int>(activity.Toys.Select(c => c.Id));
            foreach (var toy in _toyRepository.All)
            {
                if (selectedToysHs.Contains(toy.Id.ToString()))
                {
                    if (!activityToys.Contains(toy.Id))
                    {
                        activity.Toys.Add(toy);
                    }
                }
                else
                {
                    if (activityToys.Contains(toy.Id))
                    {
                        activity.Toys.Remove(toy);
                    }
                }
            }
        }

        private void AddFlashcardsToActivity(Activity activity, string[] selectedFlashcards)
        {
            var selectedFlashcardsHs = new HashSet<string>(selectedFlashcards);
            var activityFlashcards = new HashSet<int>(activity.Flashcards.Select(toy => toy.Id));

            foreach (var flashcard in _flashcardRepository.All)
            {
                if (selectedFlashcardsHs.Contains(flashcard.Id.ToString()))
                {
                    if (!activityFlashcards.Contains(flashcard.Id))
                    {
                        activity.Flashcards.Add(flashcard);
                    }
                }
                else
                {
                    if (activityFlashcards.Contains(flashcard.Id))
                    {
                        activity.Flashcards.Remove(flashcard);
                    }
                }
            }
        }


        //
        // GET: /Activity/Delete/5

        public ActionResult Delete(int id)
        {
            return View(_activityRepository.Find(id));
        }

        //
        // POST: /Activity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _activityRepository.Delete(id);
            _activityRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _activitytypeRepository.Dispose();
                _activityRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillViewBagForEdit(Activity activity)
        {
            ViewBag.PossibleActivityTypes = _activitytypeRepository.All.ToList();
            ViewBag.PossibleToys = _toyRepository.All.ToList();
            var assignedFlashcards = activity.Flashcards;
            var notAssignedFlashcards = _flashcardRepository.All.Where(flashcard => !flashcard.Activities.Any());

            //ViewBag.PossibleFlashcards = assignedFlashcards.Union(notAssignedFlashcards).ToList();
            ViewBag.PossibleFlashcards = _flashcardRepository.All.ToList();
        }

        private void FillViewBagForCreate()
        {
            ViewBag.PossibleActivityTypes = _activitytypeRepository.All.ToList();
            ViewBag.PossibleToys = _toyRepository.All.ToList();
            ViewBag.PossibleFlashcards = _flashcardRepository.All.Where(flashcard => flashcard.Activities.Count() == 0).ToList();
        }


    }
}

