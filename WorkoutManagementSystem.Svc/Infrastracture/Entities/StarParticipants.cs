namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    /// <summary>
    /// Звездный участник
    /// </summary>
    public class StarParticipants : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Достижения
        /// </summary>
        public string Achievements { get; set; }
    }
}
