namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    public class GymEquipmentDto : BaseDto
    {
        public IEnumerable<ExerciseDto>? Exercises { get; set; }
    }
}
