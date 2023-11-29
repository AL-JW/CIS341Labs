using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTrackingApp.Models
{
    public class Workout
    {

       // public int AccountId { get; set; }

        //Navigation property
        //[ForeignKey("AccountId")]
        //public virtual Account Account { get; set; }

        [Key]
        public int WorkoutId { get; set; } //Primary key

        

        [Required]
        [Display(Name = "Workout Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        //[Display(Name = "Select Exercises")]
        //public int[] ExerciseIds { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
        
       //Navigation property for join table WorkoutExercise

        //Probably do not need this along with the Exercies
        //public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }


    }
}
