using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public WorkoutManagementsSystemService(IMapper mapper, WorkoutManagementSystemContext workoutManagementSystemContext, IServiceScopeFactory serviceScopeFactory)
        {
            _mapper = mapper;
            _context = workoutManagementSystemContext;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto workoutDto)
        {
            var result = await _context.AddAsync(_mapper.Map<Workout>(workoutDto));
            await _context.SaveChangesAsync();

            return await GetWorkoutByIdAsync(result.Entity.Id);
        }

        /// <summary>
        /// Асинхронный метод 5.11
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> GetCountExerciseInsideWorkoutByIdAsync(long id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<WorkoutManagementSystemContext>();
                var workout = await context.Workouts.FirstOrDefaultAsync(x => x.Id == id);
                context.Entry(workout)
                        .Collection(w => w.Exercises)
                        .Load();

                return workout.Exercises.Count();
            }
        }

        /// <summary>
        /// Вызов скалярной функции 10.1.1
        /// </summary>
        public async Task<int> GetCountExerciseInsideWorkoutByDbFunction(int id)
        {
            var answer = _context.Workouts
                .Where(w => w.Id == id)
                .Select(e => new
                {
                    Count = WorkoutManagementSystemContext.CountExercisesInWorkout(id)
                });

            return answer.FirstOrDefault().Count;
        }

        public async Task<WorkoutDto> GetWorkoutByIdAsync(long id)
        {
            var workout = await _context.Workouts
                .AsNoTracking()
                .Include(work => work.Exercises)
                .ThenInclude(exer => exer.GymEquipment)
                .Include(x => x.StarParticipants)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<WorkoutDto>(workout);
        }

        public async Task<WorkoutDto> ChangeStarForWorkoutAsync(long id, StarParticipantsDto starParticipants)
        {
            var workout = await _context.Workouts
                .Include(x => x.StarParticipants)
                .FirstOrDefaultAsync(x => x.Id == id);

            workout.StarParticipants = _mapper.Map<StarParticipants>(starParticipants);
            await _context.SaveChangesAsync();

            return _mapper.Map<WorkoutDto>(workout);
        }

        public async Task<WorkoutDto> AddExerciseForWorkoutAsync(long id, ExerciseDto exercise)
        {
            var workout = await _context.Workouts
                .Include(work => work.Exercises)
                .FirstOrDefaultAsync(x => x.Id == id);
            workout.Exercises.Add(_mapper.Map<Exercise>(exercise));

            await _context.SaveChangesAsync();

            return _mapper.Map<WorkoutDto>(workout);
        }

        public async Task<WorkoutDto> RemoveWorkoutByIdAsync(long id)
        {
            var workout = await _context.Workouts
                .Include(work => work.Exercises)
                .Include(x => x.StarParticipants)
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = _context.Remove(workout);
            await _context.SaveChangesAsync();

            return _mapper.Map<WorkoutDto>(result.Entity);
        }

        public async Task AddExerciseGymEquipmentAsync(long idExercise, long idGymEquipment)
        {
            var exercise = await _context.Exercise
                .Include(e => e.GymEquipment)
                .FirstOrDefaultAsync(e => e.Id == idExercise);

            var equipment = await _context.GymEquipment.FirstOrDefaultAsync(eq => eq.Id == idGymEquipment);

            exercise.GymEquipment.Add(equipment);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Использование транзакций 4.7.2, использование скрытого свойства 7.14
        /// </summary>
        /// <param name="gymEquipmentDto"></param>
        /// <returns></returns>
        public async Task<GymEquipmentDto> CreateGymEquipmentAsync(GymEquipmentDto gymEquipmentDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var gymEqupment = _mapper.Map<GymEquipment>(gymEquipmentDto);
                    var result = await _context.AddAsync(gymEqupment);
                    _context.Entry(gymEqupment).Property("CreatedOn").CurrentValue = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return _mapper.Map<GymEquipmentDto>(result.Entity);
                }
                catch (Exception)
                {
                    transaction.Rollback();

                    throw;
                }
            }
        }

        /// <summary>
        /// копирование 6.2.3
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WorkoutDto> CopyWorkoutDto(long id)
        {
            var workout = await _context.Workouts
                .AsNoTracking()
                .Include(work => work.StarParticipants)
                .Include(work => work.Exercises)
                .ThenInclude(ex => ex.GymEquipment)
                .FirstOrDefaultAsync(x => x.Id == id);

            workout.Id = default;
            workout.StarParticipants.Id = default;

            foreach (var exercise in workout.Exercises)
            {
                exercise.Id = default;

                foreach (var equipment in exercise.GymEquipment)
                {
                    equipment.Id = default;
                }
            }

            var workoutCopy = await _context.AddAsync(workout);
            await _context.SaveChangesAsync();

            return _mapper.Map<WorkoutDto>(workoutCopy.Entity);
        }
    }
}
