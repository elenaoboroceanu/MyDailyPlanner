using System;

using DailyPlanner.Dal.DbContexts;

namespace DailyPlanner.Repository.BaseClasses
{
    public class BaseRepository: IDisposable
    {
        protected readonly DailyPlannerDbContext _context;
        private bool disposed = false;


      
        public BaseRepository(DailyPlannerDbContext context)
        {
            _context = context;
        }        

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing && _context!= null)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}