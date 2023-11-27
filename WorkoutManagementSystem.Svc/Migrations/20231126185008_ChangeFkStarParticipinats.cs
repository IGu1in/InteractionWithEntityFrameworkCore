using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutManagementSystem.Svc.Migrations
{
    public partial class ChangeFkStarParticipinats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_StarParticipants_StarParticipantsId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_StarParticipantsId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "StarParticipantsId",
                table: "Workouts");

            migrationBuilder.AddColumn<long>(
                name: "WorkoutId",
                table: "StarParticipants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_StarParticipants_WorkoutId",
                table: "StarParticipants",
                column: "WorkoutId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StarParticipants_Workouts_WorkoutId",
                table: "StarParticipants",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StarParticipants_Workouts_WorkoutId",
                table: "StarParticipants");

            migrationBuilder.DropIndex(
                name: "IX_StarParticipants_WorkoutId",
                table: "StarParticipants");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "StarParticipants");

            migrationBuilder.AddColumn<long>(
                name: "StarParticipantsId",
                table: "Workouts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_StarParticipantsId",
                table: "Workouts",
                column: "StarParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_StarParticipants_StarParticipantsId",
                table: "Workouts",
                column: "StarParticipantsId",
                principalTable: "StarParticipants",
                principalColumn: "Id");
        }
    }
}
