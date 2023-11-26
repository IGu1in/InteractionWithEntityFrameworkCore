using Microsoft.EntityFrameworkCore;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Infrastracture
{
    public class WorkoutManagementSystemContext : DbContext
    {
        public WorkoutManagementSystemContext(DbContextOptions<WorkoutManagementSystemContext> options) : base(options) 
        {
            
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
    }
}
