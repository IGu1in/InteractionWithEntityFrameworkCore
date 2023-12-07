namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    /// <summary>
    /// Тренировка
    /// </summary>
    public class WorkoutDto : BaseDto
    {
        /// <summary>
        /// Наименование тренировки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание тренировки
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата тренировки
        /// </summary>
        public DateTime TrainingDate { get; set; }

        /// <summary>
        /// Звездный участник
        /// </summary>
        public StarParticipantsDto? StarParticipants { get; set; }

        /// <summary>
        /// Упражнения
        /// </summary>
        public IEnumerable<ExerciseDto> Exercises { get; set; }
    }
}
