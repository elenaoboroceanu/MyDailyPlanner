using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DailyPlanner.Models
{
    public class DailyPlannerDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DailyPlanner.Models.DailyPlannerDbContext>());

        public DailyPlannerDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ActivityType> ActivityTypes { get; set; }

        public DbSet<ToyType> ToyTypes { get; set; }

        public DbSet<FlashcardType> FlashcardTypes { get; set; }

        public DbSet<Flashcard> Flashcards { get; set; }

        public DbSet<Toy> Toys { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<DailyTask> DailyTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Activity>()
                .HasMany(c => c.Toys).WithMany(i => i.Activities)
                .Map(t => t.MapLeftKey("ActivityID")
                    .MapRightKey("ToyID")
                    .ToTable("ActivityToy"));

            modelBuilder.Entity<Activity>()
                .HasMany(c => c.Flashcards).WithMany(i => i.Activities)
                .Map(t => t.MapLeftKey("ActivityID")
                    .MapRightKey("FlashcardID")
                    .ToTable("ActivityFlashcard"));
        }
    }
}