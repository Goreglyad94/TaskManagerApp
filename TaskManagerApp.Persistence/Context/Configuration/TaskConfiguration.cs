using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Tasks;

namespace TaskManagerApp.Persistence.Context.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskUnit>
    {
        public void Configure(EntityTypeBuilder<TaskUnit> builder)
        {
            builder.ToTable("tasks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.TaskStatus).HasConversion<string>();

            builder.OwnsMany(x => x.Documents, documentBuidler =>
            {
                documentBuidler.ToTable("documents");
                documentBuidler.HasKey(x => x.Id);
            });
        }
    }
}
