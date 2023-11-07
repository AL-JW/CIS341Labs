using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTrackingApp.Models
{
    public class TrackedWorkout
    {
        [Key]
        public int TrackedWorkoutId { get; set; } //The primary key for tracked workouts

        //Foreign key property
        [ForeignKey("Account")]
        public int AccountID { get; set; }

        //The navigation property needed with the foreign key
        //public virtual Account Account { get; set; }

        [Required]
        public Workout Workout { get; set; }

        [Required]
        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }

        [Required]
        public Account Account { get; set; }
    }
}
