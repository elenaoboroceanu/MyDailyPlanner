using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


using DailyPlanner.Models.Interfaces;

namespace DailyPlanner.Models.Repositories
{ 
    public class FlashcardRepository : IFlashcardRepository
    {
        DailyPlannerDbContext context = new DailyPlannerDbContext();

        public IQueryable<Flashcard> All
        {
            get { return context.Flashcards; }
        }

        public IQueryable<Flashcard> AllIncluding(params Expression<Func<Flashcard, object>>[] includeProperties)
        {
            IQueryable<Flashcard> query = context.Flashcards;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Flashcard Find(int id)
        {
            return context.Flashcards.Find(id);
        }

        public void InsertOrUpdate(Flashcard flashcard)
        {
            if (flashcard.Id == default(int)) {
                // New entity
                context.Flashcards.Add(flashcard);
            } else {
                // Existing entity
                context.Entry(flashcard).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var flashcard = context.Flashcards.Find(id);
            context.Flashcards.Remove(flashcard);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }
}