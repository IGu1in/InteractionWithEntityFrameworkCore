using System.ComponentModel.DataAnnotations;

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
        [MaxLength(200)]
        public string Achievements { get; set; }

        /// <summary>
        /// Идентификатор тренировки
        /// </summary>
        public long WorkoutId { get; set; }
    }
}
