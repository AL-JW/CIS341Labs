using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTrackingApp.Migrations.WorkoutTrackingApp
{
    /// <inheritdoc />
    public partial class FixingIntensityColumnValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Intensity",
                table: "Exercises",
                type: "int", 
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)" 
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Intensity",
            table: "Exercises",
            type: "nvarchar(max)", 
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int"
             );

        }
    }
}
