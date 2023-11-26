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
        public async Task<WorkoutDto> CreateWorkout(WorkoutDto workoutDto)
        {
            return await _workoutManagementsSystemService.CreateWorkout(workoutDto);
        }

        [HttpGet]
        public async Task<WorkoutDto> GetWorkoutByIdAsync(long id)
        {
            return await _workoutManagementsSystemService.GetWorkoutByIdAsync(id);
        }
    }
}
