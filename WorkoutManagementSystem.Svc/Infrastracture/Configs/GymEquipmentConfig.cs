using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Infrastracture.Configs
{
    /// <summary>
    /// Конфигурация для типа GymEquipment
    /// </summary>
    public class GymEquipmentConfig : IEntityTypeConfiguration<GymEquipment>
    {
        /// <summary>
        /// Создает теневое свойство CreatedOn
        /// </summary>
        public void Configure(EntityTypeBuilder<GymEquipment> builder)
        {
            builder.Property<DateTime>("CreatedOn");
        }
    }
}
