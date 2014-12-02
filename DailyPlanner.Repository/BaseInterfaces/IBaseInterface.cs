using System;
using System.Linq;
using System.Linq.Expressions;

namespace DailyPlanner.Repository.BaseInterfaces
{
    public interface IBaseInterface<T>:IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void InsertOrUpdate(T activitytype);
        void Delete(int id);
        void Save();
    }
}
