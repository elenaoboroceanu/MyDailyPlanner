using System;
using System.Linq;

using DailyPlanner.DomainClasses;
using DailyPlanner.Repository.BaseInterfaces;

namespace DailyPlanner.Repository.Interfaces
{
    public interface IDailyTaskRepository : IBaseInterface<DailyTask>
    {
        IQueryable<DailyTask> GetTasksIncludingActivitiesByDate(DateTime date);
        DailyTask GetTasksIncludingActivityById(int id);
    }
}