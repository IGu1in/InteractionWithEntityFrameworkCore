namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    public class GymEquipment : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Exercise>? Exercises { get; set; }
    }
}
