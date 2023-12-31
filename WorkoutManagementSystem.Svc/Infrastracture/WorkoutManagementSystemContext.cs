﻿using Microsoft.EntityFrameworkCore;
using WorkoutManagementSystem.Svc.EntityEvents;
using WorkoutManagementSystem.Svc.Infrastracture.Configs;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Infrastracture
{
    /// <summary>
    /// Контекст для работы с WorkoutManagementSystem
    /// </summary>
    public class WorkoutManagementSystemContext : DbContext
    {
        private readonly ITechnicalDaysEventHandler _technicalDaysEventHandler;
        public WorkoutManagementSystemContext(DbContextOptions<WorkoutManagementSystemContext> options, ITechnicalDaysEventHandler technicalDaysEventHandler) : base(options) 
        {
            _technicalDaysEventHandler = technicalDaysEventHandler;
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<GymEquipment> GymEquipment { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<TechnicalDays> TechnicalDays { get; set; }

        /// <summary>
        /// Скалярная функция базы данных для подсчета количества упражнений в тренировке
        /// </summary>
        /// <param name="workoutId">Идентификатор тренировки</param>
        /// <returns>Количество упражнений в тренировке</returns>
        [DbFunction("countexercisesinworkout", Schema = "public")]
        public static int CountExercisesInWorkout(int workoutId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Перегруженный метод SaveChanges для применения события интеграции 
        /// </summary>
        public override int SaveChanges()
        {
            if (!_technicalDaysEventHandler.NeedsCallToTechnicalDays(this))
            {
                return base.SaveChanges();
            }

            using (var transaction = Database.BeginTransaction())
            {
                var result = base.SaveChanges();
                var error = _technicalDaysEventHandler.GetError(this);

                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                transaction.Commit();

                return result;
            }
        }

        /// <summary>
        /// Перегруженный метод SaveChangesAsync для применения события интеграции 
        /// </summary>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (!_technicalDaysEventHandler.NeedsCallToTechnicalDays(this))
            {
                return base.SaveChangesAsync();
            }

            using (var transaction = Database.BeginTransaction())
            {
                var result = base.SaveChangesAsync();
                var error = _technicalDaysEventHandler.GetError(this);

                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                transaction.Commit();

                return result;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkoutConfig());
            modelBuilder.ApplyConfiguration(new GymEquipmentConfig());
            modelBuilder.ApplyConfiguration(new TechnicalDaysConfig());
            modelBuilder.UseSerialColumns();
        }
    }
}
