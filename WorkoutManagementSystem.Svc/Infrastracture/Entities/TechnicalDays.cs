namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    /// <summary>
    /// Технический день
    /// </summary>
    public class TechnicalDays : BaseEntity
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
