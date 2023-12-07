using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Infrastracture.Configs
{
    /// <summary>
    /// Конфигурация для типа Workout
    /// </summary>
    public class WorkoutConfig : IEntityTypeConfiguration<Workout>
    {
        /// <summary>
        /// Меняет тип свойства Date с datetime2 на date, который не содержит время, но занимает меньше места
        /// </summary>
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.Property(p => p.TrainingDate)
                .HasColumnType("date");
        }
    }
}
