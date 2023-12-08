using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackingApp.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; } // Primary Key


        [Required]
        [Display(Name = "Recipient")]
        public string Recipient { get; set; }

        [Required]
        [Display(Name = "Sender")]
        public string Sender { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
    }
}
