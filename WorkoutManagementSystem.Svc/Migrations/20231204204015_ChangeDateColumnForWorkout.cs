using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutManagementSystem.Svc.Migrations
{
    public partial class ChangeDateColumnForWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCreation",
                table: "Workouts",
                newName: "TrainingDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainingDate",
                table: "Workouts",
                newName: "DateCreation");
        }
    }
}
