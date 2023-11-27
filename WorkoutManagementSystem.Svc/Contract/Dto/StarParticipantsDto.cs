namespace WorkoutManagementSystem.Svc.Contract.Dto
{
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
