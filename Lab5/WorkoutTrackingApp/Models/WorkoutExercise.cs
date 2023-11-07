using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTrackingApp.Models
{
    public class WorkoutExercise
    {
        [Key]
        public int WorkoutExerciseID { get; set; } //Primary Key for this join table

        [ForeignKey("Workout")]
        public int WorkoutID { get; set; } //Foreign key to Workout
        public Workout Workout { get; set; } //Navigation property to Workout

        [ForeignKey("Exercise")]
        public int ExerciseID { get; set;} //Foreign key to exercise
        public Exercise Exercise { get; set; } //Navigation to exercise
    }
}
