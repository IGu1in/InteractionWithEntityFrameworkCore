using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Infrastracture.Configs
{
    public class TechnicalDaysConfig : IEntityTypeConfiguration<TechnicalDays>
    {
        public void Configure(EntityTypeBuilder<TechnicalDays> builder)
        {
            builder.Property(p => p.Date)
                .HasColumnType("date");
        }
    }
}
