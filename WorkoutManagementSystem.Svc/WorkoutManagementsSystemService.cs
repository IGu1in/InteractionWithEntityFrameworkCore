using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkoutManagementSystem.Svc.Contract;
using WorkoutManagementSystem.Svc.Contract.Dto;
using WorkoutManagementSystem.Svc.Infrastracture;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc
{
    public class WorkoutManagementsSystemService : IWorkoutManagementsSystemService
    {
        private readonly IMapper _mapper;
        private readonly WorkoutManagementSystemContext _context;

        public WorkoutManagementsSystemService(IMapper mapper, WorkoutManagementSystemContext workoutManagementSystemContext)
        {
            _mapper = mapper;
            _context = workoutManagementSystemContext;
        }

        public async Task<WorkoutDto> CreateWorkout(WorkoutDto workoutDto)
        {
            var result = await _context.AddAsync(_mapper.Map<Workout>(workoutDto));
            await _context.SaveChangesAsync();

            return _mapper.Map<WorkoutDto>(result.Entity);
        }

        public async Task<WorkoutDto> GetWorkoutByIdAsync(long id)
        {
            var workout = await _context.Workouts
                .AsNoTracking()
                .Include(work=>work.Exercises)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<WorkoutDto>(workout);
        }
    }
}
