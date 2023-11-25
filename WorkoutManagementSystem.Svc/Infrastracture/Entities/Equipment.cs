namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
