using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


using DailyPlanner.Models.Interfaces;

namespace DailyPlanner.Models.Repositories
{
    public class DailyTaskRepository    :IDailyTaskRepository
    {
        DailyPlannerDbContext context = new DailyPlannerDbContext();

        public IQueryable<DailyTask> All
        {
            get { return context.DailyTasks; }
        }
        public IQueryable<DailyTask> AllIncluding(params Expression<Func<DailyTask, object>>[] includeProperties)
        {
            IQueryable<DailyTask> query = context.DailyTasks;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

     
        public DailyTask Find(int id)
        {
            return context.DailyTasks.Find(id);
        }

        public void InsertOrUpdate(DailyTask dailyTask)
        {
            if (dailyTask.Id == default(int))
            {
                // New entity
                context.DailyTasks.Add(dailyTask);
            }
            else
            {
                // Existing entity
                context.Entry(dailyTask).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var dailyTask = context.DailyTasks.Find(id);
            context.DailyTasks.Remove(dailyTask);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}