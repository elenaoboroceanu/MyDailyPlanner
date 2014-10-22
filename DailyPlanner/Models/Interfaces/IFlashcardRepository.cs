using System;
using System.Linq;
using System.Linq.Expressions;

namespace DailyPlanner.Models.Interfaces
{
    public interface IFlashcardRepository : IDisposable
    {
        IQueryable<Flashcard> All { get; }
        IQueryable<Flashcard> AllIncluding(params Expression<Func<Flashcard, object>>[] includeProperties);
        Flashcard Find(int id);
        void InsertOrUpdate(Flashcard flashcard);
        void Delete(int id);
        void Save();
    }
}