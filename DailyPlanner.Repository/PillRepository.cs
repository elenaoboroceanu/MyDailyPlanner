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
    public class PillRepository : BaseRepository, IPillRepository
    {
        public PillRepository(DailyPlannerDbContext context) : base(context)
        {
        }
        public IQueryable<Pill> All
        {
            get { return _context.Pills; }
        }

        public IQueryable<Pill> AllIncluding(params Expression<Func<Pill, object>>[] includeProperties)
        {
            IQueryable<Pill> query = _context.Pills;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Pill Find(int id)
        {
            return _context.Pills.Find(id);
        }

        public void InsertOrUpdate(Pill pill)
        {
            if (pill.Id == default(int))
            {
                // New entity
                _context.Pills.Add(pill);
            }
            else
            {
                // Existing entity
                _context.Entry(pill).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var pill = _context.Pills.Find(id);
            _context.Pills.Remove(pill);
        }       
    }
}
