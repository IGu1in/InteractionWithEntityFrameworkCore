using WorkoutManagementSystem.Svc.Contract.Dto;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Contract
{
    public interface IWorkoutManagementsSystemService
    {
        Task<WorkoutDto> GetWorkoutByIdAsync(long id);
        Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto workoutDto);
        Task<int> GetCountExerciseInsideWorkoutByIdAsync(long id);
        Task<WorkoutDto> ChangeStarForWorkoutAsync(long id, StarParticipantsDto starParticipants);
        Task<WorkoutDto> RemoveWorkoutByIdAsync(long id);
        Task<WorkoutDto> AddExerciseForWorkoutAsync(long id, ExerciseDto exercise);
        Task<GymEquipmentDto> CreateGymEquipmentAsync(GymEquipmentDto gymEquipmentDto);
        Task AddExerciseGymEquipmentAsync(long idExercise, long idGymEquipment);
        Task<WorkoutDto> CopyWorkoutDto(long id);
        Task<int> GetCountExerciseInsideWorkoutByDbFunction(int id);
        Task<TechnicalDays> CreateTechnicalDaysAsync(TechnicalDaysDto technicalDaysDto);
    }
}
