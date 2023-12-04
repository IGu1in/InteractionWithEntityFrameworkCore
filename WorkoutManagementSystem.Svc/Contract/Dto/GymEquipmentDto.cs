namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    public class GymEquipmentDto : BaseDto
    {
        public string Name { get; set; }
        public IEnumerable<ExerciseDto>? Exercises { get; set; }
    }
}
