using WorkoutManagementSystem.Svc.Contract.Dto;
using WorkoutManagementSystem.Svc.Infrastracture.Entities;

namespace WorkoutManagementSystem.Svc.Contract
{
    public interface IWorkoutManagementsSystemService
    {
        /// <summary>
        /// Получает тренировку по ее Id
        /// </summary>
        /// <param name="id">Id тренировки</param>
        /// <returns><see cref="WorkoutDto"/></returns>
        Task<WorkoutDto> GetWorkoutByIdAsync(long id);

        /// <summary>
        /// Создает тренировку
        /// </summary>
        /// <param name="workoutDto"><see cref="WorkoutDto"/></param>
        /// <returns>Созданную тренировку</returns>
        Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto workoutDto);

        /// <summary>
        /// Возвращает количество упражнений в тренировке
        /// </summary>
        /// <param name="id">Id тренировки</param>
        /// <returns>Количество упражнений в тренировке</returns>
        Task<int> GetCountExerciseInsideWorkoutByIdAsync(long id);

        /// <summary>
        /// Меняет звездного участника тренировки
        /// </summary>
        /// <param name="id">Id тренировки</param>
        /// <param name="starParticipants">Новый звездный участник</param>
        /// <returns>Обновленная тренировка</returns>
        Task<WorkoutDto> ChangeStarForWorkoutAsync(long id, StarParticipantsDto starParticipants);

        /// <summary>
        /// Удаляет тренировку по ее Id
        /// </summary>
        /// <param name="id">Id тренировки</param>
        /// <returns>Удаленная тренировка</returns>
        Task<WorkoutDto> RemoveWorkoutByIdAsync(long id);

        /// <summary>
        /// Добавляет упражнение для тренировки
        /// </summary>
        /// <param name="id">Id тренировки</param>
        /// <param name="exercise">Новое упражнение</param>
        /// <returns>Обновленная тренировка</returns>
        Task<WorkoutDto> AddExerciseForWorkoutAsync(long id, ExerciseDto exercise);

        /// <summary>
        /// Создает новый тренажер
        /// </summary>
        /// <param name="gymEquipmentDto"><see cref="GymEquipmentDto"/></param>
        /// <returns>Новый тренажер</returns>
        Task<GymEquipmentDto> CreateGymEquipmentAsync(GymEquipmentDto gymEquipmentDto);

        /// <summary>
        /// Создает связь между упражнением и тренажером
        /// </summary>
        /// <param name="idExercise">Id упражнения</param>
        /// <param name="idGymEquipment">Id тренажера</param>
        Task AddExerciseGymEquipmentAsync(long idExercise, long idGymEquipment);

        /// <summary>
        /// Копирует тренировку
        /// </summary>
        /// <param name="id">Id тренировки</param>
        /// <returns>Новая тренировка</returns>
        Task<WorkoutDto> CopyWorkoutDto(long id);

        /// <summary>
        /// Возвращает количество упражнений в тренировке, используя функцию бд
        /// </summary>
        /// <param name="id">Возвращает количество упражнений в тренировке</param>
        /// <returns>Количество упражнений в тренировке</returns>
        Task<int> GetCountExerciseInsideWorkoutByDbFunction(int id);

        /// <summary>
        /// Создает тенхический день
        /// </summary>
        /// <param name="technicalDaysDto"><see cref="TechnicalDaysDto"/></param>
        /// <returns>Новый технический день</returns>
        Task<TechnicalDays> CreateTechnicalDaysAsync(TechnicalDaysDto technicalDaysDto);
    }
}
