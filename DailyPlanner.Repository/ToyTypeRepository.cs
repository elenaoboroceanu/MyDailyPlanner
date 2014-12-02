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
    public class ToyTypeRepository : BaseRepository, IToyTypeRepository
    {
        public ToyTypeRepository(DailyPlannerDbContext context)
            : base(context)
        {
            
        }
        public IQueryable<ToyType> All
        {
            get { return _context.ToyTypes; }
        }

        public IQueryable<ToyType> AllIncluding(params Expression<Func<ToyType, object>>[] includeProperties)
        {
            IQueryable<ToyType> query = _context.ToyTypes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ToyType Find(int id)
        {
            return _context.ToyTypes.Find(id);
        }

        public void InsertOrUpdate(ToyType toytype)
        {
            if (toytype.Id == default(int)) {
                // New entity
                _context.ToyTypes.Add(toytype);
            } else {
                // Existing entity
                _context.Entry(toytype).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var toytype = _context.ToyTypes.Find(id);
            _context.ToyTypes.Remove(toytype);
        }
       
    }
}