using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Domain.Tasks;

namespace TaskManagerApp.Persistence.Context
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<TaskUnit> Tasks { get; set; }
        public DbSet<Document> Documents { get; set; }

        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
