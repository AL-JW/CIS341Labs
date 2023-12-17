namespace WorkoutTrackingApp.ViewModels
// Still not using this, either need to use this instead or delete it. 
{
    public class TrainerDashboardViewModel
    {
        // Basic trainer profile information
        public string TrainerName { get; set; }
        public string Email { get; set; }

        // Trainer's messages to and from users
        public IEnumerable<MessageViewModel> Messages { get; set; }

        // Manage workouts
        public IEnumerable<WorkoutViewModel> ManageWorkouts { get; set; }

        // Manage exercises,  similar to workouts, not using though 
        public IEnumerable<ExerciseViewModel> ManageExercises { get; set; }

        // Subscriber list, a list of all subscribers
        public IEnumerable<SubscriberViewModel> Subscribers { get; set; }

        // Popular workouts, a list of the trainers popular workouts
        public IEnumerable<WorkoutViewModel> PopularWorkouts { get; set; }

    }
}
