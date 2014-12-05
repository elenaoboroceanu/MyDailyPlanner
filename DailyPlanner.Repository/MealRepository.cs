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
    public class MealRepository : BaseRepository, IMealRepository
    {
        public MealRepository(DailyPlannerDbContext context) : base(context)
        {
        }
        public IQueryable<Meal> All
        {
            get { return _context.Meals; }
        }

        public IQueryable<Meal> AllIncluding(params Expression<Func<Meal, object>>[] includeProperties)
        {
            IQueryable<Meal> query = _context.Meals;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Meal Find(int id)
        {
            return _context.Meals.Find(id);
        }

        public void InsertOrUpdate(Meal meal)
        {
            if (meal.Id == default(int))
            {
                // New entity
                _context.Meals.Add(meal);
            }
            else
            {
                // Existing entity
                _context.Entry(meal).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var meal = _context.Meals.Find(id);
            _context.Meals.Remove(meal);
        }       
    }
}
