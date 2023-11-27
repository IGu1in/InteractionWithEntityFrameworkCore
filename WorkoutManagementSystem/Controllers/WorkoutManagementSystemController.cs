using Microsoft.AspNetCore.Mvc;
using WorkoutManagementSystem.Svc.Contract;
using WorkoutManagementSystem.Svc.Contract.Dto;

namespace WorkoutManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WorkoutManagementSystemController : ControllerBase, IWorkoutManagementsSystemService
    {
        private readonly IWorkoutManagementsSystemService _workoutManagementsSystemService;

        public WorkoutManagementSystemController(IWorkoutManagementsSystemService workoutManagementsSystemService)
        {

            _workoutManagementsSystemService = workoutManagementsSystemService;
        }

        [HttpPut]
        public async Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto workoutDto)
        {
            return await _workoutManagementsSystemService.CreateWorkoutAsync(workoutDto);
        }

        [HttpGet]
        public async Task<WorkoutDto> GetWorkoutByIdAsync(long id)
        {
            return await _workoutManagementsSystemService.GetWorkoutByIdAsync(id);
        }

        [HttpGet]
        public async Task<int> GetCountExerciseInsideWorkoutByIdAsync(long id)
        {
            return await _workoutManagementsSystemService.GetCountExerciseInsideWorkoutByIdAsync(id);
        }

        [HttpPut]
        public async Task<WorkoutDto> ChangeStarForWorkoutAsync(long id, StarParticipantsDto starParticipants)
        {
            return await _workoutManagementsSystemService.ChangeStarForWorkoutAsync(id, starParticipants);
        }

        [HttpDelete]
        public async Task<WorkoutDto> RemoveWorkoutByIdAsync(long id)
        {
            return await _workoutManagementsSystemService.RemoveWorkoutByIdAsync(id);
        }

        [HttpPut]
        public async Task<WorkoutDto> AddExerciseForWorkoutAsync(long id, ExerciseDto exercise)
        {
            return await _workoutManagementsSystemService.AddExerciseForWorkoutAsync(id, exercise);
        }

        [HttpPut]
        public async Task<GymEquipmentDto> CreateGymEquipmentAsync(GymEquipmentDto gymEquipmentDto)
        {
            return await _workoutManagementsSystemService.CreateGymEquipmentAsync(gymEquipmentDto);
        }

        [HttpPut]
        public async Task AddExerciseGymEquipmentAsync(long idExercise, long idGymEquipment)
        {
            await _workoutManagementsSystemService.AddExerciseGymEquipmentAsync(idExercise, idGymEquipment);
        }
    }
}
