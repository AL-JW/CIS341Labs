using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTrackingApp.Models
{
    public class Workout
    {
        public Workout()
        {
            WorkoutExercises = new HashSet<WorkoutExercise>();
        }
       
        // Foreign key to identify the user from the Identity Database
        public string UserId { get; set; }

        [Key]
        public int WorkoutId { get; set; } // Primary key

       // [Required]
        [Display(Name = "Workout Name")]
        public string Name { get; set; }

        // [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
