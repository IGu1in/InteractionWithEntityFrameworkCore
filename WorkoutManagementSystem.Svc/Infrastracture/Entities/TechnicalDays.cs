namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    public class TechnicalDays : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}
