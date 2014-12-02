using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using DailyPlanner.Dal.DbContexts;
using DailyPlanner.DomainClasses;
using DailyPlanner.Repository.BaseClasses;
using DailyPlanner.Repository.Interfaces;

namespace DailyPlanner.Repository
{ 
    public class FlashcardRepository : BaseRepository, IFlashcardRepository
    {
        public FlashcardRepository(DailyPlannerDbContext context)
            : base(context)
        {
            
        }
        public IQueryable<Flashcard> All
        {
            get { return _context.Flashcards; }
        }

        public IQueryable<Flashcard> AllIncluding(params Expression<Func<Flashcard, object>>[] includeProperties)
        {
            IQueryable<Flashcard> query = _context.Flashcards;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Flashcard Find(int id)
        {
            return _context.Flashcards.Find(id);
        }

        public void InsertOrUpdate(Flashcard flashcard)
        {
            if (flashcard.Id == default(int)) {
                // New entity
                _context.Flashcards.Add(flashcard);
            } else {
                // Existing entity
                _context.Entry(flashcard).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var flashcard = _context.Flashcards.Find(id);
            _context.Flashcards.Remove(flashcard);
        }

       

    }
}