namespace WorkoutTrackingApp.ViewModels
{
    public class WorkoutViewModel
    {
        public int WorkoutID { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }
        public string Description { get; set; }

        public string Difficulty { get; set; }

        public List<int> SelectedExercises { get; set; }
    }
}
