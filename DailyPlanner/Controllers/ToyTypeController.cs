using System.Web.Mvc;

using DailyPlanner.DomainClasses;
using DailyPlanner.Models;
using DailyPlanner.Repository.Interfaces;

namespace DailyPlanner.Controllers
{   
    [Authorize]
    public class ToyTypeController : Controller
    {
		private readonly IToyTypeRepository toyTypeRepository;
		
        public ToyTypeController(IToyTypeRepository toyTypeRepository)
        {
			this.toyTypeRepository = toyTypeRepository;
        }

        //
        // GET: /ToyType/

        public ViewResult Index()
        {
            return View(toyTypeRepository.All);
        }

        //
        // GET: /ToyType/Details/5

        public ViewResult Details(int id)
        {
            return View(toyTypeRepository.Find(id));
        }

        //
        // GET: /ToyType/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ToyType/Create

        [HttpPost]
        public ActionResult Create(ToyType toytype)
        {
            if (ModelState.IsValid) {
                toyTypeRepository.InsertOrUpdate(toytype);
                toyTypeRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /ToyType/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(toyTypeRepository.Find(id));
        }

        //
        // POST: /ToyType/Edit/5

        [HttpPost]
        public ActionResult Edit(ToyType toytype)
        {
            if (ModelState.IsValid) {
                toyTypeRepository.InsertOrUpdate(toytype);
                toyTypeRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /ToyType/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(toyTypeRepository.Find(id));
        }

        //
        // POST: /ToyType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            toyTypeRepository.Delete(id);
            toyTypeRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                toyTypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

