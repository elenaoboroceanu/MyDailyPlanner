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
    public class FlashcardTypeController : Controller
    {
		private readonly IFlashcardTypeRepository flashcardtypeRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public FlashcardTypeController() : this(new FlashcardTypeRepository())
        {
        }

        public FlashcardTypeController(IFlashcardTypeRepository flashcardtypeRepository)
        {
			this.flashcardtypeRepository = flashcardtypeRepository;
        }

        //
        // GET: /FlashcardType/

        public ViewResult Index()
        {
            return View(flashcardtypeRepository.All);
        }

        //
        // GET: /FlashcardType/Details/5

        public ViewResult Details(int id)
        {
            return View(flashcardtypeRepository.Find(id));
        }

        //
        // GET: /FlashcardType/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /FlashcardType/Create

        [HttpPost]
        public ActionResult Create(FlashcardType flashcardtype)
        {
            if (ModelState.IsValid) {
                flashcardtypeRepository.InsertOrUpdate(flashcardtype);
                flashcardtypeRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /FlashcardType/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(flashcardtypeRepository.Find(id));
        }

        //
        // POST: /FlashcardType/Edit/5

        [HttpPost]
        public ActionResult Edit(FlashcardType flashcardtype)
        {
            if (ModelState.IsValid) {
                flashcardtypeRepository.InsertOrUpdate(flashcardtype);
                flashcardtypeRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /FlashcardType/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(flashcardtypeRepository.Find(id));
        }

        //
        // POST: /FlashcardType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            flashcardtypeRepository.Delete(id);
            flashcardtypeRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                flashcardtypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

