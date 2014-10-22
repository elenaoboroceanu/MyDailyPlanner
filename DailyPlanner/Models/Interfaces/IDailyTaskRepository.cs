using System;
using System.Linq;
using System.Linq.Expressions;

namespace DailyPlanner.Models.Interfaces
{
    public interface IDailyTaskRepository : IDisposable
    {
        IQueryable<DailyTask> All { get; }
        IQueryable<DailyTask> AllIncluding(params Expression<Func<DailyTask, object>>[] includeProperties);
        DailyTask Find(int id);
        void InsertOrUpdate(DailyTask dailyTask);
        void Delete(int id);
        void Save();
    }
}