using WorkoutManagementSystem.Svc.Contract.Dto;

namespace WorkoutManagementSystem.Svc.Contract
{
    public interface IWorkoutManagementsSystemService
    {
        Task<WorkoutDto> GetWorkoutByIdAsync(long id);
        Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto workoutDto);
        Task<int> GetCountExerciseInsideWorkoutByIdAsync(long id);
        Task<WorkoutDto> ChangeStarForWorkoutAsync(long id, StarParticipantsDto starParticipants);
    }
}
