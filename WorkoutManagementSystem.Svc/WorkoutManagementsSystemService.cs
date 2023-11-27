﻿using AutoMapper;
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

        public async Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto workoutDto)
        {
            var result = await _context.AddAsync(_mapper.Map<Workout>(workoutDto));
            await _context.SaveChangesAsync();

            return _mapper.Map<WorkoutDto>(result.Entity);
        }

        public async Task<int> GetCountExerciseInsideWorkoutByIdAsync(long id)
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(x => x.Id == id);
            _context.Entry(workout)
                    .Collection(w => w.Exercises)
                    .Load();

            return workout.Exercises.Count();
        }

        public async Task<WorkoutDto> GetWorkoutByIdAsync(long id)
        {
            var workout = await _context.Workouts
                .AsNoTracking()
                .Include(work=>work.Exercises)
                .Include(x => x.StarParticipants)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<WorkoutDto>(workout);
        }

        public async Task<WorkoutDto> ChangeStarForWorkoutAsync(long id, StarParticipantsDto starParticipants)
        {
            var workout = await _context.Workouts
                .Include(x => x.StarParticipants)
                .FirstOrDefaultAsync(x => x.Id == id);

            //if (workout.StarParticipants is null)
            //{
            //    await _context.AddAsync(new StarParticipants
            //    {
            //        Achievements = starParticipants.Achievements,
            //        Id = starParticipants.Id,
            //        Name = starParticipants.Name,
            //        WorkoutId = id
            //    });
            //}
            //else
            //{
            //    workout.StarParticipants = _mapper.Map<StarParticipants>(starParticipants);
            //}
            workout.StarParticipants = new StarParticipants
            {
                Achievements = starParticipants.Achievements,
                Id = starParticipants.Id,
                Name = starParticipants.Name,
                WorkoutId = id
            };
            //workout.StarParticipants = _mapper.Map<StarParticipants>(starParticipants);

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
    }
}
