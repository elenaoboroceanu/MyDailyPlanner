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
    public class ToyRepository : BaseRepository, IToyRepository
    {
        public ToyRepository(DailyPlannerDbContext context)
            : base(context)
        {
            
        }
        public IQueryable<Toy> All
        {
            get { return _context.Toys; }
        }

        public IQueryable<Toy> AllIncluding(params Expression<Func<Toy, object>>[] includeProperties)
        {
            IQueryable<Toy> query = _context.Toys;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Toy Find(int id)
        {
            return _context.Toys.Find(id);
        }

        public void InsertOrUpdate(Toy toy)
        {
            if (toy.Id == default(int)) {
                // New entity
                _context.Toys.Add(toy);
            } else {
                // Existing entity
                _context.Entry(toy).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var toy = _context.Toys.Find(id);
            _context.Toys.Remove(toy);
        }
       
    }
}