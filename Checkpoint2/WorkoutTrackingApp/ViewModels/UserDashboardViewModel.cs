namespace WorkoutTrackingApp.ViewModels
{
    public class UserDashboardViewModel
    {
        // User profile information
        public string UserName { get; set; }
        public string Email { get; set; }


        // Subscription Details
        public bool IsSubscribed { get; set; }
        public DateTime SubscriptionEndDate { get; set; }


        // List of recent workouts
        public IEnumerable<WorkoutViewModel> RecentWorkouts { get; set; }

        // Messages user has
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
