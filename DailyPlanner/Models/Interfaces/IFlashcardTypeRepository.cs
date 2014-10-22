using System;
using System.Linq;
using System.Linq.Expressions;

namespace DailyPlanner.Models.Interfaces
{
    public interface IFlashcardTypeRepository : IDisposable
    {
        IQueryable<FlashcardType> All { get; }
        IQueryable<FlashcardType> AllIncluding(params Expression<Func<FlashcardType, object>>[] includeProperties);
        FlashcardType Find(int id);
        void InsertOrUpdate(FlashcardType flashcardtype);
        void Delete(int id);
        void Save();
    }
}