using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using DailyPlanner.Dal.DbContexts;
using DailyPlanner.DomainClasses;
using DailyPlanner.Repository.BaseClasses;
using DailyPlanner.Repository.Interfaces;

namespace DailyPlanner.Repository
{
    public class DailyTaskRepository : BaseRepository, IDailyTaskRepository
    {
        public DailyTaskRepository(DailyPlannerDbContext context)
            : base(context)
        {
            
        }
        public IQueryable<DailyTask> All
        {
            get { return _context.DailyTasks; }
        }
        public IQueryable<DailyTask> AllIncluding(params Expression<Func<DailyTask, object>>[] includeProperties)
        {
            IQueryable<DailyTask> query = _context.DailyTasks;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

     
        public DailyTask Find(int id)
        {
            return _context.DailyTasks.Find(id);
        }

        public void InsertOrUpdate(DailyTask dailyTask)
        {
            if (dailyTask.Id == default(int))
            {
                // New entity
                _context.DailyTasks.Add(dailyTask);
            }
            else
            {
                // Existing entity
                _context.Entry(dailyTask).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var dailyTask = _context.DailyTasks.Find(id);
            _context.DailyTasks.Remove(dailyTask);
        }

        public IQueryable<DailyTask> GetTasksIncludingActivitiesByDate(DateTime date)
        {
            return AllIncluding(dailyTask => dailyTask.Activity)
                .Where(p => p.Date == date)
                .OrderBy(p => p.StartTime);
        }
    }
}