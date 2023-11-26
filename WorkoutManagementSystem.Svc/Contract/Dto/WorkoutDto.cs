using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    public class WorkoutDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public StarParticipants? StarParticipants { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
