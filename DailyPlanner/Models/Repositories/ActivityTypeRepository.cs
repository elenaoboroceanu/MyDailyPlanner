using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


using DailyPlanner.Models.Interfaces;

namespace DailyPlanner.Models.Repositories
{ 
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        DailyPlannerDbContext context = new DailyPlannerDbContext();

        public IQueryable<ActivityType> All
        {
            get { return context.ActivityTypes; }
        }

        public IQueryable<ActivityType> AllIncluding(params Expression<Func<ActivityType, object>>[] includeProperties)
        {
            IQueryable<ActivityType> query = context.ActivityTypes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ActivityType Find(int id)
        {
            return context.ActivityTypes.Find(id);
        }

        public void InsertOrUpdate(ActivityType activitytype)
        {
            if (activitytype.Id == default(int)) {
                // New entity
                context.ActivityTypes.Add(activitytype);
            } else {
                // Existing entity
                context.Entry(activitytype).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var activitytype = context.ActivityTypes.Find(id);
            context.ActivityTypes.Remove(activitytype);
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