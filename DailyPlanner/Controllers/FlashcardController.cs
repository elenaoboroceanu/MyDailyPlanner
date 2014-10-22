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
    public class FlashcardController : Controller
    {
		private readonly IFlashcardTypeRepository flashcardtypeRepository;
		private readonly IFlashcardRepository flashcardRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public FlashcardController() : this(new FlashcardTypeRepository(), new FlashcardRepository())
        {
        }

        public FlashcardController(IFlashcardTypeRepository flashcardtypeRepository, IFlashcardRepository flashcardRepository)
        {
			this.flashcardtypeRepository = flashcardtypeRepository;
			this.flashcardRepository = flashcardRepository;
        }

        //
        // GET: /Flashcard/

        public ViewResult Index()
        {
            return View(flashcardRepository.All);
        }

        //
        // GET: /Flashcard/Details/5

        public ViewResult Details(int id)
        {
            return View(flashcardRepository.Find(id));
        }

        //
        // GET: /Flashcard/Create

        public ActionResult Create()
        {
			ViewBag.PossibleFlashcardTypes = flashcardtypeRepository.All;
            return View();
        } 

        //
        // POST: /Flashcard/Create

        [HttpPost]
        public ActionResult Create(Flashcard flashcard)
        {
            if (ModelState.IsValid) {
                flashcardRepository.InsertOrUpdate(flashcard);
                flashcardRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleFlashcardTypes = flashcardtypeRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Flashcard/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleFlashcardTypes = flashcardtypeRepository.All;
             return View(flashcardRepository.Find(id));
        }

        //
        // POST: /Flashcard/Edit/5

        [HttpPost]
        public ActionResult Edit(Flashcard flashcard)
        {
            if (ModelState.IsValid) {
                flashcardRepository.InsertOrUpdate(flashcard);
                flashcardRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleFlashcardTypes = flashcardtypeRepository.All;
				return View();
			}
        }

        //
        // GET: /Flashcard/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(flashcardRepository.Find(id));
        }

        //
        // POST: /Flashcard/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            flashcardRepository.Delete(id);
            flashcardRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                flashcardtypeRepository.Dispose();
                flashcardRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

