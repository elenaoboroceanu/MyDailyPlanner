using System.Linq;
using System.Web.Mvc;

using DailyPlanner.DomainClasses;
using DailyPlanner.Repository.Interfaces;

namespace DailyPlanner.Controllers
{
    [Authorize]
    public class PillController : Controller
    {
        private readonly IPillRepository _pillRepository;


        public PillController(IPillRepository pillRepository)
        {
            this._pillRepository = pillRepository;
        }

        // GET: Pill
        public ActionResult Index()
        {
            return View(_pillRepository.All.ToList());
        }

        // GET: Pill/Details/5
        public ActionResult Details(int id)
        {
            return View(_pillRepository.Find(id));
        }

        // GET: Pill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Quantity,UnitOfMeasure,Days,Comment")] Pill pill)
        {
            if (ModelState.IsValid)
            {
                _pillRepository.InsertOrUpdate(pill);
                _pillRepository.Save();
                return RedirectToAction("Index");
            }

            return View(pill);
        }

        // GET: Pill/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_pillRepository.Find(id));
        }

        // POST: Pill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Quantity,UnitOfMeasure,Days,Comment")] Pill pill)
        {
            if (ModelState.IsValid)
            {
                _pillRepository.InsertOrUpdate(pill);
                _pillRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Pill/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_pillRepository.Find(id));
        }

        // POST: Pill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _pillRepository.Delete(id);
            _pillRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pillRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
