using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTrackingApp.Models
{
    public class TrackedWorkout
    {
        [Key]
        public int TrackedWorkoutId { get; set; } // The primary key for tracked workouts

        [Required]
        public int WorkoutId { get; set; }  // Foreign key for a workout
        public virtual Workout Workout { get; set; } // Navigation property to Workout

        [Required]
        public int AccountId { get; set; } // Foreign key to Account
        public virtual Account Account { get; set; } // Navigation property to Account


        [Required]
        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }

        [Required]
        [Display(Name = "Number of Sets")] 
        public int NumberOfSets { get; set; } // Attributes for sets

        [Required]
        [Display(Name = "Number of Reps")]
        public int NumberOfReps { get; set; }  // Attribute for reps 

    }
}
