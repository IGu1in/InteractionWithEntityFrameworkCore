namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    /// <summary>
    /// Тренажер
    /// </summary>
    public class GymEquipment : BaseEntity
    {
        /// <summary>
        /// Наименование тренажера
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Упражнения, которые можно выполнять на тренажере
        /// </summary>
        public ICollection<Exercise>? Exercises { get; set; }
    }
}
