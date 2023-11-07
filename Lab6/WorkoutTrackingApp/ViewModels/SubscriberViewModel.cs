namespace WorkoutTrackingApp.ViewModels
{
    public class SubscriberViewModel
    {
        public string UserName { get; set; }

        public DateTime SubscriptionStartDate { get; set; }
        public string SubscriptionStatus { get; set; } //could change this to a tier based

        public int NumberOfCompletedWorkouts { get; set; }

        public string ProfileUrl { get; set; }

    }
}
