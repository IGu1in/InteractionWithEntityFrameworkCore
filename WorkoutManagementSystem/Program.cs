using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WorkoutManagementSystem.Svc;
using WorkoutManagementSystem.Svc.AutoMapperProfiles;
using WorkoutManagementSystem.Svc.Contract;
using WorkoutManagementSystem.Svc.EntityEvents;
using WorkoutManagementSystem.Svc.Infrastracture;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureService(builder);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkoutManagement");
            });
        }
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.Run();
    }

    private static void ConfigureService(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddDbContext<WorkoutManagementSystemContext>(options => options.UseNpgsql(
            webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection")
        ));
        webApplicationBuilder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
        webApplicationBuilder.Services.AddSwaggerGen();
        webApplicationBuilder.Services.AddAutoMapper(typeof(WorkouManagerSystemProfile));
        webApplicationBuilder.Services.AddScoped<IWorkoutManagementsSystemService, WorkoutManagementsSystemService>();
        webApplicationBuilder.Services.AddScoped<ITechnicalDaysEventHandler, TechnicalDaysEventHandler>();
    }
}