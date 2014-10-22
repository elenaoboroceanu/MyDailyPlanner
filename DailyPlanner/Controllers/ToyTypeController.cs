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
    public class ToyTypeController : Controller
    {
		private readonly IToyTypeRepository toytypeRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ToyTypeController() : this(new ToyTypeRepository())
        {
        }

        public ToyTypeController(IToyTypeRepository toytypeRepository)
        {
			this.toytypeRepository = toytypeRepository;
        }

        //
        // GET: /ToyType/

        public ViewResult Index()
        {
            return View(toytypeRepository.All);
        }

        //
        // GET: /ToyType/Details/5

        public ViewResult Details(int id)
        {
            return View(toytypeRepository.Find(id));
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
                toytypeRepository.InsertOrUpdate(toytype);
                toytypeRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /ToyType/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(toytypeRepository.Find(id));
        }

        //
        // POST: /ToyType/Edit/5

        [HttpPost]
        public ActionResult Edit(ToyType toytype)
        {
            if (ModelState.IsValid) {
                toytypeRepository.InsertOrUpdate(toytype);
                toytypeRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /ToyType/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(toytypeRepository.Find(id));
        }

        //
        // POST: /ToyType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            toytypeRepository.Delete(id);
            toytypeRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                toytypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

