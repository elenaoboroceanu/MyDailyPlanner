using System.Web.Mvc;

using DailyPlanner.Models;
using DailyPlanner.Models.Interfaces;
using DailyPlanner.Models.Repositories;

namespace DailyPlanner.Controllers
{
    public class DailyTaskController : Controller
    {
       private readonly IDailyTaskRepository dailyTaskRepository;
       private readonly IActivityRepository activityRepository;

		// If you are using Dependency Injection, you can delete the following constructor
       public DailyTaskController()
           : this(new DailyTaskRepository(), new ActivityRepository())
        {
        }

       public DailyTaskController(IDailyTaskRepository dailyTaskRepository, IActivityRepository activityRepository)
        {
            this.dailyTaskRepository = dailyTaskRepository;
           this.activityRepository = activityRepository;
        }
        // GET: DailyTask
        public ActionResult Index()
        {
            return View(dailyTaskRepository.AllIncluding(dailyTask=>dailyTask.Activity));
        }

        // GET: DailyTask/Details/5
        public ActionResult Details(int id)
        {
            DailyTask dailyTask = dailyTaskRepository.Find(id);
            if (dailyTask == null)
            {
                return HttpNotFound();
            }
            return View(dailyTask);
        }

        // GET: DailyTask/Create
        public ActionResult Create()
        {
            ViewBag.PossibleActivities = activityRepository.All;
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
                dailyTaskRepository.InsertOrUpdate(dailyTask);
                dailyTaskRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.PossibleActivities = activityRepository.All;
                return View();
            }            
        }

        // GET: DailyTask/Edit/5
        public ActionResult Edit(int id)
        {
          
            DailyTask dailyTask = dailyTaskRepository.Find(id);
            if (dailyTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.PossibleActivities = dailyTaskRepository.All;
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
                dailyTaskRepository.InsertOrUpdate(dailyTask);
                dailyTaskRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleActivities = activityRepository.All;
            return View();
        }

        // GET: DailyTask/Delete/5
        public ActionResult Delete(int id)
        {
            DailyTask dailyTask = dailyTaskRepository.Find(id);
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
            dailyTaskRepository.Delete(id);
            dailyTaskRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dailyTaskRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}