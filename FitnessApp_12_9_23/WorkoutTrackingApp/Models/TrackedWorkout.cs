using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTrackingApp.Models
{
    public class TrackedWorkout
    {
        [Key]
        public int TrackedWorkoutId { get; set; } // The primary key for tracked workouts

        [Required]
        public int WorkoutId { get; set; }

        [Required]
        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }
        
    }
}
