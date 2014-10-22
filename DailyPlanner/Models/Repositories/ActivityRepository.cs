using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;



namespace DailyPlanner.Models.Repositories
{ 
    public class ActivityRepository : IActivityRepository
    {
        DailyPlannerDbContext context = new DailyPlannerDbContext();

        public IQueryable<Activity> All
        {
            get { return context.Activities; }
        }

        public IQueryable<Activity> AllIncluding(params Expression<Func<Activity, object>>[] includeProperties)
        {
            IQueryable<Activity> query = context.Activities;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Activity Find(int id)
        {
            return context.Activities.Find(id);
        }

        public void InsertOrUpdate(Activity activity)
        {
            if (activity.Id == default(int)) {
                // New entity
                context.Activities.Add(activity);
            } else {
                // Existing entity
                context.Entry(activity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var activity = context.Activities.Find(id);
            context.Activities.Remove(activity);
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

    public interface IActivityRepository : IDisposable
    {
        IQueryable<Activity> All { get; }
        IQueryable<Activity> AllIncluding(params Expression<Func<Activity, object>>[] includeProperties);
        Activity Find(int id);
        void InsertOrUpdate(Activity activity);
        void Delete(int id);
        void Save();
    }
}