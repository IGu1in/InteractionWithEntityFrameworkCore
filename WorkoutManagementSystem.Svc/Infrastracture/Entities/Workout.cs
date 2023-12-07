namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    /// <summary>
    /// Тренировка
    /// </summary>
    public class Workout : BaseEntity
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
        public StarParticipants? StarParticipants { get; set; }

        /// <summary>
        /// Упражнения
        /// </summary>
        public ICollection<Exercise> Exercises { get; set; }
    }
}
