using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

namespace DailyPlanner.Models.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false; 
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<LogAction> Logs { get; set; }
    }
}