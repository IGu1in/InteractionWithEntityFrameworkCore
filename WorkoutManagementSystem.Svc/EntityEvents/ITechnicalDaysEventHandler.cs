using WorkoutManagementSystem.Svc.Infrastracture;

namespace WorkoutManagementSystem.Svc.EntityEvents
{
    /// <summary>
    /// Обработчик события интеграции
    /// </summary>
    public interface ITechnicalDaysEventHandler
    {
        /// <summary>
        /// Проверка на необходимость проверки технического дня
        /// </summary>
        /// <param name="context"><see cref="WorkoutManagementSystemContext"/></param>
        /// <returns>Результат проверки</returns>
        bool NeedsCallToTechnicalDays(WorkoutManagementSystemContext context);

        /// <summary>
        /// Возвращает ошибки конфликта с техническими днями, либо пустую строку в случае их отсутствия
        /// </summary>
        /// <param name="context"><see cref="WorkoutManagementSystemContext"/></param>
        /// <returns>Результат проверки</returns>
        string GetError(WorkoutManagementSystemContext context);
    }
}
