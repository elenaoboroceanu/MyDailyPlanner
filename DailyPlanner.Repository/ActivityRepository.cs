using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

using DailyPlanner.Dal.DbContexts;
using DailyPlanner.DomainClasses;
using DailyPlanner.Repository.BaseClasses;
using DailyPlanner.Repository.Interfaces;

namespace DailyPlanner.Repository
{ 
    public class ActivityRepository : BaseRepository, IActivityRepository
    {
        public ActivityRepository(DailyPlannerDbContext context)
            : base(context)
        {
            
        }
        public IQueryable<Activity> All
        {
            get { return _context.Activities; }
        }

        public IQueryable<Activity> AllIncluding(params Expression<Func<Activity, object>>[] includeProperties)
        {
            // should I use using ?????/
            IQueryable<Activity> query = _context.Activities;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Activity Find(int id)
        {
            return _context.Activities.Find(id);
        }

        public void InsertOrUpdate(Activity activity)
        {
            if (activity.Id == default(int)) {
                // New entity
                _context.Activities.Add(activity);
            } else
            {
                // Existing entity
                var dbEntityEntry = _context.Entry(activity);
                
                dbEntityEntry.State = System.Data.Entity.EntityState.Modified;
            }
            _context.Activities.AddOrUpdate(activity);
        }

        public void Delete(int id)
        {
            var activity = _context.Activities.Find(id);
            _context.Activities.Remove(activity);
        }


        // New methods

        public IQueryable<Activity> AllActivitiesIncludingToysAndFlashcards()
        {
            //return _context.Activities.AllIncluding(activity => activity.ActivityType, activity => activity.Toys, activity => activity.Flashcards);
            return _context.Activities.Include(p => p.ActivityType).Include(p => p.Toys).Include(p => p.Flashcards);
        }
       
    }
}