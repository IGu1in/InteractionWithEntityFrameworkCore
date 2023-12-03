using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutManagementSystem.Svc.Migrations
{
    public partial class CreateCountExercisesInWorkoutFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"CREATE OR REPLACE FUNCTION CountExercisesInWorkout(pWorkoutId INT) " +
                $"RETURNS INT AS $$ DECLARE " +
                $"exercise_count INT; " +
                $"BEGIN " +
                $"SELECT COUNT(*) INTO exercise_count " +
                $"FROM \"Exercise\" " +
                "WHERE \"Exercise\".\"WorkoutId\" = pWorkoutId; " +
                "RETURN exercise_count; " +
                "END; " +
                "$$ LANGUAGE plpgsql; ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS CountExercisesInWorkout(INT);");
        }
    }
}
