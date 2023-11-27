namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    public class GymEquipment : BaseEntity
    {
        public ICollection<Exercise>? Exercises { get; set; }
    }
}
