using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WorkoutManagementSystem.Svc.Migrations
{
    public partial class CreateStarParticipantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StarParticipantsId",
                table: "Workouts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StarParticipants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Achievements = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarParticipants", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_StarParticipants_StarParticipantsId",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "StarParticipants");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_StarParticipantsId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "StarParticipantsId",
                table: "Workouts");
        }
    }
}
