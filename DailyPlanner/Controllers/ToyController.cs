using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DailyPlanner.DomainClasses;
using DailyPlanner.Models;
using DailyPlanner.Repository.Interfaces;

namespace DailyPlanner.Controllers
{   
    [Authorize]
    public class ToyController : Controller
    {
		private readonly IToyTypeRepository toytypeRepository;
		private readonly IToyRepository toyRepository;

		public ToyController(IToyTypeRepository toytypeRepository, IToyRepository toyRepository)
        {
			this.toytypeRepository = toytypeRepository;
			this.toyRepository = toyRepository;
        }

        //
        // GET: /Toy/

        public ViewResult Index()
        {
            return View(toyRepository.AllIncluding(toy => toy.ToyType));
        }

        //
        // GET: /Toy/Details/5

        public ViewResult Details(int id)
        {
            return View(toyRepository.Find(id));
        }

        //
        // GET: /Toy/Create

        public ActionResult Create()
        {
			ViewBag.PossibleToyTypes = toytypeRepository.All;
            return View();
        } 

        //
        // POST: /Toy/Create

        [HttpPost]
        public ActionResult Create(Toy toy)
        {
            if (ModelState.IsValid) {
                toyRepository.InsertOrUpdate(toy);
                toyRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleToyTypes = toytypeRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Toy/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleToyTypes = toytypeRepository.All;
             return View(toyRepository.Find(id));
        }

        //
        // POST: /Toy/Edit/5

        [HttpPost]
        public ActionResult Edit(Toy toy)
        {
            if (ModelState.IsValid) {
                toyRepository.InsertOrUpdate(toy);
                toyRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleToyTypes = toytypeRepository.All;
				return View();
			}
        }

        //
        // GET: /Toy/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(toyRepository.Find(id));
        }

        //
        // POST: /Toy/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            toyRepository.Delete(id);
            toyRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                toytypeRepository.Dispose();
                toyRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

