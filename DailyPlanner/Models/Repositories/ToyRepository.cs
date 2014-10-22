using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


using DailyPlanner.Models.Interfaces;

namespace DailyPlanner.Models.Repositories
{ 
    public class ToyRepository : IToyRepository
    {
        DailyPlannerDbContext context = new DailyPlannerDbContext();

        public IQueryable<Toy> All
        {
            get { return context.Toys; }
        }

        public IQueryable<Toy> AllIncluding(params Expression<Func<Toy, object>>[] includeProperties)
        {
            IQueryable<Toy> query = context.Toys;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Toy Find(int id)
        {
            return context.Toys.Find(id);
        }

        public void InsertOrUpdate(Toy toy)
        {
            if (toy.Id == default(int)) {
                // New entity
                context.Toys.Add(toy);
            } else {
                // Existing entity
                context.Entry(toy).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var toy = context.Toys.Find(id);
            context.Toys.Remove(toy);
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