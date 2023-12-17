using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackingApp.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; } // Primary Key


       public int SenderId { get; set; } // Sender's AccountId
        
       public int RecipientId { get; set; } // Recipient's AccountId

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        
        // Navigation Properties 
        public virtual Account Sender { get; set; }
        public virtual Account Recipient { get; set; }

        public int? SelectedWorkoutId { get; set; }
        public int? SelectedExerciseId { get; set; }
        // Navigation properties
        public virtual Workout SelectedWorkout { get; set; }
        public virtual Exercise SelectedExercise { get; set; }

    }
}
