using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


using DailyPlanner.Models.Interfaces;

namespace DailyPlanner.Models.Repositories
{ 
    public class ToyTypeRepository : IToyTypeRepository
    {
        DailyPlannerDbContext context = new DailyPlannerDbContext();

        public IQueryable<ToyType> All
        {
            get { return context.ToyTypes; }
        }

        public IQueryable<ToyType> AllIncluding(params Expression<Func<ToyType, object>>[] includeProperties)
        {
            IQueryable<ToyType> query = context.ToyTypes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ToyType Find(int id)
        {
            return context.ToyTypes.Find(id);
        }

        public void InsertOrUpdate(ToyType toytype)
        {
            if (toytype.Id == default(int)) {
                // New entity
                context.ToyTypes.Add(toytype);
            } else {
                // Existing entity
                context.Entry(toytype).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var toytype = context.ToyTypes.Find(id);
            context.ToyTypes.Remove(toytype);
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