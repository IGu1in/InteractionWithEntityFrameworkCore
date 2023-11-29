using Microsoft.EntityFrameworkCore;
using WorkoutManagementSystem.Svc.Infrastracture.Configs;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Infrastracture
{
    public class WorkoutManagementSystemContext : DbContext
    {
        public WorkoutManagementSystemContext(DbContextOptions<WorkoutManagementSystemContext> options) : base(options) 
        {
            
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<GymEquipment> GymEquipment { get; set; }
        public DbSet<Exercise> Exercise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkoutConfig());
            modelBuilder.ApplyConfiguration(new GymEquipmentConfig());
        }
    }
}
