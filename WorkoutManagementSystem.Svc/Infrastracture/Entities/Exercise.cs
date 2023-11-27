namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public long WorkoutId {get; set; }
    }
}
