using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkoutManagementSystem.Svc;
using WorkoutManagementSystem.Svc.AutoMapperProfiles;
using WorkoutManagementSystem.Svc.EntityEvents;
using WorkoutManagementSystem.Svc.Infrastracture;

namespace WorkoutManagementSystemTest
{
    /// <summary>
    /// Класс для тестирования WorkoutManagementSystem, с использование базы данных промышленного типа
    /// </summary>
    public class WorkoutManagementSystemTest
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345678;Database=WorkoutManagementSystemServerTest;";
        private IMapper _mapper;
        private ITechnicalDaysEventHandler eventHandler;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        [SetUp]
        public void Setup()
        {
            eventHandler = new TechnicalDaysEventHandler();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                   cfg.AddProfile(typeof(WorkouManagerSystemProfile));
            });
            _mapper = mapConfig.CreateMapper();
        }

        [Test]
        public void Test_GetCountExerciseInsideWorkoutByDbFunction()
        {
            var workoutId = 5;
            var expectedValue = 2;

            var builder = new DbContextOptionsBuilder<WorkoutManagementSystemContext>();
            builder.UseNpgsql(_connectionString);

            using (var context = new WorkoutManagementSystemContext(builder.Options, eventHandler))
            {
                using var transaction = context.Database.BeginTransaction();

                var workoutManagementsSystemService = new WorkoutManagementsSystemService(_mapper, context, _serviceScopeFactory);

                var value =  workoutManagementsSystemService.GetCountExerciseInsideWorkoutByDbFunction(workoutId);

                Assert.That(value.Result, Is.EqualTo(expectedValue));
            }
        }
    }
}