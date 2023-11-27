using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    public class ExerciseDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<GymEquipment>? GymEquipment { get; set; }
    }
}
