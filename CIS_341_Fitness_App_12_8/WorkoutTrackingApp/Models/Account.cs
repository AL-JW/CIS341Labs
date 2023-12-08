using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackingApp.Models
{
    public class Account
    {
        [Key] 
        public int AccountId { get; set; } // Primary key

        [Required]
        [Display(Name = "Name/Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

        public virtual ICollection<TrackedWorkout> TrackedWorkouts { get; set; }
    }
}
