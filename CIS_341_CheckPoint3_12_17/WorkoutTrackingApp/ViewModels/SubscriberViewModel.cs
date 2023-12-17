namespace WorkoutTrackingApp.ViewModels
{
    // Need to use this. Or delete it. 
    public class SubscriberViewModel
    {
        public string Email { get; set; } 

        public DateTime SubscriptionStartDate { get; set; }
        public string SubscriptionStatus { get; set; }  

        public List<WorkoutViewModel> CompletedWorkouts { get; set; }  // List of completed workouts

        
      
    }
}
