using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


using DailyPlanner.Models.Interfaces;

namespace DailyPlanner.Models.Repositories
{ 
    public class FlashcardTypeRepository : IFlashcardTypeRepository
    {
        DailyPlannerDbContext context = new DailyPlannerDbContext();

        public IQueryable<FlashcardType> All
        {
            get { return context.FlashcardTypes; }
        }

        public IQueryable<FlashcardType> AllIncluding(params Expression<Func<FlashcardType, object>>[] includeProperties)
        {
            IQueryable<FlashcardType> query = context.FlashcardTypes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public FlashcardType Find(int id)
        {
            return context.FlashcardTypes.Find(id);
        }

        public void InsertOrUpdate(FlashcardType flashcardtype)
        {
            if (flashcardtype.Id == default(int)) {
                // New entity
                context.FlashcardTypes.Add(flashcardtype);
            } else {
                // Existing entity
                context.Entry(flashcardtype).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var flashcardtype = context.FlashcardTypes.Find(id);
            context.FlashcardTypes.Remove(flashcardtype);
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