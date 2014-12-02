using System;
using System.Linq;
using System.Web.Mvc;

using DailyPlanner.DomainClasses;
using DailyPlanner.Repository.Interfaces;

namespace DailyPlanner.Controllers
{
    public class DailyTaskController : Controller
    {
        private readonly IDailyTaskRepository _dailyTaskRepository;
        private readonly IActivityRepository _activityRepository;


        public DailyTaskController(IDailyTaskRepository dailyTaskRepository, IActivityRepository activityRepository)
        {
            _dailyTaskRepository = dailyTaskRepository;
            _activityRepository = activityRepository;
        }
        //// GET: DailyTask
        public ActionResult Index()
        {
            return SearchByDate();
        }

        // GET: DailyTask by date

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SearchByDate(DateTime? date)
        {
            if (!date.HasValue || date.Value == DateTime.MinValue)
            {
                return HttpNotFound();
            }
            //, new {@class="btn btn-primary btn-lg"})
            var dailyTasksByDate = _dailyTaskRepository
                .GetTasksIncludingActivitiesByDate(date.Value.Date)
                .ToList();
            ViewBag.Date = date.Value.ToString("yyyy-MM-dd");
            return View("Index", dailyTasksByDate);
        }

        [HttpGet]
        public ActionResult SearchByDate()
        {
            var dailyTasksByDate = _dailyTaskRepository
              .GetTasksIncludingActivitiesByDate(DateTime.Now.Date)
              .ToList();
            ViewBag.Date = DateTime.Now.ToString("yyyy-MM-dd");
            return View("Index", dailyTasksByDate);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetTotalTimeByDate(string date)
        {
            DateTime dateTime = Convert.ToDateTime(date).Date;
            var sumByDate = _dailyTaskRepository.All
                .Where(p => p.Date == dateTime)
                .Sum(p => p.Duration);

            return Json(sumByDate);

            //return date;
        }

        // GET: DailyTask/Details/5
        public ActionResult Details(int id)
        {
            DailyTask dailyTask = _dailyTaskRepository.Find(id);
            if (dailyTask == null)
            {
                return HttpNotFound();
            }
            return View(dailyTask);
        }

        // GET: DailyTask/Create
        public ActionResult Create()
        {
            ViewBag.PossibleActivities = _activityRepository.All;
            return View();
        }

        // POST: DailyTask/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DailyTask dailyTask)
        {
            if (ModelState.IsValid)
            {
                _dailyTaskRepository.InsertOrUpdate(dailyTask);
                _dailyTaskRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleActivities = _activityRepository.All;
            return View();
        }

        // GET: DailyTask/Edit/5
        public ActionResult Edit(int id)
        {

            DailyTask dailyTask = _dailyTaskRepository.Find(id);
            if (dailyTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.PossibleActivities = _activityRepository.All;

            return View(dailyTask);
        }

        // POST: DailyTask/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DailyTask dailyTask)
        {
            if (ModelState.IsValid)
            {
                _dailyTaskRepository.InsertOrUpdate(dailyTask);
                _dailyTaskRepository.Save();
                return RedirectToAction("SearchByDate", new { date = dailyTask.Date });
            }
            // If the model is invalid, we must remain on the same page
            ViewBag.PossibleActivities = _activityRepository.All;
            return View();
        }

        // GET: DailyTask/Delete/5
        public ActionResult Delete(int id)
        {
            DailyTask dailyTask = _dailyTaskRepository.Find(id);
            if (dailyTask == null)
            {
                return HttpNotFound();
            }
            return View(dailyTask);
        }

        // POST: DailyTask/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _dailyTaskRepository.Delete(id);
            _dailyTaskRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dailyTaskRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult IsNumberEven(int evenNumber)
        {
            return Json(evenNumber % 2 == 0, JsonRequestBehavior.AllowGet);
        }
    }
}