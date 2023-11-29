using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutManagementSystem.Svc.Migrations
{
    public partial class AddMaxLengthAchievementsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Achievements",
                table: "StarParticipants",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Achievements",
                table: "StarParticipants",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);
        }
    }
}
