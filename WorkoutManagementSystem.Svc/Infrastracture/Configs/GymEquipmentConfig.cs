using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Infrastracture.Configs
{
    public class GymEquipmentConfig : IEntityTypeConfiguration<GymEquipment>
    {
        public void Configure(EntityTypeBuilder<GymEquipment> builder)
        {
            builder.Property<DateTime>("CreatedOn");
        }
    }
}
