using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTrackingApp.Migrations.WorkoutTrackingApp
{
    /// <inheritdoc />
    public partial class RemovedWorkoutIdForeignKeyFromExerciseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropIndex(
                name: "IX_Exercises_WorkoutId", 
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                 name: "FK_Exercises_Workouts_WorkoutId",
                 table: "Exercises");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Exercises");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Exercises",
                nullable: true); 

            
            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId", 
                onDelete: ReferentialAction.Restrict); 

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");
        }
    }
}
