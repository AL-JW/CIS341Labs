namespace WorkoutTrackingApp.ViewModels
{
    public class TrainerDashboardViewModel
    {
        // Basic trainer profile information
        public string TrainerName { get; set; }
        public string Email { get; set; }

        //Trainer's messages to and from users
        public IEnumerable<MessageViewModel> Messages { get; set; }

        // Manage workouts - This can include summaries or a list of workouts the trainer has created
        public IEnumerable<WorkoutViewModel> ManageWorkouts { get; set; }

        //Manage exercises - Similar to workouts, a list of 
        public IEnumerable<ExerciseViewModel> ManageExercises { get; set; }

        //Subscriber list - A list 
        public IEnumerable<SubscriberViewModel> Subscribers { get; set; }

        //Popular workouts - A list of the trainer's 
        public IEnumerable<WorkoutViewModel> PopularWorkouts { get; set; }

    }
}
