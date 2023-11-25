using Microsoft.EntityFrameworkCore;
using WorkoutManagementSystem.Svc;
using WorkoutManagementSystem.Svc.Contract;
using WorkoutManagementSystem.Svc.Infrastracture;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<WorkoutManagementSystemContext>(options => options.UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ));
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IWorkoutManagementsSystemService, WorkoutManagementsSystemService>();

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
}