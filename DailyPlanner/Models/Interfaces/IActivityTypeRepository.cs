using System;
using System.Linq;
using System.Linq.Expressions;

namespace DailyPlanner.Models.Interfaces
{
    public interface IActivityTypeRepository : IDisposable
    {
        IQueryable<ActivityType> All { get; }
        IQueryable<ActivityType> AllIncluding(params Expression<Func<ActivityType, object>>[] includeProperties);
        ActivityType Find(int id);
        void InsertOrUpdate(ActivityType activitytype);
        void Delete(int id);
        void Save();
    }
}