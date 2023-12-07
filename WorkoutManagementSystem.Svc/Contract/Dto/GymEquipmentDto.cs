namespace WorkoutManagementSystem.Svc.Contract.Dto
{
    /// <summary>
    /// Тренажер
    /// </summary>
    public class GymEquipmentDto : BaseDto
    {
        /// <summary>
        /// Наименование тренажера
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Упражнения, которые можно выполнять на тренажере
        /// </summary>
        public IEnumerable<ExerciseDto>? Exercises { get; set; }
    }
}
