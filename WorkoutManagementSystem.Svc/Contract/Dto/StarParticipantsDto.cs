namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    /// <summary>
    /// Звездный участник тренировки
    /// </summary>
    public class StarParticipantsDto : BaseDto
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
