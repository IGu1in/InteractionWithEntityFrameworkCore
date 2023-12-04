namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    public class Workout : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public StarParticipants? StarParticipants { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
