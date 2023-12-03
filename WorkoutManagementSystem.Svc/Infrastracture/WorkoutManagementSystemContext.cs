using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WorkoutManagementSystem.Svc.Infrastracture.Configs;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;
using WorkoutManagementSystem.Svc.Infrastracture.Functions;

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
        //public IQueryable<int> CountExercisesInWorkout(int pworkoutid) => FromExpression(() => CountExercisesInWorkout(pworkoutid));

        [DbFunction("countexercisesinworkout", Schema = "public")]
        public static int CountExercisesInWorkout(int workoutId)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkoutConfig());
            modelBuilder.ApplyConfiguration(new GymEquipmentConfig());
            //var methodInfo = typeof(WorkoutFunction).GetRuntimeMethod(nameof(WorkoutFunction.CountExercisesInWorkout), new Type[0]);
            //modelBuilder.HasDbFunction(methodInfo);
            //modelBuilder.HasDbFunction(() => CountExercisesInWorkout(default(int)));
            //modelBuilder.HasDbFunction(() => WorkoutFunction.CountExercisesInWorkout(default(int)));
        }
    }
}
