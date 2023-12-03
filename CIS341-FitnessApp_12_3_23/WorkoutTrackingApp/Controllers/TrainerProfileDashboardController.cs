using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkoutTrackingApp.ViewModels;

namespace WorkoutTrackingApp.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    public class TrainerProfileDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        
        public IActionResult ManageWorkouts()
        {
            // This would normally come from a database or service.
            var exercises = new List<ExerciseViewModel>
        {
            // Populate with actual data
            new ExerciseViewModel { Name = "Squat", Description = "A leg exercise.", /* ... other properties ... */ },
            // ... other exercises ...
        };

            return View(exercises);
        }

      
        public IActionResult ManageExercises()
        {
            //Also will fill up with database 
            var exerciseList = new List<ExerciseViewModel>
            {
                new ExerciseViewModel
                {
                    Name = "Push-up",
                    Description = "A push-up, go in plank position and bend arms down to 90 degrees and then back up...",
                    TargetMuscleGroup = "Chest",
                    EquipmentRequired = "None",
                    Difficulty = "Begineer",
                },
            };
            return View(exerciseList);           
        }

       
        public IActionResult Subscribers()
        {
            //This will be replaced with the database when it gets created and hooked up
            var subscriberList = new List<SubscriberViewModel>
            {
                new SubscriberViewModel
                {
                    UserName = "User1",
                    SubscriptionStartDate = DateTime.Now.AddMonths(-1),
                    SubscriptionStatus = "Active",
                    NumberOfCompletedWorkouts = 15
                },          
            };
            return View(subscriberList);
        }

        
        public IActionResult PopularWorkouts()
        {
            return View();
        }
    }
}
