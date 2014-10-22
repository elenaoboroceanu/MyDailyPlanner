using System;
using System.Linq;
using System.Linq.Expressions;

namespace DailyPlanner.Models.Interfaces
{
    public interface IToyTypeRepository : IDisposable
    {
        IQueryable<ToyType> All { get; }
        IQueryable<ToyType> AllIncluding(params Expression<Func<ToyType, object>>[] includeProperties);
        ToyType Find(int id);
        void InsertOrUpdate(ToyType toytype);
        void Delete(int id);
        void Save();
    }
}