using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutManagementSystem.Svc.Migrations
{
    public partial class AddColumnNameForGymEquipmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GymEquipment",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "GymEquipment");
        }
    }
}
