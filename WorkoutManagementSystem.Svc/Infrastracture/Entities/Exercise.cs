namespace WorkoutManagementSystem.Svc.Infrastracture.Entities
{
    /// <summary>
    /// Упражнение
    /// </summary>
    public class Exercise : BaseEntity
    {
        /// <summary>
        /// Наименование упражнения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание упражнения
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор тренировки
        /// </summary>
        public long WorkoutId {get; set; }

        /// <summary>
        /// Тренажеры для упражнения
        /// </summary>
        public ICollection<GymEquipment>? GymEquipment { get; set; }
    }
}
