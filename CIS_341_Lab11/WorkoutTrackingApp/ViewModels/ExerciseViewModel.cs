using WorkoutTrackingApp.Models;

namespace WorkoutTrackingApp.ViewModels
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
        public string TargetMuscleGroup { get; set; }
        
        public ExerciseIntensity Intensity { get; set; }
        public string EquipmentRequired { get; set; }
        public string Difficulty { get; set; }       
    }
}
