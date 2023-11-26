using System.ComponentModel.DataAnnotations;

namespace TodoApi
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; } //PrimaryKey

        [Required]
        [Display(Name = "Exercsise Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Length/Intensity")]
        public string Length { get; set; }
    }
}
