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
    public class FlashcardTypeRepository : BaseRepository, IFlashcardTypeRepository
    {
        public FlashcardTypeRepository(DailyPlannerDbContext context)
            : base(context)
        {
            
        }
        public IQueryable<FlashcardType> All
        {
            get { return _context.FlashcardTypes; }
        }

        public IQueryable<FlashcardType> AllIncluding(params Expression<Func<FlashcardType, object>>[] includeProperties)
        {
            IQueryable<FlashcardType> query = _context.FlashcardTypes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public FlashcardType Find(int id)
        {
            return _context.FlashcardTypes.Find(id);
        }

        public void InsertOrUpdate(FlashcardType flashcardtype)
        {
            if (flashcardtype.Id == default(int)) {
                // New entity
                _context.FlashcardTypes.Add(flashcardtype);
            } else {
                // Existing entity
                _context.Entry(flashcardtype).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var flashcardtype = _context.FlashcardTypes.Find(id);
            _context.FlashcardTypes.Remove(flashcardtype);
        }
       
    }
}