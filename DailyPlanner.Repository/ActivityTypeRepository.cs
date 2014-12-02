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
    public class ActivityTypeRepository :BaseRepository, IActivityTypeRepository
    {
        public ActivityTypeRepository(DailyPlannerDbContext context) : base(context)
        {
            
        }

        public IQueryable<ActivityType> All
        {
            get { return _context.ActivityTypes; }
        }

        public IQueryable<ActivityType> AllIncluding(params Expression<Func<ActivityType, object>>[] includeProperties)
        {
            IQueryable<ActivityType> query = _context.ActivityTypes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ActivityType Find(int id)
        {
            return _context.ActivityTypes.Find(id);
        }

        public void InsertOrUpdate(ActivityType activitytype)
        {
            if (activitytype.Id == default(int)) {
                // New entity
                _context.ActivityTypes.Add(activitytype);
            } else {
                // Existing entity
                _context.Entry(activitytype).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var activitytype = _context.ActivityTypes.Find(id);
            _context.ActivityTypes.Remove(activitytype);
        }       
    }
}