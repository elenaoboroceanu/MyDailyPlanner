using System;
using System.Linq;
using System.Linq.Expressions;

namespace DailyPlanner.Models.Interfaces
{
    public interface IToyRepository : IDisposable
    {
        IQueryable<Toy> All { get; }
        IQueryable<Toy> AllIncluding(params Expression<Func<Toy, object>>[] includeProperties);
        Toy Find(int id);
        void InsertOrUpdate(Toy toy);
        void Delete(int id);
        void Save();
    }
}