using WorkoutManagementSystem.Svc.Contract.Dto;

namespace WorkoutManagementSystem.Svc.Contract
{
    public interface IWorkoutManagementsSystemService
    {
        Task<WorkoutDto> GetWorkoutByIdAsync(long id);
        Task<WorkoutDto> CreateWorkout(WorkoutDto workoutDto);
    }
}
