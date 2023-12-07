using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Infrastracture.Configs
{
    /// <summary>
    /// Конфигурация для типа TechnicalDays
    /// </summary>
    public class TechnicalDaysConfig : IEntityTypeConfiguration<TechnicalDays>
    {
        /// <summary>
        /// Меняет тип свойства Date с datetime2 на date, который не содержит время, но занимает меньше места
        /// </summary>
        public void Configure(EntityTypeBuilder<TechnicalDays> builder)
        {
            builder.Property(p => p.Date)
                .HasColumnType("date");
        }
    }
}
