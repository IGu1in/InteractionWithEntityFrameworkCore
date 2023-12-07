using AutoMapper;
using WorkoutManagementSystem.Svc.Contract.Dto;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.AutoMapperProfiles
{
    public class WorkouManagerSystemProfile : Profile
    {
        public WorkouManagerSystemProfile()
        {
            CreateMap<WorkoutDto, Workout>();
            CreateMap<Workout, WorkoutDto>();
            
            CreateMap<ExerciseDto, Exercise>();
            CreateMap<Exercise, ExerciseDto>();

            CreateMap<StarParticipantsDto, StarParticipants>();
            CreateMap<StarParticipants, StarParticipantsDto>();

            CreateMap<GymEquipmentDto, GymEquipment>();
            CreateMap<GymEquipment, GymEquipmentDto>();

            CreateMap<TechnicalDays, TechnicalDaysDto>();
            CreateMap<TechnicalDaysDto, TechnicalDays>();
        }
    }
}
