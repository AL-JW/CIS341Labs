using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTrackingApp.Migrations.WorkoutTrackingApp
{
    /// <inheritdoc />
    public partial class AddDescriptionToWorkoutsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Exercises_Workouts_WorkoutId",
            //    table: "Exercises");

            //migrationBuilder.DropIndex(
            //    name: "IX_Exercises_WorkoutId",
            //    table: "Exercises");

            //migrationBuilder.DropColumn(
            //    name: "WorkoutId",
            //    table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Workouts");

            //migrationBuilder.AddColumn<int>(
            //    name: "WorkoutId",
            //    table: "Exercises",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Exercises_WorkoutId",
            //    table: "Exercises",
            //    column: "WorkoutId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Exercises_Workouts_WorkoutId",
            //    table: "Exercises",
            //    column: "WorkoutId",
            //    principalTable: "Workouts",
            //    principalColumn: "WorkoutId",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
