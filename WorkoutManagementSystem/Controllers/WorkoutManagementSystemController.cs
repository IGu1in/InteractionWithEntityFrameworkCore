using Microsoft.AspNetCore.Mvc;
using WorkoutManagementSystem.Svc.Contract;

namespace WorkoutManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutManagementSystemController : ControllerBase//, IWorkoutManagementsSystemService
    {
        private readonly IWorkoutManagementsSystemService _workoutManagementsSystemService;

        public WorkoutManagementSystemController(IWorkoutManagementsSystemService workoutManagementsSystemService)
        {

            _workoutManagementsSystemService = workoutManagementsSystemService;
        }

        [HttpGet]
        public async Task<string> StringMetan()
        {
            return "<h2>Hello METANIT.COM!</h2>";
        }
    }
}
