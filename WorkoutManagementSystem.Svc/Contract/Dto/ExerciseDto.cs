using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    /// <summary>
    /// Упражнение
    /// </summary>
    public class ExerciseDto : BaseDto
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
        /// Тренажеры для упражнения
        /// </summary>
        public IEnumerable<GymEquipment>? GymEquipment { get; set; }
    }
}
