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
        }
    }
}
