using System.Linq;
using System.Web.Mvc;

using DailyPlanner.DomainClasses;
using DailyPlanner.Repository.Interfaces;

namespace DailyPlanner.Controllers
{
    [Authorize]
    public class MealController : Controller
    {
        private readonly IMealRepository _mealRepository;

        public MealController(IMealRepository mealRepository)
        {
            this._mealRepository = mealRepository;
        }

        // GET: Meal
        public ActionResult Index()
        {
            return View(_mealRepository.All.ToList());
        }

        // GET: Meal/Details/5
        public ActionResult Details(int id)
        {
            return View(_mealRepository.Find(id));
        }

        // GET: Meal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Recipie,Comment")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                _mealRepository.InsertOrUpdate(meal);
                _mealRepository.Save();
                return RedirectToAction("Index");
            }

            return View(meal);
        }

        // GET: Meal/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_mealRepository.Find(id));
        }

        // POST: Meal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Recipie,Comment")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                _mealRepository.InsertOrUpdate(meal);
                _mealRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Meal/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_mealRepository.Find(id));
        }

        // POST: Meal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _mealRepository.Delete(id);
            _mealRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _mealRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }

   
}
