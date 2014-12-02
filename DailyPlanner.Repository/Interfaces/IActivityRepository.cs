using System.Linq;

using DailyPlanner.DomainClasses;
using DailyPlanner.Repository.BaseInterfaces;

namespace DailyPlanner.Repository.Interfaces
{
    public interface IActivityRepository : IBaseInterface<Activity>
    {
        IQueryable<Activity> AllActivitiesIncludingToysAndFlashcards();
    }
}