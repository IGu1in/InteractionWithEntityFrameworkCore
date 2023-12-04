namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    public class TechnicalDaysDto : BaseDto
    {
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}
