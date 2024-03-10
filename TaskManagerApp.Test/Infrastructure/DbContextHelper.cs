using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Persistence.Context;

namespace TaskManagerApp.Test.Infrastructure
{
    public class DbContextHelper : IDisposable
    {
        public TaskManagerDbContext Context { get; set; }

        public DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<TaskManagerDbContext>();
            builder.UseInMemoryDatabase("unit_testing");
            Context = new TaskManagerDbContext(builder.Options);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
