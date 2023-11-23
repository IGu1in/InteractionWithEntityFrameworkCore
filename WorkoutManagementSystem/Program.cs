using Microsoft.EntityFrameworkCore;
using WorkoutManagementSystem.Svc.Infrastracture;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WorkoutManagementSystemContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
