using Microsoft.EntityFrameworkCore;
using WorkoutManagementSystem.Svc.Infrastracture;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.EntityEvents
{
    public class TechnicalDaysEventHandler : ITechnicalDaysEventHandler
    {
        private Workout _workoutDto;

        public string GetError(WorkoutManagementSystemContext context)
        {
            var technicalDays = context.TechnicalDays
                .Where(x => x.Date == _workoutDto.TrainingDate)
                .ToList();

            if (technicalDays.Any())
            {
                return "Technical Days";
            }

            return string.Empty;
        }

        public bool NeedsCallToTechnicalDays(WorkoutManagementSystemContext context)
        {
            var newWorkouts = context.ChangeTracker
                .Entries<Workout>()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity)
                .ToList();

            if (newWorkouts.Count > 1)
            {
                throw new Exception("Can only process one Workout at a time");
            }

            if (!newWorkouts.Any())
            {
                return false;
            }

            _workoutDto = newWorkouts.FirstOrDefault();

            return true;
        }
    }
}
