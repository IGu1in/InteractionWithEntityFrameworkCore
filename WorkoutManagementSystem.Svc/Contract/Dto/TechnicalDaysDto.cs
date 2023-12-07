namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    /// <summary>
    /// Технический день
    /// </summary>
    public class TechnicalDaysDto : BaseDto
    {
        /// <summary>
        /// Дата проведения технического дня
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Причина проведения
        /// </summary>
        public string Reason { get; set; }
    }
}
